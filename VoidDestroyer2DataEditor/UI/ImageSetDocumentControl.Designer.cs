namespace VoidDestroyer2DataEditor
{
    partial class ImageSetDocumentControl
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
            this.ImageSetAtlasImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSetAtlasImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageSetAtlasImage
            // 
            this.ImageSetAtlasImage.Image = global::VoidDestroyer2DataEditor.Properties.Resources.jcStubFemale_Nana;
            this.ImageSetAtlasImage.Location = new System.Drawing.Point(13, 13);
            this.ImageSetAtlasImage.Name = "ImageSetAtlasImage";
            this.ImageSetAtlasImage.Size = new System.Drawing.Size(255, 255);
            this.ImageSetAtlasImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageSetAtlasImage.TabIndex = 0;
            this.ImageSetAtlasImage.TabStop = false;
            // 
            // ImageSetDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.ImageSetAtlasImage);
            this.Name = "ImageSetDocumentControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(133, 133);
            this.Load += new System.EventHandler(this.ImageSetDocumentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSetAtlasImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageSetAtlasImage;
    }
}
