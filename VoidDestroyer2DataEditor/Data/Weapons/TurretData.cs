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
    class TurretData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _name;
        string _turretWeapon;
        string _hardpointID;
        string _linkedMovingElement;
        string _meshName;
        string _turnSoundID;

        int _mineQuota;

        float _barrelDelay;
        float _pitchMax;
        float _dMoveSpeed;

        bool _bAlwaysShowInTactical;
        bool _bPhysicalBody;
        bool _bInvisibleTurret;
        bool _bOssilateTargetAimNodeOffset;

        Vector3D _turretViewPos;

        weaponDirectionDataStructure _weaponDirection;
        targetPriorityListDataStructure _targetPriorityList;

        List<turretBarrelDataStructure> _turretBarrel;

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings")]
        public string weaponType
        {
            get => _weaponType;
            set => _weaponType = value;
        }

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings")]
        public string weaponID
        {
            get => _weaponID;
            set => _weaponID = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("turretWeapon is a plaintext string"), Category("Plaintext Strings")]
        public string turretWeapon
        {
            get => _turretWeapon;
            set => _turretWeapon = value;
        }

        [Description("hardpointID is a plaintext string"), Category("Plaintext Strings")]
        public string hardpointID
        {
            get => _hardpointID;
            set => _hardpointID = value;
        }

        [Description("linkedMovingElement is a plaintext string"), Category("Plaintext Strings")]
        public string linkedMovingElement
        {
            get => _linkedMovingElement;
            set => _linkedMovingElement = value;
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings")]
        public string meshName
        {
            get => _meshName;
            set => _meshName = value;
        }

        [Description("turnSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string turnSoundID
        {
            get => _turnSoundID;
            set => _turnSoundID = value;
        }


        [Description("mineQuota is an integer"), Category("Integers")]
        public int mineQuota
        {
            get => _mineQuota;
            set => _mineQuota = value;
        }


        [Description("barrelDelay is a real number"), Category("Real Numbers")]
        public float barrelDelay
        {
            get => _barrelDelay;
            set => _barrelDelay = value;
        }

        [Description("pitchMax is a real number"), Category("Real Numbers")]
        public float pitchMax
        {
            get => _pitchMax;
            set => _pitchMax = value;
        }

        [Description("dMoveSpeed is a real number"), Category("Real Numbers")]
        public float dMoveSpeed
        {
            get => _dMoveSpeed;
            set => _dMoveSpeed = value;
        }


        [Description("bAlwaysShowInTactical is a boolean value"), Category("Booleans")]
        public bool bAlwaysShowInTactical
        {
            get => _bAlwaysShowInTactical;
            set => _bAlwaysShowInTactical = value;
        }

        [Description("bPhysicalBody is a boolean value"), Category("Booleans")]
        public bool bPhysicalBody
        {
            get => _bPhysicalBody;
            set => _bPhysicalBody = value;
        }

        [Description("bInvisibleTurret is a boolean value"), Category("Booleans")]
        public bool bInvisibleTurret
        {
            get => _bInvisibleTurret;
            set => _bInvisibleTurret = value;
        }

        [Description("bOssilateTargetAimNodeOffset is a boolean value"), Category("Booleans")]
        public bool bOssilateTargetAimNodeOffset
        {
            get => _bOssilateTargetAimNodeOffset;
            set => _bOssilateTargetAimNodeOffset = value;
        }


        [Description("turretViewPos is a 3D vector"), Category("3D Vectors")]
        public Vector3D turretViewPos
        {
            get => _turretViewPos;
            set => _turretViewPos = value;
        }


        [Description("weaponDirection is a datastructure"), Category("Data Structures")]
        public weaponDirectionDataStructure weaponDirection
        {
            get => _weaponDirection;
            set => _weaponDirection = value;
        }

        [Description("targetPriorityList is a datastructure"), Category("Data Structures")]
        public targetPriorityListDataStructure targetPriorityList
        {
            get => _targetPriorityList;
            set => _targetPriorityList = value;
        }


        [Description("turretBarrel is a collection of datastructures"), Category("Data Structure Collections")]
        public List<turretBarrelDataStructure> turretBarrel
        {
            get => _turretBarrel;
            set => _turretBarrel = value;
        }


        public TurretData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType");
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _turretWeapon = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turretWeapon");
                _hardpointID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "hardpointID");
                _linkedMovingElement = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "linkedMovingElement");
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName");
                _turnSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "turnSoundID");

                _mineQuota = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "mineQuota");

                _barrelDelay = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "barrelDelay");
                _pitchMax = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "pitchMax");
                _dMoveSpeed = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "dMoveSpeed");

                _bAlwaysShowInTactical = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bAlwaysShowInTactical");
                _bPhysicalBody = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bPhysicalBody");
                _bInvisibleTurret = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bInvisibleTurret");
                _bOssilateTargetAimNodeOffset = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bOssilateTargetAimNodeOffset");

                _turretViewPos = ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, "turretViewPos");

                _weaponDirection = DataStructureParseHelpers.GetweaponDirectionDataStructureFromVD2Data(DataXMLDoc);
                _targetPriorityList = DataStructureParseHelpers.GettargetPriorityListDataStructureFromVD2Data(DataXMLDoc);

                _turretBarrel = DataStructureParseHelpers.GetturretBarrelDataStructureListFromVD2Data(DataXMLDoc);
            }
        }
    }
}
