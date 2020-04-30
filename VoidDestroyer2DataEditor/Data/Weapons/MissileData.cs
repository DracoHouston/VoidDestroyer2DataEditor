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
    public class MissileData : VD2Data
    {
        string _objectType;
        string _objectID;
        string _name;
        string _missileType;
        string _meshName;
        string _ribbonID;
        string _trailParticleName;
        string _explosionID;
        string _missileParticleName;

        float _cruiseSpeed;
        float _timeTillCruise;
        float _initialVelocity;
        float _initialLife;
        float _timeTillActive;
        float _damage;
        float _health;
        float _yaw;
        float _pitch;
        float _roll;

        bool _bAntiCapital;
        bool _bSelfTarget;
        bool _bReAcquireTarget;

        Vector3D _missileSize;

        mirvDataStructure _mirv;

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

        [Description("missileType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string missileType
        {
            get
            {
                return _missileType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _missileType = value;
                        SetPropertyEdited("missileType", true);
                    }
                }
            }
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
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

        [Description("ribbonID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string ribbonID
        {
            get
            {
                return _ribbonID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ribbonID = value;
                        SetPropertyEdited("ribbonID", true);
                    }
                }
            }
        }

        [Description("trailParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string trailParticleName
        {
            get
            {
                return _trailParticleName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _trailParticleName = value;
                        SetPropertyEdited("trailParticleName", true);
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

        [Description("missileParticleName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string missileParticleName
        {
            get
            {
                return _missileParticleName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _missileParticleName = value;
                        SetPropertyEdited("missileParticleName", true);
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

        [Description("initialVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialVelocity
        {
            get
            {
                return _initialVelocity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _initialVelocity = value;
                        SetPropertyEdited("initialVelocity", true);
                    }
                }
            }
        }

        [Description("initialLife is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float initialLife
        {
            get
            {
                return _initialLife;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _initialLife = value;
                        SetPropertyEdited("initialLife", true);
                    }
                }
            }
        }

        [Description("timeTillActive is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float timeTillActive
        {
            get
            {
                return _timeTillActive;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _timeTillActive = value;
                        SetPropertyEdited("timeTillActive", true);
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

        [Description("bSelfTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSelfTarget
        {
            get
            {
                return _bSelfTarget;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bSelfTarget = value;
                        SetPropertyEdited("bSelfTarget", true);
                    }
                }
            }
        }

        [Description("bReAcquireTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bReAcquireTarget
        {
            get
            {
                return _bReAcquireTarget;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bReAcquireTarget = value;
                        SetPropertyEdited("bReAcquireTarget", true);
                    }
                }
            }
        }


        [Description("missileSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D missileSize
        {
            get
            {
                return _missileSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _missileSize.OnElementChanged -= missileSize_OnElementChanged;
                        _missileSize = value;
                        _missileSize.OnElementChanged += missileSize_OnElementChanged;
                        SetPropertyEdited("missileSize", true);
                    }
                }
            }
        }

        private void missileSize_OnElementChanged(object sender, Vector3DElementChangedEventArgs e)
        {
            if (sender is Vector3D)
            {
                Vector3D vecsender = (Vector3D)sender;
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        SetPropertyEdited("missileSize", true);
                    }
                    else
                    {
                        switch (e.ChangedElement)
                        {
                            case Vector3DElements.x:
                                vecsender.OnElementChanged -= missileSize_OnElementChanged;
                                vecsender.x = e.OldValue;
                                vecsender.OnElementChanged += missileSize_OnElementChanged;
                                break;
                            case Vector3DElements.y:
                                vecsender.OnElementChanged -= missileSize_OnElementChanged;
                                vecsender.y = e.OldValue;
                                vecsender.OnElementChanged += missileSize_OnElementChanged;
                                break;
                            case Vector3DElements.z:
                                vecsender.OnElementChanged -= missileSize_OnElementChanged;
                                vecsender.z = e.OldValue;
                                vecsender.OnElementChanged += missileSize_OnElementChanged;
                                break;
                        }
                    }
                }
            }
        }


        [Browsable(false), Description("mirv is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public mirvDataStructure mirv
        {
            get
            {
                return _mirv;
            }
            set
            {
                _mirv = value;
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("name");
            InitProperty("missileType");
            InitProperty("meshName");
            List<string> meshNamereftypes = new List<string>();
            meshNamereftypes.Add("Mesh");
            SetPropertyIsObjectIDRef("meshName", true, meshNamereftypes);
            InitProperty("ribbonID");
            List<string> ribbonIDreftypes = new List<string>();
            ribbonIDreftypes.Add("Effect");
            SetPropertyIsObjectIDRef("ribbonID", true, ribbonIDreftypes);
            InitProperty("trailParticleName");
            InitProperty("explosionID");
            List<string> explosionIDreftypes = new List<string>();
            explosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("explosionID", true, explosionIDreftypes);
            InitProperty("missileParticleName");

            InitProperty("cruiseSpeed");
            InitProperty("timeTillCruise");
            InitProperty("initialVelocity");
            InitProperty("initialLife");
            InitProperty("timeTillActive");
            InitProperty("damage");
            InitProperty("health");
            InitProperty("yaw");
            InitProperty("pitch");
            InitProperty("roll");

            InitProperty("bAntiCapital");
            InitProperty("bSelfTarget");
            InitProperty("bReAcquireTarget");

            InitProperty("missileSize");

            InitProperty("mirv");

        }

        public MissileData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _missileType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("missileType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("missileType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "missileType"));
                }
                SetPropertyExists("missileType", exists);
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
                _ribbonID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ribbonID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ribbonID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ribbonID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ribbonID"));
                }
                SetPropertyExists("ribbonID", exists);
                _trailParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "trailParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("trailParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("trailParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "trailParticleName"));
                }
                SetPropertyExists("trailParticleName", exists);
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
                _missileParticleName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "missileParticleName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("missileParticleName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("missileParticleName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "missileParticleName"));
                }
                SetPropertyExists("missileParticleName", exists);

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
                _initialVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialVelocity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("initialVelocity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("initialVelocity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "initialVelocity"));
                }
                SetPropertyExists("initialVelocity", exists);
                _initialLife = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "initialLife", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("initialLife", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("initialLife", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "initialLife"));
                }
                SetPropertyExists("initialLife", exists);
                _timeTillActive = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "timeTillActive", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("timeTillActive", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("timeTillActive", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "timeTillActive"));
                }
                SetPropertyExists("timeTillActive", exists);
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
                _bSelfTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSelfTarget", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bSelfTarget", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bSelfTarget", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bSelfTarget"));
                }
                SetPropertyExists("bSelfTarget", exists);
                _bReAcquireTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bReAcquireTarget", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bReAcquireTarget", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bReAcquireTarget", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bReAcquireTarget"));
                }
                SetPropertyExists("bReAcquireTarget", exists);

                _missileSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "missileSize", out exists);
                _missileSize.OnElementChanged += missileSize_OnElementChanged;
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("missileSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("missileSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "missileSize"));
                }
                SetPropertyExists("missileSize", exists);

                _mirv = DataStructureParseHelpers.GetmirvDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("mirv", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("mirv", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "mirv"));
                }
                SetPropertyExists("mirv", exists);

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
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("missileType"))
            {
                xmltextlines.Add("<missileType attr1=\"" + _missileType + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("ribbonID"))
            {
                xmltextlines.Add("<ribbonID attr1=\"" + _ribbonID + "\"/>");
            }
            if (PropertyExists("trailParticleName"))
            {
                xmltextlines.Add("<trailParticleName attr1=\"" + _trailParticleName + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("missileParticleName"))
            {
                xmltextlines.Add("<missileParticleName attr1=\"" + _missileParticleName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("cruiseSpeed"))
            {
                xmltextlines.Add("<cruiseSpeed attr1=\"" + _cruiseSpeed.ToString() + "\"/>");
            }
            if (PropertyExists("timeTillCruise"))
            {
                xmltextlines.Add("<timeTillCruise attr1=\"" + _timeTillCruise.ToString() + "\"/>");
            }
            if (PropertyExists("initialVelocity"))
            {
                xmltextlines.Add("<initialVelocity attr1=\"" + _initialVelocity.ToString() + "\"/>");
            }
            if (PropertyExists("initialLife"))
            {
                xmltextlines.Add("<initialLife attr1=\"" + _initialLife.ToString() + "\"/>");
            }
            if (PropertyExists("timeTillActive"))
            {
                xmltextlines.Add("<timeTillActive attr1=\"" + _timeTillActive.ToString() + "\"/>");
            }
            if (PropertyExists("damage"))
            {
                xmltextlines.Add("<damage attr1=\"" + _damage.ToString() + "\"/>");
            }
            if (PropertyExists("health"))
            {
                xmltextlines.Add("<health attr1=\"" + _health.ToString() + "\"/>");
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
            if (PropertyExists("bAntiCapital"))
            {
                xmltextlines.Add("<bAntiCapital attr1=\"" + ((_bAntiCapital) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bSelfTarget"))
            {
                xmltextlines.Add("<bSelfTarget attr1=\"" + ((_bSelfTarget) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bReAcquireTarget"))
            {
                xmltextlines.Add("<bReAcquireTarget attr1=\"" + ((_bReAcquireTarget) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("missileSize"))
            {
                xmltextlines.Add("<missileSize x=\"" + _missileSize.x.ToString() + "\" y=\"" + _missileSize.y.ToString() + "\" z=\"" + _missileSize.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("mirv"))
            {
                xmltextlines.AddRange(_mirv.AsVD2XML());
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
