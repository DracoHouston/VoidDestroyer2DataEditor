namespace VoidDestroyer2DataEditor
{
    partial class Vector3DCollectionSidebarEditorItem
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
            this.XAxisEditor = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YAxisEditor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ZAxisEditor = new System.Windows.Forms.TextBox();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // XAxisEditor
            // 
            this.XAxisEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.XAxisEditor.ForeColor = System.Drawing.Color.White;
            this.XAxisEditor.Location = new System.Drawing.Point(26, 3);
            this.XAxisEditor.Name = "XAxisEditor";
            this.XAxisEditor.Size = new System.Drawing.Size(171, 20);
            this.XAxisEditor.TabIndex = 1;
            this.XAxisEditor.Text = "0.0";
            this.XAxisEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.XAxisEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XAxisEditor_KeyPress);
            this.XAxisEditor.Leave += new System.EventHandler(this.XAxisEditor_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.XAxisEditor);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.YAxisEditor);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.ZAxisEditor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(185, 20);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y:";
            // 
            // YAxisEditor
            // 
            this.YAxisEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.YAxisEditor.ForeColor = System.Drawing.Color.White;
            this.YAxisEditor.Location = new System.Drawing.Point(226, 3);
            this.YAxisEditor.Name = "YAxisEditor";
            this.YAxisEditor.Size = new System.Drawing.Size(171, 20);
            this.YAxisEditor.TabIndex = 2;
            this.YAxisEditor.Text = "0.0";
            this.YAxisEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.YAxisEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YAxisEditor_KeyPress);
            this.YAxisEditor.Leave += new System.EventHandler(this.YAxisEditor_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Z:";
            // 
            // ZAxisEditor
            // 
            this.ZAxisEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ZAxisEditor.ForeColor = System.Drawing.Color.White;
            this.ZAxisEditor.Location = new System.Drawing.Point(426, 3);
            this.ZAxisEditor.Name = "ZAxisEditor";
            this.ZAxisEditor.Size = new System.Drawing.Size(171, 20);
            this.ZAxisEditor.TabIndex = 3;
            this.ZAxisEditor.Text = "0.0";
            this.ZAxisEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ZAxisEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZAxisEditor_KeyPress);
            this.ZAxisEditor.Leave += new System.EventHandler(this.ZAxisEditor_Leave);
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.SummaryLabel.ContextMenuStrip = this.contextMenuStrip1;
            this.SummaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryLabel.Location = new System.Drawing.Point(10, 10);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(185, 20);
            this.SummaryLabel.TabIndex = 3;
            this.SummaryLabel.Text = "X: 0, Y: 0, Z: 0";
            this.SummaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SummaryLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryLabel_MouseClick);
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
            // Vector3DCollectionSidebarEditorItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Vector3DCollectionSidebarEditorItem";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(205, 40);
            this.Load += new System.EventHandler(this.Vector3DCollectionSidebarEditorItem_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropped);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDraggedOver);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickedItem);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox XAxisEditor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YAxisEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ZAxisEditor;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
    }
}
