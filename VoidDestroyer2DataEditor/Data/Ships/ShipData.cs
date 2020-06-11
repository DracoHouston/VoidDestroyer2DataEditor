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
    public class ShipData : VD2Data
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
        string _gravityDriveParticleSystem;
        string _selfDestructAreaOfEffectID;
        string _towardsEnemy;
        string _baseID;

        ObservableCollection<string> _descriptionText;
        ObservableCollection<string> _preExplosionID;
        ObservableCollection<string> _hangarID;

        int _creditCost;
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
        int _upKeepOverride;

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
        bool _bCanNotSell;
        bool _bRequiresKnowledge;
        bool _bListedNoPurchase;
        bool _bLargeHangarOnly;
        bool _bNoTargetAimNodeOffset;
        bool _bEveryShipyardOk;
        bool _bShowInCockpitWeaponParticles;
        bool _bLargeDockOnly;
        bool _bBaseBuildOverride;
        bool _bSaveFileUnlockShip;
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

        ObservableCollection<VD2DataStructure> _propulsion;
        ObservableCollection<VD2DataStructure> _weapon;
        ObservableCollection<VD2DataStructure> _damage;
        ObservableCollection<VD2DataStructure> _turret;
        ObservableCollection<VD2DataStructure> _attachment;
        ObservableCollection<VD2DataStructure> _movingElement;
        ObservableCollection<VD2DataStructure> _dock;
        ObservableCollection<VD2DataStructure> _shield;
        ObservableCollection<VD2DataStructure> _rotatingElement;

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

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("shipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipClass
        {
            get
            {
                return _shipClass;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipClass = value;
                        SetPropertyEdited("shipClass", true);
                    }
                }
            }
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string explosionID
        {
            get
            {
                return _explosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _explosionID = value;
                        SetPropertyEdited("explosionID", true);
                    }
                }
            }
        }

        [Description("tacticalExplosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string tacticalExplosionID
        {
            get
            {
                return _tacticalExplosionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _tacticalExplosionID = value;
                        SetPropertyEdited("tacticalExplosionID", true);
                    }
                }
            }
        }

        [Description("engineSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string engineSoundID
        {
            get
            {
                return _engineSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _engineSoundID = value;
                        SetPropertyEdited("engineSoundID", true);
                    }
                }
            }
        }

        [Description("propulsionRibbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string propulsionRibbonID
        {
            get
            {
                return _propulsionRibbonID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _propulsionRibbonID = value;
                        SetPropertyEdited("propulsionRibbonID", true);
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

        [Description("cockpitActualMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cockpitActualMesh
        {
            get
            {
                return _cockpitActualMesh;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cockpitActualMesh = value;
                        SetPropertyEdited("cockpitActualMesh", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipClassSize = value;
                        SetPropertyEdited("shipClassSize", true);
                    }
                }
            }
        }

        [Description("soldByFaction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string soldByFaction
        {
            get
            {
                return _soldByFaction;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _soldByFaction = value;
                        SetPropertyEdited("soldByFaction", true);
                    }
                }
            }
        }

        [Description("cockpitID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string cockpitID
        {
            get
            {
                return _cockpitID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cockpitID = value;
                        SetPropertyEdited("cockpitID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionMeshName = value;
                        SetPropertyEdited("collisionMeshName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _sizeShipClass = value;
                        SetPropertyEdited("sizeShipClass", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _combatAIClass = value;
                        SetPropertyEdited("combatAIClass", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _minimumMiningRoidSize = value;
                        SetPropertyEdited("minimumMiningRoidSize", true);
                    }
                }
            }
        }

        [Description("gravityDriveParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string gravityDriveParticleSystem
        {
            get
            {
                return _gravityDriveParticleSystem;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _gravityDriveParticleSystem = value;
                        SetPropertyEdited("gravityDriveParticleSystem", true);
                    }
                }
            }
        }

        [Description("selfDestructAreaOfEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string selfDestructAreaOfEffectID
        {
            get
            {
                return _selfDestructAreaOfEffectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _selfDestructAreaOfEffectID = value;
                        SetPropertyEdited("selfDestructAreaOfEffectID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _towardsEnemy = value;
                        SetPropertyEdited("towardsEnemy", true);
                    }
                }
            }
        }

        [Description("baseID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string baseID
        {
            get
            {
                return _baseID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _baseID = value;
                        SetPropertyEdited("baseID", true);
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

        [Browsable(false), Description("preExplosionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> preExplosionID
        {
            get
            {
                return _preExplosionID;
            }
            set
            {
                if (_preExplosionID != null)
                {
                    _preExplosionID.CollectionChanged -= OnpreExplosionIDChanged;
                }
                _preExplosionID = value;
                if (_preExplosionID != null)
                {
                    _preExplosionID.CollectionChanged += OnpreExplosionIDChanged;
                }
            }
        }

        private void OnpreExplosionIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("preExplosionID", true);
                }
                else
                {
                    bool exists = false;
                    _preExplosionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "preExplosionID", out exists));
                    _preExplosionID.CollectionChanged += OnpreExplosionIDChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("preExplosionID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("preExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "preExplosionID"));
                    }
                    SetPropertyExists("preExplosionID", exists);
                }
            }
        }

        [Browsable(false), Description("hangarID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> hangarID
        {
            get
            {
                return _hangarID;
            }
            set
            {
                if (_hangarID != null)
                {
                    _hangarID.CollectionChanged -= OnhangarIDChanged;
                }
                _hangarID = value;
                if (_hangarID != null)
                {
                    _hangarID.CollectionChanged += OnhangarIDChanged;
                }
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
                    _hangarID.CollectionChanged += OnhangarIDChanged;
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


        [Description("creditCost is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int creditCost
        {
            get
            {
                return _creditCost;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _creditCost = value;
                        SetPropertyEdited("creditCost", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipHangarYOffset = value;
                        SetPropertyEdited("shipHangarYOffset", true);
                    }
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

        [Description("missionRankRequired is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int missionRankRequired
        {
            get
            {
                return _missionRankRequired;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _missionRankRequired = value;
                        SetPropertyEdited("missionRankRequired", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _discoveryRange = value;
                        SetPropertyEdited("discoveryRange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _detectionRange = value;
                        SetPropertyEdited("detectionRange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldHealth = value;
                        SetPropertyEdited("shieldHealth", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _captureRating = value;
                        SetPropertyEdited("captureRating", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _boardingCrew = value;
                        SetPropertyEdited("boardingCrew", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _aggressiveRange = value;
                        SetPropertyEdited("aggressiveRange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _passangerCapacity = value;
                        SetPropertyEdited("passangerCapacity", true);
                    }
                }
            }
        }

        [Description("upKeepOverride is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int upKeepOverride
        {
            get
            {
                return _upKeepOverride;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _upKeepOverride = value;
                        SetPropertyEdited("upKeepOverride", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cruiseSpeed = value;
                        SetPropertyEdited("cruiseSpeed", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _timeTillCruise = value;
                        SetPropertyEdited("timeTillCruise", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _yaw = value;
                        SetPropertyEdited("yaw", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _pitch = value;
                        SetPropertyEdited("pitch", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _roll = value;
                        SetPropertyEdited("roll", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _health = value;
                        SetPropertyEdited("health", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _buildTime = value;
                        SetPropertyEdited("buildTime", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _crew = value;
                        SetPropertyEdited("crew", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _energy = value;
                        SetPropertyEdited("energy", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ore = value;
                        SetPropertyEdited("ore", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _deathTimer = value;
                        SetPropertyEdited("deathTimer", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _armor = value;
                        SetPropertyEdited("armor", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCommsOverride = value;
                        SetPropertyEdited("bCommsOverride", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bGravityDrive = value;
                        SetPropertyEdited("bGravityDrive", true);
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

        [Description("bHideShipInCockpitAcutal is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHideShipInCockpitAcutal
        {
            get
            {
                return _bHideShipInCockpitAcutal;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bHideShipInCockpitAcutal = value;
                        SetPropertyEdited("bHideShipInCockpitAcutal", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPlayerSharedFire = value;
                        SetPropertyEdited("bPlayerSharedFire", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNotSoldUnlessOwnedBase = value;
                        SetPropertyEdited("bNotSoldUnlessOwnedBase", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bBlackMarket = value;
                        SetPropertyEdited("bBlackMarket", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bUniqueShip = value;
                        SetPropertyEdited("bUniqueShip", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bShowInCockpitParticles = value;
                        SetPropertyEdited("bShowInCockpitParticles", true);
                    }
                }
            }
        }

        [Description("bCanNotSell is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanNotSell
        {
            get
            {
                return _bCanNotSell;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCanNotSell = value;
                        SetPropertyEdited("bCanNotSell", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRequiresKnowledge = value;
                        SetPropertyEdited("bRequiresKnowledge", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bListedNoPurchase = value;
                        SetPropertyEdited("bListedNoPurchase", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bLargeHangarOnly = value;
                        SetPropertyEdited("bLargeHangarOnly", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoTargetAimNodeOffset = value;
                        SetPropertyEdited("bNoTargetAimNodeOffset", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bEveryShipyardOk = value;
                        SetPropertyEdited("bEveryShipyardOk", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bShowInCockpitWeaponParticles = value;
                        SetPropertyEdited("bShowInCockpitWeaponParticles", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bLargeDockOnly = value;
                        SetPropertyEdited("bLargeDockOnly", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bBaseBuildOverride = value;
                        SetPropertyEdited("bBaseBuildOverride", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bSaveFileUnlockShip = value;
                        SetPropertyEdited("bSaveFileUnlockShip", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCanPurchase = value;
                        SetPropertyEdited("bCanPurchase", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoShipyardRequirement = value;
                        SetPropertyEdited("bNoShipyardRequirement", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cockpitInitPos.OnElementChanged -= cockpitInitPos_OnElementChanged;
                        _cockpitInitPos = value;
                        _cockpitInitPos.OnElementChanged += cockpitInitPos_OnElementChanged;
                        SetPropertyEdited("cockpitInitPos", true);
                    }
                }
            }
        }

        private void cockpitInitPos_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("cockpitInitPos", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= cockpitInitPos_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += cockpitInitPos_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= cockpitInitPos_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += cockpitInitPos_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= cockpitInitPos_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += cockpitInitPos_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cockpitTransLimit.OnElementChanged -= cockpitTransLimit_OnElementChanged;
                        _cockpitTransLimit = value;
                        _cockpitTransLimit.OnElementChanged += cockpitTransLimit_OnElementChanged;
                        SetPropertyEdited("cockpitTransLimit", true);
                    }
                }
            }
        }

        private void cockpitTransLimit_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("cockpitTransLimit", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= cockpitTransLimit_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += cockpitTransLimit_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= cockpitTransLimit_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += cockpitTransLimit_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= cockpitTransLimit_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += cockpitTransLimit_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _chaseInitPos.OnElementChanged -= chaseInitPos_OnElementChanged;
                        _chaseInitPos = value;
                        _chaseInitPos.OnElementChanged += chaseInitPos_OnElementChanged;
                        SetPropertyEdited("chaseInitPos", true);
                    }
                }
            }
        }

        private void chaseInitPos_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("chaseInitPos", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= chaseInitPos_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += chaseInitPos_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= chaseInitPos_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += chaseInitPos_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= chaseInitPos_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += chaseInitPos_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _chaseTransLimit.OnElementChanged -= chaseTransLimit_OnElementChanged;
                        _chaseTransLimit = value;
                        _chaseTransLimit.OnElementChanged += chaseTransLimit_OnElementChanged;
                        SetPropertyEdited("chaseTransLimit", true);
                    }
                }
            }
        }

        private void chaseTransLimit_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("chaseTransLimit", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= chaseTransLimit_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += chaseTransLimit_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= chaseTransLimit_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += chaseTransLimit_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= chaseTransLimit_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += chaseTransLimit_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _deathSpin.OnElementChanged -= deathSpin_OnElementChanged;
                        _deathSpin = value;
                        _deathSpin.OnElementChanged += deathSpin_OnElementChanged;
                        SetPropertyEdited("deathSpin", true);
                    }
                }
            }
        }

        private void deathSpin_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("deathSpin", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= deathSpin_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += deathSpin_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= deathSpin_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += deathSpin_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= deathSpin_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += deathSpin_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cockpitActualPos.OnElementChanged -= cockpitActualPos_OnElementChanged;
                        _cockpitActualPos = value;
                        _cockpitActualPos.OnElementChanged += cockpitActualPos_OnElementChanged;
                        SetPropertyEdited("cockpitActualPos", true);
                    }
                }
            }
        }

        private void cockpitActualPos_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("cockpitActualPos", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= cockpitActualPos_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += cockpitActualPos_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= cockpitActualPos_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += cockpitActualPos_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= cockpitActualPos_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += cockpitActualPos_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipHangarPosition.OnElementChanged -= shipHangarPosition_OnElementChanged;
                        _shipHangarPosition = value;
                        _shipHangarPosition.OnElementChanged += shipHangarPosition_OnElementChanged;
                        SetPropertyEdited("shipHangarPosition", true);
                    }
                }
            }
        }

        private void shipHangarPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("shipHangarPosition", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= shipHangarPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += shipHangarPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= shipHangarPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += shipHangarPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= shipHangarPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += shipHangarPosition_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        [Browsable(false), Description("debrisInfo is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public debrisInfoDataStructure debrisInfo
        {
            get
            {
                return _debrisInfo;
            }
            set
            {
                _debrisInfo = value;
            }
        }

        [Browsable(false), Description("afterburner is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public afterburnerDataStructure afterburner
        {
            get
            {
                return _afterburner;
            }
            set
            {
                _afterburner = value;
            }
        }

        [Browsable(false), Description("targetPriorityList is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public targetPriorityListDataStructure targetPriorityList
        {
            get
            {
                return _targetPriorityList;
            }
            set
            {
                _targetPriorityList = value;
            }
        }

        [Browsable(false), Description("upgrades is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public upgradesDataStructure upgrades
        {
            get
            {
                return _upgrades;
            }
            set
            {
                _upgrades = value;
            }
        }


        [Browsable(false), Description("propulsion is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> propulsion
        {
            get
            {
                return _propulsion;
            }
            set
            {
                if (_propulsion != null)
                {
                    _propulsion.CollectionChanged -= OnpropulsionChanged;
                }
                _propulsion = value;
                if (_propulsion != null)
                {
                    _propulsion.CollectionChanged += OnpropulsionChanged;
                }
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
                    _propulsion = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _propulsion.CollectionChanged += OnpropulsionChanged;
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

        [Browsable(false), Description("weapon is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                if (_weapon != null)
                {
                    _weapon.CollectionChanged -= OnweaponChanged;
                }
                _weapon = value;
                if (_weapon != null)
                {
                    _weapon.CollectionChanged += OnweaponChanged;
                }
            }
        }

        private void OnweaponChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("weapon", true);
                }
                else
                {
                    bool exists = false;
                    _weapon = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetweaponDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _weapon.CollectionChanged += OnweaponChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("weapon", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("weapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weapon"));
                    }
                    SetPropertyExists("weapon", exists);
                }
            }
        }

        [Browsable(false), Description("damage is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> damage
        {
            get
            {
                return _damage;
            }
            set
            {
                if (_damage != null)
                {
                    _damage.CollectionChanged -= OndamageChanged;
                }
                _damage = value;
                if (_damage != null)
                {
                    _damage.CollectionChanged += OndamageChanged;
                }
            }
        }

        private void OndamageChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("damage", true);
                }
                else
                {
                    bool exists = false;
                    _damage = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetdamageDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _damage.CollectionChanged += OndamageChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("damage", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("damage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damage"));
                    }
                    SetPropertyExists("damage", exists);
                }
            }
        }

        [Browsable(false), Description("turret is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> turret
        {
            get
            {
                return _turret;
            }
            set
            {
                if (_turret != null)
                {
                    _turret.CollectionChanged -= OnturretChanged;
                }
                _turret = value;
                if (_turret != null)
                {
                    _turret.CollectionChanged += OnturretChanged;
                }
            }
        }

        private void OnturretChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("turret", true);
                }
                else
                {
                    bool exists = false;
                    _turret = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _turret.CollectionChanged += OnturretChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("turret", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                    }
                    SetPropertyExists("turret", exists);
                }
            }
        }

        [Browsable(false), Description("attachment is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> attachment
        {
            get
            {
                return _attachment;
            }
            set
            {
                if (_attachment != null)
                {
                    _attachment.CollectionChanged -= OnattachmentChanged;
                }
                _attachment = value;
                if (_attachment != null)
                {
                    _attachment.CollectionChanged += OnattachmentChanged;
                }
            }
        }

        private void OnattachmentChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("attachment", true);
                }
                else
                {
                    bool exists = false;
                    _attachment = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _attachment.CollectionChanged += OnattachmentChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("attachment", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("attachment", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "attachment"));
                    }
                    SetPropertyExists("attachment", exists);
                }
            }
        }

        [Browsable(false), Description("movingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> movingElement
        {
            get
            {
                return _movingElement;
            }
            set
            {
                if (_movingElement != null)
                {
                    _movingElement.CollectionChanged -= OnmovingElementChanged;
                }
                _movingElement = value;
                if (_movingElement != null)
                {
                    _movingElement.CollectionChanged += OnmovingElementChanged;
                }
            }
        }

        private void OnmovingElementChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("movingElement", true);
                }
                else
                {
                    bool exists = false;
                    _movingElement = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetmovingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _movingElement.CollectionChanged += OnmovingElementChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("movingElement", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("movingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "movingElement"));
                    }
                    SetPropertyExists("movingElement", exists);
                }
            }
        }

        [Browsable(false), Description("dock is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> dock
        {
            get
            {
                return _dock;
            }
            set
            {
                if (_dock != null)
                {
                    _dock.CollectionChanged -= OndockChanged;
                }
                _dock = value;
                if (_dock != null)
                {
                    _dock.CollectionChanged += OndockChanged;
                }
            }
        }

        private void OndockChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("dock", true);
                }
                else
                {
                    bool exists = false;
                    _dock = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetdockDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _dock.CollectionChanged += OndockChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("dock", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("dock", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dock"));
                    }
                    SetPropertyExists("dock", exists);
                }
            }
        }

        [Browsable(false), Description("shield is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> shield
        {
            get
            {
                return _shield;
            }
            set
            {
                if (_shield != null)
                {
                    _shield.CollectionChanged -= OnshieldChanged;
                }
                _shield = value;
                if (_shield != null)
                {
                    _shield.CollectionChanged += OnshieldChanged;
                }
            }
        }

        private void OnshieldChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("shield", true);
                }
                else
                {
                    bool exists = false;
                    _shield = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetshieldDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _shield.CollectionChanged += OnshieldChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("shield", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("shield", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shield"));
                    }
                    SetPropertyExists("shield", exists);
                }
            }
        }

        [Browsable(false), Description("rotatingElement is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<VD2DataStructure> rotatingElement
        {
            get
            {
                return _rotatingElement;
            }
            set
            {
                if (_rotatingElement != null)
                {
                    _rotatingElement.CollectionChanged -= OnrotatingElementChanged;
                }
                _rotatingElement = value;
                if (_rotatingElement != null)
                {
                    _rotatingElement.CollectionChanged += OnrotatingElementChanged;
                }
            }
        }

        private void OnrotatingElementChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("rotatingElement", true);
                }
                else
                {
                    bool exists = false;
                    _rotatingElement = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetrotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _rotatingElement.CollectionChanged += OnrotatingElementChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("rotatingElement", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("rotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rotatingElement"));
                    }
                    SetPropertyExists("rotatingElement", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("faction");
            List<string> factionreftypes = new List<string>();
            factionreftypes.Add("Faction");
            SetPropertyIsObjectIDRef("faction", true, factionreftypes);
            InitProperty("shipClass");
            InitProperty("meshName");
            List<string> meshNamereftypes = new List<string>();
            meshNamereftypes.Add("Mesh");
            SetPropertyIsObjectIDRef("meshName", true, meshNamereftypes);
            InitProperty("explosionID");
            List<string> explosionIDreftypes = new List<string>();
            explosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("explosionID", true, explosionIDreftypes);
            InitProperty("tacticalExplosionID");
            List<string> tacticalExplosionIDreftypes = new List<string>();
            tacticalExplosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("tacticalExplosionID", true, tacticalExplosionIDreftypes);
            InitProperty("engineSoundID");
            List<string> engineSoundIDreftypes = new List<string>();
            engineSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("engineSoundID", true, engineSoundIDreftypes);
            InitProperty("propulsionRibbonID");
            List<string> propulsionRibbonIDreftypes = new List<string>();
            propulsionRibbonIDreftypes.Add("Effect");
            SetPropertyIsObjectIDRef("propulsionRibbonID", true, propulsionRibbonIDreftypes);
            InitProperty("collisionShape");
            InitProperty("wireframeMaterial");
            InitProperty("cockpitActualMesh");
            InitProperty("shipClassSize");
            InitProperty("soldByFaction");
            List<string> soldByFactionreftypes = new List<string>();
            soldByFactionreftypes.Add("Faction");
            SetPropertyIsObjectIDRef("soldByFaction", true, soldByFactionreftypes);
            InitProperty("cockpitID");
            List<string> cockpitIDreftypes = new List<string>();
            cockpitIDreftypes.Add("Cockpit");
            SetPropertyIsObjectIDRef("cockpitID", true, cockpitIDreftypes);
            InitProperty("collisionMeshName");
            InitProperty("sizeShipClass");
            InitProperty("combatAIClass");
            InitProperty("minimumMiningRoidSize");
            InitProperty("gravityDriveParticleSystem");
            List<string> gravityDriveParticleSystemreftypes = new List<string>();
            gravityDriveParticleSystemreftypes.Add("ParticleUniverse");
            SetPropertyIsObjectIDRef("gravityDriveParticleSystem", true, gravityDriveParticleSystemreftypes);
            InitProperty("selfDestructAreaOfEffectID");
            List<string> selfDestructAreaOfEffectIDreftypes = new List<string>();
            selfDestructAreaOfEffectIDreftypes.Add("AreaOfEffect");
            SetPropertyIsObjectIDRef("selfDestructAreaOfEffectID", true, selfDestructAreaOfEffectIDreftypes);
            InitProperty("towardsEnemy");
            InitProperty("baseID");
            List<string> baseIDreftypes = new List<string>();
            baseIDreftypes.Add("Base");
            SetPropertyIsObjectIDRef("baseID", true, baseIDreftypes);

            InitProperty("descriptionText");
            SetPropertyIsCollection("descriptionText", true, typeof(string));
            InitProperty("preExplosionID");
            List<string> preExplosionIDreftypes = new List<string>();
            preExplosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("preExplosionID", true, preExplosionIDreftypes);
            SetPropertyIsCollection("preExplosionID", true, typeof(string));
            InitProperty("hangarID");
            List<string> hangarIDreftypes = new List<string>();
            hangarIDreftypes.Add("Hangar");
            SetPropertyIsObjectIDRef("hangarID", true, hangarIDreftypes);
            SetPropertyIsCollection("hangarID", true, typeof(string));

            InitProperty("creditCost");
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
            InitProperty("upKeepOverride");

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
            InitProperty("isMassInfinite");
            InitProperty("bHideShipInCockpitAcutal");
            InitProperty("bPlayerSharedFire");
            InitProperty("bNotSoldUnlessOwnedBase");
            InitProperty("bBlackMarket");
            InitProperty("bUniqueShip");
            InitProperty("bShowInCockpitParticles");
            InitProperty("bCanNotSell");
            InitProperty("bRequiresKnowledge");
            InitProperty("bListedNoPurchase");
            InitProperty("bLargeHangarOnly");
            InitProperty("bNoTargetAimNodeOffset");
            InitProperty("bEveryShipyardOk");
            InitProperty("bShowInCockpitWeaponParticles");
            InitProperty("bLargeDockOnly");
            InitProperty("bBaseBuildOverride");
            InitProperty("bSaveFileUnlockShip");
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
            SetPropertyIsCollection("propulsion", true, typeof(propulsionDataStructure));
            InitProperty("weapon");
            SetPropertyIsCollection("weapon", true, typeof(weaponDataStructure));
            InitProperty("damage");
            SetPropertyIsCollection("damage", true, typeof(damageDataStructure));
            InitProperty("turret");
            SetPropertyIsCollection("turret", true, typeof(turretDataStructure));
            InitProperty("attachment");
            SetPropertyIsCollection("attachment", true, typeof(attachmentDataStructure));
            InitProperty("movingElement");
            SetPropertyIsCollection("movingElement", true, typeof(movingElementDataStructure));
            InitProperty("dock");
            SetPropertyIsCollection("dock", true, typeof(dockDataStructure));
            InitProperty("shield");
            SetPropertyIsCollection("shield", true, typeof(shieldDataStructure));
            InitProperty("rotatingElement");
            SetPropertyIsCollection("rotatingElement", true, typeof(rotatingElementDataStructure));
        }

        public ShipData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
        }

        public override void LoadDataFromXML()
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
                _shipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipClass"));
                }
                SetPropertyExists("shipClass", exists);
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
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("explosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("explosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "explosionID"));
                }
                SetPropertyExists("explosionID", exists);
                _tacticalExplosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tacticalExplosionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("tacticalExplosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("tacticalExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "tacticalExplosionID"));
                }
                SetPropertyExists("tacticalExplosionID", exists);
                _engineSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "engineSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("engineSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("engineSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "engineSoundID"));
                }
                SetPropertyExists("engineSoundID", exists);
                _propulsionRibbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "propulsionRibbonID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("propulsionRibbonID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("propulsionRibbonID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "propulsionRibbonID"));
                }
                SetPropertyExists("propulsionRibbonID", exists);
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
                _cockpitActualMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitActualMesh", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cockpitActualMesh", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cockpitActualMesh", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cockpitActualMesh"));
                }
                SetPropertyExists("cockpitActualMesh", exists);
                _shipClassSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipClassSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipClassSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipClassSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipClassSize"));
                }
                SetPropertyExists("shipClassSize", exists);
                _soldByFaction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soldByFaction", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soldByFaction", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soldByFaction", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soldByFaction"));
                }
                SetPropertyExists("soldByFaction", exists);
                _cockpitID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "cockpitID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cockpitID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cockpitID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cockpitID"));
                }
                SetPropertyExists("cockpitID", exists);
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionMeshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionMeshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionMeshName"));
                }
                SetPropertyExists("collisionMeshName", exists);
                _sizeShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sizeShipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("sizeShipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("sizeShipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "sizeShipClass"));
                }
                SetPropertyExists("sizeShipClass", exists);
                _combatAIClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "combatAIClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("combatAIClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("combatAIClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "combatAIClass"));
                }
                SetPropertyExists("combatAIClass", exists);
                _minimumMiningRoidSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumMiningRoidSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("minimumMiningRoidSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("minimumMiningRoidSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "minimumMiningRoidSize"));
                }
                SetPropertyExists("minimumMiningRoidSize", exists);
                _gravityDriveParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityDriveParticleSystem", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("gravityDriveParticleSystem", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("gravityDriveParticleSystem", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "gravityDriveParticleSystem"));
                }
                SetPropertyExists("gravityDriveParticleSystem", exists);
                _selfDestructAreaOfEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "selfDestructAreaOfEffectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("selfDestructAreaOfEffectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("selfDestructAreaOfEffectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "selfDestructAreaOfEffectID"));
                }
                SetPropertyExists("selfDestructAreaOfEffectID", exists);
                _towardsEnemy = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "towardsEnemy", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("towardsEnemy", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("towardsEnemy", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "towardsEnemy"));
                }
                SetPropertyExists("towardsEnemy", exists);
                _baseID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "baseID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("baseID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("baseID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "baseID"));
                }
                SetPropertyExists("baseID", exists);

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
                _preExplosionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "preExplosionID", out exists));
                _preExplosionID.CollectionChanged += OnpreExplosionIDChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("preExplosionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("preExplosionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "preExplosionID"));
                }
                SetPropertyExists("preExplosionID", exists);
                _hangarID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "hangarID", out exists));
                _hangarID.CollectionChanged += OnhangarIDChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hangarID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hangarID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hangarID"));
                }
                SetPropertyExists("hangarID", exists);

                _creditCost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "creditCost", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("creditCost", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("creditCost", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "creditCost"));
                }
                SetPropertyExists("creditCost", exists);
                _shipHangarYOffset = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shipHangarYOffset", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipHangarYOffset", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipHangarYOffset", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipHangarYOffset"));
                }
                SetPropertyExists("shipHangarYOffset", exists);
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
                _missionRankRequired = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "missionRankRequired", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("missionRankRequired", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("missionRankRequired", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "missionRankRequired"));
                }
                SetPropertyExists("missionRankRequired", exists);
                _discoveryRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "discoveryRange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("discoveryRange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("discoveryRange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "discoveryRange"));
                }
                SetPropertyExists("discoveryRange", exists);
                _detectionRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionRange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("detectionRange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("detectionRange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "detectionRange"));
                }
                SetPropertyExists("detectionRange", exists);
                _shieldHealth = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shieldHealth", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldHealth", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldHealth", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldHealth"));
                }
                SetPropertyExists("shieldHealth", exists);
                _captureRating = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "captureRating", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("captureRating", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("captureRating", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "captureRating"));
                }
                SetPropertyExists("captureRating", exists);
                _boardingCrew = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "boardingCrew", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("boardingCrew", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("boardingCrew", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "boardingCrew"));
                }
                SetPropertyExists("boardingCrew", exists);
                _aggressiveRange = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "aggressiveRange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("aggressiveRange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("aggressiveRange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "aggressiveRange"));
                }
                SetPropertyExists("aggressiveRange", exists);
                _passangerCapacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "passangerCapacity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("passangerCapacity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("passangerCapacity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "passangerCapacity"));
                }
                SetPropertyExists("passangerCapacity", exists);
                _upKeepOverride = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "upKeepOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upKeepOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upKeepOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upKeepOverride"));
                }
                SetPropertyExists("upKeepOverride", exists);

                _cruiseSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "cruiseSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cruiseSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cruiseSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cruiseSpeed"));
                }
                SetPropertyExists("cruiseSpeed", exists);
                _timeTillCruise = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillCruise", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("timeTillCruise", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("timeTillCruise", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "timeTillCruise"));
                }
                SetPropertyExists("timeTillCruise", exists);
                _yaw = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "yaw", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("yaw", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("yaw", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "yaw"));
                }
                SetPropertyExists("yaw", exists);
                _pitch = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitch", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("pitch", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("pitch", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "pitch"));
                }
                SetPropertyExists("pitch", exists);
                _roll = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "roll", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("roll", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("roll", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "roll"));
                }
                SetPropertyExists("roll", exists);
                _health = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "health", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("health", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("health", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "health"));
                }
                SetPropertyExists("health", exists);
                _buildTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "buildTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("buildTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("buildTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "buildTime"));
                }
                SetPropertyExists("buildTime", exists);
                _crew = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "crew", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("crew", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("crew", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "crew"));
                }
                SetPropertyExists("crew", exists);
                _energy = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "energy", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("energy", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("energy", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "energy"));
                }
                SetPropertyExists("energy", exists);
                _ore = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "ore", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ore", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ore", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ore"));
                }
                SetPropertyExists("ore", exists);
                _deathTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "deathTimer", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("deathTimer", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("deathTimer", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "deathTimer"));
                }
                SetPropertyExists("deathTimer", exists);
                _armor = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "armor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("armor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("armor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "armor"));
                }
                SetPropertyExists("armor", exists);

                _bCommsOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCommsOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCommsOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCommsOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCommsOverride"));
                }
                SetPropertyExists("bCommsOverride", exists);
                _bGravityDrive = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGravityDrive", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bGravityDrive", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bGravityDrive", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bGravityDrive"));
                }
                SetPropertyExists("bGravityDrive", exists);
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
                _bHideShipInCockpitAcutal = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHideShipInCockpitAcutal", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bHideShipInCockpitAcutal", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bHideShipInCockpitAcutal", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bHideShipInCockpitAcutal"));
                }
                SetPropertyExists("bHideShipInCockpitAcutal", exists);
                _bPlayerSharedFire = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPlayerSharedFire", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPlayerSharedFire", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPlayerSharedFire", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPlayerSharedFire"));
                }
                SetPropertyExists("bPlayerSharedFire", exists);
                _bNotSoldUnlessOwnedBase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNotSoldUnlessOwnedBase", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNotSoldUnlessOwnedBase", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNotSoldUnlessOwnedBase", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNotSoldUnlessOwnedBase"));
                }
                SetPropertyExists("bNotSoldUnlessOwnedBase", exists);
                _bBlackMarket = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBlackMarket", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bBlackMarket", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bBlackMarket", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bBlackMarket"));
                }
                SetPropertyExists("bBlackMarket", exists);
                _bUniqueShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUniqueShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bUniqueShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bUniqueShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bUniqueShip"));
                }
                SetPropertyExists("bUniqueShip", exists);
                _bShowInCockpitParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitParticles", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bShowInCockpitParticles", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bShowInCockpitParticles", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bShowInCockpitParticles"));
                }
                SetPropertyExists("bShowInCockpitParticles", exists);
                _bCanNotSell = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanNotSell", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCanNotSell", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCanNotSell", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCanNotSell"));
                }
                SetPropertyExists("bCanNotSell", exists);
                _bRequiresKnowledge = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresKnowledge", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRequiresKnowledge", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRequiresKnowledge", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRequiresKnowledge"));
                }
                SetPropertyExists("bRequiresKnowledge", exists);
                _bListedNoPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bListedNoPurchase", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bListedNoPurchase", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bListedNoPurchase", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bListedNoPurchase"));
                }
                SetPropertyExists("bListedNoPurchase", exists);
                _bLargeHangarOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeHangarOnly", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bLargeHangarOnly", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bLargeHangarOnly", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bLargeHangarOnly"));
                }
                SetPropertyExists("bLargeHangarOnly", exists);
                _bNoTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoTargetAimNodeOffset", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoTargetAimNodeOffset", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoTargetAimNodeOffset", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoTargetAimNodeOffset"));
                }
                SetPropertyExists("bNoTargetAimNodeOffset", exists);
                _bEveryShipyardOk = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bEveryShipyardOk", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bEveryShipyardOk", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bEveryShipyardOk", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bEveryShipyardOk"));
                }
                SetPropertyExists("bEveryShipyardOk", exists);
                _bShowInCockpitWeaponParticles = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInCockpitWeaponParticles", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bShowInCockpitWeaponParticles", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bShowInCockpitWeaponParticles", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bShowInCockpitWeaponParticles"));
                }
                SetPropertyExists("bShowInCockpitWeaponParticles", exists);
                _bLargeDockOnly = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLargeDockOnly", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bLargeDockOnly", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bLargeDockOnly", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bLargeDockOnly"));
                }
                SetPropertyExists("bLargeDockOnly", exists);
                _bBaseBuildOverride = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bBaseBuildOverride", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bBaseBuildOverride", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bBaseBuildOverride", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bBaseBuildOverride"));
                }
                SetPropertyExists("bBaseBuildOverride", exists);
                _bSaveFileUnlockShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSaveFileUnlockShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bSaveFileUnlockShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bSaveFileUnlockShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bSaveFileUnlockShip"));
                }
                SetPropertyExists("bSaveFileUnlockShip", exists);
                _bCanPurchase = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanPurchase", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCanPurchase", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCanPurchase", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCanPurchase"));
                }
                SetPropertyExists("bCanPurchase", exists);
                _bNoShipyardRequirement = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShipyardRequirement", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoShipyardRequirement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoShipyardRequirement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoShipyardRequirement"));
                }
                SetPropertyExists("bNoShipyardRequirement", exists);

                _cockpitInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitInitPos", out exists);
                _cockpitInitPos.OnElementChanged += cockpitInitPos_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cockpitInitPos", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cockpitInitPos", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cockpitInitPos"));
                }
                SetPropertyExists("cockpitInitPos", exists);
                _cockpitTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitTransLimit", out exists);
                _cockpitTransLimit.OnElementChanged += cockpitTransLimit_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cockpitTransLimit", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cockpitTransLimit", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cockpitTransLimit"));
                }
                SetPropertyExists("cockpitTransLimit", exists);
                _chaseInitPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseInitPos", out exists);
                _chaseInitPos.OnElementChanged += chaseInitPos_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("chaseInitPos", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("chaseInitPos", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "chaseInitPos"));
                }
                SetPropertyExists("chaseInitPos", exists);
                _chaseTransLimit = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "chaseTransLimit", out exists);
                _chaseTransLimit.OnElementChanged += chaseTransLimit_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("chaseTransLimit", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("chaseTransLimit", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "chaseTransLimit"));
                }
                SetPropertyExists("chaseTransLimit", exists);
                _deathSpin = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "deathSpin", out exists);
                _deathSpin.OnElementChanged += deathSpin_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("deathSpin", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("deathSpin", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "deathSpin"));
                }
                SetPropertyExists("deathSpin", exists);
                _cockpitActualPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "cockpitActualPos", out exists);
                _cockpitActualPos.OnElementChanged += cockpitActualPos_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cockpitActualPos", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cockpitActualPos", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cockpitActualPos"));
                }
                SetPropertyExists("cockpitActualPos", exists);
                _shipHangarPosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "shipHangarPosition", out exists);
                _shipHangarPosition.OnElementChanged += shipHangarPosition_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipHangarPosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipHangarPosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipHangarPosition"));
                }
                SetPropertyExists("shipHangarPosition", exists);

                _debrisInfo = DataStructureParseHelpers.GetdebrisInfoDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("debrisInfo", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("debrisInfo", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "debrisInfo"));
                }
                SetPropertyExists("debrisInfo", exists);
                _afterburner = DataStructureParseHelpers.GetafterburnerDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("afterburner", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("afterburner", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "afterburner"));
                }
                SetPropertyExists("afterburner", exists);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("targetPriorityList", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("targetPriorityList", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "targetPriorityList"));
                }
                SetPropertyExists("targetPriorityList", exists);
                _upgrades = DataStructureParseHelpers.GetupgradesDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upgrades", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upgrades", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upgrades"));
                }
                SetPropertyExists("upgrades", exists);

                _propulsion =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetpropulsionDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _propulsion.CollectionChanged += OnpropulsionChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("propulsion", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("propulsion", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "propulsion"));
                }
                SetPropertyExists("propulsion", exists);
                _weapon =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetweaponDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _weapon.CollectionChanged += OnweaponChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weapon"));
                }
                SetPropertyExists("weapon", exists);
                _damage =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetdamageDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _damage.CollectionChanged += OndamageChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damage", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damage"));
                }
                SetPropertyExists("damage", exists);
                _turret =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetturretDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _turret.CollectionChanged += OnturretChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turret", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turret"));
                }
                SetPropertyExists("turret", exists);
                _attachment =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetattachmentDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _attachment.CollectionChanged += OnattachmentChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("attachment", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("attachment", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "attachment"));
                }
                SetPropertyExists("attachment", exists);
                _movingElement =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetmovingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _movingElement.CollectionChanged += OnmovingElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("movingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("movingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "movingElement"));
                }
                SetPropertyExists("movingElement", exists);
                _dock =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetdockDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _dock.CollectionChanged += OndockChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dock", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dock", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dock"));
                }
                SetPropertyExists("dock", exists);
                _shield =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetshieldDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _shield.CollectionChanged += OnshieldChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shield", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shield", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shield"));
                }
                SetPropertyExists("shield", exists);
                _rotatingElement =  new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetrotatingElementDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _rotatingElement.CollectionChanged += OnrotatingElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rotatingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rotatingElement"));
                }
                SetPropertyExists("rotatingElement", exists);
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
            if (PropertyExists("objectType"))
            {
                xmltextlines.Add("<objectType attr1=\"" + _objectType + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("faction"))
            {
                xmltextlines.Add("<faction attr1=\"" + _faction + "\"/>");
            }
            if (PropertyExists("shipClass"))
            {
                xmltextlines.Add("<shipClass attr1=\"" + _shipClass + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("tacticalExplosionID"))
            {
                xmltextlines.Add("<tacticalExplosionID attr1=\"" + _tacticalExplosionID + "\"/>");
            }
            if (PropertyExists("engineSoundID"))
            {
                xmltextlines.Add("<engineSoundID attr1=\"" + _engineSoundID + "\"/>");
            }
            if (PropertyExists("propulsionRibbonID"))
            {
                xmltextlines.Add("<propulsionRibbonID attr1=\"" + _propulsionRibbonID + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("cockpitActualMesh"))
            {
                xmltextlines.Add("<cockpitActualMesh attr1=\"" + _cockpitActualMesh + "\"/>");
            }
            if (PropertyExists("shipClassSize"))
            {
                xmltextlines.Add("<shipClassSize attr1=\"" + _shipClassSize + "\"/>");
            }
            if (PropertyExists("soldByFaction"))
            {
                xmltextlines.Add("<soldByFaction attr1=\"" + _soldByFaction + "\"/>");
            }
            if (PropertyExists("cockpitID"))
            {
                xmltextlines.Add("<cockpitID attr1=\"" + _cockpitID + "\"/>");
            }
            if (PropertyExists("collisionMeshName"))
            {
                xmltextlines.Add("<collisionMeshName attr1=\"" + _collisionMeshName + "\"/>");
            }
            if (PropertyExists("sizeShipClass"))
            {
                xmltextlines.Add("<sizeShipClass attr1=\"" + _sizeShipClass + "\"/>");
            }
            if (PropertyExists("combatAIClass"))
            {
                xmltextlines.Add("<combatAIClass attr1=\"" + _combatAIClass + "\"/>");
            }
            if (PropertyExists("minimumMiningRoidSize"))
            {
                xmltextlines.Add("<minimumMiningRoidSize attr1=\"" + _minimumMiningRoidSize + "\"/>");
            }
            if (PropertyExists("gravityDriveParticleSystem"))
            {
                xmltextlines.Add("<gravityDriveParticleSystem attr1=\"" + _gravityDriveParticleSystem + "\"/>");
            }
            if (PropertyExists("selfDestructAreaOfEffectID"))
            {
                xmltextlines.Add("<selfDestructAreaOfEffectID attr1=\"" + _selfDestructAreaOfEffectID + "\"/>");
            }
            if (PropertyExists("towardsEnemy"))
            {
                xmltextlines.Add("<towardsEnemy attr1=\"" + _towardsEnemy + "\"/>");
            }
            if (PropertyExists("baseID"))
            {
                xmltextlines.Add("<baseID attr1=\"" + _baseID + "\"/>");
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
            if (PropertyExists("preExplosionID"))
            {
                foreach (string result in _preExplosionID)
                {
                    xmltextlines.Add("<preExplosionID attr1=\"" + result + "\"/>");
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
            if (PropertyExists("creditCost"))
            {
                xmltextlines.Add("<creditCost attr1=\"" + _creditCost.ToString() + "\"/>");
            }
            if (PropertyExists("shipHangarYOffset"))
            {
                xmltextlines.Add("<shipHangarYOffset attr1=\"" + _shipHangarYOffset.ToString() + "\"/>");
            }
            if (PropertyExists("rockSubPosition"))
            {
                xmltextlines.Add("<rockSubPosition attr1=\"" + _rockSubPosition.ToString() + "\"/>");
            }
            if (PropertyExists("missionRankRequired"))
            {
                xmltextlines.Add("<missionRankRequired attr1=\"" + _missionRankRequired.ToString() + "\"/>");
            }
            if (PropertyExists("discoveryRange"))
            {
                xmltextlines.Add("<discoveryRange attr1=\"" + _discoveryRange.ToString() + "\"/>");
            }
            if (PropertyExists("detectionRange"))
            {
                xmltextlines.Add("<detectionRange attr1=\"" + _detectionRange.ToString() + "\"/>");
            }
            if (PropertyExists("shieldHealth"))
            {
                xmltextlines.Add("<shieldHealth attr1=\"" + _shieldHealth.ToString() + "\"/>");
            }
            if (PropertyExists("captureRating"))
            {
                xmltextlines.Add("<captureRating attr1=\"" + _captureRating.ToString() + "\"/>");
            }
            if (PropertyExists("boardingCrew"))
            {
                xmltextlines.Add("<boardingCrew attr1=\"" + _boardingCrew.ToString() + "\"/>");
            }
            if (PropertyExists("aggressiveRange"))
            {
                xmltextlines.Add("<aggressiveRange attr1=\"" + _aggressiveRange.ToString() + "\"/>");
            }
            if (PropertyExists("passangerCapacity"))
            {
                xmltextlines.Add("<passangerCapacity attr1=\"" + _passangerCapacity.ToString() + "\"/>");
            }
            if (PropertyExists("upKeepOverride"))
            {
                xmltextlines.Add("<upKeepOverride attr1=\"" + _upKeepOverride.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("cruiseSpeed"))
            {
                xmltextlines.Add("<cruiseSpeed attr1=\"" + _cruiseSpeed.ToString() + "\"/>");
            }
            if (PropertyExists("timeTillCruise"))
            {
                xmltextlines.Add("<timeTillCruise attr1=\"" + _timeTillCruise.ToString() + "\"/>");
            }
            if (PropertyExists("yaw"))
            {
                xmltextlines.Add("<yaw attr1=\"" + _yaw.ToString() + "\"/>");
            }
            if (PropertyExists("pitch"))
            {
                xmltextlines.Add("<pitch attr1=\"" + _pitch.ToString() + "\"/>");
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add("<roll attr1=\"" + _roll.ToString() + "\"/>");
            }
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
            }
            if (PropertyExists("buildTime"))
            {
                xmltextlines.Add("<buildTime attr1=\"" + _buildTime.ToString() + "\"/>");
            }
            if (PropertyExists("crew"))
            {
                xmltextlines.Add("<crew attr1=\"" + _crew.ToString() + "\"/>");
            }
            if (PropertyExists("energy"))
            {
                xmltextlines.Add("<energy attr1=\"" + _energy.ToString() + "\"/>");
            }
            if (PropertyExists("ore"))
            {
                xmltextlines.Add("<ore attr1=\"" + _ore.ToString() + "\"/>");
            }
            if (PropertyExists("deathTimer"))
            {
                xmltextlines.Add("<deathTimer attr1=\"" + _deathTimer.ToString() + "\"/>");
            }
            if (PropertyExists("armor"))
            {
                xmltextlines.Add("<armor attr1=\"" + _armor.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bCommsOverride"))
            {
                xmltextlines.Add("<bCommsOverride attr1=\"" + ((_bCommsOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bGravityDrive"))
            {
                xmltextlines.Add("<bGravityDrive attr1=\"" + ((_bGravityDrive) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bHideShipInCockpitAcutal"))
            {
                xmltextlines.Add("<bHideShipInCockpitAcutal attr1=\"" + ((_bHideShipInCockpitAcutal) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPlayerSharedFire"))
            {
                xmltextlines.Add("<bPlayerSharedFire attr1=\"" + ((_bPlayerSharedFire) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNotSoldUnlessOwnedBase"))
            {
                xmltextlines.Add("<bNotSoldUnlessOwnedBase attr1=\"" + ((_bNotSoldUnlessOwnedBase) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bBlackMarket"))
            {
                xmltextlines.Add("<bBlackMarket attr1=\"" + ((_bBlackMarket) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bUniqueShip"))
            {
                xmltextlines.Add("<bUniqueShip attr1=\"" + ((_bUniqueShip) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bShowInCockpitParticles"))
            {
                xmltextlines.Add("<bShowInCockpitParticles attr1=\"" + ((_bShowInCockpitParticles) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanNotSell"))
            {
                xmltextlines.Add("<bCanNotSell attr1=\"" + ((_bCanNotSell) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bRequiresKnowledge"))
            {
                xmltextlines.Add("<bRequiresKnowledge attr1=\"" + ((_bRequiresKnowledge) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bListedNoPurchase"))
            {
                xmltextlines.Add("<bListedNoPurchase attr1=\"" + ((_bListedNoPurchase) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bLargeHangarOnly"))
            {
                xmltextlines.Add("<bLargeHangarOnly attr1=\"" + ((_bLargeHangarOnly) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoTargetAimNodeOffset"))
            {
                xmltextlines.Add("<bNoTargetAimNodeOffset attr1=\"" + ((_bNoTargetAimNodeOffset) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bEveryShipyardOk"))
            {
                xmltextlines.Add("<bEveryShipyardOk attr1=\"" + ((_bEveryShipyardOk) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bShowInCockpitWeaponParticles"))
            {
                xmltextlines.Add("<bShowInCockpitWeaponParticles attr1=\"" + ((_bShowInCockpitWeaponParticles) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bLargeDockOnly"))
            {
                xmltextlines.Add("<bLargeDockOnly attr1=\"" + ((_bLargeDockOnly) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bBaseBuildOverride"))
            {
                xmltextlines.Add("<bBaseBuildOverride attr1=\"" + ((_bBaseBuildOverride) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bSaveFileUnlockShip"))
            {
                xmltextlines.Add("<bSaveFileUnlockShip attr1=\"" + ((_bSaveFileUnlockShip) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanPurchase"))
            {
                xmltextlines.Add("<bCanPurchase attr1=\"" + ((_bCanPurchase) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoShipyardRequirement"))
            {
                xmltextlines.Add("<bNoShipyardRequirement attr1=\"" + ((_bNoShipyardRequirement) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("cockpitInitPos"))
            {
                xmltextlines.Add("<cockpitInitPos x=\"" + _cockpitInitPos.x.ToString() + "\" y=\"" + _cockpitInitPos.y.ToString() + "\" z=\"" + _cockpitInitPos.z.ToString() + "\"/>");
            }
            if (PropertyExists("cockpitTransLimit"))
            {
                xmltextlines.Add("<cockpitTransLimit x=\"" + _cockpitTransLimit.x.ToString() + "\" y=\"" + _cockpitTransLimit.y.ToString() + "\" z=\"" + _cockpitTransLimit.z.ToString() + "\"/>");
            }
            if (PropertyExists("chaseInitPos"))
            {
                xmltextlines.Add("<chaseInitPos x=\"" + _chaseInitPos.x.ToString() + "\" y=\"" + _chaseInitPos.y.ToString() + "\" z=\"" + _chaseInitPos.z.ToString() + "\"/>");
            }
            if (PropertyExists("chaseTransLimit"))
            {
                xmltextlines.Add("<chaseTransLimit x=\"" + _chaseTransLimit.x.ToString() + "\" y=\"" + _chaseTransLimit.y.ToString() + "\" z=\"" + _chaseTransLimit.z.ToString() + "\"/>");
            }
            if (PropertyExists("deathSpin"))
            {
                xmltextlines.Add("<deathSpin x=\"" + _deathSpin.x.ToString() + "\" y=\"" + _deathSpin.y.ToString() + "\" z=\"" + _deathSpin.z.ToString() + "\"/>");
            }
            if (PropertyExists("cockpitActualPos"))
            {
                xmltextlines.Add("<cockpitActualPos x=\"" + _cockpitActualPos.x.ToString() + "\" y=\"" + _cockpitActualPos.y.ToString() + "\" z=\"" + _cockpitActualPos.z.ToString() + "\"/>");
            }
            if (PropertyExists("shipHangarPosition"))
            {
                xmltextlines.Add("<shipHangarPosition x=\"" + _shipHangarPosition.x.ToString() + "\" y=\"" + _shipHangarPosition.y.ToString() + "\" z=\"" + _shipHangarPosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("debrisInfo"))
            {
                xmltextlines.AddRange(_debrisInfo.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("afterburner"))
            {
                xmltextlines.AddRange(_afterburner.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("targetPriorityList"))
            {
                xmltextlines.AddRange(_targetPriorityList.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("upgrades"))
            {
                xmltextlines.AddRange(_upgrades.AsVD2XML());
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
            if (PropertyExists("weapon"))
            {
                foreach (weaponDataStructure result in _weapon)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("damage"))
            {
                foreach (damageDataStructure result in _damage)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("turret"))
            {
                foreach (turretDataStructure result in _turret)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("attachment"))
            {
                foreach (attachmentDataStructure result in _attachment)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("movingElement"))
            {
                foreach (movingElementDataStructure result in _movingElement)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("dock"))
            {
                foreach (dockDataStructure result in _dock)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("shield"))
            {
                foreach (shieldDataStructure result in _shield)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("rotatingElement"))
            {
                foreach (rotatingElementDataStructure result in _rotatingElement)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }

        public override Control GetDocumentControl()
        {
            Control baseresult = base.GetDocumentControl();
            if (baseresult != null)
            {
                if (baseresult is DataDocumentControl)
                {
                    DataDocumentControl result = (DataDocumentControl)baseresult;
                    result.MainSplitter.Panel2Collapsed = false;
                    result.SidebarSplitter.Panel1Collapsed = false;

                    ShipOgreControl modelviewer = new ShipOgreControl();
                    modelviewer.DataFile = this;
                    modelviewer.Dock = DockStyle.Fill;
                    modelviewer.Name = Source.ShortName + objectID + "datamv";
                    result.SidebarSplitter.Panel1.Controls.Add(modelviewer);
                    return result;
                }
            }
            return baseresult;
        }

        public override string GetDocumentIconKey()
        {
            switch (shipClass)
            {
                case "fighter_drone":
                    return "droneicon";
                case "fighter":
                    return "fightericon";
                case "gunship":
                    return "gunshipicon";
                case "corvette":
                    return "corvetteicon";
                case "frigate":
                    return "frigateicon";
                case "destroyer":
                    return ("destroyericon");
                case "cruiser":
                    return ("cruisericon");
                case "carrier":
                    return ("carriericon");
                case "dreadnaught":
                    return ("dreadnaughticon");
                case "transport":
                    return ("transporticon");
                case "mining":
                    return ("minericon");
                case "shuttle":
                    return ("shuttleicon");
                case "repair":
                    return ("repairicon");
                case "ship_capture":
                    return ("shipcaptureicon");
                case "capture":
                    return ("basecaptureicon");
                case "builder":
                    return ("buildericon");
                default:
                    return ("genericfileicon");
            }
        }
    }
}
