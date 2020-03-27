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
        int _isMassInfinite;
        int _shipHangarYOffset;
        int _rockSubPosition;
        int _missionRankRequired;
        int _discoveryRange;
        int _detectionRange;
        int _shieldHealth;
        int _captureRating;
        int _boardingCrew;
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

        [Description("shipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipClass
        {
            get
            {
                return _shipClass;
            }
            set
            {
                _shipClass = value;
                SetPropertyEdited("shipClass", true);
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

        [Description("engineSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string engineSoundID
        {
            get
            {
                return _engineSoundID;
            }
            set
            {
                _engineSoundID = value;
                SetPropertyEdited("engineSoundID", true);
            }
        }

        [Description("propulsionRibbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string propulsionRibbonID
        {
            get
            {
                return _propulsionRibbonID;
            }
            set
            {
                _propulsionRibbonID = value;
                SetPropertyEdited("propulsionRibbonID", true);
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

        [Description("cockpitActualMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cockpitActualMesh
        {
            get
            {
                return _cockpitActualMesh;
            }
            set
            {
                _cockpitActualMesh = value;
                SetPropertyEdited("cockpitActualMesh", true);
            }
        }

        [Description("shipClassSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipClassSize
        {
            get
            {
                return _shipClassSize;
            }
            set
            {
                _shipClassSize = value;
                SetPropertyEdited("shipClassSize", true);
            }
        }

        [Description("soldByFaction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soldByFaction
        {
            get
            {
                return _soldByFaction;
            }
            set
            {
                _soldByFaction = value;
                SetPropertyEdited("soldByFaction", true);
            }
        }

        [Description("cockpitID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cockpitID
        {
            get
            {
                return _cockpitID;
            }
            set
            {
                _cockpitID = value;
                SetPropertyEdited("cockpitID", true);
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

        [Description("sizeShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sizeShipClass
        {
            get
            {
                return _sizeShipClass;
            }
            set
            {
                _sizeShipClass = value;
                SetPropertyEdited("sizeShipClass", true);
            }
        }

        [Description("combatAIClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string combatAIClass
        {
            get
            {
                return _combatAIClass;
            }
            set
            {
                _combatAIClass = value;
                SetPropertyEdited("combatAIClass", true);
            }
        }

        [Description("minimumMiningRoidSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string minimumMiningRoidSize
        {
            get
            {
                return _minimumMiningRoidSize;
            }
            set
            {
                _minimumMiningRoidSize = value;
                SetPropertyEdited("minimumMiningRoidSize", true);
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

        [Description("gravityDriveParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gravityDriveParticleSystem
        {
            get
            {
                return _gravityDriveParticleSystem;
            }
            set
            {
                _gravityDriveParticleSystem = value;
                SetPropertyEdited("gravityDriveParticleSystem", true);
            }
        }

        [Description("selfDestructAreaOfEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string selfDestructAreaOfEffectID
        {
            get
            {
                return _selfDestructAreaOfEffectID;
            }
            set
            {
                _selfDestructAreaOfEffectID = value;
                SetPropertyEdited("selfDestructAreaOfEffectID", true);
            }
        }

        [Description("towardsEnemy is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string towardsEnemy
        {
            get
            {
                return _towardsEnemy;
            }
            set
            {
                _towardsEnemy = value;
                SetPropertyEdited("towardsEnemy", true);
            }
        }

        [Description("baseID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string baseID
        {
            get
            {
                return _baseID;
            }
            set
            {
                _baseID = value;
                SetPropertyEdited("baseID", true);
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

        [Description("preExplosionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> preExplosionID
        {
            get
            {
                return _preExplosionID;
            }
            set
            {
                _preExplosionID = value;
                SetPropertyEdited("preExplosionID", true);
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

        [Description("shipHangarYOffset is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int shipHangarYOffset
        {
            get
            {
                return _shipHangarYOffset;
            }
            set
            {
                _shipHangarYOffset = value;
                SetPropertyEdited("shipHangarYOffset", true);
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

        [Description("missionRankRequired is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int missionRankRequired
        {
            get
            {
                return _missionRankRequired;
            }
            set
            {
                _missionRankRequired = value;
                SetPropertyEdited("missionRankRequired", true);
            }
        }

        [Description("discoveryRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int discoveryRange
        {
            get
            {
                return _discoveryRange;
            }
            set
            {
                _discoveryRange = value;
                SetPropertyEdited("discoveryRange", true);
            }
        }

        [Description("detectionRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int detectionRange
        {
            get
            {
                return _detectionRange;
            }
            set
            {
                _detectionRange = value;
                SetPropertyEdited("detectionRange", true);
            }
        }

        [Description("shieldHealth is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int shieldHealth
        {
            get
            {
                return _shieldHealth;
            }
            set
            {
                _shieldHealth = value;
                SetPropertyEdited("shieldHealth", true);
            }
        }

        [Description("captureRating is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int captureRating
        {
            get
            {
                return _captureRating;
            }
            set
            {
                _captureRating = value;
                SetPropertyEdited("captureRating", true);
            }
        }

        [Description("boardingCrew is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int boardingCrew
        {
            get
            {
                return _boardingCrew;
            }
            set
            {
                _boardingCrew = value;
                SetPropertyEdited("boardingCrew", true);
            }
        }

        [Description("aggressiveRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int aggressiveRange
        {
            get
            {
                return _aggressiveRange;
            }
            set
            {
                _aggressiveRange = value;
                SetPropertyEdited("aggressiveRange", true);
            }
        }

        [Description("passangerCapacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int passangerCapacity
        {
            get
            {
                return _passangerCapacity;
            }
            set
            {
                _passangerCapacity = value;
                SetPropertyEdited("passangerCapacity", true);
            }
        }


        [Description("cruiseSpeed is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float cruiseSpeed
        {
            get
            {
                return _cruiseSpeed;
            }
            set
            {
                _cruiseSpeed = value;
                SetPropertyEdited("cruiseSpeed", true);
            }
        }

        [Description("timeTillCruise is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeTillCruise
        {
            get
            {
                return _timeTillCruise;
            }
            set
            {
                _timeTillCruise = value;
                SetPropertyEdited("timeTillCruise", true);
            }
        }

        [Description("yaw is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float yaw
        {
            get
            {
                return _yaw;
            }
            set
            {
                _yaw = value;
                SetPropertyEdited("yaw", true);
            }
        }

        [Description("pitch is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pitch
        {
            get
            {
                return _pitch;
            }
            set
            {
                _pitch = value;
                SetPropertyEdited("pitch", true);
            }
        }

        [Description("roll is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float roll
        {
            get
            {
                return _roll;
            }
            set
            {
                _roll = value;
                SetPropertyEdited("roll", true);
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

        [Description("buildTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float buildTime
        {
            get
            {
                return _buildTime;
            }
            set
            {
                _buildTime = value;
                SetPropertyEdited("buildTime", true);
            }
        }

        [Description("crew is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float crew
        {
            get
            {
                return _crew;
            }
            set
            {
                _crew = value;
                SetPropertyEdited("crew", true);
            }
        }

        [Description("energy is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = value;
                SetPropertyEdited("energy", true);
            }
        }

        [Description("ore is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float ore
        {
            get
            {
                return _ore;
            }
            set
            {
                _ore = value;
                SetPropertyEdited("ore", true);
            }
        }

        [Description("deathTimer is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float deathTimer
        {
            get
            {
                return _deathTimer;
            }
            set
            {
                _deathTimer = value;
                SetPropertyEdited("deathTimer", true);
            }
        }

        [Description("armor is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
                SetPropertyEdited("armor", true);
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

        [Description("bGravityDrive is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGravityDrive
        {
            get
            {
                return _bGravityDrive;
            }
            set
            {
                _bGravityDrive = value;
                SetPropertyEdited("bGravityDrive", true);
            }
        }

        [Description("bHideShipInCockpitAcutal is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHideShipInCockpitAcutal
        {
            get
            {
                return _bHideShipInCockpitAcutal;
            }
            set
            {
                _bHideShipInCockpitAcutal = value;
                SetPropertyEdited("bHideShipInCockpitAcutal", true);
            }
        }

        [Description("bPlayerSharedFire is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPlayerSharedFire
        {
            get
            {
                return _bPlayerSharedFire;
            }
            set
            {
                _bPlayerSharedFire = value;
                SetPropertyEdited("bPlayerSharedFire", true);
            }
        }

        [Description("bNotSoldUnlessOwnedBase is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNotSoldUnlessOwnedBase
        {
            get
            {
                return _bNotSoldUnlessOwnedBase;
            }
            set
            {
                _bNotSoldUnlessOwnedBase = value;
                SetPropertyEdited("bNotSoldUnlessOwnedBase", true);
            }
        }

        [Description("bBlackMarket is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bBlackMarket
        {
            get
            {
                return _bBlackMarket;
            }
            set
            {
                _bBlackMarket = value;
                SetPropertyEdited("bBlackMarket", true);
            }
        }

        [Description("bUniqueShip is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bUniqueShip
        {
            get
            {
                return _bUniqueShip;
            }
            set
            {
                _bUniqueShip = value;
                SetPropertyEdited("bUniqueShip", true);
            }
        }

        [Description("bShowInCockpitParticles is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInCockpitParticles
        {
            get
            {
                return _bShowInCockpitParticles;
            }
            set
            {
                _bShowInCockpitParticles = value;
                SetPropertyEdited("bShowInCockpitParticles", true);
            }
        }

        [Description("bRequiresKnowledge is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRequiresKnowledge
        {
            get
            {
                return _bRequiresKnowledge;
            }
            set
            {
                _bRequiresKnowledge = value;
                SetPropertyEdited("bRequiresKnowledge", true);
            }
        }

        [Description("bListedNoPurchase is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bListedNoPurchase
        {
            get
            {
                return _bListedNoPurchase;
            }
            set
            {
                _bListedNoPurchase = value;
                SetPropertyEdited("bListedNoPurchase", true);
            }
        }

        [Description("bLargeHangarOnly is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLargeHangarOnly
        {
            get
            {
                return _bLargeHangarOnly;
            }
            set
            {
                _bLargeHangarOnly = value;
                SetPropertyEdited("bLargeHangarOnly", true);
            }
        }

        [Description("bNoTargetAimNodeOffset is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoTargetAimNodeOffset
        {
            get
            {
                return _bNoTargetAimNodeOffset;
            }
            set
            {
                _bNoTargetAimNodeOffset = value;
                SetPropertyEdited("bNoTargetAimNodeOffset", true);
            }
        }

        [Description("bEveryShipyardOk is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bEveryShipyardOk
        {
            get
            {
                return _bEveryShipyardOk;
            }
            set
            {
                _bEveryShipyardOk = value;
                SetPropertyEdited("bEveryShipyardOk", true);
            }
        }

        [Description("bShowInCockpitWeaponParticles is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInCockpitWeaponParticles
        {
            get
            {
                return _bShowInCockpitWeaponParticles;
            }
            set
            {
                _bShowInCockpitWeaponParticles = value;
                SetPropertyEdited("bShowInCockpitWeaponParticles", true);
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

        [Description("bSaveFileUnlockShip is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSaveFileUnlockShip
        {
            get
            {
                return _bSaveFileUnlockShip;
            }
            set
            {
                _bSaveFileUnlockShip = value;
                SetPropertyEdited("bSaveFileUnlockShip", true);
            }
        }

        [Description("bLargeDockOnly is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLargeDockOnly
        {
            get
            {
                return _bLargeDockOnly;
            }
            set
            {
                _bLargeDockOnly = value;
                SetPropertyEdited("bLargeDockOnly", true);
            }
        }

        [Description("bCanPurchase is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanPurchase
        {
            get
            {
                return _bCanPurchase;
            }
            set
            {
                _bCanPurchase = value;
                SetPropertyEdited("bCanPurchase", true);
            }
        }

        [Description("bNoShipyardRequirement is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoShipyardRequirement
        {
            get
            {
                return _bNoShipyardRequirement;
            }
            set
            {
                _bNoShipyardRequirement = value;
                SetPropertyEdited("bNoShipyardRequirement", true);
            }
        }


        [Description("cockpitInitPos is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D cockpitInitPos
        {
            get
            {
                return _cockpitInitPos;
            }
            set
            {
                _cockpitInitPos = value;
                SetPropertyEdited("cockpitInitPos", true);
            }
        }

        [Description("cockpitTransLimit is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D cockpitTransLimit
        {
            get
            {
                return _cockpitTransLimit;
            }
            set
            {
                _cockpitTransLimit = value;
                SetPropertyEdited("cockpitTransLimit", true);
            }
        }

        [Description("chaseInitPos is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D chaseInitPos
        {
            get
            {
                return _chaseInitPos;
            }
            set
            {
                _chaseInitPos = value;
                SetPropertyEdited("chaseInitPos", true);
            }
        }

        [Description("chaseTransLimit is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D chaseTransLimit
        {
            get
            {
                return _chaseTransLimit;
            }
            set
            {
                _chaseTransLimit = value;
                SetPropertyEdited("chaseTransLimit", true);
            }
        }

        [Description("deathSpin is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D deathSpin
        {
            get
            {
                return _deathSpin;
            }
            set
            {
                _deathSpin = value;
                SetPropertyEdited("deathSpin", true);
            }
        }

        [Description("cockpitActualPos is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D cockpitActualPos
        {
            get
            {
                return _cockpitActualPos;
            }
            set
            {
                _cockpitActualPos = value;
                SetPropertyEdited("cockpitActualPos", true);
            }
        }

        [Description("shipHangarPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D shipHangarPosition
        {
            get
            {
                return _shipHangarPosition;
            }
            set
            {
                _shipHangarPosition = value;
                SetPropertyEdited("shipHangarPosition", true);
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

        [Description("afterburner is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public afterburnerDataStructure afterburner
        {
            get
            {
                return _afterburner;
            }
            set
            {
                _afterburner = value;
                SetPropertyEdited("afterburner", true);
            }
        }

        [Description("targetPriorityList is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public targetPriorityListDataStructure targetPriorityList
        {
            get
            {
                return _targetPriorityList;
            }
            set
            {
                _targetPriorityList = value;
                SetPropertyEdited("targetPriorityList", true);
            }
        }

        [Description("upgrades is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public upgradesDataStructure upgrades
        {
            get
            {
                return _upgrades;
            }
            set
            {
                _upgrades = value;
                SetPropertyEdited("upgrades", true);
            }
        }


        [Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public List<propulsionDataStructure> propulsion
        {
            get
            {
                return _propulsion;
            }
            set
            {
                _propulsion = value;
                SetPropertyEdited("propulsion", true);
            }
        }

        [Description("weapon is a collection of datastructures"), Category("Data Structure Collections")]
        public List<weaponDataStructure> weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
                SetPropertyEdited("weapon", true);
            }
        }

        [Description("damage is a collection of datastructures"), Category("Data Structure Collections")]
        public List<damageDataStructure> damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
                SetPropertyEdited("damage", true);
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

        [Description("movingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<movingElementDataStructure> movingElement
        {
            get
            {
                return _movingElement;
            }
            set
            {
                _movingElement = value;
                SetPropertyEdited("movingElement", true);
            }
        }

        [Description("dock is a collection of datastructures"), Category("Data Structure Collections")]
        public List<dockDataStructure> dock
        {
            get
            {
                return _dock;
            }
            set
            {
                _dock = value;
                SetPropertyEdited("dock", true);
            }
        }

        [Description("shield is a collection of datastructures"), Category("Data Structure Collections")]
        public List<shieldDataStructure> shield
        {
            get
            {
                return _shield;
            }
            set
            {
                _shield = value;
                SetPropertyEdited("shield", true);
            }
        }

        [Description("rotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public List<rotatingElementDataStructure> rotatingElement
        {
            get
            {
                return _rotatingElement;
            }
            set
            {
                _rotatingElement = value;
                SetPropertyEdited("rotatingElement", true);
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            InitProperty("faction");
            InitProperty("shipClass");
            InitProperty("meshName");
            InitProperty("explosionID");
            InitProperty("tacticalExplosionID");
            InitProperty("engineSoundID");
            InitProperty("propulsionRibbonID");
            InitProperty("collisionShape");
            InitProperty("wireframeMaterial");
            InitProperty("cockpitActualMesh");
            InitProperty("shipClassSize");
            InitProperty("soldByFaction");
            InitProperty("cockpitID");
            InitProperty("collisionMeshName");
            InitProperty("sizeShipClass");
            InitProperty("combatAIClass");
            InitProperty("minimumMiningRoidSize");
            InitProperty("hangarID");
            InitProperty("gravityDriveParticleSystem");
            InitProperty("selfDestructAreaOfEffectID");
            InitProperty("towardsEnemy");
            InitProperty("baseID");

            InitProperty("descriptionText");
            InitProperty("preExplosionID");

            InitProperty("creditCost");
            InitProperty("isMassInfinite");
            InitProperty("shipHangarYOffset");
            InitProperty("rockSubPosition");
            InitProperty("missionRankRequired");
            InitProperty("discoveryRange");
            InitProperty("detectionRange");
            InitProperty("shieldHealth");
            InitProperty("captureRating");
            InitProperty("boardingCrew");
            InitProperty("aggressiveRange");
            InitProperty("passangerCapacity");

            InitProperty("cruiseSpeed");
            InitProperty("timeTillCruise");
            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");
            InitProperty("health");
            InitProperty("buildTime");
            InitProperty("crew");
            InitProperty("energy");
            InitProperty("ore");
            InitProperty("deathTimer");
            InitProperty("armor");

            InitProperty("bCommsOverride");
            InitProperty("bGravityDrive");
            InitProperty("bHideShipInCockpitAcutal");
            InitProperty("bPlayerSharedFire");
            InitProperty("bNotSoldUnlessOwnedBase");
            InitProperty("bBlackMarket");
            InitProperty("bUniqueShip");
            InitProperty("bShowInCockpitParticles");
            InitProperty("bRequiresKnowledge");
            InitProperty("bListedNoPurchase");
            InitProperty("bLargeHangarOnly");
            InitProperty("bNoTargetAimNodeOffset");
            InitProperty("bEveryShipyardOk");
            InitProperty("bShowInCockpitWeaponParticles");
            InitProperty("bBaseBuildOverride");
            InitProperty("bSaveFileUnlockShip");
            InitProperty("bLargeDockOnly");
            InitProperty("bCanPurchase");
            InitProperty("bNoShipyardRequirement");

            InitProperty("cockpitInitPos");
            InitProperty("cockpitTransLimit");
            InitProperty("chaseInitPos");
            InitProperty("chaseTransLimit");
            InitProperty("deathSpin");
            InitProperty("cockpitActualPos");
            InitProperty("shipHangarPosition");

            InitProperty("debrisInfo");
            InitProperty("afterburner");
            InitProperty("targetPriorityList");
            InitProperty("upgrades");

            InitProperty("propulsion");
            InitProperty("weapon");
            InitProperty("damage");
            InitProperty("turret");
            InitProperty("attachment");
            InitProperty("movingElement");
            InitProperty("dock");
            InitProperty("shield");
            InitProperty("rotatingElement");
        }

        public ShipData(string inPath) : base(inPath)
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
                _shipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClass", out exists);
                SetPropertyExistsInBaseData("shipClass", exists);
                SetPropertyExists("shipClass", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                SetPropertyExistsInBaseData("meshName", exists);
                SetPropertyExists("meshName", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                SetPropertyExists("tacticalExplosionID", exists);
                _engineSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "engineSoundID", out exists);
                SetPropertyExistsInBaseData("engineSoundID", exists);
                SetPropertyExists("engineSoundID", exists);
                _propulsionRibbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "propulsionRibbonID", out exists);
                SetPropertyExistsInBaseData("propulsionRibbonID", exists);
                SetPropertyExists("propulsionRibbonID", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                SetPropertyExistsInBaseData("collisionShape", exists);
                SetPropertyExists("collisionShape", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                SetPropertyExistsInBaseData("wireframeMaterial", exists);
                SetPropertyExists("wireframeMaterial", exists);
                _cockpitActualMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitActualMesh", out exists);
                SetPropertyExistsInBaseData("cockpitActualMesh", exists);
                SetPropertyExists("cockpitActualMesh", exists);
                _shipClassSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClassSize", out exists);
                SetPropertyExistsInBaseData("shipClassSize", exists);
                SetPropertyExists("shipClassSize", exists);
                _soldByFaction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soldByFaction", out exists);
                SetPropertyExistsInBaseData("soldByFaction", exists);
                SetPropertyExists("soldByFaction", exists);
                _cockpitID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitID", out exists);
                SetPropertyExistsInBaseData("cockpitID", exists);
                SetPropertyExists("cockpitID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                SetPropertyExistsInBaseData("collisionMeshName", exists);
                SetPropertyExists("collisionMeshName", exists);
                _sizeShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sizeShipClass", out exists);
                SetPropertyExistsInBaseData("sizeShipClass", exists);
                SetPropertyExists("sizeShipClass", exists);
                _combatAIClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "combatAIClass", out exists);
                SetPropertyExistsInBaseData("combatAIClass", exists);
                SetPropertyExists("combatAIClass", exists);
                _minimumMiningRoidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumMiningRoidSize", out exists);
                SetPropertyExistsInBaseData("minimumMiningRoidSize", exists);
                SetPropertyExists("minimumMiningRoidSize", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);
                _gravityDriveParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityDriveParticleSystem", out exists);
                SetPropertyExistsInBaseData("gravityDriveParticleSystem", exists);
                SetPropertyExists("gravityDriveParticleSystem", exists);
                _selfDestructAreaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selfDestructAreaOfEffectID", out exists);
                SetPropertyExistsInBaseData("selfDestructAreaOfEffectID", exists);
                SetPropertyExists("selfDestructAreaOfEffectID", exists);
                _towardsEnemy = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "towardsEnemy", out exists);
                SetPropertyExistsInBaseData("towardsEnemy", exists);
                SetPropertyExists("towardsEnemy", exists);
                _baseID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "baseID", out exists);
                SetPropertyExistsInBaseData("baseID", exists);
                SetPropertyExists("baseID", exists);

                _descriptionText = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                SetPropertyExistsInBaseData("descriptionText", exists);
                SetPropertyExists("descriptionText", exists);
                _preExplosionID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "preExplosionID", out exists);
                SetPropertyExistsInBaseData("preExplosionID", exists);
                SetPropertyExists("preExplosionID", exists);

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost", out exists);
                SetPropertyExistsInBaseData("creditCost", exists);
                SetPropertyExists("creditCost", exists);
                _isMassInfinite = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                SetPropertyExistsInBaseData("isMassInfinite", exists);
                SetPropertyExists("isMassInfinite", exists);
                _shipHangarYOffset = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shipHangarYOffset", out exists);
                SetPropertyExistsInBaseData("shipHangarYOffset", exists);
                SetPropertyExists("shipHangarYOffset", exists);
                _rockSubPosition = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rockSubPosition", out exists);
                SetPropertyExistsInBaseData("rockSubPosition", exists);
                SetPropertyExists("rockSubPosition", exists);
                _missionRankRequired = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "missionRankRequired", out exists);
                SetPropertyExistsInBaseData("missionRankRequired", exists);
                SetPropertyExists("missionRankRequired", exists);
                _discoveryRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "discoveryRange", out exists);
                SetPropertyExistsInBaseData("discoveryRange", exists);
                SetPropertyExists("discoveryRange", exists);
                _detectionRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionRange", out exists);
                SetPropertyExistsInBaseData("detectionRange", exists);
                SetPropertyExists("detectionRange", exists);
                _shieldHealth = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealth", out exists);
                SetPropertyExistsInBaseData("shieldHealth", exists);
                SetPropertyExists("shieldHealth", exists);
                _captureRating = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "captureRating", out exists);
                SetPropertyExistsInBaseData("captureRating", exists);
                SetPropertyExists("captureRating", exists);
                _boardingCrew = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "boardingCrew", out exists);
                SetPropertyExistsInBaseData("boardingCrew", exists);
                SetPropertyExists("boardingCrew", exists);
                _aggressiveRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "aggressiveRange", out exists);
                SetPropertyExistsInBaseData("aggressiveRange", exists);
                SetPropertyExists("aggressiveRange", exists);
                _passangerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "passangerCapacity", out exists);
                SetPropertyExistsInBaseData("passangerCapacity", exists);
                SetPropertyExists("passangerCapacity", exists);

                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed", out exists);
                SetPropertyExistsInBaseData("cruiseSpeed", exists);
                SetPropertyExists("cruiseSpeed", exists);
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise", out exists);
                SetPropertyExistsInBaseData("timeTillCruise", exists);
                SetPropertyExists("timeTillCruise", exists);
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw", out exists);
                SetPropertyExistsInBaseData("yaw", exists);
                SetPropertyExists("yaw", exists);
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch", out exists);
                SetPropertyExistsInBaseData("pitch", exists);
                SetPropertyExists("pitch", exists);
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll", out exists);
                SetPropertyExistsInBaseData("roll", exists);
                SetPropertyExists("roll", exists);
                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                SetPropertyExistsInBaseData("health", exists);
                SetPropertyExists("health", exists);
                _buildTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTime", out exists);
                SetPropertyExistsInBaseData("buildTime", exists);
                SetPropertyExists("buildTime", exists);
                _crew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "crew", out exists);
                SetPropertyExistsInBaseData("crew", exists);
                SetPropertyExists("crew", exists);
                _energy = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energy", out exists);
                SetPropertyExistsInBaseData("energy", exists);
                SetPropertyExists("energy", exists);
                _ore = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ore", out exists);
                SetPropertyExistsInBaseData("ore", exists);
                SetPropertyExists("ore", exists);
                _deathTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "deathTimer", out exists);
                SetPropertyExistsInBaseData("deathTimer", exists);
                SetPropertyExists("deathTimer", exists);
                _armor = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armor", out exists);
                SetPropertyExistsInBaseData("armor", exists);
                SetPropertyExists("armor", exists);

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride", out exists);
                SetPropertyExistsInBaseData("bCommsOverride", exists);
                SetPropertyExists("bCommsOverride", exists);
                _bGravityDrive = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGravityDrive", out exists);
                SetPropertyExistsInBaseData("bGravityDrive", exists);
                SetPropertyExists("bGravityDrive", exists);
                _bHideShipInCockpitAcutal = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHideShipInCockpitAcutal", out exists);
                SetPropertyExistsInBaseData("bHideShipInCockpitAcutal", exists);
                SetPropertyExists("bHideShipInCockpitAcutal", exists);
                _bPlayerSharedFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPlayerSharedFire", out exists);
                SetPropertyExistsInBaseData("bPlayerSharedFire", exists);
                SetPropertyExists("bPlayerSharedFire", exists);
                _bNotSoldUnlessOwnedBase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNotSoldUnlessOwnedBase", out exists);
                SetPropertyExistsInBaseData("bNotSoldUnlessOwnedBase", exists);
                SetPropertyExists("bNotSoldUnlessOwnedBase", exists);
                _bBlackMarket = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBlackMarket", out exists);
                SetPropertyExistsInBaseData("bBlackMarket", exists);
                SetPropertyExists("bBlackMarket", exists);
                _bUniqueShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUniqueShip", out exists);
                SetPropertyExistsInBaseData("bUniqueShip", exists);
                SetPropertyExists("bUniqueShip", exists);
                _bShowInCockpitParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitParticles", out exists);
                SetPropertyExistsInBaseData("bShowInCockpitParticles", exists);
                SetPropertyExists("bShowInCockpitParticles", exists);
                _bRequiresKnowledge = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresKnowledge", out exists);
                SetPropertyExistsInBaseData("bRequiresKnowledge", exists);
                SetPropertyExists("bRequiresKnowledge", exists);
                _bListedNoPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bListedNoPurchase", out exists);
                SetPropertyExistsInBaseData("bListedNoPurchase", exists);
                SetPropertyExists("bListedNoPurchase", exists);
                _bLargeHangarOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeHangarOnly", out exists);
                SetPropertyExistsInBaseData("bLargeHangarOnly", exists);
                SetPropertyExists("bLargeHangarOnly", exists);
                _bNoTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoTargetAimNodeOffset", out exists);
                SetPropertyExistsInBaseData("bNoTargetAimNodeOffset", exists);
                SetPropertyExists("bNoTargetAimNodeOffset", exists);
                _bEveryShipyardOk = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEveryShipyardOk", out exists);
                SetPropertyExistsInBaseData("bEveryShipyardOk", exists);
                SetPropertyExists("bEveryShipyardOk", exists);
                _bShowInCockpitWeaponParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitWeaponParticles", out exists);
                SetPropertyExistsInBaseData("bShowInCockpitWeaponParticles", exists);
                SetPropertyExists("bShowInCockpitWeaponParticles", exists);
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride", out exists);
                SetPropertyExistsInBaseData("bBaseBuildOverride", exists);
                SetPropertyExists("bBaseBuildOverride", exists);
                _bSaveFileUnlockShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSaveFileUnlockShip", out exists);
                SetPropertyExistsInBaseData("bSaveFileUnlockShip", exists);
                SetPropertyExists("bSaveFileUnlockShip", exists);
                _bLargeDockOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeDockOnly", out exists);
                SetPropertyExistsInBaseData("bLargeDockOnly", exists);
                SetPropertyExists("bLargeDockOnly", exists);
                _bCanPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanPurchase", out exists);
                SetPropertyExistsInBaseData("bCanPurchase", exists);
                SetPropertyExists("bCanPurchase", exists);
                _bNoShipyardRequirement = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShipyardRequirement", out exists);
                SetPropertyExistsInBaseData("bNoShipyardRequirement", exists);
                SetPropertyExists("bNoShipyardRequirement", exists);

                _cockpitInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitInitPos", out exists);
                SetPropertyExistsInBaseData("cockpitInitPos", exists);
                SetPropertyExists("cockpitInitPos", exists);
                _cockpitTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitTransLimit", out exists);
                SetPropertyExistsInBaseData("cockpitTransLimit", exists);
                SetPropertyExists("cockpitTransLimit", exists);
                _chaseInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseInitPos", out exists);
                SetPropertyExistsInBaseData("chaseInitPos", exists);
                SetPropertyExists("chaseInitPos", exists);
                _chaseTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseTransLimit", out exists);
                SetPropertyExistsInBaseData("chaseTransLimit", exists);
                SetPropertyExists("chaseTransLimit", exists);
                _deathSpin = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathSpin", out exists);
                SetPropertyExistsInBaseData("deathSpin", exists);
                SetPropertyExists("deathSpin", exists);
                _cockpitActualPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitActualPos", out exists);
                SetPropertyExistsInBaseData("cockpitActualPos", exists);
                SetPropertyExists("cockpitActualPos", exists);
                _shipHangarPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "shipHangarPosition", out exists);
                SetPropertyExistsInBaseData("shipHangarPosition", exists);
                SetPropertyExists("shipHangarPosition", exists);

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("debrisInfo", exists);
                SetPropertyExists("debrisInfo", exists);
                _afterburner = DataStructureParseHelpers.GetafterburnerDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("afterburner", exists);
                SetPropertyExists("afterburner", exists);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("targetPriorityList", exists);
                SetPropertyExists("targetPriorityList", exists);
                _upgrades = DataStructureParseHelpers.GetupgradesDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("upgrades", exists);
                SetPropertyExists("upgrades", exists);

                _propulsion = DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("propulsion", exists);
                SetPropertyExists("propulsion", exists);
                _weapon = DataStructureParseHelpers.GetweaponDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("weapon", exists);
                SetPropertyExists("weapon", exists);
                _damage = DataStructureParseHelpers.GetdamageDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _turret = DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("turret", exists);
                SetPropertyExists("turret", exists);
                _attachment = DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("attachment", exists);
                SetPropertyExists("attachment", exists);
                _movingElement = DataStructureParseHelpers.GetmovingElementDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("movingElement", exists);
                SetPropertyExists("movingElement", exists);
                _dock = DataStructureParseHelpers.GetdockDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("dock", exists);
                SetPropertyExists("dock", exists);
                _shield = DataStructureParseHelpers.GetshieldDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("shield", exists);
                SetPropertyExists("shield", exists);
                _rotatingElement = DataStructureParseHelpers.GetrotatingElementDataStructureListFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("rotatingElement", exists);
                SetPropertyExists("rotatingElement", exists);
            }
        }
    }
}
