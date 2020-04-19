namespace VoidDestroyer2DataEditor
{
    partial class StringCollectionSidebarEditor
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
            this.StringCollectionText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StringCollectionText
            // 
            this.StringCollectionText.AcceptsReturn = true;
            this.StringCollectionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.StringCollectionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StringCollectionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StringCollectionText.ForeColor = System.Drawing.Color.White;
            this.StringCollectionText.Location = new System.Drawing.Point(10, 10);
            this.StringCollectionText.Multiline = true;
            this.StringCollectionText.Name = "StringCollectionText";
            this.StringCollectionText.Size = new System.Drawing.Size(130, 130);
            this.StringCollectionText.TabIndex = 0;
            this.StringCollectionText.TextChanged += new System.EventHandler(this.StringCollectionText_TextChanged);
            // 
            // StringCollectionSidebarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.StringCollectionText);
            this.Name = "StringCollectionSidebarEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox StringCollectionText;
    }
}
