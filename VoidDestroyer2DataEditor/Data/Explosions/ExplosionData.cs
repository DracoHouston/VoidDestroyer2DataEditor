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
    public class ExplosionData : VD2Data
    {
        string _effectType;
        string _objectID;
        string _particleSystemName;
        string _explosionSoundID;
        string _explosionType;

        int _renderingDistance;
        int _shakeDistance;
        int _pushForce;
        int _damage;
        int _maxSounds;

        float _life;
        float _angularForce;

        bool _bCausesShake;

        Vector3D _impactSize;

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

        [Description("explosionSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionSoundID
        {
            get
            {
                return _explosionSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _explosionSoundID = value;
                        SetPropertyEdited("explosionSoundID", true);
                    }
                }
            }
        }

        [Description("explosionType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string explosionType
        {
            get
            {
                return _explosionType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _explosionType = value;
                        SetPropertyEdited("explosionType", true);
                    }
                }
            }
        }


        [Description("renderingDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int renderingDistance
        {
            get
            {
                return _renderingDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _renderingDistance = value;
                        SetPropertyEdited("renderingDistance", true);
                    }
                }
            }
        }

        [Description("shakeDistance is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int shakeDistance
        {
            get
            {
                return _shakeDistance;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _shakeDistance = value;
                        SetPropertyEdited("shakeDistance", true);
                    }
                }
            }
        }

        [Description("pushForce is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int pushForce
        {
            get
            {
                return _pushForce;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _pushForce = value;
                        SetPropertyEdited("pushForce", true);
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


        [Description("life is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float life
        {
            get
            {
                return _life;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _life = value;
                        SetPropertyEdited("life", true);
                    }
                }
            }
        }

        [Description("angularForce is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float angularForce
        {
            get
            {
                return _angularForce;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _angularForce = value;
                        SetPropertyEdited("angularForce", true);
                    }
                }
            }
        }


        [Description("bCausesShake is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bCausesShake
        {
            get
            {
                return _bCausesShake;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bCausesShake = value;
                        SetPropertyEdited("bCausesShake", true);
                    }
                }
            }
        }


        [Description("impactSize is a 3D vector"), Category("3D Vectors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Vector3D impactSize
        {
            get
            {
                return _impactSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _impactSize = value;
                        SetPropertyEdited("impactSize", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("particleSystemName");
            InitProperty("explosionSoundID");
            InitProperty("explosionType");

            InitProperty("renderingDistance");
            InitProperty("shakeDistance");
            InitProperty("pushForce");
            InitProperty("damage");
            InitProperty("maxSounds");

            InitProperty("life");
            InitProperty("angularForce");

            InitProperty("bCausesShake");

            InitProperty("impactSize");

        }

        public ExplosionData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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
                _explosionSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("explosionSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("explosionSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "explosionSoundID"));
                }
                SetPropertyExists("explosionSoundID", exists);
                _explosionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("explosionType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("explosionType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "explosionType"));
                }
                SetPropertyExists("explosionType", exists);

                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("renderingDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("renderingDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "renderingDistance"));
                }
                SetPropertyExists("renderingDistance", exists);
                _shakeDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shakeDistance", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("shakeDistance", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("shakeDistance", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "shakeDistance"));
                }
                SetPropertyExists("shakeDistance", exists);
                _pushForce = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "pushForce", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("pushForce", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("pushForce", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "pushForce"));
                }
                SetPropertyExists("pushForce", exists);
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

                _life = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "life", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("life", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("life", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "life"));
                }
                SetPropertyExists("life", exists);
                _angularForce = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "angularForce", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("angularForce", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("angularForce", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "angularForce"));
                }
                SetPropertyExists("angularForce", exists);

                _bCausesShake = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCausesShake", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bCausesShake", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bCausesShake", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bCausesShake"));
                }
                SetPropertyExists("bCausesShake", exists);

                _impactSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "impactSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("impactSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("impactSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "impactSize"));
                }
                SetPropertyExists("impactSize", exists);

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
            if (PropertyExists("effectType"))
            {
                xmltextlines.Add("<effectType attr1=\"" + _effectType + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("particleSystemName"))
            {
                xmltextlines.Add("<particleSystemName attr1=\"" + _particleSystemName + "\"/>");
            }
            if (PropertyExists("explosionSoundID"))
            {
                xmltextlines.Add("<explosionSoundID attr1=\"" + _explosionSoundID + "\"/>");
            }
            if (PropertyExists("explosionType"))
            {
                xmltextlines.Add("<explosionType attr1=\"" + _explosionType + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("renderingDistance"))
            {
                xmltextlines.Add("<renderingDistance attr1=\"" + _renderingDistance.ToString() + "\"/>");
            }
            if (PropertyExists("shakeDistance"))
            {
                xmltextlines.Add("<shakeDistance attr1=\"" + _shakeDistance.ToString() + "\"/>");
            }
            if (PropertyExists("pushForce"))
            {
                xmltextlines.Add("<pushForce attr1=\"" + _pushForce.ToString() + "\"/>");
            }
            if (PropertyExists("damage"))
            {
                xmltextlines.Add("<damage attr1=\"" + _damage.ToString() + "\"/>");
            }
            if (PropertyExists("maxSounds"))
            {
                xmltextlines.Add("<maxSounds attr1=\"" + _maxSounds.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("life"))
            {
                xmltextlines.Add("<life attr1=\"" + _life.ToString() + "\"/>");
            }
            if (PropertyExists("angularForce"))
            {
                xmltextlines.Add("<angularForce attr1=\"" + _angularForce.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bCausesShake"))
            {
                xmltextlines.Add("<bCausesShake attr1=\"" + ((_bCausesShake) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"3D Vectors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("impactSize"))
            {
                xmltextlines.Add("<impactSize x=\"" + _impactSize.x.ToString() + "\" y=\"" + _impactSize.y.ToString() + "\" z=\"" + _impactSize.z.ToString() + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
            ResetAllPropertyEdited();
        }
    }
}
