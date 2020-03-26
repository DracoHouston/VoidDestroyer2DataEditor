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
        int _rockSubPosition;
        int _energyUpKeep;
        int _oreUpKeep;
        int _noUpKeepNumber;

        float _health;
        float _buildTimeCost;

        bool _bCommsOverride;
        bool _isMassInfinite;
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

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("faction is a plaintext string"), Category("Plaintext Strings")]
        public string faction
        {
            get => _faction;
            set => _faction = value;
        }

        [Description("stationClass is a plaintext string"), Category("Plaintext Strings")]
        public string stationClass
        {
            get => _stationClass;
            set => _stationClass = value;
        }

        [Description("stationSizeAsShip is a plaintext string"), Category("Plaintext Strings")]
        public string stationSizeAsShip
        {
            get => _stationSizeAsShip;
            set => _stationSizeAsShip = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings")]
        public string wireframeMaterial
        {
            get => _wireframeMaterial;
            set => _wireframeMaterial = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings")]
        public string tacticalExplosionID
        {
            get => _tacticalExplosionID;
            set => _tacticalExplosionID = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("resourceProduced is a plaintext string"), Category("Plaintext Strings")]
        public string resourceProduced
        {
            get => _resourceProduced;
            set => _resourceProduced = value;
        }

        [Description("displayName is a plaintext string"), Category("Plaintext Strings")]
        public string displayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings")]
        public string hangarID
        {
            get => _hangarID;
            set => _hangarID = value;
        }

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings")]
        public string shieldID
        {
            get => _shieldID;
            set => _shieldID = value;
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings")]
        public string collisionMeshName
        {
            get => _collisionMeshName;
            set => _collisionMeshName = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> descriptionText
        {
            get => _descriptionText;
            set => _descriptionText = value;
        }

        [Description("noteToSelf is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> noteToSelf
        {
            get => _noteToSelf;
            set => _noteToSelf = value;
        }


        [Description("creditCost is an integer"), Category("Integers")]
        public int creditCost
        {
            get => _creditCost;
            set => _creditCost = value;
        }

        [Description("rockSubPosition is an integer"), Category("Integers")]
        public int rockSubPosition
        {
            get => _rockSubPosition;
            set => _rockSubPosition = value;
        }

        [Description("energyUpKeep is an integer"), Category("Integers")]
        public int energyUpKeep
        {
            get => _energyUpKeep;
            set => _energyUpKeep = value;
        }

        [Description("oreUpKeep is an integer"), Category("Integers")]
        public int oreUpKeep
        {
            get => _oreUpKeep;
            set => _oreUpKeep = value;
        }

        [Description("noUpKeepNumber is an integer"), Category("Integers")]
        public int noUpKeepNumber
        {
            get => _noUpKeepNumber;
            set => _noUpKeepNumber = value;
        }


        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
        }

        [Description("buildTimeCost is a real number"), Category("Real Numbers")]
        public float buildTimeCost
        {
            get => _buildTimeCost;
            set => _buildTimeCost = value;
        }


        [Description("bCommsOverride is a boolean value"), Category("Booleans")]
        public bool bCommsOverride
        {
            get => _bCommsOverride;
            set => _bCommsOverride = value;
        }

        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }

        [Description("bBaseDefenseOverride is a boolean value"), Category("Booleans")]
        public bool bBaseDefenseOverride
        {
            get => _bBaseDefenseOverride;
            set => _bBaseDefenseOverride = value;
        }

        [Description("bFarBuild is a boolean value"), Category("Booleans")]
        public bool bFarBuild
        {
            get => _bFarBuild;
            set => _bFarBuild = value;
        }

        [Description("bBaseBuildOverride is a boolean value"), Category("Booleans")]
        public bool bBaseBuildOverride
        {
            get => _bBaseBuildOverride;
            set => _bBaseBuildOverride = value;
        }

        [Description("bCommonPlatform is a boolean value"), Category("Booleans")]
        public bool bCommonPlatform
        {
            get => _bCommonPlatform;
            set => _bCommonPlatform = value;
        }

        [Description("bLocalBuild is a boolean value"), Category("Booleans")]
        public bool bLocalBuild
        {
            get => _bLocalBuild;
            set => _bLocalBuild = value;
        }

        [Description("bStartGate is a boolean value"), Category("Booleans")]
        public bool bStartGate
        {
            get => _bStartGate;
            set => _bStartGate = value;
        }

        [Description("bEndGate is a boolean value"), Category("Booleans")]
        public bool bEndGate
        {
            get => _bEndGate;
            set => _bEndGate = value;
        }

        [Description("bAccelerator is a boolean value"), Category("Booleans")]
        public bool bAccelerator
        {
            get => _bAccelerator;
            set => _bAccelerator = value;
        }


        [Description("dockingArms is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockingArms
        {
            get => _dockingArms;
            set => _dockingArms = value;
        }

        [Description("dockingArmsEnd is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockingArmsEnd
        {
            get => _dockingArmsEnd;
            set => _dockingArmsEnd = value;
        }


        [Description("debrisInfo is a datastructure"), Category("Data Structures")]
        public debrisInfoDataStructure debrisInfo
        {
            get => _debrisInfo;
            set => _debrisInfo = value;
        }

        [Description("refuelArea is a datastructure"), Category("Data Structures")]
        public refuelAreaDataStructure refuelArea
        {
            get => _refuelArea;
            set => _refuelArea = value;
        }

        [Description("alwaysOnEffect is a datastructure"), Category("Data Structures")]
        public alwaysOnEffectDataStructure alwaysOnEffect
        {
            get => _alwaysOnEffect;
            set => _alwaysOnEffect = value;
        }

        [Description("repairArea is a datastructure"), Category("Data Structures")]
        public repairAreaDataStructure repairArea
        {
            get => _repairArea;
            set => _repairArea = value;
        }


        [Description("attachment is a collection of datastructures"), Category("Data Structure Collections")]
        public List<attachmentDataStructure> attachment
        {
            get => _attachment;
            set => _attachment = value;
        }

        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get => _turret;
            set => _turret = value;
        }

        [Description("physicalRotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<physicalRotatingElementDataStructure> physicalRotatingElement
        {
            get => _physicalRotatingElement;
            set => _physicalRotatingElement = value;
        }

        [Description("mine is a collection of datastructures"), Category("Data Structure Collections")]
        public List<mineDataStructure> mine
        {
            get => _mine;
            set => _mine = value;
        }


        public StationData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction");
                _stationClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationClass");
                _stationSizeAsShip = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "stationSizeAsShip");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID");
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape");
                _resourceProduced = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "resourceProduced");
                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName");
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID");
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID");
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName");

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");
                _noteToSelf = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "noteToSelf");

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost");
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition");
                _energyUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "energyUpKeep");
                _oreUpKeep = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "oreUpKeep");
                _noUpKeepNumber = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "noUpKeepNumber");

                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");
                _buildTimeCost = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTimeCost");

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride");
                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");
                _bBaseDefenseOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseDefenseOverride");
                _bFarBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFarBuild");
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride");
                _bCommonPlatform = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommonPlatform");
                _bLocalBuild = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLocalBuild");
                _bStartGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bStartGate");
                _bEndGate = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEndGate");
                _bAccelerator = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAccelerator");

                _dockingArms = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArms");
                _dockingArmsEnd = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "dockingArmsEnd");

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(DataXMLDoc);
                _refuelArea = DataStructureParseHelpers.GetrefuelAreaDataStructureFromVD2Data(DataXMLDoc);
                _alwaysOnEffect = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromVD2Data(DataXMLDoc);
                _repairArea = DataStructureParseHelpers.GetrepairAreaDataStructureFromVD2Data(DataXMLDoc);

                _attachment = DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(DataXMLDoc);
                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc);
                _physicalRotatingElement = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureListFromVD2Data(DataXMLDoc);
                _mine = DataStructureParseHelpers.GetmineDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
