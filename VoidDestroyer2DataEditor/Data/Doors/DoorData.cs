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
    public class DoorData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _doorSoundID;

        float _openTimeMultiplier;

        bool _bPhysicalDoor;
        bool _bOpenOnProximity;

        Vector3D _translateMax;

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

        [Description("doorSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string doorSoundID
        {
            get
            {
                return _doorSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _doorSoundID = value;
                        SetPropertyEdited("doorSoundID", true);
                    }
                }
            }
        }


        [Description("openTimeMultiplier is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float openTimeMultiplier
        {
            get
            {
                return _openTimeMultiplier;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _openTimeMultiplier = value;
                        SetPropertyEdited("openTimeMultiplier", true);
                    }
                }
            }
        }


        [Description("bPhysicalDoor is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bPhysicalDoor
        {
            get
            {
                return _bPhysicalDoor;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bPhysicalDoor = value;
                        SetPropertyEdited("bPhysicalDoor", true);
                    }
                }
            }
        }

        [Description("bOpenOnProximity is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bOpenOnProximity
        {
            get
            {
                return _bOpenOnProximity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bOpenOnProximity = value;
                        SetPropertyEdited("bOpenOnProximity", true);
                    }
                }
            }
        }


        [Description("translateMax is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D translateMax
        {
            get
            {
                return _translateMax;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _translateMax = value;
                        SetPropertyEdited("translateMax", true);
                    }
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
            InitProperty("doorSoundID");

            InitProperty("openTimeMultiplier");

            InitProperty("bPhysicalDoor");
            InitProperty("bOpenOnProximity");

            InitProperty("translateMax");

        }

        public DoorData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _doorSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "doorSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("doorSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("doorSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "doorSoundID"));
                }
                SetPropertyExists("doorSoundID", exists);

                _openTimeMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "openTimeMultiplier", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("openTimeMultiplier", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("openTimeMultiplier", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "openTimeMultiplier"));
                }
                SetPropertyExists("openTimeMultiplier", exists);

                _bPhysicalDoor = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalDoor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bPhysicalDoor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bPhysicalDoor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bPhysicalDoor"));
                }
                SetPropertyExists("bPhysicalDoor", exists);
                _bOpenOnProximity = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOpenOnProximity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bOpenOnProximity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bOpenOnProximity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bOpenOnProximity"));
                }
                SetPropertyExists("bOpenOnProximity", exists);

                _translateMax = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateMax", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("translateMax", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("translateMax", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "translateMax"));
                }
                SetPropertyExists("translateMax", exists);

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
            if (PropertyExists("doorSoundID"))
            {
                xmltextlines.Add("<doorSoundID attr1=\"" + _doorSoundID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("openTimeMultiplier"))
            {
                xmltextlines.Add("<openTimeMultiplier attr1=\"" + _openTimeMultiplier.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bPhysicalDoor"))
            {
                xmltextlines.Add("<bPhysicalDoor attr1=\"" + ((_bPhysicalDoor) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bOpenOnProximity"))
            {
                xmltextlines.Add("<bOpenOnProximity attr1=\"" + ((_bOpenOnProximity) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("translateMax"))
            {
                xmltextlines.Add("<translateMax x=\"" + _translateMax.x.ToString() + "\" y=\"" + _translateMax.y.ToString() + "\" z=\"" + _translateMax.z.ToString() + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
