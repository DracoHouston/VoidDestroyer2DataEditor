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
    class SkyboxData : VD2Data
    {
        string _objectID;
        string _materialName;

        List<string> _factionType;

        bool _bGeneric;

        [Description("objectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                _objectID = value;
                SetPropertyEdited("objectID", true);
            }
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
                SetPropertyEdited("materialName", true);
            }
        }


        [Description("factionType is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> factionType
        {
            get
            {
                return _factionType;
            }
            set
            {
                _factionType = value;
                SetPropertyEdited("factionType", true);
            }
        }


        [Description("bGeneric is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGeneric
        {
            get
            {
                return _bGeneric;
            }
            set
            {
                _bGeneric = value;
                SetPropertyEdited("bGeneric", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            InitProperty("materialName");

            InitProperty("factionType");

            InitProperty("bGeneric");

        }

        public SkyboxData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                SetPropertyExistsInBaseData("materialName", exists);
                SetPropertyExists("materialName", exists);

                _factionType = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionType", out exists);
                SetPropertyExistsInBaseData("factionType", exists);
                SetPropertyExists("factionType", exists);

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric", out exists);
                SetPropertyExistsInBaseData("bGeneric", exists);
                SetPropertyExists("bGeneric", exists);

            }
        }
    }
}
