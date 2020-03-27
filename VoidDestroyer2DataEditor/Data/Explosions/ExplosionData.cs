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
    class ExplosionData : VD2Data
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

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string particleSystemName
        {
            get
            {
                return _particleSystemName;
            }
            set
            {
                _particleSystemName = value;
                SetPropertyEdited("particleSystemName", true);
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
                _explosionSoundID = value;
                SetPropertyEdited("explosionSoundID", true);
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
                _explosionType = value;
                SetPropertyEdited("explosionType", true);
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
                _renderingDistance = value;
                SetPropertyEdited("renderingDistance", true);
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
                _shakeDistance = value;
                SetPropertyEdited("shakeDistance", true);
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
                _pushForce = value;
                SetPropertyEdited("pushForce", true);
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
                _damage = value;
                SetPropertyEdited("damage", true);
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


        [Description("life is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float life
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
                SetPropertyEdited("life", true);
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
                _angularForce = value;
                SetPropertyEdited("angularForce", true);
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
                _bCausesShake = value;
                SetPropertyEdited("bCausesShake", true);
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
                _impactSize = value;
                SetPropertyEdited("impactSize", true);
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("effectType");
            InitProperty("objectID");
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

        public ExplosionData(string inPath) : base(inPath)
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
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName", out exists);
                SetPropertyExistsInBaseData("particleSystemName", exists);
                SetPropertyExists("particleSystemName", exists);
                _explosionSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionSoundID", out exists);
                SetPropertyExistsInBaseData("explosionSoundID", exists);
                SetPropertyExists("explosionSoundID", exists);
                _explosionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionType", out exists);
                SetPropertyExistsInBaseData("explosionType", exists);
                SetPropertyExists("explosionType", exists);

                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance", out exists);
                SetPropertyExistsInBaseData("renderingDistance", exists);
                SetPropertyExists("renderingDistance", exists);
                _shakeDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shakeDistance", out exists);
                SetPropertyExistsInBaseData("shakeDistance", exists);
                SetPropertyExists("shakeDistance", exists);
                _pushForce = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "pushForce", out exists);
                SetPropertyExistsInBaseData("pushForce", exists);
                SetPropertyExists("pushForce", exists);
                _damage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damage", out exists);
                SetPropertyExistsInBaseData("damage", exists);
                SetPropertyExists("damage", exists);
                _maxSounds = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxSounds", out exists);
                SetPropertyExistsInBaseData("maxSounds", exists);
                SetPropertyExists("maxSounds", exists);

                _life = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "life", out exists);
                SetPropertyExistsInBaseData("life", exists);
                SetPropertyExists("life", exists);
                _angularForce = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "angularForce", out exists);
                SetPropertyExistsInBaseData("angularForce", exists);
                SetPropertyExists("angularForce", exists);

                _bCausesShake = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCausesShake", out exists);
                SetPropertyExistsInBaseData("bCausesShake", exists);
                SetPropertyExists("bCausesShake", exists);

                _impactSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "impactSize", out exists);
                SetPropertyExistsInBaseData("impactSize", exists);
                SetPropertyExists("impactSize", exists);

            }
        }
    }
}
