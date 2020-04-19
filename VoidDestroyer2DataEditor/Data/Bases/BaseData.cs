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
    public class BaseData : VD2Data
    {
        string _objectType;
        string _name;
        string _displayName;
        string _objectID;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _collisionShape;
        string _maxBuildShipClass;
        string _interiorMesh;
        string _dockOrientation;

        ObservableCollection<string> _descriptionText;
        ObservableCollection<string> _hangarID;

        int _rockSubPosition;
        int _miningUnitMax;
        int _tugUnitMax;

        float _oreProductionModifier;
        float _maxCrew;
        float _energyProductionModifier;
        float _foodProductionModifier;
        float _weaponsProductionModifier;
        float _narcoticsProductionModifier;

        bool _isMassInfinite;
        bool _bCanResearch;
        bool _bMobile;
        bool _bNoLargeHangarInterior;
        bool _bNoRemoteControlInterior;

        Vector3D _dockingArms;
        Vector3D _dockingArmsEnd;
        Vector3D _dockPosition;
        Vector3D _dockSize;
        Vector3D _miningPlatformPosition;

        largeDockDataStructure _largeDock;

        ObservableCollection<propulsionDataStructure> _propulsion;
        ObservableCollection<physicalRotatingElementDataStructure> _physicalRotatingElement;
        ObservableCollection<alwaysOnEffectDataStructure> _alwaysOnEffect;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectType = value;
                        SetPropertyEdited("objectType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _name = value;
                        SetPropertyEdited("name", true);
                    }
                }
            }
        }

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _displayName = value;
                        SetPropertyEdited("displayName", true);
                    }
                }
            }
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectID = value;
                        SetPropertyEdited("objectID", true);
                    }
                }
            }
        }

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get
            {
                return _faction;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _faction = value;
                        SetPropertyEdited("faction", true);
                    }
                }
            }
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string meshName
        {
            get
            {
                return _meshName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _meshName = value;
                        SetPropertyEdited("meshName", true);
                    }
                }
            }
        }

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wireframeMaterial
        {
            get
            {
                return _wireframeMaterial;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _wireframeMaterial = value;
                        SetPropertyEdited("wireframeMaterial", true);
                    }
                }
            }
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionShape
        {
            get
            {
                return _collisionShape;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionShape = value;
                        SetPropertyEdited("collisionShape", true);
                    }
                }
            }
        }

        [Description("maxBuildShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string maxBuildShipClass
        {
            get
            {
                return _maxBuildShipClass;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxBuildShipClass = value;
                        SetPropertyEdited("maxBuildShipClass", true);
                    }
                }
            }
        }

        [Description("interiorMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string interiorMesh
        {
            get
            {
                return _interiorMesh;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _interiorMesh = value;
                        SetPropertyEdited("interiorMesh", true);
                    }
                }
            }
        }

        [Description("dockOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dockOrientation
        {
            get
            {
                return _dockOrientation;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockOrientation = value;
                        SetPropertyEdited("dockOrientation", true);
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

        [Description("hangarID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                _hangarID = value;
            }
        }

        private void OnhangarIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("hangarID", true);
                }
                else
                {
                    bool exists = false;
                    _hangarID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "hangarID", out exists));
                    _hangarID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnhangarIDChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("hangarID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hangarID"));
                    }
                    SetPropertyExists("hangarID", exists);
                }
            }
        }


        [Description("rockSubPosition is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rockSubPosition
        {
            get
            {
                return _rockSubPosition;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _rockSubPosition = value;
                        SetPropertyEdited("rockSubPosition", true);
                    }
                }
            }
        }

        [Description("miningUnitMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int miningUnitMax
        {
            get
            {
                return _miningUnitMax;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _miningUnitMax = value;
                        SetPropertyEdited("miningUnitMax", true);
                    }
                }
            }
        }

        [Description("tugUnitMax is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int tugUnitMax
        {
            get
            {
                return _tugUnitMax;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _tugUnitMax = value;
                        SetPropertyEdited("tugUnitMax", true);
                    }
                }
            }
        }


        [Description("oreProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float oreProductionModifier
        {
            get
            {
                return _oreProductionModifier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _oreProductionModifier = value;
                        SetPropertyEdited("oreProductionModifier", true);
                    }
                }
            }
        }

        [Description("maxCrew is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float maxCrew
        {
            get
            {
                return _maxCrew;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxCrew = value;
                        SetPropertyEdited("maxCrew", true);
                    }
                }
            }
        }

        [Description("energyProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float energyProductionModifier
        {
            get
            {
                return _energyProductionModifier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _energyProductionModifier = value;
                        SetPropertyEdited("energyProductionModifier", true);
                    }
                }
            }
        }

        [Description("foodProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float foodProductionModifier
        {
            get
            {
                return _foodProductionModifier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _foodProductionModifier = value;
                        SetPropertyEdited("foodProductionModifier", true);
                    }
                }
            }
        }

        [Description("weaponsProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float weaponsProductionModifier
        {
            get
            {
                return _weaponsProductionModifier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponsProductionModifier = value;
                        SetPropertyEdited("weaponsProductionModifier", true);
                    }
                }
            }
        }

        [Description("narcoticsProductionModifier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float narcoticsProductionModifier
        {
            get
            {
                return _narcoticsProductionModifier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _narcoticsProductionModifier = value;
                        SetPropertyEdited("narcoticsProductionModifier", true);
                    }
                }
            }
        }


        [Description("isMassInfinite is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool isMassInfinite
        {
            get
            {
                return _isMassInfinite;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _isMassInfinite = value;
                        SetPropertyEdited("isMassInfinite", true);
                    }
                }
            }
        }

        [Description("bCanResearch is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanResearch
        {
            get
            {
                return _bCanResearch;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCanResearch = value;
                        SetPropertyEdited("bCanResearch", true);
                    }
                }
            }
        }

        [Description("bMobile is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bMobile
        {
            get
            {
                return _bMobile;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bMobile = value;
                        SetPropertyEdited("bMobile", true);
                    }
                }
            }
        }

        [Description("bNoLargeHangarInterior is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoLargeHangarInterior
        {
            get
            {
                return _bNoLargeHangarInterior;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoLargeHangarInterior = value;
                        SetPropertyEdited("bNoLargeHangarInterior", true);
                    }
                }
            }
        }

        [Description("bNoRemoteControlInterior is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoRemoteControlInterior
        {
            get
            {
                return _bNoRemoteControlInterior;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoRemoteControlInterior = value;
                        SetPropertyEdited("bNoRemoteControlInterior", true);
                    }
                }
            }
        }


        [Description("dockingArms is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArms
        {
            get
            {
                return _dockingArms;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockingArms = value;
                        SetPropertyEdited("dockingArms", true);
                    }
                }
            }
        }

        [Description("dockingArmsEnd is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockingArmsEnd
        {
            get
            {
                return _dockingArmsEnd;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockingArmsEnd = value;
                        SetPropertyEdited("dockingArmsEnd", true);
                    }
                }
            }
        }

        [Description("dockPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockPosition
        {
            get
            {
                return _dockPosition;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockPosition = value;
                        SetPropertyEdited("dockPosition", true);
                    }
                }
            }
        }

        [Description("dockSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D dockSize
        {
            get
            {
                return _dockSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dockSize = value;
                        SetPropertyEdited("dockSize", true);
                    }
                }
            }
        }

        [Description("miningPlatformPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D miningPlatformPosition
        {
            get
            {
                return _miningPlatformPosition;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _miningPlatformPosition = value;
                        SetPropertyEdited("miningPlatformPosition", true);
                    }
                }
            }
        }


        [Description("largeDock is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public largeDockDataStructure largeDock
        {
            get
            {
                return _largeDock;
            }
            set
            {
                _largeDock = value;
            }
        }


        [Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<propulsionDataStructure> propulsion
        {
            get
            {
                return _propulsion;
            }
            set
            {
                _propulsion = value;
            }
        }

        private void OnpropulsionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("propulsion", true);
                }
                else
                {
                    bool exists = false;
                    _propulsion = new ObservableCollection<propulsionDataStructure>(DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _propulsion.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnpropulsionChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("propulsion", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("propulsion", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "propulsion"));
                    }
                    SetPropertyExists("propulsion", exists);
                }
            }
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get
            {
                return _physicalRotatingElement;
            }
            set
            {
                _physicalRotatingElement = value;
            }
        }

        private void OnphysicalRotatingElementChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("physicalRotatingElement", true);
                }
                else
                {
                    bool exists = false;
                    _physicalRotatingElement = new ObservableCollection<physicalRotatingElementDataStructure>(DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _physicalRotatingElement.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnphysicalRotatingElementChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("physicalRotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "physicalRotatingElement"));
                    }
                    SetPropertyExists("physicalRotatingElement", exists);
                }
            }
        }

        [Description("alwaysOnEffect is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<alwaysOnEffectDataStructure> alwaysOnEffect
        {
            get
            {
                return _alwaysOnEffect;
            }
            set
            {
                _alwaysOnEffect = value;
            }
        }

        private void OnalwaysOnEffectChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("alwaysOnEffect", true);
                }
                else
                {
                    bool exists = false;
                    _alwaysOnEffect = new ObservableCollection<alwaysOnEffectDataStructure>(DataStructureParseHelpers.GetalwaysOnEffectDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _alwaysOnEffect.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnalwaysOnEffectChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("alwaysOnEffect", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("alwaysOnEffect", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "alwaysOnEffect"));
                    }
                    SetPropertyExists("alwaysOnEffect", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("displayName");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("collisionShape");
            InitProperty("maxBuildShipClass");
            InitProperty("interiorMesh");
            InitProperty("dockOrientation");

            InitProperty("descriptionText");
            InitProperty("hangarID");

            InitProperty("rockSubPosition");
            InitProperty("miningUnitMax");
            InitProperty("tugUnitMax");

            InitProperty("oreProductionModifier");
            InitProperty("maxCrew");
            InitProperty("energyProductionModifier");
            InitProperty("foodProductionModifier");
            InitProperty("weaponsProductionModifier");
            InitProperty("narcoticsProductionModifier");

            InitProperty("isMassInfinite");
            InitProperty("bCanResearch");
            InitProperty("bMobile");
            InitProperty("bNoLargeHangarInterior");
            InitProperty("bNoRemoteControlInterior");

            InitProperty("dockingArms");
            InitProperty("dockingArmsEnd");
            InitProperty("dockPosition");
            InitProperty("dockSize");
            InitProperty("miningPlatformPosition");

            InitProperty("largeDock");

            InitProperty("propulsion");
            InitProperty("physicalRotatingElement");
            InitProperty("alwaysOnEffect");
        }

        public BaseData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(objectID, "objectID"));
                }
                SetPropertyExists("objectID", exists);

                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "objectType"));
                }
                SetPropertyExists("objectType", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("name", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("name", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "name"));
                }
                SetPropertyExists("name", exists);
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("displayName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("displayName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "displayName"));
                }
                SetPropertyExists("displayName", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("faction", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("faction", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "faction"));
                }
                SetPropertyExists("faction", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("meshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("meshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "meshName"));
                }
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "wireframeMaterial"));
                }
                SetPropertyExists("wireframeMaterial", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionShape", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionShape", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShape"));
                }
                SetPropertyExists("collisionShape", exists);
                _maxBuildShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxBuildShipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxBuildShipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxBuildShipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxBuildShipClass"));
                }
                SetPropertyExists("maxBuildShipClass", exists);
                _interiorMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "interiorMesh", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("interiorMesh", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("interiorMesh", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "interiorMesh"));
                }
                SetPropertyExists("interiorMesh", exists);
                _dockOrientation = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "dockOrientation", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockOrientation", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockOrientation", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockOrientation"));
                }
                SetPropertyExists("dockOrientation", exists);

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
                _hangarID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "hangarID", out exists));
                _hangarID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnhangarIDChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hangarID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hangarID"));
                }
                SetPropertyExists("hangarID", exists);

                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rockSubPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rockSubPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rockSubPosition"));
                }
                SetPropertyExists("rockSubPosition", exists);
                _miningUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "miningUnitMax", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("miningUnitMax", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("miningUnitMax", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "miningUnitMax"));
                }
                SetPropertyExists("miningUnitMax", exists);
                _tugUnitMax = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "tugUnitMax", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("tugUnitMax", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("tugUnitMax", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "tugUnitMax"));
                }
                SetPropertyExists("tugUnitMax", exists);

                _oreProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oreProductionModifier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("oreProductionModifier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("oreProductionModifier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "oreProductionModifier"));
                }
                SetPropertyExists("oreProductionModifier", exists);
                _maxCrew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maxCrew", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxCrew", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxCrew", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxCrew"));
                }
                SetPropertyExists("maxCrew", exists);
                _energyProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energyProductionModifier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("energyProductionModifier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("energyProductionModifier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "energyProductionModifier"));
                }
                SetPropertyExists("energyProductionModifier", exists);
                _foodProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "foodProductionModifier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("foodProductionModifier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("foodProductionModifier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "foodProductionModifier"));
                }
                SetPropertyExists("foodProductionModifier", exists);
                _weaponsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponsProductionModifier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponsProductionModifier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponsProductionModifier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponsProductionModifier"));
                }
                SetPropertyExists("weaponsProductionModifier", exists);
                _narcoticsProductionModifier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "narcoticsProductionModifier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("narcoticsProductionModifier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("narcoticsProductionModifier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "narcoticsProductionModifier"));
                }
                SetPropertyExists("narcoticsProductionModifier", exists);

                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("isMassInfinite", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("isMassInfinite", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "isMassInfinite"));
                }
                SetPropertyExists("isMassInfinite", exists);
                _bCanResearch = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanResearch", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCanResearch", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCanResearch", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCanResearch"));
                }
                SetPropertyExists("bCanResearch", exists);
                _bMobile = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMobile", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bMobile", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bMobile", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bMobile"));
                }
                SetPropertyExists("bMobile", exists);
                _bNoLargeHangarInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLargeHangarInterior", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoLargeHangarInterior", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoLargeHangarInterior", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoLargeHangarInterior"));
                }
                SetPropertyExists("bNoLargeHangarInterior", exists);
                _bNoRemoteControlInterior = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoRemoteControlInterior", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoRemoteControlInterior", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoRemoteControlInterior", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoRemoteControlInterior"));
                }
                SetPropertyExists("bNoRemoteControlInterior", exists);

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockingArms", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockingArms", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockingArms"));
                }
                SetPropertyExists("dockingArms", exists);
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockingArmsEnd", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockingArmsEnd", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockingArmsEnd"));
                }
                SetPropertyExists("dockingArmsEnd", exists);
                _dockPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockPosition", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockPosition"));
                }
                SetPropertyExists("dockPosition", exists);
                _dockSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dockSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dockSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dockSize"));
                }
                SetPropertyExists("dockSize", exists);
                _miningPlatformPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "miningPlatformPosition", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("miningPlatformPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("miningPlatformPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "miningPlatformPosition"));
                }
                SetPropertyExists("miningPlatformPosition", exists);

                _largeDock = DataStructureParseHelpers.GetlargeDockDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("largeDock", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("largeDock", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "largeDock"));
                }
                SetPropertyExists("largeDock", exists);

                _propulsion =  new ObservableCollection<propulsionDataStructure>(DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _propulsion.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnpropulsionChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("propulsion", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("propulsion", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "propulsion"));
                }
                SetPropertyExists("propulsion", exists);
                _physicalRotatingElement =  new ObservableCollection<physicalRotatingElementDataStructure>(DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _physicalRotatingElement.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnphysicalRotatingElementChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("physicalRotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "physicalRotatingElement"));
                }
                SetPropertyExists("physicalRotatingElement", exists);
                _alwaysOnEffect =  new ObservableCollection<alwaysOnEffectDataStructure>(DataStructureParseHelpers.GetalwaysOnEffectDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _alwaysOnEffect.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnalwaysOnEffectChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("alwaysOnEffect", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("alwaysOnEffect", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "alwaysOnEffect"));
                }
                SetPropertyExists("alwaysOnEffect", exists);
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
            if (PropertyExists("objectType"))
            {
                xmltextlines.Add("<objectType attr1=\"" + _objectType + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("faction"))
            {
                xmltextlines.Add("<faction attr1=\"" + _faction + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("maxBuildShipClass"))
            {
                xmltextlines.Add("<maxBuildShipClass attr1=\"" + _maxBuildShipClass + "\"/>");
            }
            if (PropertyExists("interiorMesh"))
            {
                xmltextlines.Add("<interiorMesh attr1=\"" + _interiorMesh + "\"/>");
            }
            if (PropertyExists("dockOrientation"))
            {
                xmltextlines.Add("<dockOrientation attr1=\"" + _dockOrientation + "\"/>");
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
            if (PropertyExists("hangarID"))
            {
                foreach (string result in _hangarID)
                {
                    xmltextlines.Add("<hangarID attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("rockSubPosition"))
            {
                xmltextlines.Add("<rockSubPosition attr1=\"" + _rockSubPosition.ToString() + "\"/>");
            }
            if (PropertyExists("miningUnitMax"))
            {
                xmltextlines.Add("<miningUnitMax attr1=\"" + _miningUnitMax.ToString() + "\"/>");
            }
            if (PropertyExists("tugUnitMax"))
            {
                xmltextlines.Add("<tugUnitMax attr1=\"" + _tugUnitMax.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("oreProductionModifier"))
            {
                xmltextlines.Add("<oreProductionModifier attr1=\"" + _oreProductionModifier.ToString() + "\"/>");
            }
            if (PropertyExists("maxCrew"))
            {
                xmltextlines.Add("<maxCrew attr1=\"" + _maxCrew.ToString() + "\"/>");
            }
            if (PropertyExists("energyProductionModifier"))
            {
                xmltextlines.Add("<energyProductionModifier attr1=\"" + _energyProductionModifier.ToString() + "\"/>");
            }
            if (PropertyExists("foodProductionModifier"))
            {
                xmltextlines.Add("<foodProductionModifier attr1=\"" + _foodProductionModifier.ToString() + "\"/>");
            }
            if (PropertyExists("weaponsProductionModifier"))
            {
                xmltextlines.Add("<weaponsProductionModifier attr1=\"" + _weaponsProductionModifier.ToString() + "\"/>");
            }
            if (PropertyExists("narcoticsProductionModifier"))
            {
                xmltextlines.Add("<narcoticsProductionModifier attr1=\"" + _narcoticsProductionModifier.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanResearch"))
            {
                xmltextlines.Add("<bCanResearch attr1=\"" + ((_bCanResearch) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bMobile"))
            {
                xmltextlines.Add("<bMobile attr1=\"" + ((_bMobile) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoLargeHangarInterior"))
            {
                xmltextlines.Add("<bNoLargeHangarInterior attr1=\"" + ((_bNoLargeHangarInterior) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoRemoteControlInterior"))
            {
                xmltextlines.Add("<bNoRemoteControlInterior attr1=\"" + ((_bNoRemoteControlInterior) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("dockingArms"))
            {
                xmltextlines.Add("<dockingArms x=\"" + _dockingArms.x.ToString() + "\" y=\"" + _dockingArms.y.ToString() + "\" z=\"" + _dockingArms.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockingArmsEnd"))
            {
                xmltextlines.Add("<dockingArmsEnd x=\"" + _dockingArmsEnd.x.ToString() + "\" y=\"" + _dockingArmsEnd.y.ToString() + "\" z=\"" + _dockingArmsEnd.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockPosition"))
            {
                xmltextlines.Add("<dockPosition x=\"" + _dockPosition.x.ToString() + "\" y=\"" + _dockPosition.y.ToString() + "\" z=\"" + _dockPosition.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockSize"))
            {
                xmltextlines.Add("<dockSize x=\"" + _dockSize.x.ToString() + "\" y=\"" + _dockSize.y.ToString() + "\" z=\"" + _dockSize.z.ToString() + "\"/>");
            }
            if (PropertyExists("miningPlatformPosition"))
            {
                xmltextlines.Add("<miningPlatformPosition x=\"" + _miningPlatformPosition.x.ToString() + "\" y=\"" + _miningPlatformPosition.y.ToString() + "\" z=\"" + _miningPlatformPosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("largeDock"))
            {
                xmltextlines.AddRange(_largeDock.AsVD2XML());
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("propulsion"))
            {
                foreach (propulsionDataStructure result in _propulsion)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("physicalRotatingElement"))
            {
                foreach (physicalRotatingElementDataStructure result in _physicalRotatingElement)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("alwaysOnEffect"))
            {
                foreach (alwaysOnEffectDataStructure result in _alwaysOnEffect)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
