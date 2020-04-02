using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class FactionData : VD2Data
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

        ObservableCollection<string> _descriptionText;
        ObservableCollection<string> _spawnShipFactionID;

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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionID = value;
                        SetPropertyEdited("factionID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionType = value;
                        SetPropertyEdited("factionType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionName = value;
                        SetPropertyEdited("factionName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionPluralName = value;
                        SetPropertyEdited("factionPluralName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _tacticalMaterial = value;
                        SetPropertyEdited("tacticalMaterial", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _selectedTacticalMaterial = value;
                        SetPropertyEdited("selectedTacticalMaterial", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _buildTacticalMaterial = value;
                        SetPropertyEdited("buildTacticalMaterial", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bareBonesMaterialName = value;
                        SetPropertyEdited("bareBonesMaterialName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionIconText = value;
                        SetPropertyEdited("factionIconText", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionSkyBoxMaterialName = value;
                        SetPropertyEdited("factionSkyBoxMaterialName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _factionBaseMusic = value;
                        SetPropertyEdited("factionBaseMusic", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _instantEditorText = value;
                        SetPropertyEdited("instantEditorText", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _sellShipFactionID = value;
                        SetPropertyEdited("sellShipFactionID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _buildShipFactionID = value;
                        SetPropertyEdited("buildShipFactionID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _portraitFactionID = value;
                        SetPropertyEdited("portraitFactionID", true);
                    }
                }
            }
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                _descriptionText = value;
            }
        }

        private void OndescriptionTextChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("descriptionText", true);
                }
                else
                {
                    bool exists = false;
                    _descriptionText = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists));
                    _descriptionText.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionTextChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("descriptionText", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                    }
                    SetPropertyExists("descriptionText", exists);
                }
            }
        }

        [Description("spawnShipFactionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> spawnShipFactionID
        {
            get
            {
                return _spawnShipFactionID;
            }
            set
            {
                _spawnShipFactionID = value;
            }
        }

        private void OnspawnShipFactionIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("spawnShipFactionID", true);
                }
                else
                {
                    bool exists = false;
                    _spawnShipFactionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "spawnShipFactionID", out exists));
                    _spawnShipFactionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnspawnShipFactionIDChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("spawnShipFactionID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("spawnShipFactionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "spawnShipFactionID"));
                    }
                    SetPropertyExists("spawnShipFactionID", exists);
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bFactionShipRequiredForMission = value;
                        SetPropertyEdited("bFactionShipRequiredForMission", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoShow = value;
                        SetPropertyEdited("bNoShow", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCommsEnabled = value;
                        SetPropertyEdited("bCommsEnabled", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bHUDCommsEnabled = value;
                        SetPropertyEdited("bHUDCommsEnabled", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bGenericCommsOverride = value;
                        SetPropertyEdited("bGenericCommsOverride", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPirate = value;
                        SetPropertyEdited("bPirate", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _wireframeColor = value;
                        SetPropertyEdited("wireframeColor", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _highlightOutlineColor = value;
                        SetPropertyEdited("highlightOutlineColor", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _textColor = value;
                        SetPropertyEdited("textColor", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _backgroundColor = value;
                        SetPropertyEdited("backgroundColor", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cloudsColor = value;
                        SetPropertyEdited("cloudsColor", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("factionID");
            SetPropertyIsObjectID("factionID", true);
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

        public FactionData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _factionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(factionID, "factionID"));
                }
                SetPropertyExists("factionID", exists);

                _factionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionType"));
                }
                SetPropertyExists("factionType", exists);
                _factionName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionName"));
                }
                SetPropertyExists("factionName", exists);
                _factionPluralName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionPluralName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionPluralName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionPluralName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionPluralName"));
                }
                SetPropertyExists("factionPluralName", exists);
                _tacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("tacticalMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("tacticalMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "tacticalMaterial"));
                }
                SetPropertyExists("tacticalMaterial", exists);
                _selectedTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selectedTacticalMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("selectedTacticalMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("selectedTacticalMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "selectedTacticalMaterial"));
                }
                SetPropertyExists("selectedTacticalMaterial", exists);
                _buildTacticalMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildTacticalMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("buildTacticalMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("buildTacticalMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "buildTacticalMaterial"));
                }
                SetPropertyExists("buildTacticalMaterial", exists);
                _bareBonesMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "bareBonesMaterialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bareBonesMaterialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bareBonesMaterialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bareBonesMaterialName"));
                }
                SetPropertyExists("bareBonesMaterialName", exists);
                _factionIconText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionIconText", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionIconText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionIconText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionIconText"));
                }
                SetPropertyExists("factionIconText", exists);
                _factionSkyBoxMaterialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionSkyBoxMaterialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionSkyBoxMaterialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionSkyBoxMaterialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionSkyBoxMaterialName"));
                }
                SetPropertyExists("factionSkyBoxMaterialName", exists);
                _factionBaseMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "factionBaseMusic", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionBaseMusic", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionBaseMusic", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionBaseMusic"));
                }
                SetPropertyExists("factionBaseMusic", exists);
                _instantEditorText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantEditorText", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("instantEditorText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("instantEditorText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "instantEditorText"));
                }
                SetPropertyExists("instantEditorText", exists);
                _sellShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sellShipFactionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("sellShipFactionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("sellShipFactionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "sellShipFactionID"));
                }
                SetPropertyExists("sellShipFactionID", exists);
                _buildShipFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "buildShipFactionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("buildShipFactionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("buildShipFactionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "buildShipFactionID"));
                }
                SetPropertyExists("buildShipFactionID", exists);
                _portraitFactionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "portraitFactionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("portraitFactionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("portraitFactionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "portraitFactionID"));
                }
                SetPropertyExists("portraitFactionID", exists);

                _descriptionText = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists));
                _descriptionText.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndescriptionTextChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("descriptionText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                }
                SetPropertyExists("descriptionText", exists);
                _spawnShipFactionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "spawnShipFactionID", out exists));
                _spawnShipFactionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnspawnShipFactionIDChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("spawnShipFactionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("spawnShipFactionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "spawnShipFactionID"));
                }
                SetPropertyExists("spawnShipFactionID", exists);

                _bFactionShipRequiredForMission = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFactionShipRequiredForMission", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bFactionShipRequiredForMission", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bFactionShipRequiredForMission", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bFactionShipRequiredForMission"));
                }
                SetPropertyExists("bFactionShipRequiredForMission", exists);
                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoShow", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoShow", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoShow"));
                }
                SetPropertyExists("bNoShow", exists);
                _bCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsEnabled", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCommsEnabled", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCommsEnabled", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCommsEnabled"));
                }
                SetPropertyExists("bCommsEnabled", exists);
                _bHUDCommsEnabled = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHUDCommsEnabled", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bHUDCommsEnabled", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bHUDCommsEnabled", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bHUDCommsEnabled"));
                }
                SetPropertyExists("bHUDCommsEnabled", exists);
                _bGenericCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGenericCommsOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bGenericCommsOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bGenericCommsOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bGenericCommsOverride"));
                }
                SetPropertyExists("bGenericCommsOverride", exists);
                _bPirate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPirate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPirate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPirate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPirate"));
                }
                SetPropertyExists("bPirate", exists);

                _wireframeColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "wireframeColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("wireframeColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("wireframeColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "wireframeColor"));
                }
                SetPropertyExists("wireframeColor", exists);
                _highlightOutlineColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "highlightOutlineColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("highlightOutlineColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("highlightOutlineColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "highlightOutlineColor"));
                }
                SetPropertyExists("highlightOutlineColor", exists);
                _textColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "textColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("textColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("textColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "textColor"));
                }
                SetPropertyExists("textColor", exists);
                _backgroundColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "backgroundColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("backgroundColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("backgroundColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "backgroundColor"));
                }
                SetPropertyExists("backgroundColor", exists);
                _cloudsColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "cloudsColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cloudsColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cloudsColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cloudsColor"));
                }
                SetPropertyExists("cloudsColor", exists);

            }
        }
    }
}
