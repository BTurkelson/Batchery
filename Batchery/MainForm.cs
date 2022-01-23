using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batchery
{
    public partial class MainForm : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private System.Drawing.Text.PrivateFontCollection fonts = new System.Drawing.Text.PrivateFontCollection();
        private Font m_OutputFont;
        private Font m_StatusFont = new Font("Bahnschrift Light", 11, FontStyle.Regular);

        private Color m_GoodColor = System.Drawing.Color.LightGreen;
        private Color m_GoodColorLight = Color.FromArgb(0xDC, 0xE8, 0xDC);
        private Color m_BadColor = System.Drawing.Color.LightCoral;
        private Color m_BadColorLight = Color.FromArgb(0xEA, 0xDE, 0xDE);

        private RichTextBox m_curVisibleTextBox;

        private string m_PreFindCurVisibleTextRtf;

        private BatchManager m_batchManager;

        private int m_TotalFinds = 0;
        private int m_CurrentFind = 0;

        private bool m_OptionsShown = true;

        private System.Timers.Timer m_RunTimer;
        private string m_progressBarTextWithoutTime;
        private DateTime m_StartTime;

        enum OptionsBrowseButtonsEnum
        {
            FilePath,
            WorkingDir,
            Editor,
            FileToEdit,
        }

        enum MainTabControlIndices : int
        {
            Output = 0,
            BatchFiles,
            Settings,
        }

        enum ContextMenu2Indices : int
        {
            CheckAll = 0,
            UncheckAll,
            Separator1,
            Add,
            Remove,
            Up,
            Down,
            Separator2,
            Edit,
            Options,
        }

        public MainForm()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.RobotoMono_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontData.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            m_OutputFont = new Font(fonts.Families[0], 10.0F);

            m_batchManager = new BatchManager(batchCheckedListBox);

            m_RunTimer = new System.Timers.Timer();
            m_RunTimer.Interval = 1000;
            m_RunTimer.AutoReset = true;
            m_RunTimer.Elapsed += OnRunTimerTick;

            HideOptions();

            favoritesSplitContainer.Panel1Collapsed = true;
        }

        ~MainForm()
        {
            m_RunTimer.Dispose();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F5) && (runButton.Enabled))
            {
                mainTabControl.SelectTab((int)MainTabControlIndices.Output);
                runButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if ((e.KeyCode == Keys.Escape) && (cancelButton.Enabled))
            {
                mainTabControl.SelectTab((int)MainTabControlIndices.Output);
                cancelButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if ((e.Control) && (e.KeyCode == Keys.F) && (findPanel.Visible == false))
            {
                if (mainTabControl.SelectedIndex == (int)MainTabControlIndices.Output)
                {
                    OpenFindPanel(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if ((e.KeyCode == Keys.Enter) && (findTextBox.Focused))
            {
                if (findNextButton.Enabled)
                {
                    findNextButton_Click(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if ((e.KeyCode == Keys.F3) && (findPanel.Visible))
            {
                if (e.Shift)
                {
                    if (findPrevButton.Enabled)
                    {
                        findPrevButton_Click(sender, e);
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
                else
                {
                    if (findNextButton.Enabled)
                    {
                        findNextButton_Click(sender, e);
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            else if ((e.KeyCode == Keys.Escape) && (findPanel.Visible))
            {
                CloseFindPanel(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            m_PreFindCurVisibleTextRtf = "";
            CloseFindPanel(sender, e);

            stdTextBox.DeselectAll();
            errTextBox.DeselectAll();

            stdTextBox.SelectionStart = 0;
            errTextBox.SelectionStart = 0;

            stdTextBox.Clear();
            errTextBox.Clear();

            cancelButton.Enabled = true;
            runButton.Enabled = false;

            contextMenuStrip1.Enabled = false;

            // Disable other tabs (aside from 0) during a run.
            for (int i = 1; i < mainTabControl.TabCount; i++)
            {
                mainTabControl.TabPages[i].Enabled = false;
            }

            textProgressBar.Value = 0;
            textProgressBar.ProgressColor = m_GoodColor;
            textProgressBar.Invalidate();

            m_StartTime = DateTime.Now;
            m_RunTimer.Start();

            m_batchManager.OnRun(onBatchRunEnd, onBatchRunFile, onStdOutRecieved, onStdErrRecieved, onStatusRecieved);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            m_batchManager.OnCancel();
        }

        private void onBatchRunEnd(int exitCode)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(onBatchRunEnd), exitCode);
            }
            else
            {
                m_RunTimer.Stop();

                if (exitCode == 0)
                {
                    TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress);

                    textProgressBar.Maximum = 1;
                    textProgressBar.Value = 1;
                    textProgressBar.ProgressColor = m_GoodColor;
                    m_progressBarTextWithoutTime = "Success!";
                    UpdateProgressBarTextWithTime();
                    textProgressBar.Invalidate();
                }
                else
                {
                    TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Error);

                    textProgressBar.Maximum = 1;
                    textProgressBar.Value = 1;
                    textProgressBar.ProgressColor = m_BadColor;
                    UpdateProgressBarTextWithTime();
                    textProgressBar.Invalidate();
                }

                System.Media.SystemSounds.Beep.Play();
                cancelButton.Enabled = false;
                runButton.Enabled = true;

                contextMenuStrip1.Enabled = true;

                stdTextBox.SelectionStart = 0;
                errTextBox.SelectionStart = 0;

                // Enable other tabs after a run.
                for (int i = 1; i < mainTabControl.TabCount; i++)
                {
                    mainTabControl.TabPages[i].Enabled = true;
                }
            }
        }

        private void onBatchRunFile(string stepName, int stepIdx, int numSteps)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, int, int>(onBatchRunFile), stepName, stepIdx, numSteps);
            }
            else
            {
                TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal);
                TaskbarProgress.SetValue(this.Handle, stepIdx, numSteps);

                m_progressBarTextWithoutTime = "(" + stepIdx.ToString() + "/" + numSteps.ToString() + ") " + stepName;
                textProgressBar.Maximum = numSteps;
                textProgressBar.Value = stepIdx;
                UpdateProgressBarTextWithTime();
            }
        }

        private void onStdOutRecieved(string text)
        {
            if (stdTextBox.InvokeRequired)
            {
                stdTextBox.Invoke(new Action<string>(onStdOutRecieved), text);
            }
            else
            {
                ParseForKeywordFormattingAndAppendTextTo(stdTextBox, text);
            }
        }

        private void onStdErrRecieved(string text)
        {
            if (errTextBox.InvokeRequired)
            {
                errTextBox.Invoke(new Action<string>(onStdErrRecieved), text);
            }
            else
            {
                ParseForKeywordFormattingAndAppendTextTo(errTextBox, text);
            }
        }

        private void onStatusRecieved(string text, bool err)
        {
            if (injectBatcheryOutputCheckBox.Checked)
            {
                string outString = "Ξ " + text + " Ξ" + Environment.NewLine;
                AppendStatusTextTo(stdTextBox, outString, err);
                AppendStatusTextTo(errTextBox, outString, err);
            }
        }

        private void AppendStatusTextTo(RichTextBox textBox, string text, bool err)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<RichTextBox, string, bool>(AppendStatusTextTo), textBox, text, err);
            }
            else
            {
                Color currentTextColor = textBox.SelectionColor;
                Color currentBackColor = textBox.SelectionBackColor;

                //int lastNewLine = textBox.Text.LastIndexOf('\n');
                //if (lastNewLine >= 0)
                //{ 
                //    string previousLine = textBox.Text.Substring(lastNewLine).Trim();
                //    if (previousLine.Length > 0)
                //    {
                //        textBox.AppendText(Environment.NewLine);
                //    }
                //}
                if (textBox.TextLength > 0)
                {
                    textBox.AppendText(Environment.NewLine);
                }

                textBox.SelectionFont = m_StatusFont;
                textBox.SelectionBackColor = err ? m_BadColorLight : m_GoodColorLight;
                textBox.SelectionAlignment = HorizontalAlignment.Center;
                textBox.AppendText(text);
                textBox.SelectionBackColor = currentBackColor;
                textBox.SelectionFont = m_OutputFont;
            }
        }

        private void ParseForKeywordFormattingAndAppendTextTo(RichTextBox textBox, string text)
        {
            textBox.SelectionAlignment = HorizontalAlignment.Left;

            // Note we avoid doing this in an OnTextChanged event handler so we only have to parse
            // the new text.
            if (detectErrorsCheckBox.Checked == false && detectWarningsCheckBox.Checked == false)
            {
                textBox.AppendText(text);
            }
            else
            {
                Color currentTextColor = textBox.SelectionColor;
                Color currentBackColor = Control.DefaultBackColor;

                SortedList<int, Tuple<int, Color, Color>> formatList = new SortedList<int, Tuple<int, Color, Color>>();

                if (detectErrorsCheckBox.Checked)
                {
                    string[] keyWords =
                    {
                        "error(s)",
                        "errors",
                        "error",
                    };

                    Color textColor = Color.Firebrick; // Alternate choice: Color.FromArgb(0xFF, 0xC0, 0x50, 0x4D);
                    Color backColor = currentBackColor;

                    InsertFormatHelper(keyWords, textColor, backColor, text, ref formatList);
                }

                if (detectWarningsCheckBox.Checked)
                {
                    string[] keyWords =
                    {
                        "warning(s)",
                        "warnings",
                        "warning",
                    };

                    Color textColor = Color.FromArgb(0xFF, 0xF7, 0x96, 0x46); // Alternate choice: Color.DarkOrange;
                    Color backColor = currentBackColor;

                    InsertFormatHelper(keyWords, textColor, backColor, text, ref formatList);
                }

                int index = 0;

                Win32Utils.SuspendDrawing(textBox);

                foreach (KeyValuePair<int, Tuple<int, Color, Color>> kvp in formatList)
                {
                    textBox.AppendText(text.Substring(index, (kvp.Key - index)));

                    textBox.SelectionColor = kvp.Value.Item2;
                    textBox.SelectionBackColor = kvp.Value.Item3;
                    textBox.AppendText(text.Substring(kvp.Key, kvp.Value.Item1));
                    textBox.SelectionColor = currentTextColor;
                    textBox.SelectionBackColor = currentBackColor;

                    index = kvp.Key + kvp.Value.Item1;
                }
                textBox.AppendText(text.Substring(index));

                Win32Utils.ResumeDrawing(textBox);
            }
        }

        private void InsertFormatHelper(string[] keyWords, Color textColor, Color backColor, string text, ref SortedList<int, Tuple<int, Color, Color>> formatList)
        {
            foreach (string keyWord in keyWords)
            {
                int index = text.IndexOf(keyWord, StringComparison.CurrentCultureIgnoreCase);
                while (index >= 0)
                {
                    if (formatList.ContainsKey(index))
                    {
                        if (keyWord.Length > formatList[index].Item1)
                        {
                            formatList[index] = new Tuple<int, Color, Color>(keyWord.Length, textColor, backColor);
                        }
                    }
                    else
                    {
                        formatList.Add(index, new Tuple<int, Color, Color>(keyWord.Length, textColor, backColor));
                    }

                    index = text.IndexOf(keyWord, (index + keyWord.Length), StringComparison.CurrentCultureIgnoreCase);
                }
            }
        }

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items[0].Enabled = (m_curVisibleTextBox.SelectedText.Length > 0);
            contextMenuStrip1.Items[1].Enabled = (m_curVisibleTextBox.TextLength > 0);
            contextMenuStrip1.Items[3].Enabled = (m_curVisibleTextBox.TextLength > 0);
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_curVisibleTextBox.SelectAll();
            m_curVisibleTextBox.Copy();
            m_curVisibleTextBox.DeselectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_curVisibleTextBox.Copy();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the output
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text (.txt)|*.txt|Rich Text (.rtf)|*.rtf";
            saveFileDialog.Title = "Save As";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog.OpenFile();

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(fs))
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1: //Text
                            outputFile.WriteLine(m_curVisibleTextBox.Text);
                            break;

                        case 2: //Rich Text
                            outputFile.WriteLine(m_curVisibleTextBox.Rtf);
                            break;
                    }
                }

                fs.Close();
            }
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SessionSettings.Default.Height = this.Height;
            SessionSettings.Default.Width = this.Width;
            SessionSettings.Default.DetectLinks = detectLinksCheckBox.Checked;
            SessionSettings.Default.DetectErrors = detectErrorsCheckBox.Checked;
            SessionSettings.Default.DetectWarnings = detectWarningsCheckBox.Checked;
            SessionSettings.Default.DetectFindResults = detectFindResultsCheckBox.Checked;
            SessionSettings.Default.InjectBatcheryOutput = injectBatcheryOutputCheckBox.Checked;
            SessionSettings.Default.AdvancedPathEditing = advancedPathEditingCheckBox.Checked;
            m_batchManager.SaveToSettings();
            SessionSettings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = SessionSettings.Default.Height;
            this.Width = SessionSettings.Default.Width;
            detectLinksCheckBox.Checked = SessionSettings.Default.DetectLinks;
            detectErrorsCheckBox.Checked = SessionSettings.Default.DetectErrors;
            detectWarningsCheckBox.Checked = SessionSettings.Default.DetectWarnings;
            detectFindResultsCheckBox.Checked = SessionSettings.Default.DetectFindResults;
            injectBatcheryOutputCheckBox.Checked = SessionSettings.Default.InjectBatcheryOutput;
            advancedPathEditingCheckBox.Checked = SessionSettings.Default.AdvancedPathEditing;

            UpdateFindCountDisplay();

            m_batchManager.LoadFromSettings();

            stdTextBox.Font = m_OutputFont;
            errTextBox.Font = m_OutputFont;

            outputTabControl.SelectTab(0);
            m_curVisibleTextBox = stdTextBox;

            using (System.IO.Stream welcomeStream = new System.IO.MemoryStream(Properties.Resources.WelcomeMessage))
            {
                stdTextBox.LoadFile(welcomeStream, RichTextBoxStreamType.RichText);
                welcomeStream.Seek(0, System.IO.SeekOrigin.Begin);
                errTextBox.LoadFile(welcomeStream, RichTextBoxStreamType.RichText);
            }

            RefreshBatchListActionsEnabled();
        }

        private void OutputControl1_Selected(Object sender, TabControlEventArgs e)
        {
            CloseFindPanel(sender, e);

            if (e.TabPageIndex == 0)
            {
                m_curVisibleTextBox = stdTextBox;
            }
            else
            {
                m_curVisibleTextBox = errTextBox;
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            m_batchManager.OnUp(sender, e);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            m_batchManager.OnDown(sender, e);
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnUp(sender, e);
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnDown(sender, e);
        }

        public void dragEnterBatchList(object sender, System.Windows.Forms.DragEventArgs e)
        {
            m_batchManager.OnDragEnter(sender, e);
        }

        private void dragOntoBatchList(object sender, DragEventArgs e)
        {
            m_batchManager.OnDragDrop(sender, e);
            RefreshBatchListActionsEnabled();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            m_batchManager.OnAdd(sender, e);
            RefreshBatchListActionsEnabled();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            m_batchManager.OnRemove(sender, e);
            RefreshBatchListActionsEnabled();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            m_batchManager.OnEdit(sender, e);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnAdd(sender, e);
            RefreshBatchListActionsEnabled();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnRemove(sender, e);
            RefreshBatchListActionsEnabled();
        }

        private void editInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnEdit(sender, e);
        }

        private void batchList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            m_batchManager.OnItemCheck(sender, e);
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnCheckAll(sender, e);
        }

        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_batchManager.OnUncheckAll(sender, e);
        }

        private void ContextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RefreshBatchListActionsEnabled();
        }

        private void batchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBatchListActionsEnabled();
        }

        private void RefreshBatchListActionsEnabled()
        {
            // Check/Uncheck All
            if (batchCheckedListBox.Items.Count == 0)
            {
                contextMenuStrip2.Items[(int)ContextMenu2Indices.CheckAll].Enabled = false;
            }
            else
            {
                bool allChecked = (batchCheckedListBox.CheckedItems.Count == batchCheckedListBox.Items.Count);
                contextMenuStrip2.Items[(int)ContextMenu2Indices.CheckAll].Enabled = (!allChecked);
            }
            contextMenuStrip2.Items[(int)ContextMenu2Indices.UncheckAll].Enabled = (batchCheckedListBox.CheckedItems.Count > 0);

            // Item 2 is a separator

            // Item 3 is "Add", which is always enabled (along with the button).

            //Actions
            bool validItemHighlighted = ((batchCheckedListBox.Items.Count > 0) && (batchCheckedListBox.SelectedItem != null));
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;

            removeButton.Enabled = validItemHighlighted;
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Remove].Enabled = validItemHighlighted;

            upButton.Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Up].Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);

            downButton.Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Down].Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));

            // Item 7 is a separator

            bool editEnabled = validItemHighlighted && System.IO.File.Exists(selectedItem.Editor) && System.IO.File.Exists(selectedItem.FileToEdit);
            editButton.Enabled = editEnabled;
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Edit].Enabled = editEnabled;

            optionsButton.Enabled = validItemHighlighted;
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Options].Enabled = validItemHighlighted;

            if (validItemHighlighted == false)
            {
                ClearOptions();
            }
            else
            {
                SetOptions(selectedItem);
            }
        }
        private void ClearOptions()
        {
            optionsTableLayout.Enabled = false;
            displayNameTextBox.Clear();
            filePathTextBox.Clear();
            workingDirTextBox.Clear();
            argsTextBox.Clear();
            iterationsUpDown.Value = 1;
            abortOnNonZeroCheckBox.Checked = false;
            editorTextBox.Clear();
            fileToEditTextBox.Clear();
            disableOnSuccessCheckBox.Checked = false;
        }

        private void SetOptions(BatchItem item)
        {
            displayNameTextBox.Text = item.DisplayName;
            filePathTextBox.Text = item.FilePath;
            workingDirTextBox.Text = item.WorkingDirectory;
            argsTextBox.Text = item.Arguments;
            iterationsUpDown.Value = item.Iterations;
            abortOnNonZeroCheckBox.Checked = item.AbortOnNonZeroExitCode;
            editorTextBox.Text = item.Editor;
            fileToEditTextBox.Text = item.FileToEdit;
            optionsTableLayout.Enabled = true;
            disableOnSuccessCheckBox.Checked = item.DisableOnSuccess;
        }

        private void LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", e.LinkText);
        }

        private void detectLinksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            stdTextBox.DetectUrls = detectLinksCheckBox.Checked;
            errTextBox.DetectUrls = detectLinksCheckBox.Checked;
        }

        private void OnMainTabChanged(object sender, EventArgs e)
        {
            CloseFindPanel(sender, e);

            if (m_OptionsShown)
            {
                HideOptions();
            }
        }

        private void OpenFindPanel(object sender, EventArgs e)
        {
            if ((findPanel.Visible == false) && (runButton.Enabled == true))
            {
                m_PreFindCurVisibleTextRtf = m_curVisibleTextBox.Rtf;

                findTextBox.Clear();
                findPanel.Enabled = true;
                findPanel.Visible = true;
            }
            findTextBox.Focus();
        }

        private void CloseFindPanel(object sender, EventArgs e)
        {
            if (findPanel.Visible == true)
            {
                findPanel.Enabled = false;
                findPanel.Visible = false;
                findTextBox.Clear();

                m_TotalFinds = 0;
                m_CurrentFind = 0;

                UpdateFindCountDisplay();

                m_PreFindCurVisibleTextRtf = "";
            }
        }

        private void OnFindTextChanged(object sender, EventArgs e)
        {
            findTimer.Stop();

            findNextButton.Enabled = false;
            findPrevButton.Enabled = false;

            if ((findTextBox.TextLength == 0) || (m_curVisibleTextBox.Text.IndexOf(findTextBox.Text, StringComparison.CurrentCultureIgnoreCase) == -1))
            {
                m_TotalFinds = 0;
                m_CurrentFind = 0;

                if (detectFindResultsCheckBox.Checked)
                {
                    Win32Utils.SuspendDrawing(m_curVisibleTextBox);

                    int selectionStart = m_curVisibleTextBox.SelectionStart;
                    m_curVisibleTextBox.Rtf = m_PreFindCurVisibleTextRtf;
                    m_curVisibleTextBox.SelectionStart = selectionStart;
                    m_curVisibleTextBox.ScrollToCaret();

                    Win32Utils.ResumeDrawing(m_curVisibleTextBox);
                }
                else
                {
                    m_curVisibleTextBox.DeselectAll();
                }

                UpdateFindCountDisplay();
            }
            else
            {
                findTimer.Start();
            }
        }

        private void OnFindTimerTick(object sender, EventArgs e)
        {
            findTimer.Stop();

            int selectionStart = m_curVisibleTextBox.SelectionStart;

            m_TotalFinds = 0;
            m_CurrentFind = 0;

            Win32Utils.SuspendDrawing(m_curVisibleTextBox);

            if (detectFindResultsCheckBox.Checked)
            {
                // Undo current find formatting.
                m_curVisibleTextBox.Rtf = m_PreFindCurVisibleTextRtf;
            }

            int index = m_curVisibleTextBox.Find(findTextBox.Text, RichTextBoxFinds.None);
            while (index >= 0)
            {
                if (index < selectionStart)
                {
                    m_CurrentFind++;
                }
                m_TotalFinds++;

                if (detectFindResultsCheckBox.Checked)
                {
                    m_curVisibleTextBox.SelectionBackColor = Color.Gold;
                }

                int next = m_curVisibleTextBox.Find(findTextBox.Text, (index + findTextBox.TextLength), RichTextBoxFinds.None);
                if (next == index)
                {
                    // There appears to be undocumented behavior of Find() where the search string exactly matches the end of the text.
                    // Passing in a start length of just past the end you would expect a return of -1, however it returns the last
                    // found index instead.  For example, "Hello".Find("o", 5) returns 4 for some reason.
                    break;
                }
                else
                {
                    index = next;
                }
            }

            // Scroll to the first found instance.
            int nextFound = m_curVisibleTextBox.Find(findTextBox.Text, selectionStart, RichTextBoxFinds.None);
            if (nextFound < 0)
            {
                // Wrap
                nextFound = m_curVisibleTextBox.Find(findTextBox.Text, RichTextBoxFinds.None);
                m_CurrentFind = 0;
            }
            if (nextFound >= 0)
            {
                m_curVisibleTextBox.ScrollToCaret();
            }

            Win32Utils.ResumeDrawing(m_curVisibleTextBox);

            UpdateFindCountDisplay();

            findNextButton.Enabled = true;
            findPrevButton.Enabled = true;
        }


        private void findNextButton_Click(object sender, EventArgs e)
        {
            int index = -1;
            if ((m_curVisibleTextBox.SelectionStart + findTextBox.TextLength) < m_curVisibleTextBox.TextLength)
            {
                index = m_curVisibleTextBox.Find(findTextBox.Text, m_curVisibleTextBox.SelectionStart + findTextBox.TextLength, -1, RichTextBoxFinds.None);
            }

            if (index < 0)
            {
                // Wrap
                index = m_curVisibleTextBox.Find(findTextBox.Text, 0, m_curVisibleTextBox.SelectionStart + findTextBox.TextLength, RichTextBoxFinds.None);
                m_CurrentFind = 0;
            }
            else
            {
                m_CurrentFind++;
            }
            UpdateFindCountDisplay();
        }

        private void findPrevButton_Click(object sender, EventArgs e)
        {
            int index = m_curVisibleTextBox.Find(findTextBox.Text, 0, m_curVisibleTextBox.SelectionStart, RichTextBoxFinds.Reverse);
            if (index < 0)
            {
                // Wrap
                index = m_curVisibleTextBox.Find(findTextBox.Text, m_curVisibleTextBox.SelectionStart, -1, RichTextBoxFinds.Reverse);
                m_CurrentFind = (m_TotalFinds - 1); // - 1 because m_CurrentFind is zero-based.
            }
            else
            {
                m_CurrentFind--;
            }
            UpdateFindCountDisplay();
        }

        private void UpdateFindCountDisplay()
        {
            if (m_CurrentFind >= m_TotalFinds)
            {
                findCountLabel.Text = String.Format("{0:n0}/{1:n0}", m_TotalFinds.ToString(), m_TotalFinds.ToString());
            }
            else
            {
                findCountLabel.Text = String.Format("{0:n0}/{1:n0}", (m_CurrentFind + 1).ToString(), m_TotalFinds.ToString());
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            if (m_OptionsShown)
            {
                HideOptions();
            }
            else
            {
                ShowOptions();
            }
        }

        private void HideOptions()
        {
            m_OptionsShown = false;
            batchSplitContainer.Panel2Collapsed = true;
            optionsButton.Text = "Show Options";
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Options].Text = "Show Options";
        }

        private void ShowOptions()
        {
            m_OptionsShown = true;
            batchSplitContainer.Panel2Collapsed = false;
            optionsButton.Text = "Hide Options";
            contextMenuStrip2.Items[(int)ContextMenu2Indices.Options].Text = "Hide Options";
        }

        private void OnOptionsBrowseButtonClick(OptionsBrowseButtonsEnum whichButton, System.Windows.Forms.TextBox textBox)
        {
            switch (whichButton)
            {
                case OptionsBrowseButtonsEnum.FilePath:
                case OptionsBrowseButtonsEnum.Editor:
                case OptionsBrowseButtonsEnum.FileToEdit:
                    {
                        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

                        if (whichButton != OptionsBrowseButtonsEnum.Editor)
                        {
                            openFileDialog.Filter = "Batch files (*.bat)|*.bat|Command Files (*.cmd)|*.cmd|Executable Files (*.exe)|*.exe|All files (*.*)|*.*";
                        }
                        else
                        {
                            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All files (*.*)|*.*";
                        }

                        openFileDialog.Multiselect = false;
                        openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(textBox.Text);
                        openFileDialog.CheckFileExists = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            textBox.Text = openFileDialog.FileName;
                        }
                    }
                    break;
                case OptionsBrowseButtonsEnum.WorkingDir:
                    {
                        System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
                        folderDialog.Description = "Working Directory";

                        folderDialog.SelectedPath = textBox.Text + "\\";

                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            textBox.Text = folderDialog.SelectedPath;
                        }
                    }
                    break;
                default:
                    throw (new Exception("Unknown Options Button Type"));
            }
        }

        private void filePathBrowseButton_Click(object sender, EventArgs e)
        {
            bool setFileToEditAlso = (filePathTextBox.Text == fileToEditTextBox.Text);
            OnOptionsBrowseButtonClick(OptionsBrowseButtonsEnum.FilePath, filePathTextBox);

            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.FilePath = filePathTextBox.Text;

            if (setFileToEditAlso && BatchItem.IsTextFile(fileToEditTextBox.Text))
            {
                fileToEditTextBox.Text = filePathTextBox.Text;
                selectedItem.FileToEdit = fileToEditTextBox.Text;
            }
        }

        private void workingDirBrowseButton_Click(object sender, EventArgs e)
        {
            OnOptionsBrowseButtonClick(OptionsBrowseButtonsEnum.WorkingDir, workingDirTextBox);

            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.WorkingDirectory = workingDirTextBox.Text;
        }

        private void editorBrowseButton_Click(object sender, EventArgs e)
        {
            OnOptionsBrowseButtonClick(OptionsBrowseButtonsEnum.Editor, editorTextBox);

            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.Editor = editorTextBox.Text;
        }

        private void fileToEditBrowseButton_Click(object sender, EventArgs e)
        {
            OnOptionsBrowseButtonClick(OptionsBrowseButtonsEnum.FileToEdit, fileToEditTextBox);

            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.FileToEdit = fileToEditTextBox.Text;
        }

        private void OnDisplayNameTextBoxLeave(object sender, EventArgs e)
        {
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;

            string trimmed = displayNameTextBox.Text.Trim();
            if (trimmed.Length == 0)
            {
                trimmed = "<" + System.IO.Path.GetFileNameWithoutExtension(selectedItem.FilePath) + ">";
            }

            selectedItem.DisplayName = trimmed;
            displayNameTextBox.Text = trimmed;
        }

        private void OnArgsTextBoxLeave(object sender, EventArgs e)
        {
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            string trimmed = argsTextBox.Text.Trim();
            selectedItem.Arguments = trimmed;
            argsTextBox.Text = trimmed;
        }

        private void OnIterationsNumUpDownLeave(object sender, EventArgs e)
        {
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.Iterations = ((int)iterationsUpDown.Value);
        }

        private void OnAbortOnNonZeroCheckboxLeave(object sender, EventArgs e)
        {
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.AbortOnNonZeroExitCode = abortOnNonZeroCheckBox.Checked;
        }
        private void OnDisableOnSuccessCheckboxLeave(object sender, EventArgs e)
        {
            BatchItem selectedItem = (BatchItem)batchCheckedListBox.SelectedItem;
            selectedItem.DisableOnSuccess = disableOnSuccessCheckBox.Checked;
        }

        private void UpdateProgressBarTextWithTime()
        {
            TimeSpan runTime = DateTime.Now - m_StartTime;
            textProgressBar.CustomText = runTime.ToString(@"mm\:ss") + " - " + m_progressBarTextWithoutTime;
        }

        private void OnRunTimerTick(object sender, EventArgs e)
        {
            UpdateProgressBarTextWithTime();
        }

        private void advancedPathEditingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedPathEditingCheckBox.Checked == false)
            {
                filePathTextBox.ReadOnly = true;
                workingDirTextBox.ReadOnly = true;
                editorTextBox.ReadOnly = true;
                fileToEditTextBox.ReadOnly = true;

                filePathTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                workingDirTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                editorTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                fileToEditTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            else
            {
                filePathTextBox.ReadOnly = false;
                workingDirTextBox.ReadOnly = false;
                editorTextBox.ReadOnly = false;
                fileToEditTextBox.ReadOnly = false;

                filePathTextBox.AutoCompleteMode = AutoCompleteMode.None;
                workingDirTextBox.AutoCompleteMode = AutoCompleteMode.None;
                editorTextBox.AutoCompleteMode = AutoCompleteMode.None;
                fileToEditTextBox.AutoCompleteMode = AutoCompleteMode.None;
            }
        }
    }
}
