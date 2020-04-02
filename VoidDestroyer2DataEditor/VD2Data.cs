﻿using System;
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
        }
    }

    public class VD2Data : VD2PropertyStore
    {
        protected string _FilePath;
        public XmlDocument DataXMLDoc;
        public VD2FileSource Source;
        public TreeNode FilesTreeNode;
        public FilesTreeItem TreeItem;

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
            if ((FilesTreeNode != null) && (TreeItem != null))
            {
                FilesTreeNode.Text = TreeItem.DisplayName;
            }
        }
    }
}
