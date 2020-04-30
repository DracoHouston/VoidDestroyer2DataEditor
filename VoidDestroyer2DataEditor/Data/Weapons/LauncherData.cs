using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public class LauncherData : VD2Data
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

        [Description("weaponType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponType
        {
            get
            {
                return _weaponType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponType = value;
                        SetPropertyEdited("weaponType", true);
                    }
                }
            }
        }

        [Description("weaponID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string weaponID
        {
            get
            {
                return _weaponID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _weaponID = value;
                        SetPropertyEdited("weaponID", true);
                    }
                }
            }
        }

        [Description("ammunitionID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string ammunitionID
        {
            get
            {
                return _ammunitionID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _ammunitionID = value;
                        SetPropertyEdited("ammunitionID", true);
                    }
                }
            }
        }

        [Description("name is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _name = value;
                        SetPropertyEdited("name", true);
                    }
                }
            }
        }

        [Description("fireSoundID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string fireSoundID
        {
            get
            {
                return _fireSoundID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _fireSoundID = value;
                        SetPropertyEdited("fireSoundID", true);
                    }
                }
            }
        }

        [Description("muzzleFlashEffectID is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor)), TypeConverter(typeof(ObjectIDRefTypeConverter))]
        public string muzzleFlashEffectID
        {
            get
            {
                return _muzzleFlashEffectID;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _muzzleFlashEffectID = value;
                        SetPropertyEdited("muzzleFlashEffectID", true);
                    }
                }
            }
        }


        [Description("capacity is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _capacity = value;
                        SetPropertyEdited("capacity", true);
                    }
                }
            }
        }

        [Description("randomLaunchAngle is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int randomLaunchAngle
        {
            get
            {
                return _randomLaunchAngle;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _randomLaunchAngle = value;
                        SetPropertyEdited("randomLaunchAngle", true);
                    }
                }
            }
        }

        [Description("randomLaunchSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int randomLaunchSpeed
        {
            get
            {
                return _randomLaunchSpeed;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _randomLaunchSpeed = value;
                        SetPropertyEdited("randomLaunchSpeed", true);
                    }
                }
            }
        }


        [Description("reFireRate is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reFireRate
        {
            get
            {
                return _reFireRate;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reFireRate = value;
                        SetPropertyEdited("reFireRate", true);
                    }
                }
            }
        }

        [Description("reloadTime is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float reloadTime
        {
            get
            {
                return _reloadTime;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _reloadTime = value;
                        SetPropertyEdited("reloadTime", true);
                    }
                }
            }
        }

        [Description("launchVelocity is a real number"), Category("Real Numbers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public float launchVelocity
        {
            get
            {
                return _launchVelocity;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _launchVelocity = value;
                        SetPropertyEdited("launchVelocity", true);
                    }
                }
            }
        }


        [Description("bRequiresBeamWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRequiresBeamWeapon
        {
            get
            {
                return _bRequiresBeamWeapon;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRequiresBeamWeapon = value;
                        SetPropertyEdited("bRequiresBeamWeapon", true);
                    }
                }
            }
        }

        [Description("bNoLifeLimit is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bNoLifeLimit
        {
            get
            {
                return _bNoLifeLimit;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bNoLifeLimit = value;
                        SetPropertyEdited("bNoLifeLimit", true);
                    }
                }
            }
        }

        [Description("bFireFullAmmo is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bFireFullAmmo
        {
            get
            {
                return _bFireFullAmmo;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bFireFullAmmo = value;
                        SetPropertyEdited("bFireFullAmmo", true);
                    }
                }
            }
        }

        [Description("bRequiresCollisionWeapon is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool bRequiresCollisionWeapon
        {
            get
            {
                return _bRequiresCollisionWeapon;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _bRequiresCollisionWeapon = value;
                        SetPropertyEdited("bRequiresCollisionWeapon", true);
                    }
                }
            }
        }


        public override void InitAllProperties()
        {
            InitProperty("weaponType");
            InitProperty("weaponID");
            SetPropertyIsObjectID("weaponID", true);
            InitProperty("ammunitionID");
            List<string> ammunitionIDreftypes = new List<string>();
            ammunitionIDreftypes.Add("Missile");
            ammunitionIDreftypes.Add("Mine");
            SetPropertyIsObjectIDRef("ammunitionID", true, ammunitionIDreftypes);
            InitProperty("name");
            InitProperty("fireSoundID");
            List<string> fireSoundIDreftypes = new List<string>();
            fireSoundIDreftypes.Add("Sound");
            SetPropertyIsObjectIDRef("fireSoundID", true, fireSoundIDreftypes);
            InitProperty("muzzleFlashEffectID");
            List<string> muzzleFlashEffectIDreftypes = new List<string>();
            muzzleFlashEffectIDreftypes.Add("Particle");
            SetPropertyIsObjectIDRef("muzzleFlashEffectID", true, muzzleFlashEffectIDreftypes);

            InitProperty("capacity");
            InitProperty("randomLaunchAngle");
            InitProperty("randomLaunchSpeed");

            InitProperty("reFireRate");
            InitProperty("reloadTime");
            InitProperty("launchVelocity");

            InitProperty("bRequiresBeamWeapon");
            InitProperty("bNoLifeLimit");
            InitProperty("bFireFullAmmo");
            InitProperty("bRequiresCollisionWeapon");

        }

        public LauncherData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
        {
        }

        public override void LoadDataFromXML()
        {
            bool exists = false;
            if (DataXMLDoc != null)
            {
                _weaponID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(weaponID, "weaponID"));
                }
                SetPropertyExists("weaponID", exists);

                _weaponType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "weaponType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("weaponType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("weaponType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "weaponType"));
                }
                SetPropertyExists("weaponType", exists);
                _ammunitionID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "ammunitionID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("ammunitionID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("ammunitionID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "ammunitionID"));
                }
                SetPropertyExists("ammunitionID", exists);
                _name = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "name", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("name", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("name", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "name"));
                }
                SetPropertyExists("name", exists);
                _fireSoundID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "fireSoundID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("fireSoundID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("fireSoundID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "fireSoundID"));
                }
                SetPropertyExists("fireSoundID", exists);
                _muzzleFlashEffectID = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "muzzleFlashEffectID", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("muzzleFlashEffectID", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "muzzleFlashEffectID"));
                }
                SetPropertyExists("muzzleFlashEffectID", exists);

                _capacity = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "capacity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("capacity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("capacity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "capacity"));
                }
                SetPropertyExists("capacity", exists);
                _randomLaunchAngle = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchAngle", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("randomLaunchAngle", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("randomLaunchAngle", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "randomLaunchAngle"));
                }
                SetPropertyExists("randomLaunchAngle", exists);
                _randomLaunchSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "randomLaunchSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("randomLaunchSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("randomLaunchSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "randomLaunchSpeed"));
                }
                SetPropertyExists("randomLaunchSpeed", exists);

                _reFireRate = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reFireRate", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reFireRate", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reFireRate", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reFireRate"));
                }
                SetPropertyExists("reFireRate", exists);
                _reloadTime = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "reloadTime", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("reloadTime", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("reloadTime", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "reloadTime"));
                }
                SetPropertyExists("reloadTime", exists);
                _launchVelocity = ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, "launchVelocity", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("launchVelocity", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("launchVelocity", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "launchVelocity"));
                }
                SetPropertyExists("launchVelocity", exists);

                _bRequiresBeamWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresBeamWeapon", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRequiresBeamWeapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRequiresBeamWeapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRequiresBeamWeapon"));
                }
                SetPropertyExists("bRequiresBeamWeapon", exists);
                _bNoLifeLimit = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bNoLifeLimit", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bNoLifeLimit", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bNoLifeLimit", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bNoLifeLimit"));
                }
                SetPropertyExists("bNoLifeLimit", exists);
                _bFireFullAmmo = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bFireFullAmmo", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bFireFullAmmo", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bFireFullAmmo"));
                }
                SetPropertyExists("bFireFullAmmo", exists);
                _bRequiresCollisionWeapon = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "bRequiresCollisionWeapon", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("bRequiresCollisionWeapon", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("bRequiresCollisionWeapon", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "bRequiresCollisionWeapon"));
                }
                SetPropertyExists("bRequiresCollisionWeapon", exists);

                base.LoadDataFromXML();
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
            if (PropertyExists("weaponType"))
            {
                xmltextlines.Add("<weaponType attr1=\"" + _weaponType + "\"/>");
            }
            if (PropertyExists("weaponID"))
            {
                xmltextlines.Add("<weaponID attr1=\"" + _weaponID + "\"/>");
            }
            if (PropertyExists("ammunitionID"))
            {
                xmltextlines.Add("<ammunitionID attr1=\"" + _ammunitionID + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("fireSoundID"))
            {
                xmltextlines.Add("<fireSoundID attr1=\"" + _fireSoundID + "\"/>");
            }
            if (PropertyExists("muzzleFlashEffectID"))
            {
                xmltextlines.Add("<muzzleFlashEffectID attr1=\"" + _muzzleFlashEffectID + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("capacity"))
            {
                xmltextlines.Add("<capacity attr1=\"" + _capacity.ToString() + "\"/>");
            }
            if (PropertyExists("randomLaunchAngle"))
            {
                xmltextlines.Add("<randomLaunchAngle attr1=\"" + _randomLaunchAngle.ToString() + "\"/>");
            }
            if (PropertyExists("randomLaunchSpeed"))
            {
                xmltextlines.Add("<randomLaunchSpeed attr1=\"" + _randomLaunchSpeed.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Floats...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("reFireRate"))
            {
                xmltextlines.Add("<reFireRate attr1=\"" + _reFireRate.ToString() + "\"/>");
            }
            if (PropertyExists("reloadTime"))
            {
                xmltextlines.Add("<reloadTime attr1=\"" + _reloadTime.ToString() + "\"/>");
            }
            if (PropertyExists("launchVelocity"))
            {
                xmltextlines.Add("<launchVelocity attr1=\"" + _launchVelocity.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("bRequiresBeamWeapon"))
            {
                xmltextlines.Add("<bRequiresBeamWeapon attr1=\"" + ((_bRequiresBeamWeapon) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bNoLifeLimit"))
            {
                xmltextlines.Add("<bNoLifeLimit attr1=\"" + ((_bNoLifeLimit) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bFireFullAmmo"))
            {
                xmltextlines.Add("<bFireFullAmmo attr1=\"" + ((_bFireFullAmmo) ? "1" : "0") + "\"/>");
            }
            if (PropertyExists("bRequiresCollisionWeapon"))
            {
                xmltextlines.Add("<bRequiresCollisionWeapon attr1=\"" + ((_bRequiresCollisionWeapon) ? "1" : "0") + "\"/>");
            }

            File.WriteAllLines(_FilePath, xmltextlines);
        }
    }
}
