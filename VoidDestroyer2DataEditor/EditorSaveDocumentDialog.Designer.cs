namespace VoidDestroyer2DataEditor
{
    partial class EditorSaveDocumentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorSaveDocumentDialog));
            this.SaveButton = new System.Windows.Forms.Button();
            this.DontSaveButton = new System.Windows.Forms.Button();
            this.CamcelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(16, 79);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DontSaveButton
            // 
            this.DontSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.DontSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DontSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.DontSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DontSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DontSaveButton.Location = new System.Drawing.Point(97, 79);
            this.DontSaveButton.Name = "DontSaveButton";
            this.DontSaveButton.Size = new System.Drawing.Size(75, 23);
            this.DontSaveButton.TabIndex = 1;
            this.DontSaveButton.Text = "Don\'t Save";
            this.DontSaveButton.UseVisualStyleBackColor = false;
            this.DontSaveButton.Click += new System.EventHandler(this.DontSaveButton_Click);
            // 
            // CamcelButton
            // 
            this.CamcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.CamcelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CamcelButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CamcelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.CamcelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CamcelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CamcelButton.Location = new System.Drawing.Point(178, 79);
            this.CamcelButton.Name = "CamcelButton";
            this.CamcelButton.Size = new System.Drawing.Size(75, 23);
            this.CamcelButton.TabIndex = 2;
            this.CamcelButton.Text = "Cancel";
            this.CamcelButton.UseVisualStyleBackColor = false;
            this.CamcelButton.Click += new System.EventHandler(this.CamcelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "You are closing an unsaved file.\r\n\r\nSave changes?";
            // 
            // EditorSaveDocumentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.CancelButton = this.CamcelButton;
            this.ClientSize = new System.Drawing.Size(265, 118);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CamcelButton);
            this.Controls.Add(this.DontSaveButton);
            this.Controls.Add(this.SaveButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorSaveDocumentDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Document has unsaved changes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DontSaveButton;
        private System.Windows.Forms.Button CamcelButton;
        private System.Windows.Forms.Label label1;
    }
}