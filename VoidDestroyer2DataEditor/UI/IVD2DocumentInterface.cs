using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidDestroyer2DataEditor
{
    public interface IVD2DocumentInterface
    {
        Control GetDocumentControl();

        string GetDocumentTitle();

        string GetDocumentIconKey();
    }
}
