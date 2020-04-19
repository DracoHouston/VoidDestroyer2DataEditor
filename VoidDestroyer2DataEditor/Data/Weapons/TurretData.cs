using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    public class TurretData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _name;
        string _turretWeapon;
        string _hardpointID;
        string _linkedMovingElement;
        string _meshName;
        string _turnSoundID;

        int _mineQuota;

        float _barrelDelay;
        float _pitchMax;
        float _dMoveSpeed;

        bool _bAlwaysShowInTactical;
        bool _bPhysicalBody;
        bool _bInvisibleTurret;
        bool _bOssilateTargetAimNodeOffset;

        Vector3D _turretViewPos;

        weaponDirectionDataStructure _weaponDirection;
        targetPriorityListDataStructure _targetPriorityList;

        ObservableCollection<turretBarrelDataStructure> _turretBarrel;

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

        [Description("turretWeapon is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turretWeapon
        {
            get
            {
                return _turretWeapon;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _turretWeapon = value;
                        SetPropertyEdited("turretWeapon", true);
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _hardpointID = value;
                        SetPropertyEdited("hardpointID", true);
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

        [Description("turnSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string turnSoundID
        {
            get
            {
                return _turnSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _turnSoundID = value;
                        SetPropertyEdited("turnSoundID", true);
                    }
                }
            }
        }


        [Description("mineQuota is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int mineQuota
        {
            get
            {
                return _mineQuota;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _mineQuota = value;
                        SetPropertyEdited("mineQuota", true);
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _barrelDelay = value;
                        SetPropertyEdited("barrelDelay", true);
                    }
                }
            }
        }

        [Description("pitchMax is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float pitchMax
        {
            get
            {
                return _pitchMax;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _pitchMax = value;
                        SetPropertyEdited("pitchMax", true);
                    }
                }
            }
        }

        [Description("dMoveSpeed is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float dMoveSpeed
        {
            get
            {
                return _dMoveSpeed;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _dMoveSpeed = value;
                        SetPropertyEdited("dMoveSpeed", true);
                    }
                }
            }
        }


        [Description("bAlwaysShowInTactical is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bAlwaysShowInTactical
        {
            get
            {
                return _bAlwaysShowInTactical;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bAlwaysShowInTactical = value;
                        SetPropertyEdited("bAlwaysShowInTactical", true);
                    }
                }
            }
        }

        [Description("bPhysicalBody is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPhysicalBody
        {
            get
            {
                return _bPhysicalBody;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPhysicalBody = value;
                        SetPropertyEdited("bPhysicalBody", true);
                    }
                }
            }
        }

        [Description("bInvisibleTurret is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bInvisibleTurret
        {
            get
            {
                return _bInvisibleTurret;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bInvisibleTurret = value;
                        SetPropertyEdited("bInvisibleTurret", true);
                    }
                }
            }
        }

        [Description("bOssilateTargetAimNodeOffset is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOssilateTargetAimNodeOffset
        {
            get
            {
                return _bOssilateTargetAimNodeOffset;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bOssilateTargetAimNodeOffset = value;
                        SetPropertyEdited("bOssilateTargetAimNodeOffset", true);
                    }
                }
            }
        }


        [Description("turretViewPos is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D turretViewPos
        {
            get
            {
                return _turretViewPos;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _turretViewPos = value;
                        SetPropertyEdited("turretViewPos", true);
                    }
                }
            }
        }


        [Description("weaponDirection is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public weaponDirectionDataStructure weaponDirection
        {
            get
            {
                return _weaponDirection;
            }
            set
            {
                _weaponDirection = value;
            }
        }

        [Description("targetPriorityList is a datastructure"), Category("Data Structures"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public targetPriorityListDataStructure targetPriorityList
        {
            get
            {
                return _targetPriorityList;
            }
            set
            {
                _targetPriorityList = value;
            }
        }


        [Description("turretBarrel is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<turretBarrelDataStructure> turretBarrel
        {
            get
            {
                return _turretBarrel;
            }
            set
            {
                _turretBarrel = value;
            }
        }

        private void OnturretBarrelChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("turretBarrel", true);
                }
                else
                {
                    bool exists = false;
                    _turretBarrel = new ObservableCollection<turretBarrelDataStructure>(DataStructureParseHelpers.GetturretBarrelDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _turretBarrel.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretBarrelChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("turretBarrel", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("turretBarrel", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turretBarrel"));
                    }
                    SetPropertyExists("turretBarrel", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            SetPropertyIsObjectID("weaponID", true);
            InitProperty("name");
            InitProperty("turretWeapon");
            InitProperty("hardpointID");
            InitProperty("linkedMovingElement");
            InitProperty("meshName");
            InitProperty("turnSoundID");

            InitProperty("mineQuota");

            InitProperty("barrelDelay");
            InitProperty("pitchMax");
            InitProperty("dMoveSpeed");

            InitProperty("bAlwaysShowInTactical");
            InitProperty("bPhysicalBody");
            InitProperty("bInvisibleTurret");
            InitProperty("bOssilateTargetAimNodeOffset");

            InitProperty("turretViewPos");

            InitProperty("weaponDirection");
            InitProperty("targetPriorityList");

            InitProperty("turretBarrel");
        }

        public TurretData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _turretWeapon = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turretWeapon", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turretWeapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turretWeapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turretWeapon"));
                }
                SetPropertyExists("turretWeapon", exists);
                _hardpointID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hardpointID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("hardpointID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("hardpointID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "hardpointID"));
                }
                SetPropertyExists("hardpointID", exists);
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
                _turnSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turnSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turnSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turnSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turnSoundID"));
                }
                SetPropertyExists("turnSoundID", exists);

                _mineQuota = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "mineQuota", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("mineQuota", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("mineQuota", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "mineQuota"));
                }
                SetPropertyExists("mineQuota", exists);

                _barrelDelay = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "barrelDelay", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("barrelDelay", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("barrelDelay", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "barrelDelay"));
                }
                SetPropertyExists("barrelDelay", exists);
                _pitchMax = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitchMax", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("pitchMax", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("pitchMax", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "pitchMax"));
                }
                SetPropertyExists("pitchMax", exists);
                _dMoveSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "dMoveSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("dMoveSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("dMoveSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "dMoveSpeed"));
                }
                SetPropertyExists("dMoveSpeed", exists);

                _bAlwaysShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysShowInTactical", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bAlwaysShowInTactical", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bAlwaysShowInTactical", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bAlwaysShowInTactical"));
                }
                SetPropertyExists("bAlwaysShowInTactical", exists);
                _bPhysicalBody = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalBody", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPhysicalBody", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPhysicalBody", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPhysicalBody"));
                }
                SetPropertyExists("bPhysicalBody", exists);
                _bInvisibleTurret = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisibleTurret", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bInvisibleTurret", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bInvisibleTurret", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bInvisibleTurret"));
                }
                SetPropertyExists("bInvisibleTurret", exists);
                _bOssilateTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOssilateTargetAimNodeOffset", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bOssilateTargetAimNodeOffset", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bOssilateTargetAimNodeOffset", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bOssilateTargetAimNodeOffset"));
                }
                SetPropertyExists("bOssilateTargetAimNodeOffset", exists);

                _turretViewPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "turretViewPos", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turretViewPos", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turretViewPos", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turretViewPos"));
                }
                SetPropertyExists("turretViewPos", exists);

                _weaponDirection = DataStructureParseHelpers.GetweaponDirectionDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponDirection", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponDirection", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponDirection"));
                }
                SetPropertyExists("weaponDirection", exists);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(this, DataXMLDoc, out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("targetPriorityList", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("targetPriorityList", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "targetPriorityList"));
                }
                SetPropertyExists("targetPriorityList", exists);

                _turretBarrel =  new ObservableCollection<turretBarrelDataStructure>(DataStructureParseHelpers.GetturretBarrelDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _turretBarrel.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnturretBarrelChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("turretBarrel", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("turretBarrel", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "turretBarrel"));
                }
                SetPropertyExists("turretBarrel", exists);
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
            if (PropertyExists("turretWeapon"))
            {
                xmltextlines.Add("<turretWeapon attr1=\"" + _turretWeapon + "\"/>");
            }
            if (PropertyExists("hardpointID"))
            {
                xmltextlines.Add("<hardpointID attr1=\"" + _hardpointID + "\"/>");
            }
            if (PropertyExists("linkedMovingElement"))
            {
                xmltextlines.Add("<linkedMovingElement attr1=\"" + _linkedMovingElement + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("turnSoundID"))
            {
                xmltextlines.Add("<turnSoundID attr1=\"" + _turnSoundID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("mineQuota"))
            {
                xmltextlines.Add("<mineQuota attr1=\"" + _mineQuota.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("barrelDelay"))
            {
                xmltextlines.Add("<barrelDelay attr1=\"" + _barrelDelay.ToString() + "\"/>");
            }
            if (PropertyExists("pitchMax"))
            {
                xmltextlines.Add("<pitchMax attr1=\"" + _pitchMax.ToString() + "\"/>");
            }
            if (PropertyExists("dMoveSpeed"))
            {
                xmltextlines.Add("<dMoveSpeed attr1=\"" + _dMoveSpeed.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bAlwaysShowInTactical"))
            {
                xmltextlines.Add("<bAlwaysShowInTactical attr1=\"" + ((_bAlwaysShowInTactical) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bPhysicalBody"))
            {
                xmltextlines.Add("<bPhysicalBody attr1=\"" + ((_bPhysicalBody) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bInvisibleTurret"))
            {
                xmltextlines.Add("<bInvisibleTurret attr1=\"" + ((_bInvisibleTurret) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bOssilateTargetAimNodeOffset"))
            {
                xmltextlines.Add("<bOssilateTargetAimNodeOffset attr1=\"" + ((_bOssilateTargetAimNodeOffset) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("turretViewPos"))
            {
                xmltextlines.Add("<turretViewPos x=\"" + _turretViewPos.x.ToString() + "\" y=\"" + _turretViewPos.y.ToString() + "\" z=\"" + _turretViewPos.z.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structures...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("weaponDirection"))
            {
                xmltextlines.AddRange(_weaponDirection.AsVD2XML());
                xmltextlines.Add("");
            }
            if (PropertyExists("targetPriorityList"))
            {
                xmltextlines.AddRange(_targetPriorityList.AsVD2XML());
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("turretBarrel"))
            {
                foreach (turretBarrelDataStructure result in _turretBarrel)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
