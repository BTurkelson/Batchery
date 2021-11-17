
namespace Batchery
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.findPanel = new System.Windows.Forms.Panel();
            this.findCloseButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.findPrevButton = new System.Windows.Forms.Button();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.textProgressBar = new ProgressBarSample.TextProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.outputTabControl = new System.Windows.Forms.TabControl();
            this.stdOutTab = new System.Windows.Forms.TabPage();
            this.stdTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stdErrTab = new System.Windows.Forms.TabPage();
            this.errTextBox = new System.Windows.Forms.RichTextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.batchFilesTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.batchCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editInNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.detectLinksLabel = new System.Windows.Forms.Label();
            this.detectLinksCheckBox = new System.Windows.Forms.CheckBox();
            this.detectErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.detectErrorsLabel = new System.Windows.Forms.Label();
            this.detectWarningsCheckBox = new System.Windows.Forms.CheckBox();
            this.detectWarningsLabel = new System.Windows.Forms.Label();
            this.injectBatcheryOutputCheckBox = new System.Windows.Forms.CheckBox();
            this.injectBatcheryOutputLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.findTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTabControl.SuspendLayout();
            this.outputTab.SuspendLayout();
            this.findPanel.SuspendLayout();
            this.outputTabControl.SuspendLayout();
            this.stdOutTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.stdErrTab.SuspendLayout();
            this.batchFilesTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.outputTab);
            this.mainTabControl.Controls.Add(this.batchFilesTab);
            this.mainTabControl.Controls.Add(this.settingsPage);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(776, 426);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.OnMainTabChanged);
            // 
            // outputTab
            // 
            this.outputTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.outputTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputTab.Controls.Add(this.findPanel);
            this.outputTab.Controls.Add(this.textProgressBar);
            this.outputTab.Controls.Add(this.cancelButton);
            this.outputTab.Controls.Add(this.outputTabControl);
            this.outputTab.Controls.Add(this.runButton);
            this.outputTab.Location = new System.Drawing.Point(4, 24);
            this.outputTab.Name = "outputTab";
            this.outputTab.Padding = new System.Windows.Forms.Padding(3);
            this.outputTab.Size = new System.Drawing.Size(768, 398);
            this.outputTab.TabIndex = 0;
            this.outputTab.Text = "Output";
            // 
            // findPanel
            // 
            this.findPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findPanel.BackColor = System.Drawing.Color.White;
            this.findPanel.Controls.Add(this.findCloseButton);
            this.findPanel.Controls.Add(this.findNextButton);
            this.findPanel.Controls.Add(this.findPrevButton);
            this.findPanel.Controls.Add(this.findTextBox);
            this.findPanel.Location = new System.Drawing.Point(109, 361);
            this.findPanel.Name = "findPanel";
            this.findPanel.Size = new System.Drawing.Size(646, 27);
            this.findPanel.TabIndex = 5;
            this.findPanel.Visible = false;
            // 
            // findCloseButton
            // 
            this.findCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.findCloseButton.FlatAppearance.BorderSize = 0;
            this.findCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findCloseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.findCloseButton.Location = new System.Drawing.Point(619, 2);
            this.findCloseButton.Name = "findCloseButton";
            this.findCloseButton.Size = new System.Drawing.Size(23, 23);
            this.findCloseButton.TabIndex = 3;
            this.findCloseButton.Text = "🗙";
            this.findCloseButton.UseVisualStyleBackColor = false;
            this.findCloseButton.Click += new System.EventHandler(this.CloseFindPanel);
            // 
            // findNextButton
            // 
            this.findNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findNextButton.BackColor = System.Drawing.Color.Transparent;
            this.findNextButton.Enabled = false;
            this.findNextButton.FlatAppearance.BorderSize = 0;
            this.findNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findNextButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.findNextButton.Location = new System.Drawing.Point(590, 2);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(23, 23);
            this.findNextButton.TabIndex = 2;
            this.findNextButton.Text = "▼";
            this.findNextButton.UseVisualStyleBackColor = false;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // findPrevButton
            // 
            this.findPrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findPrevButton.BackColor = System.Drawing.Color.Transparent;
            this.findPrevButton.Enabled = false;
            this.findPrevButton.FlatAppearance.BorderSize = 0;
            this.findPrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findPrevButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.findPrevButton.Location = new System.Drawing.Point(561, 2);
            this.findPrevButton.Name = "findPrevButton";
            this.findPrevButton.Size = new System.Drawing.Size(23, 23);
            this.findPrevButton.TabIndex = 1;
            this.findPrevButton.Text = "▲";
            this.findPrevButton.UseVisualStyleBackColor = false;
            this.findPrevButton.Click += new System.EventHandler(this.findPrevButton_Click);
            // 
            // findTextBox
            // 
            this.findTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.findTextBox.Location = new System.Drawing.Point(4, 4);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.PlaceholderText = "Find...";
            this.findTextBox.Size = new System.Drawing.Size(551, 18);
            this.findTextBox.TabIndex = 0;
            this.findTextBox.TextChanged += new System.EventHandler(this.OnFindTextChanged);
            // 
            // textProgressBar
            // 
            this.textProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textProgressBar.CustomText = "";
            this.textProgressBar.Location = new System.Drawing.Point(6, 59);
            this.textProgressBar.Name = "textProgressBar";
            this.textProgressBar.ProgressColor = System.Drawing.Color.LightGreen;
            this.textProgressBar.Size = new System.Drawing.Size(678, 23);
            this.textProgressBar.TabIndex = 4;
            this.textProgressBar.TextColor = System.Drawing.SystemColors.ControlText;
            this.textProgressBar.TextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textProgressBar.VisualMode = ProgressBarSample.ProgressBarDisplayMode.CustomText;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(690, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(64, 75);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // outputTabControl
            // 
            this.outputTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.outputTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTabControl.Controls.Add(this.stdOutTab);
            this.outputTabControl.Controls.Add(this.stdErrTab);
            this.outputTabControl.Location = new System.Drawing.Point(6, 88);
            this.outputTabControl.Multiline = true;
            this.outputTabControl.Name = "outputTabControl";
            this.outputTabControl.SelectedIndex = 0;
            this.outputTabControl.Size = new System.Drawing.Size(752, 300);
            this.outputTabControl.TabIndex = 2;
            this.outputTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OutputControl1_Selected);
            // 
            // stdOutTab
            // 
            this.stdOutTab.Controls.Add(this.stdTextBox);
            this.stdOutTab.Location = new System.Drawing.Point(4, 4);
            this.stdOutTab.Name = "stdOutTab";
            this.stdOutTab.Padding = new System.Windows.Forms.Padding(3);
            this.stdOutTab.Size = new System.Drawing.Size(744, 272);
            this.stdOutTab.TabIndex = 0;
            this.stdOutTab.Text = "StdOut";
            this.stdOutTab.UseVisualStyleBackColor = true;
            // 
            // stdTextBox
            // 
            this.stdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stdTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.stdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stdTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.stdTextBox.HideSelection = false;
            this.stdTextBox.Location = new System.Drawing.Point(0, 0);
            this.stdTextBox.Name = "stdTextBox";
            this.stdTextBox.ReadOnly = true;
            this.stdTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.stdTextBox.Size = new System.Drawing.Size(741, 269);
            this.stdTextBox.TabIndex = 1;
            this.stdTextBox.Text = "";
            this.stdTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.findToolStripMenuItem,
            this.toolStripSeparator4,
            this.saveAsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyToolStripMenuItem.Text = "Copy Selected";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.findToolStripMenuItem.Text = "Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.OpenFindPanel);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(146, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // stdErrTab
            // 
            this.stdErrTab.Controls.Add(this.errTextBox);
            this.stdErrTab.Location = new System.Drawing.Point(4, 4);
            this.stdErrTab.Name = "stdErrTab";
            this.stdErrTab.Padding = new System.Windows.Forms.Padding(3);
            this.stdErrTab.Size = new System.Drawing.Size(744, 272);
            this.stdErrTab.TabIndex = 1;
            this.stdErrTab.Text = "StdErr";
            this.stdErrTab.UseVisualStyleBackColor = true;
            // 
            // errTextBox
            // 
            this.errTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.errTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.errTextBox.HideSelection = false;
            this.errTextBox.Location = new System.Drawing.Point(0, 0);
            this.errTextBox.Name = "errTextBox";
            this.errTextBox.ReadOnly = true;
            this.errTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.errTextBox.Size = new System.Drawing.Size(741, 269);
            this.errTextBox.TabIndex = 2;
            this.errTextBox.Text = "";
            this.errTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LinkClicked);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(6, 6);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(678, 46);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run!";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // batchFilesTab
            // 
            this.batchFilesTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.batchFilesTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.batchFilesTab.Controls.Add(this.tableLayoutPanel2);
            this.batchFilesTab.Controls.Add(this.tableLayoutPanel1);
            this.batchFilesTab.Controls.Add(this.batchCheckedListBox);
            this.batchFilesTab.Location = new System.Drawing.Point(4, 24);
            this.batchFilesTab.Name = "batchFilesTab";
            this.batchFilesTab.Padding = new System.Windows.Forms.Padding(3);
            this.batchFilesTab.Size = new System.Drawing.Size(768, 398);
            this.batchFilesTab.TabIndex = 1;
            this.batchFilesTab.Text = "Batch Files";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.addButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.removeButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.editButton, 2, 0);
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(602, 33);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(194, 27);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(203, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(194, 27);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(403, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(196, 27);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit in Notepad";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.upButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.downButton, 0, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(33, 344);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(3, 3);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(27, 166);
            this.upButton.TabIndex = 0;
            this.upButton.Text = "🡅";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.Enabled = false;
            this.downButton.Location = new System.Drawing.Point(3, 175);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(27, 166);
            this.downButton.TabIndex = 1;
            this.downButton.Text = "🡇";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // batchCheckedListBox
            // 
            this.batchCheckedListBox.AllowDrop = true;
            this.batchCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchCheckedListBox.ContextMenuStrip = this.contextMenuStrip2;
            this.batchCheckedListBox.FormattingEnabled = true;
            this.batchCheckedListBox.Location = new System.Drawing.Point(44, 46);
            this.batchCheckedListBox.Name = "batchCheckedListBox";
            this.batchCheckedListBox.ScrollAlwaysVisible = true;
            this.batchCheckedListBox.Size = new System.Drawing.Size(715, 346);
            this.batchCheckedListBox.TabIndex = 0;
            this.batchCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.batchList_ItemCheck);
            this.batchCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.batchList_SelectedIndexChanged);
            this.batchCheckedListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragOntoBatchList);
            this.batchCheckedListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnterBatchList);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripSeparator3,
            this.editInNotepadToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(157, 170);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip2_Opening);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.selectAllToolStripMenuItem.Text = "Check All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deselectAllToolStripMenuItem.Text = "Uncheck All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Enabled = false;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Enabled = false;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
            // 
            // editInNotepadToolStripMenuItem
            // 
            this.editInNotepadToolStripMenuItem.Enabled = false;
            this.editInNotepadToolStripMenuItem.Name = "editInNotepadToolStripMenuItem";
            this.editInNotepadToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.editInNotepadToolStripMenuItem.Text = "Edit in Notepad";
            this.editInNotepadToolStripMenuItem.Click += new System.EventHandler(this.editInNotepadToolStripMenuItem_Click);
            // 
            // settingsPage
            // 
            this.settingsPage.AutoScroll = true;
            this.settingsPage.AutoScrollMinSize = new System.Drawing.Size(250, 100);
            this.settingsPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.settingsPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settingsPage.Controls.Add(this.tableLayoutPanel3);
            this.settingsPage.Location = new System.Drawing.Point(4, 24);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(768, 398);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.detectLinksLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.detectLinksCheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.detectErrorsCheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.detectErrorsLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.detectWarningsCheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.detectWarningsLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.injectBatcheryOutputCheckBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.injectBatcheryOutputLabel, 1, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(19, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(725, 355);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // detectLinksLabel
            // 
            this.detectLinksLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detectLinksLabel.AutoSize = true;
            this.detectLinksLabel.Location = new System.Drawing.Point(23, 2);
            this.detectLinksLabel.Name = "detectLinksLabel";
            this.detectLinksLabel.Size = new System.Drawing.Size(84, 15);
            this.detectLinksLabel.TabIndex = 0;
            this.detectLinksLabel.Text = "Clickable URLs";
            // 
            // detectLinksCheckBox
            // 
            this.detectLinksCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detectLinksCheckBox.AutoSize = true;
            this.detectLinksCheckBox.Location = new System.Drawing.Point(3, 3);
            this.detectLinksCheckBox.Name = "detectLinksCheckBox";
            this.detectLinksCheckBox.Size = new System.Drawing.Size(14, 14);
            this.detectLinksCheckBox.TabIndex = 1;
            this.detectLinksCheckBox.UseVisualStyleBackColor = true;
            this.detectLinksCheckBox.CheckedChanged += new System.EventHandler(this.detectLinksCheckBox_CheckedChanged);
            // 
            // detectErrorsCheckBox
            // 
            this.detectErrorsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detectErrorsCheckBox.AutoSize = true;
            this.detectErrorsCheckBox.Location = new System.Drawing.Point(3, 23);
            this.detectErrorsCheckBox.Name = "detectErrorsCheckBox";
            this.detectErrorsCheckBox.Size = new System.Drawing.Size(14, 14);
            this.detectErrorsCheckBox.TabIndex = 2;
            this.detectErrorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectErrorsLabel
            // 
            this.detectErrorsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detectErrorsLabel.AutoSize = true;
            this.detectErrorsLabel.Location = new System.Drawing.Point(23, 22);
            this.detectErrorsLabel.Name = "detectErrorsLabel";
            this.detectErrorsLabel.Size = new System.Drawing.Size(98, 15);
            this.detectErrorsLabel.TabIndex = 3;
            this.detectErrorsLabel.Text = "Highlight Error(s)";
            // 
            // detectWarningsCheckBox
            // 
            this.detectWarningsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detectWarningsCheckBox.AutoSize = true;
            this.detectWarningsCheckBox.Location = new System.Drawing.Point(3, 43);
            this.detectWarningsCheckBox.Name = "detectWarningsCheckBox";
            this.detectWarningsCheckBox.Size = new System.Drawing.Size(14, 14);
            this.detectWarningsCheckBox.TabIndex = 4;
            this.detectWarningsCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectWarningsLabel
            // 
            this.detectWarningsLabel.AutoSize = true;
            this.detectWarningsLabel.Location = new System.Drawing.Point(23, 40);
            this.detectWarningsLabel.Name = "detectWarningsLabel";
            this.detectWarningsLabel.Size = new System.Drawing.Size(118, 15);
            this.detectWarningsLabel.TabIndex = 5;
            this.detectWarningsLabel.Text = "Highlight Warning(s)";
            // 
            // injectBatcheryOutputCheckBox
            // 
            this.injectBatcheryOutputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.injectBatcheryOutputCheckBox.AutoSize = true;
            this.injectBatcheryOutputCheckBox.Location = new System.Drawing.Point(3, 63);
            this.injectBatcheryOutputCheckBox.Name = "injectBatcheryOutputCheckBox";
            this.injectBatcheryOutputCheckBox.Size = new System.Drawing.Size(14, 14);
            this.injectBatcheryOutputCheckBox.TabIndex = 6;
            this.injectBatcheryOutputCheckBox.UseVisualStyleBackColor = true;
            // 
            // injectBatcheryOutputLabel
            // 
            this.injectBatcheryOutputLabel.AutoSize = true;
            this.injectBatcheryOutputLabel.Location = new System.Drawing.Point(23, 60);
            this.injectBatcheryOutputLabel.Name = "injectBatcheryOutputLabel";
            this.injectBatcheryOutputLabel.Size = new System.Drawing.Size(161, 15);
            this.injectBatcheryOutputLabel.TabIndex = 7;
            this.injectBatcheryOutputLabel.Text = "Inject Batchery Status Output";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // findTimer
            // 
            this.findTimer.Interval = 100;
            this.findTimer.Tick += new System.EventHandler(this.OnFindTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Batchery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.outputTab.ResumeLayout(false);
            this.findPanel.ResumeLayout(false);
            this.findPanel.PerformLayout();
            this.outputTabControl.ResumeLayout(false);
            this.stdOutTab.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.stdErrTab.ResumeLayout(false);
            this.batchFilesTab.ResumeLayout(false);
            this.batchFilesTab.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage outputTab;
        private System.Windows.Forms.TabPage batchFilesTab;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl outputTabControl;
        private System.Windows.Forms.TabPage stdOutTab;
        private System.Windows.Forms.RichTextBox stdTextBox;
        private System.Windows.Forms.TabPage stdErrTab;
        private System.Windows.Forms.RichTextBox errTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox batchCheckedListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editInNotepadToolStripMenuItem;
        private ProgressBarSample.TextProgressBar textProgressBar;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label detectLinksLabel;
        private System.Windows.Forms.CheckBox detectLinksCheckBox;
        private System.Windows.Forms.CheckBox detectErrorsCheckBox;
        private System.Windows.Forms.Label detectErrorsLabel;
        private System.Windows.Forms.CheckBox detectWarningsCheckBox;
        private System.Windows.Forms.Label detectWarningsLabel;
        private System.Windows.Forms.CheckBox injectBatcheryOutputCheckBox;
        private System.Windows.Forms.Label injectBatcheryOutputLabel;
        private System.Windows.Forms.Panel findPanel;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Button findPrevButton;
        private System.Windows.Forms.Button findCloseButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer findTimer;
    }
}

