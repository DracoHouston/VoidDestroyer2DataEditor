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
    class LauncherData : VD2Data
    {
        string _weaponType;
        string _weaponID;
        string _ammunitionID;
        string _name;
        string _fireSoundID;
        string _muzzleFlashEffectID;

        int _capacity;
        int _randomLaunchAngle;
        int _randomLaunchSpeed;

        float _reFireRate;
        float _reloadTime;
        float _launchVelocity;

        bool _bRequiresBeamWeapon;
        bool _bNoLifeLimit;
        bool _bFireFullAmmo;
        bool _bRequiresCollisionWeapon;

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

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings")]
        public string ammunitionID
        {
            get => _ammunitionID;
            set => _ammunitionID = value;
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings")]
        public string name
        {
            get => _name;
            set => _name = value;
        }

        [Description("fireSoundID is a plaintext string"), Category("Plaintext Strings")]
        public string fireSoundID
        {
            get => _fireSoundID;
            set => _fireSoundID = value;
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings")]
        public string muzzleFlashEffectID
        {
            get => _muzzleFlashEffectID;
            set => _muzzleFlashEffectID = value;
        }


        [Description("capacity is an integer"), Category("Integers")]
        public int capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        [Description("randomLaunchAngle is an integer"), Category("Integers")]
        public int randomLaunchAngle
        {
            get => _randomLaunchAngle;
            set => _randomLaunchAngle = value;
        }

        [Description("randomLaunchSpeed is an integer"), Category("Integers")]
        public int randomLaunchSpeed
        {
            get => _randomLaunchSpeed;
            set => _randomLaunchSpeed = value;
        }


        [Description("reFireRate is a real number"), Category("Real Numbers")]
        public float reFireRate
        {
            get => _reFireRate;
            set => _reFireRate = value;
        }

        [Description("reloadTime is a real number"), Category("Real Numbers")]
        public float reloadTime
        {
            get => _reloadTime;
            set => _reloadTime = value;
        }

        [Description("launchVelocity is a real number"), Category("Real Numbers")]
        public float launchVelocity
        {
            get => _launchVelocity;
            set => _launchVelocity = value;
        }


        [Description("bRequiresBeamWeapon is a boolean value"), Category("Booleans")]
        public bool bRequiresBeamWeapon
        {
            get => _bRequiresBeamWeapon;
            set => _bRequiresBeamWeapon = value;
        }

        [Description("bNoLifeLimit is a boolean value"), Category("Booleans")]
        public bool bNoLifeLimit
        {
            get => _bNoLifeLimit;
            set => _bNoLifeLimit = value;
        }

        [Description("bFireFullAmmo is a boolean value"), Category("Booleans")]
        public bool bFireFullAmmo
        {
            get => _bFireFullAmmo;
            set => _bFireFullAmmo = value;
        }

        [Description("bRequiresCollisionWeapon is a boolean value"), Category("Booleans")]
        public bool bRequiresCollisionWeapon
        {
            get => _bRequiresCollisionWeapon;
            set => _bRequiresCollisionWeapon = value;
        }



        public LauncherData(string inPath) : base(inPath)
        {
            if (DataXMLDoc != null)
            {
                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType");
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID");
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID");
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name");
                _fireSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireSoundID");
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID");

                _capacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "capacity");
                _randomLaunchAngle = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchAngle");
                _randomLaunchSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchSpeed");

                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate");
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime");
                _launchVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchVelocity");

                _bRequiresBeamWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresBeamWeapon");
                _bNoLifeLimit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLifeLimit");
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo");
                _bRequiresCollisionWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresCollisionWeapon");

            }
        }
    }
}
