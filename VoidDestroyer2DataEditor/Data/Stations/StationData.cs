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
    class StationData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _faction;
        string _stationClass;
        string _stationSizeAsShip;
        string _meshName;
        string _wireframeMaterial;
        string _explosionID;
        string _tacticalExplosionID;
        string _collisionShape;
        string _resourceProduced;
        string _displayName;
        string _hangarID;
        string _shieldID;
        string _collisionMeshName;

        List<string> _descriptionText;
        List<string> _noteToSelf;

        int _creditCost;
        int _isMassInfinite;
        int _rockSubPosition;
        int _energyUpKeep;
        int _oreUpKeep;
        int _noUpKeepNumber;

        float _health;
        float _buildTimeCost;

        bool _bCommsOverride;
        bool _bBaseDefenseOverride;
        bool _bFarBuild;
        bool _bBaseBuildOverride;
        bool _bCommonPlatform;
        bool _bLocalBuild;
        bool _bStartGate;
        bool _bEndGate;
        bool _bAccelerator;

        Vector3D _dockingArms;
        Vector3D _dockingArmsEnd;

        debrisInfoDataStructure _debrisInfo;
        refuelAreaDataStructure _refuelArea;
        alwaysOnEffectDataStructure _alwaysOnEffect;
        repairAreaDataStructure _repairArea;

        List<attachmentDataStructure> _attachment;
        List<turretDataStructure> _turret;
        List<physicalRotatingElementDataStructure> _physicalRotatingElement;
        List<mineDataStructure> _mine;

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

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get
            {
                return _faction;
            }
            set
            {
                _faction = value;
                SetPropertyEdited("faction", true);
            }
        }

        [Description("stationClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string stationClass
        {
            get
            {
                return _stationClass;
            }
            set
            {
                _stationClass = value;
                SetPropertyEdited("stationClass", true);
            }
        }

        [Description("stationSizeAsShip is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string stationSizeAsShip
        {
            get
            {
                return _stationSizeAsShip;
            }
            set
            {
                _stationSizeAsShip = value;
                SetPropertyEdited("stationSizeAsShip", true);
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
                _meshName = value;
                SetPropertyEdited("meshName", true);
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
                _wireframeMaterial = value;
                SetPropertyEdited("wireframeMaterial", true);
            }
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionID
        {
            get
            {
                return _explosionID;
            }
            set
            {
                _explosionID = value;
                SetPropertyEdited("explosionID", true);
            }
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tacticalExplosionID
        {
            get
            {
                return _tacticalExplosionID;
            }
            set
            {
                _tacticalExplosionID = value;
                SetPropertyEdited("tacticalExplosionID", true);
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
                _collisionShape = value;
                SetPropertyEdited("collisionShape", true);
            }
        }

        [Description("resourceProduced is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string resourceProduced
        {
            get
            {
                return _resourceProduced;
            }
            set
            {
                _resourceProduced = value;
                SetPropertyEdited("resourceProduced", true);
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
                _displayName = value;
                SetPropertyEdited("displayName", true);
            }
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                _hangarID = value;
                SetPropertyEdited("hangarID", true);
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

        [Description("noteToSelf is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> noteToSelf
        {
            get
            {
                return _noteToSelf;
            }
            set
            {
                _noteToSelf = value;
                SetPropertyEdited("noteToSelf", true);
            }
        }


        [Description("creditCost is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int creditCost
        {
            get
            {
                return _creditCost;
            }
            set
            {
                _creditCost = value;
                SetPropertyEdited("creditCost", true);
            }
        }

        [Description("isMassInfinite is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int isMassInfinite
        {
            get
            {
                return _isMassInfinite;
            }
            set
            {
                _isMassInfinite = value;
                SetPropertyEdited("isMassInfinite", true);
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
                _rockSubPosition = value;
                SetPropertyEdited("rockSubPosition", true);
            }
        }

        [Description("energyUpKeep is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int energyUpKeep
        {
            get
            {
                return _energyUpKeep;
            }
            set
            {
                _energyUpKeep = value;
                SetPropertyEdited("energyUpKeep", true);
            }
        }

        [Description("oreUpKeep is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int oreUpKeep
        {
            get
            {
                return _oreUpKeep;
            }
            set
            {
                _oreUpKeep = value;
                SetPropertyEdited("oreUpKeep", true);
            }
        }

        [Description("noUpKeepNumber is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int noUpKeepNumber
        {
            get
            {
                return _noUpKeepNumber;
            }
            set
            {
                _noUpKeepNumber = value;
                SetPropertyEdited("noUpKeepNumber", true);
            }
        }


        [Description("health is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                SetPropertyEdited("health", true);
            }
        }

        [Description("buildTimeCost is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float buildTimeCost
        {
            get
            {
                return _buildTimeCost;
            }
            set
            {
                _buildTimeCost = value;
                SetPropertyEdited("buildTimeCost", true);
            }
        }


        [Description("bCommsOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommsOverride
        {
            get
            {
                return _bCommsOverride;
            }
            set
            {
                _bCommsOverride = value;
                SetPropertyEdited("bCommsOverride", true);
            }
        }

        [Description("bBaseDefenseOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bBaseDefenseOverride
        {
            get
            {
                return _bBaseDefenseOverride;
            }
            set
            {
                _bBaseDefenseOverride = value;
                SetPropertyEdited("bBaseDefenseOverride", true);
            }
        }

        [Description("bFarBuild is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFarBuild
        {
            get
            {
                return _bFarBuild;
            }
            set
            {
                _bFarBuild = value;
                SetPropertyEdited("bFarBuild", true);
            }
        }

        [Description("bBaseBuildOverride is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bBaseBuildOverride
        {
            get
            {
                return _bBaseBuildOverride;
            }
            set
            {
                _bBaseBuildOverride = value;
                SetPropertyEdited("bBaseBuildOverride", true);
            }
        }

        [Description("bCommonPlatform is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCommonPlatform
        {
            get
            {
                return _bCommonPlatform;
            }
            set
            {
                _bCommonPlatform = value;
                SetPropertyEdited("bCommonPlatform", true);
            }
        }

        [Description("bLocalBuild is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLocalBuild
        {
            get
            {
                return _bLocalBuild;
            }
            set
            {
                _bLocalBuild = value;
                SetPropertyEdited("bLocalBuild", true);
            }
        }

        [Description("bStartGate is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bStartGate
        {
            get
            {
                return _bStartGate;
            }
            set
            {
                _bStartGate = value;
                SetPropertyEdited("bStartGate", true);
            }
        }

        [Description("bEndGate is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bEndGate
        {
            get
            {
                return _bEndGate;
            }
            set
            {
                _bEndGate = value;
                SetPropertyEdited("bEndGate", true);
            }
        }

        [Description("bAccelerator is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAccelerator
        {
            get
            {
                return _bAccelerator;
            }
            set
            {
                _bAccelerator = value;
                SetPropertyEdited("bAccelerator", true);
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
                _dockingArms = value;
                SetPropertyEdited("dockingArms", true);
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
                _dockingArmsEnd = value;
                SetPropertyEdited("dockingArmsEnd", true);
            }
        }


        [Description("debrisInfo is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public debrisInfoDataStructure debrisInfo
        {
            get
            {
                return _debrisInfo;
            }
            set
            {
                _debrisInfo = value;
                SetPropertyEdited("debrisInfo", true);
            }
        }

        [Description("refuelArea is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public refuelAreaDataStructure refuelArea
        {
            get
            {
                return _refuelArea;
            }
            set
            {
                _refuelArea = value;
                SetPropertyEdited("refuelArea", true);
            }
        }

        [Description("alwaysOnEffect is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public alwaysOnEffectDataStructure alwaysOnEffect
        {
            get
            {
                return _alwaysOnEffect;
            }
            set
            {
                _alwaysOnEffect = value;
                SetPropertyEdited("alwaysOnEffect", true);
            }
        }

        [Description("repairArea is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public repairAreaDataStructure repairArea
        {
            get
            {
                return _repairArea;
            }
            set
            {
                _repairArea = value;
                SetPropertyEdited("repairArea", true);
            }
        }


        [Description("attachment is a collection of datastructures"), Category("Data Structure Collections")]
        public List<attachmentDataStructure> attachment
        {
            get
            {
                return _attachment;
            }
            set
            {
                _attachment = value;
                SetPropertyEdited("attachment", true);
            }
        }

        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                _turret = value;
                SetPropertyEdited("turret", true);
            }
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get
            {
                return _physicalRotatingElement;
            }
            set
            {
                _physicalRotatingElement = value;
                SetPropertyEdited("physicalRotatingElement", true);
            }
        }

        [Description("mine is a collection of datastructures"), Category("Data Structure Collections")]
        public List<mineDataStructure> mine
        {
            get
            {
                return _mine;
            }
            set
            {
                _mine = value;
                SetPropertyEdited("mine", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("faction");
            InitProperty("stationClass");
            InitProperty("stationSizeAsShip");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("explosionID");
            InitProperty("tacticalExplosionID");
            InitProperty("collisionShape");
            InitProperty("resourceProduced");
            InitProperty("displayName");
            InitProperty("hangarID");
            InitProperty("shieldID");
            InitProperty("collisionMeshName");

            InitProperty("descriptionText");
            InitProperty("noteToSelf");

            InitProperty("creditCost");
            InitProperty("isMassInfinite");
            InitProperty("rockSubPosition");
            InitProperty("energyUpKeep");
            InitProperty("oreUpKeep");
            InitProperty("noUpKeepNumber");

            InitProperty("health");
            InitProperty("buildTimeCost");

            InitProperty("bCommsOverride");
            InitProperty("bBaseDefenseOverride");
            InitProperty("bFarBuild");
            InitProperty("bBaseBuildOverride");
            InitProperty("bCommonPlatform");
            InitProperty("bLocalBuild");
            InitProperty("bStartGate");
            InitProperty("bEndGate");
            InitProperty("bAccelerator");

            InitProperty("dockingArms");
            InitProperty("dockingArmsEnd");

            InitProperty("debrisInfo");
            InitProperty("refuelArea");
            InitProperty("alwaysOnEffect");
            InitProperty("repairArea");

            InitProperty("attachment");
            InitProperty("turret");
            InitProperty("physicalRotatingElement");
            InitProperty("mine");
        }

        public StationData(string inPath) : base(inPath)
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
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                SetPropertyExistsInBaseData("faction", exists);
                SetPropertyExists("faction", exists);
                _stationClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationClass", out exists);
                SetPropertyExistsInBaseData("stationClass", exists);
                SetPropertyExists("stationClass", exists);
                _stationSizeAsShip = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationSizeAsShip", out exists);
                SetPropertyExistsInBaseData("stationSizeAsShip", exists);
                SetPropertyExists("stationSizeAsShip", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                SetPropertyExists("tacticalExplosionID", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _resourceProduced = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "resourceProduced", out exists);
                SetPropertyExistsInBaseData("resourceProduced", exists);
                SetPropertyExists("resourceProduced", exists);
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                SetPropertyExistsInBaseData("displayName", exists);
                SetPropertyExists("displayName", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                SetPropertyExistsInBaseData("shieldID", exists);
                SetPropertyExists("shieldID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                SetPropertyExistsInBaseData("collisionMeshName", exists);
                SetPropertyExists("collisionMeshName", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);
                _noteToSelf = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "noteToSelf", out exists);
                SetPropertyExistsInBaseData("noteToSelf", exists);
                SetPropertyExists("noteToSelf", exists);

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost", out exists);
                SetPropertyExistsInBaseData("creditCost", exists);
                SetPropertyExists("creditCost", exists);
                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                SetPropertyExistsInBaseData("rockSubPosition", exists);
                SetPropertyExists("rockSubPosition", exists);
                _energyUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "energyUpKeep", out exists);
                SetPropertyExistsInBaseData("energyUpKeep", exists);
                SetPropertyExists("energyUpKeep", exists);
                _oreUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "oreUpKeep", out exists);
                SetPropertyExistsInBaseData("oreUpKeep", exists);
                SetPropertyExists("oreUpKeep", exists);
                _noUpKeepNumber = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "noUpKeepNumber", out exists);
                SetPropertyExistsInBaseData("noUpKeepNumber", exists);
                SetPropertyExists("noUpKeepNumber", exists);

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);
                _buildTimeCost = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTimeCost", out exists);
                SetPropertyExistsInBaseData("buildTimeCost", exists);
                SetPropertyExists("buildTimeCost", exists);

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride", out exists);
                SetPropertyExistsInBaseData("bCommsOverride", exists);
                SetPropertyExists("bCommsOverride", exists);
                _bBaseDefenseOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseDefenseOverride", out exists);
                SetPropertyExistsInBaseData("bBaseDefenseOverride", exists);
                SetPropertyExists("bBaseDefenseOverride", exists);
                _bFarBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFarBuild", out exists);
                SetPropertyExistsInBaseData("bFarBuild", exists);
                SetPropertyExists("bFarBuild", exists);
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride", out exists);
                SetPropertyExistsInBaseData("bBaseBuildOverride", exists);
                SetPropertyExists("bBaseBuildOverride", exists);
                _bCommonPlatform = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonPlatform", out exists);
                SetPropertyExistsInBaseData("bCommonPlatform", exists);
                SetPropertyExists("bCommonPlatform", exists);
                _bLocalBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLocalBuild", out exists);
                SetPropertyExistsInBaseData("bLocalBuild", exists);
                SetPropertyExists("bLocalBuild", exists);
                _bStartGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bStartGate", out exists);
                SetPropertyExistsInBaseData("bStartGate", exists);
                SetPropertyExists("bStartGate", exists);
                _bEndGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEndGate", out exists);
                SetPropertyExistsInBaseData("bEndGate", exists);
                SetPropertyExists("bEndGate", exists);
                _bAccelerator = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAccelerator", out exists);
                SetPropertyExistsInBaseData("bAccelerator", exists);
                SetPropertyExists("bAccelerator", exists);

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms", out exists);
                SetPropertyExistsInBaseData("dockingArms", exists);
                SetPropertyExists("dockingArms", exists);
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd", out exists);
                SetPropertyExistsInBaseData("dockingArmsEnd", exists);
                SetPropertyExists("dockingArmsEnd", exists);

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("debrisInfo", exists);
                SetPropertyExists("debrisInfo", exists);
                _refuelArea = DataStructureParseHelpers.GetrefuelAreaDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("refuelArea", exists);
                SetPropertyExists("refuelArea", exists);
                _alwaysOnEffect = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("alwaysOnEffect", exists);
                SetPropertyExists("alwaysOnEffect", exists);
                _repairArea = DataStructureParseHelpers.GetrepairAreaDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("repairArea", exists);
                SetPropertyExists("repairArea", exists);

                _attachment = DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("attachment", exists);
                SetPropertyExists("attachment", exists);
                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("turret", exists);
                SetPropertyExists("turret", exists);
                _physicalRotatingElement = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("physicalRotatingElement", exists);
                SetPropertyExists("physicalRotatingElement", exists);
                _mine = DataStructureParseHelpers.GetmineDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("mine", exists);
                SetPropertyExists("mine", exists);
            }
        }
    }
}
