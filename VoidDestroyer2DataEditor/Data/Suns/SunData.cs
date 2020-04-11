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
    public class SunData : VD2Data
    {
        string _objectType;
        string _sunType;
        string _name;
        string _objectID;
        string _materialName;
        string _billboardFlareMaterial;
        string _faction;
        string _meshName;
        string _wireframeMaterial;
        string _sunFlareParticleSystem;
        string _collisionShape;
        string _additionalObjectMesh;

        int _flareSize;
        int _scale;
        int _overworldScale;
        int _rotateSpeed;
        int _collisionShapeScale;

        bool _isMassInfinite;

        ColorF _specularColor;
        ColorF _diffuseColor;

        ObservableCollection<damageCollisionFieldDataStructure> _damageCollisionField;

        [Description("objectType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string objectType
        {
            get
            {
                return _objectType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _objectType = value;
                        SetPropertyEdited("objectType", true);
                    }
                }
            }
        }

        [Description("sunType is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sunType
        {
            get
            {
                return _sunType;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _sunType = value;
                        SetPropertyEdited("sunType", true);
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

        [Description("materialName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string materialName
        {
            get
            {
                return _materialName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _materialName = value;
                        SetPropertyEdited("materialName", true);
                    }
                }
            }
        }

        [Description("billboardFlareMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string billboardFlareMaterial
        {
            get
            {
                return _billboardFlareMaterial;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _billboardFlareMaterial = value;
                        SetPropertyEdited("billboardFlareMaterial", true);
                    }
                }
            }
        }

        [Description("faction is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string faction
        {
            get
            {
                return _faction;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _faction = value;
                        SetPropertyEdited("faction", true);
                    }
                }
            }
        }

        [Description("meshName is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string meshName
        {
            get
            {
                return _meshName;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _meshName = value;
                        SetPropertyEdited("meshName", true);
                    }
                }
            }
        }

        [Description("wireframeMaterial is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wireframeMaterial
        {
            get
            {
                return _wireframeMaterial;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _wireframeMaterial = value;
                        SetPropertyEdited("wireframeMaterial", true);
                    }
                }
            }
        }

        [Description("sunFlareParticleSystem is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string sunFlareParticleSystem
        {
            get
            {
                return _sunFlareParticleSystem;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _sunFlareParticleSystem = value;
                        SetPropertyEdited("sunFlareParticleSystem", true);
                    }
                }
            }
        }

        [Description("collisionShape is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string collisionShape
        {
            get
            {
                return _collisionShape;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionShape = value;
                        SetPropertyEdited("collisionShape", true);
                    }
                }
            }
        }

        [Description("additionalObjectMesh is a plaintext string"), Category("Plaintext Strings"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string additionalObjectMesh
        {
            get
            {
                return _additionalObjectMesh;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _additionalObjectMesh = value;
                        SetPropertyEdited("additionalObjectMesh", true);
                    }
                }
            }
        }


        [Description("flareSize is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int flareSize
        {
            get
            {
                return _flareSize;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _flareSize = value;
                        SetPropertyEdited("flareSize", true);
                    }
                }
            }
        }

        [Description("scale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int scale
        {
            get
            {
                return _scale;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _scale = value;
                        SetPropertyEdited("scale", true);
                    }
                }
            }
        }

        [Description("overworldScale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int overworldScale
        {
            get
            {
                return _overworldScale;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _overworldScale = value;
                        SetPropertyEdited("overworldScale", true);
                    }
                }
            }
        }

        [Description("rotateSpeed is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int rotateSpeed
        {
            get
            {
                return _rotateSpeed;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _rotateSpeed = value;
                        SetPropertyEdited("rotateSpeed", true);
                    }
                }
            }
        }

        [Description("collisionShapeScale is an integer"), Category("Integers"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int collisionShapeScale
        {
            get
            {
                return _collisionShapeScale;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _collisionShapeScale = value;
                        SetPropertyEdited("collisionShapeScale", true);
                    }
                }
            }
        }


        [Description("isMassInfinite is a boolean value"), Category("Booleans"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool isMassInfinite
        {
            get
            {
                return _isMassInfinite;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _isMassInfinite = value;
                        SetPropertyEdited("isMassInfinite", true);
                    }
                }
            }
        }


        [Description("specularColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF specularColor
        {
            get
            {
                return _specularColor;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _specularColor = value;
                        SetPropertyEdited("specularColor", true);
                    }
                }
            }
        }

        [Description("diffuseColor is a Color"), Category("Colors"), Editor(typeof(VD2UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ColorF diffuseColor
        {
            get
            {
                return _diffuseColor;
            }
            set
            {
                if (Source != null)
                {
                    if (Source.WriteAccess)
                    {
                        _diffuseColor = value;
                        SetPropertyEdited("diffuseColor", true);
                    }
                }
            }
        }


        [Description("damageCollisionField is a collection of datastructures"), Category("Data Structure Collections")]
        public ObservableCollection<damageCollisionFieldDataStructure> damageCollisionField
        {
            get
            {
                return _damageCollisionField;
            }
            set
            {
                _damageCollisionField = value;
            }
        }

        private void OndamageCollisionFieldChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Source != null)
            {
                if (Source.WriteAccess)
                {
                    SetPropertyEdited("damageCollisionField", true);
                }
                else
                {
                    bool exists = false;
                    _damageCollisionField = new ObservableCollection<damageCollisionFieldDataStructure>(DataStructureParseHelpers.GetdamageCollisionFieldDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                    _damageCollisionField.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndamageCollisionFieldChanged);
                    if (Source.ShortName == "Base")
                    {
                        SetPropertyExistsInBaseData("damageCollisionField", exists);
                    }
                    else
                    {
                        SetPropertyExistsInBaseData("damageCollisionField", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damageCollisionField"));
                    }
                    SetPropertyExists("damageCollisionField", exists);
                }
            }
        }

        public override void InitAllProperties()
        {
            InitProperty("objectType");
            InitProperty("sunType");
            InitProperty("name");
            InitProperty("objectID");
            SetPropertyIsObjectID("objectID", true);
            InitProperty("materialName");
            InitProperty("billboardFlareMaterial");
            InitProperty("faction");
            InitProperty("meshName");
            InitProperty("wireframeMaterial");
            InitProperty("sunFlareParticleSystem");
            InitProperty("collisionShape");
            InitProperty("additionalObjectMesh");

            InitProperty("flareSize");
            InitProperty("scale");
            InitProperty("overworldScale");
            InitProperty("rotateSpeed");
            InitProperty("collisionShapeScale");

            InitProperty("isMassInfinite");

            InitProperty("specularColor");
            InitProperty("diffuseColor");

            InitProperty("damageCollisionField");
        }

        public SunData(string inPath, VD2FileSource inSource) : base(inPath, inSource)
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

                _objectType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "objectType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("objectType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("objectType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "objectType"));
                }
                SetPropertyExists("objectType", exists);
                _sunType = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunType", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("sunType", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("sunType", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "sunType"));
                }
                SetPropertyExists("sunType", exists);
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
                _materialName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "materialName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("materialName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("materialName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "materialName"));
                }
                SetPropertyExists("materialName", exists);
                _billboardFlareMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "billboardFlareMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("billboardFlareMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("billboardFlareMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "billboardFlareMaterial"));
                }
                SetPropertyExists("billboardFlareMaterial", exists);
                _faction = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "faction", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("faction", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("faction", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "faction"));
                }
                SetPropertyExists("faction", exists);
                _meshName = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "meshName", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("meshName", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("meshName", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "meshName"));
                }
                SetPropertyExists("meshName", exists);
                _wireframeMaterial = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "wireframeMaterial", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("wireframeMaterial", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "wireframeMaterial"));
                }
                SetPropertyExists("wireframeMaterial", exists);
                _sunFlareParticleSystem = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "sunFlareParticleSystem", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("sunFlareParticleSystem", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("sunFlareParticleSystem", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "sunFlareParticleSystem"));
                }
                SetPropertyExists("sunFlareParticleSystem", exists);
                _collisionShape = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "collisionShape", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionShape", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionShape", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShape"));
                }
                SetPropertyExists("collisionShape", exists);
                _additionalObjectMesh = ParseHelpers.GetStringFromVD2Data(DataXMLDoc, "additionalObjectMesh", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("additionalObjectMesh", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("additionalObjectMesh", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "additionalObjectMesh"));
                }
                SetPropertyExists("additionalObjectMesh", exists);

                _flareSize = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "flareSize", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("flareSize", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("flareSize", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "flareSize"));
                }
                SetPropertyExists("flareSize", exists);
                _scale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "scale", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("scale", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("scale", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "scale"));
                }
                SetPropertyExists("scale", exists);
                _overworldScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "overworldScale", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("overworldScale", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("overworldScale", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "overworldScale"));
                }
                SetPropertyExists("overworldScale", exists);
                _rotateSpeed = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "rotateSpeed", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("rotateSpeed", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("rotateSpeed", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "rotateSpeed"));
                }
                SetPropertyExists("rotateSpeed", exists);
                _collisionShapeScale = ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, "collisionShapeScale", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("collisionShapeScale", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("collisionShapeScale", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "collisionShapeScale"));
                }
                SetPropertyExists("collisionShapeScale", exists);

                _isMassInfinite = ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, "isMassInfinite", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("isMassInfinite", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("isMassInfinite", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "isMassInfinite"));
                }
                SetPropertyExists("isMassInfinite", exists);

                _specularColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "specularColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("specularColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("specularColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "specularColor"));
                }
                SetPropertyExists("specularColor", exists);
                _diffuseColor = ParseHelpers.GetColorFromVD2Data(DataXMLDoc, "diffuseColor", out exists);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("diffuseColor", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("diffuseColor", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "diffuseColor"));
                }
                SetPropertyExists("diffuseColor", exists);

                _damageCollisionField =  new ObservableCollection<damageCollisionFieldDataStructure>(DataStructureParseHelpers.GetdamageCollisionFieldDataStructureListFromVD2Data(this, DataXMLDoc, out exists));
                _damageCollisionField.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(this.OndamageCollisionFieldChanged);
                if (Source.ShortName == "Base")
                {
                    SetPropertyExistsInBaseData("damageCollisionField", exists);
                }
                else
                {
                    SetPropertyExistsInBaseData("damageCollisionField", EditorUI.UI.Ships.DoesPropertyExistInBaseData(GetObjectID(), "damageCollisionField"));
                }
                SetPropertyExists("damageCollisionField", exists);
            }
        }

        public override void SaveData()
        {
            List<string> xmltextlines = new List<string>();
            xmltextlines.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmltextlines.Add("<note_to_self attr1=\"Generated by Void Destroyer 2 Data Editor\"/>");
            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Strings...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("objectType"))
            {
                xmltextlines.Add("<objectType attr1=\"" + _objectType + "\"/>");
            }
            if (PropertyExists("sunType"))
            {
                xmltextlines.Add("<sunType attr1=\"" + _sunType + "\"/>");
            }
            if (PropertyExists("name"))
            {
                xmltextlines.Add("<name attr1=\"" + _name + "\"/>");
            }
            if (PropertyExists("objectID"))
            {
                xmltextlines.Add("<objectID attr1=\"" + _objectID + "\"/>");
            }
            if (PropertyExists("materialName"))
            {
                xmltextlines.Add("<materialName attr1=\"" + _materialName + "\"/>");
            }
            if (PropertyExists("billboardFlareMaterial"))
            {
                xmltextlines.Add("<billboardFlareMaterial attr1=\"" + _billboardFlareMaterial + "\"/>");
            }
            if (PropertyExists("faction"))
            {
                xmltextlines.Add("<faction attr1=\"" + _faction + "\"/>");
            }
            if (PropertyExists("meshName"))
            {
                xmltextlines.Add("<meshName attr1=\"" + _meshName + "\"/>");
            }
            if (PropertyExists("wireframeMaterial"))
            {
                xmltextlines.Add("<wireframeMaterial attr1=\"" + _wireframeMaterial + "\"/>");
            }
            if (PropertyExists("sunFlareParticleSystem"))
            {
                xmltextlines.Add("<sunFlareParticleSystem attr1=\"" + _sunFlareParticleSystem + "\"/>");
            }
            if (PropertyExists("collisionShape"))
            {
                xmltextlines.Add("<collisionShape attr1=\"" + _collisionShape + "\"/>");
            }
            if (PropertyExists("additionalObjectMesh"))
            {
                xmltextlines.Add("<additionalObjectMesh attr1=\"" + _additionalObjectMesh + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Integers...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("flareSize"))
            {
                xmltextlines.Add("<flareSize attr1=\"" + _flareSize.ToString() + "\"/>");
            }
            if (PropertyExists("scale"))
            {
                xmltextlines.Add("<scale attr1=\"" + _scale.ToString() + "\"/>");
            }
            if (PropertyExists("overworldScale"))
            {
                xmltextlines.Add("<overworldScale attr1=\"" + _overworldScale.ToString() + "\"/>");
            }
            if (PropertyExists("rotateSpeed"))
            {
                xmltextlines.Add("<rotateSpeed attr1=\"" + _rotateSpeed.ToString() + "\"/>");
            }
            if (PropertyExists("collisionShapeScale"))
            {
                xmltextlines.Add("<collisionShapeScale attr1=\"" + _collisionShapeScale.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Booleans...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("isMassInfinite"))
            {
                xmltextlines.Add("<isMassInfinite attr1=\"" + ((_isMassInfinite) ? "1" : "0") + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Colors...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("specularColor"))
            {
                xmltextlines.Add("<specularColor r=\"" + _specularColor.r.ToString() + "\" g=\"" + _specularColor.g.ToString() + "\" b=\"" + _specularColor.b.ToString() + "\" a=\"" + _specularColor.a.ToString() + "\"/>");
            }
            if (PropertyExists("diffuseColor"))
            {
                xmltextlines.Add("<diffuseColor r=\"" + _diffuseColor.r.ToString() + "\" g=\"" + _diffuseColor.g.ToString() + "\" b=\"" + _diffuseColor.b.ToString() + "\" a=\"" + _diffuseColor.a.ToString() + "\"/>");
            }

            xmltextlines.Add("");
            xmltextlines.Add("<note_to_self attr1=\"Data Structure Collections...\"/>");
            xmltextlines.Add("");
            if (PropertyExists("damageCollisionField"))
            {
                foreach (damageCollisionFieldDataStructure result in _damageCollisionField)
                {
                    xmltextlines.AddRange(result.AsVD2XML());
                }
                xmltextlines.Add("");
            }

            File.WriteAllLines("testsavedship.xml", xmltextlines);
        }
    }
}
