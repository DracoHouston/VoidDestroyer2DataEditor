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
        public string FilePath;
        VD2FileSource _Source;

        public event EventHandler OnThisFileDeleted;

        public VD2FileSource Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }

        public MeshDocument()
        {
            MeshName = "";
            _Source = null;
        }

        public void NotifyFileDeleted()
        {
            OnThisFileDeleted?.Invoke(this, new EventArgs());
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

        public virtual string GetDocumentTitle()
        {
            if (Source != null)
            {
                return "(" + Source.ShortName + ") " + "Mesh: " + MeshName + "     ";
            }
            return "Mesh: " + MeshName + "     ";
        }
    }
}
