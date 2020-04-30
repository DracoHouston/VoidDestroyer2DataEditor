namespace VoidDestroyer2DataEditor
{
    partial class EditorDeleteFileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorDeleteFileDialog));
            this.ModFileWarning = new System.Windows.Forms.Label();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.BaseFileWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ModFileWarning
            // 
            this.ModFileWarning.AutoSize = true;
            this.ModFileWarning.Location = new System.Drawing.Point(13, 13);
            this.ModFileWarning.Name = "ModFileWarning";
            this.ModFileWarning.Size = new System.Drawing.Size(225, 39);
            this.ModFileWarning.TabIndex = 0;
            this.ModFileWarning.Text = "You are about to delete a Mod file.\r\n\r\nAre you sure? This action cannot be revers" +
    "ed.";
            // 
            // YesButton
            // 
            this.YesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.YesButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.YesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.YesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesButton.Location = new System.Drawing.Point(16, 117);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = false;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.NoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoButton.Location = new System.Drawing.Point(200, 117);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = false;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // BaseFileWarning
            // 
            this.BaseFileWarning.AutoSize = true;
            this.BaseFileWarning.Location = new System.Drawing.Point(13, 13);
            this.BaseFileWarning.Name = "BaseFileWarning";
            this.BaseFileWarning.Size = new System.Drawing.Size(270, 91);
            this.BaseFileWarning.TabIndex = 4;
            this.BaseFileWarning.Text = resources.GetString("BaseFileWarning.Text");
            this.BaseFileWarning.Visible = false;
            // 
            // EditorDeleteFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.CancelButton = this.NoButton;
            this.ClientSize = new System.Drawing.Size(287, 153);
            this.ControlBox = false;
            this.Controls.Add(this.BaseFileWarning);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.ModFileWarning);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EditorDeleteFileDialog";
            this.Text = "/!\\ Deleting File... /!\\";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        public System.Windows.Forms.Label ModFileWarning;
        public System.Windows.Forms.Label BaseFileWarning;
    }
}