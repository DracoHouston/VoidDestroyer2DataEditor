using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace VoidDestroyer2DataEditor
{
    public partial class DataStructureCollectionsEditor : UserControl
    {
        ObservableCollection<VD2DataStructure> _SelectedCollection;
        Type _ElementType;

        public Type ElementType
        {
            get
            {
                return _ElementType;
            }
            set
            {
                _ElementType = value;
            }
        }
        public ObservableCollection<VD2DataStructure> SelectedCollection
        {
            get
            {
                return _SelectedCollection;
            }
            set
            {
                _SelectedCollection = value;
                _SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                for (int i = 0; i < _SelectedCollection.Count; i++)
                {
                    SidebarCollectionsEditorItem editoritem = new SidebarCollectionsEditorItem();
                    DataStructureSidebarItemView dsitemview = new DataStructureSidebarItemView();
                    dsitemview.Item = _SelectedCollection[i];
                    dsitemview.Dock = DockStyle.Fill;
                    editoritem.InnerPanel.Controls.Add(dsitemview);
                    flowLayoutPanel1.Controls.Add(editoritem);
                    editoritem.SelectedIndex = i;
                    editoritem.Size = new Size(flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width, editoritem.Size.Height);
                }
            }
        }

        private void SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if ((flowLayoutPanel1.Controls.Count - 1) > _SelectedCollection.Count)
            {
                for (int i = flowLayoutPanel1.Controls.Count - 1; i > _SelectedCollection.Count; i--)
                {
                    flowLayoutPanel1.Controls.RemoveAt(i);
                }
            }
            else if ((flowLayoutPanel1.Controls.Count - 1) < _SelectedCollection.Count)
            {
                for (int i = flowLayoutPanel1.Controls.Count - 1; i < _SelectedCollection.Count; i++)
                {
                    SidebarCollectionsEditorItem editoritem = new SidebarCollectionsEditorItem();
                    DataStructureSidebarItemView dsitemview = new DataStructureSidebarItemView();
                    dsitemview.Item = _SelectedCollection[i];
                    dsitemview.Dock = DockStyle.Fill;
                    editoritem.InnerPanel.Controls.Add(dsitemview);
                    flowLayoutPanel1.Controls.Add(editoritem);
                    editoritem.SelectedIndex = i;
                    editoritem.Size = new Size((int)((flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width) * 0.95f), editoritem.Size.Height);
                }
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is SidebarCollectionsEditorItem)
                {
                    SidebarCollectionsEditorItem editoritem = (SidebarCollectionsEditorItem)c;
                    editoritem.UpdateContents();
                }
            }
        }

        public DataStructureCollectionsEditor()
        {
            InitializeComponent();
        }

        private void AddToCollectionButton_Click(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if ((_SelectedCollection != null) && (_ElementType != null))
            {
                VD2Data parentfile = null;
                Control c = this;
                while (c.Parent != null)
                {
                    if (c.Parent is VD2DocumentViewer)
                    {
                        VD2DocumentViewer docview = (VD2DocumentViewer)c.Parent;
                        if (docview.Document is VD2Data)
                        {
                            parentfile = (VD2Data)docview.Document;
                        }
                    }
                    c = c.Parent;
                }
                VD2DataStructure ds = (VD2DataStructure)System.Activator.CreateInstance(_ElementType, parentfile, null);
                _SelectedCollection.Add(ds);
                // 
                // _SelectedCollection.Add("");
            }
        }

        private void ClearCollectionButton_Click(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if (_SelectedCollection != null)
            {
                _SelectedCollection.Clear();
            }
        }

        private void DataStructureCollectionsEditor_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c != groupBox1)
                {
                    c.Size = new Size((int)((flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width) * 0.95f), c.Size.Height);
                }
                else
                {
                    c.Size = new Size(flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width, c.Size.Height);
                }
            }
        }
    }
}
