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
    public partial class IntegerCollectionSidebarEditorItem : UserControl
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
                        if (Parent.Parent is IntegerCollectionEditor)
                        {
                            IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                IntegerEditor.ValueChanged -= IntegerEditor_ValueChanged;
                                IntegerEditor.Value = editorparent.SelectedCollection[_SelectedIndex];
                                IntegerEditor.ValueChanged += IntegerEditor_ValueChanged;
                            }
                        }
                    }
                }
            }
        }
        public IntegerCollectionSidebarEditorItem()
        {
            InitializeComponent();
        }

        private void IntegerCollectionSidebarEditorItem_Resize(object sender, EventArgs e)
        {
            IntegerEditor.Size = new Size((int)((Size.Width - (Margin.Size.Width * 2)) * 0.95f), IntegerEditor.Size.Height);
        }

        private void SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is IntegerCollectionEditor)
                    {
                        IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            IntegerEditor.ValueChanged -= IntegerEditor_ValueChanged;
                            IntegerEditor.Value = editorparent.SelectedCollection[_SelectedIndex];
                            IntegerEditor.ValueChanged += IntegerEditor_ValueChanged;
                        }
                    }
                }
            }
        }

        private void IntegerEditor_ValueChanged(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is IntegerCollectionEditor)
                        {
                            IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                IntegerEditor.ValueChanged -= IntegerEditor_ValueChanged;
                                IntegerEditor.Value = editorparent.SelectedCollection[_SelectedIndex];
                                IntegerEditor.ValueChanged += IntegerEditor_ValueChanged;
                            }
                        }
                    }
                }
                return;
            }
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is IntegerCollectionEditor)
                    {
                        IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            editorparent.SelectedCollection.CollectionChanged -= SelectedCollection_CollectionChanged;
                            editorparent.SelectedCollection[_SelectedIndex] = (int)IntegerEditor.Value;
                            editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                        }
                    }
                }
            }
        }

        private void IntegerCollectionSidebarEditorItem_Load(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is IntegerCollectionEditor)
                    {
                        IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                        editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                    }
                }
            }
        }

        private void OnDragDropped(object sender, DragEventArgs e)
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
                    if (Parent != null)
                    {
                        if (Parent.Parent != null)
                        {
                            if (Parent.Parent is IntegerCollectionEditor)
                            {
                                IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
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

        private void OnDraggedOver(object sender, DragEventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }

            if (e.Data.GetDataPresent("System.Int32"))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void OnClickedItem(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (EditorUI.GetParentVD2DataIsReadOnly(this))
                {
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
                    if (Parent.Parent is IntegerCollectionEditor)
                    {
                        IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
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
                    if (Parent.Parent is IntegerCollectionEditor)
                    {
                        IntegerCollectionEditor editorparent = (IntegerCollectionEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                        {                            
                            editorparent.SelectedCollection.Add(editorparent.SelectedCollection[_SelectedIndex]);
                        }
                    }
                }
            }
        }
    }
}
