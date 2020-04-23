namespace VoidDestroyer2DataEditor
{
    partial class IntegerCollectionSidebarEditorItem
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
            this.IntegerEditor = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.IntegerEditor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IntegerEditor
            // 
            this.IntegerEditor.AllowDrop = true;
            this.IntegerEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.IntegerEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntegerEditor.ForeColor = System.Drawing.Color.White;
            this.IntegerEditor.Location = new System.Drawing.Point(3, 13);
            this.IntegerEditor.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.IntegerEditor.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.IntegerEditor.Name = "IntegerEditor";
            this.IntegerEditor.Size = new System.Drawing.Size(199, 20);
            this.IntegerEditor.TabIndex = 0;
            this.IntegerEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IntegerEditor.ValueChanged += new System.EventHandler(this.IntegerEditor_ValueChanged);
            this.IntegerEditor.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.IntegerEditor.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
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
            // IntegerCollectionSidebarEditorItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.IntegerEditor);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "IntegerCollectionSidebarEditorItem";
            this.Size = new System.Drawing.Size(205, 47);
            this.Load += new System.EventHandler(this.IntegerCollectionSidebarEditorItem_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickedItem);
            this.Resize += new System.EventHandler(this.IntegerCollectionSidebarEditorItem_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.IntegerEditor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown IntegerEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
    }
}
