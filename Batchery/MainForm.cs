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

        private RichTextBox m_curVisibleTextBox;
        private BatchManager m_batchManager;


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

        private void runButton_Click(object sender, EventArgs e)
        {
            stdTextBox.Clear();
            errTextBox.Clear();

            cancelButton.Enabled = true;
            runButton.Enabled = false;

            // Disable editing of batch files during a run.
            mainTabControl.TabPages[1].Enabled = false;

            textProgressBar.Value = 0;
            textProgressBar.ProgressColor = System.Drawing.Color.LightGreen;
            textProgressBar.Invalidate();

            m_batchManager.OnRun(onBatchRunEnd, onBatchRunFile, onStdOutRecieved, onStdErrRecieved);
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
                    textProgressBar.ProgressColor = System.Drawing.Color.LightGreen;
                    textProgressBar.CustomText = "";
                    textProgressBar.Invalidate();
                }
                else
                {
                    textProgressBar.Maximum = 1;
                    textProgressBar.Value = 1;
                    textProgressBar.ProgressColor = System.Drawing.Color.LightCoral;
                    textProgressBar.Invalidate();
                }

                System.Media.SystemSounds.Beep.Play();
                cancelButton.Enabled = false;
                runButton.Enabled = true;
                mainTabControl.TabPages[1].Enabled = true;
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
                stdTextBox.AppendText(text);
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
                errTextBox.AppendText(text);
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
            saveFileDialog.Filter   = "Text files (*.txt)|*.txt";
            saveFileDialog.Title    = "Save As";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog.OpenFile();

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(fs))
                {
                    outputFile.WriteLine(m_curVisibleTextBox.Text);
                }

                fs.Close();
            }
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SessionSettings.Default.Height = this.Height;
            SessionSettings.Default.Width = this.Width;
            m_batchManager.SaveToSettings();
            SessionSettings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = SessionSettings.Default.Height;
            this.Width = SessionSettings.Default.Width;

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

            removeButton.Enabled                = validItemHighlighted;
            contextMenuStrip2.Items[4].Enabled  = validItemHighlighted;

            upButton.Enabled                    = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);
            contextMenuStrip2.Items[5].Enabled  = validItemHighlighted && (batchCheckedListBox.SelectedIndex != 0);

            downButton.Enabled                  = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));
            contextMenuStrip2.Items[6].Enabled  = validItemHighlighted && (batchCheckedListBox.SelectedIndex != (batchCheckedListBox.Items.Count - 1));

            // Item 7 is a separator

            editButton.Enabled = validItemHighlighted;
            contextMenuStrip2.Items[8].Enabled = validItemHighlighted;
        }
    }
}
