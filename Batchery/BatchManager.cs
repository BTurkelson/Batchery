using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batchery
{
    class BatchManager
    {
        public delegate void OnEndCallback(int exitCode);
        private OnEndCallback m_onEndCallback;

        public delegate void OnTextRecievedCallback(string text);
        private OnTextRecievedCallback m_onStdOutRecievedCallback;
        private OnTextRecievedCallback m_onStdErrRecievedCallback;

        private System.Windows.Forms.CheckedListBox m_listBox;
        private bool m_suspendBatchListItemCheck = false;

        private Queue<string> m_BatchFiles = new Queue<string>();
        private System.Diagnostics.Process m_BatchProcess;

        public BatchManager(System.Windows.Forms.CheckedListBox listBox)
        {
            m_listBox = listBox;
        }

        public void OnRun(OnEndCallback callback, OnTextRecievedCallback stdOutCallback, OnTextRecievedCallback stdErrCallback)
        {
            m_onEndCallback = callback;
            m_onStdOutRecievedCallback = stdOutCallback;
            m_onStdErrRecievedCallback = stdErrCallback;
            
            if (m_listBox.CheckedItems.Count > 0)
            {
                m_BatchFiles.Clear();

                foreach (string file in m_listBox.CheckedItems)
                {
                    m_BatchFiles.Enqueue(file);
                }

                m_BatchProcess = new System.Diagnostics.Process();

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
                WriteTextBox("Nothing to do!");

                m_onEndCallback = null;
                m_onStdOutRecievedCallback = null;
                m_onStdErrRecievedCallback = null;

                callback(-1);
            }
        }

        private void RunNext()
        {
            string file = m_BatchFiles.Dequeue();

            WriteTextBox("Starting " + file);

            m_BatchProcess.StartInfo.FileName = file;
            m_BatchProcess.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(file);

            try
            {
                m_BatchProcess.Start();

                m_BatchProcess.BeginOutputReadLine();
                m_BatchProcess.BeginErrorReadLine();
            }
            catch (Exception e)
            {
                WriteTextBox("Exception Thrown: " + e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (m_onEndCallback != null)
                {
                    OnEndCallback temp = m_onEndCallback;
                    m_onEndCallback = null;
                    m_onStdOutRecievedCallback = null;
                    m_onStdErrRecievedCallback = null;
                    temp(-1);
                }
            }
        }

        private void OnProcess_Exited(object sender, EventArgs e)
        {
            m_BatchProcess.CancelOutputRead();
            m_BatchProcess.CancelErrorRead();

            int exitCode = -1;
            if (m_BatchProcess.HasExited)
            {
                exitCode = m_BatchProcess.ExitCode;
                WriteTextBox("Exited with code: " + m_BatchProcess.ExitCode);
            }

            bool endNow = true;
            if (m_BatchFiles.Count > 0)
            {
                if (exitCode == 0)
                {
                    endNow = false;
                    RunNext();
                }
                else
                {
                    WriteTextBox("Aborting due to nonzero exit code");
                }
            }
            
            if ((endNow == true) && (m_onEndCallback != null))
            {
                OnEndCallback temp = m_onEndCallback;
                m_onEndCallback = null;
                m_onStdOutRecievedCallback = null;
                m_onStdErrRecievedCallback = null;
                temp(exitCode);
            }
        }

        public void OnCancel()
        {
            WriteTextBox("Cancelled!");
            m_BatchFiles.Clear();
            m_BatchProcess.Kill(true);
        }

        private void WriteTextBox(string toWrite)
        {
            string outString = Environment.NewLine;
            // Rich Text Box doesn't like box characters; it switches them all to Segoe UI for some reason.
            //outString += "┏━" + new string('━', toWrite.Length) + "━┓" + Environment.NewLine;
            //outString += "┃ " + toWrite                         + " ┃" + Environment.NewLine;
            //outString += "┗━" + new string('━', toWrite.Length) + "━┛" + Environment.NewLine;
            outString += "==" + new string('=', toWrite.Length) + "==" + Environment.NewLine;
            outString += "= " + toWrite                         + " =" + Environment.NewLine;            
            outString += "==" + new string('=', toWrite.Length) + "==" + Environment.NewLine;
            m_onStdOutRecievedCallback(outString);
            m_onStdErrRecievedCallback(outString);
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

        public void LoadFromSettings()
        {
            m_suspendBatchListItemCheck = true;

            if (SessionSettings.Default.BatchFiles != null)
            {
                foreach (string file in SessionSettings.Default.BatchFiles)
                {
                    m_listBox.Items.Add(file);
                }
            }

            if (SessionSettings.Default.SelectedBatchIndices != null)
            {
                foreach (int index in SessionSettings.Default.SelectedBatchIndices)
                {
                    m_listBox.SetItemChecked(index, true);
                }
            }

            m_suspendBatchListItemCheck = false;
        }

        public void SaveToSettings()
        {
            string[] files = new string[m_listBox.Items.Count];
            int i = 0;
            foreach (string file in m_listBox.Items)
            {
                files[i++] = file;
            }
            SessionSettings.Default.BatchFiles = files;

            Int32[] checkedIndices = new Int32[m_listBox.CheckedItems.Count];
            i = 0;
            foreach (int index in m_listBox.CheckedIndices)
            {
                checkedIndices[i++] = index;
            }
            SessionSettings.Default.SelectedBatchIndices = checkedIndices;
        }

        public void OnAdd(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the output
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.Filter           = "Batch files (*.bat)|*.bat|Command Files (*.cmd)|*.cmd|All files (*.*)|*.*";
            openFileDialog.Multiselect      = true;
            openFileDialog.CheckFileExists  = true;
            openFileDialog.ShowDialog();

            foreach (string file in openFileDialog.FileNames)
            {
                m_listBox.Items.Add(file);
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
                m_listBox.Items.Add(file);
            }
        }

        public void OnRemove(object sender, EventArgs e)
        {
            m_listBox.Items.RemoveAt(m_listBox.SelectedIndex);
        }

        public void OnEdit(object sender, EventArgs e)
        {
            string fullPath = System.IO.Path.GetFullPath(m_listBox.SelectedItem.ToString());
            if (CheckIfFileExists(fullPath))
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start("Notepad.exe", fullPath);
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
        }

        private bool CheckIfFileExists(string file)
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
