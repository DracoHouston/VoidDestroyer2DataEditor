using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    class VD2PropertyInfo
    {
        public bool ExistsInBaseData;//whether we can reset to the base data default value, if false this property is only set in mod data
        public bool Exists;//whether the data contains a setter for this property
        public bool EditedByUser;//whether the user has edited this property since loading the file.
        public bool DifferentFromBaseData;//whether the value is different from base data value
        public bool IsObjectID;//whether the value represents the objectID of this data type, and is not a reference to another definition but still requires objectID functionality
        public bool IsObjectIDRef;//whether the value represents an objectID value, and refers to another definition
        public XmlNodeList BaseDataDefaultValue;//the default value of this property, as xml nodes, as it exists in base data, if it does exist in base data.
        public XmlNodeList DefaultValue;//the default value of this property, as xml nodes

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
            
        }
    }

    class VD2Data
    {
        protected string _FilePath;
        protected XmlDocument DataXMLDoc;

        public Dictionary<string, VD2PropertyInfo> VD2PropertyInfos;

        [Description("The path to the ship data file. Used internally by this editor."), Category("Misc")]
        public string FilePath
        {
            get => _FilePath;
            set => _FilePath = value;
        }

        public VD2Data(string inPath)
        {
            _FilePath = inPath;
            VD2PropertyInfos = new Dictionary<string, VD2PropertyInfo>();
            DataXMLDoc = ParseHelpers.SafeLoadVD2DataXMLFile(inPath);
        }

        public void SetPropertyEdited(string inName, bool inEdited)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.EditedByUser = inEdited;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyEdited(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.EditedByUser;
                }
            }
            return result;
        }

        public void SetPropertyExists(string inName, bool inExists)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.Exists = inExists;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExists(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.Exists;
                }
            }
            return result;
        }

        public void SetPropertyExistsInBaseData(string inName, bool inExistsInBaseData)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.ExistsInBaseData = inExistsInBaseData;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExistsInBaseData(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.ExistsInBaseData;
                }
            }
            return result;
        }

        public void UpdatePropertyInfo(string inName, VD2PropertyInfo inInfo)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfos.Remove(inName);
                VD2PropertyInfos.Add(inName, inInfo);
            }
        }
    }
}
