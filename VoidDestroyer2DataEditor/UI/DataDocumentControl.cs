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

        private void DataDocumentControl_Load(object sender, EventArgs e)
        {
            
        }

        private void DocumentTab_CloseClick(object sender, CancelEventArgs e)
        {
            if (sender is Button)
            {
                Control c = this;
                DocumentTabControl mytabcontrol = null;
                TabPage mytabpage = null;
                while (c.Parent != null)
                {
                    if (c.Parent is TabPage)
                    {
                        mytabpage = (TabPage)c.Parent;
                    }
                    if (c.Parent is DocumentTabControl)
                    {
                        mytabcontrol = (DocumentTabControl)c.Parent;
                        break;//if we reached the tab control we're done
                    }
                    c = c.Parent;
                }
                if ((mytabpage != null) && (mytabcontrol != null))
                {
                    if (mytabpage == mytabcontrol.TabPageByCloseButton((Button)sender))
                    {
                        if (DataFile.Unsaved)
                        {
                            EditorSaveDocumentDialog dialog = new EditorSaveDocumentDialog();
                            DialogResult result = dialog.ShowDialog();
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    DataFile.TrySaveData();
                                    break;
                                case DialogResult.No:
                                    DataFile.LoadDataFromXML();
                                    break;
                                case DialogResult.Cancel:
                                    e.Cancel = true;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void DataDocumentControl_ParentChanged(object sender, EventArgs e)
        {
            Control c = this;
            DocumentTabControl mytabcontrol = null;
            while (c.Parent != null)
            {
                if (c.Parent is DocumentTabControl)
                {
                    mytabcontrol = (DocumentTabControl)c.Parent;
                    break;//if we reached the tab control we're done
                }
                c = c.Parent;
            }
            if (mytabcontrol != null)
            {
                mytabcontrol.CloseClick += DocumentTab_CloseClick;
            }
        }

        private void unsetValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataDocProperties.SelectedGridItem != null)
            {
                DataFile.SetPropertyEdited(DataDocProperties.SelectedGridItem.Label, true);
                DataFile.SetPropertyExists(DataDocProperties.SelectedGridItem.Label, false);
                if (DataFile.Source != null)
                {
                    if (DataFile.Source.ShortName == "Base")
                    {
                        DataFile.SetPropertyExistsInBaseData(DataDocProperties.SelectedGridItem.Label, false);
                    }
                }
            }
        }

        private void setValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataDocProperties.SelectedGridItem != null)
            {
                DataFile.SetPropertyEdited(DataDocProperties.SelectedGridItem.Label, true);
                DataFile.SetPropertyExists(DataDocProperties.SelectedGridItem.Label, true);
                if (DataFile.Source != null)
                {
                    if (DataFile.Source.ShortName == "Base")
                    {
                        DataFile.SetPropertyExistsInBaseData(DataDocProperties.SelectedGridItem.Label, true);
                    }
                }
            }
        }
    }
}
