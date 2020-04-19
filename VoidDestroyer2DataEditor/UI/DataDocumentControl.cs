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
    public partial class DataDocumentControl : UserControl
    {
        VD2Data _DataFile;
        public VD2Data DataFile
        {
            get
            {
                return _DataFile;
            }
            set
            {
                _DataFile = value;
            }
        }
        public DataDocumentControl()
        {
            InitializeComponent();
        }
    }
}
