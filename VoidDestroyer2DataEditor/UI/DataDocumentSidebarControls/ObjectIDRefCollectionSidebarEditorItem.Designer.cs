namespace VoidDestroyer2DataEditor
{
    partial class ObjectIDRefCollectionSidebarEditorItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ObjectIDEditor = new System.Windows.Forms.ComboBox();
            this.ObjectIDRefContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TypeText = new System.Windows.Forms.Label();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectIDRefContextMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectIDEditor
            // 
            this.ObjectIDEditor.BackColor = System.Drawing.Color.Black;
            this.ObjectIDEditor.ContextMenuStrip = this.ObjectIDRefContextMenu;
            this.ObjectIDEditor.ForeColor = System.Drawing.Color.White;
            this.ObjectIDEditor.FormattingEnabled = true;
            this.ObjectIDEditor.Location = new System.Drawing.Point(3, 16);
            this.ObjectIDEditor.Name = "ObjectIDEditor";
            this.ObjectIDEditor.Size = new System.Drawing.Size(185, 21);
            this.ObjectIDEditor.Sorted = true;
            this.ObjectIDEditor.TabIndex = 0;
            this.ObjectIDEditor.TextChanged += new System.EventHandler(this.ObjectIDEditor_TextChanged);
            // 
            // ObjectIDRefContextMenu
            // 
            this.ObjectIDRefContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.duplicateToolStripMenuItem});
            this.ObjectIDRefContextMenu.Name = "ObjectIDRefContextMenu";
            this.ObjectIDRefContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.flowLayoutPanel1.ContextMenuStrip = this.ObjectIDRefContextMenu;
            this.flowLayoutPanel1.Controls.Add(this.TypeText);
            this.flowLayoutPanel1.Controls.Add(this.ObjectIDEditor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 47);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.flowLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickedItem);
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // TypeText
            // 
            this.TypeText.AllowDrop = true;
            this.TypeText.AutoSize = true;
            this.TypeText.ContextMenuStrip = this.ObjectIDRefContextMenu;
            this.TypeText.ForeColor = System.Drawing.Color.White;
            this.TypeText.Location = new System.Drawing.Point(3, 0);
            this.TypeText.Name = "TypeText";
            this.TypeText.Size = new System.Drawing.Size(35, 13);
            this.TypeText.TabIndex = 1;
            this.TypeText.Text = "label1";
            this.TypeText.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.TypeText.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
            this.TypeText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickedItem);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // ObjectIDRefCollectionSidebarEditorItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ObjectIDRefCollectionSidebarEditorItem";
            this.Size = new System.Drawing.Size(205, 47);
            this.Load += new System.EventHandler(this.ObjectIDRefCollectionSidebarEditorItem_Load);
            this.ObjectIDRefContextMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label TypeText;
        public System.Windows.Forms.ComboBox ObjectIDEditor;
        private System.Windows.Forms.ContextMenuStrip ObjectIDRefContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
    }
}
