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
    public class CharacterData : VD2Data
    {
        string _displayName;
        string _characterID;
        string _imageSetName;
        string _textColor;
        string _title;
        string _physicalObjectType;

        ObservableCollection<string> _factionID;

        bool _bGeneric;

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

        [Description("characterID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string characterID
        {
            get
            {
                return _characterID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _characterID = value;
                        SetPropertyEdited("characterID", true);
                    }
                }
            }
        }

        [Description("imageSetName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string imageSetName
        {
            get
            {
                return _imageSetName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _imageSetName = value;
                        SetPropertyEdited("imageSetName", true);
                    }
                }
            }
        }

        [Description("textColor is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string textColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _textColor = value;
                        SetPropertyEdited("textColor", true);
                    }
                }
            }
        }

        [Description("title is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _title = value;
                        SetPropertyEdited("title", true);
                    }
                }
            }
        }

        [Description("physicalObjectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string physicalObjectType
        {
            get
            {
                return _physicalObjectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _physicalObjectType = value;
                        SetPropertyEdited("physicalObjectType", true);
                    }
                }
            }
        }


        [Description("factionID is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> factionID
        {
            get
            {
                return _factionID;
            }
            set
            {
                _factionID = value;
            }
        }

        private void OnfactionIDChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("factionID", true);
                }
                else
                {
                    bool exists = false;
                    _factionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists));
                    _factionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionIDChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("factionID", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("factionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionID"));
                    }
                    SetPropertyExists("factionID", exists);
                }
            }
        }


        [Description("bGeneric is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bGeneric
        {
            get
            {
                return _bGeneric;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bGeneric = value;
                        SetPropertyEdited("bGeneric", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("displayName");
            InitProperty("characterID");
            SetPropertyIsObjectID("characterID", true);
            InitProperty("imageSetName");
            InitProperty("textColor");
            InitProperty("title");
            InitProperty("physicalObjectType");

            InitProperty("factionID");

            InitProperty("bGeneric");

        }

        public CharacterData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _characterID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "characterID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("characterID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("characterID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(characterID, "characterID"));
                }
                SetPropertyExists("characterID", exists);

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
                _imageSetName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "imageSetName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("imageSetName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("imageSetName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "imageSetName"));
                }
                SetPropertyExists("imageSetName", exists);
                _textColor = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "textColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("textColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("textColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "textColor"));
                }
                SetPropertyExists("textColor", exists);
                _title = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "title", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("title", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("title", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "title"));
                }
                SetPropertyExists("title", exists);
                _physicalObjectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "physicalObjectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("physicalObjectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("physicalObjectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "physicalObjectType"));
                }
                SetPropertyExists("physicalObjectType", exists);

                _factionID = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionID", out exists));
                _factionID.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionIDChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionID"));
                }
                SetPropertyExists("factionID", exists);

                _bGeneric = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bGeneric", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bGeneric", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bGeneric", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bGeneric"));
                }
                SetPropertyExists("bGeneric", exists);

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
            if (PropertyExists("displayName"))
            {
                xmltextlines.Add("<displayName attr1=\"" + _displayName + "\"/>");
            }
            if (PropertyExists("characterID"))
            {
                xmltextlines.Add("<characterID attr1=\"" + _characterID + "\"/>");
            }
            if (PropertyExists("imageSetName"))
            {
                xmltextlines.Add("<imageSetName attr1=\"" + _imageSetName + "\"/>");
            }
            if (PropertyExists("textColor"))
            {
                xmltextlines.Add("<textColor attr1=\"" + _textColor + "\"/>");
            }
            if (PropertyExists("title"))
            {
                xmltextlines.Add("<title attr1=\"" + _title + "\"/>");
            }
            if (PropertyExists("physicalObjectType"))
            {
                xmltextlines.Add("<physicalObjectType attr1=\"" + _physicalObjectType + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("factionID"))
            {
                foreach (string result in _factionID)
                {
                    xmltextlines.Add("<factionID attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bGeneric"))
            {
                xmltextlines.Add("<bGeneric attr1=\"" + ((_bGeneric) ? "1" : "0") + "\"/>");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
