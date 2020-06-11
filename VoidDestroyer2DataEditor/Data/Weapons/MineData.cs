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
    public class MineData : VD2Data
    {
        string _objectType;
        string _mineType;
        string _objectID;
        string _meshName;
        string _explosionID;
        string _minimumShipClass;

        int _detectionProximity;
        int _weaponPush;
        int _renderingDistance;

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

        bool _bUseParentTarget;
        bool _bSpinner;
        bool _bKeepTarget;
        bool _bCheckFriendOrFoe;
        bool _bCanAddViaBattleEditorSlider;
        bool _bIgnoresShields;
        bool _bHeatMine;

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

        [Description("mineType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string mineType
        {
            get
            {
                return _mineType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _mineType = value;
                        SetPropertyEdited("mineType", true);
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


        [Description("detectionProximity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int detectionProximity
        {
            get
            {
                return _detectionProximity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _detectionProximity = value;
                        SetPropertyEdited("detectionProximity", true);
                    }
                }
            }
        }

        [Description("weaponPush is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int weaponPush
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

        [Description("renderingDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int renderingDistance
        {
            get
            {
                return _renderingDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _renderingDistance = value;
                        SetPropertyEdited("renderingDistance", true);
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


        [Description("bUseParentTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bUseParentTarget
        {
            get
            {
                return _bUseParentTarget;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bUseParentTarget = value;
                        SetPropertyEdited("bUseParentTarget", true);
                    }
                }
            }
        }

        [Description("bSpinner is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bSpinner
        {
            get
            {
                return _bSpinner;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bSpinner = value;
                        SetPropertyEdited("bSpinner", true);
                    }
                }
            }
        }

        [Description("bKeepTarget is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bKeepTarget
        {
            get
            {
                return _bKeepTarget;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bKeepTarget = value;
                        SetPropertyEdited("bKeepTarget", true);
                    }
                }
            }
        }

        [Description("bCheckFriendOrFoe is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCheckFriendOrFoe
        {
            get
            {
                return _bCheckFriendOrFoe;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCheckFriendOrFoe = value;
                        SetPropertyEdited("bCheckFriendOrFoe", true);
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

        [Description("bHeatMine is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bHeatMine
        {
            get
            {
                return _bHeatMine;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bHeatMine = value;
                        SetPropertyEdited("bHeatMine", true);
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
            InitProperty("mineType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("meshName");
            List<string> meshNamereftypes = new List<string>();
            meshNamereftypes.Add("Mesh");
            SetPropertyIsObjectIDRef("meshName", true, meshNamereftypes);
            InitProperty("explosionID");
            List<string> explosionIDreftypes = new List<string>();
            explosionIDreftypes.Add("Explosion");
            SetPropertyIsObjectIDRef("explosionID", true, explosionIDreftypes);
            InitProperty("minimumShipClass");

            InitProperty("detectionProximity");
            InitProperty("weaponPush");
            InitProperty("renderingDistance");

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

            InitProperty("bUseParentTarget");
            InitProperty("bSpinner");
            InitProperty("bKeepTarget");
            InitProperty("bCheckFriendOrFoe");
            InitProperty("bCanAddViaBattleEditorSlider");
            InitProperty("bIgnoresShields");
            InitProperty("bHeatMine");

            InitProperty("mirv");

        }

        public MineData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _mineType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "mineType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("mineType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("mineType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "mineType"));
                }
                SetPropertyExists("mineType", exists);
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

                _detectionProximity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "detectionProximity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("detectionProximity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("detectionProximity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "detectionProximity"));
                }
                SetPropertyExists("detectionProximity", exists);
                _weaponPush = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "weaponPush", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponPush", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponPush", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponPush"));
                }
                SetPropertyExists("weaponPush", exists);
                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("renderingDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("renderingDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "renderingDistance"));
                }
                SetPropertyExists("renderingDistance", exists);

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

                _bUseParentTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bUseParentTarget", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bUseParentTarget", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bUseParentTarget", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bUseParentTarget"));
                }
                SetPropertyExists("bUseParentTarget", exists);
                _bSpinner = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bSpinner", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bSpinner", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bSpinner", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bSpinner"));
                }
                SetPropertyExists("bSpinner", exists);
                _bKeepTarget = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bKeepTarget", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bKeepTarget", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bKeepTarget", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bKeepTarget"));
                }
                SetPropertyExists("bKeepTarget", exists);
                _bCheckFriendOrFoe = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCheckFriendOrFoe", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCheckFriendOrFoe", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCheckFriendOrFoe", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCheckFriendOrFoe"));
                }
                SetPropertyExists("bCheckFriendOrFoe", exists);
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
                _bHeatMine = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bHeatMine", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bHeatMine", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bHeatMine", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bHeatMine"));
                }
                SetPropertyExists("bHeatMine", exists);

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
            if (PropertyExists("mineType"))
            {
                xmltextlines.Add("<mineType attr1=\"" + _mineType + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("explosionID"))
            {
                xmltextlines.Add("<explosionID attr1=\"" + _explosionID + "\"/>");
            }
            if (PropertyExists("minimumShipClass"))
            {
                xmltextlines.Add("<minimumShipClass attr1=\"" + _minimumShipClass + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("detectionProximity"))
            {
                xmltextlines.Add("<detectionProximity attr1=\"" + _detectionProximity.ToString() + "\"/>");
            }
            if (PropertyExists("weaponPush"))
            {
                xmltextlines.Add("<weaponPush attr1=\"" + _weaponPush.ToString() + "\"/>");
            }
            if (PropertyExists("renderingDistance"))
            {
                xmltextlines.Add("<renderingDistance attr1=\"" + _renderingDistance.ToString() + "\"/>");
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
            if (PropertyExists("bUseParentTarget"))
            {
                xmltextlines.Add("<bUseParentTarget attr1=\"" + ((_bUseParentTarget) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bSpinner"))
            {
                xmltextlines.Add("<bSpinner attr1=\"" + ((_bSpinner) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bKeepTarget"))
            {
                xmltextlines.Add("<bKeepTarget attr1=\"" + ((_bKeepTarget) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCheckFriendOrFoe"))
            {
                xmltextlines.Add("<bCheckFriendOrFoe attr1=\"" + ((_bCheckFriendOrFoe) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bCanAddViaBattleEditorSlider"))
            {
                xmltextlines.Add("<bCanAddViaBattleEditorSlider attr1=\"" + ((_bCanAddViaBattleEditorSlider) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bIgnoresShields"))
            {
                xmltextlines.Add("<bIgnoresShields attr1=\"" + ((_bIgnoresShields) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bHeatMine"))
            {
                xmltextlines.Add("<bHeatMine attr1=\"" + ((_bHeatMine) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("mirv"))
            {
                xmltextlines.AddRange(_mirv.AsVD2XML());
                xmltextlines.Add("");
            }

            SafeWriteAllLines(_FilePath, xmltextlines);
        }
    }
}
