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
    class CharacterData : VD2Data
    {
        string _displayName;
        string _characterID;
        string _imageSetName;
        string _textColor;
        string _title;
        string _physicalObjectType;

        List<string> _factionID;

        bool _bGeneric;

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
                SetPropertyEdited("displayName", true);
            }
        }

        [Description("characterID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string characterID
        {
            get
            {
                return _characterID;
            }
            set
            {
                _characterID = value;
                SetPropertyEdited("characterID", true);
            }
        }

        [Description("imageSetName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string imageSetName
        {
            get
            {
                return _imageSetName;
            }
            set
            {
                _imageSetName = value;
                SetPropertyEdited("imageSetName", true);
            }
        }

        [Description("textColor is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string textColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                SetPropertyEdited("textColor", true);
            }
        }

        [Description("title is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                SetPropertyEdited("title", true);
            }
        }

        [Description("physicalObjectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string physicalObjectType
        {
            get
            {
                return _physicalObjectType;
            }
            set
            {
                _physicalObjectType = value;
                SetPropertyEdited("physicalObjectType", true);
            }
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> factionID
        {
            get
            {
                return _factionID;
            }
            set
            {
                _factionID = value;
                SetPropertyEdited("factionID", true);
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
            InitProperty("displayName");
            InitProperty("characterID");
            InitProperty("imageSetName");
            InitProperty("textColor");
            InitProperty("title");
            InitProperty("physicalObjectType");

            InitProperty("factionID");

            InitProperty("bGeneric");

        }

        public CharacterData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                SetPropertyExistsInBaseData("displayName", exists);
                SetPropertyExists("displayName", exists);
                _characterID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "characterID", out exists);
                SetPropertyExistsInBaseData("characterID", exists);
                SetPropertyExists("characterID", exists);
                _imageSetName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSetName", out exists);
                SetPropertyExistsInBaseData("imageSetName", exists);
                SetPropertyExists("imageSetName", exists);
                _textColor = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "textColor", out exists);
                SetPropertyExistsInBaseData("textColor", exists);
                SetPropertyExists("textColor", exists);
                _title = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "title", out exists);
                SetPropertyExistsInBaseData("title", exists);
                SetPropertyExists("title", exists);
                _physicalObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "physicalObjectType", out exists);
                SetPropertyExistsInBaseData("physicalObjectType", exists);
                SetPropertyExists("physicalObjectType", exists);

                _factionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists);
                SetPropertyExistsInBaseData("factionID", exists);
                SetPropertyExists("factionID", exists);

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric", out exists);
                SetPropertyExistsInBaseData("bGeneric", exists);
                SetPropertyExists("bGeneric", exists);

            }
        }
    }
}
