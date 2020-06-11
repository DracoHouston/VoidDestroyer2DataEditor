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
    public class OtherObjectData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _explosionID;
        string _collisionShape;
        string _gateInParticleSystem;
        string _gateOutParticleSystem;

        ObservableCollection<string> _descriptionText;

        int _rockSubPosition;

        float _health;
        float _cruiseSpeed;
        float _timeTillCruise;
        float _yaw;
        float _pitch;
        float _roll;

        bool _bNoShow;
        bool _bShowInTactical;
        bool _isMassInfinite;

        cargoBayDataStructure _cargoBay;
        gateCollisionDataStructure _gateCollision;

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

        [Description("gateInParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gateInParticleSystem
        {
            get
            {
                return _gateInParticleSystem;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _gateInParticleSystem = value;
                        SetPropertyEdited("gateInParticleSystem", true);
                    }
                }
            }
        }

        [Description("gateOutParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string gateOutParticleSystem
        {
            get
            {
                return _gateOutParticleSystem;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _gateOutParticleSystem = value;
                        SetPropertyEdited("gateOutParticleSystem", true);
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


        [Description("bNoShow is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoShow
        {
            get
            {
                return _bNoShow;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoShow = value;
                        SetPropertyEdited("bNoShow", true);
                    }
                }
            }
        }

        [Description("bShowInTactical is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bShowInTactical
        {
            get
            {
                return _bShowInTactical;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bShowInTactical = value;
                        SetPropertyEdited("bShowInTactical", true);
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


        [Browsable(false), Description("cargoBay is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public cargoBayDataStructure cargoBay
        {
            get
            {
                return _cargoBay;
            }
            set
            {
                _cargoBay = value;
            }
        }

        [Browsable(false), Description("gateCollision is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public gateCollisionDataStructure gateCollision
        {
            get
            {
                return _gateCollision;
            }
            set
            {
                _gateCollision = value;
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("explosionID");
            InitProperty("collisionShape");
            InitProperty("gateInParticleSystem");
            InitProperty("gateOutParticleSystem");

            InitProperty("descriptionText");
            SetPropertyIsCollection("descriptionText", true, typeof(string));

            InitProperty("rockSubPosition");

            InitProperty("health");
            InitProperty("cruiseSpeed");
            InitProperty("timeTillCruise");
            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("bNoShow");
            InitProperty("bShowInTactical");
            InitProperty("isMassInfinite");

            InitProperty("cargoBay");
            InitProperty("gateCollision");

        }

        public OtherObjectData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _gateInParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateInParticleSystem", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("gateInParticleSystem", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("gateInParticleSystem", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "gateInParticleSystem"));
                }
                SetPropertyExists("gateInParticleSystem", exists);
                _gateOutParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "gateOutParticleSystem", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("gateOutParticleSystem", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("gateOutParticleSystem", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "gateOutParticleSystem"));
                }
                SetPropertyExists("gateOutParticleSystem", exists);

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

                _bNoShow = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoShow", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoShow", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoShow", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoShow"));
                }
                SetPropertyExists("bNoShow", exists);
                _bShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bShowInTactical", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bShowInTactical", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bShowInTactical", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bShowInTactical"));
                }
                SetPropertyExists("bShowInTactical", exists);
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

                _cargoBay = DataStructureParseHelpers.GetcargoBayDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("cargoBay", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("cargoBay", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "cargoBay"));
                }
                SetPropertyExists("cargoBay", exists);
                _gateCollision = DataStructureParseHelpers.GetgateCollisionDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("gateCollision", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("gateCollision", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "gateCollision"));
                }
                SetPropertyExists("gateCollision", exists);

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
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("gateInParticleSystem"))
            {
                xmltextlines.Add("<gateInParticleSystem attr1=\"" + _gateInParticleSystem + "\"/>");
            }
            if (PropertyExists("gateOutParticleSystem"))
            {
                xmltextlines.Add("<gateOutParticleSystem attr1=\"" + _gateOutParticleSystem + "\"/>");
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

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("rockSubPosition"))
            {
                xmltextlines.Add("<rockSubPosition attr1=\"" + _rockSubPosition.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
            }
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

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bNoShow"))
            {
                xmltextlines.Add("<bNoShow attr1=\"" + ((_bNoShow) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bShowInTactical"))
            {
                xmltextlines.Add("<bShowInTactical attr1=\"" + ((_bShowInTactical) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("cargoBay"))
            {
                xmltextlines.AddRange(_cargoBay.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("gateCollision"))
            {
                xmltextlines.AddRange(_gateCollision.AsVD2XML());
                xmltextlines.Add("");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }
    }
}
