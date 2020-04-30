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
            this.SaveToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAllToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeIcons32 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VD2PathFinderDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyObjectIDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileInNewTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.documentTabControl1 = new VoidDestroyer2DataEditor.DocumentTabControl();
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
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.SaveToolstripButton,
            this.SaveAllToolstripButton,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // SaveToolstripButton
            // 
            this.SaveToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolstripButton.Image = global::VoidDestroyer2DataEditor.Properties.Resources.saveicon64;
            this.SaveToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolstripButton.Name = "SaveToolstripButton";
            this.SaveToolstripButton.Size = new System.Drawing.Size(36, 36);
            this.SaveToolstripButton.Text = "Save";
            this.SaveToolstripButton.Click += new System.EventHandler(this.SaveToolstripButton_Click);
            // 
            // SaveAllToolstripButton
            // 
            this.SaveAllToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAllToolstripButton.Image = global::VoidDestroyer2DataEditor.Properties.Resources.saveallicon64;
            this.SaveAllToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAllToolstripButton.Name = "SaveAllToolstripButton";
            this.SaveAllToolstripButton.Size = new System.Drawing.Size(36, 36);
            this.SaveAllToolstripButton.Text = "Save All";
            this.SaveAllToolstripButton.ToolTipText = "Save All";
            this.SaveAllToolstripButton.Click += new System.EventHandler(this.SaveAllToolstripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
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
            this.saveToolStripMenuItem1,
            this.saveAllToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitToolStripMenuItem});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.saveToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.saveAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(184, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
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
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.SaveToolStripMenuItem.Text = "Save File";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Enabled = false;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.DeleteToolStripMenuItem.Text = "Delete File";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // OverrideToolStripMenuItem
            // 
            this.OverrideToolStripMenuItem.Enabled = false;
            this.OverrideToolStripMenuItem.Name = "OverrideToolStripMenuItem";
            this.OverrideToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.OverrideToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.OverrideToolStripMenuItem.Text = "Override in Mod Files";
            this.OverrideToolStripMenuItem.Click += new System.EventHandler(this.OverrideToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // CopyObjectIDItem
            // 
            this.CopyObjectIDItem.Name = "CopyObjectIDItem";
            this.CopyObjectIDItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.CopyObjectIDItem.Size = new System.Drawing.Size(261, 22);
            this.CopyObjectIDItem.Text = "Copy objectID";
            this.CopyObjectIDItem.Click += new System.EventHandler(this.CopyObjectIDItem_Click);
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFileInNewTabToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.OverrideToolStripMenuItem,
            this.createDuplicateToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.CopyObjectIDItem,
            this.openFileLocationToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(262, 186);
            this.TreeContextMenu.Opened += new System.EventHandler(this.TreeContextMenu_Opened);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Enabled = false;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFileInNewTabToolStripMenuItem
            // 
            this.openFileInNewTabToolStripMenuItem.Enabled = false;
            this.openFileInNewTabToolStripMenuItem.Name = "openFileInNewTabToolStripMenuItem";
            this.openFileInNewTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openFileInNewTabToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.openFileInNewTabToolStripMenuItem.Text = "Open File in New Tab";
            this.openFileInNewTabToolStripMenuItem.Click += new System.EventHandler(this.openFileInNewTabToolStripMenuItem_Click);
            // 
            // createDuplicateToolStripMenuItem
            // 
            this.createDuplicateToolStripMenuItem.Enabled = false;
            this.createDuplicateToolStripMenuItem.Name = "createDuplicateToolStripMenuItem";
            this.createDuplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.createDuplicateToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.createDuplicateToolStripMenuItem.Text = "Create Duplicate...";
            this.createDuplicateToolStripMenuItem.Click += new System.EventHandler(this.createDuplicateToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Enabled = false;
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 63);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editorTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.documentTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 499);
            this.splitContainer1.SplitterDistance = 229;
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
            this.editorTabControl1.Size = new System.Drawing.Size(229, 499);
            this.editorTabControl1.TabIndex = 8;
            // 
            // Files
            // 
            this.Files.Controls.Add(this.FilesTree);
            this.Files.Location = new System.Drawing.Point(4, 22);
            this.Files.Name = "Files";
            this.Files.Padding = new System.Windows.Forms.Padding(3);
            this.Files.Size = new System.Drawing.Size(221, 473);
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
            this.FilesTree.Size = new System.Drawing.Size(215, 467);
            this.FilesTree.TabIndex = 7;
            this.FilesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTree_NodeMouseClick);
            this.FilesTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTree_NodeMouseDoubleClick);
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.vD2TreeFilterDropdown1);
            this.Filters.Location = new System.Drawing.Point(4, 22);
            this.Filters.Name = "Filters";
            this.Filters.Padding = new System.Windows.Forms.Padding(3);
            this.Filters.Size = new System.Drawing.Size(221, 473);
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
            this.vD2TreeFilterDropdown1.Size = new System.Drawing.Size(215, 467);
            this.vD2TreeFilterDropdown1.TabIndex = 0;
            // 
            // Sources
            // 
            this.Sources.Controls.Add(this.vD2SourceDropdown2);
            this.Sources.Location = new System.Drawing.Point(4, 22);
            this.Sources.Name = "Sources";
            this.Sources.Padding = new System.Windows.Forms.Padding(3);
            this.Sources.Size = new System.Drawing.Size(221, 473);
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
            this.vD2SourceDropdown2.Size = new System.Drawing.Size(215, 467);
            this.vD2SourceDropdown2.TabIndex = 0;
            // 
            // documentTabControl1
            // 
            this.documentTabControl1.CloseButtonImage = null;
            this.documentTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentTabControl1.ImageList = this.TreeIcons16;
            this.documentTabControl1.Location = new System.Drawing.Point(0, 0);
            this.documentTabControl1.Name = "documentTabControl1";
            this.documentTabControl1.SelectedIndex = 0;
            this.documentTabControl1.Size = new System.Drawing.Size(551, 499);
            this.documentTabControl1.TabIndex = 0;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditorForm_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CopyObjectIDItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ImageList TreeIcons16;
        private DocumentTabControl documentTabControl1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private EditorTabControl editorTabControl1;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.TabPage Filters;
        private System.Windows.Forms.TabPage Sources;
        private VD2TreeFilterDropdown vD2TreeFilterDropdown1;
        private VD2SourceDropdown vD2SourceDropdown1;
        private VD2SourceDropdown vD2SourceDropdown2;
        private System.Windows.Forms.ToolStripMenuItem openFileInNewTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDuplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveToolstripButton;
        private System.Windows.Forms.ToolStripButton SaveAllToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

