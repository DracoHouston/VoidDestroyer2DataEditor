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

        int _wireframeColor;
        int _highlightOutlineColor;
        int _textColor;

        List<int> _cloudsColor;

        bool _bFactionShipRequiredForMission;
        bool _bNoShow;
        bool _bCommsEnabled;
        bool _bHUDCommsEnabled;
        bool _bGenericCommsOverride;
        bool _bPirate;

        List<bool> _backgroundColor;

        [Description("factionID is a plaintext string"), Category("Plaintext Strings")]
        public string factionID
        {
            get => _factionID;
            set => _factionID = value;
        }

        [Description("factionType is a plaintext string"), Category("Plaintext Strings")]
        public string factionType
        {
            get => _factionType;
            set => _factionType = value;
        }

        [Description("factionName is a plaintext string"), Category("Plaintext Strings")]
        public string factionName
        {
            get => _factionName;
            set => _factionName = value;
        }

        [Description("factionPluralName is a plaintext string"), Category("Plaintext Strings")]
        public string factionPluralName
        {
            get => _factionPluralName;
            set => _factionPluralName = value;
        }

        [Description("tacticalMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string tacticalMaterial
        {
            get => _tacticalMaterial;
            set => _tacticalMaterial = value;
        }

        [Description("selectedTacticalMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string selectedTacticalMaterial
        {
            get => _selectedTacticalMaterial;
            set => _selectedTacticalMaterial = value;
        }

        [Description("buildTacticalMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string buildTacticalMaterial
        {
            get => _buildTacticalMaterial;
            set => _buildTacticalMaterial = value;
        }

        [Description("bareBonesMaterialName is a plaintext string"), Category("Plaintext Strings")]
        public string bareBonesMaterialName
        {
            get => _bareBonesMaterialName;
            set => _bareBonesMaterialName = value;
        }

        [Description("factionIconText is a plaintext string"), Category("Plaintext Strings")]
        public string factionIconText
        {
            get => _factionIconText;
            set => _factionIconText = value;
        }

        [Description("factionSkyBoxMaterialName is a plaintext string"), Category("Plaintext Strings")]
        public string factionSkyBoxMaterialName
        {
            get => _factionSkyBoxMaterialName;
            set => _factionSkyBoxMaterialName = value;
        }

        [Description("factionBaseMusic is a plaintext string"), Category("Plaintext Strings")]
        public string factionBaseMusic
        {
            get => _factionBaseMusic;
            set => _factionBaseMusic = value;
        }

        [Description("instantEditorText is a plaintext string"), Category("Plaintext Strings")]
        public string instantEditorText
        {
            get => _instantEditorText;
            set => _instantEditorText = value;
        }

        [Description("sellShipFactionID is a plaintext string"), Category("Plaintext Strings")]
        public string sellShipFactionID
        {
            get => _sellShipFactionID;
            set => _sellShipFactionID = value;
        }

        [Description("buildShipFactionID is a plaintext string"), Category("Plaintext Strings")]
        public string buildShipFactionID
        {
            get => _buildShipFactionID;
            set => _buildShipFactionID = value;
        }

        [Description("portraitFactionID is a plaintext string"), Category("Plaintext Strings")]
        public string portraitFactionID
        {
            get => _portraitFactionID;
            set => _portraitFactionID = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }

        [Description("spawnShipFactionID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> spawnShipFactionID
        {
            get => _spawnShipFactionID;
            set => _spawnShipFactionID = value;
        }


        [Description("wireframeColor is an integer"), Category("Integers")]
        public int wireframeColor
        {
            get => _wireframeColor;
            set => _wireframeColor = value;
        }

        [Description("highlightOutlineColor is an integer"), Category("Integers")]
        public int highlightOutlineColor
        {
            get => _highlightOutlineColor;
            set => _highlightOutlineColor = value;
        }

        [Description("textColor is an integer"), Category("Integers")]
        public int textColor
        {
            get => _textColor;
            set => _textColor = value;
        }


        [Description("cloudsColor is a collection of integers"), Category("Integer Collections")]
        public List<int> cloudsColor
        {
            get => _cloudsColor;
            set => _cloudsColor = value;
        }


        [Description("bFactionShipRequiredForMission is a boolean value"), Category("Booleans")]
        public bool bFactionShipRequiredForMission
        {
            get => _bFactionShipRequiredForMission;
            set => _bFactionShipRequiredForMission = value;
        }

        [Description("bNoShow is a boolean value"), Category("Booleans")]
        public bool bNoShow
        {
            get => _bNoShow;
            set => _bNoShow = value;
        }

        [Description("bCommsEnabled is a boolean value"), Category("Booleans")]
        public bool bCommsEnabled
        {
            get => _bCommsEnabled;
            set => _bCommsEnabled = value;
        }

        [Description("bHUDCommsEnabled is a boolean value"), Category("Booleans")]
        public bool bHUDCommsEnabled
        {
            get => _bHUDCommsEnabled;
            set => _bHUDCommsEnabled = value;
        }

        [Description("bGenericCommsOverride is a boolean value"), Category("Booleans")]
        public bool bGenericCommsOverride
        {
            get => _bGenericCommsOverride;
            set => _bGenericCommsOverride = value;
        }

        [Description("bPirate is a boolean value"), Category("Booleans")]
        public bool bPirate
        {
            get => _bPirate;
            set => _bPirate = value;
        }


        [Description("backgroundColor is a collection of boolean values"), Category("Boolean Collections")]
        public List<bool> backgroundColor
        {
            get => _backgroundColor;
            set => _backgroundColor = value;
        }



        public FactionData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _factionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionID");
                _factionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionType");
                _factionName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionName");
                _factionPluralName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionPluralName");
                _tacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalMaterial");
                _selectedTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selectedTacticalMaterial");
                _buildTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildTacticalMaterial");
                _bareBonesMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "bareBonesMaterialName");
                _factionIconText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionIconText");
                _factionSkyBoxMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionSkyBoxMaterialName");
                _factionBaseMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionBaseMusic");
                _instantEditorText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantEditorText");
                _sellShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sellShipFactionID");
                _buildShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildShipFactionID");
                _portraitFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "portraitFactionID");

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");
                _spawnShipFactionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "spawnShipFactionID");

                _wireframeColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "wireframeColor");
                _highlightOutlineColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "highlightOutlineColor");
                _textColor = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "textColor");

                _cloudsColor = ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, "cloudsColor");

                _bFactionShipRequiredForMission = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFactionShipRequiredForMission");
                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow");
                _bCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsEnabled");
                _bHUDCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHUDCommsEnabled");
                _bGenericCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGenericCommsOverride");
                _bPirate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPirate");

                _backgroundColor = ParseHelpers.GetBoolListFromVD2Data(DataXMLDoc, "backgroundColor");

            }
        }
    }
}
