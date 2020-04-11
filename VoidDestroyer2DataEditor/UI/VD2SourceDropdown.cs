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
    public partial class VD2SourceDropdown : UserControl
    {
        List<VD2SourceDropdownItem> Items;
        public VD2SourceDropdown()
        {
            InitializeComponent();
            Items = new List<VD2SourceDropdownItem>();
        }

        private void VD2SourceDropdown_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //int yoff = 3;
                for (int i = 0; i < EditorUserSettings.UserSettings.Sources.Count; i++)
                {
                    VD2SourceDropdownItem newitem = new VD2SourceDropdownItem();
                    flowLayoutPanel1.Controls.Add(newitem);
                    Items.Add(newitem);
                    newitem.FolderLabel.Text = "(VD2\\" + EditorUserSettings.UserSettings.Sources[i].Path + ")";
                    newitem.SourceNameLabel.Text = EditorUserSettings.UserSettings.Sources[i].DisplayName + "(" + EditorUserSettings.UserSettings.Sources[i].ShortName + ")";
                    newitem.WriteAccessCheckBox.Checked = EditorUserSettings.UserSettings.Sources[i].WriteAccess;
                    newitem.FilterCheckbox.Checked = EditorUserSettings.UserSettings.Sources[i].FilterIn;
                    newitem.AssociatedSource = EditorUserSettings.UserSettings.Sources[i];
                    //newitem.Location = new Point(3, yoff);
                    //yoff += newitem.Size.Height;
                }
            }
            else
            {
                VD2SourceDropdownItem newitem = new VD2SourceDropdownItem();
                flowLayoutPanel1.Controls.Add(newitem);
                Items.Add(newitem);
                newitem.FolderLabel.Text = "(VD2\\Example)";
                newitem.SourceNameLabel.Text = "Example Source(Example)";
                newitem.WriteAccessCheckBox.Checked = false;
                newitem.FilterCheckbox.Checked = true;
            }
            
           
        }
    }
}
