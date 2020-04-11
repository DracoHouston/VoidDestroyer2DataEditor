using System;
using System.Collections.Generic;
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

    public class VD2Data : VD2PropertyStore, IVD2DocumentInterface
    {
        protected string _FilePath;
        public XmlDocument DataXMLDoc;
        public VD2FileSource Source;
        public TreeNode FilesTreeNode;
        public FilesTreeItem TreeItem;

        public event EventHandler<VD2PropertyChangedEventArgs> VD2PropertyChanged;

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
        }

        public virtual void SaveData()
        {
            
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

        public override void SetPropertyEdited(string inName, bool inEdited)
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
        }
        public virtual Control GetDocumentControl()
        {
            DataDocumentControl result = new DataDocumentControl();
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
}
