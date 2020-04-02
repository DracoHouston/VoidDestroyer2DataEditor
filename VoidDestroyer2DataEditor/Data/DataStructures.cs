using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class debrisInfoDataStructure : VD2DataStructure
    {
        ObservableCollection<debrisDataStructure> _debris;

        [Description("debris is a collection of datastructures"), Category("Data Structure Collection")]
        public ObservableCollection<debrisDataStructure> debris
        {
            get
            {
                return _debris;
            }
            set
            {
                _debris = value;
            }
        }

        public void OndebrisChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("debris", true);
                        ParentDataFile.SetPropertyEdited("debrisInfo", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _debris = new ObservableCollection<debrisDataStructure>(DataStructureParseHelpers.GetdebrisDataStructureListFromXMLNodeNamedChildren(ParentDataFile, DataNode, "debris", out exists));
                            _debris.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndebrisChanged);
                            SetPropertyExists("debris", exists);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("debris");
        }

        //Only called by collections editor, so we use the data file that is open right now.
        public debrisInfoDataStructure() : base(null, null)
        {
            _debris = new ObservableCollection<debrisDataStructure>();

            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public debrisInfoDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _debris = new ObservableCollection<debrisDataStructure>();
        }

        public debrisInfoDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<debrisDataStructure> indebris) : base(inParentDataFile, inDataNode)
        {
            _debris = new ObservableCollection<debrisDataStructure>(indebris);
        }

        public debrisInfoDataStructure(debrisInfoDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class debrisDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _debrisID = value;
                            SetPropertyEdited("debrisID", true);
                            ParentDataFile.SetPropertyEdited("debris", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _debrisMomentum = value;
                            SetPropertyEdited("debrisMomentum", true);
                            ParentDataFile.SetPropertyEdited("debris", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _debrisAngular = value;
                            SetPropertyEdited("debrisAngular", true);
                            ParentDataFile.SetPropertyEdited("debris", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("debrisID");

            InitProperty("debrisMomentum");
            InitProperty("debrisAngular");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public debrisDataStructure() : base(null, null)
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public debrisDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;

        }

        public debrisDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indebrisID, int indebrisMomentum, int indebrisAngular) : base(inParentDataFile, inDataNode)
        {
            _debrisID = indebrisID;

            _debrisMomentum = indebrisMomentum;
            _debrisAngular = indebrisAngular;

        }

        public debrisDataStructure(debrisDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class afterburnerDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _soundID = value;
                            SetPropertyEdited("soundID", true);
                            ParentDataFile.SetPropertyEdited("afterburner", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _tailSoundID = value;
                            SetPropertyEdited("tailSoundID", true);
                            ParentDataFile.SetPropertyEdited("afterburner", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _multiplier = value;
                            SetPropertyEdited("multiplier", true);
                            ParentDataFile.SetPropertyEdited("afterburner", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _capacity = value;
                            SetPropertyEdited("capacity", true);
                            ParentDataFile.SetPropertyEdited("afterburner", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _recharge = value;
                            SetPropertyEdited("recharge", true);
                            ParentDataFile.SetPropertyEdited("afterburner", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public afterburnerDataStructure() : base(null, null)
        {
            _soundID = "";
            _tailSoundID = "";

            _multiplier = 0;
            _capacity = 0;
            _recharge = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public afterburnerDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _soundID = "";
            _tailSoundID = "";

            _multiplier = 0;
            _capacity = 0;
            _recharge = 0;

        }

        public afterburnerDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string insoundID, string intailSoundID, float inmultiplier, float incapacity, float inrecharge) : base(inParentDataFile, inDataNode)
        {
            _soundID = insoundID;
            _tailSoundID = intailSoundID;

            _multiplier = inmultiplier;
            _capacity = incapacity;
            _recharge = inrecharge;

        }

        public afterburnerDataStructure(afterburnerDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class targetPriorityListDataStructure : VD2DataStructure
    {
        ObservableCollection<string> _targetClass;

        [Description("targetClass is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> targetClass
        {
            get
            {
                return _targetClass;
            }
            set
            {
                _targetClass = value;
            }
        }

        public void OntargetClassChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("targetClass", true);
                        ParentDataFile.SetPropertyEdited("targetPriorityList", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _targetClass = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "targetClass", out exists));
                            _targetClass.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OntargetClassChanged);
                            SetPropertyExists("targetClass", exists);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("targetClass");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public targetPriorityListDataStructure() : base(null, null)
        {
            _targetClass = new ObservableCollection<string>();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public targetPriorityListDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _targetClass = new ObservableCollection<string>();

        }

        public targetPriorityListDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> intargetClass) : base(inParentDataFile, inDataNode)
        {
            _targetClass = new ObservableCollection<string>(intargetClass);

        }

        public targetPriorityListDataStructure(targetPriorityListDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class upgradesDataStructure : VD2DataStructure
    {
        ObservableCollection<string> _upgradeID;

        int _primaryUpgradeCapacity;
        int _activeUpgradeCapacity;

        [Description("upgradeID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> upgradeID
        {
            get
            {
                return _upgradeID;
            }
            set
            {
                _upgradeID = value;
            }
        }

        public void OnupgradeIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("upgradeID", true);
                        ParentDataFile.SetPropertyEdited("upgrades", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _upgradeID = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "upgradeID", out exists));
                            _upgradeID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnupgradeIDChanged);
                            SetPropertyExists("upgradeID", exists);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _primaryUpgradeCapacity = value;
                            SetPropertyEdited("primaryUpgradeCapacity", true);
                            ParentDataFile.SetPropertyEdited("upgrades", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _activeUpgradeCapacity = value;
                            SetPropertyEdited("activeUpgradeCapacity", true);
                            ParentDataFile.SetPropertyEdited("upgrades", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("upgradeID");

            InitProperty("primaryUpgradeCapacity");
            InitProperty("activeUpgradeCapacity");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public upgradesDataStructure() : base(null, null)
        {
            _upgradeID = new ObservableCollection<string>();

            _primaryUpgradeCapacity = 0;
            _activeUpgradeCapacity = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public upgradesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _upgradeID = new ObservableCollection<string>();

            _primaryUpgradeCapacity = 0;
            _activeUpgradeCapacity = 0;

        }

        public upgradesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> inupgradeID, int inprimaryUpgradeCapacity, int inactiveUpgradeCapacity) : base(inParentDataFile, inDataNode)
        {
            _upgradeID = new ObservableCollection<string>(inupgradeID);

            _primaryUpgradeCapacity = inprimaryUpgradeCapacity;
            _activeUpgradeCapacity = inactiveUpgradeCapacity;

        }

        public upgradesDataStructure(upgradesDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class propulsionDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _propulsionEffectID = value;
                            SetPropertyEdited("propulsionEffectID", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _direction = value;
                            SetPropertyEdited("direction", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bPlayerShipOnly = value;
                            SetPropertyEdited("bPlayerShipOnly", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public propulsionDataStructure() : base(null, null)
        {
            _propulsionEffectID = "";
            _direction = "";

            _pitch = 0;
            _yaw = 0;

            _bPlayerShipOnly = false;

            _position = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public propulsionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _propulsionEffectID = "";
            _direction = "";

            _pitch = 0;
            _yaw = 0;

            _bPlayerShipOnly = false;

            _position = new Vector3D();

        }

        public propulsionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inpropulsionEffectID, string indirection, float inpitch, float inyaw, bool inbPlayerShipOnly, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _propulsionEffectID = inpropulsionEffectID;
            _direction = indirection;

            _pitch = inpitch;
            _yaw = inyaw;

            _bPlayerShipOnly = inbPlayerShipOnly;

            _position = inposition;

        }

        public propulsionDataStructure(propulsionDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class weaponDataStructure : VD2DataStructure
    {
        string _weaponType;
        string _hardpointID;
        string _weaponFire;

        float _barrelDelay;
        float _yaw;
        float _pitch;

        ObservableCollection<Vector3D> _weaponPosition;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _weaponType = value;
                            SetPropertyEdited("weaponType", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _hardpointID = value;
                            SetPropertyEdited("hardpointID", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _weaponFire = value;
                            SetPropertyEdited("weaponFire", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _barrelDelay = value;
                            SetPropertyEdited("barrelDelay", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
                    }
                }
            }
        }


        [Description("weaponPosition is a collection of 3D vectors"), Category("3D Vector Collections")]
        public ObservableCollection<Vector3D> weaponPosition
        {
            get
            {
                return _weaponPosition;
            }
            set
            {
                _weaponPosition = value;
            }
        }

        public void OnweaponPositionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("weaponPosition", true);
                        ParentDataFile.SetPropertyEdited("weapon", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _weaponPosition = new ObservableCollection<Vector3D>(ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(DataNode, "weaponPosition", out exists));
                            _weaponPosition.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnweaponPositionChanged);
                            SetPropertyExists("weaponPosition", exists);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public weaponDataStructure() : base(null, null)
        {
            _weaponType = "";
            _hardpointID = "";
            _weaponFire = "";

            _barrelDelay = 0;
            _yaw = 0;
            _pitch = 0;

            _weaponPosition = new ObservableCollection<Vector3D>();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public weaponDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _weaponType = "";
            _hardpointID = "";
            _weaponFire = "";

            _barrelDelay = 0;
            _yaw = 0;
            _pitch = 0;

            _weaponPosition = new ObservableCollection<Vector3D>();

        }

        public weaponDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inweaponType, string inhardpointID, string inweaponFire, float inbarrelDelay, float inyaw, float inpitch, List<Vector3D> inweaponPosition) : base(inParentDataFile, inDataNode)
        {
            _weaponType = inweaponType;
            _hardpointID = inhardpointID;
            _weaponFire = inweaponFire;

            _barrelDelay = inbarrelDelay;
            _yaw = inyaw;
            _pitch = inpitch;

            _weaponPosition = new ObservableCollection<Vector3D>(inweaponPosition);

        }

        public weaponDataStructure(weaponDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class damageDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _damageEffectID = value;
                            SetPropertyEdited("damageEffectID", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _roll = value;
                            SetPropertyEdited("roll", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _healthPoint = value;
                            SetPropertyEdited("healthPoint", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public damageDataStructure() : base(null, null)
        {
            _damageEffectID = "";

            _pitch = 0;
            _roll = 0;
            _yaw = 0;
            _healthPoint = 0;

            _position = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public damageDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _damageEffectID = "";

            _pitch = 0;
            _roll = 0;
            _yaw = 0;
            _healthPoint = 0;

            _position = new Vector3D();

        }

        public damageDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indamageEffectID, float inpitch, float inroll, float inyaw, float inhealthPoint, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _damageEffectID = indamageEffectID;

            _pitch = inpitch;
            _roll = inroll;
            _yaw = inyaw;
            _healthPoint = inhealthPoint;

            _position = inposition;

        }

        public damageDataStructure(damageDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class turretDataStructure : VD2DataStructure
    {
        string _turretID;
        string _turretOrientation;
        string _weaponFire;

        ObservableCollection<string> _turretRole;

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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _turretID = value;
                            SetPropertyEdited("turretID", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _turretOrientation = value;
                            SetPropertyEdited("turretOrientation", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _weaponFire = value;
                            SetPropertyEdited("weaponFire", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
            }
        }


        [Description("turretRole is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> turretRole
        {
            get
            {
                return _turretRole;
            }
            set
            {
                _turretRole = value;
            }
        }

        public void OnturretRoleChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("turretRole", true);
                        ParentDataFile.SetPropertyEdited("turret", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _turretRole = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "turretRole", out exists));
                            _turretRole.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretRoleChanged);
                            SetPropertyExists("turretRole", exists);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yawPermitted = value;
                            SetPropertyEdited("yawPermitted", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _weaponPositionID = value;
                            SetPropertyEdited("weaponPositionID", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitchLower = value;
                            SetPropertyEdited("pitchLower", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _roll = value;
                            SetPropertyEdited("roll", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bShowInCockpit = value;
                            SetPropertyEdited("bShowInCockpit", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bHideInHangar = value;
                            SetPropertyEdited("bHideInHangar", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public turretDataStructure() : base(null, null)
        {
            _turretID = "";
            _turretOrientation = "";
            _weaponFire = "";

            _turretRole = new ObservableCollection<string>();

            _yawPermitted = 0;
            _weaponPositionID = 0;

            _pitchLower = 0;
            _roll = 0;
            _yaw = 0;

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public turretDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _turretID = "";
            _turretOrientation = "";
            _weaponFire = "";

            _turretRole = new ObservableCollection<string>();

            _yawPermitted = 0;
            _weaponPositionID = 0;

            _pitchLower = 0;
            _roll = 0;
            _yaw = 0;

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();

        }

        public turretDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inturretID, string inturretOrientation, string inweaponFire, List<string> inturretRole, int inyawPermitted, int inweaponPositionID, float inpitchLower, float inroll, float inyaw, bool inbShowInCockpit, bool inbHideInHangar, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _turretID = inturretID;
            _turretOrientation = inturretOrientation;
            _weaponFire = inweaponFire;

            _turretRole = new ObservableCollection<string>(inturretRole);

            _yawPermitted = inyawPermitted;
            _weaponPositionID = inweaponPositionID;

            _pitchLower = inpitchLower;
            _roll = inroll;
            _yaw = inyaw;

            _bShowInCockpit = inbShowInCockpit;
            _bHideInHangar = inbHideInHangar;

            _position = inposition;

        }

        public turretDataStructure(turretDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class attachmentDataStructure : VD2DataStructure
    {
        string _attachmentOrientation;

        ObservableCollection<string> _attachmentID;

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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _attachmentOrientation = value;
                            SetPropertyEdited("attachmentOrientation", true);
                            ParentDataFile.SetPropertyEdited("attachment", true);
                        }
                    }
                }
            }
        }


        [Description("attachmentID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> attachmentID
        {
            get
            {
                return _attachmentID;
            }
            set
            {
                _attachmentID = value;
            }
        }

        public void OnattachmentIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("attachmentID", true);
                        ParentDataFile.SetPropertyEdited("attachment", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _attachmentID = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "attachmentID", out exists));
                            _attachmentID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnattachmentIDChanged);
                            SetPropertyExists("attachmentID", exists);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _attachmentPosition = value;
                            SetPropertyEdited("attachmentPosition", true);
                            ParentDataFile.SetPropertyEdited("attachment", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("attachmentOrientation");

            InitProperty("attachmentID");

            InitProperty("attachmentPosition");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public attachmentDataStructure() : base(null, null)
        {
            _attachmentOrientation = "";

            _attachmentID = new ObservableCollection<string>();

            _attachmentPosition = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public attachmentDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _attachmentOrientation = "";

            _attachmentID = new ObservableCollection<string>();

            _attachmentPosition = new Vector3D();

        }

        public attachmentDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inattachmentOrientation, List<string> inattachmentID, Vector3D inattachmentPosition) : base(inParentDataFile, inDataNode)
        {
            _attachmentOrientation = inattachmentOrientation;

            _attachmentID = new ObservableCollection<string>(inattachmentID);

            _attachmentPosition = inattachmentPosition;

        }

        public attachmentDataStructure(attachmentDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class movingElementDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _boneName = value;
                            SetPropertyEdited("boneName", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _roll = value;
                            SetPropertyEdited("roll", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _speedMultiplier = value;
                            SetPropertyEdited("speedMultiplier", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bLinkedToWeapon = value;
                            SetPropertyEdited("bLinkedToWeapon", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bCombat = value;
                            SetPropertyEdited("bCombat", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _translateAmount = value;
                            SetPropertyEdited("translateAmount", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public movingElementDataStructure() : base(null, null)
        {
            _boneName = "";

            _yaw = 0;
            _pitch = 0;
            _roll = 0;
            _speedMultiplier = 0;

            _bLinkedToWeapon = false;
            _bCombat = false;

            _translateAmount = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public movingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
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

        public movingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inboneName, float inyaw, float inpitch, float inroll, float inspeedMultiplier, bool inbLinkedToWeapon, bool inbCombat, Vector3D intranslateAmount) : base(inParentDataFile, inDataNode)
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

        public movingElementDataStructure(movingElementDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class dockDataStructure : VD2DataStructure
    {
        string _dockType;
        string _ejectOrientation;
        string _orientation;
        string _attachedID;
        string _boneName;
        string _dockOrientation;
        string _resourceOnly;

        ObservableCollection<string> _objectID;

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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockType = value;
                            SetPropertyEdited("dockType", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _ejectOrientation = value;
                            SetPropertyEdited("ejectOrientation", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _orientation = value;
                            SetPropertyEdited("orientation", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _attachedID = value;
                            SetPropertyEdited("attachedID", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _boneName = value;
                            SetPropertyEdited("boneName", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockOrientation = value;
                            SetPropertyEdited("dockOrientation", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _resourceOnly = value;
                            SetPropertyEdited("resourceOnly", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
            }
        }


        [Description("objectID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> objectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                _objectID = value;
            }
        }

        public void OnobjectIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("objectID", true);
                        ParentDataFile.SetPropertyEdited("dock", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _objectID = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "objectID", out exists));
                            _objectID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnobjectIDChanged);
                            SetPropertyExists("objectID", exists);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _ejectVelocity = value;
                            SetPropertyEdited("ejectVelocity", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockRollOffset = value;
                            SetPropertyEdited("dockRollOffset", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockYawOffset = value;
                            SetPropertyEdited("dockYawOffset", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bCanAcceptRawResource = value;
                            SetPropertyEdited("bCanAcceptRawResource", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bInvisible = value;
                            SetPropertyEdited("bInvisible", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public dockDataStructure() : base(null, null)
        {
            _dockType = "";
            _ejectOrientation = "";
            _orientation = "";
            _attachedID = "";
            _boneName = "";
            _dockOrientation = "";
            _resourceOnly = "";

            _objectID = new ObservableCollection<string>();

            _ejectVelocity = 0;
            _dockRollOffset = 0;
            _dockYawOffset = 0;

            _bCanAcceptRawResource = false;
            _bInvisible = false;

            _position = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public dockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _dockType = "";
            _ejectOrientation = "";
            _orientation = "";
            _attachedID = "";
            _boneName = "";
            _dockOrientation = "";
            _resourceOnly = "";

            _objectID = new ObservableCollection<string>();

            _ejectVelocity = 0;
            _dockRollOffset = 0;
            _dockYawOffset = 0;

            _bCanAcceptRawResource = false;
            _bInvisible = false;

            _position = new Vector3D();

        }

        public dockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indockType, string inejectOrientation, string inorientation, string inattachedID, string inboneName, string indockOrientation, string inresourceOnly, List<string> inobjectID, int inejectVelocity, int indockRollOffset, int indockYawOffset, bool inbCanAcceptRawResource, bool inbInvisible, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _dockType = indockType;
            _ejectOrientation = inejectOrientation;
            _orientation = inorientation;
            _attachedID = inattachedID;
            _boneName = inboneName;
            _dockOrientation = indockOrientation;
            _resourceOnly = inresourceOnly;

            _objectID = new ObservableCollection<string>(inobjectID);

            _ejectVelocity = inejectVelocity;
            _dockRollOffset = indockRollOffset;
            _dockYawOffset = indockYawOffset;

            _bCanAcceptRawResource = inbCanAcceptRawResource;
            _bInvisible = inbInvisible;

            _position = inposition;

        }

        public dockDataStructure(dockDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class shieldDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _shieldID = value;
                            SetPropertyEdited("shieldID", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _shieldOrientation = value;
                            SetPropertyEdited("shieldOrientation", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _roll = value;
                            SetPropertyEdited("roll", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _shieldPosition = value;
                            SetPropertyEdited("shieldPosition", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public shieldDataStructure() : base(null, null)
        {
            _shieldID = "";
            _shieldOrientation = "";

            _pitch = 0;
            _roll = 0;

            _shieldPosition = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public shieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _shieldID = "";
            _shieldOrientation = "";

            _pitch = 0;
            _roll = 0;

            _shieldPosition = new Vector3D();

        }

        public shieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inshieldID, string inshieldOrientation, int inpitch, int inroll, Vector3D inshieldPosition) : base(inParentDataFile, inDataNode)
        {
            _shieldID = inshieldID;
            _shieldOrientation = inshieldOrientation;

            _pitch = inpitch;
            _roll = inroll;

            _shieldPosition = inshieldPosition;

        }

        public shieldDataStructure(shieldDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class rotatingElementDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _boneName = value;
                            SetPropertyEdited("boneName", true);
                            ParentDataFile.SetPropertyEdited("rotatingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _rollSpeed = value;
                            SetPropertyEdited("rollSpeed", true);
                            ParentDataFile.SetPropertyEdited("rotatingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bLinkedToWeapon = value;
                            SetPropertyEdited("bLinkedToWeapon", true);
                            ParentDataFile.SetPropertyEdited("rotatingElement", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("boneName");

            InitProperty("rollSpeed");

            InitProperty("bLinkedToWeapon");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public rotatingElementDataStructure() : base(null, null)
        {
            _boneName = "";

            _rollSpeed = 0;

            _bLinkedToWeapon = false;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public rotatingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _boneName = "";

            _rollSpeed = 0;

            _bLinkedToWeapon = false;

        }

        public rotatingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inboneName, int inrollSpeed, bool inbLinkedToWeapon) : base(inParentDataFile, inDataNode)
        {
            _boneName = inboneName;

            _rollSpeed = inrollSpeed;

            _bLinkedToWeapon = inbLinkedToWeapon;

        }

        public rotatingElementDataStructure(rotatingElementDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class recoilDataStructure : VD2DataStructure
    {
        string _recoilBone;
        string _muzzleBoneName;
        string _recoilParentType;

        ObservableCollection<string> _muzzleBone;

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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _recoilBone = value;
                            SetPropertyEdited("recoilBone", true);
                            ParentDataFile.SetPropertyEdited("recoil", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _muzzleBoneName = value;
                            SetPropertyEdited("muzzleBoneName", true);
                            ParentDataFile.SetPropertyEdited("recoil", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _recoilParentType = value;
                            SetPropertyEdited("recoilParentType", true);
                            ParentDataFile.SetPropertyEdited("recoil", true);
                        }
                    }
                }
            }
        }


        [Description("muzzleBone is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> muzzleBone
        {
            get
            {
                return _muzzleBone;
            }
            set
            {
                _muzzleBone = value;
            }
        }

        public void OnmuzzleBoneChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("muzzleBone", true);
                        ParentDataFile.SetPropertyEdited("recoil", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _muzzleBone = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "muzzleBone", out exists));
                            _muzzleBone.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnmuzzleBoneChanged);
                            SetPropertyExists("muzzleBone", exists);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _recoilZ = value;
                            SetPropertyEdited("recoilZ", true);
                            ParentDataFile.SetPropertyEdited("recoil", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _recoilTime = value;
                            SetPropertyEdited("recoilTime", true);
                            ParentDataFile.SetPropertyEdited("recoil", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public recoilDataStructure() : base(null, null)
        {
            _recoilBone = "";
            _muzzleBoneName = "";
            _recoilParentType = "";

            _muzzleBone = new ObservableCollection<string>();

            _recoilZ = 0;
            _recoilTime = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public recoilDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _recoilBone = "";
            _muzzleBoneName = "";
            _recoilParentType = "";

            _muzzleBone = new ObservableCollection<string>();

            _recoilZ = 0;
            _recoilTime = 0;

        }

        public recoilDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inrecoilBone, string inmuzzleBoneName, string inrecoilParentType, List<string> inmuzzleBone, float inrecoilZ, float inrecoilTime) : base(inParentDataFile, inDataNode)
        {
            _recoilBone = inrecoilBone;
            _muzzleBoneName = inmuzzleBoneName;
            _recoilParentType = inrecoilParentType;

            _muzzleBone = new ObservableCollection<string>(inmuzzleBone);

            _recoilZ = inrecoilZ;
            _recoilTime = inrecoilTime;

        }

        public recoilDataStructure(recoilDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class rotateBonesDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _rotateBone = value;
                            SetPropertyEdited("rotateBone", true);
                            ParentDataFile.SetPropertyEdited("rotateBones", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("rotateBone");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public rotateBonesDataStructure() : base(null, null)
        {
            _rotateBone = "";


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public rotateBonesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _rotateBone = "";

        }

        public rotateBonesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inrotateBone) : base(inParentDataFile, inDataNode)
        {
            _rotateBone = inrotateBone;

        }

        public rotateBonesDataStructure(rotateBonesDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class canisterDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _projectileID = value;
                            SetPropertyEdited("projectileID", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _canisterCount = value;
                            SetPropertyEdited("canisterCount", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _blowBackCanisterCount = value;
                            SetPropertyEdited("blowBackCanisterCount", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yawRange = value;
                            SetPropertyEdited("yawRange", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitchRange = value;
                            SetPropertyEdited("pitchRange", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _rollRange = value;
                            SetPropertyEdited("rollRange", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _speedAddBase = value;
                            SetPropertyEdited("speedAddBase", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _speedAddRandom = value;
                            SetPropertyEdited("speedAddRandom", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bCanisterAimAssist = value;
                            SetPropertyEdited("bCanisterAimAssist", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bAddToRangeCalculations = value;
                            SetPropertyEdited("bAddToRangeCalculations", true);
                            ParentDataFile.SetPropertyEdited("canister", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public canisterDataStructure() : base(null, null)
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


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public canisterDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
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

        public canisterDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inprojectileID, int incanisterCount, int inblowBackCanisterCount, int inyawRange, int inpitchRange, int inrollRange, int inspeedAddBase, int inspeedAddRandom, bool inbCanisterAimAssist, bool inbAddToRangeCalculations) : base(inParentDataFile, inDataNode)
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

        public canisterDataStructure(canisterDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class launchTubeDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _direction = value;
                            SetPropertyEdited("direction", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _launchDeckBeg = value;
                            SetPropertyEdited("launchDeckBeg", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _launchDeckEnd = value;
                            SetPropertyEdited("launchDeckEnd", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockPosition = value;
                            SetPropertyEdited("dockPosition", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockSize = value;
                            SetPropertyEdited("dockSize", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public launchTubeDataStructure() : base(null, null)
        {
            _direction = "";

            _launchDeckBeg = new Vector3D();
            _launchDeckEnd = new Vector3D();
            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public launchTubeDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _direction = "";

            _launchDeckBeg = new Vector3D();
            _launchDeckEnd = new Vector3D();
            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();

        }

        public launchTubeDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indirection, Vector3D inlaunchDeckBeg, Vector3D inlaunchDeckEnd, Vector3D indockPosition, Vector3D indockSize) : base(inParentDataFile, inDataNode)
        {
            _direction = indirection;

            _launchDeckBeg = inlaunchDeckBeg;
            _launchDeckEnd = inlaunchDeckEnd;
            _dockPosition = indockPosition;
            _dockSize = indockSize;

        }

        public launchTubeDataStructure(launchTubeDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class mirvDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _mirvObjectID = value;
                            SetPropertyEdited("mirvObjectID", true);
                            ParentDataFile.SetPropertyEdited("mirv", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _mirvCount = value;
                            SetPropertyEdited("mirvCount", true);
                            ParentDataFile.SetPropertyEdited("mirv", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _bNoExplodeOnMirv = value;
                            SetPropertyEdited("bNoExplodeOnMirv", true);
                            ParentDataFile.SetPropertyEdited("mirv", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("mirvObjectID");

            InitProperty("mirvCount");

            InitProperty("bNoExplodeOnMirv");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public mirvDataStructure() : base(null, null)
        {
            _mirvObjectID = "";

            _mirvCount = 0;

            _bNoExplodeOnMirv = false;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public mirvDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _mirvObjectID = "";

            _mirvCount = 0;

            _bNoExplodeOnMirv = false;

        }

        public mirvDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inmirvObjectID, int inmirvCount, bool inbNoExplodeOnMirv) : base(inParentDataFile, inDataNode)
        {
            _mirvObjectID = inmirvObjectID;

            _mirvCount = inmirvCount;

            _bNoExplodeOnMirv = inbNoExplodeOnMirv;

        }

        public mirvDataStructure(mirvDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class weaponDirectionDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _mainDirection = value;
                            SetPropertyEdited("mainDirection", true);
                            ParentDataFile.SetPropertyEdited("weaponDirection", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yaw = value;
                            SetPropertyEdited("yaw", true);
                            ParentDataFile.SetPropertyEdited("weaponDirection", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitch = value;
                            SetPropertyEdited("pitch", true);
                            ParentDataFile.SetPropertyEdited("weaponDirection", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _roll = value;
                            SetPropertyEdited("roll", true);
                            ParentDataFile.SetPropertyEdited("weaponDirection", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("mainDirection");

            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public weaponDirectionDataStructure() : base(null, null)
        {
            _mainDirection = "";

            _yaw = 0;
            _pitch = 0;
            _roll = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public weaponDirectionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _mainDirection = "";

            _yaw = 0;
            _pitch = 0;
            _roll = 0;

        }

        public weaponDirectionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inmainDirection, float inyaw, float inpitch, float inroll) : base(inParentDataFile, inDataNode)
        {
            _mainDirection = inmainDirection;

            _yaw = inyaw;
            _pitch = inpitch;
            _roll = inroll;

        }

        public weaponDirectionDataStructure(weaponDirectionDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class turretBarrelDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _boneName = value;
                            SetPropertyEdited("boneName", true);
                            ParentDataFile.SetPropertyEdited("turretBarrel", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _weaponPosition = value;
                            SetPropertyEdited("weaponPosition", true);
                            ParentDataFile.SetPropertyEdited("turretBarrel", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("boneName");

            InitProperty("weaponPosition");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public turretBarrelDataStructure() : base(null, null)
        {
            _boneName = "";

            _weaponPosition = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public turretBarrelDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _boneName = "";

            _weaponPosition = new Vector3D();

        }

        public turretBarrelDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inboneName, Vector3D inweaponPosition) : base(inParentDataFile, inDataNode)
        {
            _boneName = inboneName;

            _weaponPosition = inweaponPosition;

        }

        public turretBarrelDataStructure(turretBarrelDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class deathSpawnDataStructure : VD2DataStructure
    {
        ObservableCollection<string> _asteroidID;

        [Description("asteroidID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> asteroidID
        {
            get
            {
                return _asteroidID;
            }
            set
            {
                _asteroidID = value;
            }
        }

        public void OnasteroidIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("asteroidID", true);
                        ParentDataFile.SetPropertyEdited("deathSpawn", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _asteroidID = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "asteroidID", out exists));
                            _asteroidID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnasteroidIDChanged);
                            SetPropertyExists("asteroidID", exists);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("asteroidID");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public deathSpawnDataStructure() : base(null, null)
        {
            _asteroidID = new ObservableCollection<string>();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public deathSpawnDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = new ObservableCollection<string>();

        }

        public deathSpawnDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> inasteroidID) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = new ObservableCollection<string>(inasteroidID);

        }

        public deathSpawnDataStructure(deathSpawnDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class babyDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _asteroidID = value;
                            SetPropertyEdited("asteroidID", true);
                            ParentDataFile.SetPropertyEdited("baby", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _lifeTimer = value;
                            SetPropertyEdited("lifeTimer", true);
                            ParentDataFile.SetPropertyEdited("baby", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _linearVelocity = value;
                            SetPropertyEdited("linearVelocity", true);
                            ParentDataFile.SetPropertyEdited("baby", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("asteroidID");

            InitProperty("lifeTimer");

            InitProperty("linearVelocity");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public babyDataStructure() : base(null, null)
        {
            _asteroidID = "";

            _lifeTimer = 0;

            _linearVelocity = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public babyDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = "";

            _lifeTimer = 0;

            _linearVelocity = new Vector3D();

        }

        public babyDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inasteroidID, float inlifeTimer, Vector3D inlinearVelocity) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = inasteroidID;

            _lifeTimer = inlifeTimer;

            _linearVelocity = inlinearVelocity;

        }

        public babyDataStructure(babyDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class largeDockDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _rollRotation = value;
                            SetPropertyEdited("rollRotation", true);
                            ParentDataFile.SetPropertyEdited("largeDock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockPosition = value;
                            SetPropertyEdited("dockPosition", true);
                            ParentDataFile.SetPropertyEdited("largeDock", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _dockSize = value;
                            SetPropertyEdited("dockSize", true);
                            ParentDataFile.SetPropertyEdited("largeDock", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("rollRotation");

            InitProperty("dockPosition");
            InitProperty("dockSize");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public largeDockDataStructure() : base(null, null)
        {
            _rollRotation = 0;

            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public largeDockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _rollRotation = 0;

            _dockPosition = new Vector3D();
            _dockSize = new Vector3D();

        }

        public largeDockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, int inrollRotation, Vector3D indockPosition, Vector3D indockSize) : base(inParentDataFile, inDataNode)
        {
            _rollRotation = inrollRotation;

            _dockPosition = indockPosition;
            _dockSize = indockSize;

        }

        public largeDockDataStructure(largeDockDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class physicalRotatingElementDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _meshName = value;
                            SetPropertyEdited("meshName", true);
                            ParentDataFile.SetPropertyEdited("physicalRotatingElement", true);
                        }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _collisionShape = value;
                            SetPropertyEdited("collisionShape", true);
                            ParentDataFile.SetPropertyEdited("physicalRotatingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _rollSpeed = value;
                            SetPropertyEdited("rollSpeed", true);
                            ParentDataFile.SetPropertyEdited("physicalRotatingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _yawSpeed = value;
                            SetPropertyEdited("yawSpeed", true);
                            ParentDataFile.SetPropertyEdited("physicalRotatingElement", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _pitchSpeed = value;
                            SetPropertyEdited("pitchSpeed", true);
                            ParentDataFile.SetPropertyEdited("physicalRotatingElement", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public physicalRotatingElementDataStructure() : base(null, null)
        {
            _meshName = "";
            _collisionShape = "";

            _rollSpeed = 0;
            _yawSpeed = 0;
            _pitchSpeed = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public physicalRotatingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _meshName = "";
            _collisionShape = "";

            _rollSpeed = 0;
            _yawSpeed = 0;
            _pitchSpeed = 0;

        }

        public physicalRotatingElementDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inmeshName, string incollisionShape, int inrollSpeed, int inyawSpeed, int inpitchSpeed) : base(inParentDataFile, inDataNode)
        {
            _meshName = inmeshName;
            _collisionShape = incollisionShape;

            _rollSpeed = inrollSpeed;
            _yawSpeed = inyawSpeed;
            _pitchSpeed = inpitchSpeed;

        }

        public physicalRotatingElementDataStructure(physicalRotatingElementDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class alwaysOnEffectDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _effectID = value;
                            SetPropertyEdited("effectID", true);
                            ParentDataFile.SetPropertyEdited("alwaysOnEffect", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("alwaysOnEffect", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("effectID");

            InitProperty("position");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public alwaysOnEffectDataStructure() : base(null, null)
        {
            _effectID = "";

            _position = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public alwaysOnEffectDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _effectID = "";

            _position = new Vector3D();

        }

        public alwaysOnEffectDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string ineffectID, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _effectID = ineffectID;

            _position = inposition;

        }

        public alwaysOnEffectDataStructure(alwaysOnEffectDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class cargoBayDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _cargoBayType = value;
                            SetPropertyEdited("cargoBayType", true);
                            ParentDataFile.SetPropertyEdited("cargoBay", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _maxAmount = value;
                            SetPropertyEdited("maxAmount", true);
                            ParentDataFile.SetPropertyEdited("cargoBay", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("cargoBayType");

            InitProperty("maxAmount");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public cargoBayDataStructure() : base(null, null)
        {
            _cargoBayType = "";

            _maxAmount = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public cargoBayDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _cargoBayType = "";

            _maxAmount = 0;

        }

        public cargoBayDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string incargoBayType, int inmaxAmount) : base(inParentDataFile, inDataNode)
        {
            _cargoBayType = incargoBayType;

            _maxAmount = inmaxAmount;

        }

        public cargoBayDataStructure(cargoBayDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class gateCollisionDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _gateCollisionSize = value;
                            SetPropertyEdited("gateCollisionSize", true);
                            ParentDataFile.SetPropertyEdited("gateCollision", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("gateCollisionSize");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public gateCollisionDataStructure() : base(null, null)
        {
            _gateCollisionSize = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public gateCollisionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _gateCollisionSize = new Vector3D();

        }

        public gateCollisionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, Vector3D ingateCollisionSize) : base(inParentDataFile, inDataNode)
        {
            _gateCollisionSize = ingateCollisionSize;

        }

        public gateCollisionDataStructure(gateCollisionDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class refuelAreaDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _refuelParticleSystem = value;
                            SetPropertyEdited("refuelParticleSystem", true);
                            ParentDataFile.SetPropertyEdited("refuelArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _refuelPosition = value;
                            SetPropertyEdited("refuelPosition", true);
                            ParentDataFile.SetPropertyEdited("refuelArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _refuelSize = value;
                            SetPropertyEdited("refuelSize", true);
                            ParentDataFile.SetPropertyEdited("refuelArea", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("refuelParticleSystem");

            InitProperty("refuelPosition");
            InitProperty("refuelSize");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public refuelAreaDataStructure() : base(null, null)
        {
            _refuelParticleSystem = "";

            _refuelPosition = new Vector3D();
            _refuelSize = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public refuelAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _refuelParticleSystem = "";

            _refuelPosition = new Vector3D();
            _refuelSize = new Vector3D();

        }

        public refuelAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inrefuelParticleSystem, Vector3D inrefuelPosition, Vector3D inrefuelSize) : base(inParentDataFile, inDataNode)
        {
            _refuelParticleSystem = inrefuelParticleSystem;

            _refuelPosition = inrefuelPosition;
            _refuelSize = inrefuelSize;

        }

        public refuelAreaDataStructure(refuelAreaDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class repairAreaDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _repairParticleSystem = value;
                            SetPropertyEdited("repairParticleSystem", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _repairSoundID = value;
                            SetPropertyEdited("repairSoundID", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _maxRepairClass = value;
                            SetPropertyEdited("maxRepairClass", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _repairPosition = value;
                            SetPropertyEdited("repairPosition", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _repairSize = value;
                            SetPropertyEdited("repairSize", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
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

        //Only called by collections editor, so we use the data file that is open right now.
        public repairAreaDataStructure() : base(null, null)
        {
            _repairParticleSystem = "";
            _repairSoundID = "";
            _maxRepairClass = "";

            _repairPosition = new Vector3D();
            _repairSize = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public repairAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _repairParticleSystem = "";
            _repairSoundID = "";
            _maxRepairClass = "";

            _repairPosition = new Vector3D();
            _repairSize = new Vector3D();

        }

        public repairAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inrepairParticleSystem, string inrepairSoundID, string inmaxRepairClass, Vector3D inrepairPosition, Vector3D inrepairSize) : base(inParentDataFile, inDataNode)
        {
            _repairParticleSystem = inrepairParticleSystem;
            _repairSoundID = inrepairSoundID;
            _maxRepairClass = inmaxRepairClass;

            _repairPosition = inrepairPosition;
            _repairSize = inrepairSize;

        }

        public repairAreaDataStructure(repairAreaDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class mineDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _mineID = value;
                            SetPropertyEdited("mineID", true);
                            ParentDataFile.SetPropertyEdited("mine", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _position = value;
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("mine", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _linearVelocity = value;
                            SetPropertyEdited("linearVelocity", true);
                            ParentDataFile.SetPropertyEdited("mine", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("mineID");

            InitProperty("position");
            InitProperty("linearVelocity");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public mineDataStructure() : base(null, null)
        {
            _mineID = "";

            _position = new Vector3D();
            _linearVelocity = new Vector3D();


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public mineDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _mineID = "";

            _position = new Vector3D();
            _linearVelocity = new Vector3D();

        }

        public mineDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inmineID, Vector3D inposition, Vector3D inlinearVelocity) : base(inParentDataFile, inDataNode)
        {
            _mineID = inmineID;

            _position = inposition;
            _linearVelocity = inlinearVelocity;

        }

        public mineDataStructure(mineDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
    public class damageCollisionFieldDataStructure : VD2DataStructure
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _damage = value;
                            SetPropertyEdited("damage", true);
                            ParentDataFile.SetPropertyEdited("damageCollisionField", true);
                        }
                    }
                }
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
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _scale = value;
                            SetPropertyEdited("scale", true);
                            ParentDataFile.SetPropertyEdited("damageCollisionField", true);
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("damage");
            InitProperty("scale");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public damageCollisionFieldDataStructure() : base(null, null)
        {
            _damage = 0;
            _scale = 0;


            if (EditorUI.UI.EditorForm.DataFileProperties.SelectedObject is VD2Data)
            {
                ParentDataFile = (VD2Data)EditorUI.UI.EditorForm.DataFileProperties.SelectedObject;
            }
        }

        public damageCollisionFieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _damage = 0;
            _scale = 0;

        }

        public damageCollisionFieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, int indamage, int inscale) : base(inParentDataFile, inDataNode)
        {
            _damage = indamage;
            _scale = inscale;

        }

        public damageCollisionFieldDataStructure(damageCollisionFieldDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
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
