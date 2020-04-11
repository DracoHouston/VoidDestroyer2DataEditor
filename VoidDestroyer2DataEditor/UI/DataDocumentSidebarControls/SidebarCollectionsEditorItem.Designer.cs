namespace VoidDestroyer2DataEditor
{
    partial class SidebarCollectionsEditorItem
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
            this.InnerPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // InnerPanel
            // 
            this.InnerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InnerPanel.ForeColor = System.Drawing.Color.White;
            this.InnerPanel.Location = new System.Drawing.Point(10, 10);
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Size = new System.Drawing.Size(130, 130);
            this.InnerPanel.TabIndex = 0;
            // 
            // SidebarCollectionsEditorItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.InnerPanel);
            this.Name = "SidebarCollectionsEditorItem";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SidebarCollectionsEditorItem_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SidebarCollectionsEditorItem_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel InnerPanel;
    }
}
