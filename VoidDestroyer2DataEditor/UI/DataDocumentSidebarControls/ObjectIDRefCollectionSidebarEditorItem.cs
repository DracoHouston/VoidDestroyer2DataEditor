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
    public partial class ObjectIDRefCollectionSidebarEditorItem : UserControl
    {
        List<string> _ObjectIDType;
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
                                ObjectIDEditor.Text = editorparent.SelectedCollection[_SelectedIndex];
                            }
                        }
                    }
                }
            }
        }

        public List<string> ObjectIDType
        {
            get
            {
                return _ObjectIDType;
            }
            set
            {
                _ObjectIDType = value;
                
                ObjectIDEditor.Items.Clear();
                
                string text = "";
                foreach (string sz in _ObjectIDType)
                {
                    ObjectIDEditor.Items.AddRange(EditorUI.UI.GetObjectIDListForType(sz).ToArray());
                    text += sz + ", ";
                }
                if (text.Length > 0)
                {
                    text = text.Substring(0, text.Length - 2);
                }
                TypeText.Text = text;
            }
        }
        public ObjectIDRefCollectionSidebarEditorItem()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            ObjectIDEditor.Size = new Size((int)((flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width) * 0.95f), ObjectIDEditor.Size.Height);
        }

        private void ObjectIDEditor_TextChanged(object sender, EventArgs e)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                        {
                            ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                if (editorparent.SelectedCollection[_SelectedIndex] != ObjectIDEditor.Text)
                                {
                                    ObjectIDEditor.TextChanged -= ObjectIDEditor_TextChanged;//dont wanna stack overflow, mates. 
                                    ObjectIDEditor.Text = editorparent.SelectedCollection[_SelectedIndex];
                                    ObjectIDEditor.TextChanged += ObjectIDEditor_TextChanged;
                                }
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
                    if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                    {
                        ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            if (editorparent.SelectedCollection[_SelectedIndex] != ObjectIDEditor.Text)
                            {
                                editorparent.SelectedCollection[_SelectedIndex] = ObjectIDEditor.Text;
                            }
                        }
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
                            if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                            {
                                ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
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

        private void ObjectIDRefCollectionSidebarEditorItem_Load(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                    {
                        ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                        editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                    }
                }
            }
        }

        private void SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                    {
                        ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            ObjectIDEditor.Text = editorparent.SelectedCollection[_SelectedIndex];
                        }
                    }
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                    if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                    {
                        ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                        {
                            editorparent.SelectedCollection.Add(editorparent.SelectedCollection[_SelectedIndex]);
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
                    if (Parent.Parent is ObjectIDRefCollectionSidebarEditor)
                    {
                        ObjectIDRefCollectionSidebarEditor editorparent = (ObjectIDRefCollectionSidebarEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                        {
                            editorparent.SelectedCollection.RemoveAt(_SelectedIndex);
                        }
                    }
                }
            }
        }
    }
}
