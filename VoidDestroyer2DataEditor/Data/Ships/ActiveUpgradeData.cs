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
    public class ActiveUpgradeData : VD2Data
    {
        string _displayName;
        string _objectID;
        string _upgradeCategory;
        string _upgradeType;
        string _shipActiveUpgradeType;
        string _imageSet;
        string _image;
        string _particleSystemName;
        string _shieldObjectID;
        string _activeSoundID;
        string _missileID;
        string _platformObjectID;
        string _shipID;

        ObservableCollection<string> _description;

        int _cost;
        int _rechargeTime;

        float _addCostAsPercentOfShip;
        float _durationTime;
        float _healthShieldRechargePercent;
        float _maneuveringMultiplier;

        bool _bIllegalUpgrade;
        bool _bOneAtATimeUpgrade;
        bool _bAlwaysAvailableUpgrade;

        [Description("displayName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _displayName = value;
                        SetPropertyEdited("displayName", true);
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

        [Description("upgradeCategory is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string upgradeCategory
        {
            get
            {
                return _upgradeCategory;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _upgradeCategory = value;
                        SetPropertyEdited("upgradeCategory", true);
                    }
                }
            }
        }

        [Description("upgradeType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string upgradeType
        {
            get
            {
                return _upgradeType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _upgradeType = value;
                        SetPropertyEdited("upgradeType", true);
                    }
                }
            }
        }

        [Description("shipActiveUpgradeType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shipActiveUpgradeType
        {
            get
            {
                return _shipActiveUpgradeType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipActiveUpgradeType = value;
                        SetPropertyEdited("shipActiveUpgradeType", true);
                    }
                }
            }
        }

        [Description("imageSet is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string imageSet
        {
            get
            {
                return _imageSet;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _imageSet = value;
                        SetPropertyEdited("imageSet", true);
                    }
                }
            }
        }

        [Description("image is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string image
        {
            get
            {
                return _image;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _image = value;
                        SetPropertyEdited("image", true);
                    }
                }
            }
        }

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string particleSystemName
        {
            get
            {
                return _particleSystemName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _particleSystemName = value;
                        SetPropertyEdited("particleSystemName", true);
                    }
                }
            }
        }

        [Description("shieldObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string shieldObjectID
        {
            get
            {
                return _shieldObjectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldObjectID = value;
                        SetPropertyEdited("shieldObjectID", true);
                    }
                }
            }
        }

        [Description("activeSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string activeSoundID
        {
            get
            {
                return _activeSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _activeSoundID = value;
                        SetPropertyEdited("activeSoundID", true);
                    }
                }
            }
        }

        [Description("missileID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string missileID
        {
            get
            {
                return _missileID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _missileID = value;
                        SetPropertyEdited("missileID", true);
                    }
                }
            }
        }

        [Description("platformObjectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string platformObjectID
        {
            get
            {
                return _platformObjectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _platformObjectID = value;
                        SetPropertyEdited("platformObjectID", true);
                    }
                }
            }
        }

        [Description("shipID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string shipID
        {
            get
            {
                return _shipID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shipID = value;
                        SetPropertyEdited("shipID", true);
                    }
                }
            }
        }


        [Browsable(false), Description("description is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != null)
                {
                    _description.CollectionChanged -= OndescriptionChanged;
                }
                _description = value;
                if (_description != null)
                {
                    _description.CollectionChanged += OndescriptionChanged;
                }
            }
        }

        private void OndescriptionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("description", true);
                }
                else
                {
                    bool exists = false;
                    _description = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists));
                    _description.CollectionChanged += OndescriptionChanged;
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("description", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("description", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "description"));
                    }
                    SetPropertyExists("description", exists);
                }
            }
        }


        [Description("cost is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _cost = value;
                        SetPropertyEdited("cost", true);
                    }
                }
            }
        }

        [Description("rechargeTime is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rechargeTime
        {
            get
            {
                return _rechargeTime;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _rechargeTime = value;
                        SetPropertyEdited("rechargeTime", true);
                    }
                }
            }
        }


        [Description("addCostAsPercentOfShip is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float addCostAsPercentOfShip
        {
            get
            {
                return _addCostAsPercentOfShip;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _addCostAsPercentOfShip = value;
                        SetPropertyEdited("addCostAsPercentOfShip", true);
                    }
                }
            }
        }

        [Description("durationTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float durationTime
        {
            get
            {
                return _durationTime;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _durationTime = value;
                        SetPropertyEdited("durationTime", true);
                    }
                }
            }
        }

        [Description("healthShieldRechargePercent is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float healthShieldRechargePercent
        {
            get
            {
                return _healthShieldRechargePercent;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _healthShieldRechargePercent = value;
                        SetPropertyEdited("healthShieldRechargePercent", true);
                    }
                }
            }
        }

        [Description("maneuveringMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float maneuveringMultiplier
        {
            get
            {
                return _maneuveringMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maneuveringMultiplier = value;
                        SetPropertyEdited("maneuveringMultiplier", true);
                    }
                }
            }
        }


        [Description("bIllegalUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bIllegalUpgrade
        {
            get
            {
                return _bIllegalUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bIllegalUpgrade = value;
                        SetPropertyEdited("bIllegalUpgrade", true);
                    }
                }
            }
        }

        [Description("bOneAtATimeUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOneAtATimeUpgrade
        {
            get
            {
                return _bOneAtATimeUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bOneAtATimeUpgrade = value;
                        SetPropertyEdited("bOneAtATimeUpgrade", true);
                    }
                }
            }
        }

        [Description("bAlwaysAvailableUpgrade is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAlwaysAvailableUpgrade
        {
            get
            {
                return _bAlwaysAvailableUpgrade;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAlwaysAvailableUpgrade = value;
                        SetPropertyEdited("bAlwaysAvailableUpgrade", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("displayName");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("upgradeCategory");
            InitProperty("upgradeType");
            InitProperty("shipActiveUpgradeType");
            InitProperty("imageSet");
            InitProperty("image");
            InitProperty("particleSystemName");
            List<string> particleSystemNamereftypes = new List<string>();
            particleSystemNamereftypes.Add("Particle");
            SetPropertyIsObjectIDRef("particleSystemName", true, particleSystemNamereftypes);
            InitProperty("shieldObjectID");
            List<string> shieldObjectIDreftypes = new List<string>();
            shieldObjectIDreftypes.Add("Shield");
            SetPropertyIsObjectIDRef("shieldObjectID", true, shieldObjectIDreftypes);
            InitProperty("activeSoundID");
            List<string> activeSoundIDreftypes = new List<string>();
            activeSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("activeSoundID", true, activeSoundIDreftypes);
            InitProperty("missileID");
            List<string> missileIDreftypes = new List<string>();
            missileIDreftypes.Add("Missile");
            SetPropertyIsObjectIDRef("missileID", true, missileIDreftypes);
            InitProperty("platformObjectID");
            List<string> platformObjectIDreftypes = new List<string>();
            platformObjectIDreftypes.Add("Station");
            SetPropertyIsObjectIDRef("platformObjectID", true, platformObjectIDreftypes);
            InitProperty("shipID");
            List<string> shipIDreftypes = new List<string>();
            shipIDreftypes.Add("Ship");
            SetPropertyIsObjectIDRef("shipID", true, shipIDreftypes);

            InitProperty("description");
            SetPropertyIsCollection("description", true, typeof(string));

            InitProperty("cost");
            InitProperty("rechargeTime");

            InitProperty("addCostAsPercentOfShip");
            InitProperty("durationTime");
            InitProperty("healthShieldRechargePercent");
            InitProperty("maneuveringMultiplier");

            InitProperty("bIllegalUpgrade");
            InitProperty("bOneAtATimeUpgrade");
            InitProperty("bAlwaysAvailableUpgrade");

        }

        public ActiveUpgradeData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _displayName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "displayName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("displayName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("displayName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "displayName"));
                }
                SetPropertyExists("displayName", exists);
                _upgradeCategory = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeCategory", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upgradeCategory", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upgradeCategory", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upgradeCategory"));
                }
                SetPropertyExists("upgradeCategory", exists);
                _upgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "upgradeType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("upgradeType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("upgradeType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "upgradeType"));
                }
                SetPropertyExists("upgradeType", exists);
                _shipActiveUpgradeType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipActiveUpgradeType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipActiveUpgradeType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipActiveUpgradeType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipActiveUpgradeType"));
                }
                SetPropertyExists("shipActiveUpgradeType", exists);
                _imageSet = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSet", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("imageSet", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("imageSet", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "imageSet"));
                }
                SetPropertyExists("imageSet", exists);
                _image = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "image", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("image", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("image", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "image"));
                }
                SetPropertyExists("image", exists);
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("particleSystemName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("particleSystemName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "particleSystemName"));
                }
                SetPropertyExists("particleSystemName", exists);
                _shieldObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldObjectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldObjectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldObjectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldObjectID"));
                }
                SetPropertyExists("shieldObjectID", exists);
                _activeSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "activeSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("activeSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("activeSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "activeSoundID"));
                }
                SetPropertyExists("activeSoundID", exists);
                _missileID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("missileID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("missileID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "missileID"));
                }
                SetPropertyExists("missileID", exists);
                _platformObjectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "platformObjectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("platformObjectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("platformObjectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "platformObjectID"));
                }
                SetPropertyExists("platformObjectID", exists);
                _shipID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shipID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shipID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shipID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shipID"));
                }
                SetPropertyExists("shipID", exists);

                _description = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "description", out exists));
                _description.CollectionChanged += OndescriptionChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("description", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("description", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "description"));
                }
                SetPropertyExists("description", exists);

                _cost = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "cost", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cost", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cost", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cost"));
                }
                SetPropertyExists("cost", exists);
                _rechargeTime = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rechargeTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rechargeTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rechargeTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rechargeTime"));
                }
                SetPropertyExists("rechargeTime", exists);

                _addCostAsPercentOfShip = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "addCostAsPercentOfShip", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("addCostAsPercentOfShip", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("addCostAsPercentOfShip", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "addCostAsPercentOfShip"));
                }
                SetPropertyExists("addCostAsPercentOfShip", exists);
                _durationTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "durationTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("durationTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("durationTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "durationTime"));
                }
                SetPropertyExists("durationTime", exists);
                _healthShieldRechargePercent = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "healthShieldRechargePercent", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("healthShieldRechargePercent", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("healthShieldRechargePercent", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "healthShieldRechargePercent"));
                }
                SetPropertyExists("healthShieldRechargePercent", exists);
                _maneuveringMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "maneuveringMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maneuveringMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maneuveringMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maneuveringMultiplier"));
                }
                SetPropertyExists("maneuveringMultiplier", exists);

                _bIllegalUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bIllegalUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bIllegalUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bIllegalUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bIllegalUpgrade"));
                }
                SetPropertyExists("bIllegalUpgrade", exists);
                _bOneAtATimeUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOneAtATimeUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bOneAtATimeUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bOneAtATimeUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bOneAtATimeUpgrade"));
                }
                SetPropertyExists("bOneAtATimeUpgrade", exists);
                _bAlwaysAvailableUpgrade = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysAvailableUpgrade", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAlwaysAvailableUpgrade", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAlwaysAvailableUpgrade"));
                }
                SetPropertyExists("bAlwaysAvailableUpgrade", exists);

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
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("upgradeCategory"))
            {
                xmltextlines.Add("<upgradeCategory attr1=\"" + _upgradeCategory + "\"/>");
            }
            if (PropertyExists("upgradeType"))
            {
                xmltextlines.Add("<upgradeType attr1=\"" + _upgradeType + "\"/>");
            }
            if (PropertyExists("shipActiveUpgradeType"))
            {
                xmltextlines.Add("<shipActiveUpgradeType attr1=\"" + _shipActiveUpgradeType + "\"/>");
            }
            if (PropertyExists("imageSet"))
            {
                xmltextlines.Add("<imageSet attr1=\"" + _imageSet + "\"/>");
            }
            if (PropertyExists("image"))
            {
                xmltextlines.Add("<image attr1=\"" + _image + "\"/>");
            }
            if (PropertyExists("particleSystemName"))
            {
                xmltextlines.Add("<particleSystemName attr1=\"" + _particleSystemName + "\"/>");
            }
            if (PropertyExists("shieldObjectID"))
            {
                xmltextlines.Add("<shieldObjectID attr1=\"" + _shieldObjectID + "\"/>");
            }
            if (PropertyExists("activeSoundID"))
            {
                xmltextlines.Add("<activeSoundID attr1=\"" + _activeSoundID + "\"/>");
            }
            if (PropertyExists("missileID"))
            {
                xmltextlines.Add("<missileID attr1=\"" + _missileID + "\"/>");
            }
            if (PropertyExists("platformObjectID"))
            {
                xmltextlines.Add("<platformObjectID attr1=\"" + _platformObjectID + "\"/>");
            }
            if (PropertyExists("shipID"))
            {
                xmltextlines.Add("<shipID attr1=\"" + _shipID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("description"))
            {
                foreach (string result in _description)
                {
                    xmltextlines.Add("<description attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("cost"))
            {
                xmltextlines.Add("<cost attr1=\"" + _cost.ToString() + "\"/>");
            }
            if (PropertyExists("rechargeTime"))
            {
                xmltextlines.Add("<rechargeTime attr1=\"" + _rechargeTime.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("addCostAsPercentOfShip"))
            {
                xmltextlines.Add("<addCostAsPercentOfShip attr1=\"" + _addCostAsPercentOfShip.ToString() + "\"/>");
            }
            if (PropertyExists("durationTime"))
            {
                xmltextlines.Add("<durationTime attr1=\"" + _durationTime.ToString() + "\"/>");
            }
            if (PropertyExists("healthShieldRechargePercent"))
            {
                xmltextlines.Add("<healthShieldRechargePercent attr1=\"" + _healthShieldRechargePercent.ToString() + "\"/>");
            }
            if (PropertyExists("maneuveringMultiplier"))
            {
                xmltextlines.Add("<maneuveringMultiplier attr1=\"" + _maneuveringMultiplier.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bIllegalUpgrade"))
            {
                xmltextlines.Add("<bIllegalUpgrade attr1=\"" + ((_bIllegalUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bOneAtATimeUpgrade"))
            {
                xmltextlines.Add("<bOneAtATimeUpgrade attr1=\"" + ((_bOneAtATimeUpgrade) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bAlwaysAvailableUpgrade"))
            {
                xmltextlines.Add("<bAlwaysAvailableUpgrade attr1=\"" + ((_bAlwaysAvailableUpgrade) ? "1" : "0") + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
