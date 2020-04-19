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
    public partial class StringCollectionSidebarEditor : UserControl
    {
        ObservableCollection<string> _SelectedCollection;

        public ObservableCollection<string> SelectedCollection
        {
            get
            {
                return _SelectedCollection;
            }
            set
            {
                _SelectedCollection = value;
                _SelectedCollection.CollectionChanged += _SelectedCollection_CollectionChanged;
                StringCollectionText.TextChanged -= StringCollectionText_TextChanged;//stop watching the text until done or it will update the collection and mark it unsaved

                StringCollectionText.Lines = _SelectedCollection.ToArray();

                StringCollectionText.TextChanged += StringCollectionText_TextChanged;//resuming patrol
            }
        }

        private void _SelectedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            StringCollectionText.Lines = _SelectedCollection.ToArray();
        }

        public StringCollectionSidebarEditor()
        {
            InitializeComponent();
        }

        private void StringCollectionText_TextChanged(object sender, EventArgs e)
        {
            _SelectedCollection.CollectionChanged -= _SelectedCollection_CollectionChanged;//turn off event handling for this or we will loop through these 2 events forever
            _SelectedCollection.Clear();
            foreach (string line in StringCollectionText.Lines)
            {
                _SelectedCollection.Add(line);//where the hell is addrange for these, microsoft?!
            }
            _SelectedCollection.CollectionChanged += _SelectedCollection_CollectionChanged;//and flip it back on to detect other things changing the collection
        }
    }
}
