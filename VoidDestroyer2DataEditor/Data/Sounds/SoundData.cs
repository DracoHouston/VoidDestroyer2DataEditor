using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace VoidDestroyer2DataEditor
{
    class SoundData : VD2Data
    {
        string _effectType;
        string _soundType;
        string _objectID;
        string _tailSound;
        string _startSound;
        string _startSoundFile;
        string _soundEngineSoundType;

        List<string> _soundFile;

        int _maxDistance;
        int _referenceDistance;
        int _maxSounds;

        List<int> _soundPriority;

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
                _effectType = value;
                SetPropertyEdited("effectType", true);
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
                _soundType = value;
                SetPropertyEdited("soundType", true);
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
                _objectID = value;
                SetPropertyEdited("objectID", true);
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
                _tailSound = value;
                SetPropertyEdited("tailSound", true);
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
                _startSound = value;
                SetPropertyEdited("startSound", true);
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
                _startSoundFile = value;
                SetPropertyEdited("startSoundFile", true);
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
                _soundEngineSoundType = value;
                SetPropertyEdited("soundEngineSoundType", true);
            }
        }


        [Description("soundFile is a collection of plaintext strings"), Category("Plaintext String Collections"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> soundFile
        {
            get
            {
                return _soundFile;
            }
            set
            {
                _soundFile = value;
                SetPropertyEdited("soundFile", true);
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
                _maxDistance = value;
                SetPropertyEdited("maxDistance", true);
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
                _referenceDistance = value;
                SetPropertyEdited("referenceDistance", true);
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
                _maxSounds = value;
                SetPropertyEdited("maxSounds", true);
            }
        }


        [Description("soundPriority is a collection of integers"), Category("Integer Collections")]
        public List<int> soundPriority
        {
            get
            {
                return _soundPriority;
            }
            set
            {
                _soundPriority = value;
                SetPropertyEdited("soundPriority", true);
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
                _defaultVolume = value;
                SetPropertyEdited("defaultVolume", true);
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
                _bDisable3d = value;
                SetPropertyEdited("bDisable3d", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("soundType");
            InitProperty("objectID");
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

        public SoundData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType", out exists);
                SetPropertyExistsInBaseData("effectType", exists);
                SetPropertyExists("effectType", exists);
                _soundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundType", out exists);
                SetPropertyExistsInBaseData("soundType", exists);
                SetPropertyExists("soundType", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _tailSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tailSound", out exists);
                SetPropertyExistsInBaseData("tailSound", exists);
                SetPropertyExists("tailSound", exists);
                _startSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSound", out exists);
                SetPropertyExistsInBaseData("startSound", exists);
                SetPropertyExists("startSound", exists);
                _startSoundFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSoundFile", out exists);
                SetPropertyExistsInBaseData("startSoundFile", exists);
                SetPropertyExists("startSoundFile", exists);
                _soundEngineSoundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundEngineSoundType", out exists);
                SetPropertyExistsInBaseData("soundEngineSoundType", exists);
                SetPropertyExists("soundEngineSoundType", exists);

                _soundFile = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "soundFile", out exists);
                SetPropertyExistsInBaseData("soundFile", exists);
                SetPropertyExists("soundFile", exists);

                _maxDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDistance", out exists);
                SetPropertyExistsInBaseData("maxDistance", exists);
                SetPropertyExists("maxDistance", exists);
                _referenceDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "referenceDistance", out exists);
                SetPropertyExistsInBaseData("referenceDistance", exists);
                SetPropertyExists("referenceDistance", exists);
                _maxSounds = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxSounds", out exists);
                SetPropertyExistsInBaseData("maxSounds", exists);
                SetPropertyExists("maxSounds", exists);

                _soundPriority = ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, "soundPriority", out exists);
                SetPropertyExistsInBaseData("soundPriority", exists);
                SetPropertyExists("soundPriority", exists);

                _defaultVolume = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "defaultVolume", out exists);
                SetPropertyExistsInBaseData("defaultVolume", exists);
                SetPropertyExists("defaultVolume", exists);

                _bDisable3d = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDisable3d", out exists);
                SetPropertyExistsInBaseData("bDisable3d", exists);
                SetPropertyExists("bDisable3d", exists);

            }
        }
    }
}
