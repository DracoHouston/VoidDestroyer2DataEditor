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
    class VD2DataStructure
    {
        public Dictionary<string, VD2PropertyInfo> VD2PropertyInfos;

        public VD2DataStructure()
        {
            VD2PropertyInfos = new Dictionary<string, VD2PropertyInfo>();
        }

        public void SetPropertyEdited(string inName, bool inEdited)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.EditedByUser = inEdited;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyEdited(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.EditedByUser;
                }
            }
            return result;
        }

        public void SetPropertyExists(string inName, bool inExists)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.Exists = inExists;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExists(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.Exists;
                }
            }
            return result;
        }

        public void SetPropertyExistsInBaseData(string inName, bool inExistsInBaseData)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    info.ExistsInBaseData = inExistsInBaseData;
                    UpdatePropertyInfo(inName, info);
                }
            }
        }

        public bool PropertyExistsInBaseData(string inName)
        {
            bool result = false;
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfo info = null;
                if (VD2PropertyInfos.TryGetValue(inName, out info))
                {
                    result = info.ExistsInBaseData;
                }
            }
            return result;
        }

        public void UpdatePropertyInfo(string inName, VD2PropertyInfo inInfo)
        {
            if (VD2PropertyInfos.ContainsKey(inName))
            {
                VD2PropertyInfos.Remove(inName);
                VD2PropertyInfos.Add(inName, inInfo);
            }
        }
    }

    [TypeConverter(typeof(debrisInfoDataStructureConverter))]
    class debrisInfoDataStructure
    {
        List<debrisDataStructure> _debris;

        [Description("debris is a collection of datastructures"), Category("Data Structure Collection")]
        public List<debrisDataStructure> debris
        {
            get => _debris;
            set => _debris = value;
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
            get => _debrisID;
            set => _debrisID = value;
        }


        [Description("debrisMomentum is an integer"), Category("Integers")]
        public int debrisMomentum
        {
            get => _debrisMomentum;
            set => _debrisMomentum = value;
        }

        [Description("debrisAngular is an integer"), Category("Integers")]
        public int debrisAngular
        {
            get => _debrisAngular;
            set => _debrisAngular = value;
        }



        public debrisDataStructure() : base()
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;

        }

        public debrisDataStructure(string indebrisID, int indebrisMomentum, int indebrisAngular) : base()
        {
            _debrisID = indebrisID;

            _debrisMomentum = indebrisMomentum;
            _debrisAngular = indebrisAngular;

        }

        public debrisDataStructure(debrisDataStructure inCopyFrom) : base()
        {
            _debrisID = inCopyFrom.debrisID;

            _debrisMomentum = inCopyFrom.debrisMomentum;
            _debrisAngular = inCopyFrom.debrisAngular;

        }

        public override string ToString()
        {
            int i = 0;
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
    class afterburnerDataStructure
    {
        string _soundID;
        string _tailSoundID;

        float _multiplier;
        float _capacity;
        float _recharge;

        [Description("soundID is a plaintext string"), Category("Plaintext Strings")]
        public string soundID
        {
            get => _soundID;
            set => _soundID = value;
        }

        [Description("tailSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string tailSoundID
        {
            get => _tailSoundID;
            set => _tailSoundID = value;
        }


        [Description("multiplier is a real number"), Category("Real Numbers")]
        public float multiplier
        {
            get => _multiplier;
            set => _multiplier = value;
        }

        [Description("capacity is a real number"), Category("Real Numbers")]
        public float capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        [Description("recharge is a real number"), Category("Real Numbers")]
        public float recharge
        {
            get => _recharge;
            set => _recharge = value;
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
            int i = 0;
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
    class targetPriorityListDataStructure
    {
        List<string> _targetClass;

        [Description("targetClass is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> targetClass
        {
            get => _targetClass;
            set => _targetClass = value;
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
    class upgradesDataStructure
    {
        List<string> _upgradeID;

        int _primaryUpgradeCapacity;
        int _activeUpgradeCapacity;

        [Description("upgradeID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> upgradeID
        {
            get => _upgradeID;
            set => _upgradeID = value;
        }


        [Description("primaryUpgradeCapacity is an integer"), Category("Integers")]
        public int primaryUpgradeCapacity
        {
            get => _primaryUpgradeCapacity;
            set => _primaryUpgradeCapacity = value;
        }

        [Description("activeUpgradeCapacity is an integer"), Category("Integers")]
        public int activeUpgradeCapacity
        {
            get => _activeUpgradeCapacity;
            set => _activeUpgradeCapacity = value;
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
    class propulsionDataStructure
    {
        string _propulsionEffectID;
        string _direction;

        float _pitch;
        float _yaw;

        bool _bPlayerShipOnly;

        Vector3D _position;

        [Description("propulsionEffectID is a plaintext string"), Category("Plaintext Strings")]
        public string propulsionEffectID
        {
            get => _propulsionEffectID;
            set => _propulsionEffectID = value;
        }

        [Description("direction is a plaintext string"), Category("Plaintext Strings")]
        public string direction
        {
            get => _direction;
            set => _direction = value;
        }


        [Description("pitch is a real number"), Category("Real Numbers")]
        public float pitch
        {
            get => _pitch;
            set => _pitch = value;
        }

        [Description("yaw is a real number"), Category("Real Numbers")]
        public float yaw
        {
            get => _yaw;
            set => _yaw = value;
        }


        [Description("bPlayerShipOnly is a boolean value"), Category("Booleans")]
        public bool bPlayerShipOnly
        {
            get => _bPlayerShipOnly;
            set => _bPlayerShipOnly = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
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
            int i = 0;
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
    class weaponDataStructure
    {
        string _weaponType;
        string _hardpointID;
        string _weaponFire;

        float _barrelDelay;
        float _yaw;
        float _pitch;

        List<Vector3D> _weaponPosition;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings")]
        public string weaponType
        {
            get => _weaponType;
            set => _weaponType = value;
        }

        [Description("hardpointID is a plaintext string"), Category("Plaintext Strings")]
        public string hardpointID
        {
            get => _hardpointID;
            set => _hardpointID = value;
        }

        [Description("weaponFire is a plaintext string"), Category("Plaintext Strings")]
        public string weaponFire
        {
            get => _weaponFire;
            set => _weaponFire = value;
        }


        [Description("barrelDelay is a real number"), Category("Real Numbers")]
        public float barrelDelay
        {
            get => _barrelDelay;
            set => _barrelDelay = value;
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


        [Description("weaponPosition is a collection of 3D vectors"), Category("3D Vector Collections")]
        public List<Vector3D> weaponPosition
        {
            get => _weaponPosition;
            set => _weaponPosition = value;
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
    class damageDataStructure
    {
        string _damageEffectID;

        float _pitch;
        float _roll;
        float _yaw;
        float _healthPoint;

        Vector3D _position;

        [Description("damageEffectID is a plaintext string"), Category("Plaintext Strings")]
        public string damageEffectID
        {
            get => _damageEffectID;
            set => _damageEffectID = value;
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

        [Description("yaw is a real number"), Category("Real Numbers")]
        public float yaw
        {
            get => _yaw;
            set => _yaw = value;
        }

        [Description("healthPoint is a real number"), Category("Real Numbers")]
        public float healthPoint
        {
            get => _healthPoint;
            set => _healthPoint = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
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
            int i = 0;
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
    class turretDataStructure
    {
        string _turretID;
        string _turretOrientation;
        string _weaponFire;

        List<string> _turretRole;

        int _yawPermitted;
        int _weaponPositionID;

        float _pitchLower;
        float _roll;

        List<float> _yaw;

        bool _bShowInCockpit;
        bool _bHideInHangar;

        Vector3D _position;

        [Description("turretID is a plaintext string"), Category("Plaintext Strings")]
        public string turretID
        {
            get => _turretID;
            set => _turretID = value;
        }

        [Description("turretOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string turretOrientation
        {
            get => _turretOrientation;
            set => _turretOrientation = value;
        }

        [Description("weaponFire is a plaintext string"), Category("Plaintext Strings")]
        public string weaponFire
        {
            get => _weaponFire;
            set => _weaponFire = value;
        }


        [Description("turretRole is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> turretRole
        {
            get => _turretRole;
            set => _turretRole = value;
        }


        [Description("yawPermitted is an integer"), Category("Integers")]
        public int yawPermitted
        {
            get => _yawPermitted;
            set => _yawPermitted = value;
        }

        [Description("weaponPositionID is an integer"), Category("Integers")]
        public int weaponPositionID
        {
            get => _weaponPositionID;
            set => _weaponPositionID = value;
        }


        [Description("pitchLower is a real number"), Category("Real Numbers")]
        public float pitchLower
        {
            get => _pitchLower;
            set => _pitchLower = value;
        }

        [Description("roll is a real number"), Category("Real Numbers")]
        public float roll
        {
            get => _roll;
            set => _roll = value;
        }


        [Description("yaw is a collection of real numbers"), Category("Real Number Collections")]
        public List<float> yaw
        {
            get => _yaw;
            set => _yaw = value;
        }


        [Description("bShowInCockpit is a boolean value"), Category("Booleans")]
        public bool bShowInCockpit
        {
            get => _bShowInCockpit;
            set => _bShowInCockpit = value;
        }

        [Description("bHideInHangar is a boolean value"), Category("Booleans")]
        public bool bHideInHangar
        {
            get => _bHideInHangar;
            set => _bHideInHangar = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
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

            _yaw = new List<float>();

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();

        }

        public turretDataStructure(string inturretID, string inturretOrientation, string inweaponFire, List<string> inturretRole, int inyawPermitted, int inweaponPositionID, float inpitchLower, float inroll, List<float> inyaw, bool inbShowInCockpit, bool inbHideInHangar, Vector3D inposition)
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
            for (i = 0; i < _yaw.Count; i++)
            {
                result += _yaw[i].ToString();
                if (_yaw.Count - i != 1)
                {
                    result += ", ";
                }
            }
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
    class attachmentDataStructure
    {
        string _attachmentOrientation;

        List<string> _attachmentID;

        Vector3D _attachmentPosition;

        [Description("attachmentOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string attachmentOrientation
        {
            get => _attachmentOrientation;
            set => _attachmentOrientation = value;
        }


        [Description("attachmentID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> attachmentID
        {
            get => _attachmentID;
            set => _attachmentID = value;
        }


        [Description("attachmentPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D attachmentPosition
        {
            get => _attachmentPosition;
            set => _attachmentPosition = value;
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
    class movingElementDataStructure
    {
        string _boneName;

        float _yaw;
        float _pitch;
        float _roll;
        float _speedMultiplier;

        bool _bLinkedToWeapon;
        bool _bCombat;

        Vector3D _translateAmount;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings")]
        public string boneName
        {
            get => _boneName;
            set => _boneName = value;
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

        [Description("speedMultiplier is a real number"), Category("Real Numbers")]
        public float speedMultiplier
        {
            get => _speedMultiplier;
            set => _speedMultiplier = value;
        }


        [Description("bLinkedToWeapon is a boolean value"), Category("Booleans")]
        public bool bLinkedToWeapon
        {
            get => _bLinkedToWeapon;
            set => _bLinkedToWeapon = value;
        }

        [Description("bCombat is a boolean value"), Category("Booleans")]
        public bool bCombat
        {
            get => _bCombat;
            set => _bCombat = value;
        }


        [Description("translateAmount is a 3D vector"), Category("3D Vectors")]
        public Vector3D translateAmount
        {
            get => _translateAmount;
            set => _translateAmount = value;
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
            int i = 0;
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
    class dockDataStructure
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

        [Description("dockType is a plaintext string"), Category("Plaintext Strings")]
        public string dockType
        {
            get => _dockType;
            set => _dockType = value;
        }

        [Description("ejectOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string ejectOrientation
        {
            get => _ejectOrientation;
            set => _ejectOrientation = value;
        }

        [Description("orientation is a plaintext string"), Category("Plaintext Strings")]
        public string orientation
        {
            get => _orientation;
            set => _orientation = value;
        }

        [Description("attachedID is a plaintext string"), Category("Plaintext Strings")]
        public string attachedID
        {
            get => _attachedID;
            set => _attachedID = value;
        }

        [Description("boneName is a plaintext string"), Category("Plaintext Strings")]
        public string boneName
        {
            get => _boneName;
            set => _boneName = value;
        }

        [Description("dockOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string dockOrientation
        {
            get => _dockOrientation;
            set => _dockOrientation = value;
        }

        [Description("resourceOnly is a plaintext string"), Category("Plaintext Strings")]
        public string resourceOnly
        {
            get => _resourceOnly;
            set => _resourceOnly = value;
        }


        [Description("objectID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> objectID
        {
            get => _objectID;
            set => _objectID = value;
        }


        [Description("ejectVelocity is an integer"), Category("Integers")]
        public int ejectVelocity
        {
            get => _ejectVelocity;
            set => _ejectVelocity = value;
        }

        [Description("dockRollOffset is an integer"), Category("Integers")]
        public int dockRollOffset
        {
            get => _dockRollOffset;
            set => _dockRollOffset = value;
        }

        [Description("dockYawOffset is an integer"), Category("Integers")]
        public int dockYawOffset
        {
            get => _dockYawOffset;
            set => _dockYawOffset = value;
        }


        [Description("bCanAcceptRawResource is a boolean value"), Category("Booleans")]
        public bool bCanAcceptRawResource
        {
            get => _bCanAcceptRawResource;
            set => _bCanAcceptRawResource = value;
        }

        [Description("bInvisible is a boolean value"), Category("Booleans")]
        public bool bInvisible
        {
            get => _bInvisible;
            set => _bInvisible = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
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
    class shieldDataStructure
    {
        string _shieldID;
        string _shieldOrientation;

        int _pitch;
        int _roll;

        Vector3D _shieldPosition;

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings")]
        public string shieldID
        {
            get => _shieldID;
            set => _shieldID = value;
        }

        [Description("shieldOrientation is a plaintext string"), Category("Plaintext Strings")]
        public string shieldOrientation
        {
            get => _shieldOrientation;
            set => _shieldOrientation = value;
        }


        [Description("pitch is an integer"), Category("Integers")]
        public int pitch
        {
            get => _pitch;
            set => _pitch = value;
        }

        [Description("roll is an integer"), Category("Integers")]
        public int roll
        {
            get => _roll;
            set => _roll = value;
        }


        [Description("shieldPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D shieldPosition
        {
            get => _shieldPosition;
            set => _shieldPosition = value;
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
            int i = 0;
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
    class rotatingElementDataStructure
    {
        string _boneName;

        int _rollSpeed;

        bool _bLinkedToWeapon;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings")]
        public string boneName
        {
            get => _boneName;
            set => _boneName = value;
        }


        [Description("rollSpeed is an integer"), Category("Integers")]
        public int rollSpeed
        {
            get => _rollSpeed;
            set => _rollSpeed = value;
        }


        [Description("bLinkedToWeapon is a boolean value"), Category("Booleans")]
        public bool bLinkedToWeapon
        {
            get => _bLinkedToWeapon;
            set => _bLinkedToWeapon = value;
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
            int i = 0;
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
    class recoilDataStructure
    {
        string _recoilBone;
        string _muzzleBoneName;
        string _recoilParentType;

        List<string> _muzzleBone;

        float _recoilZ;
        float _recoilTime;

        [Description("recoilBone is a plaintext string"), Category("Plaintext Strings")]
        public string recoilBone
        {
            get => _recoilBone;
            set => _recoilBone = value;
        }

        [Description("muzzleBoneName is a plaintext string"), Category("Plaintext Strings")]
        public string muzzleBoneName
        {
            get => _muzzleBoneName;
            set => _muzzleBoneName = value;
        }

        [Description("recoilParentType is a plaintext string"), Category("Plaintext Strings")]
        public string recoilParentType
        {
            get => _recoilParentType;
            set => _recoilParentType = value;
        }


        [Description("muzzleBone is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> muzzleBone
        {
            get => _muzzleBone;
            set => _muzzleBone = value;
        }


        [Description("recoilZ is a real number"), Category("Real Numbers")]
        public float recoilZ
        {
            get => _recoilZ;
            set => _recoilZ = value;
        }

        [Description("recoilTime is a real number"), Category("Real Numbers")]
        public float recoilTime
        {
            get => _recoilTime;
            set => _recoilTime = value;
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
    class rotateBonesDataStructure
    {
        string _rotateBone;

        [Description("rotateBone is a plaintext string"), Category("Plaintext Strings")]
        public string rotateBone
        {
            get => _rotateBone;
            set => _rotateBone = value;
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
            int i = 0;
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
    class canisterDataStructure
    {
        string _projectileID;

        int _canisterCount;
        int _yawRange;
        int _pitchRange;
        int _rollRange;
        int _speedAddBase;
        int _speedAddRandom;

        bool _blowBackCanisterCount;
        bool _bCanisterAimAssist;
        bool _bAddToRangeCalculations;

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings")]
        public string projectileID
        {
            get => _projectileID;
            set => _projectileID = value;
        }


        [Description("canisterCount is an integer"), Category("Integers")]
        public int canisterCount
        {
            get => _canisterCount;
            set => _canisterCount = value;
        }

        [Description("yawRange is an integer"), Category("Integers")]
        public int yawRange
        {
            get => _yawRange;
            set => _yawRange = value;
        }

        [Description("pitchRange is an integer"), Category("Integers")]
        public int pitchRange
        {
            get => _pitchRange;
            set => _pitchRange = value;
        }

        [Description("rollRange is an integer"), Category("Integers")]
        public int rollRange
        {
            get => _rollRange;
            set => _rollRange = value;
        }

        [Description("speedAddBase is an integer"), Category("Integers")]
        public int speedAddBase
        {
            get => _speedAddBase;
            set => _speedAddBase = value;
        }

        [Description("speedAddRandom is an integer"), Category("Integers")]
        public int speedAddRandom
        {
            get => _speedAddRandom;
            set => _speedAddRandom = value;
        }


        [Description("blowBackCanisterCount is a boolean value"), Category("Booleans")]
        public bool blowBackCanisterCount
        {
            get => _blowBackCanisterCount;
            set => _blowBackCanisterCount = value;
        }

        [Description("bCanisterAimAssist is a boolean value"), Category("Booleans")]
        public bool bCanisterAimAssist
        {
            get => _bCanisterAimAssist;
            set => _bCanisterAimAssist = value;
        }

        [Description("bAddToRangeCalculations is a boolean value"), Category("Booleans")]
        public bool bAddToRangeCalculations
        {
            get => _bAddToRangeCalculations;
            set => _bAddToRangeCalculations = value;
        }



        public canisterDataStructure()
        {
            _projectileID = "";

            _canisterCount = 0;
            _yawRange = 0;
            _pitchRange = 0;
            _rollRange = 0;
            _speedAddBase = 0;
            _speedAddRandom = 0;

            _blowBackCanisterCount = false;
            _bCanisterAimAssist = false;
            _bAddToRangeCalculations = false;

        }

        public canisterDataStructure(string inprojectileID, int incanisterCount, int inyawRange, int inpitchRange, int inrollRange, int inspeedAddBase, int inspeedAddRandom, bool inblowBackCanisterCount, bool inbCanisterAimAssist, bool inbAddToRangeCalculations)
        {
            _projectileID = inprojectileID;

            _canisterCount = incanisterCount;
            _yawRange = inyawRange;
            _pitchRange = inpitchRange;
            _rollRange = inrollRange;
            _speedAddBase = inspeedAddBase;
            _speedAddRandom = inspeedAddRandom;

            _blowBackCanisterCount = inblowBackCanisterCount;
            _bCanisterAimAssist = inbCanisterAimAssist;
            _bAddToRangeCalculations = inbAddToRangeCalculations;

        }

        public canisterDataStructure(canisterDataStructure inCopyFrom)
        {
            _projectileID = inCopyFrom.projectileID;

            _canisterCount = inCopyFrom.canisterCount;
            _yawRange = inCopyFrom.yawRange;
            _pitchRange = inCopyFrom.pitchRange;
            _rollRange = inCopyFrom.rollRange;
            _speedAddBase = inCopyFrom.speedAddBase;
            _speedAddRandom = inCopyFrom.speedAddRandom;

            _blowBackCanisterCount = inCopyFrom.blowBackCanisterCount;
            _bCanisterAimAssist = inCopyFrom.bCanisterAimAssist;
            _bAddToRangeCalculations = inCopyFrom.bAddToRangeCalculations;

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            result += _projectileID;
            result += ", ";
            result += _canisterCount.ToString();
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
            result += _blowBackCanisterCount.ToString();
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
    class launchTubeDataStructure
    {
        string _direction;

        Vector3D _launchDeckBeg;
        Vector3D _launchDeckEnd;
        Vector3D _dockPosition;
        Vector3D _dockSize;

        [Description("direction is a plaintext string"), Category("Plaintext Strings")]
        public string direction
        {
            get => _direction;
            set => _direction = value;
        }


        [Description("launchDeckBeg is a 3D vector"), Category("3D Vectors")]
        public Vector3D launchDeckBeg
        {
            get => _launchDeckBeg;
            set => _launchDeckBeg = value;
        }

        [Description("launchDeckEnd is a 3D vector"), Category("3D Vectors")]
        public Vector3D launchDeckEnd
        {
            get => _launchDeckEnd;
            set => _launchDeckEnd = value;
        }

        [Description("dockPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockPosition
        {
            get => _dockPosition;
            set => _dockPosition = value;
        }

        [Description("dockSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockSize
        {
            get => _dockSize;
            set => _dockSize = value;
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
            int i = 0;
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
    class mirvDataStructure
    {
        string _mirvObjectID;

        int _mirvCount;

        bool _bNoExplodeOnMirv;

        [Description("mirvObjectID is a plaintext string"), Category("Plaintext Strings")]
        public string mirvObjectID
        {
            get => _mirvObjectID;
            set => _mirvObjectID = value;
        }


        [Description("mirvCount is an integer"), Category("Integers")]
        public int mirvCount
        {
            get => _mirvCount;
            set => _mirvCount = value;
        }


        [Description("bNoExplodeOnMirv is a boolean value"), Category("Booleans")]
        public bool bNoExplodeOnMirv
        {
            get => _bNoExplodeOnMirv;
            set => _bNoExplodeOnMirv = value;
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
            int i = 0;
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
    class weaponDirectionDataStructure
    {
        string _mainDirection;

        float _yaw;
        float _pitch;
        float _roll;

        [Description("mainDirection is a plaintext string"), Category("Plaintext Strings")]
        public string mainDirection
        {
            get => _mainDirection;
            set => _mainDirection = value;
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
            int i = 0;
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
    class turretBarrelDataStructure
    {
        string _boneName;

        Vector3D _weaponPosition;

        [Description("boneName is a plaintext string"), Category("Plaintext Strings")]
        public string boneName
        {
            get => _boneName;
            set => _boneName = value;
        }


        [Description("weaponPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D weaponPosition
        {
            get => _weaponPosition;
            set => _weaponPosition = value;
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
            int i = 0;
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
    class deathSpawnDataStructure
    {
        List<string> _asteroidID;

        [Description("asteroidID is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> asteroidID
        {
            get => _asteroidID;
            set => _asteroidID = value;
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
    class babyDataStructure
    {
        string _asteroidID;

        float _lifeTimer;

        Vector3D _linearVelocity;

        [Description("asteroidID is a plaintext string"), Category("Plaintext Strings")]
        public string asteroidID
        {
            get => _asteroidID;
            set => _asteroidID = value;
        }


        [Description("lifeTimer is a real number"), Category("Real Numbers")]
        public float lifeTimer
        {
            get => _lifeTimer;
            set => _lifeTimer = value;
        }


        [Description("linearVelocity is a 3D vector"), Category("3D Vectors")]
        public Vector3D linearVelocity
        {
            get => _linearVelocity;
            set => _linearVelocity = value;
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
            int i = 0;
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
    class largeDockDataStructure
    {
        int _rollRotation;

        Vector3D _dockPosition;
        Vector3D _dockSize;

        [Description("rollRotation is an integer"), Category("Integers")]
        public int rollRotation
        {
            get => _rollRotation;
            set => _rollRotation = value;
        }


        [Description("dockPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockPosition
        {
            get => _dockPosition;
            set => _dockPosition = value;
        }

        [Description("dockSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D dockSize
        {
            get => _dockSize;
            set => _dockSize = value;
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
            int i = 0;
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
    class physicalRotatingElementDataStructure
    {
        string _meshName;
        string _collisionShape;

        int _rollSpeed;
        int _yawSpeed;
        int _pitchSpeed;

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings")]
        public string collisionShape
        {
            get => _collisionShape;
            set => _collisionShape = value;
        }


        [Description("rollSpeed is an integer"), Category("Integers")]
        public int rollSpeed
        {
            get => _rollSpeed;
            set => _rollSpeed = value;
        }

        [Description("yawSpeed is an integer"), Category("Integers")]
        public int yawSpeed
        {
            get => _yawSpeed;
            set => _yawSpeed = value;
        }

        [Description("pitchSpeed is an integer"), Category("Integers")]
        public int pitchSpeed
        {
            get => _pitchSpeed;
            set => _pitchSpeed = value;
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
            int i = 0;
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
    class alwaysOnEffectDataStructure
    {
        string _effectID;

        Vector3D _position;

        [Description("effectID is a plaintext string"), Category("Plaintext Strings")]
        public string effectID
        {
            get => _effectID;
            set => _effectID = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
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
            int i = 0;
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
    class cargoBayDataStructure
    {
        string _cargoBayType;

        int _maxAmount;

        [Description("cargoBayType is a plaintext string"), Category("Plaintext Strings")]
        public string cargoBayType
        {
            get => _cargoBayType;
            set => _cargoBayType = value;
        }


        [Description("maxAmount is an integer"), Category("Integers")]
        public int maxAmount
        {
            get => _maxAmount;
            set => _maxAmount = value;
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
            int i = 0;
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
    class gateCollisionDataStructure
    {
        Vector3D _gateCollisionSize;

        [Description("gateCollisionSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D gateCollisionSize
        {
            get => _gateCollisionSize;
            set => _gateCollisionSize = value;
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
            int i = 0;
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
    class refuelAreaDataStructure
    {
        string _refuelParticleSystem;

        Vector3D _refuelPosition;
        Vector3D _refuelSize;

        [Description("refuelParticleSystem is a plaintext string"), Category("Plaintext Strings")]
        public string refuelParticleSystem
        {
            get => _refuelParticleSystem;
            set => _refuelParticleSystem = value;
        }


        [Description("refuelPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D refuelPosition
        {
            get => _refuelPosition;
            set => _refuelPosition = value;
        }

        [Description("refuelSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D refuelSize
        {
            get => _refuelSize;
            set => _refuelSize = value;
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
            int i = 0;
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
    class repairAreaDataStructure
    {
        string _repairParticleSystem;
        string _repairSoundID;
        string _maxRepairClass;

        Vector3D _repairPosition;
        Vector3D _repairSize;

        [Description("repairParticleSystem is a plaintext string"), Category("Plaintext Strings")]
        public string repairParticleSystem
        {
            get => _repairParticleSystem;
            set => _repairParticleSystem = value;
        }

        [Description("repairSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string repairSoundID
        {
            get => _repairSoundID;
            set => _repairSoundID = value;
        }

        [Description("maxRepairClass is a plaintext string"), Category("Plaintext Strings")]
        public string maxRepairClass
        {
            get => _maxRepairClass;
            set => _maxRepairClass = value;
        }


        [Description("repairPosition is a 3D vector"), Category("3D Vectors")]
        public Vector3D repairPosition
        {
            get => _repairPosition;
            set => _repairPosition = value;
        }

        [Description("repairSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D repairSize
        {
            get => _repairSize;
            set => _repairSize = value;
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
            int i = 0;
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
    class mineDataStructure
    {
        string _mineID;

        Vector3D _position;
        Vector3D _linearVelocity;

        [Description("mineID is a plaintext string"), Category("Plaintext Strings")]
        public string mineID
        {
            get => _mineID;
            set => _mineID = value;
        }


        [Description("position is a 3D vector"), Category("3D Vectors")]
        public Vector3D position
        {
            get => _position;
            set => _position = value;
        }

        [Description("linearVelocity is a 3D vector"), Category("3D Vectors")]
        public Vector3D linearVelocity
        {
            get => _linearVelocity;
            set => _linearVelocity = value;
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
            int i = 0;
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
    class damageCollisionFieldDataStructure
    {
        int _damage;
        int _scale;

        [Description("damage is an integer"), Category("Integers")]
        public int damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("scale is an integer"), Category("Integers")]
        public int scale
        {
            get => _scale;
            set => _scale = value;
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
            int i = 0;
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
