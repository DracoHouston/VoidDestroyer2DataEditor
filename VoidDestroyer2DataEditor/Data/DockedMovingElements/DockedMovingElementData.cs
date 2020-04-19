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
    public class DockedMovingElementData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _soundID;

        int _proximityDistance;

        float _moveAwayTimeDuration;

        bool _bOpenOnProximity;

        Vector3D _translateVector;

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

        [Description("soundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soundID
        {
            get
            {
                return _soundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _soundID = value;
                        SetPropertyEdited("soundID", true);
                    }
                }
            }
        }


        [Description("proximityDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int proximityDistance
        {
            get
            {
                return _proximityDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _proximityDistance = value;
                        SetPropertyEdited("proximityDistance", true);
                    }
                }
            }
        }


        [Description("moveAwayTimeDuration is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float moveAwayTimeDuration
        {
            get
            {
                return _moveAwayTimeDuration;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _moveAwayTimeDuration = value;
                        SetPropertyEdited("moveAwayTimeDuration", true);
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


        [Description("translateVector is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D translateVector
        {
            get
            {
                return _translateVector;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _translateVector = value;
                        SetPropertyEdited("translateVector", true);
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
            InitProperty("soundID");

            InitProperty("proximityDistance");

            InitProperty("moveAwayTimeDuration");

            InitProperty("bOpenOnProximity");

            InitProperty("translateVector");

        }

        public DockedMovingElementData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _soundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundID"));
                }
                SetPropertyExists("soundID", exists);

                _proximityDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "proximityDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("proximityDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("proximityDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "proximityDistance"));
                }
                SetPropertyExists("proximityDistance", exists);

                _moveAwayTimeDuration = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "moveAwayTimeDuration", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("moveAwayTimeDuration", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("moveAwayTimeDuration", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "moveAwayTimeDuration"));
                }
                SetPropertyExists("moveAwayTimeDuration", exists);

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

                _translateVector = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateVector", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("translateVector", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("translateVector", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "translateVector"));
                }
                SetPropertyExists("translateVector", exists);

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
            if (PropertyExists("soundID"))
            {
                xmltextlines.Add("<soundID attr1=\"" + _soundID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("proximityDistance"))
            {
                xmltextlines.Add("<proximityDistance attr1=\"" + _proximityDistance.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("moveAwayTimeDuration"))
            {
                xmltextlines.Add("<moveAwayTimeDuration attr1=\"" + _moveAwayTimeDuration.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bOpenOnProximity"))
            {
                xmltextlines.Add("<bOpenOnProximity attr1=\"" + ((_bOpenOnProximity) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("translateVector"))
            {
                xmltextlines.Add("<translateVector x=\"" + _translateVector.x.ToString() + "\" y=\"" + _translateVector.y.ToString() + "\" z=\"" + _translateVector.z.ToString() + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
