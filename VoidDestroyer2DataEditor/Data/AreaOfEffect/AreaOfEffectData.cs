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
    class AreaOfEffectData : VD2Data
    {
        string _objectID;
        string _particleSystemName;
        string _affectedObjects;

        int _damage;
        int _lifeTimer;

        bool _bRefuel;
        bool _bDebrisFieldRadiation;

        Vector3D _fieldSize;

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

        [Description("affectedObjects is a plaintext string"), Category("Plaintext Strings")]
        public string affectedObjects
        {
            get => _affectedObjects;
            set => _affectedObjects = value;
        }


        [Description("damage is an integer"), Category("Integers")]
        public int damage
        {
            get => _damage;
            set => _damage = value;
        }

        [Description("lifeTimer is an integer"), Category("Integers")]
        public int lifeTimer
        {
            get => _lifeTimer;
            set => _lifeTimer = value;
        }


        [Description("bRefuel is a boolean value"), Category("Booleans")]
        public bool bRefuel
        {
            get => _bRefuel;
            set => _bRefuel = value;
        }

        [Description("bDebrisFieldRadiation is a boolean value"), Category("Booleans")]
        public bool bDebrisFieldRadiation
        {
            get => _bDebrisFieldRadiation;
            set => _bDebrisFieldRadiation = value;
        }


        [Description("fieldSize is a 3D vector"), Category("3D Vectors")]
        public Vector3D fieldSize
        {
            get => _fieldSize;
            set => _fieldSize = value;
        }



        public AreaOfEffectData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _particleSystemName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "particleSystemName");
                _affectedObjects = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "affectedObjects");

                _damage = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "damage");
                _lifeTimer = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "lifeTimer");

                _bRefuel = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRefuel");
                _bDebrisFieldRadiation = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bDebrisFieldRadiation");

                _fieldSize = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "fieldSize");

            }
        }
    }
}
