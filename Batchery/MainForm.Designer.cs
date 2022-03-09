
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
            this.findCountLabel = new System.Windows.Forms.Label();
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
            this.favoritesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.downButton = new System.Windows.Forms.Button();
            this.batchSplitContainer = new System.Windows.Forms.SplitContainer();
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
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.disableOnSuccessCheckBox = new System.Windows.Forms.CheckBox();
            this.disableOnSuccessLabel = new System.Windows.Forms.Label();
            this.fileToEditBrowseButton = new System.Windows.Forms.Button();
            this.editorBrowseButton = new System.Windows.Forms.Button();
            this.fileToEditTextBox = new System.Windows.Forms.TextBox();
            this.editorTextBox = new System.Windows.Forms.TextBox();
            this.fileToEditLabel = new System.Windows.Forms.Label();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.workingDirLabel = new System.Windows.Forms.Label();
            this.argsLabel = new System.Windows.Forms.Label();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.abortOnNonZeroLabel = new System.Windows.Forms.Label();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.workingDirTextBox = new System.Windows.Forms.TextBox();
            this.argsTextBox = new System.Windows.Forms.TextBox();
            this.iterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.abortOnNonZeroCheckBox = new System.Windows.Forms.CheckBox();
            this.filePathBrowseButton = new System.Windows.Forms.Button();
            this.workingDirBrowseButton = new System.Windows.Forms.Button();
            this.editorLabel = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.optionsButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.settingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.detectLinksLabel = new System.Windows.Forms.Label();
            this.detectLinksCheckBox = new System.Windows.Forms.CheckBox();
            this.detectErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.detectErrorsLabel = new System.Windows.Forms.Label();
            this.detectWarningsCheckBox = new System.Windows.Forms.CheckBox();
            this.detectWarningsLabel = new System.Windows.Forms.Label();
            this.detectFindResultsCheckBox = new System.Windows.Forms.CheckBox();
            this.detectFindResultsLabel = new System.Windows.Forms.Label();
            this.injectBatcheryOutputCheckBox = new System.Windows.Forms.CheckBox();
            this.injectBatcheryOutputLabel = new System.Windows.Forms.Label();
            this.advancedPathEditingCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedPathEditingLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.favoritesSplitContainer)).BeginInit();
            this.favoritesSplitContainer.Panel2.SuspendLayout();
            this.favoritesSplitContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchSplitContainer)).BeginInit();
            this.batchSplitContainer.Panel1.SuspendLayout();
            this.batchSplitContainer.Panel2.SuspendLayout();
            this.batchSplitContainer.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.optionsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.settingsTableLayout.SuspendLayout();
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
            this.findPanel.Controls.Add(this.findCountLabel);
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
            this.findTextBox.Size = new System.Drawing.Size(486, 18);
            this.findTextBox.TabIndex = 0;
            this.findTextBox.TextChanged += new System.EventHandler(this.OnFindTextChanged);
            // 
            // findCountLabel
            // 
            this.findCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findCountLabel.AutoSize = true;
            this.findCountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.findCountLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.findCountLabel.Location = new System.Drawing.Point(494, 5);
            this.findCountLabel.MinimumSize = new System.Drawing.Size(55, 0);
            this.findCountLabel.Name = "findCountLabel";
            this.findCountLabel.Size = new System.Drawing.Size(69, 17);
            this.findCountLabel.TabIndex = 4;
            this.findCountLabel.Text = "9999/9999";
            this.findCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 104);
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
            this.batchFilesTab.Controls.Add(this.favoritesSplitContainer);
            this.batchFilesTab.Location = new System.Drawing.Point(4, 24);
            this.batchFilesTab.Name = "batchFilesTab";
            this.batchFilesTab.Padding = new System.Windows.Forms.Padding(3);
            this.batchFilesTab.Size = new System.Drawing.Size(768, 398);
            this.batchFilesTab.TabIndex = 1;
            this.batchFilesTab.Text = "Batch Files";
            // 
            // favoritesSplitContainer
            // 
            this.favoritesSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.favoritesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoritesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.favoritesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.favoritesSplitContainer.Name = "favoritesSplitContainer";
            // 
            // favoritesSplitContainer.Panel1
            // 
            this.favoritesSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.favoritesSplitContainer.Panel1MinSize = 100;
            // 
            // favoritesSplitContainer.Panel2
            // 
            this.favoritesSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.favoritesSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.favoritesSplitContainer.Panel2MinSize = 100;
            this.favoritesSplitContainer.Size = new System.Drawing.Size(758, 388);
            this.favoritesSplitContainer.SplitterDistance = 166;
            this.favoritesSplitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.downButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.batchSplitContainer, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.upButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 388);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // downButton
            // 
            this.downButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downButton.Enabled = false;
            this.downButton.Location = new System.Drawing.Point(3, 213);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(30, 172);
            this.downButton.TabIndex = 1;
            this.downButton.Text = "🡇";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // batchSplitContainer
            // 
            this.batchSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchSplitContainer.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.batchSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.batchSplitContainer.IsSplitterFixed = true;
            this.batchSplitContainer.Location = new System.Drawing.Point(39, 36);
            this.batchSplitContainer.Name = "batchSplitContainer";
            this.batchSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // batchSplitContainer.Panel1
            // 
            this.batchSplitContainer.Panel1.Controls.Add(this.batchCheckedListBox);
            this.batchSplitContainer.Panel1MinSize = 30;
            // 
            // batchSplitContainer.Panel2
            // 
            this.batchSplitContainer.Panel2.Controls.Add(this.optionsTableLayout);
            this.batchSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.batchSplitContainer.Panel2MinSize = 243;
            this.tableLayoutPanel2.SetRowSpan(this.batchSplitContainer, 2);
            this.batchSplitContainer.Size = new System.Drawing.Size(574, 349);
            this.batchSplitContainer.SplitterDistance = 76;
            this.batchSplitContainer.TabIndex = 7;
            // 
            // batchCheckedListBox
            // 
            this.batchCheckedListBox.AllowDrop = true;
            this.batchCheckedListBox.ContextMenuStrip = this.contextMenuStrip2;
            this.batchCheckedListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.batchCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchCheckedListBox.FormattingEnabled = true;
            this.batchCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.batchCheckedListBox.Name = "batchCheckedListBox";
            this.batchCheckedListBox.ScrollAlwaysVisible = true;
            this.batchCheckedListBox.Size = new System.Drawing.Size(574, 76);
            this.batchCheckedListBox.TabIndex = 1;
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
            this.editInNotepadToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 192);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip2_Opening);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Check All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deselectAllToolStripMenuItem.Text = "Uncheck All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addToolStripMenuItem.Text = "Add...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Enabled = false;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Enabled = false;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // editInNotepadToolStripMenuItem
            // 
            this.editInNotepadToolStripMenuItem.Enabled = false;
            this.editInNotepadToolStripMenuItem.Name = "editInNotepadToolStripMenuItem";
            this.editInNotepadToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.editInNotepadToolStripMenuItem.Text = "Edit...";
            this.editInNotepadToolStripMenuItem.Click += new System.EventHandler(this.editInNotepadToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.optionsToolStripMenuItem.Text = "Hide Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // optionsTableLayout
            // 
            this.optionsTableLayout.ColumnCount = 3;
            this.optionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.optionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.optionsTableLayout.Controls.Add(this.disableOnSuccessCheckBox, 1, 8);
            this.optionsTableLayout.Controls.Add(this.disableOnSuccessLabel, 0, 8);
            this.optionsTableLayout.Controls.Add(this.fileToEditBrowseButton, 2, 7);
            this.optionsTableLayout.Controls.Add(this.editorBrowseButton, 2, 6);
            this.optionsTableLayout.Controls.Add(this.fileToEditTextBox, 1, 7);
            this.optionsTableLayout.Controls.Add(this.editorTextBox, 1, 6);
            this.optionsTableLayout.Controls.Add(this.fileToEditLabel, 0, 7);
            this.optionsTableLayout.Controls.Add(this.displayNameLabel, 0, 0);
            this.optionsTableLayout.Controls.Add(this.filePathLabel, 0, 1);
            this.optionsTableLayout.Controls.Add(this.workingDirLabel, 0, 2);
            this.optionsTableLayout.Controls.Add(this.argsLabel, 0, 3);
            this.optionsTableLayout.Controls.Add(this.iterationsLabel, 0, 4);
            this.optionsTableLayout.Controls.Add(this.abortOnNonZeroLabel, 0, 5);
            this.optionsTableLayout.Controls.Add(this.displayNameTextBox, 1, 0);
            this.optionsTableLayout.Controls.Add(this.filePathTextBox, 1, 1);
            this.optionsTableLayout.Controls.Add(this.workingDirTextBox, 1, 2);
            this.optionsTableLayout.Controls.Add(this.argsTextBox, 1, 3);
            this.optionsTableLayout.Controls.Add(this.iterationsUpDown, 1, 4);
            this.optionsTableLayout.Controls.Add(this.abortOnNonZeroCheckBox, 1, 5);
            this.optionsTableLayout.Controls.Add(this.filePathBrowseButton, 2, 1);
            this.optionsTableLayout.Controls.Add(this.workingDirBrowseButton, 2, 2);
            this.optionsTableLayout.Controls.Add(this.editorLabel, 0, 6);
            this.optionsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayout.Location = new System.Drawing.Point(0, 0);
            this.optionsTableLayout.Name = "optionsTableLayout";
            this.optionsTableLayout.RowCount = 9;
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.optionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.optionsTableLayout.Size = new System.Drawing.Size(574, 269);
            this.optionsTableLayout.TabIndex = 0;
            // 
            // disableOnSuccessCheckBox
            // 
            this.disableOnSuccessCheckBox.AutoSize = true;
            this.disableOnSuccessCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.disableOnSuccessCheckBox.Location = new System.Drawing.Point(131, 243);
            this.disableOnSuccessCheckBox.Name = "disableOnSuccessCheckBox";
            this.disableOnSuccessCheckBox.Size = new System.Drawing.Size(15, 23);
            this.disableOnSuccessCheckBox.TabIndex = 21;
            this.disableOnSuccessCheckBox.UseVisualStyleBackColor = true;
            this.disableOnSuccessCheckBox.Leave += new System.EventHandler(this.OnDisableOnSuccessCheckboxLeave);
            // 
            // disableOnSuccessLabel
            // 
            this.disableOnSuccessLabel.AutoSize = true;
            this.disableOnSuccessLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disableOnSuccessLabel.Location = new System.Drawing.Point(3, 240);
            this.disableOnSuccessLabel.Name = "disableOnSuccessLabel";
            this.disableOnSuccessLabel.Size = new System.Drawing.Size(122, 29);
            this.disableOnSuccessLabel.TabIndex = 20;
            this.disableOnSuccessLabel.Text = "Disable On Success";
            this.disableOnSuccessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileToEditBrowseButton
            // 
            this.fileToEditBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileToEditBrowseButton.Location = new System.Drawing.Point(457, 213);
            this.fileToEditBrowseButton.Name = "fileToEditBrowseButton";
            this.fileToEditBrowseButton.Size = new System.Drawing.Size(114, 24);
            this.fileToEditBrowseButton.TabIndex = 19;
            this.fileToEditBrowseButton.Text = "Browse...";
            this.fileToEditBrowseButton.UseVisualStyleBackColor = true;
            this.fileToEditBrowseButton.Click += new System.EventHandler(this.fileToEditBrowseButton_Click);
            // 
            // editorBrowseButton
            // 
            this.editorBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorBrowseButton.Location = new System.Drawing.Point(457, 183);
            this.editorBrowseButton.Name = "editorBrowseButton";
            this.editorBrowseButton.Size = new System.Drawing.Size(114, 24);
            this.editorBrowseButton.TabIndex = 18;
            this.editorBrowseButton.Text = "Browse...";
            this.editorBrowseButton.UseVisualStyleBackColor = true;
            this.editorBrowseButton.Click += new System.EventHandler(this.editorBrowseButton_Click);
            // 
            // fileToEditTextBox
            // 
            this.fileToEditTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.fileToEditTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileToEditTextBox.Location = new System.Drawing.Point(131, 213);
            this.fileToEditTextBox.Name = "fileToEditTextBox";
            this.fileToEditTextBox.ReadOnly = true;
            this.fileToEditTextBox.Size = new System.Drawing.Size(320, 23);
            this.fileToEditTextBox.TabIndex = 17;
            this.fileToEditTextBox.WordWrap = false;
            // 
            // editorTextBox
            // 
            this.editorTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.editorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorTextBox.Location = new System.Drawing.Point(131, 183);
            this.editorTextBox.Name = "editorTextBox";
            this.editorTextBox.ReadOnly = true;
            this.editorTextBox.Size = new System.Drawing.Size(320, 23);
            this.editorTextBox.TabIndex = 16;
            this.editorTextBox.WordWrap = false;
            // 
            // fileToEditLabel
            // 
            this.fileToEditLabel.AutoSize = true;
            this.fileToEditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileToEditLabel.Location = new System.Drawing.Point(3, 210);
            this.fileToEditLabel.Name = "fileToEditLabel";
            this.fileToEditLabel.Size = new System.Drawing.Size(122, 30);
            this.fileToEditLabel.TabIndex = 15;
            this.fileToEditLabel.Text = "File To Edit";
            this.fileToEditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayNameLabel.Location = new System.Drawing.Point(3, 0);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(122, 30);
            this.displayNameLabel.TabIndex = 0;
            this.displayNameLabel.Text = "Display Name";
            this.displayNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathLabel.Location = new System.Drawing.Point(3, 30);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(122, 30);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "Batch File or Exe Path";
            this.filePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // workingDirLabel
            // 
            this.workingDirLabel.AutoSize = true;
            this.workingDirLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingDirLabel.Location = new System.Drawing.Point(3, 60);
            this.workingDirLabel.Name = "workingDirLabel";
            this.workingDirLabel.Size = new System.Drawing.Size(122, 30);
            this.workingDirLabel.TabIndex = 2;
            this.workingDirLabel.Text = "Working Directory";
            this.workingDirLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // argsLabel
            // 
            this.argsLabel.AutoSize = true;
            this.argsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argsLabel.Location = new System.Drawing.Point(3, 90);
            this.argsLabel.Name = "argsLabel";
            this.argsLabel.Size = new System.Drawing.Size(122, 30);
            this.argsLabel.TabIndex = 3;
            this.argsLabel.Text = "Arguments";
            this.argsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iterationsLabel.Location = new System.Drawing.Point(3, 120);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(122, 30);
            this.iterationsLabel.TabIndex = 4;
            this.iterationsLabel.Text = "Iterations";
            this.iterationsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // abortOnNonZeroLabel
            // 
            this.abortOnNonZeroLabel.AutoSize = true;
            this.abortOnNonZeroLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abortOnNonZeroLabel.Location = new System.Drawing.Point(3, 150);
            this.abortOnNonZeroLabel.Name = "abortOnNonZeroLabel";
            this.abortOnNonZeroLabel.Size = new System.Drawing.Size(122, 30);
            this.abortOnNonZeroLabel.TabIndex = 5;
            this.abortOnNonZeroLabel.Text = "Abort on Error";
            this.abortOnNonZeroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // displayNameTextBox
            // 
            this.optionsTableLayout.SetColumnSpan(this.displayNameTextBox, 2);
            this.displayNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayNameTextBox.Location = new System.Drawing.Point(131, 3);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(440, 23);
            this.displayNameTextBox.TabIndex = 6;
            this.displayNameTextBox.WordWrap = false;
            this.displayNameTextBox.Leave += new System.EventHandler(this.OnDisplayNameTextBoxLeave);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.filePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathTextBox.Location = new System.Drawing.Point(131, 33);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(320, 23);
            this.filePathTextBox.TabIndex = 7;
            this.filePathTextBox.WordWrap = false;
            // 
            // workingDirTextBox
            // 
            this.workingDirTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.workingDirTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingDirTextBox.Location = new System.Drawing.Point(131, 63);
            this.workingDirTextBox.Name = "workingDirTextBox";
            this.workingDirTextBox.ReadOnly = true;
            this.workingDirTextBox.Size = new System.Drawing.Size(320, 23);
            this.workingDirTextBox.TabIndex = 8;
            this.workingDirTextBox.WordWrap = false;
            // 
            // argsTextBox
            // 
            this.optionsTableLayout.SetColumnSpan(this.argsTextBox, 2);
            this.argsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argsTextBox.Location = new System.Drawing.Point(131, 93);
            this.argsTextBox.Name = "argsTextBox";
            this.argsTextBox.Size = new System.Drawing.Size(440, 23);
            this.argsTextBox.TabIndex = 9;
            this.argsTextBox.WordWrap = false;
            this.argsTextBox.Leave += new System.EventHandler(this.OnArgsTextBoxLeave);
            // 
            // iterationsUpDown
            // 
            this.iterationsUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.iterationsUpDown.Location = new System.Drawing.Point(131, 123);
            this.iterationsUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.iterationsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationsUpDown.Name = "iterationsUpDown";
            this.iterationsUpDown.Size = new System.Drawing.Size(50, 23);
            this.iterationsUpDown.TabIndex = 10;
            this.iterationsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationsUpDown.Leave += new System.EventHandler(this.OnIterationsNumUpDownLeave);
            // 
            // abortOnNonZeroCheckBox
            // 
            this.abortOnNonZeroCheckBox.AutoSize = true;
            this.abortOnNonZeroCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.abortOnNonZeroCheckBox.Location = new System.Drawing.Point(131, 153);
            this.abortOnNonZeroCheckBox.Name = "abortOnNonZeroCheckBox";
            this.abortOnNonZeroCheckBox.Size = new System.Drawing.Size(15, 24);
            this.abortOnNonZeroCheckBox.TabIndex = 11;
            this.abortOnNonZeroCheckBox.UseVisualStyleBackColor = true;
            this.abortOnNonZeroCheckBox.Leave += new System.EventHandler(this.OnAbortOnNonZeroCheckboxLeave);
            // 
            // filePathBrowseButton
            // 
            this.filePathBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathBrowseButton.Location = new System.Drawing.Point(457, 33);
            this.filePathBrowseButton.Name = "filePathBrowseButton";
            this.filePathBrowseButton.Size = new System.Drawing.Size(114, 24);
            this.filePathBrowseButton.TabIndex = 12;
            this.filePathBrowseButton.Text = "Browse...";
            this.filePathBrowseButton.UseVisualStyleBackColor = true;
            this.filePathBrowseButton.Click += new System.EventHandler(this.filePathBrowseButton_Click);
            // 
            // workingDirBrowseButton
            // 
            this.workingDirBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingDirBrowseButton.Location = new System.Drawing.Point(457, 63);
            this.workingDirBrowseButton.Name = "workingDirBrowseButton";
            this.workingDirBrowseButton.Size = new System.Drawing.Size(114, 24);
            this.workingDirBrowseButton.TabIndex = 13;
            this.workingDirBrowseButton.Text = "Browse...";
            this.workingDirBrowseButton.UseVisualStyleBackColor = true;
            this.workingDirBrowseButton.Click += new System.EventHandler(this.workingDirBrowseButton_Click);
            // 
            // editorLabel
            // 
            this.editorLabel.AutoSize = true;
            this.editorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorLabel.Location = new System.Drawing.Point(3, 180);
            this.editorLabel.Name = "editorLabel";
            this.editorLabel.Size = new System.Drawing.Size(122, 30);
            this.editorLabel.TabIndex = 14;
            this.editorLabel.Text = "Editor";
            this.editorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // upButton
            // 
            this.upButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(3, 36);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(30, 171);
            this.upButton.TabIndex = 0;
            this.upButton.Text = "🡅";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.optionsButton, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.addButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.removeButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.editButton, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(616, 33);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // optionsButton
            // 
            this.optionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsButton.Enabled = false;
            this.optionsButton.Location = new System.Drawing.Point(465, 3);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(148, 27);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "Hide Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(148, 27);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(157, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(148, 27);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(311, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(148, 27);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // settingsPage
            // 
            this.settingsPage.AutoScroll = true;
            this.settingsPage.AutoScrollMinSize = new System.Drawing.Size(250, 100);
            this.settingsPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.settingsPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settingsPage.Controls.Add(this.settingsTableLayout);
            this.settingsPage.Location = new System.Drawing.Point(4, 24);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(768, 398);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "Settings";
            // 
            // settingsTableLayout
            // 
            this.settingsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTableLayout.ColumnCount = 3;
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.settingsTableLayout.Controls.Add(this.detectLinksLabel, 1, 0);
            this.settingsTableLayout.Controls.Add(this.detectLinksCheckBox, 0, 0);
            this.settingsTableLayout.Controls.Add(this.detectErrorsCheckBox, 0, 1);
            this.settingsTableLayout.Controls.Add(this.detectErrorsLabel, 1, 1);
            this.settingsTableLayout.Controls.Add(this.detectWarningsCheckBox, 0, 2);
            this.settingsTableLayout.Controls.Add(this.detectWarningsLabel, 1, 2);
            this.settingsTableLayout.Controls.Add(this.detectFindResultsCheckBox, 0, 3);
            this.settingsTableLayout.Controls.Add(this.detectFindResultsLabel, 1, 3);
            this.settingsTableLayout.Controls.Add(this.injectBatcheryOutputCheckBox, 0, 4);
            this.settingsTableLayout.Controls.Add(this.injectBatcheryOutputLabel, 1, 4);
            this.settingsTableLayout.Controls.Add(this.advancedPathEditingCheckBox, 0, 5);
            this.settingsTableLayout.Controls.Add(this.advancedPathEditingLabel, 1, 5);
            this.settingsTableLayout.Location = new System.Drawing.Point(19, 19);
            this.settingsTableLayout.Name = "settingsTableLayout";
            this.settingsTableLayout.RowCount = 7;
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsTableLayout.Size = new System.Drawing.Size(725, 355);
            this.settingsTableLayout.TabIndex = 0;
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
            // detectFindResultsCheckBox
            // 
            this.detectFindResultsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.detectFindResultsCheckBox.AutoSize = true;
            this.detectFindResultsCheckBox.Location = new System.Drawing.Point(3, 63);
            this.detectFindResultsCheckBox.Name = "detectFindResultsCheckBox";
            this.detectFindResultsCheckBox.Size = new System.Drawing.Size(14, 14);
            this.detectFindResultsCheckBox.TabIndex = 6;
            this.detectFindResultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectFindResultsLabel
            // 
            this.detectFindResultsLabel.AutoSize = true;
            this.detectFindResultsLabel.Location = new System.Drawing.Point(23, 60);
            this.detectFindResultsLabel.Name = "detectFindResultsLabel";
            this.detectFindResultsLabel.Size = new System.Drawing.Size(140, 15);
            this.detectFindResultsLabel.TabIndex = 7;
            this.detectFindResultsLabel.Text = "Highlight All Find Results";
            // 
            // injectBatcheryOutputCheckBox
            // 
            this.injectBatcheryOutputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.injectBatcheryOutputCheckBox.AutoSize = true;
            this.injectBatcheryOutputCheckBox.Location = new System.Drawing.Point(3, 83);
            this.injectBatcheryOutputCheckBox.Name = "injectBatcheryOutputCheckBox";
            this.injectBatcheryOutputCheckBox.Size = new System.Drawing.Size(14, 14);
            this.injectBatcheryOutputCheckBox.TabIndex = 8;
            this.injectBatcheryOutputCheckBox.UseVisualStyleBackColor = true;
            // 
            // injectBatcheryOutputLabel
            // 
            this.injectBatcheryOutputLabel.AutoSize = true;
            this.injectBatcheryOutputLabel.Location = new System.Drawing.Point(23, 80);
            this.injectBatcheryOutputLabel.Name = "injectBatcheryOutputLabel";
            this.injectBatcheryOutputLabel.Size = new System.Drawing.Size(161, 15);
            this.injectBatcheryOutputLabel.TabIndex = 9;
            this.injectBatcheryOutputLabel.Text = "Inject Batchery Status Output";
            // 
            // advancedPathEditingCheckBox
            // 
            this.advancedPathEditingCheckBox.AutoSize = true;
            this.advancedPathEditingCheckBox.Location = new System.Drawing.Point(3, 103);
            this.advancedPathEditingCheckBox.Name = "advancedPathEditingCheckBox";
            this.advancedPathEditingCheckBox.Size = new System.Drawing.Size(14, 14);
            this.advancedPathEditingCheckBox.TabIndex = 10;
            this.advancedPathEditingCheckBox.Text = "checkBox1";
            this.advancedPathEditingCheckBox.UseVisualStyleBackColor = true;
            this.advancedPathEditingCheckBox.CheckedChanged += new System.EventHandler(this.advancedPathEditingCheckBox_CheckedChanged);
            // 
            // advancedPathEditingLabel
            // 
            this.advancedPathEditingLabel.AutoSize = true;
            this.advancedPathEditingLabel.Location = new System.Drawing.Point(23, 100);
            this.advancedPathEditingLabel.Name = "advancedPathEditingLabel";
            this.advancedPathEditingLabel.Size = new System.Drawing.Size(127, 15);
            this.advancedPathEditingLabel.TabIndex = 11;
            this.advancedPathEditingLabel.Text = "Advanced Path Editing";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // findTimer
            // 
            this.findTimer.Interval = 500;
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
            this.favoritesSplitContainer.Panel2.ResumeLayout(false);
            this.favoritesSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favoritesSplitContainer)).EndInit();
            this.favoritesSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.batchSplitContainer.Panel1.ResumeLayout(false);
            this.batchSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.batchSplitContainer)).EndInit();
            this.batchSplitContainer.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.optionsTableLayout.ResumeLayout(false);
            this.optionsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.settingsTableLayout.ResumeLayout(false);
            this.settingsTableLayout.PerformLayout();
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
        private System.Windows.Forms.TabPage stdErrTab;
        private System.Windows.Forms.RichTextBox errTextBox;
        private System.Windows.Forms.Button cancelButton;
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
        private System.Windows.Forms.TableLayoutPanel settingsTableLayout;
        private System.Windows.Forms.Label detectLinksLabel;
        private System.Windows.Forms.CheckBox detectLinksCheckBox;
        private System.Windows.Forms.CheckBox detectErrorsCheckBox;
        private System.Windows.Forms.Label detectErrorsLabel;
        private System.Windows.Forms.CheckBox detectWarningsCheckBox;
        private System.Windows.Forms.Label detectWarningsLabel;
        private System.Windows.Forms.CheckBox detectFindResultsCheckBox;
        private System.Windows.Forms.Label detectFindResultsLabel;
        private System.Windows.Forms.Panel findPanel;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Button findPrevButton;
        private System.Windows.Forms.Button findCloseButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer findTimer;
        private System.Windows.Forms.CheckBox injectBatcheryOutputCheckBox;
        private System.Windows.Forms.Label injectBatcheryOutputLabel;
        private System.Windows.Forms.Label findCountLabel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox stdTextBox;
        private System.Windows.Forms.SplitContainer favoritesSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.SplitContainer batchSplitContainer;
        private System.Windows.Forms.CheckedListBox batchCheckedListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayout;
        private System.Windows.Forms.Label displayNameLabel;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label workingDirLabel;
        private System.Windows.Forms.Label argsLabel;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label abortOnNonZeroLabel;
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox workingDirTextBox;
        private System.Windows.Forms.TextBox argsTextBox;
        private System.Windows.Forms.NumericUpDown iterationsUpDown;
        private System.Windows.Forms.CheckBox abortOnNonZeroCheckBox;
        private System.Windows.Forms.Button filePathBrowseButton;
        private System.Windows.Forms.Button workingDirBrowseButton;
        private System.Windows.Forms.Button fileToEditBrowseButton;
        private System.Windows.Forms.Button editorBrowseButton;
        private System.Windows.Forms.TextBox fileToEditTextBox;
        private System.Windows.Forms.TextBox editorTextBox;
        private System.Windows.Forms.Label fileToEditLabel;
        private System.Windows.Forms.Label editorLabel;
        private System.Windows.Forms.CheckBox advancedPathEditingCheckBox;
        private System.Windows.Forms.Label advancedPathEditingLabel;
        private System.Windows.Forms.CheckBox disableOnSuccessCheckBox;
        private System.Windows.Forms.Label disableOnSuccessLabel;
    }
}

