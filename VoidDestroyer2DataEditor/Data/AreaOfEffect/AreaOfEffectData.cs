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
    public class AreaOfEffectData : VD2Data
    {
        string _objectID;
        string _particleSystemName;
        string _affectedObjects;

        int _damage;
        int _lifeTimer;

        bool _bRefuel;
        bool _bDebrisFieldRadiation;

        Vector3D _fieldSize;

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

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

        [Description("affectedObjects is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string affectedObjects
        {
            get
            {
                return _affectedObjects;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _affectedObjects = value;
                        SetPropertyEdited("affectedObjects", true);
                    }
                }
            }
        }


        [Description("damage is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int damage
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

        [Description("lifeTimer is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int lifeTimer
        {
            get
            {
                return _lifeTimer;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _lifeTimer = value;
                        SetPropertyEdited("lifeTimer", true);
                    }
                }
            }
        }


        [Description("bRefuel is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRefuel
        {
            get
            {
                return _bRefuel;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRefuel = value;
                        SetPropertyEdited("bRefuel", true);
                    }
                }
            }
        }

        [Description("bDebrisFieldRadiation is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bDebrisFieldRadiation
        {
            get
            {
                return _bDebrisFieldRadiation;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bDebrisFieldRadiation = value;
                        SetPropertyEdited("bDebrisFieldRadiation", true);
                    }
                }
            }
        }


        [Description("fieldSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D fieldSize
        {
            get
            {
                return _fieldSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fieldSize = value;
                        SetPropertyEdited("fieldSize", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("particleSystemName");
            InitProperty("affectedObjects");

            InitProperty("damage");
            InitProperty("lifeTimer");

            InitProperty("bRefuel");
            InitProperty("bDebrisFieldRadiation");

            InitProperty("fieldSize");

        }

        public AreaOfEffectData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _affectedObjects = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "affectedObjects", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("affectedObjects", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("affectedObjects", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "affectedObjects"));
                }
                SetPropertyExists("affectedObjects", exists);

                _damage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damage", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damage", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damage", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damage"));
                }
                SetPropertyExists("damage", exists);
                _lifeTimer = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "lifeTimer", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("lifeTimer", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("lifeTimer", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "lifeTimer"));
                }
                SetPropertyExists("lifeTimer", exists);

                _bRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRefuel", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRefuel", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRefuel", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRefuel"));
                }
                SetPropertyExists("bRefuel", exists);
                _bDebrisFieldRadiation = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDebrisFieldRadiation", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bDebrisFieldRadiation", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bDebrisFieldRadiation", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bDebrisFieldRadiation"));
                }
                SetPropertyExists("bDebrisFieldRadiation", exists);

                _fieldSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "fieldSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fieldSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fieldSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fieldSize"));
                }
                SetPropertyExists("fieldSize", exists);

            }
        }

        public override void SaveData()
        {
            List<string> xmltextlines = new List<string>();
            xmltextlines.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmltextlines.Add("<note_to_self attr1=\"Generated by Void Destroyer 2 Data Editor\"/>");
            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Strings...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("particleSystemName"))
            {
                xmltextlines.Add("<particleSystemName attr1=\"" + _particleSystemName + "\"/>");
            }
            if (PropertyExists("affectedObjects"))
            {
                xmltextlines.Add("<affectedObjects attr1=\"" + _affectedObjects + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("damage"))
            {
                xmltextlines.Add("<damage attr1=\"" + _damage.ToString() + "\"/>");
            }
            if (PropertyExists("lifeTimer"))
            {
                xmltextlines.Add("<lifeTimer attr1=\"" + _lifeTimer.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bRefuel"))
            {
                xmltextlines.Add("<bRefuel attr1=\"" + ((_bRefuel) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bDebrisFieldRadiation"))
            {
                xmltextlines.Add("<bDebrisFieldRadiation attr1=\"" + ((_bDebrisFieldRadiation) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("fieldSize"))
            {
                xmltextlines.Add("<fieldSize x=\"" + _fieldSize.x.ToString() + "\" y=\"" + _fieldSize.y.ToString() + "\" z=\"" + _fieldSize.z.ToString() + "\"/>");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
