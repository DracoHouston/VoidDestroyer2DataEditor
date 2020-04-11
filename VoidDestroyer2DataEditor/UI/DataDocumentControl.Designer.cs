namespace VoidDestroyer2DataEditor
{
    partial class DataDocumentControl
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
            this.MainSplitter = new System.Windows.Forms.SplitContainer();
            this.DataDocProperties = new System.Windows.Forms.PropertyGrid();
            this.SidebarSplitter = new System.Windows.Forms.SplitContainer();
            this.CollectionsTabs = new VoidDestroyer2DataEditor.EditorTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).BeginInit();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitter)).BeginInit();
            this.SidebarSplitter.Panel2.SuspendLayout();
            this.SidebarSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitter
            // 
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Name = "MainSplitter";
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.Controls.Add(this.DataDocProperties);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.Controls.Add(this.SidebarSplitter);
            this.MainSplitter.Size = new System.Drawing.Size(500, 500);
            this.MainSplitter.SplitterDistance = 301;
            this.MainSplitter.TabIndex = 0;
            // 
            // DataDocProperties
            // 
            this.DataDocProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataDocProperties.Location = new System.Drawing.Point(0, 0);
            this.DataDocProperties.Name = "DataDocProperties";
            this.DataDocProperties.SelectedObject = this;
            this.DataDocProperties.Size = new System.Drawing.Size(301, 500);
            this.DataDocProperties.TabIndex = 0;
            // 
            // SidebarSplitter
            // 
            this.SidebarSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidebarSplitter.Location = new System.Drawing.Point(0, 0);
            this.SidebarSplitter.Name = "SidebarSplitter";
            this.SidebarSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SidebarSplitter.Panel1
            // 
            this.SidebarSplitter.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            // 
            // SidebarSplitter.Panel2
            // 
            this.SidebarSplitter.Panel2.Controls.Add(this.CollectionsTabs);
            this.SidebarSplitter.Size = new System.Drawing.Size(195, 500);
            this.SidebarSplitter.SplitterDistance = 166;
            this.SidebarSplitter.TabIndex = 0;
            // 
            // CollectionsTabs
            // 
            this.CollectionsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CollectionsTabs.Location = new System.Drawing.Point(0, 0);
            this.CollectionsTabs.Multiline = true;
            this.CollectionsTabs.Name = "CollectionsTabs";
            this.CollectionsTabs.SelectedIndex = 0;
            this.CollectionsTabs.Size = new System.Drawing.Size(195, 330);
            this.CollectionsTabs.TabIndex = 0;
            // 
            // DataDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitter);
            this.Name = "DataDocumentControl";
            this.Size = new System.Drawing.Size(500, 500);
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).EndInit();
            this.MainSplitter.ResumeLayout(false);
            this.SidebarSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SidebarSplitter)).EndInit();
            this.SidebarSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.SplitContainer MainSplitter;
        public System.Windows.Forms.PropertyGrid DataDocProperties;
        public System.Windows.Forms.SplitContainer SidebarSplitter;
        public EditorTabControl CollectionsTabs;
    }
}
