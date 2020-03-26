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

        [Description("effectType is a plaintext string"), Category("Plaintext Strings")]
        public string effectType
        {
            get => _effectType;
            set => _effectType = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("musicFile is a plaintext string"), Category("Plaintext Strings")]
        public string musicFile
        {
            get => _musicFile;
            set => _musicFile = value;
        }

        [Description("objectTypeMusic is a plaintext string"), Category("Plaintext Strings")]
        public string objectTypeMusic
        {
            get => _objectTypeMusic;
            set => _objectTypeMusic = value;
        }


        [Description("defaultVolume is a real number"), Category("Real Numbers")]
        public float defaultVolume
        {
            get => _defaultVolume;
            set => _defaultVolume = value;
        }


        [Description("bLooping is a boolean value"), Category("Booleans")]
        public bool bLooping
        {
            get => _bLooping;
            set => _bLooping = value;
        }



        public MusicData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _musicFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "musicFile");
                _objectTypeMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectTypeMusic");

                _defaultVolume = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "defaultVolume");

                _bLooping = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLooping");

            }
        }
    }
}
