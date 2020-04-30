using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace VoidDestroyer2DataEditor
{   
    public class ImageSetDocument : IVD2DocumentInterface
    {
        public string ImageSetName;
        public string TexturePath;
        public int Width;
        public int Height;
        public string FilePath;
        public VD2FileSource Source;
        public List<ImageSetImage> Images;

        public event EventHandler OnThisFileDeleted;

        public ImageSetDocument()
        {
            ImageSetName = "";
            FilePath = "";
            Source = null;
            Images = new List<ImageSetImage>();
        }

        public ImageSetDocument(string inImageSetName, string inFilePath, VD2FileSource inSource)
        {
            ImageSetName = inImageSetName;
            FilePath = inFilePath;
            Source = inSource;
            Images = new List<ImageSetImage>();
            LoadData();
        }

        public void LoadData()
        {
            /*if (File.Exists(EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\gui\\imagesets\\" + ImageSetName + ".png"))
            {
                TexturePath = EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\gui\\imagesets\\" + ImageSetName + ".png";
                FilePath = EditorUserSettings.UserSettings.VD2Path + "Mod\\Media\\gui\\imagesets\\" + ImageSetName + ".imageset";
                Source = EditorUserSettings.UserSettings.GetSourceByShortName("Mod");
            }
            else if (File.Exists(EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets\\" + ImageSetName + ".png"))
            {
                TexturePath = EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets\\" + ImageSetName + ".png";
                FilePath = EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets\\" + ImageSetName + ".imageset";
                Source = EditorUserSettings.UserSettings.GetSourceByShortName("Base");
            }*/
            if (File.Exists(Path.GetDirectoryName(FilePath) + ImageSetName + ".png"))
            {
                TexturePath = Path.GetDirectoryName(FilePath) + ImageSetName + ".png";                
            }
            
            if (FilePath != "")
            {
                XmlDocument imagesetxml = new XmlDocument();
                imagesetxml.Load(FilePath);
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
                    ImageSetImage image = new ImageSetImage();
                    image.Name = imagename;
                    image.XPos = imagex;
                    image.YPos = imagey;
                    image.Width = imagew;
                    image.Height = imageh;
                    image.ParentImageSet = this;
                    Images.Add(image);
                }
            }
        }

        public void NotifyFileDeleted()
        {
            OnThisFileDeleted?.Invoke(this, new EventArgs());
        }

        public Control GetDocumentControl()
        {
            ImageSetDocumentControl c = new ImageSetDocumentControl();
            c.Dock = DockStyle.Fill;
            c.ImageSetName = ImageSetName;
            return c;
        }

        public string GetDocumentIconKey()
        {
            return "genericfileicon";
        }

        public string GetDocumentTitle()
        {
            return ImageSetName + "     ";
        }
    }

    public class ImageSetImage
    {
        public string Name;
        public int XPos;
        public int YPos;
        public int Width;
        public int Height;
        public ImageSetDocument ParentImageSet;
    }
}
