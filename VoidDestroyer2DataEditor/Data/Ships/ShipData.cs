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
    class ShipData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _faction;
        string _shipClass;
        string _meshName;
        string _explosionID;
        string _tacticalExplosionID;
        string _engineSoundID;
        string _propulsionRibbonID;
        string _collisionShape;
        string _wireframeMaterial;
        string _cockpitActualMesh;
        string _shipClassSize;
        string _soldByFaction;
        string _cockpitID;
        string _collisionMeshName;
        string _sizeShipClass;
        string _combatAIClass;
        string _minimumMiningRoidSize;
        string _hangarID;
        string _gravityDriveParticleSystem;
        string _selfDestructAreaOfEffectID;
        string _towardsEnemy;
        string _baseID;

        List<string> _descriptionText;
        List<string> _preExplosionID;

        int _creditCost;
        int _shipHangarYOffset;
        int _rockSubPosition;
        int _missionRankRequired;
        int _discoveryRange;
        int _detectionRange;
        int _shieldHealth;
        int _captureRating;
        int _aggressiveRange;
        int _passangerCapacity;

        float _cruiseSpeed;
        float _timeTillCruise;
        float _yaw;
        float _pitch;
        float _roll;
        float _health;
        float _buildTime;
        float _crew;
        float _energy;
        float _ore;
        float _deathTimer;
        float _armor;

        bool _bCommsOverride;
        bool _bGravityDrive;
        bool _isMassInfinite;
        bool _bHideShipInCockpitAcutal;
        bool _bPlayerSharedFire;
        bool _bNotSoldUnlessOwnedBase;
        bool _bBlackMarket;
        bool _bUniqueShip;
        bool _bShowInCockpitParticles;
        bool _bRequiresKnowledge;
        bool _bListedNoPurchase;
        bool _bLargeHangarOnly;
        bool _bNoTargetAimNodeOffset;
        bool _bEveryShipyardOk;
        bool _bShowInCockpitWeaponParticles;
        bool _boardingCrew;
        bool _bBaseBuildOverride;
        bool _bSaveFileUnlockShip;
        bool _bLargeDockOnly;
        bool _bCanPurchase;
        bool _bNoShipyardRequirement;

        Vector3D _cockpitInitPos;
        Vector3D _cockpitTransLimit;
        Vector3D _chaseInitPos;
        Vector3D _chaseTransLimit;
        Vector3D _deathSpin;
        Vector3D _cockpitActualPos;
        Vector3D _shipHangarPosition;

        debrisInfoDataStructure _debrisInfo;
        afterburnerDataStructure _afterburner;
        targetPriorityListDataStructure _targetPriorityList;
        upgradesDataStructure _upgrades;

        List<propulsionDataStructure> _propulsion;
        List<weaponDataStructure> _weapon;
        List<damageDataStructure> _damage;
        List<turretDataStructure> _turret;
        List<attachmentDataStructure> _attachment;
        List<movingElementDataStructure> _movingElement;
        List<dockDataStructure> _dock;
        List<shieldDataStructure> _shield;
        List<rotatingElementDataStructure> _rotatingElement;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                SetPropertyEdited("objectType", true);
                _objectType = value;
            }
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get => _faction;
            set => _faction = value;
        }

        [Description("shipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipClass
        {
            get => _shipClass;
            set => _shipClass = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tacticalExplosionID
        {
            get => _tacticalExplosionID;
            set => _tacticalExplosionID = value;
        }

        [Description("engineSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string engineSoundID
        {
            get => _engineSoundID;
            set => _engineSoundID = value;
        }

        [Description("propulsionRibbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string propulsionRibbonID
        {
            get => _propulsionRibbonID;
            set => _propulsionRibbonID = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wireframeMaterial
        {
            get => _wireframeMaterial;
            set => _wireframeMaterial = value;
        }

        [Description("cockpitActualMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cockpitActualMesh
        {
            get => _cockpitActualMesh;
            set => _cockpitActualMesh = value;
        }

        [Description("shipClassSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipClassSize
        {
            get => _shipClassSize;
            set => _shipClassSize = value;
        }

        [Description("soldByFaction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soldByFaction
        {
            get => _soldByFaction;
            set => _soldByFaction = value;
        }

        [Description("cockpitID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cockpitID
        {
            get => _cockpitID;
            set => _cockpitID = value;
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionMeshName
        {
            get => _collisionMeshName;
            set => _collisionMeshName = value;
        }

        [Description("sizeShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sizeShipClass
        {
            get => _sizeShipClass;
            set => _sizeShipClass = value;
        }

        [Description("combatAIClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string combatAIClass
        {
            get => _combatAIClass;
            set => _combatAIClass = value;
        }

        [Description("minimumMiningRoidSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string minimumMiningRoidSize
        {
            get => _minimumMiningRoidSize;
            set => _minimumMiningRoidSize = value;
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hangarID
        {
            get => _hangarID;
            set => _hangarID = value;
        }

        [Description("gravityDriveParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gravityDriveParticleSystem
        {
            get => _gravityDriveParticleSystem;
            set => _gravityDriveParticleSystem = value;
        }

        [Description("selfDestructAreaOfEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string selfDestructAreaOfEffectID
        {
            get => _selfDestructAreaOfEffectID;
            set => _selfDestructAreaOfEffectID = value;
        }

        [Description("towardsEnemy is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string towardsEnemy
        {
            get => _towardsEnemy;
            set => _towardsEnemy = value;
        }

        [Description("baseID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string baseID
        {
            get => _baseID;
            set => _baseID = value;
        }


        [Description("descriptionText is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor(typeof(VD2CollectionEditor), typeof(System.ComponentModel.Design.CollectionEditor))]
        public List<string> descriptionText
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

        [Description("preExplosionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor(typeof(VD2CollectionEditor), typeof(System.ComponentModel.Design.CollectionEditor))]
        public List<string> preExplosionID
        {
            get => _preExplosionID;
            set => _preExplosionID = value;
        }


        [Description("creditCost is an integer"), Category("Integers")]
        public int creditCost
        {
            get => _creditCost;
            set => _creditCost = value;
        }

        [Description("shipHangarYOffset is an integer"), Category("Integers")]
        public int shipHangarYOffset
        {
            get => _shipHangarYOffset;
            set => _shipHangarYOffset = value;
        }

        [Description("rockSubPosition is an integer"), Category("Integers")]
        public int rockSubPosition
        {
            get => _rockSubPosition;
            set => _rockSubPosition = value;
        }

        [Description("missionRankRequired is an integer"), Category("Integers")]
        public int missionRankRequired
        {
            get => _missionRankRequired;
            set => _missionRankRequired = value;
        }

        [Description("discoveryRange is an integer"), Category("Integers")]
        public int discoveryRange
        {
            get => _discoveryRange;
            set => _discoveryRange = value;
        }

        [Description("detectionRange is an integer"), Category("Integers")]
        public int detectionRange
        {
            get => _detectionRange;
            set => _detectionRange = value;
        }

        [Description("shieldHealth is an integer"), Category("Integers")]
        public int shieldHealth
        {
            get => _shieldHealth;
            set => _shieldHealth = value;
        }

        [Description("captureRating is an integer"), Category("Integers")]
        public int captureRating
        {
            get => _captureRating;
            set => _captureRating = value;
        }

        [Description("aggressiveRange is an integer"), Category("Integers")]
        public int aggressiveRange
        {
            get => _aggressiveRange;
            set => _aggressiveRange = value;
        }

        [Description("passangerCapacity is an integer"), Category("Integers")]
        public int passangerCapacity
        {
            get => _passangerCapacity;
            set => _passangerCapacity = value;
        }


        [Description("cruiseSpeed is a real number"), Category("Real Numbers")]
        public float cruiseSpeed
        {
            get => _cruiseSpeed;
            set => _cruiseSpeed = value;
        }

        [Description("timeTillCruise is a real number"), Category("Real Numbers")]
        public float timeTillCruise
        {
            get => _timeTillCruise;
            set => _timeTillCruise = value;
        }

        [Description("yaw is a real number"), Category("Real Numbers")]
        public float yaw
        {
            get => _yaw;
            set => _yaw = value;
        }

        [Description("pitch is a real number"), Category("Real Numbers")]
        public float pitch
        {
            get => _pitch;
            set => _pitch = value;
        }

        [Description("roll is a real number"), Category("Real Numbers")]
        public float roll
        {
            get => _roll;
            set => _roll = value;
        }

        [Description("health is a real number"), Category("Real Numbers")]
        public float health
        {
            get => _health;
            set => _health = value;
        }

        [Description("buildTime is a real number"), Category("Real Numbers")]
        public float buildTime
        {
            get => _buildTime;
            set => _buildTime = value;
        }

        [Description("crew is a real number"), Category("Real Numbers")]
        public float crew
        {
            get => _crew;
            set => _crew = value;
        }

        [Description("energy is a real number"), Category("Real Numbers")]
        public float energy
        {
            get => _energy;
            set => _energy = value;
        }

        [Description("ore is a real number"), Category("Real Numbers")]
        public float ore
        {
            get => _ore;
            set => _ore = value;
        }

        [Description("deathTimer is a real number"), Category("Real Numbers")]
        public float deathTimer
        {
            get => _deathTimer;
            set => _deathTimer = value;
        }

        [Description("armor is a real number"), Category("Real Numbers")]
        public float armor
        {
            get => _armor;
            set => _armor = value;
        }


        [Description("bCommsOverride is a boolean value"), Category("Booleans")]
        public bool bCommsOverride
        {
            get => _bCommsOverride;
            set => _bCommsOverride = value;
        }

        [Description("bGravityDrive is a boolean value"), Category("Booleans")]
        public bool bGravityDrive
        {
            get => _bGravityDrive;
            set => _bGravityDrive = value;
        }

        [Description("isMassInfinite is a boolean value"), Category("Booleans")]
        public bool isMassInfinite
        {
            get => _isMassInfinite;
            set => _isMassInfinite = value;
        }

        [Description("bHideShipInCockpitAcutal is a boolean value"), Category("Booleans")]
        public bool bHideShipInCockpitAcutal
        {
            get => _bHideShipInCockpitAcutal;
            set => _bHideShipInCockpitAcutal = value;
        }

        [Description("bPlayerSharedFire is a boolean value"), Category("Booleans")]
        public bool bPlayerSharedFire
        {
            get => _bPlayerSharedFire;
            set => _bPlayerSharedFire = value;
        }

        [Description("bNotSoldUnlessOwnedBase is a boolean value"), Category("Booleans")]
        public bool bNotSoldUnlessOwnedBase
        {
            get => _bNotSoldUnlessOwnedBase;
            set => _bNotSoldUnlessOwnedBase = value;
        }

        [Description("bBlackMarket is a boolean value"), Category("Booleans")]
        public bool bBlackMarket
        {
            get => _bBlackMarket;
            set => _bBlackMarket = value;
        }

        [Description("bUniqueShip is a boolean value"), Category("Booleans")]
        public bool bUniqueShip
        {
            get => _bUniqueShip;
            set => _bUniqueShip = value;
        }

        [Description("bShowInCockpitParticles is a boolean value"), Category("Booleans")]
        public bool bShowInCockpitParticles
        {
            get => _bShowInCockpitParticles;
            set => _bShowInCockpitParticles = value;
        }

        [Description("bRequiresKnowledge is a boolean value"), Category("Booleans")]
        public bool bRequiresKnowledge
        {
            get => _bRequiresKnowledge;
            set => _bRequiresKnowledge = value;
        }

        [Description("bListedNoPurchase is a boolean value"), Category("Booleans")]
        public bool bListedNoPurchase
        {
            get => _bListedNoPurchase;
            set => _bListedNoPurchase = value;
        }

        [Description("bLargeHangarOnly is a boolean value"), Category("Booleans")]
        public bool bLargeHangarOnly
        {
            get => _bLargeHangarOnly;
            set => _bLargeHangarOnly = value;
        }

        [Description("bNoTargetAimNodeOffset is a boolean value"), Category("Booleans")]
        public bool bNoTargetAimNodeOffset
        {
            get => _bNoTargetAimNodeOffset;
            set => _bNoTargetAimNodeOffset = value;
        }

        [Description("bEveryShipyardOk is a boolean value"), Category("Booleans")]
        public bool bEveryShipyardOk
        {
            get => _bEveryShipyardOk;
            set => _bEveryShipyardOk = value;
        }

        [Description("bShowInCockpitWeaponParticles is a boolean value"), Category("Booleans")]
        public bool bShowInCockpitWeaponParticles
        {
            get => _bShowInCockpitWeaponParticles;
            set => _bShowInCockpitWeaponParticles = value;
        }

        [Description("boardingCrew is a boolean value"), Category("Booleans")]
        public bool boardingCrew
        {
            get => _boardingCrew;
            set => _boardingCrew = value;
        }

        [Description("bBaseBuildOverride is a boolean value"), Category("Booleans")]
        public bool bBaseBuildOverride
        {
            get => _bBaseBuildOverride;
            set => _bBaseBuildOverride = value;
        }

        [Description("bSaveFileUnlockShip is a boolean value"), Category("Booleans")]
        public bool bSaveFileUnlockShip
        {
            get => _bSaveFileUnlockShip;
            set => _bSaveFileUnlockShip = value;
        }

        [Description("bLargeDockOnly is a boolean value"), Category("Booleans")]
        public bool bLargeDockOnly
        {
            get => _bLargeDockOnly;
            set => _bLargeDockOnly = value;
        }

        [Description("bCanPurchase is a boolean value"), Category("Booleans")]
        public bool bCanPurchase
        {
            get => _bCanPurchase;
            set => _bCanPurchase = value;
        }

        [Description("bNoShipyardRequirement is a boolean value"), Category("Booleans")]
        public bool bNoShipyardRequirement
        {
            get => _bNoShipyardRequirement;
            set => _bNoShipyardRequirement = value;
        }


        [Description("cockpitInitPos is a 3D vector"), Category("3D Vectors")]
        public Vector3D cockpitInitPos
        {
            get => _cockpitInitPos;
            set => _cockpitInitPos = value;
        }

        [Description("cockpitTransLimit is a 3D vector"), Category("3D Vectors")]
        public Vector3D cockpitTransLimit
        {
            get => _cockpitTransLimit;
            set => _cockpitTransLimit = value;
        }

        [Description("chaseInitPos is a 3D vector"), Category("3D Vectors")]
        public Vector3D chaseInitPos
        {
            get => _chaseInitPos;
            set => _chaseInitPos = value;
        }

        [Description("chaseTransLimit is a 3D vector"), Category("3D Vectors")]
        public Vector3D chaseTransLimit
        {
            get => _chaseTransLimit;
            set => _chaseTransLimit = value;
        }

        [Description("deathSpin is a 3D vector"), Category("3D Vectors")]
        public Vector3D deathSpin
        {
            get => _deathSpin;
            set => _deathSpin = value;
        }

        [Description("cockpitActualPos is a 3D vector"), Category("3D Vectors")]
        public Vector3D cockpitActualPos
        {
            get => _cockpitActualPos;
            set => _cockpitActualPos = value;
        }

        [Description("shipHangarPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D shipHangarPosition
        {
            get => _shipHangarPosition;
            set => _shipHangarPosition = value;
        }


        [Description("debrisInfo is a datastructure"), Category("Data Structures")]
        public debrisInfoDataStructure debrisInfo
        {
            get => _debrisInfo;
            set => _debrisInfo = value;
        }

        [Description("afterburner is a datastructure"), Category("Data Structures")]
        public afterburnerDataStructure afterburner
        {
            get => _afterburner;
            set => _afterburner = value;
        }

        [Description("targetPriorityList is a datastructure"), Category("Data Structures")]
        public targetPriorityListDataStructure targetPriorityList
        {
            get => _targetPriorityList;
            set => _targetPriorityList = value;
        }

        [Description("upgrades is a datastructure"), Category("Data Structures")]
        public upgradesDataStructure upgrades
        {
            get => _upgrades;
            set => _upgrades = value;
        }


        [Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public List<propulsionDataStructure> propulsion
        {
            get => _propulsion;
            set => _propulsion = value;
        }

        [Description("weapon is a collection of datastructures"), Category("Data Structure Collections")]
        public List<weaponDataStructure> weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        [Description("damage is a collection of datastructures"), Category("Data Structure Collections")]
        public List<damageDataStructure> damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretDataStructure> turret
        {
            get => _turret;
            set => _turret = value;
        }

        [Description("attachment is a collection of datastructures"), Category("Data Structure Collections")]
        public List<attachmentDataStructure> attachment
        {
            get => _attachment;
            set => _attachment = value;
        }

        [Description("movingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<movingElementDataStructure> movingElement
        {
            get => _movingElement;
            set => _movingElement = value;
        }

        [Description("dock is a collection of datastructures"), Category("Data Structure Collections")]
        public List<dockDataStructure> dock
        {
            get => _dock;
            set => _dock = value;
        }

        [Description("shield is a collection of datastructures"), Category("Data Structure Collections")]
        public List<shieldDataStructure> shield
        {
            get => _shield;
            set => _shield = value;
        }

        [Description("rotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<rotatingElementDataStructure> rotatingElement
        {
            get => _rotatingElement;
            set => _rotatingElement = value;
        }


        public ShipData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                bool exists = false;
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                VD2PropertyInfos.Add("objectType", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("objectType", exists);
                SetPropertyExists("objectType", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                VD2PropertyInfos.Add("name", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                VD2PropertyInfos.Add("objectID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                VD2PropertyInfos.Add("faction", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("faction", exists);
                SetPropertyExists("faction", exists);
                _shipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClass", out exists);
                VD2PropertyInfos.Add("shipClass", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("shipClass", exists);
                SetPropertyExists("shipClass", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                VD2PropertyInfos.Add("meshName", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                VD2PropertyInfos.Add("explosionID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                VD2PropertyInfos.Add("tacticalExplosionID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                SetPropertyExists("tacticalExplosionID", exists);
                _engineSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "engineSoundID", out exists);
                VD2PropertyInfos.Add("engineSoundID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("engineSoundID", exists);
                SetPropertyExists("engineSoundID", exists);
                _propulsionRibbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "propulsionRibbonID", out exists);
                VD2PropertyInfos.Add("propulsionRibbonID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("propulsionRibbonID", exists);
                SetPropertyExists("propulsionRibbonID", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                VD2PropertyInfos.Add("collisionShape", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                VD2PropertyInfos.Add("wireframeMaterial", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _cockpitActualMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitActualMesh", out exists);
                VD2PropertyInfos.Add("cockpitActualMesh", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("cockpitActualMesh", exists);
                SetPropertyExists("cockpitActualMesh", exists);
                _shipClassSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClassSize", out exists);
                VD2PropertyInfos.Add("shipClassSize", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("shipClassSize", exists);
                SetPropertyExists("shipClassSize", exists);
                _soldByFaction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soldByFaction", out exists);
                VD2PropertyInfos.Add("soldByFaction", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("soldByFaction", exists);
                SetPropertyExists("soldByFaction", exists);
                _cockpitID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitID", out exists);
                VD2PropertyInfos.Add("cockpitID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("cockpitID", exists);
                SetPropertyExists("cockpitID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                VD2PropertyInfos.Add("collisionMeshName", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("collisionMeshName", exists);
                SetPropertyExists("collisionMeshName", exists);
                _sizeShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sizeShipClass", out exists);
                VD2PropertyInfos.Add("sizeShipClass", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("sizeShipClass", exists);
                SetPropertyExists("sizeShipClass", exists);
                _combatAIClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "combatAIClass", out exists);
                VD2PropertyInfos.Add("combatAIClass", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("combatAIClass", exists);
                SetPropertyExists("combatAIClass", exists);
                _minimumMiningRoidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumMiningRoidSize", out exists);
                VD2PropertyInfos.Add("minimumMiningRoidSize", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("minimumMiningRoidSize", exists);
                SetPropertyExists("minimumMiningRoidSize", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                VD2PropertyInfos.Add("hangarID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);
                _gravityDriveParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityDriveParticleSystem", out exists);
                VD2PropertyInfos.Add("gravityDriveParticleSystem", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("gravityDriveParticleSystem", exists);
                SetPropertyExists("gravityDriveParticleSystem", exists);
                _selfDestructAreaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selfDestructAreaOfEffectID", out exists);
                VD2PropertyInfos.Add("selfDestructAreaOfEffectID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("selfDestructAreaOfEffectID", exists);
                SetPropertyExists("selfDestructAreaOfEffectID", exists);
                _towardsEnemy = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "towardsEnemy", out exists);
                VD2PropertyInfos.Add("towardsEnemy", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("towardsEnemy", exists);
                SetPropertyExists("towardsEnemy", exists);
                _baseID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "baseID", out exists);
                VD2PropertyInfos.Add("baseID", new VD2PropertyInfo());
                SetPropertyExistsInBaseData("baseID", exists);
                SetPropertyExists("baseID", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText");
                _preExplosionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "preExplosionID");

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost");
                _shipHangarYOffset = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shipHangarYOffset");
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition");
                _missionRankRequired = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "missionRankRequired");
                _discoveryRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "discoveryRange");
                _detectionRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionRange");
                _shieldHealth = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealth");
                _captureRating = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "captureRating");
                _aggressiveRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "aggressiveRange");
                _passangerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "passangerCapacity");

                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed");
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise");
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw");
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch");
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll");
                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health");
                _buildTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTime");
                _crew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "crew");
                _energy = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energy");
                _ore = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ore");
                _deathTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "deathTimer");
                _armor = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armor");

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride");
                _bGravityDrive = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGravityDrive");
                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite");
                _bHideShipInCockpitAcutal = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHideShipInCockpitAcutal");
                _bPlayerSharedFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPlayerSharedFire");
                _bNotSoldUnlessOwnedBase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNotSoldUnlessOwnedBase");
                _bBlackMarket = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBlackMarket");
                _bUniqueShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUniqueShip");
                _bShowInCockpitParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitParticles");
                _bRequiresKnowledge = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresKnowledge");
                _bListedNoPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bListedNoPurchase");
                _bLargeHangarOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeHangarOnly");
                _bNoTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoTargetAimNodeOffset");
                _bEveryShipyardOk = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEveryShipyardOk");
                _bShowInCockpitWeaponParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitWeaponParticles");
                _boardingCrew = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "boardingCrew");
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride");
                _bSaveFileUnlockShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSaveFileUnlockShip");
                _bLargeDockOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeDockOnly");
                _bCanPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanPurchase");
                _bNoShipyardRequirement = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShipyardRequirement");

                _cockpitInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitInitPos");
                _cockpitTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitTransLimit");
                _chaseInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseInitPos");
                _chaseTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseTransLimit");
                _deathSpin = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathSpin");
                _cockpitActualPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitActualPos");
                _shipHangarPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "shipHangarPosition");

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(DataXMLDoc);
                _afterburner = DataStructureParseHelpers.GetafterburnerDataStructureFromVD2Data(DataXMLDoc);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(DataXMLDoc);
                _upgrades = DataStructureParseHelpers.GetupgradesDataStructureFromVD2Data(DataXMLDoc);

                _propulsion = DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(DataXMLDoc);
                _weapon = DataStructureParseHelpers.GetweaponDataStructureListFromVD2Data(DataXMLDoc);
                _damage = DataStructureParseHelpers.GetdamageDataStructureListFromVD2Data(DataXMLDoc);
                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc);
                _attachment = DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(DataXMLDoc);
                _movingElement = DataStructureParseHelpers.GetmovingElementDataStructureListFromVD2Data(DataXMLDoc);
                _dock = DataStructureParseHelpers.GetdockDataStructureListFromVD2Data(DataXMLDoc);
                _shield = DataStructureParseHelpers.GetshieldDataStructureListFromVD2Data(DataXMLDoc);
                _rotatingElement = DataStructureParseHelpers.GetrotatingElementDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
