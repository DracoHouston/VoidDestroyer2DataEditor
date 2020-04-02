using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor.UI
{
    public partial class VD2SourceDropdownItem : UserControl
    {
        public VD2FileSource AssociatedSource;
        public VD2SourceDropdownItem()
        {
            InitializeComponent();
            AssociatedSource = null;
        }

        private void FilterCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AssociatedSource != null)
            {
                AssociatedSource.FilterIn = FilterCheckbox.Checked;
                EditorUI.UI.EditorForm.RepopulateAllTrees();
            }
        }
    }
}
