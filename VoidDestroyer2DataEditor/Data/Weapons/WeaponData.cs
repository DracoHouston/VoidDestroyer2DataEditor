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
    class WeaponData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _name;
        string _materialName;
        string _hitParticleName;
        string _muzzleFlashEffectID;
        string _gravityObjectType;
        string _maxShipSize;
        string _shieldID;
        string _ammunitionID;
        string _projectileWeaponType;
        string _instantType;
        string _explosionID;
        string _chargeSoundID;
        string _chargedSoundID;
        string _chargeParticleName;
        string _auxAmmunitionID;
        string _linkedRotatingElement;
        string _beamShieldID;
        string _collisionWeaponType;
        string _particleEffectName;
        string _beamType;
        string _hitSound;
        string _fireParticleName;
        string _linkedMovingElement;
        string _minimumShipClass;
        string _hangarID;

        List<string> _fireSoundID;

        int _distance;
        int _roundsPerShot;
        int _rotateSpeed;

        float _damage;
        float _range;
        float _baseScale;
        float _oscilateRange;
        float _oscilateAmount;
        float _capacity;
        float _reloadTime;
        float _assistDegree;
        float _reFireRate;
        float _parentPush;
        float _penetrateZ;
        float _speedChange;
        float _weaponPush;
        float _visualTimer;
        float _pullSpeed;
        float _disableRate;

        List<float> _scatterYaw;
        List<float> _scatterPitch;

        bool _bNoAimAssist;
        bool _bAlwaysPlayFireSound;
        bool _bFireFullAmmo;
        bool _bSticky;
        bool _bCapture;
        bool _bReduceMassOnStick;
        bool _bChargeGun;
        bool _bAntiCapShip;
        bool _bIgnoresShields;
        bool _bAddRandom;
        bool _bMining;
        bool _bRepair;
        bool _bAntiCapital;

        Vector3D _size;
        Vector3D _particlePosition;

        ColorF _color;

        recoilDataStructure _recoil;
        rotateBonesDataStructure _rotateBones;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                _weaponType = value;
                SetPropertyEdited("weaponType", true);
            }
        }

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponID
        {
            get
            {
                return _weaponID;
            }
            set
            {
                _weaponID = value;
                SetPropertyEdited("weaponID", true);
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

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                _materialName = value;
                SetPropertyEdited("materialName", true);
            }
        }

        [Description("hitParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hitParticleName
        {
            get
            {
                return _hitParticleName;
            }
            set
            {
                _hitParticleName = value;
                SetPropertyEdited("hitParticleName", true);
            }
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string muzzleFlashEffectID
        {
            get
            {
                return _muzzleFlashEffectID;
            }
            set
            {
                _muzzleFlashEffectID = value;
                SetPropertyEdited("muzzleFlashEffectID", true);
            }
        }

        [Description("gravityObjectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gravityObjectType
        {
            get
            {
                return _gravityObjectType;
            }
            set
            {
                _gravityObjectType = value;
                SetPropertyEdited("gravityObjectType", true);
            }
        }

        [Description("maxShipSize is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string maxShipSize
        {
            get
            {
                return _maxShipSize;
            }
            set
            {
                _maxShipSize = value;
                SetPropertyEdited("maxShipSize", true);
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

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ammunitionID
        {
            get
            {
                return _ammunitionID;
            }
            set
            {
                _ammunitionID = value;
                SetPropertyEdited("ammunitionID", true);
            }
        }

        [Description("projectileWeaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileWeaponType
        {
            get
            {
                return _projectileWeaponType;
            }
            set
            {
                _projectileWeaponType = value;
                SetPropertyEdited("projectileWeaponType", true);
            }
        }

        [Description("instantType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string instantType
        {
            get
            {
                return _instantType;
            }
            set
            {
                _instantType = value;
                SetPropertyEdited("instantType", true);
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

        [Description("chargeSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string chargeSoundID
        {
            get
            {
                return _chargeSoundID;
            }
            set
            {
                _chargeSoundID = value;
                SetPropertyEdited("chargeSoundID", true);
            }
        }

        [Description("chargedSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string chargedSoundID
        {
            get
            {
                return _chargedSoundID;
            }
            set
            {
                _chargedSoundID = value;
                SetPropertyEdited("chargedSoundID", true);
            }
        }

        [Description("chargeParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string chargeParticleName
        {
            get
            {
                return _chargeParticleName;
            }
            set
            {
                _chargeParticleName = value;
                SetPropertyEdited("chargeParticleName", true);
            }
        }

        [Description("auxAmmunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string auxAmmunitionID
        {
            get
            {
                return _auxAmmunitionID;
            }
            set
            {
                _auxAmmunitionID = value;
                SetPropertyEdited("auxAmmunitionID", true);
            }
        }

        [Description("linkedRotatingElement is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string linkedRotatingElement
        {
            get
            {
                return _linkedRotatingElement;
            }
            set
            {
                _linkedRotatingElement = value;
                SetPropertyEdited("linkedRotatingElement", true);
            }
        }

        [Description("beamShieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string beamShieldID
        {
            get
            {
                return _beamShieldID;
            }
            set
            {
                _beamShieldID = value;
                SetPropertyEdited("beamShieldID", true);
            }
        }

        [Description("collisionWeaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionWeaponType
        {
            get
            {
                return _collisionWeaponType;
            }
            set
            {
                _collisionWeaponType = value;
                SetPropertyEdited("collisionWeaponType", true);
            }
        }

        [Description("particleEffectName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string particleEffectName
        {
            get
            {
                return _particleEffectName;
            }
            set
            {
                _particleEffectName = value;
                SetPropertyEdited("particleEffectName", true);
            }
        }

        [Description("beamType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string beamType
        {
            get
            {
                return _beamType;
            }
            set
            {
                _beamType = value;
                SetPropertyEdited("beamType", true);
            }
        }

        [Description("hitSound is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hitSound
        {
            get
            {
                return _hitSound;
            }
            set
            {
                _hitSound = value;
                SetPropertyEdited("hitSound", true);
            }
        }

        [Description("fireParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string fireParticleName
        {
            get
            {
                return _fireParticleName;
            }
            set
            {
                _fireParticleName = value;
                SetPropertyEdited("fireParticleName", true);
            }
        }

        [Description("linkedMovingElement is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string linkedMovingElement
        {
            get
            {
                return _linkedMovingElement;
            }
            set
            {
                _linkedMovingElement = value;
                SetPropertyEdited("linkedMovingElement", true);
            }
        }

        [Description("minimumShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string minimumShipClass
        {
            get
            {
                return _minimumShipClass;
            }
            set
            {
                _minimumShipClass = value;
                SetPropertyEdited("minimumShipClass", true);
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


        [Description("fireSoundID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> fireSoundID
        {
            get
            {
                return _fireSoundID;
            }
            set
            {
                _fireSoundID = value;
                SetPropertyEdited("fireSoundID", true);
            }
        }


        [Description("distance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int distance
        {
            get
            {
                return _distance;
            }
            set
            {
                _distance = value;
                SetPropertyEdited("distance", true);
            }
        }

        [Description("roundsPerShot is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int roundsPerShot
        {
            get
            {
                return _roundsPerShot;
            }
            set
            {
                _roundsPerShot = value;
                SetPropertyEdited("roundsPerShot", true);
            }
        }

        [Description("rotateSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rotateSpeed
        {
            get
            {
                return _rotateSpeed;
            }
            set
            {
                _rotateSpeed = value;
                SetPropertyEdited("rotateSpeed", true);
            }
        }


        [Description("damage is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float damage
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

        [Description("range is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
                SetPropertyEdited("range", true);
            }
        }

        [Description("baseScale is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float baseScale
        {
            get
            {
                return _baseScale;
            }
            set
            {
                _baseScale = value;
                SetPropertyEdited("baseScale", true);
            }
        }

        [Description("oscilateRange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float oscilateRange
        {
            get
            {
                return _oscilateRange;
            }
            set
            {
                _oscilateRange = value;
                SetPropertyEdited("oscilateRange", true);
            }
        }

        [Description("oscilateAmount is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float oscilateAmount
        {
            get
            {
                return _oscilateAmount;
            }
            set
            {
                _oscilateAmount = value;
                SetPropertyEdited("oscilateAmount", true);
            }
        }

        [Description("capacity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                _capacity = value;
                SetPropertyEdited("capacity", true);
            }
        }

        [Description("reloadTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reloadTime
        {
            get
            {
                return _reloadTime;
            }
            set
            {
                _reloadTime = value;
                SetPropertyEdited("reloadTime", true);
            }
        }

        [Description("assistDegree is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float assistDegree
        {
            get
            {
                return _assistDegree;
            }
            set
            {
                _assistDegree = value;
                SetPropertyEdited("assistDegree", true);
            }
        }

        [Description("reFireRate is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reFireRate
        {
            get
            {
                return _reFireRate;
            }
            set
            {
                _reFireRate = value;
                SetPropertyEdited("reFireRate", true);
            }
        }

        [Description("parentPush is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float parentPush
        {
            get
            {
                return _parentPush;
            }
            set
            {
                _parentPush = value;
                SetPropertyEdited("parentPush", true);
            }
        }

        [Description("penetrateZ is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float penetrateZ
        {
            get
            {
                return _penetrateZ;
            }
            set
            {
                _penetrateZ = value;
                SetPropertyEdited("penetrateZ", true);
            }
        }

        [Description("speedChange is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float speedChange
        {
            get
            {
                return _speedChange;
            }
            set
            {
                _speedChange = value;
                SetPropertyEdited("speedChange", true);
            }
        }

        [Description("weaponPush is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float weaponPush
        {
            get
            {
                return _weaponPush;
            }
            set
            {
                _weaponPush = value;
                SetPropertyEdited("weaponPush", true);
            }
        }

        [Description("visualTimer is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float visualTimer
        {
            get
            {
                return _visualTimer;
            }
            set
            {
                _visualTimer = value;
                SetPropertyEdited("visualTimer", true);
            }
        }

        [Description("pullSpeed is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pullSpeed
        {
            get
            {
                return _pullSpeed;
            }
            set
            {
                _pullSpeed = value;
                SetPropertyEdited("pullSpeed", true);
            }
        }

        [Description("disableRate is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float disableRate
        {
            get
            {
                return _disableRate;
            }
            set
            {
                _disableRate = value;
                SetPropertyEdited("disableRate", true);
            }
        }


        [Description("scatterYaw is a collection of real numbers"), Category("Real Number Collections")]
        public List<float> scatterYaw
        {
            get
            {
                return _scatterYaw;
            }
            set
            {
                _scatterYaw = value;
                SetPropertyEdited("scatterYaw", true);
            }
        }

        [Description("scatterPitch is a collection of real numbers"), Category("Real Number Collections")]
        public List<float> scatterPitch
        {
            get
            {
                return _scatterPitch;
            }
            set
            {
                _scatterPitch = value;
                SetPropertyEdited("scatterPitch", true);
            }
        }


        [Description("bNoAimAssist is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoAimAssist
        {
            get
            {
                return _bNoAimAssist;
            }
            set
            {
                _bNoAimAssist = value;
                SetPropertyEdited("bNoAimAssist", true);
            }
        }

        [Description("bAlwaysPlayFireSound is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAlwaysPlayFireSound
        {
            get
            {
                return _bAlwaysPlayFireSound;
            }
            set
            {
                _bAlwaysPlayFireSound = value;
                SetPropertyEdited("bAlwaysPlayFireSound", true);
            }
        }

        [Description("bFireFullAmmo is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFireFullAmmo
        {
            get
            {
                return _bFireFullAmmo;
            }
            set
            {
                _bFireFullAmmo = value;
                SetPropertyEdited("bFireFullAmmo", true);
            }
        }

        [Description("bSticky is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSticky
        {
            get
            {
                return _bSticky;
            }
            set
            {
                _bSticky = value;
                SetPropertyEdited("bSticky", true);
            }
        }

        [Description("bCapture is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCapture
        {
            get
            {
                return _bCapture;
            }
            set
            {
                _bCapture = value;
                SetPropertyEdited("bCapture", true);
            }
        }

        [Description("bReduceMassOnStick is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bReduceMassOnStick
        {
            get
            {
                return _bReduceMassOnStick;
            }
            set
            {
                _bReduceMassOnStick = value;
                SetPropertyEdited("bReduceMassOnStick", true);
            }
        }

        [Description("bChargeGun is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bChargeGun
        {
            get
            {
                return _bChargeGun;
            }
            set
            {
                _bChargeGun = value;
                SetPropertyEdited("bChargeGun", true);
            }
        }

        [Description("bAntiCapShip is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAntiCapShip
        {
            get
            {
                return _bAntiCapShip;
            }
            set
            {
                _bAntiCapShip = value;
                SetPropertyEdited("bAntiCapShip", true);
            }
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIgnoresShields
        {
            get
            {
                return _bIgnoresShields;
            }
            set
            {
                _bIgnoresShields = value;
                SetPropertyEdited("bIgnoresShields", true);
            }
        }

        [Description("bAddRandom is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAddRandom
        {
            get
            {
                return _bAddRandom;
            }
            set
            {
                _bAddRandom = value;
                SetPropertyEdited("bAddRandom", true);
            }
        }

        [Description("bMining is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bMining
        {
            get
            {
                return _bMining;
            }
            set
            {
                _bMining = value;
                SetPropertyEdited("bMining", true);
            }
        }

        [Description("bRepair is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRepair
        {
            get
            {
                return _bRepair;
            }
            set
            {
                _bRepair = value;
                SetPropertyEdited("bRepair", true);
            }
        }

        [Description("bAntiCapital is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAntiCapital
        {
            get
            {
                return _bAntiCapital;
            }
            set
            {
                _bAntiCapital = value;
                SetPropertyEdited("bAntiCapital", true);
            }
        }


        [Description("size is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                SetPropertyEdited("size", true);
            }
        }

        [Description("particlePosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D particlePosition
        {
            get
            {
                return _particlePosition;
            }
            set
            {
                _particlePosition = value;
                SetPropertyEdited("particlePosition", true);
            }
        }


        [Description("color is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                SetPropertyEdited("color", true);
            }
        }


        [Description("recoil is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public recoilDataStructure recoil
        {
            get
            {
                return _recoil;
            }
            set
            {
                _recoil = value;
                SetPropertyEdited("recoil", true);
            }
        }

        [Description("rotateBones is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public rotateBonesDataStructure rotateBones
        {
            get
            {
                return _rotateBones;
            }
            set
            {
                _rotateBones = value;
                SetPropertyEdited("rotateBones", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            InitProperty("name");
            InitProperty("materialName");
            InitProperty("hitParticleName");
            InitProperty("muzzleFlashEffectID");
            InitProperty("gravityObjectType");
            InitProperty("maxShipSize");
            InitProperty("shieldID");
            InitProperty("ammunitionID");
            InitProperty("projectileWeaponType");
            InitProperty("instantType");
            InitProperty("explosionID");
            InitProperty("chargeSoundID");
            InitProperty("chargedSoundID");
            InitProperty("chargeParticleName");
            InitProperty("auxAmmunitionID");
            InitProperty("linkedRotatingElement");
            InitProperty("beamShieldID");
            InitProperty("collisionWeaponType");
            InitProperty("particleEffectName");
            InitProperty("beamType");
            InitProperty("hitSound");
            InitProperty("fireParticleName");
            InitProperty("linkedMovingElement");
            InitProperty("minimumShipClass");
            InitProperty("hangarID");

            InitProperty("fireSoundID");

            InitProperty("distance");
            InitProperty("roundsPerShot");
            InitProperty("rotateSpeed");

            InitProperty("damage");
            InitProperty("range");
            InitProperty("baseScale");
            InitProperty("oscilateRange");
            InitProperty("oscilateAmount");
            InitProperty("capacity");
            InitProperty("reloadTime");
            InitProperty("assistDegree");
            InitProperty("reFireRate");
            InitProperty("parentPush");
            InitProperty("penetrateZ");
            InitProperty("speedChange");
            InitProperty("weaponPush");
            InitProperty("visualTimer");
            InitProperty("pullSpeed");
            InitProperty("disableRate");

            InitProperty("scatterYaw");
            InitProperty("scatterPitch");

            InitProperty("bNoAimAssist");
            InitProperty("bAlwaysPlayFireSound");
            InitProperty("bFireFullAmmo");
            InitProperty("bSticky");
            InitProperty("bCapture");
            InitProperty("bReduceMassOnStick");
            InitProperty("bChargeGun");
            InitProperty("bAntiCapShip");
            InitProperty("bIgnoresShields");
            InitProperty("bAddRandom");
            InitProperty("bMining");
            InitProperty("bRepair");
            InitProperty("bAntiCapital");

            InitProperty("size");
            InitProperty("particlePosition");

            InitProperty("color");

            InitProperty("recoil");
            InitProperty("rotateBones");

        }

        public WeaponData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                SetPropertyExistsInBaseData("weaponType", exists);
                SetPropertyExists("weaponType", exists);
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                SetPropertyExistsInBaseData("weaponID", exists);
                SetPropertyExists("weaponID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                SetPropertyExistsInBaseData("name", exists);
                SetPropertyExists("name", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                SetPropertyExistsInBaseData("materialName", exists);
                SetPropertyExists("materialName", exists);
                _hitParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitParticleName", out exists);
                SetPropertyExistsInBaseData("hitParticleName", exists);
                SetPropertyExists("hitParticleName", exists);
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID", out exists);
                SetPropertyExistsInBaseData("muzzleFlashEffectID", exists);
                SetPropertyExists("muzzleFlashEffectID", exists);
                _gravityObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityObjectType", out exists);
                SetPropertyExistsInBaseData("gravityObjectType", exists);
                SetPropertyExists("gravityObjectType", exists);
                _maxShipSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxShipSize", out exists);
                SetPropertyExistsInBaseData("maxShipSize", exists);
                SetPropertyExists("maxShipSize", exists);
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                SetPropertyExistsInBaseData("shieldID", exists);
                SetPropertyExists("shieldID", exists);
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID", out exists);
                SetPropertyExistsInBaseData("ammunitionID", exists);
                SetPropertyExists("ammunitionID", exists);
                _projectileWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileWeaponType", out exists);
                SetPropertyExistsInBaseData("projectileWeaponType", exists);
                SetPropertyExists("projectileWeaponType", exists);
                _instantType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantType", out exists);
                SetPropertyExistsInBaseData("instantType", exists);
                SetPropertyExists("instantType", exists);
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID", out exists);
                SetPropertyExistsInBaseData("explosionID", exists);
                SetPropertyExists("explosionID", exists);
                _chargeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeSoundID", out exists);
                SetPropertyExistsInBaseData("chargeSoundID", exists);
                SetPropertyExists("chargeSoundID", exists);
                _chargedSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargedSoundID", out exists);
                SetPropertyExistsInBaseData("chargedSoundID", exists);
                SetPropertyExists("chargedSoundID", exists);
                _chargeParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeParticleName", out exists);
                SetPropertyExistsInBaseData("chargeParticleName", exists);
                SetPropertyExists("chargeParticleName", exists);
                _auxAmmunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "auxAmmunitionID", out exists);
                SetPropertyExistsInBaseData("auxAmmunitionID", exists);
                SetPropertyExists("auxAmmunitionID", exists);
                _linkedRotatingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedRotatingElement", out exists);
                SetPropertyExistsInBaseData("linkedRotatingElement", exists);
                SetPropertyExists("linkedRotatingElement", exists);
                _beamShieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamShieldID", out exists);
                SetPropertyExistsInBaseData("beamShieldID", exists);
                SetPropertyExists("beamShieldID", exists);
                _collisionWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionWeaponType", out exists);
                SetPropertyExistsInBaseData("collisionWeaponType", exists);
                SetPropertyExists("collisionWeaponType", exists);
                _particleEffectName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleEffectName", out exists);
                SetPropertyExistsInBaseData("particleEffectName", exists);
                SetPropertyExists("particleEffectName", exists);
                _beamType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamType", out exists);
                SetPropertyExistsInBaseData("beamType", exists);
                SetPropertyExists("beamType", exists);
                _hitSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitSound", out exists);
                SetPropertyExistsInBaseData("hitSound", exists);
                SetPropertyExists("hitSound", exists);
                _fireParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireParticleName", out exists);
                SetPropertyExistsInBaseData("fireParticleName", exists);
                SetPropertyExists("fireParticleName", exists);
                _linkedMovingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedMovingElement", out exists);
                SetPropertyExistsInBaseData("linkedMovingElement", exists);
                SetPropertyExists("linkedMovingElement", exists);
                _minimumShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumShipClass", out exists);
                SetPropertyExistsInBaseData("minimumShipClass", exists);
                SetPropertyExists("minimumShipClass", exists);
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID", out exists);
                SetPropertyExistsInBaseData("hangarID", exists);
                SetPropertyExists("hangarID", exists);

                _fireSoundID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "fireSoundID", out exists);
                SetPropertyExistsInBaseData("fireSoundID", exists);
                SetPropertyExists("fireSoundID", exists);

                _distance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "distance", out exists);
                SetPropertyExistsInBaseData("distance", exists);
                SetPropertyExists("distance", exists);
                _roundsPerShot = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "roundsPerShot", out exists);
                SetPropertyExistsInBaseData("roundsPerShot", exists);
                SetPropertyExists("roundsPerShot", exists);
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed", out exists);
                SetPropertyExistsInBaseData("rotateSpeed", exists);
                SetPropertyExists("rotateSpeed", exists);

                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage", out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range", out exists);
                SetPropertyExistsInBaseData("range", exists);
                SetPropertyExists("range", exists);
                _baseScale = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "baseScale", out exists);
                SetPropertyExistsInBaseData("baseScale", exists);
                SetPropertyExists("baseScale", exists);
                _oscilateRange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateRange", out exists);
                SetPropertyExistsInBaseData("oscilateRange", exists);
                SetPropertyExists("oscilateRange", exists);
                _oscilateAmount = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateAmount", out exists);
                SetPropertyExistsInBaseData("oscilateAmount", exists);
                SetPropertyExists("oscilateAmount", exists);
                _capacity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "capacity", out exists);
                SetPropertyExistsInBaseData("capacity", exists);
                SetPropertyExists("capacity", exists);
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime", out exists);
                SetPropertyExistsInBaseData("reloadTime", exists);
                SetPropertyExists("reloadTime", exists);
                _assistDegree = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "assistDegree", out exists);
                SetPropertyExistsInBaseData("assistDegree", exists);
                SetPropertyExists("assistDegree", exists);
                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate", out exists);
                SetPropertyExistsInBaseData("reFireRate", exists);
                SetPropertyExists("reFireRate", exists);
                _parentPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "parentPush", out exists);
                SetPropertyExistsInBaseData("parentPush", exists);
                SetPropertyExists("parentPush", exists);
                _penetrateZ = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "penetrateZ", out exists);
                SetPropertyExistsInBaseData("penetrateZ", exists);
                SetPropertyExists("penetrateZ", exists);
                _speedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChange", out exists);
                SetPropertyExistsInBaseData("speedChange", exists);
                SetPropertyExists("speedChange", exists);
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush", out exists);
                SetPropertyExistsInBaseData("weaponPush", exists);
                SetPropertyExists("weaponPush", exists);
                _visualTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "visualTimer", out exists);
                SetPropertyExistsInBaseData("visualTimer", exists);
                SetPropertyExists("visualTimer", exists);
                _pullSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pullSpeed", out exists);
                SetPropertyExistsInBaseData("pullSpeed", exists);
                SetPropertyExists("pullSpeed", exists);
                _disableRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "disableRate", out exists);
                SetPropertyExistsInBaseData("disableRate", exists);
                SetPropertyExists("disableRate", exists);

                _scatterYaw = ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterYaw", out exists);
                SetPropertyExistsInBaseData("scatterYaw", exists);
                SetPropertyExists("scatterYaw", exists);
                _scatterPitch = ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterPitch", out exists);
                SetPropertyExistsInBaseData("scatterPitch", exists);
                SetPropertyExists("scatterPitch", exists);

                _bNoAimAssist = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoAimAssist", out exists);
                SetPropertyExistsInBaseData("bNoAimAssist", exists);
                SetPropertyExists("bNoAimAssist", exists);
                _bAlwaysPlayFireSound = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysPlayFireSound", out exists);
                SetPropertyExistsInBaseData("bAlwaysPlayFireSound", exists);
                SetPropertyExists("bAlwaysPlayFireSound", exists);
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo", out exists);
                SetPropertyExistsInBaseData("bFireFullAmmo", exists);
                SetPropertyExists("bFireFullAmmo", exists);
                _bSticky = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSticky", out exists);
                SetPropertyExistsInBaseData("bSticky", exists);
                SetPropertyExists("bSticky", exists);
                _bCapture = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCapture", out exists);
                SetPropertyExistsInBaseData("bCapture", exists);
                SetPropertyExists("bCapture", exists);
                _bReduceMassOnStick = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReduceMassOnStick", out exists);
                SetPropertyExistsInBaseData("bReduceMassOnStick", exists);
                SetPropertyExists("bReduceMassOnStick", exists);
                _bChargeGun = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bChargeGun", out exists);
                SetPropertyExistsInBaseData("bChargeGun", exists);
                SetPropertyExists("bChargeGun", exists);
                _bAntiCapShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapShip", out exists);
                SetPropertyExistsInBaseData("bAntiCapShip", exists);
                SetPropertyExists("bAntiCapShip", exists);
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields", out exists);
                SetPropertyExistsInBaseData("bIgnoresShields", exists);
                SetPropertyExists("bIgnoresShields", exists);
                _bAddRandom = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAddRandom", out exists);
                SetPropertyExistsInBaseData("bAddRandom", exists);
                SetPropertyExists("bAddRandom", exists);
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining", out exists);
                SetPropertyExistsInBaseData("bMining", exists);
                SetPropertyExists("bMining", exists);
                _bRepair = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepair", out exists);
                SetPropertyExistsInBaseData("bRepair", exists);
                SetPropertyExists("bRepair", exists);
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital", out exists);
                SetPropertyExistsInBaseData("bAntiCapital", exists);
                SetPropertyExists("bAntiCapital", exists);

                _size = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "size", out exists);
                SetPropertyExistsInBaseData("size", exists);
                SetPropertyExists("size", exists);
                _particlePosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "particlePosition", out exists);
                SetPropertyExistsInBaseData("particlePosition", exists);
                SetPropertyExists("particlePosition", exists);

                _color = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "color", out exists);
                SetPropertyExistsInBaseData("color", exists);
                SetPropertyExists("color", exists);

                _recoil = DataStructureParseHelpers.GetrecoilDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("recoil", exists);
                SetPropertyExists("recoil", exists);
                _rotateBones = DataStructureParseHelpers.GetrotateBonesDataStructureFromVD2Data(DataXMLDoc, out exists);
                SetPropertyExistsInBaseData("rotateBones", exists);
                SetPropertyExists("rotateBones", exists);

            }
        }
    }
}
