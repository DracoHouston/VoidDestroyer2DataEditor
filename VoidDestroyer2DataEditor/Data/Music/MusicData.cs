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
    public class MusicData : VD2Data
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

        [Description("musicFile is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string musicFile
        {
            get
            {
                return _musicFile;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _musicFile = value;
                        SetPropertyEdited("musicFile", true);
                    }
                }
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
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectTypeMusic = value;
                        SetPropertyEdited("objectTypeMusic", true);
                    }
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


        [Description("bLooping is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bLooping
        {
            get
            {
                return _bLooping;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bLooping = value;
                        SetPropertyEdited("bLooping", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("musicFile");
            InitProperty("objectTypeMusic");

            InitProperty("defaultVolume");

            InitProperty("bLooping");

        }

        public MusicData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _musicFile = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "musicFile", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("musicFile", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("musicFile", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "musicFile"));
                }
                SetPropertyExists("musicFile", exists);
                _objectTypeMusic = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectTypeMusic", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectTypeMusic", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectTypeMusic", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "objectTypeMusic"));
                }
                SetPropertyExists("objectTypeMusic", exists);

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

                _bLooping = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bLooping", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bLooping", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bLooping", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bLooping"));
                }
                SetPropertyExists("bLooping", exists);

            }
        }
    }
}
