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

        enum MainTabControlIndices : int
        {
            Output = 0,
            BatchFiles,
            Settings,
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
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control) && (e.KeyCode == Keys.F) && (findPanel.Visible == false))
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
            stdTextBox.Clear();
            errTextBox.Clear();

            CloseFindPanel(sender, e);

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
                if (exitCode == 0)
                {
                    textProgressBar.Value = 0;
                    textProgressBar.ProgressColor = m_GoodColor;
                    textProgressBar.CustomText = "";
                    textProgressBar.Invalidate();
                }
                else
                {
                    textProgressBar.Maximum = 1;
                    textProgressBar.Value = 1;
                    textProgressBar.ProgressColor = m_BadColor;
                    textProgressBar.Invalidate();
                }

                System.Media.SystemSounds.Beep.Play();
                cancelButton.Enabled = false;
                runButton.Enabled = true;

                contextMenuStrip1.Enabled = true;

                // Disable other tabs (aside from 0) during a run.
                for (int i = 1; i < mainTabControl.TabCount; i++)
                {
                    mainTabControl.TabPages[i].Enabled = true;
                }
            }
        }

        private void onBatchRunFile(string file, int stepIdx, int numSteps)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, int, int>(onBatchRunFile), file, stepIdx, numSteps);
            }
            else
            {
                textProgressBar.CustomText = "(" + stepIdx.ToString() + "/" + numSteps.ToString() + ") " + file;
                textProgressBar.Value = stepIdx;
                textProgressBar.Maximum = numSteps;
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
            SessionSettings.Default.InjectBatcheryOutput = injectBatcheryOutputCheckBox.Checked;
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
            injectBatcheryOutputCheckBox.Checked = SessionSettings.Default.InjectBatcheryOutput;

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
                contextMenuStrip2.Items[0].Enabled = false;
            }
            else
            {
                bool allChecked = (batchCheckedListBox.CheckedItems.Count == batchCheckedListBox.Items.Count);
                contextMenuStrip2.Items[0].Enabled = (!allChecked);
            }
            contextMenuStrip2.Items[1].Enabled = (batchCheckedListBox.CheckedItems.Count > 0);

            // Item 2 is a separator

            // Item 3 is "Add", which is always enabled (along with the button).

            //Actions
            bool validItemHighlighted = ((batchCheckedListBox.Items.Count > 0) && (batchCheckedListBox.SelectedItem != null));

            removeButton.Enabled = validItemHighlighted;
            contextMenuStrip2.Items[4].Enabled = validItemHighlighted;

            upButton.Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);
            contextMenuStrip2.Items[5].Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);

            downButton.Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));
            contextMenuStrip2.Items[6].Enabled = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));

            // Item 7 is a separator

            editButton.Enabled = validItemHighlighted;
            contextMenuStrip2.Items[8].Enabled = validItemHighlighted;
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
                Win32Utils.SuspendDrawing(m_curVisibleTextBox);

                int selectionStart = m_curVisibleTextBox.SelectionStart;
                m_curVisibleTextBox.Rtf = m_PreFindCurVisibleTextRtf;
                m_curVisibleTextBox.SelectionStart = selectionStart;
                m_curVisibleTextBox.ScrollToCaret();

                Win32Utils.ResumeDrawing(m_curVisibleTextBox);
            }
            else
            {
                findTimer.Start();
            }
        }

        private void OnFindTimerTick(object sender, EventArgs e)
        {
            findTimer.Stop();

            Win32Utils.SuspendDrawing(m_curVisibleTextBox);

            int selectionStart = m_curVisibleTextBox.SelectionStart;

            // Undo current find formatting.
            m_curVisibleTextBox.Rtf = m_PreFindCurVisibleTextRtf;

            // Highlight all instances of the found string.
            int index = m_curVisibleTextBox.Text.IndexOf(findTextBox.Text, StringComparison.CurrentCultureIgnoreCase);
            while (index >= 0)
            {
                m_curVisibleTextBox.Select(index, findTextBox.TextLength);
                m_curVisibleTextBox.SelectionBackColor = Color.Gold;

                index = m_curVisibleTextBox.Text.IndexOf(findTextBox.Text, (index + findTextBox.TextLength), StringComparison.CurrentCultureIgnoreCase);
            }

            // Scroll to the first found instance.
            int nextFound = m_curVisibleTextBox.Find(findTextBox.Text, selectionStart, RichTextBoxFinds.None);
            if (nextFound < 0)
            {
                // Wrap
                nextFound = m_curVisibleTextBox.Find(findTextBox.Text, RichTextBoxFinds.None);
            }
            if (nextFound >= 0)
            {
                m_curVisibleTextBox.ScrollToCaret();
            }

            Win32Utils.ResumeDrawing(m_curVisibleTextBox);

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
            }
        }

        private void findPrevButton_Click(object sender, EventArgs e)
        {
            int index = m_curVisibleTextBox.Find(findTextBox.Text, 0, m_curVisibleTextBox.SelectionStart, RichTextBoxFinds.Reverse);
            if (index < 0)
            {
                // Wrap
                index = m_curVisibleTextBox.Find(findTextBox.Text, m_curVisibleTextBox.SelectionStart, -1, RichTextBoxFinds.Reverse);
            } 
        }
    }
}
