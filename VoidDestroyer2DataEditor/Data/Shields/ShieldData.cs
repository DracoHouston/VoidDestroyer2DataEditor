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
    class ShieldData : VD2Data
    {
        string _objectType;
        string _name;
        string _shieldID;
        string _collisionMeshName;
        string _shieldType;
        string _materialName;

        bool _bInvisible;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                _objectType = value;
                SetPropertyEdited("objectType", true);
            }
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SetPropertyEdited("name", true);
            }
        }

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldID
        {
            get
            {
                return _shieldID;
            }
            set
            {
                _shieldID = value;
                SetPropertyEdited("shieldID", true);
            }
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionMeshName
        {
            get
            {
                return _collisionMeshName;
            }
            set
            {
                _collisionMeshName = value;
                SetPropertyEdited("collisionMeshName", true);
            }
        }

        [Description("shieldType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldType
        {
            get
            {
                return _shieldType;
            }
            set
            {
                _shieldType = value;
                SetPropertyEdited("shieldType", true);
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


        [Description("bInvisible is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bInvisible
        {
            get
            {
                return _bInvisible;
            }
            set
            {
                _bInvisible = value;
                SetPropertyEdited("bInvisible", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("shieldID");
            InitProperty("collisionMeshName");
            InitProperty("shieldType");
            InitProperty("materialName");

            InitProperty("bInvisible");

        }

        public ShieldData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                SetPropertyExistsInBaseData("shieldID", exists);
                SetPropertyExists("shieldID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                SetPropertyExistsInBaseData("collisionMeshName", exists);
                SetPropertyExists("collisionMeshName", exists);
                _shieldType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldType", out exists);
                SetPropertyExistsInBaseData("shieldType", exists);
                SetPropertyExists("shieldType", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                SetPropertyExistsInBaseData("materialName", exists);
                SetPropertyExists("materialName", exists);

                _bInvisible = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisible", out exists);
                SetPropertyExistsInBaseData("bInvisible", exists);
                SetPropertyExists("bInvisible", exists);

            }
        }
    }
}
