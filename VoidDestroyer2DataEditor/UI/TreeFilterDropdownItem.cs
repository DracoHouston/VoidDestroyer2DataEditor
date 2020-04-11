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
    public partial class TreeFilterDropdownItem : UserControl
    {
        string ItemTitle;
        string TagPrefix;
        List<TreeFilterDropdownSubitem> Subitems;
        VD2TreeFilterDropdown ParentTreeFilterDropdown;
        public TreeFilterDropdownItem(string inTitle, string inPrefix, VD2TreeFilterDropdown inParent)
        {
            ItemTitle = inTitle;
            TagPrefix = inPrefix;
            Subitems = new List<TreeFilterDropdownSubitem>();
            ParentTreeFilterDropdown = inParent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Subitems.Count > 0)
            {
                for (int i = 0; i < Subitems.Count; i++)
                {
                    Subitems[i].Dispose();
                    Subitems.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                if (ParentTreeFilterDropdown != null)
                {
                    for (int i = 0; i < ParentTreeFilterDropdown.StandardFilterTags.Count; i++)
                    {
                        List<string> splittag = ParentTreeFilterDropdown.StandardFilterTags[i].Split(":".ToCharArray()).ToList();
                        if (splittag.Count == 2)
                        {
                            if (splittag[0] == TagPrefix)
                            {
                                Subitems.Add(new TreeFilterDropdownSubitem(ParentTreeFilterDropdown.StandardFilterTags[i]));
                                flowLayoutPanel1.Controls.Add(Subitems[Subitems.Count - 1]);
                                //PerformLayout();
                            }
                        }
                    }
                }
            }
        }

        private void TreeFilterDropdownItem_Load(object sender, EventArgs e)
        {
            button1.Text = ItemTitle;
        }
    }
}
