namespace VoidDestroyer2DataEditor
{
    partial class Vector3DCollectionSidebarEditor
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddToCollectionButton = new System.Windows.Forms.Button();
            this.ClearCollectionButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 150);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D Vector Collection";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.AddToCollectionButton);
            this.flowLayoutPanel2.Controls.Add(this.ClearCollectionButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(138, 31);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // AddToCollectionButton
            // 
            this.AddToCollectionButton.AutoSize = true;
            this.AddToCollectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddToCollectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.AddToCollectionButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddToCollectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.AddToCollectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddToCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToCollectionButton.Location = new System.Drawing.Point(3, 3);
            this.AddToCollectionButton.Name = "AddToCollectionButton";
            this.AddToCollectionButton.Size = new System.Drawing.Size(38, 25);
            this.AddToCollectionButton.TabIndex = 0;
            this.AddToCollectionButton.Text = "Add";
            this.AddToCollectionButton.UseVisualStyleBackColor = false;
            this.AddToCollectionButton.Click += new System.EventHandler(this.AddToCollectionButton_Click);
            // 
            // ClearCollectionButton
            // 
            this.ClearCollectionButton.AutoSize = true;
            this.ClearCollectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearCollectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClearCollectionButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClearCollectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ClearCollectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearCollectionButton.Location = new System.Drawing.Point(47, 3);
            this.ClearCollectionButton.Name = "ClearCollectionButton";
            this.ClearCollectionButton.Size = new System.Drawing.Size(43, 25);
            this.ClearCollectionButton.TabIndex = 1;
            this.ClearCollectionButton.Text = "Clear";
            this.ClearCollectionButton.UseVisualStyleBackColor = false;
            this.ClearCollectionButton.Click += new System.EventHandler(this.ClearCollectionButton_Click);
            // 
            // Vector3DCollectionSidebarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Vector3DCollectionSidebarEditor";
            this.Load += new System.EventHandler(this.Vector3DCollectionSidebarEditor_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button AddToCollectionButton;
        private System.Windows.Forms.Button ClearCollectionButton;
    }
}
