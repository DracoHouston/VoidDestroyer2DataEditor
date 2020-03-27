using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace VoidDestroyer2DataEditor
{
    [TypeConverter(typeof(debrisInfoDataStructureConverter))]
    class debrisInfoDataStructure : VD2PropertyStore
    {
        List<debrisDataStructure> _debris;

        [Description("debris is a collection of datastructures"), Category("Data Structure Collection")]
        public List<debrisDataStructure> debris
        {
            get
            {
                return _debris;
            }
            set
            {
                _debris = value;
                SetPropertyEdited("debris", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("debris");
        }

        public debrisInfoDataStructure()
        {
            _debris = new List<debrisDataStructure>();
        }

        public debrisInfoDataStructure(List<debrisDataStructure> indebris)
        {
            _debris = indebris;
        }

        public debrisInfoDataStructure(debrisInfoDataStructure inCopyFrom)
        {
            _debris = inCopyFrom.debris;
        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            for (i = 0; i < _debris.Count; i++)
            {
                result += _debris[i].ToString();
                if (_debris.Count - i != 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }

    public class debrisInfoDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(debrisDataStructureConverter))]
    class debrisDataStructure : VD2PropertyStore
    {
        string _debrisID;

        int _debrisMomentum;
        int _debrisAngular;

        [Description("debrisID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string debrisID
        {
            get
            {
                return _debrisID;
            }
            set
            {
                _debrisID = value;
                SetPropertyEdited("debrisID", true);
            }
        }


        [Description("debrisMomentum is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int debrisMomentum
        {
            get
            {
                return _debrisMomentum;
            }
            set
            {
                _debrisMomentum = value;
                SetPropertyEdited("debrisMomentum", true);
            }
        }

        [Description("debrisAngular is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int debrisAngular
        {
            get
            {
                return _debrisAngular;
            }
            set
            {
                _debrisAngular = value;
                SetPropertyEdited("debrisAngular", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("debrisID");

            InitProperty("debrisMomentum");
            InitProperty("debrisAngular");

        }

        public debrisDataStructure()
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;

        }

        public debrisDataStructure(string indebrisID, int indebrisMomentum, int indebrisAngular)
        {
            _debrisID = indebrisID;

            _debrisMomentum = indebrisMomentum;
            _debrisAngular = indebrisAngular;

        }

        public debrisDataStructure(debrisDataStructure inCopyFrom)
        {
            _debrisID = inCopyFrom.debrisID;

            _debrisMomentum = inCopyFrom.debrisMomentum;
            _debrisAngular = inCopyFrom.debrisAngular;

        }

        public override string ToString()
        {
            string result = "";
            result += _debrisID;
            result += ", ";
            result += _debrisMomentum.ToString();
            result += ", ";
            result += _debrisAngular.ToString();
            return result;
        }
    }

    public class debrisDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(afterburnerDataStructureConverter))]
    class afterburnerDataStructure : VD2PropertyStore
    {
        string _soundID;
        string _tailSoundID;

        float _multiplier;
        float _capacity;
        float _recharge;

        [Description("soundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soundID
        {
            get
            {
                return _soundID;
            }
            set
            {
                _soundID = value;
                SetPropertyEdited("soundID", true);
            }
        }

        [Description("tailSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tailSoundID
        {
            get
            {
                return _tailSoundID;
            }
            set
            {
                _tailSoundID = value;
                SetPropertyEdited("tailSoundID", true);
            }
        }


        [Description("multiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float multiplier
        {
            get
            {
                return _multiplier;
            }
            set
            {
                _multiplier = value;
                SetPropertyEdited("multiplier", true);
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

        [Description("recharge is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float recharge
        {
            get
            {
                return _recharge;
            }
            set
            {
                _recharge = value;
                SetPropertyEdited("recharge", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("soundID");
            InitProperty("tailSoundID");

            InitProperty("multiplier");
            InitProperty("capacity");
            InitProperty("recharge");

        }

        public afterburnerDataStructure()
        {
            _soundID = "";
            _tailSoundID = "";

            _multiplier = 0;
            _capacity = 0;
            _recharge = 0;

        }

        public afterburnerDataStructure(string insoundID, string intailSoundID, float inmultiplier, float incapacity, float inrecharge)
        {
            _soundID = insoundID;
            _tailSoundID = intailSoundID;

            _multiplier = inmultiplier;
            _capacity = incapacity;
            _recharge = inrecharge;

        }

        public afterburnerDataStructure(afterburnerDataStructure inCopyFrom)
        {
            _soundID = inCopyFrom.soundID;
            _tailSoundID = inCopyFrom.tailSoundID;

            _multiplier = inCopyFrom.multiplier;
            _capacity = inCopyFrom.capacity;
            _recharge = inCopyFrom.recharge;

        }

        public override string ToString()
        {
            string result = "";
            result += _soundID;
            result += ", ";
            result += _tailSoundID;
            result += ", ";
            result += _multiplier.ToString();
            result += ", ";
            result += _capacity.ToString();
            result += ", ";
            result += _recharge.ToString();
            return result;
        }
    }

    public class afterburnerDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(targetPriorityListDataStructureConverter))]
    class targetPriorityListDataStructure : VD2PropertyStore
    {
        List<string> _targetClass;

        [Description("targetClass is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> targetClass
        {
            get
            {
                return _targetClass;
            }
            set
            {
                _targetClass = value;
                SetPropertyEdited("targetClass", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("targetClass");

        }

        public targetPriorityListDataStructure()
        {
            _targetClass = new List<string>();

        }

        public targetPriorityListDataStructure(List<string> intargetClass)
        {
            _targetClass = intargetClass;

        }

        public targetPriorityListDataStructure(targetPriorityListDataStructure inCopyFrom)
        {
            _targetClass = inCopyFrom.targetClass;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            for (i = 0; i < _targetClass.Count; i++)
            {
                result += _targetClass[i];
                if (_targetClass.Count - i != 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }

    public class targetPriorityListDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(upgradesDataStructureConverter))]
    class upgradesDataStructure : VD2PropertyStore
    {
        List<string> _upgradeID;

        int _primaryUpgradeCapacity;
        int _activeUpgradeCapacity;

        [Description("upgradeID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> upgradeID
        {
            get
            {
                return _upgradeID;
            }
            set
            {
                _upgradeID = value;
                SetPropertyEdited("upgradeID", true);
            }
        }


        [Description("primaryUpgradeCapacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int primaryUpgradeCapacity
        {
            get
            {
                return _primaryUpgradeCapacity;
            }
            set
            {
                _primaryUpgradeCapacity = value;
                SetPropertyEdited("primaryUpgradeCapacity", true);
            }
        }

        [Description("activeUpgradeCapacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int activeUpgradeCapacity
        {
            get
            {
                return _activeUpgradeCapacity;
            }
            set
            {
                _activeUpgradeCapacity = value;
                SetPropertyEdited("activeUpgradeCapacity", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("upgradeID");

            InitProperty("primaryUpgradeCapacity");
            InitProperty("activeUpgradeCapacity");

        }

        public upgradesDataStructure()
        {
            _upgradeID = new List<string>();

            _primaryUpgradeCapacity = 0;
            _activeUpgradeCapacity = 0;

        }

        public upgradesDataStructure(List<string> inupgradeID, int inprimaryUpgradeCapacity, int inactiveUpgradeCapacity)
        {
            _upgradeID = inupgradeID;

            _primaryUpgradeCapacity = inprimaryUpgradeCapacity;
            _activeUpgradeCapacity = inactiveUpgradeCapacity;

        }

        public upgradesDataStructure(upgradesDataStructure inCopyFrom)
        {
            _upgradeID = inCopyFrom.upgradeID;

            _primaryUpgradeCapacity = inCopyFrom.primaryUpgradeCapacity;
            _activeUpgradeCapacity = inCopyFrom.activeUpgradeCapacity;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            for (i = 0; i < _upgradeID.Count; i++)
            {
                result += _upgradeID[i];
                if (_upgradeID.Count - i != 1)
                {
                    result += ", ";
                }
            }
            result += ", ";
            result += _primaryUpgradeCapacity.ToString();
            result += ", ";
            result += _activeUpgradeCapacity.ToString();
            return result;
        }
    }

    public class upgradesDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(propulsionDataStructureConverter))]
    class propulsionDataStructure : VD2PropertyStore
    {
        string _propulsionEffectID;
        string _direction;

        float _pitch;
        float _yaw;

        bool _bPlayerShipOnly;

        Vector3D _position;

        [Description("propulsionEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string propulsionEffectID
        {
            get
            {
                return _propulsionEffectID;
            }
            set
            {
                _propulsionEffectID = value;
                SetPropertyEdited("propulsionEffectID", true);
            }
        }

        [Description("direction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                SetPropertyEdited("direction", true);
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


        [Description("bPlayerShipOnly is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPlayerShipOnly
        {
            get
            {
                return _bPlayerShipOnly;
            }
            set
            {
                _bPlayerShipOnly = value;
                SetPropertyEdited("bPlayerShipOnly", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("propulsionEffectID");
            InitProperty("direction");

            InitProperty("pitch");
            InitProperty("yaw");

            InitProperty("bPlayerShipOnly");

            InitProperty("position");

        }

        public propulsionDataStructure()
        {
            _propulsionEffectID = "";
            _direction = "";

            _pitch = 0;
            _yaw = 0;

            _bPlayerShipOnly = false;

            _position = new Vector3D();

        }

        public propulsionDataStructure(string inpropulsionEffectID, string indirection, float inpitch, float inyaw, bool inbPlayerShipOnly, Vector3D inposition)
        {
            _propulsionEffectID = inpropulsionEffectID;
            _direction = indirection;

            _pitch = inpitch;
            _yaw = inyaw;

            _bPlayerShipOnly = inbPlayerShipOnly;

            _position = inposition;

        }

        public propulsionDataStructure(propulsionDataStructure inCopyFrom)
        {
            _propulsionEffectID = inCopyFrom.propulsionEffectID;
            _direction = inCopyFrom.direction;

            _pitch = inCopyFrom.pitch;
            _yaw = inCopyFrom.yaw;

            _bPlayerShipOnly = inCopyFrom.bPlayerShipOnly;

            _position = inCopyFrom.position;

        }

        public override string ToString()
        {
            string result = "";
            result += _propulsionEffectID;
            result += ", ";
            result += _direction;
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _bPlayerShipOnly.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }
    }

    public class propulsionDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(weaponDataStructureConverter))]
    class weaponDataStructure : VD2PropertyStore
    {
        string _weaponType;
        string _hardpointID;
        string _weaponFire;

        float _barrelDelay;
        float _yaw;
        float _pitch;

        List<Vector3D> _weaponPosition;

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

        [Description("hardpointID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string hardpointID
        {
            get
            {
                return _hardpointID;
            }
            set
            {
                _hardpointID = value;
                SetPropertyEdited("hardpointID", true);
            }
        }

        [Description("weaponFire is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponFire
        {
            get
            {
                return _weaponFire;
            }
            set
            {
                _weaponFire = value;
                SetPropertyEdited("weaponFire", true);
            }
        }


        [Description("barrelDelay is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float barrelDelay
        {
            get
            {
                return _barrelDelay;
            }
            set
            {
                _barrelDelay = value;
                SetPropertyEdited("barrelDelay", true);
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


        [Description("weaponPosition is a collection of 3D vectors"), Category("3D Vector Collections")]
        public List<Vector3D> weaponPosition
        {
            get
            {
                return _weaponPosition;
            }
            set
            {
                _weaponPosition = value;
                SetPropertyEdited("weaponPosition", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("hardpointID");
            InitProperty("weaponFire");

            InitProperty("barrelDelay");
            InitProperty("yaw");
            InitProperty("pitch");

            InitProperty("weaponPosition");

        }

        public weaponDataStructure()
        {
            _weaponType = "";
            _hardpointID = "";
            _weaponFire = "";

            _barrelDelay = 0;
            _yaw = 0;
            _pitch = 0;

            _weaponPosition = new List<Vector3D>();

        }

        public weaponDataStructure(string inweaponType, string inhardpointID, string inweaponFire, float inbarrelDelay, float inyaw, float inpitch, List<Vector3D> inweaponPosition)
        {
            _weaponType = inweaponType;
            _hardpointID = inhardpointID;
            _weaponFire = inweaponFire;

            _barrelDelay = inbarrelDelay;
            _yaw = inyaw;
            _pitch = inpitch;

            _weaponPosition = inweaponPosition;

        }

        public weaponDataStructure(weaponDataStructure inCopyFrom)
        {
            _weaponType = inCopyFrom.weaponType;
            _hardpointID = inCopyFrom.hardpointID;
            _weaponFire = inCopyFrom.weaponFire;

            _barrelDelay = inCopyFrom.barrelDelay;
            _yaw = inCopyFrom.yaw;
            _pitch = inCopyFrom.pitch;

            _weaponPosition = inCopyFrom.weaponPosition;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _weaponType;
            result += ", ";
            result += _hardpointID;
            result += ", ";
            result += _weaponFire;
            result += ", ";
            result += _barrelDelay.ToString();
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            for (i = 0; i < _weaponPosition.Count; i++)
            {
                result += _weaponPosition[i].ToString();
                if (_weaponPosition.Count - i != 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }

    public class weaponDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(damageDataStructureConverter))]
    class damageDataStructure : VD2PropertyStore
    {
        string _damageEffectID;

        float _pitch;
        float _roll;
        float _yaw;
        float _healthPoint;

        Vector3D _position;

        [Description("damageEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string damageEffectID
        {
            get
            {
                return _damageEffectID;
            }
            set
            {
                _damageEffectID = value;
                SetPropertyEdited("damageEffectID", true);
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

        [Description("healthPoint is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float healthPoint
        {
            get
            {
                return _healthPoint;
            }
            set
            {
                _healthPoint = value;
                SetPropertyEdited("healthPoint", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("damageEffectID");

            InitProperty("pitch");
            InitProperty("roll");
            InitProperty("yaw");
            InitProperty("healthPoint");

            InitProperty("position");

        }

        public damageDataStructure()
        {
            _damageEffectID = "";

            _pitch = 0;
            _roll = 0;
            _yaw = 0;
            _healthPoint = 0;

            _position = new Vector3D();

        }

        public damageDataStructure(string indamageEffectID, float inpitch, float inroll, float inyaw, float inhealthPoint, Vector3D inposition)
        {
            _damageEffectID = indamageEffectID;

            _pitch = inpitch;
            _roll = inroll;
            _yaw = inyaw;
            _healthPoint = inhealthPoint;

            _position = inposition;

        }

        public damageDataStructure(damageDataStructure inCopyFrom)
        {
            _damageEffectID = inCopyFrom.damageEffectID;

            _pitch = inCopyFrom.pitch;
            _roll = inCopyFrom.roll;
            _yaw = inCopyFrom.yaw;
            _healthPoint = inCopyFrom.healthPoint;

            _position = inCopyFrom.position;

        }

        public override string ToString()
        {
            string result = "";
            result += _damageEffectID;
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _roll.ToString();
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _healthPoint.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }
    }

    public class damageDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(turretDataStructureConverter))]
    class turretDataStructure : VD2PropertyStore
    {
        string _turretID;
        string _turretOrientation;
        string _weaponFire;

        List<string> _turretRole;

        int _yawPermitted;
        int _weaponPositionID;

        float _pitchLower;
        float _roll;
        float _yaw;

        bool _bShowInCockpit;
        bool _bHideInHangar;

        Vector3D _position;

        [Description("turretID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turretID
        {
            get
            {
                return _turretID;
            }
            set
            {
                _turretID = value;
                SetPropertyEdited("turretID", true);
            }
        }

        [Description("turretOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turretOrientation
        {
            get
            {
                return _turretOrientation;
            }
            set
            {
                _turretOrientation = value;
                SetPropertyEdited("turretOrientation", true);
            }
        }

        [Description("weaponFire is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponFire
        {
            get
            {
                return _weaponFire;
            }
            set
            {
                _weaponFire = value;
                SetPropertyEdited("weaponFire", true);
            }
        }


        [Description("turretRole is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> turretRole
        {
            get
            {
                return _turretRole;
            }
            set
            {
                _turretRole = value;
                SetPropertyEdited("turretRole", true);
            }
        }


        [Description("yawPermitted is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int yawPermitted
        {
            get
            {
                return _yawPermitted;
            }
            set
            {
                _yawPermitted = value;
                SetPropertyEdited("yawPermitted", true);
            }
        }

        [Description("weaponPositionID is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int weaponPositionID
        {
            get
            {
                return _weaponPositionID;
            }
            set
            {
                _weaponPositionID = value;
                SetPropertyEdited("weaponPositionID", true);
            }
        }


        [Description("pitchLower is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pitchLower
        {
            get
            {
                return _pitchLower;
            }
            set
            {
                _pitchLower = value;
                SetPropertyEdited("pitchLower", true);
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


        [Description("bShowInCockpit is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInCockpit
        {
            get
            {
                return _bShowInCockpit;
            }
            set
            {
                _bShowInCockpit = value;
                SetPropertyEdited("bShowInCockpit", true);
            }
        }

        [Description("bHideInHangar is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHideInHangar
        {
            get
            {
                return _bHideInHangar;
            }
            set
            {
                _bHideInHangar = value;
                SetPropertyEdited("bHideInHangar", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("turretID");
            InitProperty("turretOrientation");
            InitProperty("weaponFire");

            InitProperty("turretRole");

            InitProperty("yawPermitted");
            InitProperty("weaponPositionID");

            InitProperty("pitchLower");
            InitProperty("roll");
            InitProperty("yaw");

            InitProperty("bShowInCockpit");
            InitProperty("bHideInHangar");

            InitProperty("position");

        }

        public turretDataStructure()
        {
            _turretID = "";
            _turretOrientation = "";
            _weaponFire = "";

            _turretRole = new List<string>();

            _yawPermitted = 0;
            _weaponPositionID = 0;

            _pitchLower = 0;
            _roll = 0;
            _yaw = 0;

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();

        }

        public turretDataStructure(string inturretID, string inturretOrientation, string inweaponFire, List<string> inturretRole, int inyawPermitted, int inweaponPositionID, float inpitchLower, float inroll, float inyaw, bool inbShowInCockpit, bool inbHideInHangar, Vector3D inposition)
        {
            _turretID = inturretID;
            _turretOrientation = inturretOrientation;
            _weaponFire = inweaponFire;

            _turretRole = inturretRole;

            _yawPermitted = inyawPermitted;
            _weaponPositionID = inweaponPositionID;

            _pitchLower = inpitchLower;
            _roll = inroll;
            _yaw = inyaw;

            _bShowInCockpit = inbShowInCockpit;
            _bHideInHangar = inbHideInHangar;

            _position = inposition;

        }

        public turretDataStructure(turretDataStructure inCopyFrom)
        {
            _turretID = inCopyFrom.turretID;
            _turretOrientation = inCopyFrom.turretOrientation;
            _weaponFire = inCopyFrom.weaponFire;

            _turretRole = inCopyFrom.turretRole;

            _yawPermitted = inCopyFrom.yawPermitted;
            _weaponPositionID = inCopyFrom.weaponPositionID;

            _pitchLower = inCopyFrom.pitchLower;
            _roll = inCopyFrom.roll;
            _yaw = inCopyFrom.yaw;

            _bShowInCockpit = inCopyFrom.bShowInCockpit;
            _bHideInHangar = inCopyFrom.bHideInHangar;

            _position = inCopyFrom.position;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _turretID;
            result += ", ";
            result += _turretOrientation;
            result += ", ";
            result += _weaponFire;
            result += ", ";
            for (i = 0; i < _turretRole.Count; i++)
            {
                result += _turretRole[i];
                if (_turretRole.Count - i != 1)
                {
                    result += ", ";
                }
            }
            result += ", ";
            result += _yawPermitted.ToString();
            result += ", ";
            result += _weaponPositionID.ToString();
            result += ", ";
            result += _pitchLower.ToString();
            result += ", ";
            result += _roll.ToString();
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _bShowInCockpit.ToString();
            result += ", ";
            result += _bHideInHangar.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }
    }

    public class turretDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(attachmentDataStructureConverter))]
    class attachmentDataStructure : VD2PropertyStore
    {
        string _attachmentOrientation;

        List<string> _attachmentID;

        Vector3D _attachmentPosition;

        [Description("attachmentOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string attachmentOrientation
        {
            get
            {
                return _attachmentOrientation;
            }
            set
            {
                _attachmentOrientation = value;
                SetPropertyEdited("attachmentOrientation", true);
            }
        }


        [Description("attachmentID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> attachmentID
        {
            get
            {
                return _attachmentID;
            }
            set
            {
                _attachmentID = value;
                SetPropertyEdited("attachmentID", true);
            }
        }


        [Description("attachmentPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D attachmentPosition
        {
            get
            {
                return _attachmentPosition;
            }
            set
            {
                _attachmentPosition = value;
                SetPropertyEdited("attachmentPosition", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("attachmentOrientation");

            InitProperty("attachmentID");

            InitProperty("attachmentPosition");

        }

        public attachmentDataStructure()
        {
            _attachmentOrientation = "";

            _attachmentID = new List<string>();

            _attachmentPosition = new Vector3D();

        }

        public attachmentDataStructure(string inattachmentOrientation, List<string> inattachmentID, Vector3D inattachmentPosition)
        {
            _attachmentOrientation = inattachmentOrientation;

            _attachmentID = inattachmentID;

            _attachmentPosition = inattachmentPosition;

        }

        public attachmentDataStructure(attachmentDataStructure inCopyFrom)
        {
            _attachmentOrientation = inCopyFrom.attachmentOrientation;

            _attachmentID = inCopyFrom.attachmentID;

            _attachmentPosition = inCopyFrom.attachmentPosition;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _attachmentOrientation;
            result += ", ";
            for (i = 0; i < _attachmentID.Count; i++)
            {
                result += _attachmentID[i];
                if (_attachmentID.Count - i != 1)
                {
                    result += ", ";
                }
            }
            result += ", ";
            result += _attachmentPosition.ToString();
            return result;
        }
    }

    public class attachmentDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(movingElementDataStructureConverter))]
    class movingElementDataStructure : VD2PropertyStore
    {
        string _boneName;

        float _yaw;
        float _pitch;
        float _roll;
        float _speedMultiplier;

        bool _bLinkedToWeapon;
        bool _bCombat;

        Vector3D _translateAmount;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string boneName
        {
            get
            {
                return _boneName;
            }
            set
            {
                _boneName = value;
                SetPropertyEdited("boneName", true);
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

        [Description("speedMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float speedMultiplier
        {
            get
            {
                return _speedMultiplier;
            }
            set
            {
                _speedMultiplier = value;
                SetPropertyEdited("speedMultiplier", true);
            }
        }


        [Description("bLinkedToWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLinkedToWeapon
        {
            get
            {
                return _bLinkedToWeapon;
            }
            set
            {
                _bLinkedToWeapon = value;
                SetPropertyEdited("bLinkedToWeapon", true);
            }
        }

        [Description("bCombat is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCombat
        {
            get
            {
                return _bCombat;
            }
            set
            {
                _bCombat = value;
                SetPropertyEdited("bCombat", true);
            }
        }


        [Description("translateAmount is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D translateAmount
        {
            get
            {
                return _translateAmount;
            }
            set
            {
                _translateAmount = value;
                SetPropertyEdited("translateAmount", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("boneName");

            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");
            InitProperty("speedMultiplier");

            InitProperty("bLinkedToWeapon");
            InitProperty("bCombat");

            InitProperty("translateAmount");

        }

        public movingElementDataStructure()
        {
            _boneName = "";

            _yaw = 0;
            _pitch = 0;
            _roll = 0;
            _speedMultiplier = 0;

            _bLinkedToWeapon = false;
            _bCombat = false;

            _translateAmount = new Vector3D();

        }

        public movingElementDataStructure(string inboneName, float inyaw, float inpitch, float inroll, float inspeedMultiplier, bool inbLinkedToWeapon, bool inbCombat, Vector3D intranslateAmount)
        {
            _boneName = inboneName;

            _yaw = inyaw;
            _pitch = inpitch;
            _roll = inroll;
            _speedMultiplier = inspeedMultiplier;

            _bLinkedToWeapon = inbLinkedToWeapon;
            _bCombat = inbCombat;

            _translateAmount = intranslateAmount;

        }

        public movingElementDataStructure(movingElementDataStructure inCopyFrom)
        {
            _boneName = inCopyFrom.boneName;

            _yaw = inCopyFrom.yaw;
            _pitch = inCopyFrom.pitch;
            _roll = inCopyFrom.roll;
            _speedMultiplier = inCopyFrom.speedMultiplier;

            _bLinkedToWeapon = inCopyFrom.bLinkedToWeapon;
            _bCombat = inCopyFrom.bCombat;

            _translateAmount = inCopyFrom.translateAmount;

        }

        public override string ToString()
        {
            string result = "";
            result += _boneName;
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _roll.ToString();
            result += ", ";
            result += _speedMultiplier.ToString();
            result += ", ";
            result += _bLinkedToWeapon.ToString();
            result += ", ";
            result += _bCombat.ToString();
            result += ", ";
            result += _translateAmount.ToString();
            return result;
        }
    }

    public class movingElementDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(dockDataStructureConverter))]
    class dockDataStructure : VD2PropertyStore
    {
        string _dockType;
        string _ejectOrientation;
        string _orientation;
        string _attachedID;
        string _boneName;
        string _dockOrientation;
        string _resourceOnly;

        List<string> _objectID;

        int _ejectVelocity;
        int _dockRollOffset;
        int _dockYawOffset;

        bool _bCanAcceptRawResource;
        bool _bInvisible;

        Vector3D _position;

        [Description("dockType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string dockType
        {
            get
            {
                return _dockType;
            }
            set
            {
                _dockType = value;
                SetPropertyEdited("dockType", true);
            }
        }

        [Description("ejectOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ejectOrientation
        {
            get
            {
                return _ejectOrientation;
            }
            set
            {
                _ejectOrientation = value;
                SetPropertyEdited("ejectOrientation", true);
            }
        }

        [Description("orientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                SetPropertyEdited("orientation", true);
            }
        }

        [Description("attachedID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string attachedID
        {
            get
            {
                return _attachedID;
            }
            set
            {
                _attachedID = value;
                SetPropertyEdited("attachedID", true);
            }
        }

        [Description("boneName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string boneName
        {
            get
            {
                return _boneName;
            }
            set
            {
                _boneName = value;
                SetPropertyEdited("boneName", true);
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
                _dockOrientation = value;
                SetPropertyEdited("dockOrientation", true);
            }
        }

        [Description("resourceOnly is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string resourceOnly
        {
            get
            {
                return _resourceOnly;
            }
            set
            {
                _resourceOnly = value;
                SetPropertyEdited("resourceOnly", true);
            }
        }


        [Description("objectID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> objectID
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


        [Description("ejectVelocity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int ejectVelocity
        {
            get
            {
                return _ejectVelocity;
            }
            set
            {
                _ejectVelocity = value;
                SetPropertyEdited("ejectVelocity", true);
            }
        }

        [Description("dockRollOffset is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int dockRollOffset
        {
            get
            {
                return _dockRollOffset;
            }
            set
            {
                _dockRollOffset = value;
                SetPropertyEdited("dockRollOffset", true);
            }
        }

        [Description("dockYawOffset is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int dockYawOffset
        {
            get
            {
                return _dockYawOffset;
            }
            set
            {
                _dockYawOffset = value;
                SetPropertyEdited("dockYawOffset", true);
            }
        }


        [Description("bCanAcceptRawResource is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanAcceptRawResource
        {
            get
            {
                return _bCanAcceptRawResource;
            }
            set
            {
                _bCanAcceptRawResource = value;
                SetPropertyEdited("bCanAcceptRawResource", true);
            }
        }

        [Description("bInvisible is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bInvisible
        {
            get
            {
                return _bInvisible;
            }
            set
            {
                _bInvisible = value;
                SetPropertyEdited("bInvisible", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("dockType");
            InitProperty("ejectOrientation");
            InitProperty("orientation");
            InitProperty("attachedID");
            InitProperty("boneName");
            InitProperty("dockOrientation");
            InitProperty("resourceOnly");

            InitProperty("objectID");

            InitProperty("ejectVelocity");
            InitProperty("dockRollOffset");
            InitProperty("dockYawOffset");

            InitProperty("bCanAcceptRawResource");
            InitProperty("bInvisible");

            InitProperty("position");

        }

        public dockDataStructure()
        {
            _dockType = "";
            _ejectOrientation = "";
            _orientation = "";
            _attachedID = "";
            _boneName = "";
            _dockOrientation = "";
            _resourceOnly = "";

            _objectID = new List<string>();

            _ejectVelocity = 0;
            _dockRollOffset = 0;
            _dockYawOffset = 0;

            _bCanAcceptRawResource = false;
            _bInvisible = false;

            _position = new Vector3D();

        }

        public dockDataStructure(string indockType, string inejectOrientation, string inorientation, string inattachedID, string inboneName, string indockOrientation, string inresourceOnly, List<string> inobjectID, int inejectVelocity, int indockRollOffset, int indockYawOffset, bool inbCanAcceptRawResource, bool inbInvisible, Vector3D inposition)
        {
            _dockType = indockType;
            _ejectOrientation = inejectOrientation;
            _orientation = inorientation;
            _attachedID = inattachedID;
            _boneName = inboneName;
            _dockOrientation = indockOrientation;
            _resourceOnly = inresourceOnly;

            _objectID = inobjectID;

            _ejectVelocity = inejectVelocity;
            _dockRollOffset = indockRollOffset;
            _dockYawOffset = indockYawOffset;

            _bCanAcceptRawResource = inbCanAcceptRawResource;
            _bInvisible = inbInvisible;

            _position = inposition;

        }

        public dockDataStructure(dockDataStructure inCopyFrom)
        {
            _dockType = inCopyFrom.dockType;
            _ejectOrientation = inCopyFrom.ejectOrientation;
            _orientation = inCopyFrom.orientation;
            _attachedID = inCopyFrom.attachedID;
            _boneName = inCopyFrom.boneName;
            _dockOrientation = inCopyFrom.dockOrientation;
            _resourceOnly = inCopyFrom.resourceOnly;

            _objectID = inCopyFrom.objectID;

            _ejectVelocity = inCopyFrom.ejectVelocity;
            _dockRollOffset = inCopyFrom.dockRollOffset;
            _dockYawOffset = inCopyFrom.dockYawOffset;

            _bCanAcceptRawResource = inCopyFrom.bCanAcceptRawResource;
            _bInvisible = inCopyFrom.bInvisible;

            _position = inCopyFrom.position;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _dockType;
            result += ", ";
            result += _ejectOrientation;
            result += ", ";
            result += _orientation;
            result += ", ";
            result += _attachedID;
            result += ", ";
            result += _boneName;
            result += ", ";
            result += _dockOrientation;
            result += ", ";
            result += _resourceOnly;
            result += ", ";
            for (i = 0; i < _objectID.Count; i++)
            {
                result += _objectID[i];
                if (_objectID.Count - i != 1)
                {
                    result += ", ";
                }
            }
            result += ", ";
            result += _ejectVelocity.ToString();
            result += ", ";
            result += _dockRollOffset.ToString();
            result += ", ";
            result += _dockYawOffset.ToString();
            result += ", ";
            result += _bCanAcceptRawResource.ToString();
            result += ", ";
            result += _bInvisible.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }
    }

    public class dockDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(shieldDataStructureConverter))]
    class shieldDataStructure : VD2PropertyStore
    {
        string _shieldID;
        string _shieldOrientation;

        int _pitch;
        int _roll;

        Vector3D _shieldPosition;

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

        [Description("shieldOrientation is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldOrientation
        {
            get
            {
                return _shieldOrientation;
            }
            set
            {
                _shieldOrientation = value;
                SetPropertyEdited("shieldOrientation", true);
            }
        }


        [Description("pitch is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int pitch
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

        [Description("roll is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int roll
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


        [Description("shieldPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D shieldPosition
        {
            get
            {
                return _shieldPosition;
            }
            set
            {
                _shieldPosition = value;
                SetPropertyEdited("shieldPosition", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("shieldID");
            InitProperty("shieldOrientation");

            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("shieldPosition");

        }

        public shieldDataStructure()
        {
            _shieldID = "";
            _shieldOrientation = "";

            _pitch = 0;
            _roll = 0;

            _shieldPosition = new Vector3D();

        }

        public shieldDataStructure(string inshieldID, string inshieldOrientation, int inpitch, int inroll, Vector3D inshieldPosition)
        {
            _shieldID = inshieldID;
            _shieldOrientation = inshieldOrientation;

            _pitch = inpitch;
            _roll = inroll;

            _shieldPosition = inshieldPosition;

        }

        public shieldDataStructure(shieldDataStructure inCopyFrom)
        {
            _shieldID = inCopyFrom.shieldID;
            _shieldOrientation = inCopyFrom.shieldOrientation;

            _pitch = inCopyFrom.pitch;
            _roll = inCopyFrom.roll;

            _shieldPosition = inCopyFrom.shieldPosition;

        }

        public override string ToString()
        {
            string result = "";
            result += _shieldID;
            result += ", ";
            result += _shieldOrientation;
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _roll.ToString();
            result += ", ";
            result += _shieldPosition.ToString();
            return result;
        }
    }

    public class shieldDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(rotatingElementDataStructureConverter))]
    class rotatingElementDataStructure : VD2PropertyStore
    {
        string _boneName;

        int _rollSpeed;

        bool _bLinkedToWeapon;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string boneName
        {
            get
            {
                return _boneName;
            }
            set
            {
                _boneName = value;
                SetPropertyEdited("boneName", true);
            }
        }


        [Description("rollSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rollSpeed
        {
            get
            {
                return _rollSpeed;
            }
            set
            {
                _rollSpeed = value;
                SetPropertyEdited("rollSpeed", true);
            }
        }


        [Description("bLinkedToWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLinkedToWeapon
        {
            get
            {
                return _bLinkedToWeapon;
            }
            set
            {
                _bLinkedToWeapon = value;
                SetPropertyEdited("bLinkedToWeapon", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("boneName");

            InitProperty("rollSpeed");

            InitProperty("bLinkedToWeapon");

        }

        public rotatingElementDataStructure()
        {
            _boneName = "";

            _rollSpeed = 0;

            _bLinkedToWeapon = false;

        }

        public rotatingElementDataStructure(string inboneName, int inrollSpeed, bool inbLinkedToWeapon)
        {
            _boneName = inboneName;

            _rollSpeed = inrollSpeed;

            _bLinkedToWeapon = inbLinkedToWeapon;

        }

        public rotatingElementDataStructure(rotatingElementDataStructure inCopyFrom)
        {
            _boneName = inCopyFrom.boneName;

            _rollSpeed = inCopyFrom.rollSpeed;

            _bLinkedToWeapon = inCopyFrom.bLinkedToWeapon;

        }

        public override string ToString()
        {
            string result = "";
            result += _boneName;
            result += ", ";
            result += _rollSpeed.ToString();
            result += ", ";
            result += _bLinkedToWeapon.ToString();
            return result;
        }
    }

    public class rotatingElementDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(recoilDataStructureConverter))]
    class recoilDataStructure : VD2PropertyStore
    {
        string _recoilBone;
        string _muzzleBoneName;
        string _recoilParentType;

        List<string> _muzzleBone;

        float _recoilZ;
        float _recoilTime;

        [Description("recoilBone is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string recoilBone
        {
            get
            {
                return _recoilBone;
            }
            set
            {
                _recoilBone = value;
                SetPropertyEdited("recoilBone", true);
            }
        }

        [Description("muzzleBoneName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string muzzleBoneName
        {
            get
            {
                return _muzzleBoneName;
            }
            set
            {
                _muzzleBoneName = value;
                SetPropertyEdited("muzzleBoneName", true);
            }
        }

        [Description("recoilParentType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string recoilParentType
        {
            get
            {
                return _recoilParentType;
            }
            set
            {
                _recoilParentType = value;
                SetPropertyEdited("recoilParentType", true);
            }
        }


        [Description("muzzleBone is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> muzzleBone
        {
            get
            {
                return _muzzleBone;
            }
            set
            {
                _muzzleBone = value;
                SetPropertyEdited("muzzleBone", true);
            }
        }


        [Description("recoilZ is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float recoilZ
        {
            get
            {
                return _recoilZ;
            }
            set
            {
                _recoilZ = value;
                SetPropertyEdited("recoilZ", true);
            }
        }

        [Description("recoilTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float recoilTime
        {
            get
            {
                return _recoilTime;
            }
            set
            {
                _recoilTime = value;
                SetPropertyEdited("recoilTime", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("recoilBone");
            InitProperty("muzzleBoneName");
            InitProperty("recoilParentType");

            InitProperty("muzzleBone");

            InitProperty("recoilZ");
            InitProperty("recoilTime");

        }

        public recoilDataStructure()
        {
            _recoilBone = "";
            _muzzleBoneName = "";
            _recoilParentType = "";

            _muzzleBone = new List<string>();

            _recoilZ = 0;
            _recoilTime = 0;

        }

        public recoilDataStructure(string inrecoilBone, string inmuzzleBoneName, string inrecoilParentType, List<string> inmuzzleBone, float inrecoilZ, float inrecoilTime)
        {
            _recoilBone = inrecoilBone;
            _muzzleBoneName = inmuzzleBoneName;
            _recoilParentType = inrecoilParentType;

            _muzzleBone = inmuzzleBone;

            _recoilZ = inrecoilZ;
            _recoilTime = inrecoilTime;

        }

        public recoilDataStructure(recoilDataStructure inCopyFrom)
        {
            _recoilBone = inCopyFrom.recoilBone;
            _muzzleBoneName = inCopyFrom.muzzleBoneName;
            _recoilParentType = inCopyFrom.recoilParentType;

            _muzzleBone = inCopyFrom.muzzleBone;

            _recoilZ = inCopyFrom.recoilZ;
            _recoilTime = inCopyFrom.recoilTime;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _recoilBone;
            result += ", ";
            result += _muzzleBoneName;
            result += ", ";
            result += _recoilParentType;
            result += ", ";
            for (i = 0; i < _muzzleBone.Count; i++)
            {
                result += _muzzleBone[i];
                if (_muzzleBone.Count - i != 1)
                {
                    result += ", ";
                }
            }
            result += ", ";
            result += _recoilZ.ToString();
            result += ", ";
            result += _recoilTime.ToString();
            return result;
        }
    }

    public class recoilDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(rotateBonesDataStructureConverter))]
    class rotateBonesDataStructure : VD2PropertyStore
    {
        string _rotateBone;

        [Description("rotateBone is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string rotateBone
        {
            get
            {
                return _rotateBone;
            }
            set
            {
                _rotateBone = value;
                SetPropertyEdited("rotateBone", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("rotateBone");

        }

        public rotateBonesDataStructure()
        {
            _rotateBone = "";

        }

        public rotateBonesDataStructure(string inrotateBone)
        {
            _rotateBone = inrotateBone;

        }

        public rotateBonesDataStructure(rotateBonesDataStructure inCopyFrom)
        {
            _rotateBone = inCopyFrom.rotateBone;

        }

        public override string ToString()
        {
            string result = "";
            result += _rotateBone;
            return result;
        }
    }

    public class rotateBonesDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(canisterDataStructureConverter))]
    class canisterDataStructure : VD2PropertyStore
    {
        string _projectileID;

        int _canisterCount;
        int _blowBackCanisterCount;
        int _yawRange;
        int _pitchRange;
        int _rollRange;
        int _speedAddBase;
        int _speedAddRandom;

        bool _bCanisterAimAssist;
        bool _bAddToRangeCalculations;

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string projectileID
        {
            get
            {
                return _projectileID;
            }
            set
            {
                _projectileID = value;
                SetPropertyEdited("projectileID", true);
            }
        }


        [Description("canisterCount is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int canisterCount
        {
            get
            {
                return _canisterCount;
            }
            set
            {
                _canisterCount = value;
                SetPropertyEdited("canisterCount", true);
            }
        }

        [Description("blowBackCanisterCount is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int blowBackCanisterCount
        {
            get
            {
                return _blowBackCanisterCount;
            }
            set
            {
                _blowBackCanisterCount = value;
                SetPropertyEdited("blowBackCanisterCount", true);
            }
        }

        [Description("yawRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int yawRange
        {
            get
            {
                return _yawRange;
            }
            set
            {
                _yawRange = value;
                SetPropertyEdited("yawRange", true);
            }
        }

        [Description("pitchRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int pitchRange
        {
            get
            {
                return _pitchRange;
            }
            set
            {
                _pitchRange = value;
                SetPropertyEdited("pitchRange", true);
            }
        }

        [Description("rollRange is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rollRange
        {
            get
            {
                return _rollRange;
            }
            set
            {
                _rollRange = value;
                SetPropertyEdited("rollRange", true);
            }
        }

        [Description("speedAddBase is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int speedAddBase
        {
            get
            {
                return _speedAddBase;
            }
            set
            {
                _speedAddBase = value;
                SetPropertyEdited("speedAddBase", true);
            }
        }

        [Description("speedAddRandom is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int speedAddRandom
        {
            get
            {
                return _speedAddRandom;
            }
            set
            {
                _speedAddRandom = value;
                SetPropertyEdited("speedAddRandom", true);
            }
        }


        [Description("bCanisterAimAssist is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanisterAimAssist
        {
            get
            {
                return _bCanisterAimAssist;
            }
            set
            {
                _bCanisterAimAssist = value;
                SetPropertyEdited("bCanisterAimAssist", true);
            }
        }

        [Description("bAddToRangeCalculations is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAddToRangeCalculations
        {
            get
            {
                return _bAddToRangeCalculations;
            }
            set
            {
                _bAddToRangeCalculations = value;
                SetPropertyEdited("bAddToRangeCalculations", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("projectileID");

            InitProperty("canisterCount");
            InitProperty("blowBackCanisterCount");
            InitProperty("yawRange");
            InitProperty("pitchRange");
            InitProperty("rollRange");
            InitProperty("speedAddBase");
            InitProperty("speedAddRandom");

            InitProperty("bCanisterAimAssist");
            InitProperty("bAddToRangeCalculations");

        }

        public canisterDataStructure()
        {
            _projectileID = "";

            _canisterCount = 0;
            _blowBackCanisterCount = 0;
            _yawRange = 0;
            _pitchRange = 0;
            _rollRange = 0;
            _speedAddBase = 0;
            _speedAddRandom = 0;

            _bCanisterAimAssist = false;
            _bAddToRangeCalculations = false;

        }

        public canisterDataStructure(string inprojectileID, int incanisterCount, int inblowBackCanisterCount, int inyawRange, int inpitchRange, int inrollRange, int inspeedAddBase, int inspeedAddRandom, bool inbCanisterAimAssist, bool inbAddToRangeCalculations)
        {
            _projectileID = inprojectileID;

            _canisterCount = incanisterCount;
            _blowBackCanisterCount = inblowBackCanisterCount;
            _yawRange = inyawRange;
            _pitchRange = inpitchRange;
            _rollRange = inrollRange;
            _speedAddBase = inspeedAddBase;
            _speedAddRandom = inspeedAddRandom;

            _bCanisterAimAssist = inbCanisterAimAssist;
            _bAddToRangeCalculations = inbAddToRangeCalculations;

        }

        public canisterDataStructure(canisterDataStructure inCopyFrom)
        {
            _projectileID = inCopyFrom.projectileID;

            _canisterCount = inCopyFrom.canisterCount;
            _blowBackCanisterCount = inCopyFrom.blowBackCanisterCount;
            _yawRange = inCopyFrom.yawRange;
            _pitchRange = inCopyFrom.pitchRange;
            _rollRange = inCopyFrom.rollRange;
            _speedAddBase = inCopyFrom.speedAddBase;
            _speedAddRandom = inCopyFrom.speedAddRandom;

            _bCanisterAimAssist = inCopyFrom.bCanisterAimAssist;
            _bAddToRangeCalculations = inCopyFrom.bAddToRangeCalculations;

        }

        public override string ToString()
        {
            string result = "";
            result += _projectileID;
            result += ", ";
            result += _canisterCount.ToString();
            result += ", ";
            result += _blowBackCanisterCount.ToString();
            result += ", ";
            result += _yawRange.ToString();
            result += ", ";
            result += _pitchRange.ToString();
            result += ", ";
            result += _rollRange.ToString();
            result += ", ";
            result += _speedAddBase.ToString();
            result += ", ";
            result += _speedAddRandom.ToString();
            result += ", ";
            result += _bCanisterAimAssist.ToString();
            result += ", ";
            result += _bAddToRangeCalculations.ToString();
            return result;
        }
    }

    public class canisterDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(launchTubeDataStructureConverter))]
    class launchTubeDataStructure : VD2PropertyStore
    {
        string _direction;

        Vector3D _launchDeckBeg;
        Vector3D _launchDeckEnd;
        Vector3D _dockPosition;
        Vector3D _dockSize;

        [Description("direction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                SetPropertyEdited("direction", true);
            }
        }


        [Description("launchDeckBeg is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D launchDeckBeg
        {
            get
            {
                return _launchDeckBeg;
            }
            set
            {
                _launchDeckBeg = value;
                SetPropertyEdited("launchDeckBeg", true);
            }
        }

        [Description("launchDeckEnd is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D launchDeckEnd
        {
            get
            {
                return _launchDeckEnd;
            }
            set
            {
                _launchDeckEnd = value;
                SetPropertyEdited("launchDeckEnd", true);
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
                _dockPosition = value;
                SetPropertyEdited("dockPosition", true);
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
                _dockSize = value;
                SetPropertyEdited("dockSize", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("direction");

            InitProperty("launchDeckBeg");
            InitProperty("launchDeckEnd");
            InitProperty("dockPosition");
            InitProperty("dockSize");

        }

        public launchTubeDataStructure()
        {
            _direction = "";

            _launchDeckBeg = new Vector3D();
            _launchDeckEnd = new Vector3D();
            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();

        }

        public launchTubeDataStructure(string indirection, Vector3D inlaunchDeckBeg, Vector3D inlaunchDeckEnd, Vector3D indockPosition, Vector3D indockSize)
        {
            _direction = indirection;

            _launchDeckBeg = inlaunchDeckBeg;
            _launchDeckEnd = inlaunchDeckEnd;
            _dockPosition = indockPosition;
            _dockSize = indockSize;

        }

        public launchTubeDataStructure(launchTubeDataStructure inCopyFrom)
        {
            _direction = inCopyFrom.direction;

            _launchDeckBeg = inCopyFrom.launchDeckBeg;
            _launchDeckEnd = inCopyFrom.launchDeckEnd;
            _dockPosition = inCopyFrom.dockPosition;
            _dockSize = inCopyFrom.dockSize;

        }

        public override string ToString()
        {
            string result = "";
            result += _direction;
            result += ", ";
            result += _launchDeckBeg.ToString();
            result += ", ";
            result += _launchDeckEnd.ToString();
            result += ", ";
            result += _dockPosition.ToString();
            result += ", ";
            result += _dockSize.ToString();
            return result;
        }
    }

    public class launchTubeDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(mirvDataStructureConverter))]
    class mirvDataStructure : VD2PropertyStore
    {
        string _mirvObjectID;

        int _mirvCount;

        bool _bNoExplodeOnMirv;

        [Description("mirvObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string mirvObjectID
        {
            get
            {
                return _mirvObjectID;
            }
            set
            {
                _mirvObjectID = value;
                SetPropertyEdited("mirvObjectID", true);
            }
        }


        [Description("mirvCount is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int mirvCount
        {
            get
            {
                return _mirvCount;
            }
            set
            {
                _mirvCount = value;
                SetPropertyEdited("mirvCount", true);
            }
        }


        [Description("bNoExplodeOnMirv is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoExplodeOnMirv
        {
            get
            {
                return _bNoExplodeOnMirv;
            }
            set
            {
                _bNoExplodeOnMirv = value;
                SetPropertyEdited("bNoExplodeOnMirv", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("mirvObjectID");

            InitProperty("mirvCount");

            InitProperty("bNoExplodeOnMirv");

        }

        public mirvDataStructure()
        {
            _mirvObjectID = "";

            _mirvCount = 0;

            _bNoExplodeOnMirv = false;

        }

        public mirvDataStructure(string inmirvObjectID, int inmirvCount, bool inbNoExplodeOnMirv)
        {
            _mirvObjectID = inmirvObjectID;

            _mirvCount = inmirvCount;

            _bNoExplodeOnMirv = inbNoExplodeOnMirv;

        }

        public mirvDataStructure(mirvDataStructure inCopyFrom)
        {
            _mirvObjectID = inCopyFrom.mirvObjectID;

            _mirvCount = inCopyFrom.mirvCount;

            _bNoExplodeOnMirv = inCopyFrom.bNoExplodeOnMirv;

        }

        public override string ToString()
        {
            string result = "";
            result += _mirvObjectID;
            result += ", ";
            result += _mirvCount.ToString();
            result += ", ";
            result += _bNoExplodeOnMirv.ToString();
            return result;
        }
    }

    public class mirvDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(weaponDirectionDataStructureConverter))]
    class weaponDirectionDataStructure : VD2PropertyStore
    {
        string _mainDirection;

        float _yaw;
        float _pitch;
        float _roll;

        [Description("mainDirection is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string mainDirection
        {
            get
            {
                return _mainDirection;
            }
            set
            {
                _mainDirection = value;
                SetPropertyEdited("mainDirection", true);
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



        public override void InitAllProperties()
        {
            InitProperty("mainDirection");

            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

        }

        public weaponDirectionDataStructure()
        {
            _mainDirection = "";

            _yaw = 0;
            _pitch = 0;
            _roll = 0;

        }

        public weaponDirectionDataStructure(string inmainDirection, float inyaw, float inpitch, float inroll)
        {
            _mainDirection = inmainDirection;

            _yaw = inyaw;
            _pitch = inpitch;
            _roll = inroll;

        }

        public weaponDirectionDataStructure(weaponDirectionDataStructure inCopyFrom)
        {
            _mainDirection = inCopyFrom.mainDirection;

            _yaw = inCopyFrom.yaw;
            _pitch = inCopyFrom.pitch;
            _roll = inCopyFrom.roll;

        }

        public override string ToString()
        {
            string result = "";
            result += _mainDirection;
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _roll.ToString();
            return result;
        }
    }

    public class weaponDirectionDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(turretBarrelDataStructureConverter))]
    class turretBarrelDataStructure : VD2PropertyStore
    {
        string _boneName;

        Vector3D _weaponPosition;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string boneName
        {
            get
            {
                return _boneName;
            }
            set
            {
                _boneName = value;
                SetPropertyEdited("boneName", true);
            }
        }


        [Description("weaponPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D weaponPosition
        {
            get
            {
                return _weaponPosition;
            }
            set
            {
                _weaponPosition = value;
                SetPropertyEdited("weaponPosition", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("boneName");

            InitProperty("weaponPosition");

        }

        public turretBarrelDataStructure()
        {
            _boneName = "";

            _weaponPosition = new Vector3D();

        }

        public turretBarrelDataStructure(string inboneName, Vector3D inweaponPosition)
        {
            _boneName = inboneName;

            _weaponPosition = inweaponPosition;

        }

        public turretBarrelDataStructure(turretBarrelDataStructure inCopyFrom)
        {
            _boneName = inCopyFrom.boneName;

            _weaponPosition = inCopyFrom.weaponPosition;

        }

        public override string ToString()
        {
            string result = "";
            result += _boneName;
            result += ", ";
            result += _weaponPosition.ToString();
            return result;
        }
    }

    public class turretBarrelDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(deathSpawnDataStructureConverter))]
    class deathSpawnDataStructure : VD2PropertyStore
    {
        List<string> _asteroidID;

        [Description("asteroidID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> asteroidID
        {
            get
            {
                return _asteroidID;
            }
            set
            {
                _asteroidID = value;
                SetPropertyEdited("asteroidID", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("asteroidID");

        }

        public deathSpawnDataStructure()
        {
            _asteroidID = new List<string>();

        }

        public deathSpawnDataStructure(List<string> inasteroidID)
        {
            _asteroidID = inasteroidID;

        }

        public deathSpawnDataStructure(deathSpawnDataStructure inCopyFrom)
        {
            _asteroidID = inCopyFrom.asteroidID;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            for (i = 0; i < _asteroidID.Count; i++)
            {
                result += _asteroidID[i];
                if (_asteroidID.Count - i != 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }

    public class deathSpawnDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(babyDataStructureConverter))]
    class babyDataStructure : VD2PropertyStore
    {
        string _asteroidID;

        float _lifeTimer;

        Vector3D _linearVelocity;

        [Description("asteroidID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string asteroidID
        {
            get
            {
                return _asteroidID;
            }
            set
            {
                _asteroidID = value;
                SetPropertyEdited("asteroidID", true);
            }
        }


        [Description("lifeTimer is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float lifeTimer
        {
            get
            {
                return _lifeTimer;
            }
            set
            {
                _lifeTimer = value;
                SetPropertyEdited("lifeTimer", true);
            }
        }


        [Description("linearVelocity is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D linearVelocity
        {
            get
            {
                return _linearVelocity;
            }
            set
            {
                _linearVelocity = value;
                SetPropertyEdited("linearVelocity", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("asteroidID");

            InitProperty("lifeTimer");

            InitProperty("linearVelocity");

        }

        public babyDataStructure()
        {
            _asteroidID = "";

            _lifeTimer = 0;

            _linearVelocity = new Vector3D();

        }

        public babyDataStructure(string inasteroidID, float inlifeTimer, Vector3D inlinearVelocity)
        {
            _asteroidID = inasteroidID;

            _lifeTimer = inlifeTimer;

            _linearVelocity = inlinearVelocity;

        }

        public babyDataStructure(babyDataStructure inCopyFrom)
        {
            _asteroidID = inCopyFrom.asteroidID;

            _lifeTimer = inCopyFrom.lifeTimer;

            _linearVelocity = inCopyFrom.linearVelocity;

        }

        public override string ToString()
        {
            string result = "";
            result += _asteroidID;
            result += ", ";
            result += _lifeTimer.ToString();
            result += ", ";
            result += _linearVelocity.ToString();
            return result;
        }
    }

    public class babyDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(largeDockDataStructureConverter))]
    class largeDockDataStructure : VD2PropertyStore
    {
        int _rollRotation;

        Vector3D _dockPosition;
        Vector3D _dockSize;

        [Description("rollRotation is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rollRotation
        {
            get
            {
                return _rollRotation;
            }
            set
            {
                _rollRotation = value;
                SetPropertyEdited("rollRotation", true);
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
                _dockPosition = value;
                SetPropertyEdited("dockPosition", true);
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
                _dockSize = value;
                SetPropertyEdited("dockSize", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("rollRotation");

            InitProperty("dockPosition");
            InitProperty("dockSize");

        }

        public largeDockDataStructure()
        {
            _rollRotation = 0;

            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();

        }

        public largeDockDataStructure(int inrollRotation, Vector3D indockPosition, Vector3D indockSize)
        {
            _rollRotation = inrollRotation;

            _dockPosition = indockPosition;
            _dockSize = indockSize;

        }

        public largeDockDataStructure(largeDockDataStructure inCopyFrom)
        {
            _rollRotation = inCopyFrom.rollRotation;

            _dockPosition = inCopyFrom.dockPosition;
            _dockSize = inCopyFrom.dockSize;

        }

        public override string ToString()
        {
            string result = "";
            result += _rollRotation.ToString();
            result += ", ";
            result += _dockPosition.ToString();
            result += ", ";
            result += _dockSize.ToString();
            return result;
        }
    }

    public class largeDockDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(physicalRotatingElementDataStructureConverter))]
    class physicalRotatingElementDataStructure : VD2PropertyStore
    {
        string _meshName;
        string _collisionShape;

        int _rollSpeed;
        int _yawSpeed;
        int _pitchSpeed;

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


        [Description("rollSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rollSpeed
        {
            get
            {
                return _rollSpeed;
            }
            set
            {
                _rollSpeed = value;
                SetPropertyEdited("rollSpeed", true);
            }
        }

        [Description("yawSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int yawSpeed
        {
            get
            {
                return _yawSpeed;
            }
            set
            {
                _yawSpeed = value;
                SetPropertyEdited("yawSpeed", true);
            }
        }

        [Description("pitchSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int pitchSpeed
        {
            get
            {
                return _pitchSpeed;
            }
            set
            {
                _pitchSpeed = value;
                SetPropertyEdited("pitchSpeed", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("meshName");
            InitProperty("collisionShape");

            InitProperty("rollSpeed");
            InitProperty("yawSpeed");
            InitProperty("pitchSpeed");

        }

        public physicalRotatingElementDataStructure()
        {
            _meshName = "";
            _collisionShape = "";

            _rollSpeed = 0;
            _yawSpeed = 0;
            _pitchSpeed = 0;

        }

        public physicalRotatingElementDataStructure(string inmeshName, string incollisionShape, int inrollSpeed, int inyawSpeed, int inpitchSpeed)
        {
            _meshName = inmeshName;
            _collisionShape = incollisionShape;

            _rollSpeed = inrollSpeed;
            _yawSpeed = inyawSpeed;
            _pitchSpeed = inpitchSpeed;

        }

        public physicalRotatingElementDataStructure(physicalRotatingElementDataStructure inCopyFrom)
        {
            _meshName = inCopyFrom.meshName;
            _collisionShape = inCopyFrom.collisionShape;

            _rollSpeed = inCopyFrom.rollSpeed;
            _yawSpeed = inCopyFrom.yawSpeed;
            _pitchSpeed = inCopyFrom.pitchSpeed;

        }

        public override string ToString()
        {
            string result = "";
            result += _meshName;
            result += ", ";
            result += _collisionShape;
            result += ", ";
            result += _rollSpeed.ToString();
            result += ", ";
            result += _yawSpeed.ToString();
            result += ", ";
            result += _pitchSpeed.ToString();
            return result;
        }
    }

    public class physicalRotatingElementDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(alwaysOnEffectDataStructureConverter))]
    class alwaysOnEffectDataStructure : VD2PropertyStore
    {
        string _effectID;

        Vector3D _position;

        [Description("effectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string effectID
        {
            get
            {
                return _effectID;
            }
            set
            {
                _effectID = value;
                SetPropertyEdited("effectID", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("effectID");

            InitProperty("position");

        }

        public alwaysOnEffectDataStructure()
        {
            _effectID = "";

            _position = new Vector3D();

        }

        public alwaysOnEffectDataStructure(string ineffectID, Vector3D inposition)
        {
            _effectID = ineffectID;

            _position = inposition;

        }

        public alwaysOnEffectDataStructure(alwaysOnEffectDataStructure inCopyFrom)
        {
            _effectID = inCopyFrom.effectID;

            _position = inCopyFrom.position;

        }

        public override string ToString()
        {
            string result = "";
            result += _effectID;
            result += ", ";
            result += _position.ToString();
            return result;
        }
    }

    public class alwaysOnEffectDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(cargoBayDataStructureConverter))]
    class cargoBayDataStructure : VD2PropertyStore
    {
        string _cargoBayType;

        int _maxAmount;

        [Description("cargoBayType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string cargoBayType
        {
            get
            {
                return _cargoBayType;
            }
            set
            {
                _cargoBayType = value;
                SetPropertyEdited("cargoBayType", true);
            }
        }


        [Description("maxAmount is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxAmount
        {
            get
            {
                return _maxAmount;
            }
            set
            {
                _maxAmount = value;
                SetPropertyEdited("maxAmount", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("cargoBayType");

            InitProperty("maxAmount");

        }

        public cargoBayDataStructure()
        {
            _cargoBayType = "";

            _maxAmount = 0;

        }

        public cargoBayDataStructure(string incargoBayType, int inmaxAmount)
        {
            _cargoBayType = incargoBayType;

            _maxAmount = inmaxAmount;

        }

        public cargoBayDataStructure(cargoBayDataStructure inCopyFrom)
        {
            _cargoBayType = inCopyFrom.cargoBayType;

            _maxAmount = inCopyFrom.maxAmount;

        }

        public override string ToString()
        {
            string result = "";
            result += _cargoBayType;
            result += ", ";
            result += _maxAmount.ToString();
            return result;
        }
    }

    public class cargoBayDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(gateCollisionDataStructureConverter))]
    class gateCollisionDataStructure : VD2PropertyStore
    {
        Vector3D _gateCollisionSize;

        [Description("gateCollisionSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D gateCollisionSize
        {
            get
            {
                return _gateCollisionSize;
            }
            set
            {
                _gateCollisionSize = value;
                SetPropertyEdited("gateCollisionSize", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("gateCollisionSize");

        }

        public gateCollisionDataStructure()
        {
            _gateCollisionSize = new Vector3D();

        }

        public gateCollisionDataStructure(Vector3D ingateCollisionSize)
        {
            _gateCollisionSize = ingateCollisionSize;

        }

        public gateCollisionDataStructure(gateCollisionDataStructure inCopyFrom)
        {
            _gateCollisionSize = inCopyFrom.gateCollisionSize;

        }

        public override string ToString()
        {
            string result = "";
            result += _gateCollisionSize.ToString();
            return result;
        }
    }

    public class gateCollisionDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(refuelAreaDataStructureConverter))]
    class refuelAreaDataStructure : VD2PropertyStore
    {
        string _refuelParticleSystem;

        Vector3D _refuelPosition;
        Vector3D _refuelSize;

        [Description("refuelParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string refuelParticleSystem
        {
            get
            {
                return _refuelParticleSystem;
            }
            set
            {
                _refuelParticleSystem = value;
                SetPropertyEdited("refuelParticleSystem", true);
            }
        }


        [Description("refuelPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D refuelPosition
        {
            get
            {
                return _refuelPosition;
            }
            set
            {
                _refuelPosition = value;
                SetPropertyEdited("refuelPosition", true);
            }
        }

        [Description("refuelSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D refuelSize
        {
            get
            {
                return _refuelSize;
            }
            set
            {
                _refuelSize = value;
                SetPropertyEdited("refuelSize", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("refuelParticleSystem");

            InitProperty("refuelPosition");
            InitProperty("refuelSize");

        }

        public refuelAreaDataStructure()
        {
            _refuelParticleSystem = "";

            _refuelPosition = new Vector3D();
            _refuelSize = new Vector3D();

        }

        public refuelAreaDataStructure(string inrefuelParticleSystem, Vector3D inrefuelPosition, Vector3D inrefuelSize)
        {
            _refuelParticleSystem = inrefuelParticleSystem;

            _refuelPosition = inrefuelPosition;
            _refuelSize = inrefuelSize;

        }

        public refuelAreaDataStructure(refuelAreaDataStructure inCopyFrom)
        {
            _refuelParticleSystem = inCopyFrom.refuelParticleSystem;

            _refuelPosition = inCopyFrom.refuelPosition;
            _refuelSize = inCopyFrom.refuelSize;

        }

        public override string ToString()
        {
            string result = "";
            result += _refuelParticleSystem;
            result += ", ";
            result += _refuelPosition.ToString();
            result += ", ";
            result += _refuelSize.ToString();
            return result;
        }
    }

    public class refuelAreaDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(repairAreaDataStructureConverter))]
    class repairAreaDataStructure : VD2PropertyStore
    {
        string _repairParticleSystem;
        string _repairSoundID;
        string _maxRepairClass;

        Vector3D _repairPosition;
        Vector3D _repairSize;

        [Description("repairParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string repairParticleSystem
        {
            get
            {
                return _repairParticleSystem;
            }
            set
            {
                _repairParticleSystem = value;
                SetPropertyEdited("repairParticleSystem", true);
            }
        }

        [Description("repairSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string repairSoundID
        {
            get
            {
                return _repairSoundID;
            }
            set
            {
                _repairSoundID = value;
                SetPropertyEdited("repairSoundID", true);
            }
        }

        [Description("maxRepairClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string maxRepairClass
        {
            get
            {
                return _maxRepairClass;
            }
            set
            {
                _maxRepairClass = value;
                SetPropertyEdited("maxRepairClass", true);
            }
        }


        [Description("repairPosition is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D repairPosition
        {
            get
            {
                return _repairPosition;
            }
            set
            {
                _repairPosition = value;
                SetPropertyEdited("repairPosition", true);
            }
        }

        [Description("repairSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D repairSize
        {
            get
            {
                return _repairSize;
            }
            set
            {
                _repairSize = value;
                SetPropertyEdited("repairSize", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("repairParticleSystem");
            InitProperty("repairSoundID");
            InitProperty("maxRepairClass");

            InitProperty("repairPosition");
            InitProperty("repairSize");

        }

        public repairAreaDataStructure()
        {
            _repairParticleSystem = "";
            _repairSoundID = "";
            _maxRepairClass = "";

            _repairPosition = new Vector3D();
            _repairSize = new Vector3D();

        }

        public repairAreaDataStructure(string inrepairParticleSystem, string inrepairSoundID, string inmaxRepairClass, Vector3D inrepairPosition, Vector3D inrepairSize)
        {
            _repairParticleSystem = inrepairParticleSystem;
            _repairSoundID = inrepairSoundID;
            _maxRepairClass = inmaxRepairClass;

            _repairPosition = inrepairPosition;
            _repairSize = inrepairSize;

        }

        public repairAreaDataStructure(repairAreaDataStructure inCopyFrom)
        {
            _repairParticleSystem = inCopyFrom.repairParticleSystem;
            _repairSoundID = inCopyFrom.repairSoundID;
            _maxRepairClass = inCopyFrom.maxRepairClass;

            _repairPosition = inCopyFrom.repairPosition;
            _repairSize = inCopyFrom.repairSize;

        }

        public override string ToString()
        {
            string result = "";
            result += _repairParticleSystem;
            result += ", ";
            result += _repairSoundID;
            result += ", ";
            result += _maxRepairClass;
            result += ", ";
            result += _repairPosition.ToString();
            result += ", ";
            result += _repairSize.ToString();
            return result;
        }
    }

    public class repairAreaDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(mineDataStructureConverter))]
    class mineDataStructure : VD2PropertyStore
    {
        string _mineID;

        Vector3D _position;
        Vector3D _linearVelocity;

        [Description("mineID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string mineID
        {
            get
            {
                return _mineID;
            }
            set
            {
                _mineID = value;
                SetPropertyEdited("mineID", true);
            }
        }


        [Description("position is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetPropertyEdited("position", true);
            }
        }

        [Description("linearVelocity is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D linearVelocity
        {
            get
            {
                return _linearVelocity;
            }
            set
            {
                _linearVelocity = value;
                SetPropertyEdited("linearVelocity", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("mineID");

            InitProperty("position");
            InitProperty("linearVelocity");

        }

        public mineDataStructure()
        {
            _mineID = "";

            _position = new Vector3D();
            _linearVelocity = new Vector3D();

        }

        public mineDataStructure(string inmineID, Vector3D inposition, Vector3D inlinearVelocity)
        {
            _mineID = inmineID;

            _position = inposition;
            _linearVelocity = inlinearVelocity;

        }

        public mineDataStructure(mineDataStructure inCopyFrom)
        {
            _mineID = inCopyFrom.mineID;

            _position = inCopyFrom.position;
            _linearVelocity = inCopyFrom.linearVelocity;

        }

        public override string ToString()
        {
            string result = "";
            result += _mineID;
            result += ", ";
            result += _position.ToString();
            result += ", ";
            result += _linearVelocity.ToString();
            return result;
        }
    }

    public class mineDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

    [TypeConverter(typeof(damageCollisionFieldDataStructureConverter))]
    class damageCollisionFieldDataStructure : VD2PropertyStore
    {
        int _damage;
        int _scale;

        [Description("damage is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damage
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

        [Description("scale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                SetPropertyEdited("scale", true);
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("damage");
            InitProperty("scale");

        }

        public damageCollisionFieldDataStructure()
        {
            _damage = 0;
            _scale = 0;

        }

        public damageCollisionFieldDataStructure(int indamage, int inscale)
        {
            _damage = indamage;
            _scale = inscale;

        }

        public damageCollisionFieldDataStructure(damageCollisionFieldDataStructure inCopyFrom)
        {
            _damage = inCopyFrom.damage;
            _scale = inCopyFrom.scale;

        }

        public override string ToString()
        {
            string result = "";
            result += _damage.ToString();
            result += ", ";
            result += _scale.ToString();
            return result;
        }
    }

    public class damageCollisionFieldDataStructureConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

}
