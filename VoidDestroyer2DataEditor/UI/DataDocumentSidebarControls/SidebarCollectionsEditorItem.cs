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
            if (e.Data.GetDataPresent("System.Int32"))
            {
                object data = e.Data.GetData("System.Int32");
                if (data is Int32)
                {
                    int idx = (int)data;
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
            }
        }

        public virtual void UpdateContents()
        {

        }

        private void SidebarCollectionsEditorItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Int32"))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
    }

    public interface ISidebarItemInterface
    {
        


    }
}
