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
    public partial class FloatCollectionSidebarEditorItem : UserControl
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
                        if (Parent.Parent is FloatCollectionSidebarEditor)
                        {
                            FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                FloatEditor.Text = editorparent.SelectedCollection[_SelectedIndex].ToString();
                            }
                        }
                    }
                }
            }
        }
        public FloatCollectionSidebarEditorItem()
        {
            InitializeComponent();
        }

        private void FloatCollectionSidebarEditorItem_Resize(object sender, EventArgs e)
        {
            FloatEditor.Size = new Size((int)((Size.Width - (Margin.Size.Width * 2)) * 0.95f), FloatEditor.Size.Height);
        }

        private void SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is FloatCollectionSidebarEditor)
                    {
                        FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            FloatEditor.Text = editorparent.SelectedCollection[_SelectedIndex].ToString();
                        }
                    }
                }
            }
        }



       

        private void FloatCollectionSidebarEditorItem_Load(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is FloatCollectionSidebarEditor)
                    {
                        FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
                        editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                    }
                }
            }
        }

        private void OnDragDropped(object sender, DragEventArgs e)
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
                            if (Parent.Parent is FloatCollectionSidebarEditor)
                            {
                                FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
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

        private void FloatEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DoTextToFloatInput();
            }
        }

        private void FloatEditor_Leave(object sender, EventArgs e)
        {
            DoTextToFloatInput();
        }

        private void DoTextToFloatInput()
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is FloatCollectionSidebarEditor)
                        {
                            FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                FloatEditor.Text = editorparent.SelectedCollection[_SelectedIndex].ToString();
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
                    if (Parent.Parent is FloatCollectionSidebarEditor)
                    {
                        FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
                        float parseresult;
                        if (float.TryParse(FloatEditor.Text, out parseresult))
                        {
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                if (editorparent.SelectedCollection[_SelectedIndex] != parseresult)
                                {
                                    editorparent.SelectedCollection.CollectionChanged -= SelectedCollection_CollectionChanged;
                                    editorparent.SelectedCollection[_SelectedIndex] = parseresult;
                                    editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                                }
                            }
                        }
                        else
                        {
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                FloatEditor.Text = editorparent.SelectedCollection[_SelectedIndex].ToString();
                            }
                        }
                    }
                }
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
                    if (Parent.Parent is FloatCollectionSidebarEditor)
                    {
                        FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
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
                    if (Parent.Parent is FloatCollectionSidebarEditor)
                    {
                        FloatCollectionSidebarEditor editorparent = (FloatCollectionSidebarEditor)Parent.Parent;
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
