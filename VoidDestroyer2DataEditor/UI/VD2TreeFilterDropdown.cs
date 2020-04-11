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
    public partial class VD2TreeFilterDropdown : UserControl
    {
        public List<string> StandardFilterTags;
        List<TreeFilterDropdownItem> FilterCategories;
        public VD2TreeFilterDropdown()
        {
            /*if (!DesignMode)
            {
                if (EditorUI.UI != null)
                {
                    StandardFilterTags = EditorUI.UI.EditorForm.GetStandardFilterTags();
                }
            }
            else
            {
               */ StandardFilterTags = new List<string>();
              //  StandardFilterTags.Add("Example:Test");
         //   }
            FilterCategories = new List<TreeFilterDropdownItem>();
            
            InitializeComponent();
        }

        private void VD2TreeFilterDropdown_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                StandardFilterTags.AddRange(EditorUI.UI.EditorForm.GetStandardFilterTags());
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
            else
            {
                FilterCategories.Add(new TreeFilterDropdownItem("Example Tags", "Example", this));
                flowLayoutPanel1.Controls.Add(FilterCategories[FilterCategories.Count - 1]);
            }
        }
    }
}
