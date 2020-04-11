namespace VoidDestroyer2DataEditor
{
    partial class VD2SourceDropdownItem
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
            this.SourceNameLabel = new System.Windows.Forms.Label();
            this.WriteAccessCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.FilterCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceNameLabel
            // 
            this.SourceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceNameLabel.Location = new System.Drawing.Point(20, 3);
            this.SourceNameLabel.MaximumSize = new System.Drawing.Size(180, 15);
            this.SourceNameLabel.MinimumSize = new System.Drawing.Size(180, 15);
            this.SourceNameLabel.Name = "SourceNameLabel";
            this.SourceNameLabel.Size = new System.Drawing.Size(180, 15);
            this.SourceNameLabel.TabIndex = 0;
            this.SourceNameLabel.Text = "...";
            // 
            // WriteAccessCheckBox
            // 
            this.WriteAccessCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WriteAccessCheckBox.Location = new System.Drawing.Point(3, 20);
            this.WriteAccessCheckBox.Name = "WriteAccessCheckBox";
            this.WriteAccessCheckBox.Size = new System.Drawing.Size(89, 17);
            this.WriteAccessCheckBox.TabIndex = 1;
            this.WriteAccessCheckBox.Text = "Write Access";
            this.WriteAccessCheckBox.UseVisualStyleBackColor = true;
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoEllipsis = true;
            this.FolderLabel.Location = new System.Drawing.Point(115, 17);
            this.FolderLabel.MaximumSize = new System.Drawing.Size(80, 20);
            this.FolderLabel.MinimumSize = new System.Drawing.Size(80, 20);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(80, 20);
            this.FolderLabel.TabIndex = 3;
            this.FolderLabel.Text = "...";
            this.FolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterCheckbox
            // 
            this.FilterCheckbox.AutoSize = true;
            this.FilterCheckbox.Checked = true;
            this.FilterCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilterCheckbox.Location = new System.Drawing.Point(3, 3);
            this.FilterCheckbox.Name = "FilterCheckbox";
            this.FilterCheckbox.Size = new System.Drawing.Size(15, 14);
            this.FilterCheckbox.TabIndex = 4;
            this.FilterCheckbox.UseVisualStyleBackColor = true;
            this.FilterCheckbox.CheckedChanged += new System.EventHandler(this.FilterCheckbox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::VoidDestroyer2DataEditor.Properties.Resources.foldericon;
            this.pictureBox1.Location = new System.Drawing.Point(92, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // VD2SourceDropdownItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.FilterCheckbox);
            this.Controls.Add(this.FolderLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WriteAccessCheckBox);
            this.Controls.Add(this.SourceNameLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximumSize = new System.Drawing.Size(200, 40);
            this.MinimumSize = new System.Drawing.Size(200, 40);
            this.Name = "VD2SourceDropdownItem";
            this.Size = new System.Drawing.Size(200, 40);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox WriteAccessCheckBox;
        public System.Windows.Forms.Label SourceNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label FolderLabel;
        public System.Windows.Forms.CheckBox FilterCheckbox;
    }
}
