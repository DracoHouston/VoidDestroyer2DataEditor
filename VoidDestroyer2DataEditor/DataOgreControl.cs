using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.ogre;

namespace VoidDestroyer2DataEditor
{
    public partial class DataOgreControl : OgreControl //for now a misnomer, actually just a ship ogre control.
    {
        VD2Data _DataFile;
        public VD2Data DataFile
        {
            get
            {
                return _DataFile;
            }
            set
            {
                _DataFile = value;
            }
        }

        public List<OgreTurret> OgreTurrets;
        public List<OgreShipAttachment> OgreAttachments;

        public SceneNode ShipNode;
        public Entity ShipEntity;

        public DataOgreControl() : base()
        {
            OgreTurrets = new List<OgreTurret>();
            OgreAttachments = new List<OgreShipAttachment>();
            InitializeComponent();
        }

        protected override void SpawnEntities()
        {
            if (DataFile != null)
            {
                DataFile.VD2PropertyChanged += DataFile_VD2PropertyChanged;
                DataFile.OnThisFileLoaded += DataFile_OnThisFileLoaded;
                DataFile.OnThisFileOverriden += DataFile_OnThisFileOverriden;
                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    ShipNode = OgreScene.getRootSceneNode().createChildSceneNode();
                    if (ship.meshName != null)
                    {
                        string meshname = GetTrueFileName(ship.meshName);
                        if (meshname != "")
                        {
                            ShipEntity = OgreScene.createEntity(meshname);
                            distance = ShipEntity.getBoundingRadius() * 1.25f;
                            zoomdistance = distance * 0.1f;
                            OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
                            
                            ShipNode.attachObject(ShipEntity);
                            foreach (VD2DataStructure ds in ship.rotatingElement)
                            {
                                if (ds is rotatingElementDataStructure)
                                {
                                    rotatingElementDataStructure rotating = (rotatingElementDataStructure)ds;
                                    var skele = ShipEntity.getSkeleton();
                                    if (skele != null)
                                    {
                                        var bone = skele.getBone(rotating.boneName);
                                        bone.setManuallyControlled(true);
                                    }                                        
                                }
                            }
                            
                        }
                    }
                    for (int i = 0; i < ship.turret.Count; i++)
                    {
                        if (ship.turret[i] is turretDataStructure)
                        {
                            turretDataStructure turret = (turretDataStructure)ship.turret[i];
                            OgreTurret turretent = new OgreTurret();
                            turretent.ParentOgreControl = this;
                            turretent.SelectedIndex = i;
                            turretent.ShipNode = ShipNode;
                            turretent.TurretDec = turret;
                            List<TurretData> turretdefhits = new List<TurretData>();
                            foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                            {
                                if (turretdata.GetObjectID() == turret.turretID)
                                {
                                        
                                    //turretent.TurretDef = turretdata;

                                    turretdefhits.Add(turretdata);
                                }
                            }
                            TurretData bestdef = null;
                            foreach (TurretData turretdef in turretdefhits)
                            {
                                if (bestdef == null)
                                {
                                    bestdef = turretdef;
                                }
                                else if ((turretdef.Source != null) && (bestdef.Source != null))
                                {
                                    if (turretdef.Source.ShortName == "Mod")
                                    {
                                        if (bestdef.Source.ShortName == "Base")
                                        {
                                            bestdef = turretdef;
                                        }
                                    }
                                }
                            }
                            turretent.TurretDef = bestdef;
                            turretent.Spawn();
                            OgreTurrets.Add(turretent);
                        }
                    }
                    ship.turret.CollectionChanged += Turret_CollectionChanged;
                    for (int i = 0; i < ship.attachment.Count; i++)
                    {
                        if (ship.attachment[i] is attachmentDataStructure)
                        {
                            attachmentDataStructure attachment = (attachmentDataStructure)ship.attachment[i];
                            OgreShipAttachment attachmentent = new OgreShipAttachment();
                            attachmentent.ParentOgreControl = this;
                            attachmentent.SelectedIndex = i;
                            attachmentent.ShipNode = ShipNode;
                            attachmentent.AttachmentDec = attachment;
                            List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                            foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                            {
                                if (attachment.attachmentID.Count > 0)
                                {
                                    if (attachmentdata.GetObjectID() == attachment.attachmentID[0])
                                    {
                                        attachmentdefhits.Add(attachmentdata);
                                    }
                                }
                            }
                            OtherObjectData bestattachmentdef = null;
                            foreach (OtherObjectData attachmentdef in attachmentdefhits)
                            {
                                if (bestattachmentdef == null)
                                {
                                    bestattachmentdef = attachmentdef;
                                }
                                else if ((attachmentdef.Source != null) && (bestattachmentdef.Source != null))
                                {
                                    if (attachmentdef.Source.ShortName == "Mod")
                                    {
                                        if (bestattachmentdef.Source.ShortName == "Base")
                                        {
                                            bestattachmentdef = attachmentdef;
                                        }
                                    }
                                }
                            }
                            attachmentent.AttachmentDef = bestattachmentdef;
                            attachmentent.Spawn();
                            OgreAttachments.Add(attachmentent);
                        }
                    }
                    ship.attachment.CollectionChanged += Attachment_CollectionChanged;
                    OgreRenderer.Renderer.FrameListener.OnFrameEnded += FrameListener_OnFrameEnded;
                }                    
            }
        }

