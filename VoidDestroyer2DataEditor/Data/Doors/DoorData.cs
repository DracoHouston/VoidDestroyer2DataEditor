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
    class DoorData : VD2Data
    {
        string _objectType;
        string _name;
        string _objectID;
        string _meshName;
        string _doorSoundID;

        float _openTimeMultiplier;

        bool _bPhysicalDoor;
        bool _bOpenOnProximity;

        Vector3D _translateMax;

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

        [Description("doorSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string doorSoundID
        {
            get => _doorSoundID;
            set => _doorSoundID = value;
        }


        [Description("openTimeMultiplier is a real number"), Category("Real Numbers")]
        public float openTimeMultiplier
        {
            get => _openTimeMultiplier;
            set => _openTimeMultiplier = value;
        }


        [Description("bPhysicalDoor is a boolean value"), Category("Booleans")]
        public bool bPhysicalDoor
        {
            get => _bPhysicalDoor;
            set => _bPhysicalDoor = value;
        }

        [Description("bOpenOnProximity is a boolean value"), Category("Booleans")]
        public bool bOpenOnProximity
        {
            get => _bOpenOnProximity;
            set => _bOpenOnProximity = value;
        }


        [Description("translateMax is a 3D vector"), Category("3D Vectors")]
        public Vector3D translateMax
        {
            get => _translateMax;
            set => _translateMax = value;
        }



        public DoorData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _objectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectID");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _doorSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "doorSoundID");

                _openTimeMultiplier = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "openTimeMultiplier");

                _bPhysicalDoor = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalDoor");
                _bOpenOnProximity = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOpenOnProximity");

                _translateMax = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "translateMax");

            }
        }
    }
}
