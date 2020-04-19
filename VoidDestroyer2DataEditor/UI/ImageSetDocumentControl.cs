using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class ImageSetDocumentControl : UserControl
    {
        public string ImageSetName;
        public ImageSetDocumentControl()
        {
            ImageSetName = "";
            InitializeComponent();
        }

        private void ImageSetDocumentControl_Load(object sender, EventArgs e)
        {
            string imagepath = "";
            if (File.Exists(EditorUserSettings.UserSettings.VD2Path + "Mod\\media\\gui\\imagesets\\" + ImageSetName + ".png"))
            {
                imagepath = EditorUserSettings.UserSettings.VD2Path + "Mod\\media\\gui\\imagesets\\" + ImageSetName + ".png";
            }
            else if (File.Exists(EditorUserSettings.UserSettings.VD2Path + "media\\gui\\imagesets\\" + ImageSetName + ".png"))
            {
                imagepath = EditorUserSettings.UserSettings.VD2Path + "media\\gui\\imagesets\\" + ImageSetName + ".png";
            }
            else
            {
                ImageSetAtlasImage.Visible = false;
            }
            if (imagepath != "")
            {
                ImageSetAtlasImage.Image = Image.FromFile(imagepath);
                XmlDocument imagesetxml = new XmlDocument();
                imagesetxml.Load(Path.GetDirectoryName(imagepath) + "/" + Path.GetFileNameWithoutExtension(imagepath) + ".imageset");
                XmlNodeList images = imagesetxml.GetElementsByTagName("Image");
                foreach (XmlNode node in images)
                {
                    string imagename = "";
                    int imagex = 0;
                    int imagey = 0;
                    int imagew = 0;
                    int imageh = 0;
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        if (attr.Name == "Name")
                        {
                            imagename = attr.Value;
                        }
                        else if (attr.Name == "XPos")
                        {
                            int.TryParse(attr.Value, out imagex);
                        }
                        else if (attr.Name == "YPos")
                        {
                            int.TryParse(attr.Value, out imagey);
                        }
                        else if (attr.Name == "Width")
                        {
                            int.TryParse(attr.Value, out imagew);
                        }
                        else if (attr.Name == "Height")
                        {
                            int.TryParse(attr.Value, out imageh);
                        }
                    }
                    ImageSetOverlayControl c = new ImageSetOverlayControl();
                    c.ImageName = imagename;
                    c.Location = new Point(imagex, imagey);
                    c.Size = new Size(imagew, imageh);
                    ImageSetAtlasImage.Controls.Add(c);
                   // c.BringToFront();
                }
                //BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void ImageSetDocumentControl_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawLine(new Pen(Color.Green, 2), 0, 1, Size.Width, 1);
        }
    }
}
