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
    public partial class SidebarItemView : UserControl
    {
        public object _Item;
        public virtual object Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
            }
        }
        public SidebarItemView()
        {
            InitializeComponent();
        }
    }
}
