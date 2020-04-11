using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class ObjectIDRefCollectionSidebarEditor : UserControl
    {
        ObservableCollection<string> _SelectedCollection;
        List<string> _ObjectIDType;
        public List<string> ObjectIDType
        {
            get
            {
                return _ObjectIDType;
            }
            set
            {
                _ObjectIDType = value;
            }
        }

        public ObservableCollection<string> SelectedCollection
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
                    ObjectIDRefCollectionSidebarEditorItem editoritem = new ObjectIDRefCollectionSidebarEditorItem();
                    flowLayoutPanel1.Controls.Add(editoritem);
                    editoritem.SelectedIndex = i;
                    editoritem.ObjectIDType = _ObjectIDType;
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
                    ObjectIDRefCollectionSidebarEditorItem editoritem = new ObjectIDRefCollectionSidebarEditorItem();
                    flowLayoutPanel1.Controls.Add(editoritem);
                    editoritem.SelectedIndex = i;
                    editoritem.ObjectIDType = _ObjectIDType;
                    editoritem.Size = new Size(flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width, editoritem.Size.Height);
                }
            }
        }

        public ObjectIDRefCollectionSidebarEditor()
        {
            _ObjectIDType = new List<string>();
            InitializeComponent();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                c.Size = new Size(flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width, c.Size.Height);
            }
        }

        private void ClearCollectionButton_Click(object sender, EventArgs e)
        {
            if (_SelectedCollection != null)
            {
                _SelectedCollection.Clear();
            }
        }

        private void AddToCollectionButton_Click(object sender, EventArgs e)
        {
            if (_SelectedCollection != null)
            {
                _SelectedCollection.Add("");
            }
        }
    }
}
