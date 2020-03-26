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
        int _color;
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

        recoilDataStructure _recoil;
        rotateBonesDataStructure _rotateBones;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings")]
        public string weaponType
        {
            get => _weaponType;
            set => _weaponType = value;
        }

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings")]
        public string weaponID
        {
            get => _weaponID;
            set => _weaponID = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings")]
        public string materialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        [Description("hitParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string hitParticleName
        {
            get => _hitParticleName;
            set => _hitParticleName = value;
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings")]
        public string muzzleFlashEffectID
        {
            get => _muzzleFlashEffectID;
            set => _muzzleFlashEffectID = value;
        }

        [Description("gravityObjectType is a plaintext string"), Category("Plaintext Strings")]
        public string gravityObjectType
        {
            get => _gravityObjectType;
            set => _gravityObjectType = value;
        }

        [Description("maxShipSize is a plaintext string"), Category("Plaintext Strings")]
        public string maxShipSize
        {
            get => _maxShipSize;
            set => _maxShipSize = value;
        }

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings")]
        public string shieldID
        {
            get => _shieldID;
            set => _shieldID = value;
        }

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings")]
        public string ammunitionID
        {
            get => _ammunitionID;
            set => _ammunitionID = value;
        }

        [Description("projectileWeaponType is a plaintext string"), Category("Plaintext Strings")]
        public string projectileWeaponType
        {
            get => _projectileWeaponType;
            set => _projectileWeaponType = value;
        }

        [Description("instantType is a plaintext string"), Category("Plaintext Strings")]
        public string instantType
        {
            get => _instantType;
            set => _instantType = value;
        }

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionID
        {
            get => _explosionID;
            set => _explosionID = value;
        }

        [Description("chargeSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string chargeSoundID
        {
            get => _chargeSoundID;
            set => _chargeSoundID = value;
        }

        [Description("chargedSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string chargedSoundID
        {
            get => _chargedSoundID;
            set => _chargedSoundID = value;
        }

        [Description("chargeParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string chargeParticleName
        {
            get => _chargeParticleName;
            set => _chargeParticleName = value;
        }

        [Description("auxAmmunitionID is a plaintext string"), Category("Plaintext Strings")]
        public string auxAmmunitionID
        {
            get => _auxAmmunitionID;
            set => _auxAmmunitionID = value;
        }

        [Description("linkedRotatingElement is a plaintext string"), Category("Plaintext Strings")]
        public string linkedRotatingElement
        {
            get => _linkedRotatingElement;
            set => _linkedRotatingElement = value;
        }

        [Description("beamShieldID is a plaintext string"), Category("Plaintext Strings")]
        public string beamShieldID
        {
            get => _beamShieldID;
            set => _beamShieldID = value;
        }

        [Description("collisionWeaponType is a plaintext string"), Category("Plaintext Strings")]
        public string collisionWeaponType
        {
            get => _collisionWeaponType;
            set => _collisionWeaponType = value;
        }

        [Description("particleEffectName is a plaintext string"), Category("Plaintext Strings")]
        public string particleEffectName
        {
            get => _particleEffectName;
            set => _particleEffectName = value;
        }

        [Description("beamType is a plaintext string"), Category("Plaintext Strings")]
        public string beamType
        {
            get => _beamType;
            set => _beamType = value;
        }

        [Description("hitSound is a plaintext string"), Category("Plaintext Strings")]
        public string hitSound
        {
            get => _hitSound;
            set => _hitSound = value;
        }

        [Description("fireParticleName is a plaintext string"), Category("Plaintext Strings")]
        public string fireParticleName
        {
            get => _fireParticleName;
            set => _fireParticleName = value;
        }

        [Description("linkedMovingElement is a plaintext string"), Category("Plaintext Strings")]
        public string linkedMovingElement
        {
            get => _linkedMovingElement;
            set => _linkedMovingElement = value;
        }

        [Description("minimumShipClass is a plaintext string"), Category("Plaintext Strings")]
        public string minimumShipClass
        {
            get => _minimumShipClass;
            set => _minimumShipClass = value;
        }

        [Description("hangarID is a plaintext string"), Category("Plaintext Strings")]
        public string hangarID
        {
            get => _hangarID;
            set => _hangarID = value;
        }


        [Description("fireSoundID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> fireSoundID
        {
            get => _fireSoundID;
            set => _fireSoundID = value;
        }


        [Description("distance is an integer"), Category("Integers")]
        public int distance
        {
            get => _distance;
            set => _distance = value;
        }

        [Description("roundsPerShot is an integer"), Category("Integers")]
        public int roundsPerShot
        {
            get => _roundsPerShot;
            set => _roundsPerShot = value;
        }

        [Description("color is an integer"), Category("Integers")]
        public int color
        {
            get => _color;
            set => _color = value;
        }

        [Description("rotateSpeed is an integer"), Category("Integers")]
        public int rotateSpeed
        {
            get => _rotateSpeed;
            set => _rotateSpeed = value;
        }


        [Description("damage is a real number"), Category("Real Numbers")]
        public float damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("range is a real number"), Category("Real Numbers")]
        public float range
        {
            get => _range;
            set => _range = value;
        }

        [Description("baseScale is a real number"), Category("Real Numbers")]
        public float baseScale
        {
            get => _baseScale;
            set => _baseScale = value;
        }

        [Description("oscilateRange is a real number"), Category("Real Numbers")]
        public float oscilateRange
        {
            get => _oscilateRange;
            set => _oscilateRange = value;
        }

        [Description("oscilateAmount is a real number"), Category("Real Numbers")]
        public float oscilateAmount
        {
            get => _oscilateAmount;
            set => _oscilateAmount = value;
        }

        [Description("capacity is a real number"), Category("Real Numbers")]
        public float capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        [Description("reloadTime is a real number"), Category("Real Numbers")]
        public float reloadTime
        {
            get => _reloadTime;
            set => _reloadTime = value;
        }

        [Description("assistDegree is a real number"), Category("Real Numbers")]
        public float assistDegree
        {
            get => _assistDegree;
            set => _assistDegree = value;
        }

        [Description("reFireRate is a real number"), Category("Real Numbers")]
        public float reFireRate
        {
            get => _reFireRate;
            set => _reFireRate = value;
        }

        [Description("parentPush is a real number"), Category("Real Numbers")]
        public float parentPush
        {
            get => _parentPush;
            set => _parentPush = value;
        }

        [Description("penetrateZ is a real number"), Category("Real Numbers")]
        public float penetrateZ
        {
            get => _penetrateZ;
            set => _penetrateZ = value;
        }

        [Description("speedChange is a real number"), Category("Real Numbers")]
        public float speedChange
        {
            get => _speedChange;
            set => _speedChange = value;
        }

        [Description("weaponPush is a real number"), Category("Real Numbers")]
        public float weaponPush
        {
            get => _weaponPush;
            set => _weaponPush = value;
        }

        [Description("visualTimer is a real number"), Category("Real Numbers")]
        public float visualTimer
        {
            get => _visualTimer;
            set => _visualTimer = value;
        }

        [Description("pullSpeed is a real number"), Category("Real Numbers")]
        public float pullSpeed
        {
            get => _pullSpeed;
            set => _pullSpeed = value;
        }

        [Description("disableRate is a real number"), Category("Real Numbers")]
        public float disableRate
        {
            get => _disableRate;
            set => _disableRate = value;
        }


        [Description("scatterYaw is a collection of real numbers"), Category("Real Number Collections")]
        public List<float> scatterYaw
        {
            get => _scatterYaw;
            set => _scatterYaw = value;
        }

        [Description("scatterPitch is a collection of real numbers"), Category("Real Number Collections")]
        public List<float> scatterPitch
        {
            get => _scatterPitch;
            set => _scatterPitch = value;
        }


        [Description("bNoAimAssist is a boolean value"), Category("Booleans")]
        public bool bNoAimAssist
        {
            get => _bNoAimAssist;
            set => _bNoAimAssist = value;
        }

        [Description("bAlwaysPlayFireSound is a boolean value"), Category("Booleans")]
        public bool bAlwaysPlayFireSound
        {
            get => _bAlwaysPlayFireSound;
            set => _bAlwaysPlayFireSound = value;
        }

        [Description("bFireFullAmmo is a boolean value"), Category("Booleans")]
        public bool bFireFullAmmo
        {
            get => _bFireFullAmmo;
            set => _bFireFullAmmo = value;
        }

        [Description("bSticky is a boolean value"), Category("Booleans")]
        public bool bSticky
        {
            get => _bSticky;
            set => _bSticky = value;
        }

        [Description("bCapture is a boolean value"), Category("Booleans")]
        public bool bCapture
        {
            get => _bCapture;
            set => _bCapture = value;
        }

        [Description("bReduceMassOnStick is a boolean value"), Category("Booleans")]
        public bool bReduceMassOnStick
        {
            get => _bReduceMassOnStick;
            set => _bReduceMassOnStick = value;
        }

        [Description("bChargeGun is a boolean value"), Category("Booleans")]
        public bool bChargeGun
        {
            get => _bChargeGun;
            set => _bChargeGun = value;
        }

        [Description("bAntiCapShip is a boolean value"), Category("Booleans")]
        public bool bAntiCapShip
        {
            get => _bAntiCapShip;
            set => _bAntiCapShip = value;
        }

        [Description("bIgnoresShields is a boolean value"), Category("Booleans")]
        public bool bIgnoresShields
        {
            get => _bIgnoresShields;
            set => _bIgnoresShields = value;
        }

        [Description("bAddRandom is a boolean value"), Category("Booleans")]
        public bool bAddRandom
        {
            get => _bAddRandom;
            set => _bAddRandom = value;
        }

        [Description("bMining is a boolean value"), Category("Booleans")]
        public bool bMining
        {
            get => _bMining;
            set => _bMining = value;
        }

        [Description("bRepair is a boolean value"), Category("Booleans")]
        public bool bRepair
        {
            get => _bRepair;
            set => _bRepair = value;
        }

        [Description("bAntiCapital is a boolean value"), Category("Booleans")]
        public bool bAntiCapital
        {
            get => _bAntiCapital;
            set => _bAntiCapital = value;
        }


        [Description("size is a 3D vector"), Category("3D Vectors")]
        public Vector3D size
        {
            get => _size;
            set => _size = value;
        }

        [Description("particlePosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D particlePosition
        {
            get => _particlePosition;
            set => _particlePosition = value;
        }


        [Description("recoil is a datastructure"), Category("Data Structures")]
        public recoilDataStructure recoil
        {
            get => _recoil;
            set => _recoil = value;
        }

        [Description("rotateBones is a datastructure"), Category("Data Structures")]
        public rotateBonesDataStructure rotateBones
        {
            get => _rotateBones;
            set => _rotateBones = value;
        }



        public WeaponData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType");
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName");
                _hitParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitParticleName");
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID");
                _gravityObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityObjectType");
                _maxShipSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxShipSize");
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID");
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID");
                _projectileWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileWeaponType");
                _instantType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantType");
                _explosionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionID");
                _chargeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeSoundID");
                _chargedSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargedSoundID");
                _chargeParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeParticleName");
                _auxAmmunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "auxAmmunitionID");
                _linkedRotatingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedRotatingElement");
                _beamShieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamShieldID");
                _collisionWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionWeaponType");
                _particleEffectName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleEffectName");
                _beamType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamType");
                _hitSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitSound");
                _fireParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireParticleName");
                _linkedMovingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedMovingElement");
                _minimumShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumShipClass");
                _hangarID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hangarID");

                _fireSoundID = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "fireSoundID");

                _distance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "distance");
                _roundsPerShot = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "roundsPerShot");
                _color = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "color");
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed");

                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage");
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range");
                _baseScale = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "baseScale");
                _oscilateRange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateRange");
                _oscilateAmount = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateAmount");
                _capacity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "capacity");
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime");
                _assistDegree = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "assistDegree");
                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate");
                _parentPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "parentPush");
                _penetrateZ = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "penetrateZ");
                _speedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChange");
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush");
                _visualTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "visualTimer");
                _pullSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pullSpeed");
                _disableRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "disableRate");

                _scatterYaw = ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterYaw");
                _scatterPitch = ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterPitch");

                _bNoAimAssist = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoAimAssist");
                _bAlwaysPlayFireSound = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysPlayFireSound");
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo");
                _bSticky = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSticky");
                _bCapture = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCapture");
                _bReduceMassOnStick = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReduceMassOnStick");
                _bChargeGun = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bChargeGun");
                _bAntiCapShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapShip");
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields");
                _bAddRandom = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAddRandom");
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining");
                _bRepair = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepair");
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital");

                _size = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "size");
                _particlePosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "particlePosition");

                _recoil = DataStructureParseHelpers.GetrecoilDataStructureFromVD2Data(DataXMLDoc);
                _rotateBones = DataStructureParseHelpers.GetrotateBonesDataStructureFromVD2Data(DataXMLDoc);

            }
        }
    }
}
