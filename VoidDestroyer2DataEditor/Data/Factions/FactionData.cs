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
    class FactionData : VD2Data
    {
        string _factionID;
        string _factionType;
        string _factionName;
        string _factionPluralName;
        string _tacticalMaterial;
        string _selectedTacticalMaterial;
        string _buildTacticalMaterial;
        string _bareBonesMaterialName;
        string _factionIconText;
        string _factionSkyBoxMaterialName;
        string _factionBaseMusic;
        string _instantEditorText;
        string _sellShipFactionID;
        string _buildShipFactionID;
        string _portraitFactionID;

        List<string> _descriptionText;
        List<string> _spawnShipFactionID;

        bool _bFactionShipRequiredForMission;
        bool _bNoShow;
        bool _bCommsEnabled;
        bool _bHUDCommsEnabled;
        bool _bGenericCommsOverride;
        bool _bPirate;

        ColorF _wireframeColor;
        ColorF _highlightOutlineColor;
        ColorF _textColor;
        ColorF _backgroundColor;
        ColorF _cloudsColor;

        [Description("factionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionID
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

        [Description("factionType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionType
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

        [Description("factionName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionName
        {
            get
            {
                return _factionName;
            }
            set
            {
                _factionName = value;
                SetPropertyEdited("factionName", true);
            }
        }

        [Description("factionPluralName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionPluralName
        {
            get
            {
                return _factionPluralName;
            }
            set
            {
                _factionPluralName = value;
                SetPropertyEdited("factionPluralName", true);
            }
        }

        [Description("tacticalMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tacticalMaterial
        {
            get
            {
                return _tacticalMaterial;
            }
            set
            {
                _tacticalMaterial = value;
                SetPropertyEdited("tacticalMaterial", true);
            }
        }

        [Description("selectedTacticalMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string selectedTacticalMaterial
        {
            get
            {
                return _selectedTacticalMaterial;
            }
            set
            {
                _selectedTacticalMaterial = value;
                SetPropertyEdited("selectedTacticalMaterial", true);
            }
        }

        [Description("buildTacticalMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string buildTacticalMaterial
        {
            get
            {
                return _buildTacticalMaterial;
            }
            set
            {
                _buildTacticalMaterial = value;
                SetPropertyEdited("buildTacticalMaterial", true);
            }
        }

        [Description("bareBonesMaterialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string bareBonesMaterialName
        {
            get
            {
                return _bareBonesMaterialName;
            }
            set
            {
                _bareBonesMaterialName = value;
                SetPropertyEdited("bareBonesMaterialName", true);
            }
        }

        [Description("factionIconText is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionIconText
        {
            get
            {
                return _factionIconText;
            }
            set
            {
                _factionIconText = value;
                SetPropertyEdited("factionIconText", true);
            }
        }

        [Description("factionSkyBoxMaterialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionSkyBoxMaterialName
        {
            get
            {
                return _factionSkyBoxMaterialName;
            }
            set
            {
                _factionSkyBoxMaterialName = value;
                SetPropertyEdited("factionSkyBoxMaterialName", true);
            }
        }

        [Description("factionBaseMusic is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string factionBaseMusic
        {
            get
            {
                return _factionBaseMusic;
            }
            set
            {
                _factionBaseMusic = value;
                SetPropertyEdited("factionBaseMusic", true);
            }
        }

        [Description("instantEditorText is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string instantEditorText
        {
            get
            {
                return _instantEditorText;
            }
            set
            {
                _instantEditorText = value;
                SetPropertyEdited("instantEditorText", true);
            }
        }

        [Description("sellShipFactionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sellShipFactionID
        {
            get
            {
                return _sellShipFactionID;
            }
            set
            {
                _sellShipFactionID = value;
                SetPropertyEdited("sellShipFactionID", true);
            }
        }

        [Description("buildShipFactionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string buildShipFactionID
        {
            get
            {
                return _buildShipFactionID;
            }
            set
            {
                _buildShipFactionID = value;
                SetPropertyEdited("buildShipFactionID", true);
            }
        }

        [Description("portraitFactionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string portraitFactionID
        {
            get
            {
                return _portraitFactionID;
            }
            set
            {
                _portraitFactionID = value;
                SetPropertyEdited("portraitFactionID", true);
            }
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                _descriptionText = value;
                SetPropertyEdited("descriptionText", true);
            }
        }

        [Description("spawnShipFactionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> spawnShipFactionID
        {
            get
            {
                return _spawnShipFactionID;
            }
            set
            {
                _spawnShipFactionID = value;
                SetPropertyEdited("spawnShipFactionID", true);
            }
        }


        [Description("bFactionShipRequiredForMission is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFactionShipRequiredForMission
        {
            get
            {
                return _bFactionShipRequiredForMission;
            }
            set
            {
                _bFactionShipRequiredForMission = value;
                SetPropertyEdited("bFactionShipRequiredForMission", true);
            }
        }

        [Description("bNoShow is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoShow
        {
            get
            {
                return _bNoShow;
            }
            set
            {
                _bNoShow = value;
                SetPropertyEdited("bNoShow", true);
            }
        }

        [Description("bCommsEnabled is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommsEnabled
        {
            get
            {
                return _bCommsEnabled;
            }
            set
            {
                _bCommsEnabled = value;
                SetPropertyEdited("bCommsEnabled", true);
            }
        }

        [Description("bHUDCommsEnabled is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHUDCommsEnabled
        {
            get
            {
                return _bHUDCommsEnabled;
            }
            set
            {
                _bHUDCommsEnabled = value;
                SetPropertyEdited("bHUDCommsEnabled", true);
            }
        }

        [Description("bGenericCommsOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGenericCommsOverride
        {
            get
            {
                return _bGenericCommsOverride;
            }
            set
            {
                _bGenericCommsOverride = value;
                SetPropertyEdited("bGenericCommsOverride", true);
            }
        }

        [Description("bPirate is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPirate
        {
            get
            {
                return _bPirate;
            }
            set
            {
                _bPirate = value;
                SetPropertyEdited("bPirate", true);
            }
        }


        [Description("wireframeColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF wireframeColor
        {
            get
            {
                return _wireframeColor;
            }
            set
            {
                _wireframeColor = value;
                SetPropertyEdited("wireframeColor", true);
            }
        }

        [Description("highlightOutlineColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF highlightOutlineColor
        {
            get
            {
                return _highlightOutlineColor;
            }
            set
            {
                _highlightOutlineColor = value;
                SetPropertyEdited("highlightOutlineColor", true);
            }
        }

        [Description("textColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF textColor
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

        [Description("backgroundColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF backgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                SetPropertyEdited("backgroundColor", true);
            }
        }

        [Description("cloudsColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF cloudsColor
        {
            get
            {
                return _cloudsColor;
            }
            set
            {
                _cloudsColor = value;
                SetPropertyEdited("cloudsColor", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("factionID");
            InitProperty("factionType");
            InitProperty("factionName");
            InitProperty("factionPluralName");
            InitProperty("tacticalMaterial");
            InitProperty("selectedTacticalMaterial");
            InitProperty("buildTacticalMaterial");
            InitProperty("bareBonesMaterialName");
            InitProperty("factionIconText");
            InitProperty("factionSkyBoxMaterialName");
            InitProperty("factionBaseMusic");
            InitProperty("instantEditorText");
            InitProperty("sellShipFactionID");
            InitProperty("buildShipFactionID");
            InitProperty("portraitFactionID");

            InitProperty("descriptionText");
            InitProperty("spawnShipFactionID");

            InitProperty("bFactionShipRequiredForMission");
            InitProperty("bNoShow");
            InitProperty("bCommsEnabled");
            InitProperty("bHUDCommsEnabled");
            InitProperty("bGenericCommsOverride");
            InitProperty("bPirate");

            InitProperty("wireframeColor");
            InitProperty("highlightOutlineColor");
            InitProperty("textColor");
            InitProperty("backgroundColor");
            InitProperty("cloudsColor");

        }

        public FactionData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _factionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionID", out exists);
                SetPropertyExistsInBaseData("factionID", exists);
                SetPropertyExists("factionID", exists);
                _factionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionType", out exists);
                SetPropertyExistsInBaseData("factionType", exists);
                SetPropertyExists("factionType", exists);
                _factionName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionName", out exists);
                SetPropertyExistsInBaseData("factionName", exists);
                SetPropertyExists("factionName", exists);
                _factionPluralName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionPluralName", out exists);
                SetPropertyExistsInBaseData("factionPluralName", exists);
                SetPropertyExists("factionPluralName", exists);
                _tacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalMaterial", out exists);
                SetPropertyExistsInBaseData("tacticalMaterial", exists);
                SetPropertyExists("tacticalMaterial", exists);
                _selectedTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selectedTacticalMaterial", out exists);
                SetPropertyExistsInBaseData("selectedTacticalMaterial", exists);
                SetPropertyExists("selectedTacticalMaterial", exists);
                _buildTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildTacticalMaterial", out exists);
                SetPropertyExistsInBaseData("buildTacticalMaterial", exists);
                SetPropertyExists("buildTacticalMaterial", exists);
                _bareBonesMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "bareBonesMaterialName", out exists);
                SetPropertyExistsInBaseData("bareBonesMaterialName", exists);
                SetPropertyExists("bareBonesMaterialName", exists);
                _factionIconText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionIconText", out exists);
                SetPropertyExistsInBaseData("factionIconText", exists);
                SetPropertyExists("factionIconText", exists);
                _factionSkyBoxMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionSkyBoxMaterialName", out exists);
                SetPropertyExistsInBaseData("factionSkyBoxMaterialName", exists);
                SetPropertyExists("factionSkyBoxMaterialName", exists);
                _factionBaseMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionBaseMusic", out exists);
                SetPropertyExistsInBaseData("factionBaseMusic", exists);
                SetPropertyExists("factionBaseMusic", exists);
                _instantEditorText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantEditorText", out exists);
                SetPropertyExistsInBaseData("instantEditorText", exists);
                SetPropertyExists("instantEditorText", exists);
                _sellShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sellShipFactionID", out exists);
                SetPropertyExistsInBaseData("sellShipFactionID", exists);
                SetPropertyExists("sellShipFactionID", exists);
                _buildShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildShipFactionID", out exists);
                SetPropertyExistsInBaseData("buildShipFactionID", exists);
                SetPropertyExists("buildShipFactionID", exists);
                _portraitFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "portraitFactionID", out exists);
                SetPropertyExistsInBaseData("portraitFactionID", exists);
                SetPropertyExists("portraitFactionID", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);
                _spawnShipFactionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "spawnShipFactionID", out exists);
                SetPropertyExistsInBaseData("spawnShipFactionID", exists);
                SetPropertyExists("spawnShipFactionID", exists);

                _bFactionShipRequiredForMission = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFactionShipRequiredForMission", out exists);
                SetPropertyExistsInBaseData("bFactionShipRequiredForMission", exists);
                SetPropertyExists("bFactionShipRequiredForMission", exists);
                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow", out exists);
                SetPropertyExistsInBaseData("bNoShow", exists);
                SetPropertyExists("bNoShow", exists);
                _bCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsEnabled", out exists);
                SetPropertyExistsInBaseData("bCommsEnabled", exists);
                SetPropertyExists("bCommsEnabled", exists);
                _bHUDCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHUDCommsEnabled", out exists);
                SetPropertyExistsInBaseData("bHUDCommsEnabled", exists);
                SetPropertyExists("bHUDCommsEnabled", exists);
                _bGenericCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGenericCommsOverride", out exists);
                SetPropertyExistsInBaseData("bGenericCommsOverride", exists);
                SetPropertyExists("bGenericCommsOverride", exists);
                _bPirate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPirate", out exists);
                SetPropertyExistsInBaseData("bPirate", exists);
                SetPropertyExists("bPirate", exists);

                _wireframeColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "wireframeColor", out exists);
                SetPropertyExistsInBaseData("wireframeColor", exists);
                SetPropertyExists("wireframeColor", exists);
                _highlightOutlineColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "highlightOutlineColor", out exists);
                SetPropertyExistsInBaseData("highlightOutlineColor", exists);
                SetPropertyExists("highlightOutlineColor", exists);
                _textColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "textColor", out exists);
                SetPropertyExistsInBaseData("textColor", exists);
                SetPropertyExists("textColor", exists);
                _backgroundColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "backgroundColor", out exists);
                SetPropertyExistsInBaseData("backgroundColor", exists);
                SetPropertyExists("backgroundColor", exists);
                _cloudsColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "cloudsColor", out exists);
                SetPropertyExistsInBaseData("cloudsColor", exists);
                SetPropertyExists("cloudsColor", exists);

            }
        }
    }
}
