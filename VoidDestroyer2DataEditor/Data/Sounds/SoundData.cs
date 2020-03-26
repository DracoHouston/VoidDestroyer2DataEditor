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

        [Description("effectType is a plaintext string"), Category("Plaintext Strings")]
        public string effectType
        {
            get => _effectType;
            set => _effectType = value;
        }

        [Description("soundType is a plaintext string"), Category("Plaintext Strings")]
        public string soundType
        {
            get => _soundType;
            set => _soundType = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("tailSound is a plaintext string"), Category("Plaintext Strings")]
        public string tailSound
        {
            get => _tailSound;
            set => _tailSound = value;
        }

        [Description("startSound is a plaintext string"), Category("Plaintext Strings")]
        public string startSound
        {
            get => _startSound;
            set => _startSound = value;
        }

        [Description("startSoundFile is a plaintext string"), Category("Plaintext Strings")]
        public string startSoundFile
        {
            get => _startSoundFile;
            set => _startSoundFile = value;
        }

        [Description("soundEngineSoundType is a plaintext string"), Category("Plaintext Strings")]
        public string soundEngineSoundType
        {
            get => _soundEngineSoundType;
            set => _soundEngineSoundType = value;
        }


        [Description("soundFile is a collection of plaintext strings"), Category("Plaintext String Collections")]
        public List<string> soundFile
        {
            get => _soundFile;
            set => _soundFile = value;
        }


        [Description("maxDistance is an integer"), Category("Integers")]
        public int maxDistance
        {
            get => _maxDistance;
            set => _maxDistance = value;
        }

        [Description("referenceDistance is an integer"), Category("Integers")]
        public int referenceDistance
        {
            get => _referenceDistance;
            set => _referenceDistance = value;
        }

        [Description("maxSounds is an integer"), Category("Integers")]
        public int maxSounds
        {
            get => _maxSounds;
            set => _maxSounds = value;
        }


        [Description("soundPriority is a collection of integers"), Category("Integer Collections")]
        public List<int> soundPriority
        {
            get => _soundPriority;
            set => _soundPriority = value;
        }


        [Description("defaultVolume is a real number"), Category("Real Numbers")]
        public float defaultVolume
        {
            get => _defaultVolume;
            set => _defaultVolume = value;
        }


        [Description("bDisable3d is a boolean value"), Category("Booleans")]
        public bool bDisable3d
        {
            get => _bDisable3d;
            set => _bDisable3d = value;
        }



        public SoundData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType");
                _soundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _tailSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "tailSound");
                _startSound = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSound");
                _startSoundFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "startSoundFile");
                _soundEngineSoundType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundEngineSoundType");

                _soundFile = ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, "soundFile");

                _maxDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxDistance");
                _referenceDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "referenceDistance");
                _maxSounds = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxSounds");

                _soundPriority = ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, "soundPriority");

                _defaultVolume = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "defaultVolume");

                _bDisable3d = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDisable3d");

            }
        }
    }
}
