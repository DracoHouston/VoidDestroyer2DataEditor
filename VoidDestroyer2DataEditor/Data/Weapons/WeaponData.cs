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
    public class WeaponData : VD2Data
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

        ObservableCollection<string> _fireSoundID;
        ObservableCollection<string> _hangarID;

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

        ObservableCollection<float> _scatterYaw;
        ObservableCollection<float> _scatterPitch;

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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponType = value;
                        SetPropertyEdited("weaponType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponID = value;
                        SetPropertyEdited("weaponID", true);
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

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialName = value;
                        SetPropertyEdited("materialName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _hitParticleName = value;
                        SetPropertyEdited("hitParticleName", true);
                    }
                }
            }
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string muzzleFlashEffectID
        {
            get
            {
                return _muzzleFlashEffectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _muzzleFlashEffectID = value;
                        SetPropertyEdited("muzzleFlashEffectID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _gravityObjectType = value;
                        SetPropertyEdited("gravityObjectType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxShipSize = value;
                        SetPropertyEdited("maxShipSize", true);
                    }
                }
            }
        }

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string shieldID
        {
            get
            {
                return _shieldID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldID = value;
                        SetPropertyEdited("shieldID", true);
                    }
                }
            }
        }

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string ammunitionID
        {
            get
            {
                return _ammunitionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ammunitionID = value;
                        SetPropertyEdited("ammunitionID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _projectileWeaponType = value;
                        SetPropertyEdited("projectileWeaponType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _instantType = value;
                        SetPropertyEdited("instantType", true);
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

        [Description("chargeSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string chargeSoundID
        {
            get
            {
                return _chargeSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _chargeSoundID = value;
                        SetPropertyEdited("chargeSoundID", true);
                    }
                }
            }
        }

        [Description("chargedSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string chargedSoundID
        {
            get
            {
                return _chargedSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _chargedSoundID = value;
                        SetPropertyEdited("chargedSoundID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _chargeParticleName = value;
                        SetPropertyEdited("chargeParticleName", true);
                    }
                }
            }
        }

        [Description("auxAmmunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string auxAmmunitionID
        {
            get
            {
                return _auxAmmunitionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _auxAmmunitionID = value;
                        SetPropertyEdited("auxAmmunitionID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _linkedRotatingElement = value;
                        SetPropertyEdited("linkedRotatingElement", true);
                    }
                }
            }
        }

        [Description("beamShieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string beamShieldID
        {
            get
            {
                return _beamShieldID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _beamShieldID = value;
                        SetPropertyEdited("beamShieldID", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionWeaponType = value;
                        SetPropertyEdited("collisionWeaponType", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _particleEffectName = value;
                        SetPropertyEdited("particleEffectName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _beamType = value;
                        SetPropertyEdited("beamType", true);
                    }
                }
            }
        }

        [Description("hitSound is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string hitSound
        {
            get
            {
                return _hitSound;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _hitSound = value;
                        SetPropertyEdited("hitSound", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fireParticleName = value;
                        SetPropertyEdited("fireParticleName", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _linkedMovingElement = value;
                        SetPropertyEdited("linkedMovingElement", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _minimumShipClass = value;
                        SetPropertyEdited("minimumShipClass", true);
                    }
                }
            }
        }


        [Browsable(false), Description("fireSoundID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> fireSoundID
        {
            get
            {
                return _fireSoundID;
            }
            set
            {
                if (_fireSoundID != null)
                {
                    _fireSoundID.CollectionChanged -= OnfireSoundIDChanged;
                }
                _fireSoundID = value;
                if (_fireSoundID != null)
                {
                    _fireSoundID.CollectionChanged += OnfireSoundIDChanged;
                }
            }
        }

        private void OnfireSoundIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("fireSoundID", true);
                }
                else
                {
                    bool exists = false;
                    _fireSoundID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "fireSoundID", out exists));
                    _fireSoundID.CollectionChanged += OnfireSoundIDChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("fireSoundID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("fireSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireSoundID"));
                    }
                    SetPropertyExists("fireSoundID", exists);
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


        [Description("distance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _distance = value;
                        SetPropertyEdited("distance", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _roundsPerShot = value;
                        SetPropertyEdited("roundsPerShot", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _rotateSpeed = value;
                        SetPropertyEdited("rotateSpeed", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _damage = value;
                        SetPropertyEdited("damage", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _range = value;
                        SetPropertyEdited("range", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _baseScale = value;
                        SetPropertyEdited("baseScale", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _oscilateRange = value;
                        SetPropertyEdited("oscilateRange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _oscilateAmount = value;
                        SetPropertyEdited("oscilateAmount", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _capacity = value;
                        SetPropertyEdited("capacity", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reloadTime = value;
                        SetPropertyEdited("reloadTime", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _assistDegree = value;
                        SetPropertyEdited("assistDegree", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reFireRate = value;
                        SetPropertyEdited("reFireRate", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _parentPush = value;
                        SetPropertyEdited("parentPush", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _penetrateZ = value;
                        SetPropertyEdited("penetrateZ", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _speedChange = value;
                        SetPropertyEdited("speedChange", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponPush = value;
                        SetPropertyEdited("weaponPush", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _visualTimer = value;
                        SetPropertyEdited("visualTimer", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _pullSpeed = value;
                        SetPropertyEdited("pullSpeed", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _disableRate = value;
                        SetPropertyEdited("disableRate", true);
                    }
                }
            }
        }


        [Browsable(false), Description("scatterYaw is a collection of real numbers"), Category("Real Number Collections")]
        public ObservableCollection<float> scatterYaw
        {
            get
            {
                return _scatterYaw;
            }
            set
            {
                if (_scatterYaw != null)
                {
                    _scatterYaw.CollectionChanged -= OnscatterYawChanged;
                }
                _scatterYaw = value;
                if (_scatterYaw != null)
                {
                    _scatterYaw.CollectionChanged += OnscatterYawChanged;
                }
            }
        }

        private void OnscatterYawChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("scatterYaw", true);
                }
                else
                {
                    bool exists = false;
                    _scatterYaw = new ObservableCollection<float>(ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterYaw", out exists));
                    _scatterYaw.CollectionChanged += OnscatterYawChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("scatterYaw", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("scatterYaw", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "scatterYaw"));
                    }
                    SetPropertyExists("scatterYaw", exists);
                }
            }
        }

        [Browsable(false), Description("scatterPitch is a collection of real numbers"), Category("Real Number Collections")]
        public ObservableCollection<float> scatterPitch
        {
            get
            {
                return _scatterPitch;
            }
            set
            {
                if (_scatterPitch != null)
                {
                    _scatterPitch.CollectionChanged -= OnscatterPitchChanged;
                }
                _scatterPitch = value;
                if (_scatterPitch != null)
                {
                    _scatterPitch.CollectionChanged += OnscatterPitchChanged;
                }
            }
        }

        private void OnscatterPitchChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("scatterPitch", true);
                }
                else
                {
                    bool exists = false;
                    _scatterPitch = new ObservableCollection<float>(ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterPitch", out exists));
                    _scatterPitch.CollectionChanged += OnscatterPitchChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("scatterPitch", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("scatterPitch", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "scatterPitch"));
                    }
                    SetPropertyExists("scatterPitch", exists);
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoAimAssist = value;
                        SetPropertyEdited("bNoAimAssist", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAlwaysPlayFireSound = value;
                        SetPropertyEdited("bAlwaysPlayFireSound", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bFireFullAmmo = value;
                        SetPropertyEdited("bFireFullAmmo", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bSticky = value;
                        SetPropertyEdited("bSticky", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCapture = value;
                        SetPropertyEdited("bCapture", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bReduceMassOnStick = value;
                        SetPropertyEdited("bReduceMassOnStick", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bChargeGun = value;
                        SetPropertyEdited("bChargeGun", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAntiCapShip = value;
                        SetPropertyEdited("bAntiCapShip", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bIgnoresShields = value;
                        SetPropertyEdited("bIgnoresShields", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAddRandom = value;
                        SetPropertyEdited("bAddRandom", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bMining = value;
                        SetPropertyEdited("bMining", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRepair = value;
                        SetPropertyEdited("bRepair", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAntiCapital = value;
                        SetPropertyEdited("bAntiCapital", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _size.OnElementChanged -= size_OnElementChanged;
                        _size = value;
                        _size.OnElementChanged += size_OnElementChanged;
                        SetPropertyEdited("size", true);
                    }
                }
            }
        }

        private void size_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("size", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= size_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += size_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= size_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += size_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= size_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += size_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _particlePosition.OnElementChanged -= particlePosition_OnElementChanged;
                        _particlePosition = value;
                        _particlePosition.OnElementChanged += particlePosition_OnElementChanged;
                        SetPropertyEdited("particlePosition", true);
                    }
                }
            }
        }

        private void particlePosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("particlePosition", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= particlePosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += particlePosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= particlePosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += particlePosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= particlePosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += particlePosition_OnElementChanged;
                                break;
                        }
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _color.OnElementChanged -= color_OnElementChanged;
                        _color = value;
                        _color.OnElementChanged += color_OnElementChanged;
                        SetPropertyEdited("color", true);
                    }
                }
            }
        }

        private void color_OnElementChanged(object sender, ColorFElementChangedEventArgs e)
        {
            if (sender is ColorF)
            {
                ColorF colorsender = (ColorF)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("color", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case ColorFElements.r:
                                colorsender.OnElementChanged -= color_OnElementChanged;
                                colorsender.r = e.OldValue;
                                colorsender.OnElementChanged += color_OnElementChanged;
                                break;
                            case ColorFElements.g:
                                colorsender.OnElementChanged -= color_OnElementChanged;
                                colorsender.g = e.OldValue;
                                colorsender.OnElementChanged += color_OnElementChanged;
                                break;
                            case ColorFElements.b:
                                colorsender.OnElementChanged -= color_OnElementChanged;
                                colorsender.b = e.OldValue;
                                colorsender.OnElementChanged += color_OnElementChanged;
                                break;
                            case ColorFElements.a:
                                colorsender.OnElementChanged -= color_OnElementChanged;
                                colorsender.a = e.OldValue;
                                colorsender.OnElementChanged += color_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        [Browsable(false), Description("recoil is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public recoilDataStructure recoil
        {
            get
            {
                return _recoil;
            }
            set
            {
                _recoil = value;
            }
        }

        [Browsable(false), Description("rotateBones is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public rotateBonesDataStructure rotateBones
        {
            get
            {
                return _rotateBones;
            }
            set
            {
                _rotateBones = value;
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            SetPropertyIsObjectID("weaponID", true);
            InitProperty("name");
            InitProperty("materialName");
            InitProperty("hitParticleName");
            InitProperty("muzzleFlashEffectID");
            List<string> muzzleFlashEffectIDreftypes = new List<string>();
            muzzleFlashEffectIDreftypes.Add("Particle");
            SetPropertyIsObjectIDRef("muzzleFlashEffectID", true, muzzleFlashEffectIDreftypes);
            InitProperty("gravityObjectType");
            InitProperty("maxShipSize");
            InitProperty("shieldID");
            List<string> shieldIDreftypes = new List<string>();
            shieldIDreftypes.Add("Shield");
            SetPropertyIsObjectIDRef("shieldID", true, shieldIDreftypes);
            InitProperty("ammunitionID");
            List<string> ammunitionIDreftypes = new List<string>();
            ammunitionIDreftypes.Add("Ammo");
            SetPropertyIsObjectIDRef("ammunitionID", true, ammunitionIDreftypes);
            InitProperty("projectileWeaponType");
            InitProperty("instantType");
            InitProperty("explosionID");
            List<string> explosionIDreftypes = new List<string>();
            explosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("explosionID", true, explosionIDreftypes);
            InitProperty("chargeSoundID");
            List<string> chargeSoundIDreftypes = new List<string>();
            chargeSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("chargeSoundID", true, chargeSoundIDreftypes);
            InitProperty("chargedSoundID");
            List<string> chargedSoundIDreftypes = new List<string>();
            chargedSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("chargedSoundID", true, chargedSoundIDreftypes);
            InitProperty("chargeParticleName");
            InitProperty("auxAmmunitionID");
            List<string> auxAmmunitionIDreftypes = new List<string>();
            auxAmmunitionIDreftypes.Add("Ammo");
            SetPropertyIsObjectIDRef("auxAmmunitionID", true, auxAmmunitionIDreftypes);
            InitProperty("linkedRotatingElement");
            InitProperty("beamShieldID");
            List<string> beamShieldIDreftypes = new List<string>();
            beamShieldIDreftypes.Add("Shield");
            SetPropertyIsObjectIDRef("beamShieldID", true, beamShieldIDreftypes);
            InitProperty("collisionWeaponType");
            InitProperty("particleEffectName");
            InitProperty("beamType");
            InitProperty("hitSound");
            List<string> hitSoundreftypes = new List<string>();
            hitSoundreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("hitSound", true, hitSoundreftypes);
            InitProperty("fireParticleName");
            InitProperty("linkedMovingElement");
            InitProperty("minimumShipClass");

            InitProperty("fireSoundID");
            List<string> fireSoundIDreftypes = new List<string>();
            fireSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("fireSoundID", true, fireSoundIDreftypes);
            SetPropertyIsCollection("fireSoundID", true, typeof(string));
            InitProperty("hangarID");
            List<string> hangarIDreftypes = new List<string>();
            hangarIDreftypes.Add("Hangar");
            SetPropertyIsObjectIDRef("hangarID", true, hangarIDreftypes);
            SetPropertyIsCollection("hangarID", true, typeof(string));

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
            SetPropertyIsCollection("scatterYaw", true, typeof(float));
            InitProperty("scatterPitch");
            SetPropertyIsCollection("scatterPitch", true, typeof(float));

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

        public WeaponData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
        }

        public override void LoadDataFromXML()
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(weaponID, "weaponID"));
                }
                SetPropertyExists("weaponID", exists);

                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponType"));
                }
                SetPropertyExists("weaponType", exists);
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
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialName"));
                }
                SetPropertyExists("materialName", exists);
                _hitParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hitParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hitParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hitParticleName"));
                }
                SetPropertyExists("hitParticleName", exists);
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "muzzleFlashEffectID"));
                }
                SetPropertyExists("muzzleFlashEffectID", exists);
                _gravityObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gravityObjectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("gravityObjectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("gravityObjectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "gravityObjectType"));
                }
                SetPropertyExists("gravityObjectType", exists);
                _maxShipSize = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "maxShipSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxShipSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxShipSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxShipSize"));
                }
                SetPropertyExists("maxShipSize", exists);
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldID"));
                }
                SetPropertyExists("shieldID", exists);
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ammunitionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ammunitionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ammunitionID"));
                }
                SetPropertyExists("ammunitionID", exists);
                _projectileWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "projectileWeaponType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("projectileWeaponType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("projectileWeaponType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "projectileWeaponType"));
                }
                SetPropertyExists("projectileWeaponType", exists);
                _instantType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "instantType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("instantType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("instantType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "instantType"));
                }
                SetPropertyExists("instantType", exists);
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
                _chargeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("chargeSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("chargeSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "chargeSoundID"));
                }
                SetPropertyExists("chargeSoundID", exists);
                _chargedSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargedSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("chargedSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("chargedSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "chargedSoundID"));
                }
                SetPropertyExists("chargedSoundID", exists);
                _chargeParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "chargeParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("chargeParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("chargeParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "chargeParticleName"));
                }
                SetPropertyExists("chargeParticleName", exists);
                _auxAmmunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "auxAmmunitionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("auxAmmunitionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("auxAmmunitionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "auxAmmunitionID"));
                }
                SetPropertyExists("auxAmmunitionID", exists);
                _linkedRotatingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedRotatingElement", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("linkedRotatingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("linkedRotatingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "linkedRotatingElement"));
                }
                SetPropertyExists("linkedRotatingElement", exists);
                _beamShieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamShieldID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("beamShieldID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("beamShieldID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "beamShieldID"));
                }
                SetPropertyExists("beamShieldID", exists);
                _collisionWeaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionWeaponType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionWeaponType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionWeaponType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionWeaponType"));
                }
                SetPropertyExists("collisionWeaponType", exists);
                _particleEffectName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleEffectName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("particleEffectName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("particleEffectName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "particleEffectName"));
                }
                SetPropertyExists("particleEffectName", exists);
                _beamType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "beamType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("beamType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("beamType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "beamType"));
                }
                SetPropertyExists("beamType", exists);
                _hitSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hitSound", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hitSound", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hitSound", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hitSound"));
                }
                SetPropertyExists("hitSound", exists);
                _fireParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fireParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fireParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireParticleName"));
                }
                SetPropertyExists("fireParticleName", exists);
                _linkedMovingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedMovingElement", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("linkedMovingElement", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("linkedMovingElement", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "linkedMovingElement"));
                }
                SetPropertyExists("linkedMovingElement", exists);
                _minimumShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "minimumShipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("minimumShipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("minimumShipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "minimumShipClass"));
                }
                SetPropertyExists("minimumShipClass", exists);

                _fireSoundID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "fireSoundID", out exists));
                _fireSoundID.CollectionChanged += OnfireSoundIDChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fireSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fireSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireSoundID"));
                }
                SetPropertyExists("fireSoundID", exists);
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

                _distance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "distance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("distance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("distance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "distance"));
                }
                SetPropertyExists("distance", exists);
                _roundsPerShot = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "roundsPerShot", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("roundsPerShot", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("roundsPerShot", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "roundsPerShot"));
                }
                SetPropertyExists("roundsPerShot", exists);
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rotateSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rotateSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rotateSpeed"));
                }
                SetPropertyExists("rotateSpeed", exists);

                _damage = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "damage", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damage", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damage"));
                }
                SetPropertyExists("damage", exists);
                _range = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "range", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("range", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("range", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "range"));
                }
                SetPropertyExists("range", exists);
                _baseScale = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "baseScale", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("baseScale", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("baseScale", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "baseScale"));
                }
                SetPropertyExists("baseScale", exists);
                _oscilateRange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateRange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("oscilateRange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("oscilateRange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "oscilateRange"));
                }
                SetPropertyExists("oscilateRange", exists);
                _oscilateAmount = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "oscilateAmount", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("oscilateAmount", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("oscilateAmount", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "oscilateAmount"));
                }
                SetPropertyExists("oscilateAmount", exists);
                _capacity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "capacity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("capacity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("capacity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "capacity"));
                }
                SetPropertyExists("capacity", exists);
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reloadTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reloadTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reloadTime"));
                }
                SetPropertyExists("reloadTime", exists);
                _assistDegree = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "assistDegree", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("assistDegree", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("assistDegree", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "assistDegree"));
                }
                SetPropertyExists("assistDegree", exists);
                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reFireRate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reFireRate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reFireRate"));
                }
                SetPropertyExists("reFireRate", exists);
                _parentPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "parentPush", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("parentPush", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("parentPush", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "parentPush"));
                }
                SetPropertyExists("parentPush", exists);
                _penetrateZ = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "penetrateZ", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("penetrateZ", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("penetrateZ", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "penetrateZ"));
                }
                SetPropertyExists("penetrateZ", exists);
                _speedChange = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "speedChange", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("speedChange", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("speedChange", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "speedChange"));
                }
                SetPropertyExists("speedChange", exists);
                _weaponPush = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "weaponPush", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponPush", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponPush", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponPush"));
                }
                SetPropertyExists("weaponPush", exists);
                _visualTimer = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "visualTimer", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("visualTimer", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("visualTimer", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "visualTimer"));
                }
                SetPropertyExists("visualTimer", exists);
                _pullSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pullSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("pullSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("pullSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "pullSpeed"));
                }
                SetPropertyExists("pullSpeed", exists);
                _disableRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "disableRate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("disableRate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("disableRate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "disableRate"));
                }
                SetPropertyExists("disableRate", exists);

                _scatterYaw =  new ObservableCollection<float>(ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterYaw", out exists));
                _scatterYaw.CollectionChanged += OnscatterYawChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("scatterYaw", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("scatterYaw", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "scatterYaw"));
                }
                SetPropertyExists("scatterYaw", exists);
                _scatterPitch =  new ObservableCollection<float>(ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, "scatterPitch", out exists));
                _scatterPitch.CollectionChanged += OnscatterPitchChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("scatterPitch", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("scatterPitch", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "scatterPitch"));
                }
                SetPropertyExists("scatterPitch", exists);

                _bNoAimAssist = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoAimAssist", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoAimAssist", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoAimAssist", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoAimAssist"));
                }
                SetPropertyExists("bNoAimAssist", exists);
                _bAlwaysPlayFireSound = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysPlayFireSound", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAlwaysPlayFireSound", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAlwaysPlayFireSound", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAlwaysPlayFireSound"));
                }
                SetPropertyExists("bAlwaysPlayFireSound", exists);
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bFireFullAmmo"));
                }
                SetPropertyExists("bFireFullAmmo", exists);
                _bSticky = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSticky", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bSticky", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bSticky", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bSticky"));
                }
                SetPropertyExists("bSticky", exists);
                _bCapture = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCapture", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCapture", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCapture", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCapture"));
                }
                SetPropertyExists("bCapture", exists);
                _bReduceMassOnStick = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReduceMassOnStick", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bReduceMassOnStick", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bReduceMassOnStick", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bReduceMassOnStick"));
                }
                SetPropertyExists("bReduceMassOnStick", exists);
                _bChargeGun = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bChargeGun", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bChargeGun", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bChargeGun", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bChargeGun"));
                }
                SetPropertyExists("bChargeGun", exists);
                _bAntiCapShip = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAntiCapShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAntiCapShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAntiCapShip"));
                }
                SetPropertyExists("bAntiCapShip", exists);
                _bIgnoresShields = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIgnoresShields", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bIgnoresShields", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bIgnoresShields", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bIgnoresShields"));
                }
                SetPropertyExists("bIgnoresShields", exists);
                _bAddRandom = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAddRandom", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAddRandom", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAddRandom", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAddRandom"));
                }
                SetPropertyExists("bAddRandom", exists);
                _bMining = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bMining", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bMining", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bMining", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bMining"));
                }
                SetPropertyExists("bMining", exists);
                _bRepair = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRepair", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRepair", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRepair", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRepair"));
                }
                SetPropertyExists("bRepair", exists);
                _bAntiCapital = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAntiCapital", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAntiCapital", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAntiCapital", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAntiCapital"));
                }
                SetPropertyExists("bAntiCapital", exists);

                _size = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "size", out exists);
                _size.OnElementChanged += size_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("size", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("size", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "size"));
                }
                SetPropertyExists("size", exists);
                _particlePosition = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "particlePosition", out exists);
                _particlePosition.OnElementChanged += particlePosition_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("particlePosition", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("particlePosition", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "particlePosition"));
                }
                SetPropertyExists("particlePosition", exists);

                _color = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "color", out exists);
                _color.OnElementChanged += color_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("color", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("color", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "color"));
                }
                SetPropertyExists("color", exists);

                _recoil = DataStructureParseHelpers.GetrecoilDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("recoil", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("recoil", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "recoil"));
                }
                SetPropertyExists("recoil", exists);
                _rotateBones = DataStructureParseHelpers.GetrotateBonesDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rotateBones", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rotateBones", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rotateBones"));
                }
                SetPropertyExists("rotateBones", exists);

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
            if (PropertyExists("weaponType"))
            {
                xmltextlines.Add("<weaponType attr1=\"" + _weaponType + "\"/>");
            }
            if (PropertyExists("weaponID"))
            {
                xmltextlines.Add("<weaponID attr1=\"" + _weaponID + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("materialName"))
            {
                xmltextlines.Add("<materialName attr1=\"" + _materialName + "\"/>");
            }
            if (PropertyExists("hitParticleName"))
            {
                xmltextlines.Add("<hitParticleName attr1=\"" + _hitParticleName + "\"/>");
            }
            if (PropertyExists("muzzleFlashEffectID"))
            {
                xmltextlines.Add("<muzzleFlashEffectID attr1=\"" + _muzzleFlashEffectID + "\"/>");
            }
            if (PropertyExists("gravityObjectType"))
            {
                xmltextlines.Add("<gravityObjectType attr1=\"" + _gravityObjectType + "\"/>");
            }
            if (PropertyExists("maxShipSize"))
            {
                xmltextlines.Add("<maxShipSize attr1=\"" + _maxShipSize + "\"/>");
            }
            if (PropertyExists("shieldID"))
            {
                xmltextlines.Add("<shieldID attr1=\"" + _shieldID + "\"/>");
            }
            if (PropertyExists("ammunitionID"))
            {
                xmltextlines.Add("<ammunitionID attr1=\"" + _ammunitionID + "\"/>");
            }
            if (PropertyExists("projectileWeaponType"))
            {
                xmltextlines.Add("<projectileWeaponType attr1=\"" + _projectileWeaponType + "\"/>");
            }
            if (PropertyExists("instantType"))
            {
                xmltextlines.Add("<instantType attr1=\"" + _instantType + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("chargeSoundID"))
            {
                xmltextlines.Add("<chargeSoundID attr1=\"" + _chargeSoundID + "\"/>");
            }
            if (PropertyExists("chargedSoundID"))
            {
                xmltextlines.Add("<chargedSoundID attr1=\"" + _chargedSoundID + "\"/>");
            }
            if (PropertyExists("chargeParticleName"))
            {
                xmltextlines.Add("<chargeParticleName attr1=\"" + _chargeParticleName + "\"/>");
            }
            if (PropertyExists("auxAmmunitionID"))
            {
                xmltextlines.Add("<auxAmmunitionID attr1=\"" + _auxAmmunitionID + "\"/>");
            }
            if (PropertyExists("linkedRotatingElement"))
            {
                xmltextlines.Add("<linkedRotatingElement attr1=\"" + _linkedRotatingElement + "\"/>");
            }
            if (PropertyExists("beamShieldID"))
            {
                xmltextlines.Add("<beamShieldID attr1=\"" + _beamShieldID + "\"/>");
            }
            if (PropertyExists("collisionWeaponType"))
            {
                xmltextlines.Add("<collisionWeaponType attr1=\"" + _collisionWeaponType + "\"/>");
            }
            if (PropertyExists("particleEffectName"))
            {
                xmltextlines.Add("<particleEffectName attr1=\"" + _particleEffectName + "\"/>");
            }
            if (PropertyExists("beamType"))
            {
                xmltextlines.Add("<beamType attr1=\"" + _beamType + "\"/>");
            }
            if (PropertyExists("hitSound"))
            {
                xmltextlines.Add("<hitSound attr1=\"" + _hitSound + "\"/>");
            }
            if (PropertyExists("fireParticleName"))
            {
                xmltextlines.Add("<fireParticleName attr1=\"" + _fireParticleName + "\"/>");
            }
            if (PropertyExists("linkedMovingElement"))
            {
                xmltextlines.Add("<linkedMovingElement attr1=\"" + _linkedMovingElement + "\"/>");
            }
            if (PropertyExists("minimumShipClass"))
            {
                xmltextlines.Add("<minimumShipClass attr1=\"" + _minimumShipClass + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("fireSoundID"))
            {
                foreach (string result in _fireSoundID)
                {
                    xmltextlines.Add("<fireSoundID attr1=\"" + result + "\"/>");
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
            if (PropertyExists("distance"))
            {
                xmltextlines.Add("<distance attr1=\"" + _distance.ToString() + "\"/>");
            }
            if (PropertyExists("roundsPerShot"))
            {
                xmltextlines.Add("<roundsPerShot attr1=\"" + _roundsPerShot.ToString() + "\"/>");
            }
            if (PropertyExists("rotateSpeed"))
            {
                xmltextlines.Add("<rotateSpeed attr1=\"" + _rotateSpeed.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("damage"))
            {
                xmltextlines.Add("<damage attr1=\"" + _damage.ToString() + "\"/>");
            }
            if (PropertyExists("range"))
            {
                xmltextlines.Add("<range attr1=\"" + _range.ToString() + "\"/>");
            }
            if (PropertyExists("baseScale"))
            {
                xmltextlines.Add("<baseScale attr1=\"" + _baseScale.ToString() + "\"/>");
            }
            if (PropertyExists("oscilateRange"))
            {
                xmltextlines.Add("<oscilateRange attr1=\"" + _oscilateRange.ToString() + "\"/>");
            }
            if (PropertyExists("oscilateAmount"))
            {
                xmltextlines.Add("<oscilateAmount attr1=\"" + _oscilateAmount.ToString() + "\"/>");
            }
            if (PropertyExists("capacity"))
            {
                xmltextlines.Add("<capacity attr1=\"" + _capacity.ToString() + "\"/>");
            }
            if (PropertyExists("reloadTime"))
            {
                xmltextlines.Add("<reloadTime attr1=\"" + _reloadTime.ToString() + "\"/>");
            }
            if (PropertyExists("assistDegree"))
            {
                xmltextlines.Add("<assistDegree attr1=\"" + _assistDegree.ToString() + "\"/>");
            }
            if (PropertyExists("reFireRate"))
            {
                xmltextlines.Add("<reFireRate attr1=\"" + _reFireRate.ToString() + "\"/>");
            }
            if (PropertyExists("parentPush"))
            {
                xmltextlines.Add("<parentPush attr1=\"" + _parentPush.ToString() + "\"/>");
            }
            if (PropertyExists("penetrateZ"))
            {
                xmltextlines.Add("<penetrateZ attr1=\"" + _penetrateZ.ToString() + "\"/>");
            }
            if (PropertyExists("speedChange"))
            {
                xmltextlines.Add("<speedChange attr1=\"" + _speedChange.ToString() + "\"/>");
            }
            if (PropertyExists("weaponPush"))
            {
                xmltextlines.Add("<weaponPush attr1=\"" + _weaponPush.ToString() + "\"/>");
            }
            if (PropertyExists("visualTimer"))
            {
                xmltextlines.Add("<visualTimer attr1=\"" + _visualTimer.ToString() + "\"/>");
            }
            if (PropertyExists("pullSpeed"))
            {
                xmltextlines.Add("<pullSpeed attr1=\"" + _pullSpeed.ToString() + "\"/>");
            }
            if (PropertyExists("disableRate"))
            {
                xmltextlines.Add("<disableRate attr1=\"" + _disableRate.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Float Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("scatterYaw"))
            {
                foreach (float result in _scatterYaw)
                {
                    xmltextlines.Add("<scatterYaw attr1=\"" + result.ToString() + "\"/>");
                }
                xmltextlines.Add("");
            }
            if (PropertyExists("scatterPitch"))
            {
                foreach (float result in _scatterPitch)
                {
                    xmltextlines.Add("<scatterPitch attr1=\"" + result.ToString() + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bNoAimAssist"))
            {
                xmltextlines.Add("<bNoAimAssist attr1=\"" + ((_bNoAimAssist) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAlwaysPlayFireSound"))
            {
                xmltextlines.Add("<bAlwaysPlayFireSound attr1=\"" + ((_bAlwaysPlayFireSound) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bFireFullAmmo"))
            {
                xmltextlines.Add("<bFireFullAmmo attr1=\"" + ((_bFireFullAmmo) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bSticky"))
            {
                xmltextlines.Add("<bSticky attr1=\"" + ((_bSticky) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCapture"))
            {
                xmltextlines.Add("<bCapture attr1=\"" + ((_bCapture) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bReduceMassOnStick"))
            {
                xmltextlines.Add("<bReduceMassOnStick attr1=\"" + ((_bReduceMassOnStick) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bChargeGun"))
            {
                xmltextlines.Add("<bChargeGun attr1=\"" + ((_bChargeGun) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAntiCapShip"))
            {
                xmltextlines.Add("<bAntiCapShip attr1=\"" + ((_bAntiCapShip) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bIgnoresShields"))
            {
                xmltextlines.Add("<bIgnoresShields attr1=\"" + ((_bIgnoresShields) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAddRandom"))
            {
                xmltextlines.Add("<bAddRandom attr1=\"" + ((_bAddRandom) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bMining"))
            {
                xmltextlines.Add("<bMining attr1=\"" + ((_bMining) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bRepair"))
            {
                xmltextlines.Add("<bRepair attr1=\"" + ((_bRepair) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAntiCapital"))
            {
                xmltextlines.Add("<bAntiCapital attr1=\"" + ((_bAntiCapital) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("size"))
            {
                xmltextlines.Add("<size x=\"" + _size.x.ToString() + "\" y=\"" + _size.y.ToString() + "\" z=\"" + _size.z.ToString() + "\"/>");
            }
            if (PropertyExists("particlePosition"))
            {
                xmltextlines.Add("<particlePosition x=\"" + _particlePosition.x.ToString() + "\" y=\"" + _particlePosition.y.ToString() + "\" z=\"" + _particlePosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Colors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("color"))
            {
                xmltextlines.Add("<color r=\"" + _color.r.ToString() + "\" g=\"" + _color.g.ToString() + "\" b=\"" + _color.b.ToString() + "\" a=\"" + _color.a.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("recoil"))
            {
                xmltextlines.AddRange(_recoil.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("rotateBones"))
            {
                xmltextlines.AddRange(_rotateBones.AsVD2XML());
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
