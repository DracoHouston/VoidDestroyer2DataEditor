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
    public partial class TreeFilterDropdownSubitem : UserControl
    {
        string FilterTag;

        public TreeFilterDropdownSubitem(string inTag)
        {
            FilterTag = inTag;
            InitializeComponent();
        }

        private void TreeFilterDropdownSubitem_Load(object sender, EventArgs e)
        {
            checkBox1.Text = FilterTag;
            checkBox1.Checked = !EditorUI.UI.EditorForm.IsFilterActive(FilterTag);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                EditorUI.UI.EditorForm.ActivateFilter(FilterTag);
            }
            else
            {
                EditorUI.UI.EditorForm.DeactivateFilter(FilterTag);
            }
        }
    }
}
