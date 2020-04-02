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
    public partial class VD2TreeFilterDropdown : UserControl
    {
        public List<string> StandardFilterTags;
        List<TreeFilterDropdownItem> FilterCategories;
        public VD2TreeFilterDropdown()
        {
            StandardFilterTags = EditorUI.UI.EditorForm.GetStandardFilterTags();
            FilterCategories = new List<TreeFilterDropdownItem>();
            InitializeComponent();
        }

        private void VD2TreeFilterDropdown_Load(object sender, EventArgs e)
        {
            FilterCategories.Add(new TreeFilterDropdownItem("File Types", "FileType", this));
            flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
            FilterCategories.Add(new TreeFilterDropdownItem("Factions", "Faction", this));
            flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
            FilterCategories.Add(new TreeFilterDropdownItem("Ship Class", "Class", this));
            flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
            FilterCategories.Add(new TreeFilterDropdownItem("Ship Hull", "Hull", this));
            flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
            FilterCategories.Add(new TreeFilterDropdownItem("Ship Size", "Size", this));         
            flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
        }
    }
}
