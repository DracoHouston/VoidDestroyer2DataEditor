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
    public partial class DataStructureSidebarItemView : UserControl
    {
        object _Item;
        

        private PropertyGrid DataStructurePropertiesEditor = null;
        public  object Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;                

                flowLayoutPanel1.Controls.Clear();
                if (_Item != null)
                {
                    SummaryLabel.Text = _Item.ToString();
                    List<System.Reflection.PropertyInfo> props = _Item.GetType().GetProperties().ToList();
                    bool hassimpleprops = false;
                    bool hascollections = false;
                    List<Control> collectioneditors = new List<Control>();
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        if (!(prop.PropertyType.GetInterface(nameof(System.Collections.ICollection)) != null))
                        {
                            bool isbrowsableattr = true;
                            foreach (var attr in prop.CustomAttributes)
                            {
                                if (attr.AttributeType == typeof(BrowsableAttribute))
                                {
                                    foreach (var attrarg in attr.ConstructorArguments)
                                    {
                                        if (attrarg.Value is bool)
                                        {
                                            if (!(bool)attrarg.Value)
                                            {
                                                isbrowsableattr = false;
                                            }
                                        }
                                    }
                                }
                            }
                            if (isbrowsableattr)
                            {
                                hassimpleprops = true;
                            }
                        }
                        else
                        {
                            hascollections = true;
                            if (_Item is VD2DataStructure)
                            {
                                VD2DataStructure dsitem = (VD2DataStructure)_Item;                                
                                List<Type> generictypes = prop.PropertyType.GetGenericArguments().ToList();
                                if (generictypes.Count == 1)//we dont "do" dictionary editors. collections only.
                                {
                                    if (generictypes[0] == typeof(string))
                                    {
                                        List<string> reftypes = new List<string>();
                                        if (dsitem.PropertyIsObjectIDRef(prop.Name, out reftypes))
                                        {
                                            object o = prop.GetValue(_Item);
                                            if (o is System.Collections.ObjectModel.ObservableCollection<string>)
                                            {
                                                ObjectIDRefCollectionSidebarEditor objidrefed = new ObjectIDRefCollectionSidebarEditor();
                                                System.Collections.ObjectModel.ObservableCollection<string> szcollectionprop = (System.Collections.ObjectModel.ObservableCollection<string>)o;
                                                objidrefed.ObjectIDType = reftypes;
                                                objidrefed.SelectedCollection = szcollectionprop;
                                                collectioneditors.Add(objidrefed);
                                            }
                                        }
                                        else
                                        {

                                            object o = prop.GetValue(_Item);
                                            if (o is System.Collections.ObjectModel.ObservableCollection<string>)
                                            {
                                                StringCollectionSidebarEditor szed = new StringCollectionSidebarEditor();
                                                System.Collections.ObjectModel.ObservableCollection<string> szcollectionprop = (System.Collections.ObjectModel.ObservableCollection<string>)o;
                                                szed.SelectedCollection = szcollectionprop;
                                                collectioneditors.Add(szed);
                                            }

                                            // collectioneditors.Last()
                                        }
                                    }
                                    else if ((generictypes[0] == (typeof(VD2DataStructure))) || (generictypes[0].IsSubclassOf(typeof(VD2DataStructure))))
                                    {
                                        object o = prop.GetValue(_Item);
                                        if (o is System.Collections.ObjectModel.ObservableCollection<VD2DataStructure>)
                                        {
                                            DataStructureCollectionsEditor dsed = new DataStructureCollectionsEditor();
                                            System.Collections.ObjectModel.ObservableCollection<VD2DataStructure> dscollectionprop = (System.Collections.ObjectModel.ObservableCollection<VD2DataStructure>)o;
                                            Type eletype;
                                            dsitem.PropertyIsCollection(prop.Name, out eletype);
                                            dsed.ElementType = eletype;
                                            dsed.SelectedCollection = dscollectionprop;
                                            collectioneditors.Add(dsed);
                                        }
                                    }
                                    else if (generictypes[0] == typeof(int))
                                    {
                                        object o = prop.GetValue(_Item);
                                        if (o is System.Collections.ObjectModel.ObservableCollection<int>)
                                        {
                                            IntegerCollectionEditor inted = new IntegerCollectionEditor();
                                            System.Collections.ObjectModel.ObservableCollection<int> intcollectionprop = (System.Collections.ObjectModel.ObservableCollection<int>)o;
                                            inted.SelectedCollection = intcollectionprop;
                                            collectioneditors.Add(inted);
                                        }
                                    }
                                    else if (generictypes[0] == typeof(float))
                                    {
                                        object o = prop.GetValue(_Item);
                                        if (o is System.Collections.ObjectModel.ObservableCollection<float>)
                                        {
                                            FloatCollectionSidebarEditor floated = new FloatCollectionSidebarEditor();
                                            System.Collections.ObjectModel.ObservableCollection<float> floatcollectionprop = (System.Collections.ObjectModel.ObservableCollection<float>)o;
                                            floated.SelectedCollection = floatcollectionprop;
                                            collectioneditors.Add(floated);
                                        }
                                    }
                                    else if (generictypes[0] == typeof(Vector3D))
                                    {
                                        object o = prop.GetValue(_Item);
                                        if (o is System.Collections.ObjectModel.ObservableCollection<Vector3D>)
                                        {
                                            Vector3DCollectionSidebarEditor veced = new Vector3DCollectionSidebarEditor();
                                            System.Collections.ObjectModel.ObservableCollection<Vector3D> veccollectionprop = (System.Collections.ObjectModel.ObservableCollection<Vector3D>)o;
                                            veced.SelectedCollection = veccollectionprop;
                                            collectioneditors.Add(veced);
                                        }
                                    }
                                }
                            }
                            //collectioneditors.Add()
                        }
                    }
                    if (hassimpleprops)
                    {
                        if (DataStructurePropertiesEditor == null)
                        {
                            DataStructurePropertiesEditor = new PropertyGrid();
                        }
                        DataStructurePropertiesEditor.SelectedObject = _Item;
                        int h = 200;
                        if (!hascollections)
                        {
                            if (flowLayoutPanel1.Parent != null)
                            {
                                if (flowLayoutPanel1.Parent == this)
                                {
                                    Controls.Remove(flowLayoutPanel1);
                                }
                            }
                            if (DataStructurePropertiesEditor.Parent == null)
                            {
                                DataStructurePropertiesEditor.Dock = DockStyle.Fill;
                                Controls.Add(DataStructurePropertiesEditor);
                            }
                            
                        }
                        else
                        {
                            DataStructurePropertiesEditor.Size = new Size(flowLayoutPanel1.Size.Width, h);
                            if (DataStructurePropertiesEditor.Parent == null)
                            {
                                DataStructurePropertiesEditor.Dock = DockStyle.None;
                                flowLayoutPanel1.Controls.Add(DataStructurePropertiesEditor);
                            }
                            else if (DataStructurePropertiesEditor.Parent != flowLayoutPanel1)
                            {
                                DataStructurePropertiesEditor.Parent.Controls.Remove(DataStructurePropertiesEditor);
                                DataStructurePropertiesEditor.Dock = DockStyle.None;
                                flowLayoutPanel1.Controls.Add(DataStructurePropertiesEditor);
                            }
                        }
                        
                    }
                    else
                    {
                        DataStructurePropertiesEditor = null;
                    }
                    if (hascollections)
                    {
                        if (!hassimpleprops)
                        {
                            if (collectioneditors.Count == 1)
                            {
                                if (Parent != null)
                                {
                                    if (Parent is DataStructureSidebarEditor)
                                    {
                                        Parent.Padding = new Padding(0);
                                    }
                                }
                                //Padding = new Padding(0);
                                Controls.Remove(flowLayoutPanel1);
                                collectioneditors[0].Dock = DockStyle.Fill;
                                Controls.Add(collectioneditors[0]);
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.AddRange(collectioneditors.ToArray());
                            }
                        }
                        else
                        {
                            flowLayoutPanel1.Controls.AddRange(collectioneditors.ToArray());
                        }
                        
                    }
                }
            }
        }
        public DataStructureSidebarItemView()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.Size = new Size((int)((flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Size.Width) * 0.95f), c.Height);
            }
        }

        private void DataStructureSidebarItemView_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Control c = this;
                while (c.Parent != null)
                {
                    if (c.Parent is SidebarCollectionsEditorItem)
                    {
                        flowLayoutPanel1.Visible = false;
                        SummaryLabel.Visible = true;
                        c.Parent.Size = new Size(c.Parent.Size.Width, 50);
                        break;
                    }
                    c = c.Parent;
                }
            }
        }

        public void ToggleCollectionsItemModeCollapse()
        {
            if (SummaryLabel.Visible == true)
            {
                flowLayoutPanel1.Visible = true;
                SummaryLabel.Visible = false;
                Control c = this;
                while (c.Parent != null)
                {
                    if (c.Parent is SidebarCollectionsEditorItem)
                    {
                        c.Parent.Size = new Size(c.Parent.Size.Width, 350);
                        break;
                    }
                    c = c.Parent;
                }
            }
            else
            {
                flowLayoutPanel1.Visible = false;
                SummaryLabel.Visible = true;
                Control c = this;
                while (c.Parent != null)
                {
                    if (c.Parent is SidebarCollectionsEditorItem)
                    {
                        c.Parent.Size = new Size(c.Parent.Size.Width, 50);
                        break;
                    }
                    c = c.Parent;
                }
            }
        }

        private void SummaryLabel_MouseClick(object sender, MouseEventArgs e)
        {
            ToggleCollectionsItemModeCollapse();
        }
    }
}
