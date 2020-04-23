namespace VoidDestroyer2DataEditor
{
    partial class DuplicateFileDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateFileDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjectIDTextBox = new System.Windows.Forms.TextBox();
            this.FileNameIndicator = new System.Windows.Forms.CheckBox();
            this.ObjectIDIndicator = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelDuplicateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(12, 67);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(357, 20);
            this.FileNameTextBox.TabIndex = 1;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // ObjectIDTextBox
            // 
            this.ObjectIDTextBox.Location = new System.Drawing.Point(8, 145);
            this.ObjectIDTextBox.Name = "ObjectIDTextBox";
            this.ObjectIDTextBox.Size = new System.Drawing.Size(361, 20);
            this.ObjectIDTextBox.TabIndex = 3;
            this.ObjectIDTextBox.TextChanged += new System.EventHandler(this.ObjectIDTextBox_TextChanged);
            // 
            // FileNameIndicator
            // 
            this.FileNameIndicator.AutoCheck = false;
            this.FileNameIndicator.AutoSize = true;
            this.FileNameIndicator.BackColor = System.Drawing.Color.Red;
            this.FileNameIndicator.Enabled = false;
            this.FileNameIndicator.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FileNameIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileNameIndicator.Location = new System.Drawing.Point(375, 71);
            this.FileNameIndicator.Name = "FileNameIndicator";
            this.FileNameIndicator.Size = new System.Drawing.Size(12, 11);
            this.FileNameIndicator.TabIndex = 4;
            this.FileNameIndicator.UseVisualStyleBackColor = false;
            // 
            // ObjectIDIndicator
            // 
            this.ObjectIDIndicator.AutoCheck = false;
            this.ObjectIDIndicator.AutoSize = true;
            this.ObjectIDIndicator.BackColor = System.Drawing.Color.Red;
            this.ObjectIDIndicator.Enabled = false;
            this.ObjectIDIndicator.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ObjectIDIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObjectIDIndicator.Location = new System.Drawing.Point(375, 149);
            this.ObjectIDIndicator.Name = "ObjectIDIndicator";
            this.ObjectIDIndicator.Size = new System.Drawing.Size(12, 11);
            this.ObjectIDIndicator.TabIndex = 5;
            this.ObjectIDIndicator.UseVisualStyleBackColor = false;
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(16, 171);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelDuplicateButton
            // 
            this.CancelDuplicateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.CancelDuplicateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDuplicateButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CancelDuplicateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.CancelDuplicateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelDuplicateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDuplicateButton.ForeColor = System.Drawing.Color.White;
            this.CancelDuplicateButton.Location = new System.Drawing.Point(312, 171);
            this.CancelDuplicateButton.Name = "CancelDuplicateButton";
            this.CancelDuplicateButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDuplicateButton.TabIndex = 7;
            this.CancelDuplicateButton.Text = "Cancel";
            this.CancelDuplicateButton.UseVisualStyleBackColor = false;
            this.CancelDuplicateButton.Click += new System.EventHandler(this.CancelDialogButton_Click);
            // 
            // DuplicateFileDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDuplicateButton;
            this.ClientSize = new System.Drawing.Size(404, 218);
            this.ControlBox = false;
            this.Controls.Add(this.CancelDuplicateButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ObjectIDIndicator);
            this.Controls.Add(this.FileNameIndicator);
            this.Controls.Add(this.ObjectIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuplicateFileDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DuplicateFileDialog";
            this.Load += new System.EventHandler(this.DuplicateFileDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ObjectIDTextBox;
        private System.Windows.Forms.CheckBox FileNameIndicator;
        private System.Windows.Forms.CheckBox ObjectIDIndicator;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelDuplicateButton;
    }
}