using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

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


        [Browsable(false), Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                if (_descriptionText != null)
                {
                    _descriptionText.CollectionChanged -= OndescriptionTextChanged;
                }
                _descriptionText = value;
                if (_descriptionText != null)
                {
                    _descriptionText.CollectionChanged += OndescriptionTextChanged;
                }
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
                    _descriptionText.CollectionChanged += OndescriptionTextChanged;
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

        [Browsable(false), Description("spawnShipFactionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> spawnShipFactionID
        {
            get
            {
                return _spawnShipFactionID;
            }
            set
            {
                if (_spawnShipFactionID != null)
                {
                    _spawnShipFactionID.CollectionChanged -= OnspawnShipFactionIDChanged;
                }
                _spawnShipFactionID = value;
                if (_spawnShipFactionID != null)
                {
                    _spawnShipFactionID.CollectionChanged += OnspawnShipFactionIDChanged;
                }
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
                    _spawnShipFactionID.CollectionChanged += OnspawnShipFactionIDChanged;
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
                        _wireframeColor.OnElementChanged -= wireframeColor_OnElementChanged;
                        _wireframeColor = value;
                        _wireframeColor.OnElementChanged += wireframeColor_OnElementChanged;
                        SetPropertyEdited("wireframeColor", true);
                    }
                }
            }
        }

        private void wireframeColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("wireframeColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= wireframeColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += wireframeColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= wireframeColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += wireframeColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= wireframeColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += wireframeColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= wireframeColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += wireframeColor_OnElementChanged;
                                break;
                        }
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
                        _highlightOutlineColor.OnElementChanged -= highlightOutlineColor_OnElementChanged;
                        _highlightOutlineColor = value;
                        _highlightOutlineColor.OnElementChanged += highlightOutlineColor_OnElementChanged;
                        SetPropertyEdited("highlightOutlineColor", true);
                    }
                }
            }
        }

        private void highlightOutlineColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("highlightOutlineColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= highlightOutlineColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += highlightOutlineColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= highlightOutlineColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += highlightOutlineColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= highlightOutlineColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += highlightOutlineColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= highlightOutlineColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += highlightOutlineColor_OnElementChanged;
                                break;
                        }
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
                        _textColor.OnElementChanged -= textColor_OnElementChanged;
                        _textColor = value;
                        _textColor.OnElementChanged += textColor_OnElementChanged;
                        SetPropertyEdited("textColor", true);
                    }
                }
            }
        }

        private void textColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("textColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= textColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += textColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= textColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += textColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= textColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += textColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= textColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += textColor_OnElementChanged;
                                break;
                        }
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
                        _backgroundColor.OnElementChanged -= backgroundColor_OnElementChanged;
                        _backgroundColor = value;
                        _backgroundColor.OnElementChanged += backgroundColor_OnElementChanged;
                        SetPropertyEdited("backgroundColor", true);
                    }
                }
            }
        }

        private void backgroundColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("backgroundColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= backgroundColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += backgroundColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= backgroundColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += backgroundColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= backgroundColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += backgroundColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= backgroundColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += backgroundColor_OnElementChanged;
                                break;
                        }
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
                        _cloudsColor.OnElementChanged -= cloudsColor_OnElementChanged;
                        _cloudsColor = value;
                        _cloudsColor.OnElementChanged += cloudsColor_OnElementChanged;
                        SetPropertyEdited("cloudsColor", true);
                    }
                }
            }
        }

        private void cloudsColor_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("cloudsColor", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= cloudsColor_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += cloudsColor_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= cloudsColor_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += cloudsColor_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= cloudsColor_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += cloudsColor_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= cloudsColor_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += cloudsColor_OnElementChanged;
                                break;
                        }
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
            SetPropertyIsCollection("descriptionText", true, typeof(string));
            InitProperty("spawnShipFactionID");
            SetPropertyIsCollection("spawnShipFactionID", true, typeof(string));

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
        }

        public override void LoadDataFromXML()
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
                _descriptionText.CollectionChanged += OndescriptionTextChanged;
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
                _spawnShipFactionID.CollectionChanged += OnspawnShipFactionIDChanged;
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
                _wireframeColor.OnElementChanged += wireframeColor_OnElementChanged;
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
                _highlightOutlineColor.OnElementChanged += highlightOutlineColor_OnElementChanged;
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
                _textColor.OnElementChanged += textColor_OnElementChanged;
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
                _backgroundColor.OnElementChanged += backgroundColor_OnElementChanged;
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
                _cloudsColor.OnElementChanged += cloudsColor_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cloudsColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cloudsColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cloudsColor"));
                }
                SetPropertyExists("cloudsColor", exists);

                base.LoadDataFromXML();
            }
        }

        protected override void SaveData()
        {
            List<string> xmltextlines = new List<string>();
            xmltextlines.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmltextlines.Add("<note_to_self attr1=\"Generated by Void Destroyer 2 Data Editor\"/>");
            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Strings...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("factionID"))
            {
                xmltextlines.Add("<factionID attr1=\"" + _factionID + "\"/>");
            }
            if (PropertyExists("factionType"))
            {
                xmltextlines.Add("<factionType attr1=\"" + _factionType + "\"/>");
            }
            if (PropertyExists("factionName"))
            {
                xmltextlines.Add("<factionName attr1=\"" + _factionName + "\"/>");
            }
            if (PropertyExists("factionPluralName"))
            {
                xmltextlines.Add("<factionPluralName attr1=\"" + _factionPluralName + "\"/>");
            }
            if (PropertyExists("tacticalMaterial"))
            {
                xmltextlines.Add("<tacticalMaterial attr1=\"" + _tacticalMaterial + "\"/>");
            }
            if (PropertyExists("selectedTacticalMaterial"))
            {
                xmltextlines.Add("<selectedTacticalMaterial attr1=\"" + _selectedTacticalMaterial + "\"/>");
            }
            if (PropertyExists("buildTacticalMaterial"))
            {
                xmltextlines.Add("<buildTacticalMaterial attr1=\"" + _buildTacticalMaterial + "\"/>");
            }
            if (PropertyExists("bareBonesMaterialName"))
            {
                xmltextlines.Add("<bareBonesMaterialName attr1=\"" + _bareBonesMaterialName + "\"/>");
            }
            if (PropertyExists("factionIconText"))
            {
                xmltextlines.Add("<factionIconText attr1=\"" + _factionIconText + "\"/>");
            }
            if (PropertyExists("factionSkyBoxMaterialName"))
            {
                xmltextlines.Add("<factionSkyBoxMaterialName attr1=\"" + _factionSkyBoxMaterialName + "\"/>");
            }
            if (PropertyExists("factionBaseMusic"))
            {
                xmltextlines.Add("<factionBaseMusic attr1=\"" + _factionBaseMusic + "\"/>");
            }
            if (PropertyExists("instantEditorText"))
            {
                xmltextlines.Add("<instantEditorText attr1=\"" + _instantEditorText + "\"/>");
            }
            if (PropertyExists("sellShipFactionID"))
            {
                xmltextlines.Add("<sellShipFactionID attr1=\"" + _sellShipFactionID + "\"/>");
            }
            if (PropertyExists("buildShipFactionID"))
            {
                xmltextlines.Add("<buildShipFactionID attr1=\"" + _buildShipFactionID + "\"/>");
            }
            if (PropertyExists("portraitFactionID"))
            {
                xmltextlines.Add("<portraitFactionID attr1=\"" + _portraitFactionID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("descriptionText"))
            {
                foreach (string result in _descriptionText)
                {
                    xmltextlines.Add("<descriptionText attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("spawnShipFactionID"))
            {
                foreach (string result in _spawnShipFactionID)
                {
                    xmltextlines.Add("<spawnShipFactionID attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bFactionShipRequiredForMission"))
            {
                xmltextlines.Add("<bFactionShipRequiredForMission attr1=\"" + ((_bFactionShipRequiredForMission) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoShow"))
            {
                xmltextlines.Add("<bNoShow attr1=\"" + ((_bNoShow) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCommsEnabled"))
            {
                xmltextlines.Add("<bCommsEnabled attr1=\"" + ((_bCommsEnabled) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bHUDCommsEnabled"))
            {
                xmltextlines.Add("<bHUDCommsEnabled attr1=\"" + ((_bHUDCommsEnabled) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bGenericCommsOverride"))
            {
                xmltextlines.Add("<bGenericCommsOverride attr1=\"" + ((_bGenericCommsOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPirate"))
            {
                xmltextlines.Add("<bPirate attr1=\"" + ((_bPirate) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Colors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("wireframeColor"))
            {
                xmltextlines.Add("<wireframeColor r=\"" + _wireframeColor.r.ToString() + "\" g=\"" + _wireframeColor.g.ToString() + "\" b=\"" + _wireframeColor.b.ToString() + "\" a=\"" + _wireframeColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("highlightOutlineColor"))
            {
                xmltextlines.Add("<highlightOutlineColor r=\"" + _highlightOutlineColor.r.ToString() + "\" g=\"" + _highlightOutlineColor.g.ToString() + "\" b=\"" + _highlightOutlineColor.b.ToString() + "\" a=\"" + _highlightOutlineColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("textColor"))
            {
                xmltextlines.Add("<textColor r=\"" + _textColor.r.ToString() + "\" g=\"" + _textColor.g.ToString() + "\" b=\"" + _textColor.b.ToString() + "\" a=\"" + _textColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("backgroundColor"))
            {
                xmltextlines.Add("<backgroundColor r=\"" + _backgroundColor.r.ToString() + "\" g=\"" + _backgroundColor.g.ToString() + "\" b=\"" + _backgroundColor.b.ToString() + "\" a=\"" + _backgroundColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("cloudsColor"))
            {
                xmltextlines.Add("<cloudsColor r=\"" + _cloudsColor.r.ToString() + "\" g=\"" + _cloudsColor.g.ToString() + "\" b=\"" + _cloudsColor.b.ToString() + "\" a=\"" + _cloudsColor.a.ToString() + "\"/>");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }
    }
}
