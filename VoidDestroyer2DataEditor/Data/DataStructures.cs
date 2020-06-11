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
    public class debrisInfoDataStructure : VD2DataStructure
    {
        ObservableCollection<VD2DataStructure> _debris;

        [Description("debris is a collection of datastructures"), Category("Data Structure Collection")]
        public ObservableCollection<VD2DataStructure> debris
        {
            get
            {
                return _debris;
            }
            set
            {
                if (_debris != null)
                {
                    _debris.CollectionChanged -= OndebrisChanged;
                }
                _debris = value;
                if (_debris != null)
                {
                    _debris.CollectionChanged += OndebrisChanged;
                }
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
                            _debris = new ObservableCollection<VD2DataStructure>(DataStructureParseHelpers.GetdebrisDataStructureListFromXMLNodeNamedChildren(ParentDataFile, DataNode, "debris", out exists));
                            _debris.CollectionChanged += OndebrisChanged;
                            SetPropertyExists("debris", exists);
                        }
                        else
                        {
                            _debris.CollectionChanged -= OndebrisChanged;
                            _debris.Clear();
                            _debris.CollectionChanged += OndebrisChanged;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("debris");
            SetPropertyIsCollection("debris", true, typeof(debrisDataStructure));
        }

        //Only called by collections editor, so we use the data file that is open right now.
        public debrisInfoDataStructure() : base(null, null)
        {
            _debris = new ObservableCollection<VD2DataStructure>();
            _debris.CollectionChanged += OndebrisChanged;
        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public debrisInfoDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _debris = new ObservableCollection<VD2DataStructure>();
            _debris.CollectionChanged += OndebrisChanged;
        }

        public debrisInfoDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<debrisDataStructure> indebris) : base(inParentDataFile, inDataNode)
        {
            _debris = new ObservableCollection<VD2DataStructure>(indebris);
        }

        public debrisInfoDataStructure(debrisInfoDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _debris = new ObservableCollection<VD2DataStructure>();
            _debris.CollectionChanged += OndebrisChanged;
            foreach (VD2DataStructure ds in inCopyFrom.debris)
            {
                VD2DataStructure dupeds = (VD2DataStructure)System.Activator.CreateInstance(ds.GetType(), ds);
                _debris.Add(dupeds);
            }
            SetPropertyExists("debris", inCopyFrom.PropertyExists("debris"));
        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            debrisInfoDataStructure original = (debrisInfoDataStructure)inOriginal;
            _debris = new ObservableCollection<VD2DataStructure>();
            _debris.CollectionChanged += OndebrisChanged;
            foreach (VD2DataStructure ds in original.debris)
            {
                VD2DataStructure dupeds = (VD2DataStructure)System.Activator.CreateInstance(ds.GetType(), ds);
                _debris.Add(dupeds);
            }
            SetPropertyExists("debris", original.PropertyExists("debris"));
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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<debrisInfo>");
            if (PropertyExists("debris"))
            {
                foreach (debrisDataStructure result in _debris)
                {
                    xmltextlines.AddRange(result.AsVD2XML(inIndent + 4));
                }
            }

            xmltextlines.Add(indent + "</debrisInfo>");
            return xmltextlines;
        }
    }

    public class debrisDataStructure : VD2DataStructure
    {
        string _debrisID;

        float _debrisMomentum;
        float _debrisAngular;

        [Description("debrisID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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


        [Description("debrisMomentum is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float debrisMomentum
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

        [Description("debrisAngular is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float debrisAngular
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
            List<string> debrisIDreftypes = new List<string>();
            debrisIDreftypes.Add("Debris");
            SetPropertyIsObjectIDRef("debrisID", true, debrisIDreftypes);

            InitProperty("debrisMomentum");
            InitProperty("debrisAngular");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public debrisDataStructure() : base(null, null)
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public debrisDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _debrisID = "";

            _debrisMomentum = 0;
            _debrisAngular = 0;

        }

        public debrisDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indebrisID, float indebrisMomentum, float indebrisAngular) : base(inParentDataFile, inDataNode)
        {
            _debrisID = indebrisID;

            _debrisMomentum = indebrisMomentum;
            _debrisAngular = indebrisAngular;

        }

        public debrisDataStructure(debrisDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _debrisID = inCopyFrom.debrisID;
            SetPropertyExists("debrisID", inCopyFrom.PropertyExists("debrisID"));

            _debrisMomentum = inCopyFrom.debrisMomentum;
            SetPropertyExists("debrisMomentum", inCopyFrom.PropertyExists("debrisMomentum"));
            _debrisAngular = inCopyFrom.debrisAngular;
            SetPropertyExists("debrisAngular", inCopyFrom.PropertyExists("debrisAngular"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            debrisDataStructure original = (debrisDataStructure)inOriginal;
            _debrisID = original.debrisID;
            SetPropertyExists("debrisID", original.PropertyExists("debrisID"));

            _debrisMomentum = original.debrisMomentum;
            SetPropertyExists("debrisMomentum", original.PropertyExists("debrisMomentum"));
            _debrisAngular = original.debrisAngular;
            SetPropertyExists("debrisAngular", original.PropertyExists("debrisAngular"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<debris>");
            if (PropertyExists("debrisID"))
            {
                xmltextlines.Add(indent + "    <debrisID attr1=\"" + _debrisID + "\"/>"); 
            }

            if (PropertyExists("debrisMomentum"))
            {
                xmltextlines.Add(indent + "    <debrisMomentum attr1=\"" + _debrisMomentum.ToString() + "\"/>"); 
            }
            if (PropertyExists("debrisAngular"))
            {
                xmltextlines.Add(indent + "    <debrisAngular attr1=\"" + _debrisAngular.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</debris>");
            return xmltextlines;
        }
    }

    public class afterburnerDataStructure : VD2DataStructure
    {
        string _soundID;
        string _tailSoundID;

        float _multiplier;
        float _capacity;
        float _recharge;

        [Description("soundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("tailSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
            List<string> soundIDreftypes = new List<string>();
            soundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("soundID", true, soundIDreftypes);
            InitProperty("tailSoundID");
            List<string> tailSoundIDreftypes = new List<string>();
            tailSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("tailSoundID", true, tailSoundIDreftypes);

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("soundID", inCopyFrom.PropertyExists("soundID"));
            _tailSoundID = inCopyFrom.tailSoundID;
            SetPropertyExists("tailSoundID", inCopyFrom.PropertyExists("tailSoundID"));

            _multiplier = inCopyFrom.multiplier;
            SetPropertyExists("multiplier", inCopyFrom.PropertyExists("multiplier"));
            _capacity = inCopyFrom.capacity;
            SetPropertyExists("capacity", inCopyFrom.PropertyExists("capacity"));
            _recharge = inCopyFrom.recharge;
            SetPropertyExists("recharge", inCopyFrom.PropertyExists("recharge"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            afterburnerDataStructure original = (afterburnerDataStructure)inOriginal;
            _soundID = original.soundID;
            SetPropertyExists("soundID", original.PropertyExists("soundID"));
            _tailSoundID = original.tailSoundID;
            SetPropertyExists("tailSoundID", original.PropertyExists("tailSoundID"));

            _multiplier = original.multiplier;
            SetPropertyExists("multiplier", original.PropertyExists("multiplier"));
            _capacity = original.capacity;
            SetPropertyExists("capacity", original.PropertyExists("capacity"));
            _recharge = original.recharge;
            SetPropertyExists("recharge", original.PropertyExists("recharge"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<afterburner>");
            if (PropertyExists("soundID"))
            {
                xmltextlines.Add(indent + "    <soundID attr1=\"" + _soundID + "\"/>"); 
            }
            if (PropertyExists("tailSoundID"))
            {
                xmltextlines.Add(indent + "    <tailSoundID attr1=\"" + _tailSoundID + "\"/>"); 
            }

            if (PropertyExists("multiplier"))
            {
                xmltextlines.Add(indent + "    <multiplier attr1=\"" + _multiplier.ToString() + "\"/>"); 
            }
            if (PropertyExists("capacity"))
            {
                xmltextlines.Add(indent + "    <capacity attr1=\"" + _capacity.ToString() + "\"/>"); 
            }
            if (PropertyExists("recharge"))
            {
                xmltextlines.Add(indent + "    <recharge attr1=\"" + _recharge.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</afterburner>");
            return xmltextlines;
        }
    }

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
                if (_targetClass != null)
                {
                    _targetClass.CollectionChanged -= OntargetClassChanged;
                }
                _targetClass = value;
                if (_targetClass != null)
                {
                    _targetClass.CollectionChanged += OntargetClassChanged;
                }
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
                            _targetClass.CollectionChanged += OntargetClassChanged;
                            SetPropertyExists("targetClass", exists);
                        }
                        else
                        {
                            _targetClass.CollectionChanged -= OntargetClassChanged;
                            _targetClass.Clear();
                            _targetClass.CollectionChanged += OntargetClassChanged;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("targetClass");
            SetPropertyIsCollection("targetClass", true, typeof(string));

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public targetPriorityListDataStructure() : base(null, null)
        {
            _targetClass = new ObservableCollection<string>();
            _targetClass.CollectionChanged += OntargetClassChanged;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public targetPriorityListDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _targetClass = new ObservableCollection<string>();
            _targetClass.CollectionChanged += OntargetClassChanged;

        }

        public targetPriorityListDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> intargetClass) : base(inParentDataFile, inDataNode)
        {
            _targetClass = new ObservableCollection<string>(intargetClass);

        }

        public targetPriorityListDataStructure(targetPriorityListDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _targetClass = new ObservableCollection<string>(inCopyFrom.targetClass);
            _targetClass.CollectionChanged += OntargetClassChanged;
            SetPropertyExists("targetClass", inCopyFrom.PropertyExists("targetClass"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            targetPriorityListDataStructure original = (targetPriorityListDataStructure)inOriginal;
            _targetClass = new ObservableCollection<string>(original.targetClass);
            _targetClass.CollectionChanged += OntargetClassChanged;
            SetPropertyExists("targetClass", original.PropertyExists("targetClass"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<targetPriorityList>");
            if (PropertyExists("targetClass"))
            {
                foreach (string result in _targetClass)
                {
                    xmltextlines.Add(indent + "    <targetClass attr1=\"" + result + "\"/>"); 
                }
            }

            xmltextlines.Add(indent + "</targetPriorityList>");
            return xmltextlines;
        }
    }

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
                if (_upgradeID != null)
                {
                    _upgradeID.CollectionChanged -= OnupgradeIDChanged;
                }
                _upgradeID = value;
                if (_upgradeID != null)
                {
                    _upgradeID.CollectionChanged += OnupgradeIDChanged;
                }
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
                            _upgradeID.CollectionChanged += OnupgradeIDChanged;
                            SetPropertyExists("upgradeID", exists);
                        }
                        else
                        {
                            _upgradeID.CollectionChanged -= OnupgradeIDChanged;
                            _upgradeID.Clear();
                            _upgradeID.CollectionChanged += OnupgradeIDChanged;
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
            List<string> upgradeIDreftypes = new List<string>();
            upgradeIDreftypes.Add("PrimaryUpgrade");
            upgradeIDreftypes.Add("ActiveUpgrade");
            SetPropertyIsObjectIDRef("upgradeID", true, upgradeIDreftypes);
            SetPropertyIsCollection("upgradeID", true, typeof(string));

            InitProperty("primaryUpgradeCapacity");
            InitProperty("activeUpgradeCapacity");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public upgradesDataStructure() : base(null, null)
        {
            _upgradeID = new ObservableCollection<string>();
            _upgradeID.CollectionChanged += OnupgradeIDChanged;

            _primaryUpgradeCapacity = 0;
            _activeUpgradeCapacity = 0;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public upgradesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _upgradeID = new ObservableCollection<string>();
            _upgradeID.CollectionChanged += OnupgradeIDChanged;

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
            _upgradeID = new ObservableCollection<string>(inCopyFrom.upgradeID);
            _upgradeID.CollectionChanged += OnupgradeIDChanged;
            SetPropertyExists("upgradeID", inCopyFrom.PropertyExists("upgradeID"));

            _primaryUpgradeCapacity = inCopyFrom.primaryUpgradeCapacity;
            SetPropertyExists("primaryUpgradeCapacity", inCopyFrom.PropertyExists("primaryUpgradeCapacity"));
            _activeUpgradeCapacity = inCopyFrom.activeUpgradeCapacity;
            SetPropertyExists("activeUpgradeCapacity", inCopyFrom.PropertyExists("activeUpgradeCapacity"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            upgradesDataStructure original = (upgradesDataStructure)inOriginal;
            _upgradeID = new ObservableCollection<string>(original.upgradeID);
            _upgradeID.CollectionChanged += OnupgradeIDChanged;
            SetPropertyExists("upgradeID", original.PropertyExists("upgradeID"));

            _primaryUpgradeCapacity = original.primaryUpgradeCapacity;
            SetPropertyExists("primaryUpgradeCapacity", original.PropertyExists("primaryUpgradeCapacity"));
            _activeUpgradeCapacity = original.activeUpgradeCapacity;
            SetPropertyExists("activeUpgradeCapacity", original.PropertyExists("activeUpgradeCapacity"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<upgrades>");
            if (PropertyExists("upgradeID"))
            {
                foreach (string result in _upgradeID)
                {
                    xmltextlines.Add(indent + "    <upgradeID attr1=\"" + result + "\"/>"); 
                }
            }

            if (PropertyExists("primaryUpgradeCapacity"))
            {
                xmltextlines.Add(indent + "    <primaryUpgradeCapacity attr1=\"" + _primaryUpgradeCapacity.ToString() + "\"/>"); 
            }
            if (PropertyExists("activeUpgradeCapacity"))
            {
                xmltextlines.Add(indent + "    <activeUpgradeCapacity attr1=\"" + _activeUpgradeCapacity.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</upgrades>");
            return xmltextlines;
        }
    }

    public class propulsionDataStructure : VD2DataStructure
    {
        string _propulsionEffectID;
        string _direction;

        float _pitch;
        float _yaw;
        float _roll;

        bool _bPlayerShipOnly;

        Vector3D _position;

        [Description("propulsionEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("propulsion", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("propulsion", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("propulsionEffectID");
            List<string> propulsionEffectIDreftypes = new List<string>();
            propulsionEffectIDreftypes.Add("Particle");
            SetPropertyIsObjectIDRef("propulsionEffectID", true, propulsionEffectIDreftypes);
            InitProperty("direction");

            InitProperty("pitch");
            InitProperty("yaw");
            InitProperty("roll");

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
            _roll = 0;

            _bPlayerShipOnly = false;

            _position = new Vector3D();

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public propulsionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _propulsionEffectID = "";
            _direction = "";

            _pitch = 0;
            _yaw = 0;
            _roll = 0;

            _bPlayerShipOnly = false;

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

        }

        public propulsionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inpropulsionEffectID, string indirection, float inpitch, float inyaw, float inroll, bool inbPlayerShipOnly, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _propulsionEffectID = inpropulsionEffectID;
            _direction = indirection;

            _pitch = inpitch;
            _yaw = inyaw;
            _roll = inroll;

            _bPlayerShipOnly = inbPlayerShipOnly;

            _position = inposition;

        }

        public propulsionDataStructure(propulsionDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _propulsionEffectID = inCopyFrom.propulsionEffectID;
            SetPropertyExists("propulsionEffectID", inCopyFrom.PropertyExists("propulsionEffectID"));
            _direction = inCopyFrom.direction;
            SetPropertyExists("direction", inCopyFrom.PropertyExists("direction"));

            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));
            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));

            _bPlayerShipOnly = inCopyFrom.bPlayerShipOnly;
            SetPropertyExists("bPlayerShipOnly", inCopyFrom.PropertyExists("bPlayerShipOnly"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            propulsionDataStructure original = (propulsionDataStructure)inOriginal;
            _propulsionEffectID = original.propulsionEffectID;
            SetPropertyExists("propulsionEffectID", original.PropertyExists("propulsionEffectID"));
            _direction = original.direction;
            SetPropertyExists("direction", original.PropertyExists("direction"));

            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));
            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));

            _bPlayerShipOnly = original.bPlayerShipOnly;
            SetPropertyExists("bPlayerShipOnly", original.PropertyExists("bPlayerShipOnly"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

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
            result += _roll.ToString();
            result += ", ";
            result += _bPlayerShipOnly.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<propulsion>");
            if (PropertyExists("propulsionEffectID"))
            {
                xmltextlines.Add(indent + "    <propulsionEffectID attr1=\"" + _propulsionEffectID + "\"/>"); 
            }
            if (PropertyExists("direction"))
            {
                xmltextlines.Add(indent + "    <direction attr1=\"" + _direction + "\"/>"); 
            }

            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }
            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }

            if (PropertyExists("bPlayerShipOnly"))
            {
                xmltextlines.Add(indent + "    <bPlayerShipOnly attr1=\"" + ((_bPlayerShipOnly) ? "1" : "0") + "\"/>");
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</propulsion>");
            return xmltextlines;
        }
    }

    public class weaponDataStructure : VD2DataStructure
    {
        string _weaponType;
        string _hardpointID;
        string _weaponFire;

        int _weaponPositionID;

        float _barrelDelay;
        float _yaw;
        float _pitch;

        Vector3D _position;

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

        [Description("hardpointID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("weapon", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("weapon", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
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
                if (_weaponPosition != null)
                {
                    _weaponPosition.CollectionChanged -= OnweaponPositionChanged;
                }
                _weaponPosition = value;
                if (_weaponPosition != null)
                {
                    _weaponPosition.CollectionChanged += OnweaponPositionChanged;
                }
                foreach (Vector3D element in _weaponPosition)
                {
                    element.OnElementChanged += weaponPosition_OnElementChanged;
                }
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
                        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                        {
                            foreach (object o in e.NewItems)
                            {
                                if (o is Vector3D)
                                {
                                    Vector3D vec = (Vector3D)o;
                                    vec.OnElementChanged += weaponPosition_OnElementChanged;
                                }
                            }
                        }
                        SetPropertyEdited("weaponPosition", true);
                        ParentDataFile.SetPropertyEdited("weapon", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _weaponPosition = new ObservableCollection<Vector3D>(ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(DataNode, "weaponPosition", out exists));
                            _weaponPosition.CollectionChanged += OnweaponPositionChanged;
                            SetPropertyExists("weaponPosition", exists);
                        }
                        else
                        {
                            _weaponPosition.CollectionChanged -= OnweaponPositionChanged;
                            _weaponPosition.Clear();
                            _weaponPosition.CollectionChanged += OnweaponPositionChanged;
                        }
                    }
                }
            }
        }

        public void weaponPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("weaponPosition", true);
                        ParentDataFile.SetPropertyEdited("weapon", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("hardpointID");
            List<string> hardpointIDreftypes = new List<string>();
            hardpointIDreftypes.Add("Weapon");
            hardpointIDreftypes.Add("Launcher");
            SetPropertyIsObjectIDRef("hardpointID", true, hardpointIDreftypes);
            InitProperty("weaponFire");

            InitProperty("weaponPositionID");

            InitProperty("barrelDelay");
            InitProperty("yaw");
            InitProperty("pitch");

            InitProperty("position");

            InitProperty("weaponPosition");
            SetPropertyIsCollection("weaponPosition", true, typeof(Vector3D));

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public weaponDataStructure() : base(null, null)
        {
            _weaponType = "";
            _hardpointID = "";
            _weaponFire = "";

            _weaponPositionID = 0;

            _barrelDelay = 0;
            _yaw = 0;
            _pitch = 0;

            _position = new Vector3D();

            _weaponPosition = new ObservableCollection<Vector3D>();
            _weaponPosition.CollectionChanged += OnweaponPositionChanged;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public weaponDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _weaponType = "";
            _hardpointID = "";
            _weaponFire = "";

            _weaponPositionID = 0;

            _barrelDelay = 0;
            _yaw = 0;
            _pitch = 0;

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

            _weaponPosition = new ObservableCollection<Vector3D>();
            _weaponPosition.CollectionChanged += OnweaponPositionChanged;

        }

        public weaponDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inweaponType, string inhardpointID, string inweaponFire, int inweaponPositionID, float inbarrelDelay, float inyaw, float inpitch, Vector3D inposition, List<Vector3D> inweaponPosition) : base(inParentDataFile, inDataNode)
        {
            _weaponType = inweaponType;
            _hardpointID = inhardpointID;
            _weaponFire = inweaponFire;

            _weaponPositionID = inweaponPositionID;

            _barrelDelay = inbarrelDelay;
            _yaw = inyaw;
            _pitch = inpitch;

            _position = inposition;

            _weaponPosition = new ObservableCollection<Vector3D>(inweaponPosition);

        }

        public weaponDataStructure(weaponDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _weaponType = inCopyFrom.weaponType;
            SetPropertyExists("weaponType", inCopyFrom.PropertyExists("weaponType"));
            _hardpointID = inCopyFrom.hardpointID;
            SetPropertyExists("hardpointID", inCopyFrom.PropertyExists("hardpointID"));
            _weaponFire = inCopyFrom.weaponFire;
            SetPropertyExists("weaponFire", inCopyFrom.PropertyExists("weaponFire"));

            _weaponPositionID = inCopyFrom.weaponPositionID;
            SetPropertyExists("weaponPositionID", inCopyFrom.PropertyExists("weaponPositionID"));

            _barrelDelay = inCopyFrom.barrelDelay;
            SetPropertyExists("barrelDelay", inCopyFrom.PropertyExists("barrelDelay"));
            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

            _weaponPosition = new ObservableCollection<Vector3D>();
            _weaponPosition.CollectionChanged += OnweaponPositionChanged;
            foreach (Vector3D vector in inCopyFrom.weaponPosition)
            {
                _weaponPosition.Add(new Vector3D(vector));
            }
            SetPropertyExists("weaponPosition", inCopyFrom.PropertyExists("weaponPosition"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            weaponDataStructure original = (weaponDataStructure)inOriginal;
            _weaponType = original.weaponType;
            SetPropertyExists("weaponType", original.PropertyExists("weaponType"));
            _hardpointID = original.hardpointID;
            SetPropertyExists("hardpointID", original.PropertyExists("hardpointID"));
            _weaponFire = original.weaponFire;
            SetPropertyExists("weaponFire", original.PropertyExists("weaponFire"));

            _weaponPositionID = original.weaponPositionID;
            SetPropertyExists("weaponPositionID", original.PropertyExists("weaponPositionID"));

            _barrelDelay = original.barrelDelay;
            SetPropertyExists("barrelDelay", original.PropertyExists("barrelDelay"));
            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

            _weaponPosition = new ObservableCollection<Vector3D>();
            _weaponPosition.CollectionChanged += OnweaponPositionChanged;
            foreach (Vector3D vector in original.weaponPosition)
            {
                _weaponPosition.Add(new Vector3D(vector));
            }
            SetPropertyExists("weaponPosition", original.PropertyExists("weaponPosition"));

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
            result += _weaponPositionID.ToString();
            result += ", ";
            result += _barrelDelay.ToString();
            result += ", ";
            result += _yaw.ToString();
            result += ", ";
            result += _pitch.ToString();
            result += ", ";
            result += _position.ToString();
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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<weapon>");
            if (PropertyExists("weaponType"))
            {
                xmltextlines.Add(indent + "    <weaponType attr1=\"" + _weaponType + "\"/>"); 
            }
            if (PropertyExists("hardpointID"))
            {
                xmltextlines.Add(indent + "    <hardpointID attr1=\"" + _hardpointID + "\"/>"); 
            }
            if (PropertyExists("weaponFire"))
            {
                xmltextlines.Add(indent + "    <weaponFire attr1=\"" + _weaponFire + "\"/>"); 
            }

            if (PropertyExists("weaponPositionID"))
            {
                xmltextlines.Add(indent + "    <weaponPositionID attr1=\"" + _weaponPositionID.ToString() + "\"/>"); 
            }

            if (PropertyExists("barrelDelay"))
            {
                xmltextlines.Add(indent + "    <barrelDelay attr1=\"" + _barrelDelay.ToString() + "\"/>"); 
            }
            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            if (PropertyExists("weaponPosition"))
            {
                foreach (Vector3D result in _weaponPosition)
                {
                    xmltextlines.Add(indent + "    <weaponPosition x=\"" + result.x.ToString() + "\" y=\"" + result.y.ToString() + "\" z=\"" + result.z.ToString() + "\"/>");
                }
            }

            xmltextlines.Add(indent + "</weapon>");
            return xmltextlines;
        }
    }

    public class damageDataStructure : VD2DataStructure
    {
        string _damageEffectID;

        float _pitch;
        float _roll;
        float _yaw;
        float _healthPoint;

        Vector3D _position;

        [Description("damageEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("damage", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("damage", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("damageEffectID");
            List<string> damageEffectIDreftypes = new List<string>();
            damageEffectIDreftypes.Add("Particle");
            SetPropertyIsObjectIDRef("damageEffectID", true, damageEffectIDreftypes);

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public damageDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _damageEffectID = "";

            _pitch = 0;
            _roll = 0;
            _yaw = 0;
            _healthPoint = 0;

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

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
            SetPropertyExists("damageEffectID", inCopyFrom.PropertyExists("damageEffectID"));

            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));
            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _healthPoint = inCopyFrom.healthPoint;
            SetPropertyExists("healthPoint", inCopyFrom.PropertyExists("healthPoint"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            damageDataStructure original = (damageDataStructure)inOriginal;
            _damageEffectID = original.damageEffectID;
            SetPropertyExists("damageEffectID", original.PropertyExists("damageEffectID"));

            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));
            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _healthPoint = original.healthPoint;
            SetPropertyExists("healthPoint", original.PropertyExists("healthPoint"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<damage>");
            if (PropertyExists("damageEffectID"))
            {
                xmltextlines.Add(indent + "    <damageEffectID attr1=\"" + _damageEffectID + "\"/>"); 
            }

            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }
            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("healthPoint"))
            {
                xmltextlines.Add(indent + "    <healthPoint attr1=\"" + _healthPoint.ToString() + "\"/>"); 
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</damage>");
            return xmltextlines;
        }
    }

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
        float _pitch;

        bool _bShowInCockpit;
        bool _bHideInHangar;

        Vector3D _position;

        [Description("turretID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                if (_turretRole != null)
                {
                    _turretRole.CollectionChanged -= OnturretRoleChanged;
                }
                _turretRole = value;
                if (_turretRole != null)
                {
                    _turretRole.CollectionChanged += OnturretRoleChanged;
                }
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
                            _turretRole.CollectionChanged += OnturretRoleChanged;
                            SetPropertyExists("turretRole", exists);
                        }
                        else
                        {
                            _turretRole.CollectionChanged -= OnturretRoleChanged;
                            _turretRole.Clear();
                            _turretRole.CollectionChanged += OnturretRoleChanged;
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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("turret", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("turret", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("turretID");
            List<string> turretIDreftypes = new List<string>();
            turretIDreftypes.Add("Turret");
            SetPropertyIsObjectIDRef("turretID", true, turretIDreftypes);
            InitProperty("turretOrientation");
            InitProperty("weaponFire");

            InitProperty("turretRole");
            SetPropertyIsCollection("turretRole", true, typeof(string));

            InitProperty("yawPermitted");
            InitProperty("weaponPositionID");

            InitProperty("pitchLower");
            InitProperty("roll");
            InitProperty("yaw");
            InitProperty("pitch");

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
            _turretRole.CollectionChanged += OnturretRoleChanged;

            _yawPermitted = 0;
            _weaponPositionID = 0;

            _pitchLower = 0;
            _roll = 0;
            _yaw = 0;
            _pitch = 0;

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public turretDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _turretID = "";
            _turretOrientation = "";
            _weaponFire = "";

            _turretRole = new ObservableCollection<string>();
            _turretRole.CollectionChanged += OnturretRoleChanged;

            _yawPermitted = 0;
            _weaponPositionID = 0;

            _pitchLower = 0;
            _roll = 0;
            _yaw = 0;
            _pitch = 0;

            _bShowInCockpit = false;
            _bHideInHangar = false;

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

        }

        public turretDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inturretID, string inturretOrientation, string inweaponFire, List<string> inturretRole, int inyawPermitted, int inweaponPositionID, float inpitchLower, float inroll, float inyaw, float inpitch, bool inbShowInCockpit, bool inbHideInHangar, Vector3D inposition) : base(inParentDataFile, inDataNode)
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
            _pitch = inpitch;

            _bShowInCockpit = inbShowInCockpit;
            _bHideInHangar = inbHideInHangar;

            _position = inposition;

        }

        public turretDataStructure(turretDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _turretID = inCopyFrom.turretID;
            SetPropertyExists("turretID", inCopyFrom.PropertyExists("turretID"));
            _turretOrientation = inCopyFrom.turretOrientation;
            SetPropertyExists("turretOrientation", inCopyFrom.PropertyExists("turretOrientation"));
            _weaponFire = inCopyFrom.weaponFire;
            SetPropertyExists("weaponFire", inCopyFrom.PropertyExists("weaponFire"));

            _turretRole = new ObservableCollection<string>(inCopyFrom.turretRole);
            _turretRole.CollectionChanged += OnturretRoleChanged;
            SetPropertyExists("turretRole", inCopyFrom.PropertyExists("turretRole"));

            _yawPermitted = inCopyFrom.yawPermitted;
            SetPropertyExists("yawPermitted", inCopyFrom.PropertyExists("yawPermitted"));
            _weaponPositionID = inCopyFrom.weaponPositionID;
            SetPropertyExists("weaponPositionID", inCopyFrom.PropertyExists("weaponPositionID"));

            _pitchLower = inCopyFrom.pitchLower;
            SetPropertyExists("pitchLower", inCopyFrom.PropertyExists("pitchLower"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));
            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));

            _bShowInCockpit = inCopyFrom.bShowInCockpit;
            SetPropertyExists("bShowInCockpit", inCopyFrom.PropertyExists("bShowInCockpit"));
            _bHideInHangar = inCopyFrom.bHideInHangar;
            SetPropertyExists("bHideInHangar", inCopyFrom.PropertyExists("bHideInHangar"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            turretDataStructure original = (turretDataStructure)inOriginal;
            _turretID = original.turretID;
            SetPropertyExists("turretID", original.PropertyExists("turretID"));
            _turretOrientation = original.turretOrientation;
            SetPropertyExists("turretOrientation", original.PropertyExists("turretOrientation"));
            _weaponFire = original.weaponFire;
            SetPropertyExists("weaponFire", original.PropertyExists("weaponFire"));

            _turretRole = new ObservableCollection<string>(original.turretRole);
            _turretRole.CollectionChanged += OnturretRoleChanged;
            SetPropertyExists("turretRole", original.PropertyExists("turretRole"));

            _yawPermitted = original.yawPermitted;
            SetPropertyExists("yawPermitted", original.PropertyExists("yawPermitted"));
            _weaponPositionID = original.weaponPositionID;
            SetPropertyExists("weaponPositionID", original.PropertyExists("weaponPositionID"));

            _pitchLower = original.pitchLower;
            SetPropertyExists("pitchLower", original.PropertyExists("pitchLower"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));
            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));

            _bShowInCockpit = original.bShowInCockpit;
            SetPropertyExists("bShowInCockpit", original.PropertyExists("bShowInCockpit"));
            _bHideInHangar = original.bHideInHangar;
            SetPropertyExists("bHideInHangar", original.PropertyExists("bHideInHangar"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

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
            result += _pitch.ToString();
            result += ", ";
            result += _bShowInCockpit.ToString();
            result += ", ";
            result += _bHideInHangar.ToString();
            result += ", ";
            result += _position.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<turret>");
            if (PropertyExists("turretID"))
            {
                xmltextlines.Add(indent + "    <turretID attr1=\"" + _turretID + "\"/>"); 
            }
            if (PropertyExists("turretOrientation"))
            {
                xmltextlines.Add(indent + "    <turretOrientation attr1=\"" + _turretOrientation + "\"/>"); 
            }
            if (PropertyExists("weaponFire"))
            {
                xmltextlines.Add(indent + "    <weaponFire attr1=\"" + _weaponFire + "\"/>"); 
            }

            if (PropertyExists("turretRole"))
            {
                foreach (string result in _turretRole)
                {
                    xmltextlines.Add(indent + "    <turretRole attr1=\"" + result + "\"/>"); 
                }
            }

            if (PropertyExists("yawPermitted"))
            {
                xmltextlines.Add(indent + "    <yawPermitted attr1=\"" + _yawPermitted.ToString() + "\"/>"); 
            }
            if (PropertyExists("weaponPositionID"))
            {
                xmltextlines.Add(indent + "    <weaponPositionID attr1=\"" + _weaponPositionID.ToString() + "\"/>"); 
            }

            if (PropertyExists("pitchLower"))
            {
                xmltextlines.Add(indent + "    <pitchLower attr1=\"" + _pitchLower.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }
            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }

            if (PropertyExists("bShowInCockpit"))
            {
                xmltextlines.Add(indent + "    <bShowInCockpit attr1=\"" + ((_bShowInCockpit) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bHideInHangar"))
            {
                xmltextlines.Add(indent + "    <bHideInHangar attr1=\"" + ((_bHideInHangar) ? "1" : "0") + "\"/>");
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</turret>");
            return xmltextlines;
        }
    }

    public class attachmentDataStructure : VD2DataStructure
    {
        string _attachmentID;
        string _attachmentOrientation;

        Vector3D _attachmentPosition;

        [Description("attachmentID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string attachmentID
        {
            get
            {
                return _attachmentID;
            }
            set
            {
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _attachmentID = value;
                            SetPropertyEdited("attachmentID", true);
                            ParentDataFile.SetPropertyEdited("attachment", true);
                        }
                    }
                }
            }
        }

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
                            if (_attachmentPosition != null)
                            {
                                _attachmentPosition.OnElementChanged -= attachmentPosition_OnElementChanged;
                            }
                            _attachmentPosition = value;
                            if (_attachmentPosition != null)
                            {
                                _attachmentPosition.OnElementChanged += attachmentPosition_OnElementChanged;
                            }
                            SetPropertyEdited("attachmentPosition", true);
                            ParentDataFile.SetPropertyEdited("attachment", true);
                        }
                    }
                }
            }
        }

        public void attachmentPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("attachmentPosition", true);
                        ParentDataFile.SetPropertyEdited("attachment", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= attachmentPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += attachmentPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= attachmentPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += attachmentPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= attachmentPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += attachmentPosition_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("attachmentID");
            List<string> attachmentIDreftypes = new List<string>();
            attachmentIDreftypes.Add("Other");
            SetPropertyIsObjectIDRef("attachmentID", true, attachmentIDreftypes);
            InitProperty("attachmentOrientation");

            InitProperty("attachmentPosition");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public attachmentDataStructure() : base(null, null)
        {
            _attachmentID = "";
            _attachmentOrientation = "";

            _attachmentPosition = new Vector3D();

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public attachmentDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _attachmentID = "";
            _attachmentOrientation = "";

            _attachmentPosition = new Vector3D();
            _attachmentPosition.OnElementChanged += attachmentPosition_OnElementChanged;

        }

        public attachmentDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inattachmentID, string inattachmentOrientation, Vector3D inattachmentPosition) : base(inParentDataFile, inDataNode)
        {
            _attachmentID = inattachmentID;
            _attachmentOrientation = inattachmentOrientation;

            _attachmentPosition = inattachmentPosition;

        }

        public attachmentDataStructure(attachmentDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _attachmentID = inCopyFrom.attachmentID;
            SetPropertyExists("attachmentID", inCopyFrom.PropertyExists("attachmentID"));
            _attachmentOrientation = inCopyFrom.attachmentOrientation;
            SetPropertyExists("attachmentOrientation", inCopyFrom.PropertyExists("attachmentOrientation"));

            _attachmentPosition = new Vector3D(inCopyFrom.attachmentPosition);
            SetPropertyExists("attachmentPosition", inCopyFrom.PropertyExists("attachmentPosition"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            attachmentDataStructure original = (attachmentDataStructure)inOriginal;
            _attachmentID = original.attachmentID;
            SetPropertyExists("attachmentID", original.PropertyExists("attachmentID"));
            _attachmentOrientation = original.attachmentOrientation;
            SetPropertyExists("attachmentOrientation", original.PropertyExists("attachmentOrientation"));

            _attachmentPosition = new Vector3D(original.attachmentPosition);
            SetPropertyExists("attachmentPosition", original.PropertyExists("attachmentPosition"));

        }

        public override string ToString()
        {
            string result = "";
            result += _attachmentID;
            result += ", ";
            result += _attachmentOrientation;
            result += ", ";
            result += _attachmentPosition.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<attachment>");
            if (PropertyExists("attachmentID"))
            {
                xmltextlines.Add(indent + "    <attachmentID attr1=\"" + _attachmentID + "\"/>"); 
            }
            if (PropertyExists("attachmentOrientation"))
            {
                xmltextlines.Add(indent + "    <attachmentOrientation attr1=\"" + _attachmentOrientation + "\"/>"); 
            }

            if (PropertyExists("attachmentPosition"))
            {
                xmltextlines.Add(indent + "    <attachmentPosition x=\"" + _attachmentPosition.x.ToString() + "\" y=\"" + _attachmentPosition.y.ToString() + "\" z=\"" + _attachmentPosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</attachment>");
            return xmltextlines;
        }
    }

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
                            if (_translateAmount != null)
                            {
                                _translateAmount.OnElementChanged -= translateAmount_OnElementChanged;
                            }
                            _translateAmount = value;
                            if (_translateAmount != null)
                            {
                                _translateAmount.OnElementChanged += translateAmount_OnElementChanged;
                            }
                            SetPropertyEdited("translateAmount", true);
                            ParentDataFile.SetPropertyEdited("movingElement", true);
                        }
                    }
                }
            }
        }

        public void translateAmount_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("translateAmount", true);
                        ParentDataFile.SetPropertyEdited("movingElement", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= translateAmount_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += translateAmount_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= translateAmount_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += translateAmount_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= translateAmount_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += translateAmount_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            _translateAmount.OnElementChanged += translateAmount_OnElementChanged;

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
            SetPropertyExists("boneName", inCopyFrom.PropertyExists("boneName"));

            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));
            _speedMultiplier = inCopyFrom.speedMultiplier;
            SetPropertyExists("speedMultiplier", inCopyFrom.PropertyExists("speedMultiplier"));

            _bLinkedToWeapon = inCopyFrom.bLinkedToWeapon;
            SetPropertyExists("bLinkedToWeapon", inCopyFrom.PropertyExists("bLinkedToWeapon"));
            _bCombat = inCopyFrom.bCombat;
            SetPropertyExists("bCombat", inCopyFrom.PropertyExists("bCombat"));

            _translateAmount = new Vector3D(inCopyFrom.translateAmount);
            SetPropertyExists("translateAmount", inCopyFrom.PropertyExists("translateAmount"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            movingElementDataStructure original = (movingElementDataStructure)inOriginal;
            _boneName = original.boneName;
            SetPropertyExists("boneName", original.PropertyExists("boneName"));

            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));
            _speedMultiplier = original.speedMultiplier;
            SetPropertyExists("speedMultiplier", original.PropertyExists("speedMultiplier"));

            _bLinkedToWeapon = original.bLinkedToWeapon;
            SetPropertyExists("bLinkedToWeapon", original.PropertyExists("bLinkedToWeapon"));
            _bCombat = original.bCombat;
            SetPropertyExists("bCombat", original.PropertyExists("bCombat"));

            _translateAmount = new Vector3D(original.translateAmount);
            SetPropertyExists("translateAmount", original.PropertyExists("translateAmount"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<movingElement>");
            if (PropertyExists("boneName"))
            {
                xmltextlines.Add(indent + "    <boneName attr1=\"" + _boneName + "\"/>"); 
            }

            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }
            if (PropertyExists("speedMultiplier"))
            {
                xmltextlines.Add(indent + "    <speedMultiplier attr1=\"" + _speedMultiplier.ToString() + "\"/>"); 
            }

            if (PropertyExists("bLinkedToWeapon"))
            {
                xmltextlines.Add(indent + "    <bLinkedToWeapon attr1=\"" + ((_bLinkedToWeapon) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCombat"))
            {
                xmltextlines.Add(indent + "    <bCombat attr1=\"" + ((_bCombat) ? "1" : "0") + "\"/>");
            }

            if (PropertyExists("translateAmount"))
            {
                xmltextlines.Add(indent + "    <translateAmount x=\"" + _translateAmount.x.ToString() + "\" y=\"" + _translateAmount.y.ToString() + "\" z=\"" + _translateAmount.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</movingElement>");
            return xmltextlines;
        }
    }

    public class dockDataStructure : VD2DataStructure
    {
        string _dockType;
        string _ejectOrientation;
        string _objectID;
        string _orientation;
        string _attachedID;
        string _boneName;
        string _dockOrientation;
        string _resourceOnly;

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

        [Description("objectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string objectID
        {
            get
            {
                return _objectID;
            }
            set
            {
                if (ParentDataFile != null)
                {
                    if (ParentDataFile.Source != null)
                    {
                        if (ParentDataFile.Source.WriteAccess)
                        {
                            _objectID = value;
                            SetPropertyEdited("objectID", true);
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

        [Description("attachedID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("dock", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("dock", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("dockType");
            InitProperty("ejectOrientation");
            InitProperty("objectID");
            List<string> objectIDreftypes = new List<string>();
            objectIDreftypes.Add("Ship");
            SetPropertyIsObjectIDRef("objectID", true, objectIDreftypes);
            InitProperty("orientation");
            InitProperty("attachedID");
            List<string> attachedIDreftypes = new List<string>();
            attachedIDreftypes.Add("Ship");
            SetPropertyIsObjectIDRef("attachedID", true, attachedIDreftypes);
            InitProperty("boneName");
            InitProperty("dockOrientation");
            InitProperty("resourceOnly");

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
            _objectID = "";
            _orientation = "";
            _attachedID = "";
            _boneName = "";
            _dockOrientation = "";
            _resourceOnly = "";

            _ejectVelocity = 0;
            _dockRollOffset = 0;
            _dockYawOffset = 0;

            _bCanAcceptRawResource = false;
            _bInvisible = false;

            _position = new Vector3D();

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public dockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _dockType = "";
            _ejectOrientation = "";
            _objectID = "";
            _orientation = "";
            _attachedID = "";
            _boneName = "";
            _dockOrientation = "";
            _resourceOnly = "";

            _ejectVelocity = 0;
            _dockRollOffset = 0;
            _dockYawOffset = 0;

            _bCanAcceptRawResource = false;
            _bInvisible = false;

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

        }

        public dockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string indockType, string inejectOrientation, string inobjectID, string inorientation, string inattachedID, string inboneName, string indockOrientation, string inresourceOnly, int inejectVelocity, int indockRollOffset, int indockYawOffset, bool inbCanAcceptRawResource, bool inbInvisible, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _dockType = indockType;
            _ejectOrientation = inejectOrientation;
            _objectID = inobjectID;
            _orientation = inorientation;
            _attachedID = inattachedID;
            _boneName = inboneName;
            _dockOrientation = indockOrientation;
            _resourceOnly = inresourceOnly;

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
            SetPropertyExists("dockType", inCopyFrom.PropertyExists("dockType"));
            _ejectOrientation = inCopyFrom.ejectOrientation;
            SetPropertyExists("ejectOrientation", inCopyFrom.PropertyExists("ejectOrientation"));
            _objectID = inCopyFrom.objectID;
            SetPropertyExists("objectID", inCopyFrom.PropertyExists("objectID"));
            _orientation = inCopyFrom.orientation;
            SetPropertyExists("orientation", inCopyFrom.PropertyExists("orientation"));
            _attachedID = inCopyFrom.attachedID;
            SetPropertyExists("attachedID", inCopyFrom.PropertyExists("attachedID"));
            _boneName = inCopyFrom.boneName;
            SetPropertyExists("boneName", inCopyFrom.PropertyExists("boneName"));
            _dockOrientation = inCopyFrom.dockOrientation;
            SetPropertyExists("dockOrientation", inCopyFrom.PropertyExists("dockOrientation"));
            _resourceOnly = inCopyFrom.resourceOnly;
            SetPropertyExists("resourceOnly", inCopyFrom.PropertyExists("resourceOnly"));

            _ejectVelocity = inCopyFrom.ejectVelocity;
            SetPropertyExists("ejectVelocity", inCopyFrom.PropertyExists("ejectVelocity"));
            _dockRollOffset = inCopyFrom.dockRollOffset;
            SetPropertyExists("dockRollOffset", inCopyFrom.PropertyExists("dockRollOffset"));
            _dockYawOffset = inCopyFrom.dockYawOffset;
            SetPropertyExists("dockYawOffset", inCopyFrom.PropertyExists("dockYawOffset"));

            _bCanAcceptRawResource = inCopyFrom.bCanAcceptRawResource;
            SetPropertyExists("bCanAcceptRawResource", inCopyFrom.PropertyExists("bCanAcceptRawResource"));
            _bInvisible = inCopyFrom.bInvisible;
            SetPropertyExists("bInvisible", inCopyFrom.PropertyExists("bInvisible"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            dockDataStructure original = (dockDataStructure)inOriginal;
            _dockType = original.dockType;
            SetPropertyExists("dockType", original.PropertyExists("dockType"));
            _ejectOrientation = original.ejectOrientation;
            SetPropertyExists("ejectOrientation", original.PropertyExists("ejectOrientation"));
            _objectID = original.objectID;
            SetPropertyExists("objectID", original.PropertyExists("objectID"));
            _orientation = original.orientation;
            SetPropertyExists("orientation", original.PropertyExists("orientation"));
            _attachedID = original.attachedID;
            SetPropertyExists("attachedID", original.PropertyExists("attachedID"));
            _boneName = original.boneName;
            SetPropertyExists("boneName", original.PropertyExists("boneName"));
            _dockOrientation = original.dockOrientation;
            SetPropertyExists("dockOrientation", original.PropertyExists("dockOrientation"));
            _resourceOnly = original.resourceOnly;
            SetPropertyExists("resourceOnly", original.PropertyExists("resourceOnly"));

            _ejectVelocity = original.ejectVelocity;
            SetPropertyExists("ejectVelocity", original.PropertyExists("ejectVelocity"));
            _dockRollOffset = original.dockRollOffset;
            SetPropertyExists("dockRollOffset", original.PropertyExists("dockRollOffset"));
            _dockYawOffset = original.dockYawOffset;
            SetPropertyExists("dockYawOffset", original.PropertyExists("dockYawOffset"));

            _bCanAcceptRawResource = original.bCanAcceptRawResource;
            SetPropertyExists("bCanAcceptRawResource", original.PropertyExists("bCanAcceptRawResource"));
            _bInvisible = original.bInvisible;
            SetPropertyExists("bInvisible", original.PropertyExists("bInvisible"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

        }

        public override string ToString()
        {
            string result = "";
            result += _dockType;
            result += ", ";
            result += _ejectOrientation;
            result += ", ";
            result += _objectID;
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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<dock>");
            if (PropertyExists("dockType"))
            {
                xmltextlines.Add(indent + "    <dockType attr1=\"" + _dockType + "\"/>"); 
            }
            if (PropertyExists("ejectOrientation"))
            {
                xmltextlines.Add(indent + "    <ejectOrientation attr1=\"" + _ejectOrientation + "\"/>"); 
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add(indent + "    <objectID attr1=\"" + _objectID + "\"/>"); 
            }
            if (PropertyExists("orientation"))
            {
                xmltextlines.Add(indent + "    <orientation attr1=\"" + _orientation + "\"/>"); 
            }
            if (PropertyExists("attachedID"))
            {
                xmltextlines.Add(indent + "    <attachedID attr1=\"" + _attachedID + "\"/>"); 
            }
            if (PropertyExists("boneName"))
            {
                xmltextlines.Add(indent + "    <boneName attr1=\"" + _boneName + "\"/>"); 
            }
            if (PropertyExists("dockOrientation"))
            {
                xmltextlines.Add(indent + "    <dockOrientation attr1=\"" + _dockOrientation + "\"/>"); 
            }
            if (PropertyExists("resourceOnly"))
            {
                xmltextlines.Add(indent + "    <resourceOnly attr1=\"" + _resourceOnly + "\"/>"); 
            }

            if (PropertyExists("ejectVelocity"))
            {
                xmltextlines.Add(indent + "    <ejectVelocity attr1=\"" + _ejectVelocity.ToString() + "\"/>"); 
            }
            if (PropertyExists("dockRollOffset"))
            {
                xmltextlines.Add(indent + "    <dockRollOffset attr1=\"" + _dockRollOffset.ToString() + "\"/>"); 
            }
            if (PropertyExists("dockYawOffset"))
            {
                xmltextlines.Add(indent + "    <dockYawOffset attr1=\"" + _dockYawOffset.ToString() + "\"/>"); 
            }

            if (PropertyExists("bCanAcceptRawResource"))
            {
                xmltextlines.Add(indent + "    <bCanAcceptRawResource attr1=\"" + ((_bCanAcceptRawResource) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bInvisible"))
            {
                xmltextlines.Add(indent + "    <bInvisible attr1=\"" + ((_bInvisible) ? "1" : "0") + "\"/>");
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</dock>");
            return xmltextlines;
        }
    }

    public class shieldDataStructure : VD2DataStructure
    {
        string _shieldID;
        string _shieldOrientation;

        int _pitch;
        int _roll;

        float _yaw;

        Vector3D _shieldPosition;

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
                            if (_shieldPosition != null)
                            {
                                _shieldPosition.OnElementChanged -= shieldPosition_OnElementChanged;
                            }
                            _shieldPosition = value;
                            if (_shieldPosition != null)
                            {
                                _shieldPosition.OnElementChanged += shieldPosition_OnElementChanged;
                            }
                            SetPropertyEdited("shieldPosition", true);
                            ParentDataFile.SetPropertyEdited("shield", true);
                        }
                    }
                }
            }
        }

        public void shieldPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("shieldPosition", true);
                        ParentDataFile.SetPropertyEdited("shield", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= shieldPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += shieldPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= shieldPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += shieldPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= shieldPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += shieldPosition_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("shieldID");
            List<string> shieldIDreftypes = new List<string>();
            shieldIDreftypes.Add("Shield");
            SetPropertyIsObjectIDRef("shieldID", true, shieldIDreftypes);
            InitProperty("shieldOrientation");

            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("yaw");

            InitProperty("shieldPosition");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public shieldDataStructure() : base(null, null)
        {
            _shieldID = "";
            _shieldOrientation = "";

            _pitch = 0;
            _roll = 0;

            _yaw = 0;

            _shieldPosition = new Vector3D();

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public shieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _shieldID = "";
            _shieldOrientation = "";

            _pitch = 0;
            _roll = 0;

            _yaw = 0;

            _shieldPosition = new Vector3D();
            _shieldPosition.OnElementChanged += shieldPosition_OnElementChanged;

        }

        public shieldDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inshieldID, string inshieldOrientation, int inpitch, int inroll, float inyaw, Vector3D inshieldPosition) : base(inParentDataFile, inDataNode)
        {
            _shieldID = inshieldID;
            _shieldOrientation = inshieldOrientation;

            _pitch = inpitch;
            _roll = inroll;

            _yaw = inyaw;

            _shieldPosition = inshieldPosition;

        }

        public shieldDataStructure(shieldDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _shieldID = inCopyFrom.shieldID;
            SetPropertyExists("shieldID", inCopyFrom.PropertyExists("shieldID"));
            _shieldOrientation = inCopyFrom.shieldOrientation;
            SetPropertyExists("shieldOrientation", inCopyFrom.PropertyExists("shieldOrientation"));

            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));

            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));

            _shieldPosition = new Vector3D(inCopyFrom.shieldPosition);
            SetPropertyExists("shieldPosition", inCopyFrom.PropertyExists("shieldPosition"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            shieldDataStructure original = (shieldDataStructure)inOriginal;
            _shieldID = original.shieldID;
            SetPropertyExists("shieldID", original.PropertyExists("shieldID"));
            _shieldOrientation = original.shieldOrientation;
            SetPropertyExists("shieldOrientation", original.PropertyExists("shieldOrientation"));

            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));

            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));

            _shieldPosition = new Vector3D(original.shieldPosition);
            SetPropertyExists("shieldPosition", original.PropertyExists("shieldPosition"));

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
            result += _yaw.ToString();
            result += ", ";
            result += _shieldPosition.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<shield>");
            if (PropertyExists("shieldID"))
            {
                xmltextlines.Add(indent + "    <shieldID attr1=\"" + _shieldID + "\"/>"); 
            }
            if (PropertyExists("shieldOrientation"))
            {
                xmltextlines.Add(indent + "    <shieldOrientation attr1=\"" + _shieldOrientation + "\"/>"); 
            }

            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }

            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }

            if (PropertyExists("shieldPosition"))
            {
                xmltextlines.Add(indent + "    <shieldPosition x=\"" + _shieldPosition.x.ToString() + "\" y=\"" + _shieldPosition.y.ToString() + "\" z=\"" + _shieldPosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</shield>");
            return xmltextlines;
        }
    }

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("boneName", inCopyFrom.PropertyExists("boneName"));

            _rollSpeed = inCopyFrom.rollSpeed;
            SetPropertyExists("rollSpeed", inCopyFrom.PropertyExists("rollSpeed"));

            _bLinkedToWeapon = inCopyFrom.bLinkedToWeapon;
            SetPropertyExists("bLinkedToWeapon", inCopyFrom.PropertyExists("bLinkedToWeapon"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            rotatingElementDataStructure original = (rotatingElementDataStructure)inOriginal;
            _boneName = original.boneName;
            SetPropertyExists("boneName", original.PropertyExists("boneName"));

            _rollSpeed = original.rollSpeed;
            SetPropertyExists("rollSpeed", original.PropertyExists("rollSpeed"));

            _bLinkedToWeapon = original.bLinkedToWeapon;
            SetPropertyExists("bLinkedToWeapon", original.PropertyExists("bLinkedToWeapon"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<rotatingElement>");
            if (PropertyExists("boneName"))
            {
                xmltextlines.Add(indent + "    <boneName attr1=\"" + _boneName + "\"/>"); 
            }

            if (PropertyExists("rollSpeed"))
            {
                xmltextlines.Add(indent + "    <rollSpeed attr1=\"" + _rollSpeed.ToString() + "\"/>"); 
            }

            if (PropertyExists("bLinkedToWeapon"))
            {
                xmltextlines.Add(indent + "    <bLinkedToWeapon attr1=\"" + ((_bLinkedToWeapon) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add(indent + "</rotatingElement>");
            return xmltextlines;
        }
    }

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
                if (_muzzleBone != null)
                {
                    _muzzleBone.CollectionChanged -= OnmuzzleBoneChanged;
                }
                _muzzleBone = value;
                if (_muzzleBone != null)
                {
                    _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;
                }
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
                            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;
                            SetPropertyExists("muzzleBone", exists);
                        }
                        else
                        {
                            _muzzleBone.CollectionChanged -= OnmuzzleBoneChanged;
                            _muzzleBone.Clear();
                            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;
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
            SetPropertyIsCollection("muzzleBone", true, typeof(string));

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
            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;

            _recoilZ = 0;
            _recoilTime = 0;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public recoilDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _recoilBone = "";
            _muzzleBoneName = "";
            _recoilParentType = "";

            _muzzleBone = new ObservableCollection<string>();
            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;

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
            SetPropertyExists("recoilBone", inCopyFrom.PropertyExists("recoilBone"));
            _muzzleBoneName = inCopyFrom.muzzleBoneName;
            SetPropertyExists("muzzleBoneName", inCopyFrom.PropertyExists("muzzleBoneName"));
            _recoilParentType = inCopyFrom.recoilParentType;
            SetPropertyExists("recoilParentType", inCopyFrom.PropertyExists("recoilParentType"));

            _muzzleBone = new ObservableCollection<string>(inCopyFrom.muzzleBone);
            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;
            SetPropertyExists("muzzleBone", inCopyFrom.PropertyExists("muzzleBone"));

            _recoilZ = inCopyFrom.recoilZ;
            SetPropertyExists("recoilZ", inCopyFrom.PropertyExists("recoilZ"));
            _recoilTime = inCopyFrom.recoilTime;
            SetPropertyExists("recoilTime", inCopyFrom.PropertyExists("recoilTime"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            recoilDataStructure original = (recoilDataStructure)inOriginal;
            _recoilBone = original.recoilBone;
            SetPropertyExists("recoilBone", original.PropertyExists("recoilBone"));
            _muzzleBoneName = original.muzzleBoneName;
            SetPropertyExists("muzzleBoneName", original.PropertyExists("muzzleBoneName"));
            _recoilParentType = original.recoilParentType;
            SetPropertyExists("recoilParentType", original.PropertyExists("recoilParentType"));

            _muzzleBone = new ObservableCollection<string>(original.muzzleBone);
            _muzzleBone.CollectionChanged += OnmuzzleBoneChanged;
            SetPropertyExists("muzzleBone", original.PropertyExists("muzzleBone"));

            _recoilZ = original.recoilZ;
            SetPropertyExists("recoilZ", original.PropertyExists("recoilZ"));
            _recoilTime = original.recoilTime;
            SetPropertyExists("recoilTime", original.PropertyExists("recoilTime"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<recoil>");
            if (PropertyExists("recoilBone"))
            {
                xmltextlines.Add(indent + "    <recoilBone attr1=\"" + _recoilBone + "\"/>"); 
            }
            if (PropertyExists("muzzleBoneName"))
            {
                xmltextlines.Add(indent + "    <muzzleBoneName attr1=\"" + _muzzleBoneName + "\"/>"); 
            }
            if (PropertyExists("recoilParentType"))
            {
                xmltextlines.Add(indent + "    <recoilParentType attr1=\"" + _recoilParentType + "\"/>"); 
            }

            if (PropertyExists("muzzleBone"))
            {
                foreach (string result in _muzzleBone)
                {
                    xmltextlines.Add(indent + "    <muzzleBone attr1=\"" + result + "\"/>"); 
                }
            }

            if (PropertyExists("recoilZ"))
            {
                xmltextlines.Add(indent + "    <recoilZ attr1=\"" + _recoilZ.ToString() + "\"/>"); 
            }
            if (PropertyExists("recoilTime"))
            {
                xmltextlines.Add(indent + "    <recoilTime attr1=\"" + _recoilTime.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</recoil>");
            return xmltextlines;
        }
    }

    public class rotateBonesDataStructure : VD2DataStructure
    {
        ObservableCollection<string> _rotateBone;

        [Description("rotateBone is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> rotateBone
        {
            get
            {
                return _rotateBone;
            }
            set
            {
                if (_rotateBone != null)
                {
                    _rotateBone.CollectionChanged -= OnrotateBoneChanged;
                }
                _rotateBone = value;
                if (_rotateBone != null)
                {
                    _rotateBone.CollectionChanged += OnrotateBoneChanged;
                }
            }
        }

        public void OnrotateBoneChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ParentDataFile != null)
            {
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("rotateBone", true);
                        ParentDataFile.SetPropertyEdited("rotateBones", true);
                    }
                    else
                    {
                        if (DataNode != null)
                        {
                            bool exists = false;
                            _rotateBone = new ObservableCollection<string>(ParseHelpers.GetStringListFromXMLNodeNamedChildren(DataNode, "rotateBone", out exists));
                            _rotateBone.CollectionChanged += OnrotateBoneChanged;
                            SetPropertyExists("rotateBone", exists);
                        }
                        else
                        {
                            _rotateBone.CollectionChanged -= OnrotateBoneChanged;
                            _rotateBone.Clear();
                            _rotateBone.CollectionChanged += OnrotateBoneChanged;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("rotateBone");
            SetPropertyIsCollection("rotateBone", true, typeof(string));

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public rotateBonesDataStructure() : base(null, null)
        {
            _rotateBone = new ObservableCollection<string>();
            _rotateBone.CollectionChanged += OnrotateBoneChanged;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public rotateBonesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _rotateBone = new ObservableCollection<string>();
            _rotateBone.CollectionChanged += OnrotateBoneChanged;

        }

        public rotateBonesDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> inrotateBone) : base(inParentDataFile, inDataNode)
        {
            _rotateBone = new ObservableCollection<string>(inrotateBone);

        }

        public rotateBonesDataStructure(rotateBonesDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _rotateBone = new ObservableCollection<string>(inCopyFrom.rotateBone);
            _rotateBone.CollectionChanged += OnrotateBoneChanged;
            SetPropertyExists("rotateBone", inCopyFrom.PropertyExists("rotateBone"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            rotateBonesDataStructure original = (rotateBonesDataStructure)inOriginal;
            _rotateBone = new ObservableCollection<string>(original.rotateBone);
            _rotateBone.CollectionChanged += OnrotateBoneChanged;
            SetPropertyExists("rotateBone", original.PropertyExists("rotateBone"));

        }

        public override string ToString()
        {
            int i = 0;
            string result = "";
            for (i = 0; i < _rotateBone.Count; i++)
            {
                result += _rotateBone[i];
                if (_rotateBone.Count - i != 1)
                {
                    result += ", ";
                }
            }
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<rotateBones>");
            if (PropertyExists("rotateBone"))
            {
                foreach (string result in _rotateBone)
                {
                    xmltextlines.Add(indent + "    <rotateBone attr1=\"" + result + "\"/>"); 
                }
            }

            xmltextlines.Add(indent + "</rotateBones>");
            return xmltextlines;
        }
    }

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

        [Description("projectileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
            List<string> projectileIDreftypes = new List<string>();
            projectileIDreftypes.Add("Ammo");
            SetPropertyIsObjectIDRef("projectileID", true, projectileIDreftypes);

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("projectileID", inCopyFrom.PropertyExists("projectileID"));

            _canisterCount = inCopyFrom.canisterCount;
            SetPropertyExists("canisterCount", inCopyFrom.PropertyExists("canisterCount"));
            _blowBackCanisterCount = inCopyFrom.blowBackCanisterCount;
            SetPropertyExists("blowBackCanisterCount", inCopyFrom.PropertyExists("blowBackCanisterCount"));
            _yawRange = inCopyFrom.yawRange;
            SetPropertyExists("yawRange", inCopyFrom.PropertyExists("yawRange"));
            _pitchRange = inCopyFrom.pitchRange;
            SetPropertyExists("pitchRange", inCopyFrom.PropertyExists("pitchRange"));
            _rollRange = inCopyFrom.rollRange;
            SetPropertyExists("rollRange", inCopyFrom.PropertyExists("rollRange"));
            _speedAddBase = inCopyFrom.speedAddBase;
            SetPropertyExists("speedAddBase", inCopyFrom.PropertyExists("speedAddBase"));
            _speedAddRandom = inCopyFrom.speedAddRandom;
            SetPropertyExists("speedAddRandom", inCopyFrom.PropertyExists("speedAddRandom"));

            _bCanisterAimAssist = inCopyFrom.bCanisterAimAssist;
            SetPropertyExists("bCanisterAimAssist", inCopyFrom.PropertyExists("bCanisterAimAssist"));
            _bAddToRangeCalculations = inCopyFrom.bAddToRangeCalculations;
            SetPropertyExists("bAddToRangeCalculations", inCopyFrom.PropertyExists("bAddToRangeCalculations"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            canisterDataStructure original = (canisterDataStructure)inOriginal;
            _projectileID = original.projectileID;
            SetPropertyExists("projectileID", original.PropertyExists("projectileID"));

            _canisterCount = original.canisterCount;
            SetPropertyExists("canisterCount", original.PropertyExists("canisterCount"));
            _blowBackCanisterCount = original.blowBackCanisterCount;
            SetPropertyExists("blowBackCanisterCount", original.PropertyExists("blowBackCanisterCount"));
            _yawRange = original.yawRange;
            SetPropertyExists("yawRange", original.PropertyExists("yawRange"));
            _pitchRange = original.pitchRange;
            SetPropertyExists("pitchRange", original.PropertyExists("pitchRange"));
            _rollRange = original.rollRange;
            SetPropertyExists("rollRange", original.PropertyExists("rollRange"));
            _speedAddBase = original.speedAddBase;
            SetPropertyExists("speedAddBase", original.PropertyExists("speedAddBase"));
            _speedAddRandom = original.speedAddRandom;
            SetPropertyExists("speedAddRandom", original.PropertyExists("speedAddRandom"));

            _bCanisterAimAssist = original.bCanisterAimAssist;
            SetPropertyExists("bCanisterAimAssist", original.PropertyExists("bCanisterAimAssist"));
            _bAddToRangeCalculations = original.bAddToRangeCalculations;
            SetPropertyExists("bAddToRangeCalculations", original.PropertyExists("bAddToRangeCalculations"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<canister>");
            if (PropertyExists("projectileID"))
            {
                xmltextlines.Add(indent + "    <projectileID attr1=\"" + _projectileID + "\"/>"); 
            }

            if (PropertyExists("canisterCount"))
            {
                xmltextlines.Add(indent + "    <canisterCount attr1=\"" + _canisterCount.ToString() + "\"/>"); 
            }
            if (PropertyExists("blowBackCanisterCount"))
            {
                xmltextlines.Add(indent + "    <blowBackCanisterCount attr1=\"" + _blowBackCanisterCount.ToString() + "\"/>"); 
            }
            if (PropertyExists("yawRange"))
            {
                xmltextlines.Add(indent + "    <yawRange attr1=\"" + _yawRange.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitchRange"))
            {
                xmltextlines.Add(indent + "    <pitchRange attr1=\"" + _pitchRange.ToString() + "\"/>"); 
            }
            if (PropertyExists("rollRange"))
            {
                xmltextlines.Add(indent + "    <rollRange attr1=\"" + _rollRange.ToString() + "\"/>"); 
            }
            if (PropertyExists("speedAddBase"))
            {
                xmltextlines.Add(indent + "    <speedAddBase attr1=\"" + _speedAddBase.ToString() + "\"/>"); 
            }
            if (PropertyExists("speedAddRandom"))
            {
                xmltextlines.Add(indent + "    <speedAddRandom attr1=\"" + _speedAddRandom.ToString() + "\"/>"); 
            }

            if (PropertyExists("bCanisterAimAssist"))
            {
                xmltextlines.Add(indent + "    <bCanisterAimAssist attr1=\"" + ((_bCanisterAimAssist) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAddToRangeCalculations"))
            {
                xmltextlines.Add(indent + "    <bAddToRangeCalculations attr1=\"" + ((_bAddToRangeCalculations) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add(indent + "</canister>");
            return xmltextlines;
        }
    }

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
                            if (_launchDeckBeg != null)
                            {
                                _launchDeckBeg.OnElementChanged -= launchDeckBeg_OnElementChanged;
                            }
                            _launchDeckBeg = value;
                            if (_launchDeckBeg != null)
                            {
                                _launchDeckBeg.OnElementChanged += launchDeckBeg_OnElementChanged;
                            }
                            SetPropertyEdited("launchDeckBeg", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
            }
        }

        public void launchDeckBeg_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("launchDeckBeg", true);
                        ParentDataFile.SetPropertyEdited("launchTube", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= launchDeckBeg_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += launchDeckBeg_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= launchDeckBeg_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += launchDeckBeg_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= launchDeckBeg_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += launchDeckBeg_OnElementChanged;
                                break;
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
                            if (_launchDeckEnd != null)
                            {
                                _launchDeckEnd.OnElementChanged -= launchDeckEnd_OnElementChanged;
                            }
                            _launchDeckEnd = value;
                            if (_launchDeckEnd != null)
                            {
                                _launchDeckEnd.OnElementChanged += launchDeckEnd_OnElementChanged;
                            }
                            SetPropertyEdited("launchDeckEnd", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
            }
        }

        public void launchDeckEnd_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("launchDeckEnd", true);
                        ParentDataFile.SetPropertyEdited("launchTube", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= launchDeckEnd_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += launchDeckEnd_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= launchDeckEnd_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += launchDeckEnd_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= launchDeckEnd_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += launchDeckEnd_OnElementChanged;
                                break;
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
                            if (_dockPosition != null)
                            {
                                _dockPosition.OnElementChanged -= dockPosition_OnElementChanged;
                            }
                            _dockPosition = value;
                            if (_dockPosition != null)
                            {
                                _dockPosition.OnElementChanged += dockPosition_OnElementChanged;
                            }
                            SetPropertyEdited("dockPosition", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
            }
        }

        public void dockPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("dockPosition", true);
                        ParentDataFile.SetPropertyEdited("launchTube", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
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
                            if (_dockSize != null)
                            {
                                _dockSize.OnElementChanged -= dockSize_OnElementChanged;
                            }
                            _dockSize = value;
                            if (_dockSize != null)
                            {
                                _dockSize.OnElementChanged += dockSize_OnElementChanged;
                            }
                            SetPropertyEdited("dockSize", true);
                            ParentDataFile.SetPropertyEdited("launchTube", true);
                        }
                    }
                }
            }
        }

        public void dockSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("dockSize", true);
                        ParentDataFile.SetPropertyEdited("launchTube", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public launchTubeDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _direction = "";

            _launchDeckBeg = new Vector3D();
            _launchDeckBeg.OnElementChanged += launchDeckBeg_OnElementChanged;
            _launchDeckEnd = new Vector3D();
            _launchDeckEnd.OnElementChanged += launchDeckEnd_OnElementChanged;
            _dockPosition = new Vector3D();
            _dockPosition.OnElementChanged += dockPosition_OnElementChanged;
            _dockSize = new Vector3D();
            _dockSize.OnElementChanged += dockSize_OnElementChanged;

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
            SetPropertyExists("direction", inCopyFrom.PropertyExists("direction"));

            _launchDeckBeg = new Vector3D(inCopyFrom.launchDeckBeg);
            SetPropertyExists("launchDeckBeg", inCopyFrom.PropertyExists("launchDeckBeg"));
            _launchDeckEnd = new Vector3D(inCopyFrom.launchDeckEnd);
            SetPropertyExists("launchDeckEnd", inCopyFrom.PropertyExists("launchDeckEnd"));
            _dockPosition = new Vector3D(inCopyFrom.dockPosition);
            SetPropertyExists("dockPosition", inCopyFrom.PropertyExists("dockPosition"));
            _dockSize = new Vector3D(inCopyFrom.dockSize);
            SetPropertyExists("dockSize", inCopyFrom.PropertyExists("dockSize"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            launchTubeDataStructure original = (launchTubeDataStructure)inOriginal;
            _direction = original.direction;
            SetPropertyExists("direction", original.PropertyExists("direction"));

            _launchDeckBeg = new Vector3D(original.launchDeckBeg);
            SetPropertyExists("launchDeckBeg", original.PropertyExists("launchDeckBeg"));
            _launchDeckEnd = new Vector3D(original.launchDeckEnd);
            SetPropertyExists("launchDeckEnd", original.PropertyExists("launchDeckEnd"));
            _dockPosition = new Vector3D(original.dockPosition);
            SetPropertyExists("dockPosition", original.PropertyExists("dockPosition"));
            _dockSize = new Vector3D(original.dockSize);
            SetPropertyExists("dockSize", original.PropertyExists("dockSize"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<launchTube>");
            if (PropertyExists("direction"))
            {
                xmltextlines.Add(indent + "    <direction attr1=\"" + _direction + "\"/>"); 
            }

            if (PropertyExists("launchDeckBeg"))
            {
                xmltextlines.Add(indent + "    <launchDeckBeg x=\"" + _launchDeckBeg.x.ToString() + "\" y=\"" + _launchDeckBeg.y.ToString() + "\" z=\"" + _launchDeckBeg.z.ToString() + "\"/>");
            }
            if (PropertyExists("launchDeckEnd"))
            {
                xmltextlines.Add(indent + "    <launchDeckEnd x=\"" + _launchDeckEnd.x.ToString() + "\" y=\"" + _launchDeckEnd.y.ToString() + "\" z=\"" + _launchDeckEnd.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockPosition"))
            {
                xmltextlines.Add(indent + "    <dockPosition x=\"" + _dockPosition.x.ToString() + "\" y=\"" + _dockPosition.y.ToString() + "\" z=\"" + _dockPosition.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockSize"))
            {
                xmltextlines.Add(indent + "    <dockSize x=\"" + _dockSize.x.ToString() + "\" y=\"" + _dockSize.y.ToString() + "\" z=\"" + _dockSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</launchTube>");
            return xmltextlines;
        }
    }

    public class mirvDataStructure : VD2DataStructure
    {
        string _mirvObjectID;

        int _mirvCount;

        bool _bNoExplodeOnMirv;

        [Description("mirvObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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
            List<string> mirvObjectIDreftypes = new List<string>();
            mirvObjectIDreftypes.Add("Missile");
            SetPropertyIsObjectIDRef("mirvObjectID", true, mirvObjectIDreftypes);

            InitProperty("mirvCount");

            InitProperty("bNoExplodeOnMirv");

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public mirvDataStructure() : base(null, null)
        {
            _mirvObjectID = "";

            _mirvCount = 0;

            _bNoExplodeOnMirv = false;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("mirvObjectID", inCopyFrom.PropertyExists("mirvObjectID"));

            _mirvCount = inCopyFrom.mirvCount;
            SetPropertyExists("mirvCount", inCopyFrom.PropertyExists("mirvCount"));

            _bNoExplodeOnMirv = inCopyFrom.bNoExplodeOnMirv;
            SetPropertyExists("bNoExplodeOnMirv", inCopyFrom.PropertyExists("bNoExplodeOnMirv"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            mirvDataStructure original = (mirvDataStructure)inOriginal;
            _mirvObjectID = original.mirvObjectID;
            SetPropertyExists("mirvObjectID", original.PropertyExists("mirvObjectID"));

            _mirvCount = original.mirvCount;
            SetPropertyExists("mirvCount", original.PropertyExists("mirvCount"));

            _bNoExplodeOnMirv = original.bNoExplodeOnMirv;
            SetPropertyExists("bNoExplodeOnMirv", original.PropertyExists("bNoExplodeOnMirv"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<mirv>");
            if (PropertyExists("mirvObjectID"))
            {
                xmltextlines.Add(indent + "    <mirvObjectID attr1=\"" + _mirvObjectID + "\"/>"); 
            }

            if (PropertyExists("mirvCount"))
            {
                xmltextlines.Add(indent + "    <mirvCount attr1=\"" + _mirvCount.ToString() + "\"/>"); 
            }

            if (PropertyExists("bNoExplodeOnMirv"))
            {
                xmltextlines.Add(indent + "    <bNoExplodeOnMirv attr1=\"" + ((_bNoExplodeOnMirv) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add(indent + "</mirv>");
            return xmltextlines;
        }
    }

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("mainDirection", inCopyFrom.PropertyExists("mainDirection"));

            _yaw = inCopyFrom.yaw;
            SetPropertyExists("yaw", inCopyFrom.PropertyExists("yaw"));
            _pitch = inCopyFrom.pitch;
            SetPropertyExists("pitch", inCopyFrom.PropertyExists("pitch"));
            _roll = inCopyFrom.roll;
            SetPropertyExists("roll", inCopyFrom.PropertyExists("roll"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            weaponDirectionDataStructure original = (weaponDirectionDataStructure)inOriginal;
            _mainDirection = original.mainDirection;
            SetPropertyExists("mainDirection", original.PropertyExists("mainDirection"));

            _yaw = original.yaw;
            SetPropertyExists("yaw", original.PropertyExists("yaw"));
            _pitch = original.pitch;
            SetPropertyExists("pitch", original.PropertyExists("pitch"));
            _roll = original.roll;
            SetPropertyExists("roll", original.PropertyExists("roll"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<weaponDirection>");
            if (PropertyExists("mainDirection"))
            {
                xmltextlines.Add(indent + "    <mainDirection attr1=\"" + _mainDirection + "\"/>"); 
            }

            if (PropertyExists("yaw"))
            {
                xmltextlines.Add(indent + "    <yaw attr1=\"" + _yaw.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitch"))
            {
                xmltextlines.Add(indent + "    <pitch attr1=\"" + _pitch.ToString() + "\"/>"); 
            }
            if (PropertyExists("roll"))
            {
                xmltextlines.Add(indent + "    <roll attr1=\"" + _roll.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</weaponDirection>");
            return xmltextlines;
        }
    }

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
                            if (_weaponPosition != null)
                            {
                                _weaponPosition.OnElementChanged -= weaponPosition_OnElementChanged;
                            }
                            _weaponPosition = value;
                            if (_weaponPosition != null)
                            {
                                _weaponPosition.OnElementChanged += weaponPosition_OnElementChanged;
                            }
                            SetPropertyEdited("weaponPosition", true);
                            ParentDataFile.SetPropertyEdited("turretBarrel", true);
                        }
                    }
                }
            }
        }

        public void weaponPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("weaponPosition", true);
                        ParentDataFile.SetPropertyEdited("turretBarrel", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= weaponPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += weaponPosition_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public turretBarrelDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _boneName = "";

            _weaponPosition = new Vector3D();
            _weaponPosition.OnElementChanged += weaponPosition_OnElementChanged;

        }

        public turretBarrelDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string inboneName, Vector3D inweaponPosition) : base(inParentDataFile, inDataNode)
        {
            _boneName = inboneName;

            _weaponPosition = inweaponPosition;

        }

        public turretBarrelDataStructure(turretBarrelDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _boneName = inCopyFrom.boneName;
            SetPropertyExists("boneName", inCopyFrom.PropertyExists("boneName"));

            _weaponPosition = new Vector3D(inCopyFrom.weaponPosition);
            SetPropertyExists("weaponPosition", inCopyFrom.PropertyExists("weaponPosition"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            turretBarrelDataStructure original = (turretBarrelDataStructure)inOriginal;
            _boneName = original.boneName;
            SetPropertyExists("boneName", original.PropertyExists("boneName"));

            _weaponPosition = new Vector3D(original.weaponPosition);
            SetPropertyExists("weaponPosition", original.PropertyExists("weaponPosition"));

        }

        public override string ToString()
        {
            string result = "";
            result += _boneName;
            result += ", ";
            result += _weaponPosition.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<turretBarrel>");
            if (PropertyExists("boneName"))
            {
                xmltextlines.Add(indent + "    <boneName attr1=\"" + _boneName + "\"/>"); 
            }

            if (PropertyExists("weaponPosition"))
            {
                xmltextlines.Add(indent + "    <weaponPosition x=\"" + _weaponPosition.x.ToString() + "\" y=\"" + _weaponPosition.y.ToString() + "\" z=\"" + _weaponPosition.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</turretBarrel>");
            return xmltextlines;
        }
    }

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
                if (_asteroidID != null)
                {
                    _asteroidID.CollectionChanged -= OnasteroidIDChanged;
                }
                _asteroidID = value;
                if (_asteroidID != null)
                {
                    _asteroidID.CollectionChanged += OnasteroidIDChanged;
                }
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
                            _asteroidID.CollectionChanged += OnasteroidIDChanged;
                            SetPropertyExists("asteroidID", exists);
                        }
                        else
                        {
                            _asteroidID.CollectionChanged -= OnasteroidIDChanged;
                            _asteroidID.Clear();
                            _asteroidID.CollectionChanged += OnasteroidIDChanged;
                        }
                    }
                }
            }
        }



        public override void InitAllProperties()
        {
            InitProperty("asteroidID");
            SetPropertyIsCollection("asteroidID", true, typeof(string));

        }

        //Only called by collections editor, so we use the data file that is open right now.
        public deathSpawnDataStructure() : base(null, null)
        {
            _asteroidID = new ObservableCollection<string>();
            _asteroidID.CollectionChanged += OnasteroidIDChanged;

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public deathSpawnDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = new ObservableCollection<string>();
            _asteroidID.CollectionChanged += OnasteroidIDChanged;

        }

        public deathSpawnDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, List<string> inasteroidID) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = new ObservableCollection<string>(inasteroidID);

        }

        public deathSpawnDataStructure(deathSpawnDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _asteroidID = new ObservableCollection<string>(inCopyFrom.asteroidID);
            _asteroidID.CollectionChanged += OnasteroidIDChanged;
            SetPropertyExists("asteroidID", inCopyFrom.PropertyExists("asteroidID"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            deathSpawnDataStructure original = (deathSpawnDataStructure)inOriginal;
            _asteroidID = new ObservableCollection<string>(original.asteroidID);
            _asteroidID.CollectionChanged += OnasteroidIDChanged;
            SetPropertyExists("asteroidID", original.PropertyExists("asteroidID"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<deathSpawn>");
            if (PropertyExists("asteroidID"))
            {
                foreach (string result in _asteroidID)
                {
                    xmltextlines.Add(indent + "    <asteroidID attr1=\"" + result + "\"/>"); 
                }
            }

            xmltextlines.Add(indent + "</deathSpawn>");
            return xmltextlines;
        }
    }

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
                            if (_linearVelocity != null)
                            {
                                _linearVelocity.OnElementChanged -= linearVelocity_OnElementChanged;
                            }
                            _linearVelocity = value;
                            if (_linearVelocity != null)
                            {
                                _linearVelocity.OnElementChanged += linearVelocity_OnElementChanged;
                            }
                            SetPropertyEdited("linearVelocity", true);
                            ParentDataFile.SetPropertyEdited("baby", true);
                        }
                    }
                }
            }
        }

        public void linearVelocity_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("linearVelocity", true);
                        ParentDataFile.SetPropertyEdited("baby", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public babyDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _asteroidID = "";

            _lifeTimer = 0;

            _linearVelocity = new Vector3D();
            _linearVelocity.OnElementChanged += linearVelocity_OnElementChanged;

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
            SetPropertyExists("asteroidID", inCopyFrom.PropertyExists("asteroidID"));

            _lifeTimer = inCopyFrom.lifeTimer;
            SetPropertyExists("lifeTimer", inCopyFrom.PropertyExists("lifeTimer"));

            _linearVelocity = new Vector3D(inCopyFrom.linearVelocity);
            SetPropertyExists("linearVelocity", inCopyFrom.PropertyExists("linearVelocity"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            babyDataStructure original = (babyDataStructure)inOriginal;
            _asteroidID = original.asteroidID;
            SetPropertyExists("asteroidID", original.PropertyExists("asteroidID"));

            _lifeTimer = original.lifeTimer;
            SetPropertyExists("lifeTimer", original.PropertyExists("lifeTimer"));

            _linearVelocity = new Vector3D(original.linearVelocity);
            SetPropertyExists("linearVelocity", original.PropertyExists("linearVelocity"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<baby>");
            if (PropertyExists("asteroidID"))
            {
                xmltextlines.Add(indent + "    <asteroidID attr1=\"" + _asteroidID + "\"/>"); 
            }

            if (PropertyExists("lifeTimer"))
            {
                xmltextlines.Add(indent + "    <lifeTimer attr1=\"" + _lifeTimer.ToString() + "\"/>"); 
            }

            if (PropertyExists("linearVelocity"))
            {
                xmltextlines.Add(indent + "    <linearVelocity x=\"" + _linearVelocity.x.ToString() + "\" y=\"" + _linearVelocity.y.ToString() + "\" z=\"" + _linearVelocity.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</baby>");
            return xmltextlines;
        }
    }

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
                            if (_dockPosition != null)
                            {
                                _dockPosition.OnElementChanged -= dockPosition_OnElementChanged;
                            }
                            _dockPosition = value;
                            if (_dockPosition != null)
                            {
                                _dockPosition.OnElementChanged += dockPosition_OnElementChanged;
                            }
                            SetPropertyEdited("dockPosition", true);
                            ParentDataFile.SetPropertyEdited("largeDock", true);
                        }
                    }
                }
            }
        }

        public void dockPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("dockPosition", true);
                        ParentDataFile.SetPropertyEdited("largeDock", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= dockPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += dockPosition_OnElementChanged;
                                break;
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
                            if (_dockSize != null)
                            {
                                _dockSize.OnElementChanged -= dockSize_OnElementChanged;
                            }
                            _dockSize = value;
                            if (_dockSize != null)
                            {
                                _dockSize.OnElementChanged += dockSize_OnElementChanged;
                            }
                            SetPropertyEdited("dockSize", true);
                            ParentDataFile.SetPropertyEdited("largeDock", true);
                        }
                    }
                }
            }
        }

        public void dockSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("dockSize", true);
                        ParentDataFile.SetPropertyEdited("largeDock", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= dockSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += dockSize_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public largeDockDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _rollRotation = 0;

            _dockPosition = new Vector3D();
            _dockPosition.OnElementChanged += dockPosition_OnElementChanged;
            _dockSize = new Vector3D();
            _dockSize.OnElementChanged += dockSize_OnElementChanged;

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
            SetPropertyExists("rollRotation", inCopyFrom.PropertyExists("rollRotation"));

            _dockPosition = new Vector3D(inCopyFrom.dockPosition);
            SetPropertyExists("dockPosition", inCopyFrom.PropertyExists("dockPosition"));
            _dockSize = new Vector3D(inCopyFrom.dockSize);
            SetPropertyExists("dockSize", inCopyFrom.PropertyExists("dockSize"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            largeDockDataStructure original = (largeDockDataStructure)inOriginal;
            _rollRotation = original.rollRotation;
            SetPropertyExists("rollRotation", original.PropertyExists("rollRotation"));

            _dockPosition = new Vector3D(original.dockPosition);
            SetPropertyExists("dockPosition", original.PropertyExists("dockPosition"));
            _dockSize = new Vector3D(original.dockSize);
            SetPropertyExists("dockSize", original.PropertyExists("dockSize"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<largeDock>");
            if (PropertyExists("rollRotation"))
            {
                xmltextlines.Add(indent + "    <rollRotation attr1=\"" + _rollRotation.ToString() + "\"/>"); 
            }

            if (PropertyExists("dockPosition"))
            {
                xmltextlines.Add(indent + "    <dockPosition x=\"" + _dockPosition.x.ToString() + "\" y=\"" + _dockPosition.y.ToString() + "\" z=\"" + _dockPosition.z.ToString() + "\"/>");
            }
            if (PropertyExists("dockSize"))
            {
                xmltextlines.Add(indent + "    <dockSize x=\"" + _dockSize.x.ToString() + "\" y=\"" + _dockSize.y.ToString() + "\" z=\"" + _dockSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</largeDock>");
            return xmltextlines;
        }
    }

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("meshName", inCopyFrom.PropertyExists("meshName"));
            _collisionShape = inCopyFrom.collisionShape;
            SetPropertyExists("collisionShape", inCopyFrom.PropertyExists("collisionShape"));

            _rollSpeed = inCopyFrom.rollSpeed;
            SetPropertyExists("rollSpeed", inCopyFrom.PropertyExists("rollSpeed"));
            _yawSpeed = inCopyFrom.yawSpeed;
            SetPropertyExists("yawSpeed", inCopyFrom.PropertyExists("yawSpeed"));
            _pitchSpeed = inCopyFrom.pitchSpeed;
            SetPropertyExists("pitchSpeed", inCopyFrom.PropertyExists("pitchSpeed"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            physicalRotatingElementDataStructure original = (physicalRotatingElementDataStructure)inOriginal;
            _meshName = original.meshName;
            SetPropertyExists("meshName", original.PropertyExists("meshName"));
            _collisionShape = original.collisionShape;
            SetPropertyExists("collisionShape", original.PropertyExists("collisionShape"));

            _rollSpeed = original.rollSpeed;
            SetPropertyExists("rollSpeed", original.PropertyExists("rollSpeed"));
            _yawSpeed = original.yawSpeed;
            SetPropertyExists("yawSpeed", original.PropertyExists("yawSpeed"));
            _pitchSpeed = original.pitchSpeed;
            SetPropertyExists("pitchSpeed", original.PropertyExists("pitchSpeed"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<physicalRotatingElement>");
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add(indent + "    <meshName attr1=\"" + _meshName + "\"/>"); 
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add(indent + "    <collisionShape attr1=\"" + _collisionShape + "\"/>"); 
            }

            if (PropertyExists("rollSpeed"))
            {
                xmltextlines.Add(indent + "    <rollSpeed attr1=\"" + _rollSpeed.ToString() + "\"/>"); 
            }
            if (PropertyExists("yawSpeed"))
            {
                xmltextlines.Add(indent + "    <yawSpeed attr1=\"" + _yawSpeed.ToString() + "\"/>"); 
            }
            if (PropertyExists("pitchSpeed"))
            {
                xmltextlines.Add(indent + "    <pitchSpeed attr1=\"" + _pitchSpeed.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</physicalRotatingElement>");
            return xmltextlines;
        }
    }

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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("alwaysOnEffect", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("alwaysOnEffect", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public alwaysOnEffectDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _effectID = "";

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;

        }

        public alwaysOnEffectDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, string ineffectID, Vector3D inposition) : base(inParentDataFile, inDataNode)
        {
            _effectID = ineffectID;

            _position = inposition;

        }

        public alwaysOnEffectDataStructure(alwaysOnEffectDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _effectID = inCopyFrom.effectID;
            SetPropertyExists("effectID", inCopyFrom.PropertyExists("effectID"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            alwaysOnEffectDataStructure original = (alwaysOnEffectDataStructure)inOriginal;
            _effectID = original.effectID;
            SetPropertyExists("effectID", original.PropertyExists("effectID"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));

        }

        public override string ToString()
        {
            string result = "";
            result += _effectID;
            result += ", ";
            result += _position.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<alwaysOnEffect>");
            if (PropertyExists("effectID"))
            {
                xmltextlines.Add(indent + "    <effectID attr1=\"" + _effectID + "\"/>"); 
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</alwaysOnEffect>");
            return xmltextlines;
        }
    }

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("cargoBayType", inCopyFrom.PropertyExists("cargoBayType"));

            _maxAmount = inCopyFrom.maxAmount;
            SetPropertyExists("maxAmount", inCopyFrom.PropertyExists("maxAmount"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            cargoBayDataStructure original = (cargoBayDataStructure)inOriginal;
            _cargoBayType = original.cargoBayType;
            SetPropertyExists("cargoBayType", original.PropertyExists("cargoBayType"));

            _maxAmount = original.maxAmount;
            SetPropertyExists("maxAmount", original.PropertyExists("maxAmount"));

        }

        public override string ToString()
        {
            string result = "";
            result += _cargoBayType;
            result += ", ";
            result += _maxAmount.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<cargoBay>");
            if (PropertyExists("cargoBayType"))
            {
                xmltextlines.Add(indent + "    <cargoBayType attr1=\"" + _cargoBayType + "\"/>"); 
            }

            if (PropertyExists("maxAmount"))
            {
                xmltextlines.Add(indent + "    <maxAmount attr1=\"" + _maxAmount.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</cargoBay>");
            return xmltextlines;
        }
    }

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
                            if (_gateCollisionSize != null)
                            {
                                _gateCollisionSize.OnElementChanged -= gateCollisionSize_OnElementChanged;
                            }
                            _gateCollisionSize = value;
                            if (_gateCollisionSize != null)
                            {
                                _gateCollisionSize.OnElementChanged += gateCollisionSize_OnElementChanged;
                            }
                            SetPropertyEdited("gateCollisionSize", true);
                            ParentDataFile.SetPropertyEdited("gateCollision", true);
                        }
                    }
                }
            }
        }

        public void gateCollisionSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("gateCollisionSize", true);
                        ParentDataFile.SetPropertyEdited("gateCollision", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= gateCollisionSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += gateCollisionSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= gateCollisionSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += gateCollisionSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= gateCollisionSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += gateCollisionSize_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public gateCollisionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _gateCollisionSize = new Vector3D();
            _gateCollisionSize.OnElementChanged += gateCollisionSize_OnElementChanged;

        }

        public gateCollisionDataStructure(VD2Data inParentDataFile, XmlNode inDataNode, Vector3D ingateCollisionSize) : base(inParentDataFile, inDataNode)
        {
            _gateCollisionSize = ingateCollisionSize;

        }

        public gateCollisionDataStructure(gateCollisionDataStructure inCopyFrom) : base(inCopyFrom.ParentDataFile, inCopyFrom.DataNode)
        {
            _gateCollisionSize = new Vector3D(inCopyFrom.gateCollisionSize);
            SetPropertyExists("gateCollisionSize", inCopyFrom.PropertyExists("gateCollisionSize"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            gateCollisionDataStructure original = (gateCollisionDataStructure)inOriginal;
            _gateCollisionSize = new Vector3D(original.gateCollisionSize);
            SetPropertyExists("gateCollisionSize", original.PropertyExists("gateCollisionSize"));

        }

        public override string ToString()
        {
            string result = "";
            result += _gateCollisionSize.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<gateCollision>");
            if (PropertyExists("gateCollisionSize"))
            {
                xmltextlines.Add(indent + "    <gateCollisionSize x=\"" + _gateCollisionSize.x.ToString() + "\" y=\"" + _gateCollisionSize.y.ToString() + "\" z=\"" + _gateCollisionSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</gateCollision>");
            return xmltextlines;
        }
    }

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
                            if (_refuelPosition != null)
                            {
                                _refuelPosition.OnElementChanged -= refuelPosition_OnElementChanged;
                            }
                            _refuelPosition = value;
                            if (_refuelPosition != null)
                            {
                                _refuelPosition.OnElementChanged += refuelPosition_OnElementChanged;
                            }
                            SetPropertyEdited("refuelPosition", true);
                            ParentDataFile.SetPropertyEdited("refuelArea", true);
                        }
                    }
                }
            }
        }

        public void refuelPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("refuelPosition", true);
                        ParentDataFile.SetPropertyEdited("refuelArea", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= refuelPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += refuelPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= refuelPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += refuelPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= refuelPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += refuelPosition_OnElementChanged;
                                break;
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
                            if (_refuelSize != null)
                            {
                                _refuelSize.OnElementChanged -= refuelSize_OnElementChanged;
                            }
                            _refuelSize = value;
                            if (_refuelSize != null)
                            {
                                _refuelSize.OnElementChanged += refuelSize_OnElementChanged;
                            }
                            SetPropertyEdited("refuelSize", true);
                            ParentDataFile.SetPropertyEdited("refuelArea", true);
                        }
                    }
                }
            }
        }

        public void refuelSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("refuelSize", true);
                        ParentDataFile.SetPropertyEdited("refuelArea", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= refuelSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += refuelSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= refuelSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += refuelSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= refuelSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += refuelSize_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public refuelAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _refuelParticleSystem = "";

            _refuelPosition = new Vector3D();
            _refuelPosition.OnElementChanged += refuelPosition_OnElementChanged;
            _refuelSize = new Vector3D();
            _refuelSize.OnElementChanged += refuelSize_OnElementChanged;

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
            SetPropertyExists("refuelParticleSystem", inCopyFrom.PropertyExists("refuelParticleSystem"));

            _refuelPosition = new Vector3D(inCopyFrom.refuelPosition);
            SetPropertyExists("refuelPosition", inCopyFrom.PropertyExists("refuelPosition"));
            _refuelSize = new Vector3D(inCopyFrom.refuelSize);
            SetPropertyExists("refuelSize", inCopyFrom.PropertyExists("refuelSize"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            refuelAreaDataStructure original = (refuelAreaDataStructure)inOriginal;
            _refuelParticleSystem = original.refuelParticleSystem;
            SetPropertyExists("refuelParticleSystem", original.PropertyExists("refuelParticleSystem"));

            _refuelPosition = new Vector3D(original.refuelPosition);
            SetPropertyExists("refuelPosition", original.PropertyExists("refuelPosition"));
            _refuelSize = new Vector3D(original.refuelSize);
            SetPropertyExists("refuelSize", original.PropertyExists("refuelSize"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<refuelArea>");
            if (PropertyExists("refuelParticleSystem"))
            {
                xmltextlines.Add(indent + "    <refuelParticleSystem attr1=\"" + _refuelParticleSystem + "\"/>"); 
            }

            if (PropertyExists("refuelPosition"))
            {
                xmltextlines.Add(indent + "    <refuelPosition x=\"" + _refuelPosition.x.ToString() + "\" y=\"" + _refuelPosition.y.ToString() + "\" z=\"" + _refuelPosition.z.ToString() + "\"/>");
            }
            if (PropertyExists("refuelSize"))
            {
                xmltextlines.Add(indent + "    <refuelSize x=\"" + _refuelSize.x.ToString() + "\" y=\"" + _refuelSize.y.ToString() + "\" z=\"" + _refuelSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</refuelArea>");
            return xmltextlines;
        }
    }

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
                            if (_repairPosition != null)
                            {
                                _repairPosition.OnElementChanged -= repairPosition_OnElementChanged;
                            }
                            _repairPosition = value;
                            if (_repairPosition != null)
                            {
                                _repairPosition.OnElementChanged += repairPosition_OnElementChanged;
                            }
                            SetPropertyEdited("repairPosition", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
            }
        }

        public void repairPosition_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("repairPosition", true);
                        ParentDataFile.SetPropertyEdited("repairArea", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= repairPosition_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += repairPosition_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= repairPosition_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += repairPosition_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= repairPosition_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += repairPosition_OnElementChanged;
                                break;
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
                            if (_repairSize != null)
                            {
                                _repairSize.OnElementChanged -= repairSize_OnElementChanged;
                            }
                            _repairSize = value;
                            if (_repairSize != null)
                            {
                                _repairSize.OnElementChanged += repairSize_OnElementChanged;
                            }
                            SetPropertyEdited("repairSize", true);
                            ParentDataFile.SetPropertyEdited("repairArea", true);
                        }
                    }
                }
            }
        }

        public void repairSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("repairSize", true);
                        ParentDataFile.SetPropertyEdited("repairArea", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= repairSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += repairSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= repairSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += repairSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= repairSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += repairSize_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public repairAreaDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _repairParticleSystem = "";
            _repairSoundID = "";
            _maxRepairClass = "";

            _repairPosition = new Vector3D();
            _repairPosition.OnElementChanged += repairPosition_OnElementChanged;
            _repairSize = new Vector3D();
            _repairSize.OnElementChanged += repairSize_OnElementChanged;

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
            SetPropertyExists("repairParticleSystem", inCopyFrom.PropertyExists("repairParticleSystem"));
            _repairSoundID = inCopyFrom.repairSoundID;
            SetPropertyExists("repairSoundID", inCopyFrom.PropertyExists("repairSoundID"));
            _maxRepairClass = inCopyFrom.maxRepairClass;
            SetPropertyExists("maxRepairClass", inCopyFrom.PropertyExists("maxRepairClass"));

            _repairPosition = new Vector3D(inCopyFrom.repairPosition);
            SetPropertyExists("repairPosition", inCopyFrom.PropertyExists("repairPosition"));
            _repairSize = new Vector3D(inCopyFrom.repairSize);
            SetPropertyExists("repairSize", inCopyFrom.PropertyExists("repairSize"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            repairAreaDataStructure original = (repairAreaDataStructure)inOriginal;
            _repairParticleSystem = original.repairParticleSystem;
            SetPropertyExists("repairParticleSystem", original.PropertyExists("repairParticleSystem"));
            _repairSoundID = original.repairSoundID;
            SetPropertyExists("repairSoundID", original.PropertyExists("repairSoundID"));
            _maxRepairClass = original.maxRepairClass;
            SetPropertyExists("maxRepairClass", original.PropertyExists("maxRepairClass"));

            _repairPosition = new Vector3D(original.repairPosition);
            SetPropertyExists("repairPosition", original.PropertyExists("repairPosition"));
            _repairSize = new Vector3D(original.repairSize);
            SetPropertyExists("repairSize", original.PropertyExists("repairSize"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<repairArea>");
            if (PropertyExists("repairParticleSystem"))
            {
                xmltextlines.Add(indent + "    <repairParticleSystem attr1=\"" + _repairParticleSystem + "\"/>"); 
            }
            if (PropertyExists("repairSoundID"))
            {
                xmltextlines.Add(indent + "    <repairSoundID attr1=\"" + _repairSoundID + "\"/>"); 
            }
            if (PropertyExists("maxRepairClass"))
            {
                xmltextlines.Add(indent + "    <maxRepairClass attr1=\"" + _maxRepairClass + "\"/>"); 
            }

            if (PropertyExists("repairPosition"))
            {
                xmltextlines.Add(indent + "    <repairPosition x=\"" + _repairPosition.x.ToString() + "\" y=\"" + _repairPosition.y.ToString() + "\" z=\"" + _repairPosition.z.ToString() + "\"/>");
            }
            if (PropertyExists("repairSize"))
            {
                xmltextlines.Add(indent + "    <repairSize x=\"" + _repairSize.x.ToString() + "\" y=\"" + _repairSize.y.ToString() + "\" z=\"" + _repairSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</repairArea>");
            return xmltextlines;
        }
    }

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
                            if (_position != null)
                            {
                                _position.OnElementChanged -= position_OnElementChanged;
                            }
                            _position = value;
                            if (_position != null)
                            {
                                _position.OnElementChanged += position_OnElementChanged;
                            }
                            SetPropertyEdited("position", true);
                            ParentDataFile.SetPropertyEdited("mine", true);
                        }
                    }
                }
            }
        }

        public void position_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("position", true);
                        ParentDataFile.SetPropertyEdited("mine", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= position_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += position_OnElementChanged;
                                break;
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
                            if (_linearVelocity != null)
                            {
                                _linearVelocity.OnElementChanged -= linearVelocity_OnElementChanged;
                            }
                            _linearVelocity = value;
                            if (_linearVelocity != null)
                            {
                                _linearVelocity.OnElementChanged += linearVelocity_OnElementChanged;
                            }
                            SetPropertyEdited("linearVelocity", true);
                            ParentDataFile.SetPropertyEdited("mine", true);
                        }
                    }
                }
            }
        }

        public void linearVelocity_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (ParentDataFile.Source != null)
                {
                    if (ParentDataFile.Source.WriteAccess)
                    {
                        SetPropertyEdited("linearVelocity", true);
                        ParentDataFile.SetPropertyEdited("mine", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= linearVelocity_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += linearVelocity_OnElementChanged;
                                break;
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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
        public mineDataStructure(VD2Data inParentDataFile, XmlNode inDataNode) : base(inParentDataFile, inDataNode)
        {
            _mineID = "";

            _position = new Vector3D();
            _position.OnElementChanged += position_OnElementChanged;
            _linearVelocity = new Vector3D();
            _linearVelocity.OnElementChanged += linearVelocity_OnElementChanged;

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
            SetPropertyExists("mineID", inCopyFrom.PropertyExists("mineID"));

            _position = new Vector3D(inCopyFrom.position);
            SetPropertyExists("position", inCopyFrom.PropertyExists("position"));
            _linearVelocity = new Vector3D(inCopyFrom.linearVelocity);
            SetPropertyExists("linearVelocity", inCopyFrom.PropertyExists("linearVelocity"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            mineDataStructure original = (mineDataStructure)inOriginal;
            _mineID = original.mineID;
            SetPropertyExists("mineID", original.PropertyExists("mineID"));

            _position = new Vector3D(original.position);
            SetPropertyExists("position", original.PropertyExists("position"));
            _linearVelocity = new Vector3D(original.linearVelocity);
            SetPropertyExists("linearVelocity", original.PropertyExists("linearVelocity"));

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

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<mine>");
            if (PropertyExists("mineID"))
            {
                xmltextlines.Add(indent + "    <mineID attr1=\"" + _mineID + "\"/>"); 
            }

            if (PropertyExists("position"))
            {
                xmltextlines.Add(indent + "    <position x=\"" + _position.x.ToString() + "\" y=\"" + _position.y.ToString() + "\" z=\"" + _position.z.ToString() + "\"/>");
            }
            if (PropertyExists("linearVelocity"))
            {
                xmltextlines.Add(indent + "    <linearVelocity x=\"" + _linearVelocity.x.ToString() + "\" y=\"" + _linearVelocity.y.ToString() + "\" z=\"" + _linearVelocity.z.ToString() + "\"/>");
            }

            xmltextlines.Add(indent + "</mine>");
            return xmltextlines;
        }
    }

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

        }

        //Only called when data does not exist to fill the data structure, datafile is given but data node is null in this case
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
            SetPropertyExists("damage", inCopyFrom.PropertyExists("damage"));
            _scale = inCopyFrom.scale;
            SetPropertyExists("scale", inCopyFrom.PropertyExists("scale"));

        }

        public override void CopyFrom(VD2DataStructure inOriginal)
        {
            damageCollisionFieldDataStructure original = (damageCollisionFieldDataStructure)inOriginal;
            _damage = original.damage;
            SetPropertyExists("damage", original.PropertyExists("damage"));
            _scale = original.scale;
            SetPropertyExists("scale", original.PropertyExists("scale"));

        }

        public override string ToString()
        {
            string result = "";
            result += _damage.ToString();
            result += ", ";
            result += _scale.ToString();
            return result;
        }

        public override List<string> AsVD2XML(int inIndent = 0)
        {
            List<string> xmltextlines = new List<string>();
            string indent = "";
            for (int i = 0; i < inIndent; i++)
            {
                indent += " ";
            }
            xmltextlines.Add(indent + "<damageCollisionField>");
            if (PropertyExists("damage"))
            {
                xmltextlines.Add(indent + "    <damage attr1=\"" + _damage.ToString() + "\"/>"); 
            }
            if (PropertyExists("scale"))
            {
                xmltextlines.Add(indent + "    <scale attr1=\"" + _scale.ToString() + "\"/>"); 
            }

            xmltextlines.Add(indent + "</damageCollisionField>");
            return xmltextlines;
        }
    }

}
