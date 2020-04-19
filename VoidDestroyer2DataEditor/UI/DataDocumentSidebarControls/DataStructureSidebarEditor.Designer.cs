namespace VoidDestroyer2DataEditor
{
    partial class DataStructureSidebarEditor
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
            this.DataStructureEditor = new VoidDestroyer2DataEditor.DataStructureSidebarItemView();
            this.SuspendLayout();
            // 
            // DataStructureEditor
            // 
            this.DataStructureEditor.AutoScroll = true;
            this.DataStructureEditor.AutoSize = true;
            this.DataStructureEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.DataStructureEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataStructureEditor.ForeColor = System.Drawing.Color.White;
            this.DataStructureEditor.Item = null;
            this.DataStructureEditor.Location = new System.Drawing.Point(10, 10);
            this.DataStructureEditor.Name = "DataStructureEditor";
            this.DataStructureEditor.Size = new System.Drawing.Size(130, 130);
            this.DataStructureEditor.TabIndex = 0;
            // 
            // DataStructureSidebarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.DataStructureEditor);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DataStructureSidebarEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DataStructureSidebarItemView DataStructureEditor;
    }
}
