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

        [Description("particleSystemName is a plaintext string"), Category("Plaintext Strings")]
        public string particleSystemName
        {
            get => _particleSystemName;
            set => _particleSystemName = value;
        }

        [Description("explosionSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string explosionSoundID
        {
            get => _explosionSoundID;
            set => _explosionSoundID = value;
        }

        [Description("explosionType is a plaintext string"), Category("Plaintext Strings")]
        public string explosionType
        {
            get => _explosionType;
            set => _explosionType = value;
        }


        [Description("renderingDistance is an integer"), Category("Integers")]
        public int renderingDistance
        {
            get => _renderingDistance;
            set => _renderingDistance = value;
        }

        [Description("shakeDistance is an integer"), Category("Integers")]
        public int shakeDistance
        {
            get => _shakeDistance;
            set => _shakeDistance = value;
        }

        [Description("pushForce is an integer"), Category("Integers")]
        public int pushForce
        {
            get => _pushForce;
            set => _pushForce = value;
        }

        [Description("damage is an integer"), Category("Integers")]
        public int damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("maxSounds is an integer"), Category("Integers")]
        public int maxSounds
        {
            get => _maxSounds;
            set => _maxSounds = value;
        }


        [Description("life is a real number"), Category("Real Numbers")]
        public float life
        {
            get => _life;
            set => _life = value;
        }

        [Description("angularForce is a real number"), Category("Real Numbers")]
        public float angularForce
        {
            get => _angularForce;
            set => _angularForce = value;
        }


        [Description("bCausesShake is a boolean value"), Category("Booleans")]
        public bool bCausesShake
        {
            get => _bCausesShake;
            set => _bCausesShake = value;
        }


        [Description("impactSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D impactSize
        {
            get => _impactSize;
            set => _impactSize = value;
        }



        public ExplosionData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _effectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "effectType");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName");
                _explosionSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionSoundID");
                _explosionType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "explosionType");

                _renderingDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "renderingDistance");
                _shakeDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "shakeDistance");
                _pushForce = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "pushForce");
                _damage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damage");
                _maxSounds = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "maxSounds");

                _life = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "life");
                _angularForce = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "angularForce");

                _bCausesShake = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bCausesShake");

                _impactSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "impactSize");

            }
        }
    }
}
