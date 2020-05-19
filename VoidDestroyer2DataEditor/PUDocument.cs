using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    class PUDocument : IVD2DocumentInterface
    {
        public string PUTemplateName;

        public PUDocument(string inTemplateName)
        {
            PUTemplateName = inTemplateName;
        }

        public Control GetDocumentControl()
        {
            PUOgreControl result = new PUOgreControl();
            result.PUSystemName = PUTemplateName;
            result.Dock = DockStyle.Fill;
            return result;
        }

        public string GetDocumentTitle()
        {
            return "     " + PUTemplateName + "     ";
        }

        public string GetDocumentIconKey()
        {
            return "genericfileicon";
        }
    }
}
