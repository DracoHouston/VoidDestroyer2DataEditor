using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{   
    class ImageSetDocument : IVD2DocumentInterface
    {
        public string ImageSetName;
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
}
