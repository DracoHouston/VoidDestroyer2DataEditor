namespace VoidDestroyer2DataEditor
{
    partial class OgreControl
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
            this.OgreContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asdadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asdasdasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OgreContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OgreContextMenu
            // 
            this.OgreContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdadToolStripMenuItem});
            this.OgreContextMenu.Name = "OgreContextMenu";
            this.OgreContextMenu.Size = new System.Drawing.Size(181, 48);
            this.OgreContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OgreContextMenu_Opening);
            // 
            // asdadToolStripMenuItem
            // 
            this.asdadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdadToolStripMenuItem1,
            this.asdasdasdToolStripMenuItem});
            this.asdadToolStripMenuItem.Name = "asdadToolStripMenuItem";
            this.asdadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asdadToolStripMenuItem.Text = "asdad";
            // 
            // asdadToolStripMenuItem1
            // 
            this.asdadToolStripMenuItem1.Name = "asdadToolStripMenuItem1";
            this.asdadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.asdadToolStripMenuItem1.Text = "asdad";
            // 
            // asdasdasdToolStripMenuItem
            // 
            this.asdasdasdToolStripMenuItem.Name = "asdasdasdToolStripMenuItem";
            this.asdasdasdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asdasdasdToolStripMenuItem.Text = "asdasdasd";
            // 
            // OgreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = this.OgreContextMenu;
            this.Name = "OgreControl";
            this.Load += new System.EventHandler(this.OgreControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OgreControl_MouseDown);
            this.MouseLeave += new System.EventHandler(this.OgreControl_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OgreControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OgreControl_MouseUp);
            this.Resize += new System.EventHandler(this.OgreControl_Resize);
            this.OgreContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ContextMenuStrip OgreContextMenu;
        private System.Windows.Forms.ToolStripMenuItem asdadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asdasdasdToolStripMenuItem;
    }
}
