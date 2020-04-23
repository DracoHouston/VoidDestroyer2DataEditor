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
    public partial class Vector3DCollectionSidebarEditorItem : UserControl
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
                        if (Parent.Parent is Vector3DCollectionSidebarEditor)
                        {
                            Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                XAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].x.ToString();
                                YAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].y.ToString();
                                ZAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].z.ToString();
                                SummaryLabel.Text = "X: " + XAxisEditor.Text + " Y: " + YAxisEditor.Text + " Z: " + ZAxisEditor.Text;
                            }
                        }
                    }
                }
            }
        }
        public Vector3DCollectionSidebarEditorItem()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.Size = new Size((int)((flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width) * 0.95f), c.Size.Height);
            }
        }

        private void SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.Parent != null)
                {
                    if (Parent.Parent is Vector3DCollectionSidebarEditor)
                    {
                        Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            XAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].x.ToString();
                            YAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].y.ToString();
                            ZAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].z.ToString();
                            SummaryLabel.Text = "X: " + XAxisEditor.Text + " Y: " + YAxisEditor.Text + " Z: " + ZAxisEditor.Text;
                        }
                    }
                }
            }
        }

        private void Vector3DCollectionSidebarEditorItem_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is Vector3DCollectionSidebarEditor)
                        {
                            Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                            editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
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
                    if (idx != SelectedIndex)
                    {
                        if (Parent != null)
                        {
                            if (Parent.Parent != null)
                            {
                                if (Parent.Parent is Vector3DCollectionSidebarEditor)
                                {
                                    Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
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
                        ToggleCollectionsItemModeCollapse();//user is trying to click this to collapse
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
                    ToggleCollectionsItemModeCollapse();
                    return;
                }            
                DoDragDrop(_SelectedIndex, DragDropEffects.Move);
            }
        }

        private void XAxisEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {                
                DoTextToFloatInput(1);
            }
        }

        private void XAxisEditor_Leave(object sender, EventArgs e)
        {
            DoTextToFloatInput(1);
        }

        private void YAxisEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DoTextToFloatInput(2);
            }
        }

        private void YAxisEditor_Leave(object sender, EventArgs e)
        {
            DoTextToFloatInput(2);
        }

        private void ZAxisEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DoTextToFloatInput(3);
            }
        }

        private void ZAxisEditor_Leave(object sender, EventArgs e)
        {
            DoTextToFloatInput(3);
        }

        private void DoTextToFloatInput(byte axis)
        {
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                if (Parent != null)
                {
                    if (Parent.Parent != null)
                    {
                        if (Parent.Parent is Vector3DCollectionSidebarEditor)
                        {
                            Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                            if (_SelectedIndex < editorparent.SelectedCollection.Count)
                            {
                                XAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].x.ToString();
                                YAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].y.ToString();
                                ZAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].z.ToString();
                                SummaryLabel.Text = "X: " + XAxisEditor.Text + " Y: " + YAxisEditor.Text + " Z: " + ZAxisEditor.Text;
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
                    if (Parent.Parent is Vector3DCollectionSidebarEditor)
                    {
                        Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                        if (_SelectedIndex < editorparent.SelectedCollection.Count)
                        {
                            string texttoparse = "";
                            float valuetotest = 0.0f;
                            switch (axis)
                            {
                                case 1:
                                    texttoparse = XAxisEditor.Text;
                                    valuetotest = editorparent.SelectedCollection[_SelectedIndex].x;
                                    break;
                                case 2:
                                    texttoparse = YAxisEditor.Text;
                                    valuetotest = editorparent.SelectedCollection[_SelectedIndex].y;
                                    break;
                                case 3:
                                    texttoparse = ZAxisEditor.Text;
                                    valuetotest = editorparent.SelectedCollection[_SelectedIndex].z;
                                    break;
                            }
                            float parseresult;
                            if (float.TryParse(texttoparse, out parseresult))
                            {

                                if (valuetotest != parseresult)
                                {
                                    editorparent.SelectedCollection.CollectionChanged -= SelectedCollection_CollectionChanged;
                                    switch (axis)
                                    {
                                        case 1:
                                            editorparent.SelectedCollection[_SelectedIndex].x = parseresult;
                                            break;
                                        case 2:
                                            editorparent.SelectedCollection[_SelectedIndex].y = parseresult;
                                            break;
                                        case 3:
                                            editorparent.SelectedCollection[_SelectedIndex].z = parseresult;
                                            break;
                                    }
                                    SummaryLabel.Text = "X: " + XAxisEditor.Text + " Y: " + YAxisEditor.Text + " Z: " + ZAxisEditor.Text;
                                    editorparent.SelectedCollection.CollectionChanged += SelectedCollection_CollectionChanged;
                                }
                            }
                            else
                            {
                                switch (axis)
                                {
                                    case 1:
                                        XAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].x.ToString();
                                        break;
                                    case 2:
                                        YAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].y.ToString();
                                        break;
                                    case 3:
                                        ZAxisEditor.Text = editorparent.SelectedCollection[_SelectedIndex].z.ToString();
                                        break;
                                }
                                SummaryLabel.Text = "X: " + XAxisEditor.Text + " Y: " + YAxisEditor.Text + " Z: " + ZAxisEditor.Text;
                            }
                        }                        
                    }
                }
            }
        }

        public void ToggleCollectionsItemModeCollapse()
        {
            if (SummaryLabel.Visible == true)
            {
                flowLayoutPanel1.Visible = true;
                SummaryLabel.Visible = false;
                Size = new Size(Size.Width, 140);
            }
            else
            {
                flowLayoutPanel1.Visible = false;
                SummaryLabel.Visible = true;
                Size = new Size(Size.Width, 40);
            }
            if (EditorUI.GetParentVD2DataIsReadOnly(this))
            {
                return;
            }
            DoTextToFloatInput(1);
            DoTextToFloatInput(2);
            DoTextToFloatInput(3);
        }

        private void SummaryLabel_MouseClick(object sender, MouseEventArgs e)
        {
            ToggleCollectionsItemModeCollapse();
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
                    if (Parent.Parent is Vector3DCollectionSidebarEditor)
                    {
                        Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
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
                    if (Parent.Parent is Vector3DCollectionSidebarEditor)
                    {
                        Vector3DCollectionSidebarEditor editorparent = (Vector3DCollectionSidebarEditor)Parent.Parent;
                        if ((_SelectedIndex >= 0) && (_SelectedIndex < editorparent.SelectedCollection.Count))
                        {
                            Vector3D vec = new Vector3D(editorparent.SelectedCollection[_SelectedIndex]);
                            editorparent.SelectedCollection.Add(vec);
                        }
                    }
                }
            }
        }
    }
}
