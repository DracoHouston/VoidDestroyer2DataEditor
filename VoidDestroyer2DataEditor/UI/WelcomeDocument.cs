using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoidDestroyer2DataEditor.UI;

namespace VoidDestroyer2DataEditor
{
    class WelcomeDocument : IVD2DocumentInterface
    {
        public Control GetDocumentControl()
        {
            WelcomeDocumentControl c = new WelcomeDocumentControl();
            c.Dock = DockStyle.Fill;
            return c;
        }

        public string GetDocumentIconKey()
        {
            return "foldericon";
        }

        public string GetDocumentTitle()
        {
            return "Welcome!";
        }
    }
}
