using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batchery
{
    class BatchManager
    {
        public delegate void OnEndCallback(int exitCode);
        private OnEndCallback m_onEndCallback;

        public delegate void OnRunFileCallback(string stepName, int stepIdx, int numSteps);
        private OnRunFileCallback m_onRunFileCallback;

        public delegate void OnTextRecievedCallback(string text);
        private OnTextRecievedCallback m_onStdOutRecievedCallback;
        private OnTextRecievedCallback m_onStdErrRecievedCallback;

        public delegate void OnStatusRecievedCallback(string text, bool err);
        private OnStatusRecievedCallback m_onStatusRecievedCallback;

        private System.Windows.Forms.CheckedListBox m_listBox;
        private bool m_suspendBatchListItemCheck = false;

        private Queue<(BatchItem, int)> m_BatchFiles = new Queue<(BatchItem, int)>();
        private (BatchItem, int) m_RunningTuple = (null, 0);
        private Process m_BatchProcess;

        private int m_stepIdx = 0;
        private int m_numSteps = 0;

        private Stopwatch m_stepStopwatch;

        public BatchManager(System.Windows.Forms.CheckedListBox listBox)
        {
            m_listBox = listBox;
            m_listBox.DisplayMember = "DisplayName";
        }

        public void OnRun(OnEndCallback onEnd, OnRunFileCallback onRunFile, OnTextRecievedCallback stdOutCallback, OnTextRecievedCallback stdErrCallback, OnStatusRecievedCallback statusCallback)
        {
            m_onEndCallback = onEnd;
            m_onRunFileCallback = onRunFile;
            m_onStdOutRecievedCallback = stdOutCallback;
            m_onStdErrRecievedCallback = stdErrCallback;
            m_onStatusRecievedCallback = statusCallback;

            if (m_listBox.CheckedItems.Count > 0)
            {
                m_BatchFiles.Clear();

                foreach (BatchItem item in m_listBox.CheckedItems)
                {
                    for (int i = 0; i < item.Iterations; i++)
                    {
                        m_BatchFiles.Enqueue((item, i));
                    }
                }

                m_numSteps = m_BatchFiles.Count;
                m_stepIdx = 0;

                m_BatchProcess = new Process();

                m_BatchProcess.StartInfo.UseShellExecute = false;
                m_BatchProcess.StartInfo.CreateNoWindow = true;

                m_BatchProcess.StartInfo.RedirectStandardOutput = true;
                m_BatchProcess.OutputDataReceived += OnStdOut;

                m_BatchProcess.StartInfo.RedirectStandardError = true;
                m_BatchProcess.ErrorDataReceived += OnStdErr;

                m_BatchProcess.EnableRaisingEvents = true;
                m_BatchProcess.Exited += OnProcess_Exited;

                RunNext();
            }
            else
            {
                m_onRunFileCallback("Nothing to do!", 0, 0);

                ClearCallbacks();

                onEnd(-1);
            }
        }

        private void ClearCallbacks()
        {
            if (m_stepStopwatch != null)
            {
                m_stepStopwatch.Stop();
            }

            m_onEndCallback = null;
            m_onRunFileCallback = null;
            m_onStdOutRecievedCallback = null;
            m_onStdErrRecievedCallback = null;
            m_onStatusRecievedCallback = null;
        }

        private void RunNext()
        {
            m_RunningTuple = m_BatchFiles.Dequeue();

            BatchItem item = m_RunningTuple.Item1;
            int iteration = m_RunningTuple.Item2;

            m_stepIdx++;

            if (item.Iterations > 1)
            {
                OnStatus("Step " + m_stepIdx.ToString() + " / " + m_numSteps.ToString() + ": " + item.DisplayName + " (" + (iteration + 1).ToString() + " / " + item.Iterations.ToString() + ")", false);
            }
            else
            {
                OnStatus("Step " + m_stepIdx.ToString() + " / " + m_numSteps.ToString() + ": " + item.DisplayName, false);
            }

            m_BatchProcess.StartInfo.FileName = item.FilePath;
            m_BatchProcess.StartInfo.Arguments = item.Arguments;
            m_BatchProcess.StartInfo.WorkingDirectory = item.WorkingDirectory;

            m_onRunFileCallback(item.DisplayName, m_stepIdx, m_numSteps);

            m_stepStopwatch = Stopwatch.StartNew();

            try
            {
                m_BatchProcess.Start();

                m_BatchProcess.BeginOutputReadLine();
                m_BatchProcess.BeginErrorReadLine();
            }
            catch (Exception e)
            {
                OnStatus("Exception Thrown: " + e.Message, true);
                System.Windows.Forms.MessageBox.Show(e.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (m_onEndCallback != null)
                {
                    OnEndCallback temp = m_onEndCallback;
                    ClearCallbacks();
                    temp(-1);
                }
            }
        }

        private void OnProcess_Exited(object sender, EventArgs e)
        {
            // Process has exited; call this to wait for the output to all be processed.
            m_BatchProcess.WaitForExit();

            try
            {
                m_BatchProcess.CancelOutputRead();
                m_BatchProcess.CancelErrorRead();
            }
            catch(Exception)
            {
                // Okay if these fail.
            }


            m_stepStopwatch.Stop();
            TimeSpan elapsedTime = m_stepStopwatch.Elapsed;
            string elapsedTimeString = elapsedTime.ToString(@"mm\:ss\.ff");

            int exitCode = -1;
            if (m_BatchProcess.HasExited)
            {
                exitCode = m_BatchProcess.ExitCode;
                OnStatus("Exited in " + elapsedTimeString + " with code: " + m_BatchProcess.ExitCode, (exitCode != 0));
            }

            if (m_RunningTuple.Item2 == (m_RunningTuple.Item1.Iterations - 1))
            {
                if ((m_RunningTuple.Item1.DisableOnSuccess) && ((exitCode == 0) || (m_RunningTuple.Item1.AbortOnNonZeroExitCode == false)))
                {
                    UncheckItem(m_RunningTuple.Item1);
                }
            }

            bool endNow = true;
            if (m_BatchFiles.Count > 0)
            {
                if ((exitCode == 0) || (m_RunningTuple.Item1.AbortOnNonZeroExitCode == false))
                {
                    endNow = false;
                    RunNext();
                }
                else
                {
                    OnStatus("Aborting due to nonzero exit code", true);
                }
            }

            if (endNow == true)
            {
                m_RunningTuple = (null, 0);
                if (m_onEndCallback != null)
                {
                    OnEndCallback temp = m_onEndCallback;
                    ClearCallbacks();
                    temp(exitCode);
                }
            }
        }
        private void UncheckItem(BatchItem item)
        {
            if (m_listBox.InvokeRequired)
            {
                m_listBox.Invoke(new Action<BatchItem>(UncheckItem), item);
            }
            else
            {
                m_suspendBatchListItemCheck = true;

                m_RunningTuple.Item1.IsChecked = false;
                m_listBox.SetItemChecked(m_listBox.Items.IndexOf(m_RunningTuple.Item1), false);

                m_suspendBatchListItemCheck = false;
            }
        }

        public void OnCancel()
        {
            OnStatus("Cancelled!", true);
            m_BatchFiles.Clear();
            m_BatchProcess.Kill(true);
        }

        private void OnStdOut(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                m_onStdOutRecievedCallback(Environment.NewLine + outLine.Data.ToString());
            }
        }

        private void OnStdErr(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                m_onStdErrRecievedCallback(Environment.NewLine + outLine.Data.ToString());
            }
        }

        private void OnStatus(string text, bool err = false)
        {
            if (m_onStatusRecievedCallback != null)
            {
                m_onStatusRecievedCallback(text, err);
            }
        }

        public void LoadFromSettings()
        {
            m_suspendBatchListItemCheck = true;

            if (SessionSettings.Default.SerializedBatchItems.Length > 0)
            {
                BatchItem[] items = BatchItem.DeserializeArray(SessionSettings.Default.SerializedBatchItems);
                foreach (BatchItem item in items)
                {
                    m_listBox.Items.Add(item, item.IsChecked);
                }
            }

            m_suspendBatchListItemCheck = false;
        }

        public void SaveToSettings()
        {
            SessionSettings.Default.SerializedBatchItems = BatchItem.SerializeArray(m_listBox.Items.Cast<BatchItem>().ToArray());
        }

        public void OnAdd(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.Filter           = "Batch files (*.bat)|*.bat|Command Files (*.cmd)|*.cmd|Executable Files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.Multiselect      = true;
            openFileDialog.CheckFileExists  = true;
            openFileDialog.ShowDialog();

            foreach (string file in openFileDialog.FileNames)
            {
                m_listBox.Items.Add(new BatchItem(file));
            }
        }

        public void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Copy;
            }
        }

        public void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
            foreach (string file in files)
            { 
                m_listBox.Items.Add(new BatchItem(file));
            }
        }

        public void OnRemove(object sender, EventArgs e)
        {
            m_listBox.Items.RemoveAt(m_listBox.SelectedIndex);
        }

        private string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }

        public void OnEdit(object sender, EventArgs e)
        {
            string editor = System.IO.Path.GetFullPath(((BatchItem)m_listBox.SelectedItem).Editor);
            string fullPath = System.IO.Path.GetFullPath(((BatchItem)m_listBox.SelectedItem).FileToEdit);
            if (CheckIfFileExists(editor) && CheckIfFileExists(fullPath))
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(editor, AddQuotesIfRequired(fullPath));
            }
        }

        public void OnUp(object sender, EventArgs e)
        {
            m_suspendBatchListItemCheck = true;
            
            int curIndex = m_listBox.SelectedIndex;
            int newIndex = curIndex - 1;
            object curSelected = m_listBox.SelectedItem;
            bool isChecked = m_listBox.GetItemChecked(curIndex);

            m_listBox.Items.RemoveAt(curIndex);
            m_listBox.Items.Insert(newIndex, curSelected);
            m_listBox.SelectedItem = curSelected;
            m_listBox.SetItemChecked(newIndex, isChecked);

            m_suspendBatchListItemCheck = false;
        }

        public void OnDown(object sender, EventArgs e)
        {
            m_suspendBatchListItemCheck = true;

            int curIndex = m_listBox.SelectedIndex;
            int newIndex = curIndex + 1;
            object curSelected = m_listBox.SelectedItem;
            bool isChecked = m_listBox.GetItemChecked(curIndex);

            m_listBox.Items.RemoveAt(curIndex);
            m_listBox.Items.Insert(newIndex, curSelected);
            m_listBox.SelectedItem = curSelected;
            m_listBox.SetItemChecked(newIndex, isChecked);

            m_suspendBatchListItemCheck = false;
        }

        public void OnCheckAll(object sender, EventArgs e)
        {
            m_suspendBatchListItemCheck = true;
            
            for (int i = 0; i < m_listBox.Items.Count; i++)
            {
                m_listBox.SetItemChecked(i, true);
            }

            m_suspendBatchListItemCheck = false;
        }

        public void OnUncheckAll(object sender, EventArgs e)
        {
            m_suspendBatchListItemCheck = true;
            
            for (int i = 0; i < m_listBox.Items.Count; i++)
            {
                m_listBox.SetItemChecked(i, false);
            }

            m_suspendBatchListItemCheck = false;
        }

        public void OnItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (m_suspendBatchListItemCheck == false)
            {
                //if the click isn't on an item (and on the white space)
                if (m_listBox.IndexFromPoint(m_listBox.PointToClient(System.Windows.Forms.Cursor.Position).X,
                                             m_listBox.PointToClient(System.Windows.Forms.Cursor.Position).Y) <= -1)
                {
                    e.NewValue = e.CurrentValue;
                    m_listBox.ClearSelected();
                }
            }

            ((BatchItem)(m_listBox.Items[e.Index])).IsChecked = (e.NewValue == System.Windows.Forms.CheckState.Checked);
        }

        public static bool CheckIfFileExists(string file)
        {
            bool ret = true;

            if (System.IO.File.Exists(file) == false)
            {
                System.Windows.Forms.MessageBox.Show("Cannot find '" + System.IO.Path.GetFileName(file) + "'", "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ret = false;
            }

            return ret;
        }
    }
}
