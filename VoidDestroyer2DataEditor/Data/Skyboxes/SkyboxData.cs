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
    public class SkyboxData : VD2Data
    {
        string _objectID;
        string _materialName;

        ObservableCollection<string> _factionType;

        bool _bGeneric;

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


        [Description("factionType is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> factionType
        {
            get
            {
                return _factionType;
            }
            set
            {
                _factionType = value;
            }
        }

        private void OnfactionTypeChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("factionType", true);
                }
                else
                {
                    bool exists = false;
                    _factionType = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionType", out exists));
                    _factionType.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionTypeChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("factionType", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("factionType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionType"));
                    }
                    SetPropertyExists("factionType", exists);
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
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("materialName");

            InitProperty("factionType");

            InitProperty("bGeneric");

        }

        public SkyboxData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _factionType = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "factionType", out exists));
                _factionType.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnfactionTypeChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("factionType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("factionType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "factionType"));
                }
                SetPropertyExists("factionType", exists);

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

        protected override void SaveData()
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
            if (PropertyExists("materialName"))
            {
                xmltextlines.Add("<materialName attr1=\"" + _materialName + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("factionType"))
            {
                foreach (string result in _factionType)
                {
                    xmltextlines.Add("<factionType attr1=\"" + result + "\"/>");
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

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
