namespace VoidDestroyer2DataEditor
{
    partial class MainEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeIcons32 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VD2PathFinderDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyObjectIDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeIcons16 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editorTabControl1 = new VoidDestroyer2DataEditor.EditorTabControl();
            this.Files = new System.Windows.Forms.TabPage();
            this.FilesTree = new System.Windows.Forms.TreeView();
            this.Filters = new System.Windows.Forms.TabPage();
            this.vD2TreeFilterDropdown1 = new VoidDestroyer2DataEditor.VD2TreeFilterDropdown();
            this.Sources = new System.Windows.Forms.TabPage();
            this.vD2SourceDropdown2 = new VoidDestroyer2DataEditor.VD2SourceDropdown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.documentTabControl1 = new VoidDestroyer2DataEditor.DocumentTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataFileProperties = new System.Windows.Forms.PropertyGrid();
            this.vD2SourceDropdown1 = new VoidDestroyer2DataEditor.VD2SourceDropdown();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.editorTabControl1.SuspendLayout();
            this.Files.SuspendLayout();
            this.Filters.SuspendLayout();
            this.Sources.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TreeIcons32
            // 
            this.TreeIcons32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeIcons32.ImageStream")));
            this.TreeIcons32.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeIcons32.Images.SetKeyName(0, "selectedicon");
            this.TreeIcons32.Images.SetKeyName(1, "genericfileicon");
            this.TreeIcons32.Images.SetKeyName(2, "foldericon");
            this.TreeIcons32.Images.SetKeyName(3, "categoryicon");
            this.TreeIcons32.Images.SetKeyName(4, "droneicon");
            this.TreeIcons32.Images.SetKeyName(5, "fightericon");
            this.TreeIcons32.Images.SetKeyName(6, "gunshipicon");
            this.TreeIcons32.Images.SetKeyName(7, "corvetteicon");
            this.TreeIcons32.Images.SetKeyName(8, "frigateicon");
            this.TreeIcons32.Images.SetKeyName(9, "destroyericon");
            this.TreeIcons32.Images.SetKeyName(10, "cruisericon");
            this.TreeIcons32.Images.SetKeyName(11, "carriericon");
            this.TreeIcons32.Images.SetKeyName(12, "dreadnaughticon");
            this.TreeIcons32.Images.SetKeyName(13, "transporticon");
            this.TreeIcons32.Images.SetKeyName(14, "minericon");
            this.TreeIcons32.Images.SetKeyName(15, "shuttleicon");
            this.TreeIcons32.Images.SetKeyName(16, "repairicon");
            this.TreeIcons32.Images.SetKeyName(17, "shipcaptureicon");
            this.TreeIcons32.Images.SetKeyName(18, "basecaptureicon");
            this.TreeIcons32.Images.SetKeyName(19, "buildericon");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditorSettingsToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "Settings";
            // 
            // EditorSettingsToolStripMenuItem
            // 
            this.EditorSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.EditorSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditorSettingsToolStripMenuItem.Name = "EditorSettingsToolStripMenuItem";
            this.EditorSettingsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.EditorSettingsToolStripMenuItem.Text = "Editor Settings";
            this.EditorSettingsToolStripMenuItem.Click += new System.EventHandler(this.EditorSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // VD2PathFinderDialog
            // 
            this.VD2PathFinderDialog.DefaultExt = "exe";
            this.VD2PathFinderDialog.FileName = "Void Destroyer 2.exe";
            this.VD2PathFinderDialog.Filter = "Void Destroyer 2.exe|Void Destroyer 2.exe";
            this.VD2PathFinderDialog.InitialDirectory = "MyComputer";
            this.VD2PathFinderDialog.Title = "Please find your \'Void Destroyer 2.exe\'";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem3.Text = "Save File";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem4.Text = "Save As...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem5.Text = "Delete File";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItem6.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem6.Text = "Duplicate To Mod Files";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(266, 6);
            // 
            // CopyObjectIDItem
            // 
            this.CopyObjectIDItem.Name = "CopyObjectIDItem";
            this.CopyObjectIDItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.CopyObjectIDItem.Size = new System.Drawing.Size(269, 22);
            this.CopyObjectIDItem.Text = "Copy objectID";
            this.CopyObjectIDItem.Click += new System.EventHandler(this.CopyObjectIDItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem8.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem8.Text = "Find References";
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator2,
            this.CopyObjectIDItem,
            this.toolStripMenuItem8,
            this.openFileLocationToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(270, 186);
            this.TreeContextMenu.Opened += new System.EventHandler(this.TreeContextMenu_Opened);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open File Location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // TreeIcons16
            // 
            this.TreeIcons16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeIcons16.ImageStream")));
            this.TreeIcons16.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeIcons16.Images.SetKeyName(0, "selectedicon");
            this.TreeIcons16.Images.SetKeyName(1, "genericfileicon");
            this.TreeIcons16.Images.SetKeyName(2, "foldericon");
            this.TreeIcons16.Images.SetKeyName(3, "categoryicon");
            this.TreeIcons16.Images.SetKeyName(4, "droneicon");
            this.TreeIcons16.Images.SetKeyName(5, "fightericon");
            this.TreeIcons16.Images.SetKeyName(6, "gunshipicon");
            this.TreeIcons16.Images.SetKeyName(7, "corvetteicon");
            this.TreeIcons16.Images.SetKeyName(8, "frigateicon");
            this.TreeIcons16.Images.SetKeyName(9, "destroyericon");
            this.TreeIcons16.Images.SetKeyName(10, "cruisericon");
            this.TreeIcons16.Images.SetKeyName(11, "carriericon");
            this.TreeIcons16.Images.SetKeyName(12, "dreadnaughticon");
            this.TreeIcons16.Images.SetKeyName(13, "transporticon");
            this.TreeIcons16.Images.SetKeyName(14, "minericon");
            this.TreeIcons16.Images.SetKeyName(15, "shuttleicon");
            this.TreeIcons16.Images.SetKeyName(16, "repairicon");
            this.TreeIcons16.Images.SetKeyName(17, "shipcaptureicon");
            this.TreeIcons16.Images.SetKeyName(18, "basecaptureicon");
            this.TreeIcons16.Images.SetKeyName(19, "buildericon");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editorTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 513);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 3;
            // 
            // editorTabControl1
            // 
            this.editorTabControl1.Controls.Add(this.Files);
            this.editorTabControl1.Controls.Add(this.Filters);
            this.editorTabControl1.Controls.Add(this.Sources);
            this.editorTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorTabControl1.Location = new System.Drawing.Point(0, 0);
            this.editorTabControl1.Name = "editorTabControl1";
            this.editorTabControl1.SelectedIndex = 0;
            this.editorTabControl1.Size = new System.Drawing.Size(250, 513);
            this.editorTabControl1.TabIndex = 8;
            // 
            // Files
            // 
            this.Files.Controls.Add(this.FilesTree);
            this.Files.Location = new System.Drawing.Point(4, 22);
            this.Files.Name = "Files";
            this.Files.Padding = new System.Windows.Forms.Padding(3);
            this.Files.Size = new System.Drawing.Size(242, 487);
            this.Files.TabIndex = 1;
            this.Files.Text = "Files";
            this.Files.UseVisualStyleBackColor = true;
            // 
            // FilesTree
            // 
            this.FilesTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FilesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesTree.ForeColor = System.Drawing.Color.White;
            this.FilesTree.ImageIndex = 1;
            this.FilesTree.ImageList = this.TreeIcons32;
            this.FilesTree.LineColor = System.Drawing.Color.White;
            this.FilesTree.Location = new System.Drawing.Point(3, 3);
            this.FilesTree.Name = "FilesTree";
            this.FilesTree.SelectedImageIndex = 0;
            this.FilesTree.Size = new System.Drawing.Size(236, 481);
            this.FilesTree.TabIndex = 7;
            this.FilesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FilesTree_AfterSelect);
            this.FilesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTree_NodeMouseClick);
            this.FilesTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTree_NodeMouseDoubleClick);
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.vD2TreeFilterDropdown1);
            this.Filters.Location = new System.Drawing.Point(4, 22);
            this.Filters.Name = "Filters";
            this.Filters.Padding = new System.Windows.Forms.Padding(3);
            this.Filters.Size = new System.Drawing.Size(242, 487);
            this.Filters.TabIndex = 2;
            this.Filters.Text = "Filters";
            this.Filters.UseVisualStyleBackColor = true;
            // 
            // vD2TreeFilterDropdown1
            // 
            this.vD2TreeFilterDropdown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vD2TreeFilterDropdown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vD2TreeFilterDropdown1.Location = new System.Drawing.Point(3, 3);
            this.vD2TreeFilterDropdown1.Name = "vD2TreeFilterDropdown1";
            this.vD2TreeFilterDropdown1.Size = new System.Drawing.Size(236, 481);
            this.vD2TreeFilterDropdown1.TabIndex = 0;
            // 
            // Sources
            // 
            this.Sources.Controls.Add(this.vD2SourceDropdown2);
            this.Sources.Location = new System.Drawing.Point(4, 22);
            this.Sources.Name = "Sources";
            this.Sources.Padding = new System.Windows.Forms.Padding(3);
            this.Sources.Size = new System.Drawing.Size(242, 487);
            this.Sources.TabIndex = 3;
            this.Sources.Text = "Sources";
            this.Sources.UseVisualStyleBackColor = true;
            // 
            // vD2SourceDropdown2
            // 
            this.vD2SourceDropdown2.AutoSize = true;
            this.vD2SourceDropdown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.vD2SourceDropdown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vD2SourceDropdown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vD2SourceDropdown2.Location = new System.Drawing.Point(3, 3);
            this.vD2SourceDropdown2.Name = "vD2SourceDropdown2";
            this.vD2SourceDropdown2.Size = new System.Drawing.Size(236, 481);
            this.vD2SourceDropdown2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 513);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.documentTabControl1);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // documentTabControl1
            // 
            this.documentTabControl1.CloseButtonImage = null;
            this.documentTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentTabControl1.ImageList = this.TreeIcons16;
            this.documentTabControl1.Location = new System.Drawing.Point(3, 3);
            this.documentTabControl1.Name = "documentTabControl1";
            this.documentTabControl1.SelectedIndex = 0;
            this.documentTabControl1.Size = new System.Drawing.Size(516, 481);
            this.documentTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataFileProperties);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(522, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataFileProperties
            // 
            this.DataFileProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DataFileProperties.CategoryForeColor = System.Drawing.Color.White;
            this.DataFileProperties.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DataFileProperties.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DataFileProperties.CommandsForeColor = System.Drawing.SystemColors.Control;
            this.DataFileProperties.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataFileProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataFileProperties.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DataFileProperties.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.DataFileProperties.HelpForeColor = System.Drawing.Color.White;
            this.DataFileProperties.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DataFileProperties.Location = new System.Drawing.Point(3, 3);
            this.DataFileProperties.Name = "DataFileProperties";
            this.DataFileProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.DataFileProperties.SelectedItemWithFocusForeColor = System.Drawing.Color.White;
            this.DataFileProperties.Size = new System.Drawing.Size(516, 481);
            this.DataFileProperties.TabIndex = 0;
            this.DataFileProperties.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.DataFileProperties.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.DataFileProperties.ViewForeColor = System.Drawing.Color.White;
            // 
            // vD2SourceDropdown1
            // 
            this.vD2SourceDropdown1.AutoSize = true;
            this.vD2SourceDropdown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.vD2SourceDropdown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vD2SourceDropdown1.Location = new System.Drawing.Point(8, 8);
            this.vD2SourceDropdown1.Name = "vD2SourceDropdown1";
            this.vD2SourceDropdown1.Size = new System.Drawing.Size(2, 2);
            this.vD2SourceDropdown1.TabIndex = 1;
            // 
            // MainEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainEditorForm";
            this.Text = "Void Destroyer 2 Data Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TreeContextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.editorTabControl1.ResumeLayout(false);
            this.Files.ResumeLayout(false);
            this.Filters.ResumeLayout(false);
            this.Sources.ResumeLayout(false);
            this.Sources.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EditorSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog VD2PathFinderDialog;
        public System.Windows.Forms.TreeView FilesTree;
        private System.Windows.Forms.ImageList TreeIcons32;
        public System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CopyObjectIDItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ImageList TreeIcons16;
        public System.Windows.Forms.PropertyGrid DataFileProperties;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DocumentTabControl documentTabControl1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private EditorTabControl editorTabControl1;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.TabPage Filters;
        private System.Windows.Forms.TabPage Sources;
        private VD2TreeFilterDropdown vD2TreeFilterDropdown1;
        private VD2SourceDropdown vD2SourceDropdown1;
        private VD2SourceDropdown vD2SourceDropdown2;
    }
}

