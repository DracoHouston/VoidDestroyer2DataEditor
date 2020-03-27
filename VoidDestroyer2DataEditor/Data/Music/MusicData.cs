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
    class MusicData : VD2Data
    {
        string _effectType;
        string _objectID;
        string _musicFile;
        string _objectTypeMusic;

        float _defaultVolume;

        bool _bLooping;

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

        [Description("musicFile is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string musicFile
        {
            get
            {
                return _musicFile;
            }
            set
            {
                _musicFile = value;
                SetPropertyEdited("musicFile", true);
            }
        }

        [Description("objectTypeMusic is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectTypeMusic
        {
            get
            {
                return _objectTypeMusic;
            }
            set
            {
                _objectTypeMusic = value;
                SetPropertyEdited("objectTypeMusic", true);
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


        [Description("bLooping is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLooping
        {
            get
            {
                return _bLooping;
            }
            set
            {
                _bLooping = value;
                SetPropertyEdited("bLooping", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
            InitProperty("musicFile");
            InitProperty("objectTypeMusic");

            InitProperty("defaultVolume");

            InitProperty("bLooping");

        }

        public MusicData(string inPath) : base(inPath)
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType", out exists);
                SetPropertyExistsInBaseData("effectType", exists);
                SetPropertyExists("effectType", exists);
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID", out exists);
                SetPropertyExistsInBaseData("objectID", exists);
                SetPropertyExists("objectID", exists);
                _musicFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "musicFile", out exists);
                SetPropertyExistsInBaseData("musicFile", exists);
                SetPropertyExists("musicFile", exists);
                _objectTypeMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectTypeMusic", out exists);
                SetPropertyExistsInBaseData("objectTypeMusic", exists);
                SetPropertyExists("objectTypeMusic", exists);

                _defaultVolume = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "defaultVolume", out exists);
                SetPropertyExistsInBaseData("defaultVolume", exists);
                SetPropertyExists("defaultVolume", exists);

                _bLooping = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLooping", out exists);
                SetPropertyExistsInBaseData("bLooping", exists);
                SetPropertyExists("bLooping", exists);

            }
        }
    }
}
