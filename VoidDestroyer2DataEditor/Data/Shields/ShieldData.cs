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
    public class ShieldData : VD2Data
    {
        string _objectType;
        string _name;
        string _shieldID;
        string _collisionMeshName;
        string _shieldType;
        string _materialName;

        bool _bInvisible;

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

        [Description("shieldID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldID
        {
            get
            {
                return _shieldID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldID = value;
                        SetPropertyEdited("shieldID", true);
                    }
                }
            }
        }

        [Description("collisionMeshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionMeshName
        {
            get
            {
                return _collisionMeshName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionMeshName = value;
                        SetPropertyEdited("collisionMeshName", true);
                    }
                }
            }
        }

        [Description("shieldType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string shieldType
        {
            get
            {
                return _shieldType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shieldType = value;
                        SetPropertyEdited("shieldType", true);
                    }
                }
            }
        }

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialName = value;
                        SetPropertyEdited("materialName", true);
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bInvisible = value;
                        SetPropertyEdited("bInvisible", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("name");
            InitProperty("shieldID");
            SetPropertyIsObjectID("shieldID", true);
            InitProperty("collisionMeshName");
            InitProperty("shieldType");
            InitProperty("materialName");

            InitProperty("bInvisible");

        }

        public ShieldData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _shieldID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(shieldID, "shieldID"));
                }
                SetPropertyExists("shieldID", exists);

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
                _collisionMeshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionMeshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionMeshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionMeshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionMeshName"));
                }
                SetPropertyExists("collisionMeshName", exists);
                _shieldType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "shieldType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shieldType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shieldType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shieldType"));
                }
                SetPropertyExists("shieldType", exists);
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialName"));
                }
                SetPropertyExists("materialName", exists);

                _bInvisible = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisible", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bInvisible", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bInvisible", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bInvisible"));
                }
                SetPropertyExists("bInvisible", exists);

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
            if (PropertyExists("objectType"))
            {
                xmltextlines.Add("<objectType attr1=\"" + _objectType + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("shieldID"))
            {
                xmltextlines.Add("<shieldID attr1=\"" + _shieldID + "\"/>");
            }
            if (PropertyExists("collisionMeshName"))
            {
                xmltextlines.Add("<collisionMeshName attr1=\"" + _collisionMeshName + "\"/>");
            }
            if (PropertyExists("shieldType"))
            {
                xmltextlines.Add("<shieldType attr1=\"" + _shieldType + "\"/>");
            }
            if (PropertyExists("materialName"))
            {
                xmltextlines.Add("<materialName attr1=\"" + _materialName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bInvisible"))
            {
                xmltextlines.Add("<bInvisible attr1=\"" + ((_bInvisible) ? "1" : "0") + "\"/>");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
