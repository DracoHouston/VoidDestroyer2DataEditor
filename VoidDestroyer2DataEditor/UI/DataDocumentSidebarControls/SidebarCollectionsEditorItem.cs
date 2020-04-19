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
    public partial class SidebarCollectionsEditorItem : UserControl
    {
        int _SelectedIndex;

        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = value;
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                        {
                            ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                UpdateContents();
                            }
                        }
                        else if (Parent.Parent is DataStructureCollectionsEditor)
                        {
                            DataStructureCollectionsEditor editorparent = (DataStructureCollectionsEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                UpdateContents();
                            }
                        }
                    }
                }
            }
        }

        public SidebarCollectionsEditorItem()
        {
            InitializeComponent();
        }

        private void SidebarCollectionsEditorItem_DragDrop(object sender, DragEventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if (e.Data.GetDataPresent("System.Int32"))
            {
                object data = e.Data.GetData("System.Int32");
                if (data is Int32)
                {
                    int idx = (int)data;
                    if (_SelectedIndex != idx)
                    {
                        if (Parent != null)
                        {
                            if (Parent.Parent != null)
                            {
                                if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                                {
                                    ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                                    if ((idx >= 0) && (idx < editorparent.SelectedCollection.Count))
                                    {
                                        editorparent.SelectedCollection.Move(idx, _SelectedIndex);
                                    }
                                }
                                else if (Parent.Parent is DataStructureCollectionsEditor)
                                {
                                    DataStructureCollectionsEditor editorparent = (DataStructureCollectionsEditor)Parent.Parent;
                                    if ((idx >= 0) && (idx < editorparent.SelectedCollection.Count))
                                    {
                                        editorparent.SelectedCollection.Move(idx, _SelectedIndex);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Control c in InnerPanel.Controls)
                        {
                            if (c is DataStructureSidebarItemView)
                            {
                                DataStructureSidebarItemView dsitemview = (DataStructureSidebarItemView)c;
                                dsitemview.ToggleCollectionsItemModeCollapse();
                            }
                        }
                    }
                }
            }
        }

        public virtual void UpdateContents()
        {
            foreach (Control c in InnerPanel.Controls)
            {
                if (c is DataStructureSidebarItemView)
                {
                    DataStructureSidebarItemView dsitemview = (DataStructureSidebarItemView)c;
                    if (Parent != null)
                    {
                        if (Parent.Parent != null)
                        {
                            if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                            {
                                ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                                if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                                {
                                    //editorparent.SelectedCollection.Move(idx, _SelectedIndex);
                                }
                            }
                            else if (Parent.Parent is DataStructureCollectionsEditor)
                            {
                                DataStructureCollectionsEditor editorparent = (DataStructureCollectionsEditor)Parent.Parent;
                                if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                                {
                                    dsitemview.Item = editorparent.SelectedCollection[_SelectedIndex];
                                }
                            }
                        }
                    }
                    
                }
            }
        }

        private void SidebarCollectionsEditorItem_DragEnter(object sender, DragEventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if (e.Data.GetDataPresent("System.Int32"))
            {
                object data = e.Data.GetData("System.Int32");
                if (data is Int32)
                {
                    int idx = (int)data;
                    //if (_SelectedIndex != idx)
                    //{
                        e.Effect = DragDropEffects.Move;
                    //}
                }
            }
        }

        

        private void SidebarCollectionsEditorItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (EditorUI.GetParentVD2DataIsReadOnly(this))
                {
                    foreach (Control c in InnerPanel.Controls)
                    {
                        if (c is DataStructureSidebarItemView)
                        {
                            DataStructureSidebarItemView dsitemview = (DataStructureSidebarItemView)c;
                            dsitemview.ToggleCollectionsItemModeCollapse();
                        }
                    }
                    return;
                }            
                DoDragDrop(_SelectedIndex, DragDropEffects.Move);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is DataStructureCollectionsEditor)
                    {
                        DataStructureCollectionsEditor editorparent = (DataStructureCollectionsEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                        {
                            editorparent.SelectedCollection.RemoveAt(_SelectedIndex);
                        }
                    }
                }
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is DataStructureCollectionsEditor)
                    {
                        DataStructureCollectionsEditor editorparent = (DataStructureCollectionsEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
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
                            VD2DataStructure ds = (VD2DataStructure)System.Activator.CreateInstance(editorparent.ElementType, parentfile, editorparent.SelectedCollection[_SelectedIndex].DataNode);
                            ds.CopyFrom(editorparent.SelectedCollection[_SelectedIndex]);
                            editorparent.SelectedCollection.Add(ds);
                        }
                    }
                }
            }
        }
    }

    public interface ISidebarItemInterface
    {
        


    }
}
