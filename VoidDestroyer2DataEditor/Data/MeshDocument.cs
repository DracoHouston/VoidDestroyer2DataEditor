using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    class MeshDocument : IVD2DocumentInterface
    {
        public string MeshName;

        public MeshDocument()
        {
            MeshName = "";
        }
        public Control GetDocumentControl()
        {
            OgreControl mv = new OgreControl();
            mv.meshname = MeshName;
            mv.Dock = DockStyle.Fill;
            return mv;
        }

        public string GetDocumentIconKey()
        {
            return "genericfileicon";
        }

        public string GetDocumentTitle()
        {
            return "Mesh: " + MeshName + "     ";
        }
    }
}
