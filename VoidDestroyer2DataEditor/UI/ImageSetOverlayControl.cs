using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class ImageSetOverlayControl : UserControl
    {
        public string ImageName;
        public ImageSetOverlayControl()
        {
            InitializeComponent();
            ImageName = "";
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void ImageSetOverlayControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, 0, Size.Width-1, 0);
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, 0, 0, Size.Height-1);
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, Size.Height-1, Size.Width-1, Size.Height-1);
            e.Graphics.DrawLine(new Pen(Color.Lime), Size.Width-1, Size.Height-1, Size.Width-1, 0);
            e.Graphics.DrawString(ImageName, new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Lime), 3, 3);
        }

        private void ImageSetOverlayControl_Load(object sender, EventArgs e)
        {
            label1.Text = ImageName;
        }
    }
}
