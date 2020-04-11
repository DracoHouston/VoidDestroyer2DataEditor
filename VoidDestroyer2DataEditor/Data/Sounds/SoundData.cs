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
    public class SoundData : VD2Data
    {
        string _effectType;
        string _soundType;
        string _objectID;
        string _tailSound;
        string _startSound;
        string _startSoundFile;
        string _soundEngineSoundType;

        ObservableCollection<string> _soundFile;

        int _maxDistance;
        int _referenceDistance;
        int _maxSounds;

        ObservableCollection<int> _soundPriority;

        float _defaultVolume;

        bool _bDisable3d;

        [Description("effectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string effectType
        {
            get
            {
                return _effectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _effectType = value;
                        SetPropertyEdited("effectType", true);
                    }
                }
            }
        }

        [Description("soundType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soundType
        {
            get
            {
                return _soundType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _soundType = value;
                        SetPropertyEdited("soundType", true);
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

        [Description("tailSound is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string tailSound
        {
            get
            {
                return _tailSound;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _tailSound = value;
                        SetPropertyEdited("tailSound", true);
                    }
                }
            }
        }

        [Description("startSound is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string startSound
        {
            get
            {
                return _startSound;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _startSound = value;
                        SetPropertyEdited("startSound", true);
                    }
                }
            }
        }

        [Description("startSoundFile is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string startSoundFile
        {
            get
            {
                return _startSoundFile;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _startSoundFile = value;
                        SetPropertyEdited("startSoundFile", true);
                    }
                }
            }
        }

        [Description("soundEngineSoundType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string soundEngineSoundType
        {
            get
            {
                return _soundEngineSoundType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _soundEngineSoundType = value;
                        SetPropertyEdited("soundEngineSoundType", true);
                    }
                }
            }
        }


        [Description("soundFile is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public ObservableCollection<string> soundFile
        {
            get
            {
                return _soundFile;
            }
            set
            {
                _soundFile = value;
            }
        }

        private void OnsoundFileChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("soundFile", true);
                }
                else
                {
                    bool exists = false;
                    _soundFile = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "soundFile", out exists));
                    _soundFile.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnsoundFileChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("soundFile", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("soundFile", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundFile"));
                    }
                    SetPropertyExists("soundFile", exists);
                }
            }
        }


        [Description("maxDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxDistance
        {
            get
            {
                return _maxDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxDistance = value;
                        SetPropertyEdited("maxDistance", true);
                    }
                }
            }
        }

        [Description("referenceDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int referenceDistance
        {
            get
            {
                return _referenceDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _referenceDistance = value;
                        SetPropertyEdited("referenceDistance", true);
                    }
                }
            }
        }

        [Description("maxSounds is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int maxSounds
        {
            get
            {
                return _maxSounds;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _maxSounds = value;
                        SetPropertyEdited("maxSounds", true);
                    }
                }
            }
        }


        [Description("soundPriority is a collection of integers"), Category("Integer Collections")]
        public ObservableCollection<int> soundPriority
        {
            get
            {
                return _soundPriority;
            }
            set
            {
                _soundPriority = value;
            }
        }

        private void OnsoundPriorityChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("soundPriority", true);
                }
                else
                {
                    bool exists = false;
                    _soundPriority = new ObservableCollection<int>(ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, "soundPriority", out exists));
                    _soundPriority.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnsoundPriorityChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("soundPriority", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("soundPriority", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundPriority"));
                    }
                    SetPropertyExists("soundPriority", exists);
                }
            }
        }


        [Description("defaultVolume is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float defaultVolume
        {
            get
            {
                return _defaultVolume;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _defaultVolume = value;
                        SetPropertyEdited("defaultVolume", true);
                    }
                }
            }
        }


        [Description("bDisable3d is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bDisable3d
        {
            get
            {
                return _bDisable3d;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bDisable3d = value;
                        SetPropertyEdited("bDisable3d", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("soundType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("tailSound");
            InitProperty("startSound");
            InitProperty("startSoundFile");
            InitProperty("soundEngineSoundType");

            InitProperty("soundFile");

            InitProperty("maxDistance");
            InitProperty("referenceDistance");
            InitProperty("maxSounds");

            InitProperty("soundPriority");

            InitProperty("defaultVolume");

            InitProperty("bDisable3d");

        }

        public SoundData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("effectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("effectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "effectType"));
                }
                SetPropertyExists("effectType", exists);
                _soundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soundType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soundType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundType"));
                }
                SetPropertyExists("soundType", exists);
                _tailSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tailSound", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("tailSound", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("tailSound", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "tailSound"));
                }
                SetPropertyExists("tailSound", exists);
                _startSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSound", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("startSound", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("startSound", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "startSound"));
                }
                SetPropertyExists("startSound", exists);
                _startSoundFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSoundFile", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("startSoundFile", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("startSoundFile", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "startSoundFile"));
                }
                SetPropertyExists("startSoundFile", exists);
                _soundEngineSoundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundEngineSoundType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soundEngineSoundType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soundEngineSoundType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundEngineSoundType"));
                }
                SetPropertyExists("soundEngineSoundType", exists);

                _soundFile = new ObservableCollection<string>(ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "soundFile", out exists));
                _soundFile.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnsoundFileChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soundFile", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soundFile", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundFile"));
                }
                SetPropertyExists("soundFile", exists);

                _maxDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxDistance"));
                }
                SetPropertyExists("maxDistance", exists);
                _referenceDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "referenceDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("referenceDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("referenceDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "referenceDistance"));
                }
                SetPropertyExists("referenceDistance", exists);
                _maxSounds = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxSounds", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("maxSounds", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("maxSounds", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "maxSounds"));
                }
                SetPropertyExists("maxSounds", exists);

                _soundPriority =  new ObservableCollection<int>(ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, "soundPriority", out exists));
                _soundPriority.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OnsoundPriorityChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("soundPriority", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("soundPriority", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "soundPriority"));
                }
                SetPropertyExists("soundPriority", exists);

                _defaultVolume = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "defaultVolume", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("defaultVolume", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("defaultVolume", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "defaultVolume"));
                }
                SetPropertyExists("defaultVolume", exists);

                _bDisable3d = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDisable3d", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bDisable3d", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bDisable3d", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bDisable3d"));
                }
                SetPropertyExists("bDisable3d", exists);

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
            if (PropertyExists("effectType"))
            {
                xmltextlines.Add("<effectType attr1=\"" + _effectType + "\"/>");
            }
            if (PropertyExists("soundType"))
            {
                xmltextlines.Add("<soundType attr1=\"" + _soundType + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("tailSound"))
            {
                xmltextlines.Add("<tailSound attr1=\"" + _tailSound + "\"/>");
            }
            if (PropertyExists("startSound"))
            {
                xmltextlines.Add("<startSound attr1=\"" + _startSound + "\"/>");
            }
            if (PropertyExists("startSoundFile"))
            {
                xmltextlines.Add("<startSoundFile attr1=\"" + _startSoundFile + "\"/>");
            }
            if (PropertyExists("soundEngineSoundType"))
            {
                xmltextlines.Add("<soundEngineSoundType attr1=\"" + _soundEngineSoundType + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"String Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("soundFile"))
            {
                foreach (string result in _soundFile)
                {
                    xmltextlines.Add("<soundFile attr1=\"" + result + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("maxDistance"))
            {
                xmltextlines.Add("<maxDistance attr1=\"" + _maxDistance.ToString() + "\"/>");
            }
            if (PropertyExists("referenceDistance"))
            {
                xmltextlines.Add("<referenceDistance attr1=\"" + _referenceDistance.ToString() + "\"/>");
            }
            if (PropertyExists("maxSounds"))
            {
                xmltextlines.Add("<maxSounds attr1=\"" + _maxSounds.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integer Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("soundPriority"))
            {
                foreach (int result in _soundPriority)
                {
                    xmltextlines.Add("<soundPriority attr1=\"" + result.ToString() + "\"/>");
                }
                xmltextlines.Add("");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("defaultVolume"))
            {
                xmltextlines.Add("<defaultVolume attr1=\"" + _defaultVolume.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bDisable3d"))
            {
                xmltextlines.Add("<bDisable3d attr1=\"" + ((_bDisable3d) ? "1" : "0") + "\"/>");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
