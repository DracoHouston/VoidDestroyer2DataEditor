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
    public class DebrisData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _faction;
        string _descriptionText;
        string _collisionShape;
        string _explosionID;
        string _debrisSizeAsShipClass;

        float _health;
        float _timeToLive;
        float _minimumMomentum;
        float _minimumRotation;

        bool _isMassInfinite;
        bool _bCanAddViaBattleEditorSlider;

        ObservableCollection<VD2DataStructure> _turret;

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

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

        [Description("descriptionText is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string descriptionText
        {
            get
            {
                return _descriptionText;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _descriptionText = value;
                        SetPropertyEdited("descriptionText", true);
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

        [Description("explosionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

        [Description("debrisSizeAsShipClass is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string debrisSizeAsShipClass
        {
            get
            {
                return _debrisSizeAsShipClass;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _debrisSizeAsShipClass = value;
                        SetPropertyEdited("debrisSizeAsShipClass", true);
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

        [Description("timeToLive is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeToLive
        {
            get
            {
                return _timeToLive;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _timeToLive = value;
                        SetPropertyEdited("timeToLive", true);
                    }
                }
            }
        }

        [Description("minimumMomentum is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float minimumMomentum
        {
            get
            {
                return _minimumMomentum;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _minimumMomentum = value;
                        SetPropertyEdited("minimumMomentum", true);
                    }
                }
            }
        }

        [Description("minimumRotation is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float minimumRotation
        {
            get
            {
                return _minimumRotation;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _minimumRotation = value;
                        SetPropertyEdited("minimumRotation", true);
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

        [Description("bCanAddViaBattleEditorSlider is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCanAddViaBattleEditorSlider
        {
            get
            {
                return _bCanAddViaBattleEditorSlider;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCanAddViaBattleEditorSlider = value;
                        SetPropertyEdited("bCanAddViaBattleEditorSlider", true);
                    }
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

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("meshName");
            InitProperty("faction");
            InitProperty("descriptionText");
            InitProperty("collisionShape");
            InitProperty("explosionID");
            InitProperty("debrisSizeAsShipClass");

            InitProperty("health");
            InitProperty("timeToLive");
            InitProperty("minimumMomentum");
            InitProperty("minimumRotation");

            InitProperty("isMassInfinite");
            InitProperty("bCanAddViaBattleEditorSlider");

            InitProperty("turret");
            SetPropertyIsCollection("turret", true, typeof(turretDataStructure));
        }

        public DebrisData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _descriptionText = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "descriptionText", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("descriptionText", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("descriptionText", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "descriptionText"));
                }
                SetPropertyExists("descriptionText", exists);
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
                _debrisSizeAsShipClass = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "debrisSizeAsShipClass", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("debrisSizeAsShipClass", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("debrisSizeAsShipClass", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "debrisSizeAsShipClass"));
                }
                SetPropertyExists("debrisSizeAsShipClass", exists);

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
                _timeToLive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeToLive", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("timeToLive", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("timeToLive", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "timeToLive"));
                }
                SetPropertyExists("timeToLive", exists);
                _minimumMomentum = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumMomentum", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("minimumMomentum", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("minimumMomentum", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "minimumMomentum"));
                }
                SetPropertyExists("minimumMomentum", exists);
                _minimumRotation = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "minimumRotation", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("minimumRotation", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("minimumRotation", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "minimumRotation"));
                }
                SetPropertyExists("minimumRotation", exists);

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
                _bCanAddViaBattleEditorSlider = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCanAddViaBattleEditorSlider", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCanAddViaBattleEditorSlider", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCanAddViaBattleEditorSlider"));
                }
                SetPropertyExists("bCanAddViaBattleEditorSlider", exists);

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
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("faction"))
            {
                xmltextlines.Add("<faction attr1=\"" + _faction + "\"/>");
            }
            if (PropertyExists("descriptionText"))
            {
                xmltextlines.Add("<descriptionText attr1=\"" + _descriptionText + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("debrisSizeAsShipClass"))
            {
                xmltextlines.Add("<debrisSizeAsShipClass attr1=\"" + _debrisSizeAsShipClass + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
            }
            if (PropertyExists("timeToLive"))
            {
                xmltextlines.Add("<timeToLive attr1=\"" + _timeToLive.ToString() + "\"/>");
            }
            if (PropertyExists("minimumMomentum"))
            {
                xmltextlines.Add("<minimumMomentum attr1=\"" + _minimumMomentum.ToString() + "\"/>");
            }
            if (PropertyExists("minimumRotation"))
            {
                xmltextlines.Add("<minimumRotation attr1=\"" + _minimumRotation.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanAddViaBattleEditorSlider"))
            {
                xmltextlines.Add("<bCanAddViaBattleEditorSlider attr1=\"" + ((_bCanAddViaBattleEditorSlider) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("turret"))
            {
                foreach (turretDataStructure result in _turret)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
