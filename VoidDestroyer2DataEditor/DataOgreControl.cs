using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

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
        public List<RotateBoneAnimationComponent> RotateBones;

        public EditorActor ShipActor;

        public DataOgreControl() : base()
        {
            OgreTurrets = new List<OgreTurret>();
            OgreAttachments = new List<OgreShipAttachment>();
            RotateBones = new List<RotateBoneAnimationComponent>();
            InitializeComponent();
        }

        protected override void OgreControlDisposed()
        {
            if (!DesignMode)
            {
                if (!SplashLoadingWindow)
                {
                    foreach (OgreTurret turret in OgreTurrets)
                    {
                        turret.DestroyTurret();
                    }
                    foreach (OgreShipAttachment attachment in OgreAttachments)
                    {
                        attachment.DestroyAttachment();
                    }
                    if (ShipActor != null)
                    {
                        ShipActor.Destroy();
                    }
                    if (VP != null)
                    {
                        VP.Destroy();
                        VP.Dispose();
                        VP = null;
                    }
                    if (World != null)
                    {
                        World.Destroy();
                        World.Dispose();
                        World = null;
                    }                    
                }
            }
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
                    ShipActor = World.CreateActor("ShipActor");
                    if (ship.meshName != null)
                    {
                        string meshname = GetTrueFileName(ship.meshName);
                        if (meshname != "")
                        {
                            ShipActor.SetMesh(meshname);
                            distance = ShipActor.GetBoundingRadius() * 1.25f;
                            zoomdistance = distance * 0.1f;
                            VP.SetCameraYawPitchDistance(yaw, pitch, distance);
                            for (int i = 0; i < ship.rotatingElement.Count; i++)
                            {
                                if (ship.rotatingElement[i] is rotatingElementDataStructure)
                                {
                                    rotatingElementDataStructure rotating = (rotatingElementDataStructure)ship.rotatingElement[i];
                                    RotateBoneAnimationComponent rotator = ShipActor.CreateRotateBoneAnimationComponent("RotateAnim" + i.ToString());
                                    if (rotator != null)
                                    {
                                        rotator.StartAnimation(rotating.boneName, rotating.rollSpeed, RotateBoneAnimationAxis.Roll);
                                        RotateBones.Add(rotator);
                                    }
                                }
                            }
                            ship.rotatingElement.CollectionChanged += RotatingElement_CollectionChanged;
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
                            turretent.ParentShipActor = ShipActor;
                            turretent.TurretDec = turret;
                            List<TurretData> turretdefhits = new List<TurretData>();
                            foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                            {
                                if (turretdata.GetObjectID() == turret.turretID)
                                {
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
                            turretent.World = World;
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
                            attachmentent.ParentShipActor = ShipActor;
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
                }
            }
        }

        private void RotatingElement_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateRotatingElements();
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

        private void UpdateRotatingElement(int inIndex, RotateBoneAnimationComponent inComponent)
        {
            if (DataFile != null)
            {
                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    if (ship.rotatingElement[inIndex] is rotatingElementDataStructure)
                    {
                        rotatingElementDataStructure rotating = (rotatingElementDataStructure)ship.rotatingElement[inIndex];
                        if (inComponent != null)
                        {
                            inComponent.StartAnimation(rotating.boneName, rotating.rollSpeed, RotateBoneAnimationAxis.Roll);
                        }
                    }
                }
            }
        }

        private void UpdateRotatingElements()
        {
            if (DataFile != null)
            {
                if (DataFile is ShipData)
                {
                    ShipData ship = (ShipData)DataFile;
                    if (RotateBones.Count > ship.rotatingElement.Count)
                    {
                        for (int i = RotateBones.Count - 1; i >= ship.rotatingElement.Count; i--)
                        {
                            RotateBones[i].Destroy();
                            RotateBones.RemoveAt(i);
                        }
                    }
                    else if (RotateBones.Count < ship.rotatingElement.Count)
                    {
                        for (int i = RotateBones.Count; i < ship.rotatingElement.Count; i++)
                        {
                            if (ship.rotatingElement[i] is rotatingElementDataStructure)
                            {
                                rotatingElementDataStructure rotating = (rotatingElementDataStructure)ship.rotatingElement[i];
                                RotateBoneAnimationComponent rotator = ShipActor.CreateRotateBoneAnimationComponent("RotateAnim" + i.ToString());
                                if (rotator != null)
                                {
                                    rotator.StartAnimation(rotating.boneName, rotating.rollSpeed, RotateBoneAnimationAxis.Roll);
                                    RotateBones.Add(rotator);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < RotateBones.Count; i++)
                    {
                        UpdateRotatingElement(i, RotateBones[i]);
                    }
                }
            }
        }

        private void UpdateTurrets()
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
                                turretent.ParentShipActor = ShipActor;
                                turretent.TurretDec = turret;
                                List<TurretData> turretdefhits = new List<TurretData>();
                                foreach (TurretData turretdata in EditorUI.UI.Turrets.Data.Values)
                                {
                                    if (turretdata.GetObjectID() == turret.turretID)
                                    {
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

        private void UpdateAttachments()
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
                                attachmentent.ParentShipActor = ShipActor;
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

        private void UpdateShip()
        {
            if (DataFile is ShipData)
            {
                ShipData ship = (ShipData)DataFile;
                string meshname = (string)ship.meshName;
                meshname = GetTrueFileName(meshname);
                if (meshname != "")
                {
                    if (ShipActor.GetMeshName() != meshname)
                    {
                        ShipActor.SetMesh(meshname);
                        distance = ShipActor.GetBoundingRadius() * 1.25f;
                        zoomdistance = distance * 0.1f;
                        VP.SetCameraYawPitchDistance(yaw, pitch, distance);
                    }
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
                            UpdateShip();
                        }
                    }
                }
                if (e.PropertyName == "rotatingElement")
                {
                    ship.rotatingElement.CollectionChanged += RotatingElement_CollectionChanged;
                    UpdateRotatingElements();
                }
                if (e.PropertyName == "turret")
                {
                    ship.turret.CollectionChanged += Turret_CollectionChanged;
                    UpdateTurrets();
                }
                if (e.PropertyName == "attachment")
                {
                    ship.attachment.CollectionChanged += Attachment_CollectionChanged;
                    UpdateAttachments();
                }
            }
        }

        private void Attachment_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateAttachments();
        }       

        private void Turret_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateTurrets();
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
            AttachmentActor.Destroy();
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
                Update();
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
   
        public DataOgreControl ParentOgreControl;
        public EditorActor ParentShipActor;
        public EditorActor AttachmentActor;
        public int SelectedIndex;

        public void Spawn()
        {
            if ((AttachmentDef != null) && (AttachmentDec != null))
            {
                AttachmentActor = ParentShipActor.CreateChildActor("Attachment" + SelectedIndex.ToString());
                if (AttachmentDef.meshName != null)
                {
                    string meshname = OgreControl.GetTrueFileName(AttachmentDef.meshName);

                    if (meshname != "")
                    {
                        AttachmentActor.SetMesh(meshname);

                        float yawasdegrees = 0.0f;
                        float rollasdegrees = 0.0f;
                        float pitchasdegrees = 0.0f;
                        switch (AttachmentDec.attachmentOrientation)
                        {
                            case "bottom":
                                pitchasdegrees = 180.0f;
                                yawasdegrees = 180.0f;
                                break;
                            case "left":
                                rollasdegrees = 90.0f;
                                break;
                            case "right":
                                rollasdegrees = -90.0f;
                                break;
                        }

                        AttachmentActor.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);

                        AttachmentActor.SetRelativePosition(AttachmentDec.attachmentPosition.x, AttachmentDec.attachmentPosition.y, AttachmentDec.attachmentPosition.z);
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
            if (AttachmentDec != null)
            {
                if (AttachmentDef == null)//if we have a declaration but no reference to the definition it uses, find it so we can spawn
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
                if (AttachmentActor == null)
                {
                    Spawn();
                    return;
                }
                if ((AttachmentActor.GetRelativePositionX() != AttachmentDec.attachmentPosition.x) || (AttachmentActor.GetRelativePositionY() != AttachmentDec.attachmentPosition.y) || (AttachmentActor.GetRelativePositionZ() != AttachmentDec.attachmentPosition.z))
                {
                    AttachmentActor.SetRelativePosition(AttachmentDec.attachmentPosition.x, AttachmentDec.attachmentPosition.y, AttachmentDec.attachmentPosition.z);
                }
                float yawasdegrees = 0.0f;
                float rollasdegrees = 0.0f;
                float pitchasdegrees = 0.0f;
                switch (AttachmentDec.attachmentOrientation)
                {
                    case "bottom":
                        pitchasdegrees = 180.0f;
                        yawasdegrees = 180.0f;
                        break;
                    case "left":
                        rollasdegrees = 90.0f;
                        break;
                    case "right":
                        rollasdegrees = -90.0f;
                        break;
                }
                AttachmentActor.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
            }
            if (AttachmentDef != null)
            {
                string meshname = AttachmentDef.meshName;
                meshname = OgreControl.GetTrueFileName(meshname);
                if (meshname != "")
                {
                    if (AttachmentActor.GetMeshName() != meshname)
                    {
                        AttachmentActor.SetMesh(meshname);
                    }
                }
            }
            /* if (AttachmentEntity == null)
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
             AttachmentNode.pitch(new Radian(pitchasdegrees), Node.TransformSpace.TS_PARENT);*/
        }
        
    }

    public class OgreTurret
    {
        public void DestroyTurret()
        {
            TurretActor.Destroy();
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
                Update();
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

        public DataOgreControl ParentOgreControl;
        public EditorActor TurretActor;
        public EditorActor ParentShipActor;
        public EditorWorld World;
        public int SelectedIndex;

        public void Spawn()
        {
            TurretActor = ParentShipActor.CreateChildActor("Turret" + SelectedIndex.ToString());
            if ((TurretDef != null) && (TurretDec != null))
            {                
                if (TurretDef.meshName != null)
                {
                    string meshname = OgreControl.GetTrueFileName(TurretDef.meshName);                    
                    if (meshname != "")
                    {
                        TurretActor.SetMesh(meshname);
                    }                    
                }
                float yawasdegrees = TurretDec.yaw;
                float rollasdegrees = TurretDec.roll;
                float pitchasdegrees = 0.0f;
                switch (TurretDec.turretOrientation)
                {
                    case "bottom":
                        pitchasdegrees = 180.0f;
                        yawasdegrees = TurretDec.yaw + 180.0f;
                        break;
                    case "left":
                        rollasdegrees = TurretDec.roll + 90.0f;
                        break;
                    case "right":
                        rollasdegrees = TurretDec.roll - 90.0f;
                        break;
                }
                TurretActor.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
                TurretActor.SetRelativePosition(TurretDec.position.x, TurretDec.position.y, TurretDec.position.z);
            }
        }

        private void TurretDec_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {            
            if (TurretDec != null)
            {
                if (TurretDef == null)//if we have a declaration but no reference to the definition it uses, find it so we can spawn
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
                if (TurretActor == null)
                {
                    Spawn();
                    return;
                }
                if ((TurretActor.GetRelativePositionX() != TurretDec.position.x) || (TurretActor.GetRelativePositionY() != TurretDec.position.y) || (TurretActor.GetRelativePositionZ() != TurretDec.position.z))
                {
                    TurretActor.SetRelativePosition(TurretDec.position.x, TurretDec.position.y, TurretDec.position.z);
                }
                float yawasdegrees = TurretDec.yaw;
                float rollasdegrees = TurretDec.roll;
                float pitchasdegrees = 0.0f;
                switch (TurretDec.turretOrientation)
                {
                    case "bottom":
                        pitchasdegrees = 180.0f;
                        yawasdegrees = TurretDec.yaw + 180.0f;
                        break;
                    case "left":
                        rollasdegrees = TurretDec.roll + 90.0f;
                        break;
                    case "right":
                        rollasdegrees = TurretDec.roll - 90.0f;
                        break;
                }
                TurretActor.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
            }
            if (TurretDef != null)
            {
                string meshname = TurretDef.meshName;
                meshname = OgreControl.GetTrueFileName(meshname);
                if (meshname != "")
                {
                    if (TurretActor.GetMeshName() != meshname)
                    {
                        TurretActor.SetMesh(meshname);
                    }
                }
            }
        }
    }
}
