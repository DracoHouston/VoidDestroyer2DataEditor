namespace VoidDestroyer2DataEditor
{
    partial class FloatCollectionSidebarEditorItem
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
            this.FloatEditor = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FloatEditor
            // 
            this.FloatEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FloatEditor.ForeColor = System.Drawing.Color.White;
            this.FloatEditor.Location = new System.Drawing.Point(3, 13);
            this.FloatEditor.Name = "FloatEditor";
            this.FloatEditor.Size = new System.Drawing.Size(199, 20);
            this.FloatEditor.TabIndex = 0;
            this.FloatEditor.Text = "0.0";
            this.FloatEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FloatEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FloatEditor_KeyPress);
            this.FloatEditor.Leave += new System.EventHandler(this.FloatEditor_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.duplicateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // FloatCollectionSidebarEditorItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.FloatEditor);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FloatCollectionSidebarEditorItem";
            this.Size = new System.Drawing.Size(205, 47);
            this.Load += new System.EventHandler(this.FloatCollectionSidebarEditorItem_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickedItem);
            this.Resize += new System.EventHandler(this.FloatCollectionSidebarEditorItem_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FloatEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
    }
}
