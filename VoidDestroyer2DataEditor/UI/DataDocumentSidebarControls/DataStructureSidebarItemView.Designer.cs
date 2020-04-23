namespace VoidDestroyer2DataEditor
{
    partial class DataStructureSidebarItemView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unsetValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(181, 199);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoEllipsis = true;
            this.SummaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryLabel.Location = new System.Drawing.Point(0, 0);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(181, 199);
            this.SummaryLabel.TabIndex = 0;
            this.SummaryLabel.Text = "label1";
            this.SummaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SummaryLabel.Visible = false;
            this.SummaryLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryLabel_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unsetValueToolStripMenuItem,
            this.setValueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(200, 70);
            // 
            // unsetValueToolStripMenuItem
            // 
            this.unsetValueToolStripMenuItem.Name = "unsetValueToolStripMenuItem";
            this.unsetValueToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.unsetValueToolStripMenuItem.Text = "Unset Selected Property";
            this.unsetValueToolStripMenuItem.Click += new System.EventHandler(this.unsetValueToolStripMenuItem_Click);
            // 
            // setValueToolStripMenuItem
            // 
            this.setValueToolStripMenuItem.Name = "setValueToolStripMenuItem";
            this.setValueToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.setValueToolStripMenuItem.Text = "Set Selected Property";
            this.setValueToolStripMenuItem.Click += new System.EventHandler(this.setValueToolStripMenuItem_Click);
            // 
            // DataStructureSidebarItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DataStructureSidebarItemView";
            this.Size = new System.Drawing.Size(181, 199);
            this.Load += new System.EventHandler(this.DataStructureSidebarItemView_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem unsetValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setValueToolStripMenuItem;
    }
}
