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
    class DockedMovingElementData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _soundID;

        int _proximityDistance;

        float _moveAwayTimeDuration;

        bool _bOpenOnProximity;

        Vector3D _translateVector;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings")]
        public string objectType
        {
            get => _objectType;
            set => _objectType = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("objectID is a plaintext string"), Category("Plaintext Strings")]
        public string objectID
        {
            get => _objectID;
            set => _objectID = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("soundID is a plaintext string"), Category("Plaintext Strings")]
        public string soundID
        {
            get => _soundID;
            set => _soundID = value;
        }


        [Description("proximityDistance is an integer"), Category("Integers")]
        public int proximityDistance
        {
            get => _proximityDistance;
            set => _proximityDistance = value;
        }


        [Description("moveAwayTimeDuration is a real number"), Category("Real Numbers")]
        public float moveAwayTimeDuration
        {
            get => _moveAwayTimeDuration;
            set => _moveAwayTimeDuration = value;
        }


        [Description("bOpenOnProximity is a boolean value"), Category("Booleans")]
        public bool bOpenOnProximity
        {
            get => _bOpenOnProximity;
            set => _bOpenOnProximity = value;
        }


        [Description("translateVector is a 3D vector"), Category("3D Vectors")]
        public Vector3D translateVector
        {
            get => _translateVector;
            set => _translateVector = value;
        }



        public DockedMovingElementData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _soundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "soundID");

                _proximityDistance = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "proximityDistance");

                _moveAwayTimeDuration = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "moveAwayTimeDuration");

                _bOpenOnProximity = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOpenOnProximity");

                _translateVector = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateVector");

            }
        }
    }
}
