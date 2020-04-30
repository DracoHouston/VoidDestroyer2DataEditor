using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class VD2PropertyInfo
    {
        public bool ExistsInBaseData;//whether we can reset to the base data default value, if false this property is only set in mod data
        public bool Exists;//whether the data contains a setter for this property
        public bool EditedByUser;//whether the user has edited this property since loading the file.
        public bool DifferentFromBaseData;//whether the value is different from base data value
        public bool IsObjectID;//whether the value represents the objectID of this data type, and is not a reference to another definition but still requires objectID functionality
        public bool IsObjectIDRef;//whether the value represents an objectID value, and refers to another definition
        public List<string> ObjectIDRefTypes;//what types of objectID reference is this, if any?
        public bool IsCollection;
        public Type CollectionElementType;
        //public XmlNodeList BaseDataDefaultValue;//the default value of this property, as xml nodes, as it exists in base data, if it does exist in base data.
        //public XmlNodeList DefaultValue;//the default value of this property, as xml nodes

        public bool IsDifferentFromBaseData()
        {
            bool result = false;

            return result;
        }

        public void ResetToBaseDataDefaultValue()
        {

        }

        public void ResetToDefaultValue()
        {

        }

        public VD2PropertyInfo()
        {
            ExistsInBaseData = false;
            Exists = false;
            EditedByUser = false;
            DifferentFromBaseData = false;
            IsObjectID = false;
            IsObjectIDRef = false;
            ObjectIDRefTypes = new List<string>();
            IsCollection = false;
            CollectionElementType = typeof(object);
        }
    }

    public class VD2DataFileOverridenArgs : EventArgs
    {
        public VD2Data OldFile;
        public VD2Data NewFile;
    }

    public class VD2Data : VD2PropertyStore, IVD2DocumentInterface
    {
        protected string _FilePath;
        public XmlDocument DataXMLDoc;
        public VD2FileSource Source;
        public TreeNode FilesTreeNode;
        public FilesTreeItem TreeItem;

        public event EventHandler<VD2DataFileOverridenArgs> OnThisFileOverriden;
        public event EventHandler OnThisFileSaved;
        public event EventHandler OnThisFileLoaded;//called after calling LoadDataFromXML, during constructor and when a file is closed without saving.
        public event EventHandler OnThisFileDeleted;

        [Description("The path to the ship data file. Used internally by this editor."), Category("Misc")]
        public string FilePath
        {
            get => _FilePath;
            set => _FilePath = value;
        }

        public VD2Data(string inPath, VD2FileSource inSource) : base()
        {
            _FilePath = inPath;
            DataXMLDoc = ParseHelpers.SafeLoadVD2DataXMLFile(inPath);
            Source = inSource;
            LoadDataFromXML();
        }

        public virtual void LoadDataFromXML()
        {
            ResetAllPropertyEdited();
            OnThisFileLoaded?.Invoke(this, new EventArgs());
        }

        protected virtual void SaveData()
        {
            
        }

        public bool TrySaveData()
        {
            if (Source != null)
            {
                if (Source.WriteAccess == true)
                {
                    if (Unsaved)
                    {
                        SaveData();
                        ResetAllPropertyEdited();
                        DataXMLDoc = ParseHelpers.SafeLoadVD2DataXMLFile(_FilePath);
                        OnThisFileSaved?.Invoke(this, new EventArgs());
                    }
                    return true;
                }
            }
            return false;
        }

        public virtual string GetObjectID()
        {
            for (int i = 0; i < VD2PropertyInfos.Keys.Count; i++)
            {
                VD2PropertyInfo info;
                if (VD2PropertyInfos.TryGetValue(VD2PropertyInfos.Keys.ElementAt(i), out info))
                {
                    if (info.IsObjectID)
                    {
                        object objvalue = GetType().GetProperty(VD2PropertyInfos.Keys.ElementAt(i)).GetValue(this);
                        if (objvalue is string)
                        {
                            return (string)objvalue;
                        }
                    }
                }
            }
            return "";
        }

        //Ignores read only protections, used to duplicate a file and give it a new object ID regardless of write access for source
        public virtual void SetObjectID(string inObjectID)
        {

        }

        /*public override void SetPropertyEdited(string inName, bool inEdited)
        {
            base.SetPropertyEdited(inName, inEdited);
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    VD2PropertyChangedEventArgs e = new VD2PropertyChangedEventArgs();
                    e.PropertyInfo = info;
                    e.PropertyName = inName;
                    e.NewValue = GetType().GetProperty(inName).GetValue(this);
                    EventHandler<VD2PropertyChangedEventArgs> handler = VD2PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, e);
                    }
                }
            }
            
            
            //if ((FilesTreeNode != null) && (TreeItem != null))
            //{
            //    FilesTreeNode.Text = TreeItem.DisplayName;
            //}
        }*/

        public void NotifyFileOverriden(VD2Data inNewFile)
        {
            VD2DataFileOverridenArgs args = new VD2DataFileOverridenArgs();
            args.OldFile = this;
            args.NewFile = inNewFile;
            OnThisFileOverriden?.Invoke(this, args);
        }

        public void NotifyFileDeleted()
        {            
            OnThisFileDeleted?.Invoke(this, new EventArgs());
        }

        public virtual Control GetDocumentControl()
        {
            DataDocumentControl result = new DataDocumentControl();
            result.DataFile = this;
            result.MainSplitter.Panel1Collapsed = false;
            result.MainSplitter.Panel2Collapsed = true;
            result.SidebarSplitter.Panel1Collapsed = true;
            result.SidebarSplitter.Panel2Collapsed = false;
            result.DataDocProperties.BackColor = EditorUserSettings.UserSettings.CurrentTheme.FrameColor;
            result.DataDocProperties.LineColor = EditorUserSettings.UserSettings.CurrentTheme.SecondaryFrameColor;
            result.DataDocProperties.HelpBackColor = EditorUserSettings.UserSettings.CurrentTheme.SecondaryFrameColor;
            result.DataDocProperties.ViewForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            result.DataDocProperties.HelpForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            result.DataDocProperties.CategoryForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            result.DataDocProperties.ViewBackColor = EditorUserSettings.UserSettings.CurrentTheme.ContentColor;
            result.DataDocProperties.SelectedObject = this;
            result.Dock = DockStyle.Fill;
            result.CollectionsTabs.TabPages.Clear();
            List<System.Reflection.PropertyInfo> props = GetType().GetProperties().ToList();
            bool hascollections = false;
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                Type eletype;
                if (PropertyIsCollection(prop.Name, out eletype))
                {
                    hascollections = true;
                    if (result.MainSplitter.Panel2Collapsed)
                    {
                        result.MainSplitter.Panel2Collapsed = false;
                    }
                    if (eletype == typeof(string))
                    {
                        List<string> reftypes = new List<string>();
                        if (PropertyIsObjectIDRef(prop.Name, out reftypes))//object id ref collection
                        {
                            result.CollectionsTabs.TabPages.Add(prop.Name);
                            ObjectIDRefCollectionSidebarEditor objectidrefeditor = new ObjectIDRefCollectionSidebarEditor();
                            objectidrefeditor.ObjectIDType = reftypes;
                            object val = prop.GetValue(this);
                            if (val is ObservableCollection<string>)
                            {
                                ObservableCollection<string> castedval = (ObservableCollection<string>)val;
                                objectidrefeditor.SelectedCollection = castedval;
                            }
                            objectidrefeditor.Dock = DockStyle.Fill;
                            result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(objectidrefeditor);
                        }
                        else//string collection or finite option collection
                        {

                            result.CollectionsTabs.TabPages.Add(prop.Name);
                            StringCollectionSidebarEditor stringcollectioneditor = new StringCollectionSidebarEditor();
                            object val = prop.GetValue(this);
                            if (val is ObservableCollection<string>)
                            {
                                ObservableCollection<string> castedval = (ObservableCollection<string>)val;
                                stringcollectioneditor.SelectedCollection = castedval;
                            }
                            stringcollectioneditor.Dock = DockStyle.Fill;
                            result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(stringcollectioneditor);
                        }
                    }
                    else if (eletype == typeof(int)) //integer collection
                    {
                        result.CollectionsTabs.TabPages.Add(prop.Name);
                        IntegerCollectionEditor inteditor = new IntegerCollectionEditor();
                        object val = prop.GetValue(this);
                        if (val is ObservableCollection<int>)
                        {
                            ObservableCollection<int> castedval = (ObservableCollection<int>)val;
                            inteditor.SelectedCollection = castedval;
                        }
                        inteditor.Dock = DockStyle.Fill;
                        result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(inteditor);
                    }

                    else if (eletype == typeof(float)) //real number collection
                    {
                        result.CollectionsTabs.TabPages.Add(prop.Name);
                        FloatCollectionSidebarEditor floateditor = new FloatCollectionSidebarEditor();
                        object val = prop.GetValue(this);
                        if (val is ObservableCollection<float>)
                        {
                            ObservableCollection<float> castedval = (ObservableCollection<float>)val;
                            floateditor.SelectedCollection = castedval;
                        }
                        floateditor.Dock = DockStyle.Fill;
                        result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(floateditor);
                    }
                    else if (eletype == typeof(bool)) //boolean collection
                    {

                    }
                    else if (eletype == typeof(Vector3D)) //3d vector collection
                    {
                        result.CollectionsTabs.TabPages.Add(prop.Name);
                        Vector3DCollectionSidebarEditor vector3deditor = new Vector3DCollectionSidebarEditor();
                        object val = prop.GetValue(this);
                        if (val is ObservableCollection<Vector3D>)
                        {
                            ObservableCollection<Vector3D> castedval = (ObservableCollection<Vector3D>)val;
                            vector3deditor.SelectedCollection = castedval;
                        }
                        vector3deditor.Dock = DockStyle.Fill;
                        result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(vector3deditor);
                    }
                    else if (eletype == typeof(ColorF)) //color collection
                    {

                    }
                    else if ((eletype.IsSubclassOf(typeof(VD2DataStructure))) || (eletype == typeof(VD2DataStructure))) //data structure collection
                    {
                        result.CollectionsTabs.TabPages.Add(prop.Name);
                        DataStructureCollectionsEditor dscollectioneditor = new DataStructureCollectionsEditor();
                        dscollectioneditor.ElementType = eletype;
                        object val = prop.GetValue(this);
                        if (val is ObservableCollection<VD2DataStructure>)
                        {
                            ObservableCollection<VD2DataStructure> castedval = (ObservableCollection<VD2DataStructure>)val;
                            dscollectioneditor.SelectedCollection = castedval;
                        }
                        dscollectioneditor.Dock = DockStyle.Fill;
                        result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(dscollectioneditor);
                    }
                }
                else
                {
                    object val = prop.GetValue(this);
                    if (val.GetType().IsSubclassOf(typeof(VD2DataStructure)))
                    {
                        result.CollectionsTabs.TabPages.Add(prop.Name);
                        DataStructureSidebarEditor dsEditor = new DataStructureSidebarEditor();
                        dsEditor.DataStructureEditor.Item = (VD2DataStructure)val;
                        dsEditor.Dock = DockStyle.Fill;
                        result.CollectionsTabs.TabPages[result.CollectionsTabs.TabPages.Count - 1].Controls.Add(dsEditor);
                        hascollections = true;
                    }
                }
            }
            if (!hascollections)
            {
                result.SidebarSplitter.Panel2Collapsed = true;
            }
            else
            {
                result.SidebarSplitter.Panel2Collapsed = false;
                result.MainSplitter.Panel2Collapsed = false;
            }
            return result;
        }

        public virtual string GetDocumentTitle()
        {
            string savestring = "";
            if (Unsaved)
            {
                savestring = "*";
            }

            string rwstring = "";
            string sourcestring = "";

            if (Source != null)
            {
                sourcestring = Source.ShortName;
                if (Source.WriteAccess)
                {
                    rwstring = "[RW]";
                }
                else
                {
                    rwstring = "[R]";
                }
            }
            string filename = System.IO.Path.GetFileNameWithoutExtension(_FilePath);
            return "(" + sourcestring + rwstring + ") " + savestring + filename + "     ";
        }

        public virtual string GetDocumentIconKey()
        {
            return "genericfileicon";
        }
    }

    public class ObjectIDRefTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {            
            return false;
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> stdvals = new List<string>();
            if (context.Instance != null)
            {
                if (context.Instance is VD2PropertyStore)
                {
                    VD2PropertyStore datainstance = (VD2PropertyStore)context.Instance;
                    List<string> reftypes;
                    if (datainstance.PropertyIsObjectIDRef(context.PropertyDescriptor.Name, out reftypes))
                    {
                        foreach (string reftype in reftypes)
                        {
                            stdvals.AddRange(EditorUI.UI.GetObjectIDListForType(reftype));
                        }
                    }                    
                }                
            }
            return new StandardValuesCollection(stdvals);
        }
    }
}