        private void DataFile_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (e.NewFile is ShipData)
            {
                ShipData newdef = (ShipData)e.NewFile;
                if (e.OldFile is ShipData)
                {
                    ShipData testolddef = (ShipData)e.OldFile;
                    if (DataFile != null)
                    {
                        if (testolddef == DataFile)
                        {
                            DataFile = newdef;
                            UpdateShip();
                        }
                    }
                }
            }
        }

        private void UpdateShip()
        {
            if (DataFile is ShipData)
            {
                ShipData ship = (ShipData)DataFile;
                string meshname = (string)ship.meshName;
                meshname = GetTrueFileName(meshname);
                Entity oldshipentity = null;
                if (ShipEntity != null)
                {
                    oldshipentity = ShipEntity;
                }
                ShipEntity = null;
                if (meshname != "")
                {
                    ShipEntity = OgreScene.createEntity(meshname);
                    distance = ShipEntity.getBoundingRadius() * 1.25f;
                    zoomdistance = distance * 0.1f;
                    OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);

                    ShipNode.attachObject(ShipEntity);
                    foreach (VD2DataStructure ds in ship.rotatingElement)
                    {
                        if (ds is rotatingElementDataStructure)
                        {
                            rotatingElementDataStructure rotating = (rotatingElementDataStructure)ds;
                            var skele = ShipEntity.getSkeleton();
                            if (skele != null)
                            {
                                var bone = skele.getBone(rotating.boneName);
                                bone.setManuallyControlled(true);
                            }
                        }
                    }

                }
                if (oldshipentity != null)
                {
                    OgreScene.destroyEntity(oldshipentity);
                }
            }
        }

        private void DataFile_OnThisFileLoaded(object sender, EventArgs e)
        {
            UpdateShip();
        }

        private void DataFile_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            if (DataFile is ShipData)
            {
                ShipData ship = (ShipData)DataFile;
                if (e.PropertyName == "meshName")
                {
                    if (e.NewValue != null)
                    {
                        if (e.NewValue is string)
                        {
                            string meshname = (string)e.NewValue;
                            meshname = GetTrueFileName(meshname);
                            Entity oldshipentity = null;
                            if (ShipEntity != null)
                            {
                                oldshipentity = ShipEntity;
                            }
                            ShipEntity = null;
                            if (meshname != "")
                            {

                                ShipEntity = OgreScene.createEntity(meshname);
                                distance = ShipEntity.getBoundingRadius() * 1.25f;
                                zoomdistance = distance * 0.1f;
                                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);

                                ShipNode.attachObject(ShipEntity);
                                foreach (VD2DataStructure ds in ship.rotatingElement)
                                {
                                    if (ds is rotatingElementDataStructure)
                                    {
                                        rotatingElementDataStructure rotating = (rotatingElementDataStructure)ds;
                                        var skele = ShipEntity.getSkeleton();
                                        if (skele != null)
                                        {
                                            var bone = skele.getBone(rotating.boneName);
                                            bone.setManuallyControlled(true);
                                        }
                                    }
                                }

                            }
                            if (oldshipentity != null)
                            {
                                OgreScene.destroyEntity(oldshipentity);
                                
                            }
                        }
                    }
                }
            }
        }

        private void Attachment_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (DataFile != null)
            {

                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    if (OgreAttachments.Count > ship.attachment.Count)
                    {
                        for (int i = OgreAttachments.Count - 1; i >= ship.attachment.Count; i--)
                        {
                            OgreAttachments[i].DestroyAttachment();
                            OgreAttachments.RemoveAt(i);
                        }
                    }
                    else if (OgreAttachments.Count < ship.attachment.Count)
                    {
                        for (int i = OgreAttachments.Count; i < ship.attachment.Count; i++)
                        {
                            if (ship.attachment[i] is attachmentDataStructure)
                            {
                                attachmentDataStructure attachment = (attachmentDataStructure)ship.attachment[i];
                                OgreShipAttachment attachmentent = new OgreShipAttachment();
                                attachmentent.ParentOgreControl = this;
                                attachmentent.SelectedIndex = i;
                                attachmentent.ShipNode = ShipNode;
                                attachmentent.AttachmentDec = attachment;
                                List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                                foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                                {
                                    if (attachment.attachmentID.Count > 0)
                                    {
                                        if (attachmentdata.GetObjectID() == attachment.attachmentID[0])
                                        {
                                            attachmentdefhits.Add(attachmentdata);
                                        }
                                    }
                                }
                                OtherObjectData bestattachmentdef = null;
                                foreach (OtherObjectData attachmentdef in attachmentdefhits)
                                {
                                    if (bestattachmentdef == null)
                                    {
                                        bestattachmentdef = attachmentdef;
                                    }
                                    else if ((attachmentdef.Source != null) && (bestattachmentdef.Source != null))
                                    {
                                        if (attachmentdef.Source.ShortName == "Mod")
                                        {
                                            if (bestattachmentdef.Source.ShortName == "Base")
                                            {
                                                bestattachmentdef = attachmentdef;
                                            }
                                        }
                                    }
                                }
                                attachmentent.AttachmentDef = bestattachmentdef;
                                attachmentent.Spawn();
                                OgreAttachments.Add(attachmentent);
                            }
                        }
                    }
                    for (int i = 0; i < OgreAttachments.Count; i++)
                    {
                        if (i < ship.attachment.Count)
                        {
                            if (ship.attachment[i] is attachmentDataStructure)
                            {
                                OgreAttachments[i].AttachmentDec = (attachmentDataStructure)ship.attachment[i];
                            }
                            OgreAttachments[i].Update();
                        }
                    }
                }
            }
        }

        private void FrameListener_OnFrameEnded(object sender, OgreFrameListenerEventArgs e)
        {
            if (DataFile != null)
            {
                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    foreach (VD2DataStructure ds in ship.rotatingElement)
                    {
                        if (ds is rotatingElementDataStructure)
                        {
                            rotatingElementDataStructure rotating = (rotatingElementDataStructure)ds;
                            if (rotating.boneName != "")
                            {
                                if (ShipEntity != null)
                                {
                                    var skele = ShipEntity.getSkeleton();
                                    if (skele != null)
                                    {
                                        try
                                        {
                                            var bone = skele.getBone(rotating.boneName);
                                            bone.setManuallyControlled(true);
                                            bone.roll(new Radian(new Degree(rotating.rollSpeed * e.DeltaTime)));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Turret_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            
            if (DataFile != null)
            {

                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    if (OgreTurrets.Count > ship.turret.Count)
                    {
                        for (int i = OgreTurrets.Count - 1; i >= ship.turret.Count; i--)
                        {
                            OgreTurrets[i].DestroyTurret();
                            OgreTurrets.RemoveAt(i);
                        }
                    }
                    else if (OgreTurrets.Count < ship.turret.Count)
                    {
                        for (int i = OgreTurrets.Count; i < ship.turret.Count; i++)
                        {
                            if (ship.turret[i] is turretDataStructure)
                            {
                                turretDataStructure turret = (turretDataStructure)ship.turret[i];
                                OgreTurret turretent = new OgreTurret();
                                turretent.ParentOgreControl = this;
                                turretent.SelectedIndex = i;
                                turretent.ShipNode = ShipNode;
                                turretent.TurretDec = turret;
                                List<TurretData> turretdefhits = new List<TurretData>();
                                foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                                {
                                    if (turretdata.GetObjectID() == turret.turretID)
                                    {

                                        //turretent.TurretDef = turretdata;

                                        turretdefhits.Add(turretdata);
                                    }
                                }
                                TurretData bestdef = null;
                                foreach (TurretData turretdef in turretdefhits)
                                {
                                    if (bestdef == null)
                                    {
                                        bestdef = turretdef;
                                    }
                                    else if ((turretdef.Source != null) && (bestdef.Source != null))
                                    {
                                        if (turretdef.Source.ShortName == "Mod")
                                        {
                                            if (bestdef.Source.ShortName == "Base")
                                            {
                                                bestdef = turretdef;
                                            }
                                        }
                                    }
                                }
                                turretent.TurretDef = bestdef;
                                turretent.Spawn();
                                OgreTurrets.Add(turretent);
                            }
                        }
                    }
                    for (int i = 0; i < OgreTurrets.Count; i++)
                    {
                        if (i < ship.turret.Count)
                        {
                            if (ship.turret[i] is turretDataStructure)
                            {
                                OgreTurrets[i].TurretDec = (turretDataStructure)ship.turret[i];
                            }
                            OgreTurrets[i].Update();
                        }
                    }
                }
            }
        }

        private void DataOgreControl_Load(object sender, EventArgs e)
        {
            base.OgreControl_Load(sender, e);
        }
    }

    public class OgreShipAttachment
    {
        public void DestroyAttachment()
        {
            if (ParentOgreControl != null)
            {
                if (AttachmentEntity != null)
                {
                    ParentOgreControl.OgreScene.destroyEntity(AttachmentEntity);
                    AttachmentEntity = null;
                }
                if (AttachmentNode != null)
                {
                    ParentOgreControl.OgreScene.destroySceneNode(AttachmentNode);
                    AttachmentNode = null;
                }
            }
        }

        public OtherObjectData _AttachmentDef;
        public OtherObjectData AttachmentDef
        {
            get
            {
                return _AttachmentDef;
            }
            set
            {
                if (_AttachmentDef != null)
                {
                    _AttachmentDef.VD2PropertyChanged -= AttachmentDef_VD2PropertyChanged;
                    _AttachmentDef.OnThisFileOverriden -= AttachmentDef_OnThisFileOverriden;
                    _AttachmentDef.OnThisFileLoaded -= AttachmentDef_OnThisFileLoaded;
                    _AttachmentDef.OnThisFileDeleted -= AttachmentDef_OnThisFileDeleted;
                }
                _AttachmentDef = value;
                if (_AttachmentDef != null)
                {
                    _AttachmentDef.VD2PropertyChanged += AttachmentDef_VD2PropertyChanged;
                    _AttachmentDef.OnThisFileOverriden += AttachmentDef_OnThisFileOverriden;
                    _AttachmentDef.OnThisFileLoaded += AttachmentDef_OnThisFileLoaded;
                    _AttachmentDef.OnThisFileDeleted += AttachmentDef_OnThisFileDeleted;
                }
            }
        }

        private void AttachmentDef_OnThisFileDeleted(object sender, EventArgs e)
        {
            if (AttachmentDef.Source != null)
            {
                if (AttachmentDef.Source.ShortName != "Base")
                {
                    List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                    foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                    {
                        if (AttachmentDec.attachmentID.Count > 0)
                        {
                            if (attachmentdata.GetObjectID() == AttachmentDec.attachmentID[0])
                            {
                                attachmentdefhits.Add(attachmentdata);
                            }
                        }
                    }
                    OtherObjectData bestattachmentdef = null;
                    foreach (OtherObjectData attachmentdef in attachmentdefhits)
                    {
                        if (bestattachmentdef == null)
                        {
                            bestattachmentdef = attachmentdef;
                        }
                        else if ((attachmentdef.Source != null) && (bestattachmentdef.Source != null))
                        {
                            if (attachmentdef.Source.ShortName == "Mod")
                            {
                                if (bestattachmentdef.Source.ShortName == "Base")
                                {
                                    bestattachmentdef = attachmentdef;
                                }
                            }
                        }
                    }
                    AttachmentDef = bestattachmentdef;
                }
                else
                {
                    AttachmentDef = null;
                }
            }
            Update();
        }

        private void AttachmentDef_OnThisFileLoaded(object sender, EventArgs e)
        {
            Update();
        }

        private void AttachmentDef_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (e.NewFile is OtherObjectData)
            {
                OtherObjectData newdef = (OtherObjectData)e.NewFile;
                if (e.OldFile is OtherObjectData)
                {
                    OtherObjectData testolddef = (OtherObjectData)e.OldFile;
                    if (AttachmentDef != null)
                    {
                        if (testolddef == AttachmentDef)
                        {
                            AttachmentDef = newdef;
                            Update();
                        }
                    }
                }
            }
        }

        private void AttachmentDef_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "meshName")
            {
                if (AttachmentEntity == null)
                {
                    Spawn();//see if the data can make a mesh yet, which will set it all up on current data anyway.
                }
                else
                {
                    //DestroyTurret();
                    Spawn();
                }                
            }
        }

        public attachmentDataStructure _AttachmentDec;
        public attachmentDataStructure AttachmentDec
        {
            get
            {
                return _AttachmentDec;
            }
            set
            {
                if (_AttachmentDec != null)
                {
                    _AttachmentDec.VD2PropertyChanged -= AttachmentDec_VD2PropertyChanged;
                }
                _AttachmentDec = value;
                if (_AttachmentDec != null)
                {
                    _AttachmentDec.VD2PropertyChanged += AttachmentDec_VD2PropertyChanged;
                }
            }
        }
        public SceneNode AttachmentNode;
        public SceneNode ShipNode;
        public Entity AttachmentEntity;
        public DataOgreControl ParentOgreControl;
        public int SelectedIndex;

        public void Spawn()
        {
            if ((AttachmentDef != null) && (AttachmentDec != null))
            {
                
                if (AttachmentDef.meshName != null)
                {
                    string meshname = OgreControl.GetTrueFileName(AttachmentDef.meshName);
                    Entity oldturretentity = null;
                    if (AttachmentEntity != null)
                    {
                        oldturretentity = AttachmentEntity;
                    }
                    AttachmentEntity = null;
                    if (meshname != "")
                    {
                        AttachmentEntity = ParentOgreControl.OgreScene.createEntity(meshname);
                        if (AttachmentNode == null)
                        {
                            AttachmentNode = ShipNode.createChildSceneNode(new Vector3(AttachmentDec.attachmentPosition.x, AttachmentDec.attachmentPosition.y, AttachmentDec.attachmentPosition.z));
                        }
                        else
                        {
                            AttachmentNode.detachAllObjects();
                        }
                        AttachmentNode.attachObject(AttachmentEntity);
                        Degree yawasdegrees = new Degree(0.0f);
                        Degree rollasdegrees = new Degree(0.0f);
                        Degree pitchasdegrees = new Degree(0.0f);
                        switch (AttachmentDec.attachmentOrientation)
                        {
                            case "bottom":
                                pitchasdegrees = new Degree(180.0f);
                                yawasdegrees = new Degree(180.0f);
                                break;
                            case "left":
                                rollasdegrees = new Degree(90.0f);
                                break;
                            case "right":
                                rollasdegrees = new Degree(90.0f);
                                break;
                        }
                        AttachmentNode.roll(new Radian(rollasdegrees), Node.TransformSpace.TS_PARENT);
                        AttachmentNode.yaw(new Radian(yawasdegrees), Node.TransformSpace.TS_PARENT);
                        AttachmentNode.pitch(new Radian(pitchasdegrees), Node.TransformSpace.TS_PARENT);
                                                
                    }
                    if (oldturretentity != null)
                    {
                        ParentOgreControl.OgreScene.destroyEntity(oldturretentity);
                    }
                }
            }
        }

        private void AttachmentDec_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            if (AttachmentEntity == null)
            {
                if ((AttachmentDef == null) && (AttachmentDec != null))//if we have a turret declaration but no reference to the turret definition it uses, find it so we can spawn
                {
                    List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                    foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                    {
                        if (AttachmentDec.attachmentID.Count > 0)
                        {
                            if (attachmentdata.GetObjectID() == AttachmentDec.attachmentID[0])
                            {
                                attachmentdefhits.Add(attachmentdata);
                            }
                        }
                    }
                    OtherObjectData bestattachmentdef = null;
                    foreach (OtherObjectData attachmentdef in attachmentdefhits)
                    {
                        if (bestattachmentdef == null)
                        {
                            bestattachmentdef = attachmentdef;
                        }
                        else if ((attachmentdef.Source != null) && (bestattachmentdef.Source != null))
                        {
                            if (attachmentdef.Source.ShortName == "Mod")
                            {
                                if (bestattachmentdef.Source.ShortName == "Base")
                                {
                                    bestattachmentdef = attachmentdef;
                                }
                            }
                        }
                    }
                    AttachmentDef = bestattachmentdef;
                }
                Spawn();//see if the data can make a mesh yet, which will set it all up on current data anyway.
                return;
            }
            Vector3 currentpos = AttachmentNode.getPosition();
            if ((currentpos.x != AttachmentDec.attachmentPosition.x) || (currentpos.y != AttachmentDec.attachmentPosition.y) || (currentpos.z != AttachmentDec.attachmentPosition.z))
            {
                AttachmentNode.setPosition(new Vector3(AttachmentDec.attachmentPosition.x, AttachmentDec.attachmentPosition.y, AttachmentDec.attachmentPosition.z));
            }
            Degree yawasdegrees = new Degree(0.0f);
            Degree rollasdegrees = new Degree(0.0f);
            Degree pitchasdegrees = new Degree(0.0f);
            switch (AttachmentDec.attachmentOrientation)
            {
                case "bottom":
                    pitchasdegrees = new Degree(180.0f);
                    yawasdegrees = new Degree(180.0f);
                    break;
                case "left":
                    rollasdegrees = new Degree(90.0f);
                    break;
                case "right":
                    rollasdegrees = new Degree(90.0f);
                    break;
            }
            AttachmentNode.resetOrientation();
            AttachmentNode.roll(new Radian(rollasdegrees), Node.TransformSpace.TS_PARENT);
            AttachmentNode.yaw(new Radian(yawasdegrees), Node.TransformSpace.TS_PARENT);
            AttachmentNode.pitch(new Radian(pitchasdegrees), Node.TransformSpace.TS_PARENT);
        }

    }

    public class OgreTurret
    {
        public void DestroyTurret()
        {
            if (ParentOgreControl != null)
            {
                if (TurretEntity != null)
                {
                    ParentOgreControl.OgreScene.destroyEntity(TurretEntity);
                    TurretEntity = null;
                }
                if (TurretNode != null)
                {
                    ParentOgreControl.OgreScene.destroySceneNode(TurretNode);
                    TurretNode = null;
                }
            }
        }

        public TurretData _TurretDef;
        public TurretData TurretDef
        {
            get
            {
                return _TurretDef;
            }
            set
            {
                if (_TurretDef != null)
                {
                    _TurretDef.VD2PropertyChanged -= TurretDef_VD2PropertyChanged;
                    _TurretDef.OnThisFileOverriden -= TurretDef_OnThisFileOverriden;
                    _TurretDef.OnThisFileLoaded -= TurretDef_OnThisFileLoaded;
                    _TurretDef.OnThisFileDeleted -= TurretDef_OnThisFileDeleted;
                }
                _TurretDef = value;
                if (_TurretDef != null)
                {
                    _TurretDef.VD2PropertyChanged += TurretDef_VD2PropertyChanged;
                    _TurretDef.OnThisFileOverriden += TurretDef_OnThisFileOverriden;
                    _TurretDef.OnThisFileLoaded += TurretDef_OnThisFileLoaded;
                    _TurretDef.OnThisFileDeleted += TurretDef_OnThisFileDeleted;
                }
            }
        }

        private void TurretDef_OnThisFileDeleted(object sender, EventArgs e)
        {
            if (TurretDef.Source != null)
            {
                if (TurretDef.Source.ShortName != "Base")
                {
                    List<TurretData> turretdefhits = new List<TurretData>();
                    foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                    {
                        if (turretdata.GetObjectID() == TurretDec.turretID)
                        {
                            turretdefhits.Add(turretdata);
                        }
                    }
                    TurretData bestturretdef = null;
                    foreach (TurretData turretdef in turretdefhits)
                    {
                        if (bestturretdef == null)
                        {
                            bestturretdef = turretdef;
                        }
                        else if ((turretdef.Source != null) && (bestturretdef.Source != null))
                        {
                            if (turretdef.Source.ShortName == "Mod")
                            {
                                if (bestturretdef.Source.ShortName == "Base")
                                {
                                    bestturretdef = turretdef;
                                }
                            }
                        }
                    }
                    TurretDef = bestturretdef;
                }
                else
                {
                    TurretDef = null;
                }
            }
            Update();
        }

        private void TurretDef_OnThisFileLoaded(object sender, EventArgs e)
        {
            Update();
        }

        private void TurretDef_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (e.NewFile is TurretData)
            {
                TurretData newdef = (TurretData)e.NewFile;
                if (e.OldFile is TurretData)
                {
                    TurretData testolddef = (TurretData)e.OldFile;
                    if (TurretDef != null)
                    {
                        if (testolddef == TurretDef)
                        {
                            TurretDef = newdef;
                            Update();
                        }
                    }
                }
            }
        }

        private void TurretDef_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "meshName")
            {
                if (TurretEntity == null)
                {
                    Spawn();//see if the data can make a mesh yet, which will set it all up on current data anyway.
                }
                else
                {
                    //DestroyTurret();
                    Spawn();
                }
            }
        }

        public turretDataStructure _TurretDec;
        public turretDataStructure TurretDec
        {
            get
            {
                return _TurretDec;
            }
            set
            {
                if (_TurretDec != null)
                {
                    _TurretDec.VD2PropertyChanged -= TurretDec_VD2PropertyChanged;
                }
                _TurretDec = value;
                if (_TurretDec != null)
                {
                    _TurretDec.VD2PropertyChanged += TurretDec_VD2PropertyChanged;
                }
            }
        }
        public SceneNode TurretNode;
        public SceneNode ShipNode;
        public Entity TurretEntity;
        public DataOgreControl ParentOgreControl;
        public int SelectedIndex;

        public void Spawn()
        {
            if ((TurretDef != null) && (TurretDec != null))
            {

                if (TurretDef.meshName != null)
                {
                    string meshname = OgreControl.GetTrueFileName(TurretDef.meshName);
                    Entity oldturretentity = null;
                    if (TurretEntity != null)
                    {
                        oldturretentity = TurretEntity;
                    }
                    TurretEntity = null;
                    if (meshname != "")
                    {
                        TurretEntity = ParentOgreControl.OgreScene.createEntity(meshname);
                        if (TurretNode == null)
                        {
                            TurretNode = ShipNode.createChildSceneNode(new Vector3(TurretDec.position.x, TurretDec.position.y, TurretDec.position.z));
                        }
                        else
                        {
                            TurretNode.detachAllObjects();
                        }
                        TurretNode.attachObject(TurretEntity);
                        Degree yawasdegrees = new Degree(TurretDec.yaw);
                        Degree rollasdegrees = new Degree(TurretDec.roll);
                        Degree pitchasdegrees = new Degree(0.0f);
                        switch (TurretDec.turretOrientation)
                        {
                            case "bottom":
                                pitchasdegrees = new Degree(180.0f);
                                yawasdegrees = new Degree(TurretDec.yaw + 180.0f);
                                break;
                            case "left":
                                rollasdegrees = new Degree(TurretDec.roll + 90.0f);
                                break;
                            case "right":
                                rollasdegrees = new Degree(TurretDec.roll - 90.0f);
                                break;
                        }
                        TurretNode.roll(new Radian(rollasdegrees), Node.TransformSpace.TS_PARENT);
                        TurretNode.yaw(new Radian(yawasdegrees), Node.TransformSpace.TS_PARENT);
                        TurretNode.pitch(new Radian(pitchasdegrees), Node.TransformSpace.TS_PARENT);
                    }
                    if (oldturretentity != null)
                    {
                        ParentOgreControl.OgreScene.destroyEntity(oldturretentity);

                    }
                }
            }
        }

        private void TurretDec_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            if (TurretEntity == null)
            {
                if ((TurretDef == null) && (TurretDec != null))//if we have a turret declaration but no reference to the turret definition it uses, find it so we can spawn
                {
                    List<TurretData> turretdefhits = new List<TurretData>();
                    foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                    {
                        if (turretdata.GetObjectID() == TurretDec.turretID)
                        {
                            turretdefhits.Add(turretdata);
                        }
                    }
                    TurretData bestturretdef = null;
                    foreach (TurretData turretdef in turretdefhits)
                    {
                        if (bestturretdef == null)
                        {
                            bestturretdef = turretdef;
                        }
                        else if ((turretdef.Source != null) && (bestturretdef.Source != null))
                        {
                            if (turretdef.Source.ShortName == "Mod")
                            {
                                if (bestturretdef.Source.ShortName == "Base")
                                {
                                    bestturretdef = turretdef;
                                }
                            }
                        }
                    }
                    TurretDef = bestturretdef;
                }
                Spawn();//see if the data can make a mesh yet, which will set it all up on current data anyway.
                return;
            }
            else
            {
                if ((TurretDef == null) && (TurretDec != null))
                {
                    foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                    {
                        if (turretdata.GetObjectID() == TurretDec.turretID)
                        {
                            TurretDef = turretdata;
                            break;
                        }
                    }

                }
                if (TurretDef != null)
                {
                    if (TurretDef.meshName != null)
                    {
                        if (TurretDef.meshName != TurretEntity.getMesh().getName())//changed mesh name?
                        {
                            Spawn();
                        }
                    }
                }
            }
            if (TurretDec == null)
            {
                return;
            }
            Vector3 currentpos = TurretNode.getPosition();
            if ((currentpos.x != TurretDec.position.x) || (currentpos.y != TurretDec.position.y) || (currentpos.z != TurretDec.position.z))
            {
                TurretNode.setPosition(new Vector3(TurretDec.position.x, TurretDec.position.y, TurretDec.position.z));
            }
            Degree yawasdegrees = new Degree(TurretDec.yaw);
            Degree rollasdegrees = new Degree(TurretDec.roll);
            Degree pitchasdegrees = new Degree(0.0f);
            switch (TurretDec.turretOrientation)
            {
                case "bottom":
                    pitchasdegrees = new Degree(180.0f);
                    yawasdegrees = new Degree(TurretDec.yaw + 180.0f);
                    break;
                case "left":
                    rollasdegrees = new Degree(TurretDec.roll + 90.0f);
                    break;
                case "right":
                    rollasdegrees = new Degree(TurretDec.roll - 90.0f);
                    break;
            }
            TurretNode.resetOrientation();
            TurretNode.roll(new Radian(rollasdegrees), Node.TransformSpace.TS_PARENT);
            TurretNode.yaw(new Radian(yawasdegrees), Node.TransformSpace.TS_PARENT);
            TurretNode.pitch(new Radian(pitchasdegrees), Node.TransformSpace.TS_PARENT);
        }

    }
}
