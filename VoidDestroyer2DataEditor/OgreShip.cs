using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace VoidDestroyer2DataEditor
{
    class OgreShip
    {
        public event EventHandler OnShipMainMeshChanged;

        public List<OgreShipTurret> OgreTurrets;
        public List<OgreShipAttachment> OgreAttachments;
        public List<RotateBoneAnimationComponent> RotateBones;
        public List<OgreShipDamageStateEffect> DamageStateEffects;
        public List<OgreShipPropulsionEffect> PropulsionEffects;
        public Dictionary<string, bool> PropulsionDirectionToggle;

        public EditorActor ShipActor;
        public EditorWorld World;

        public float CurrentHealthPercent;

        public string ShipObjectID;
        public bool InvariantSource;//if true we were given a data file and are expected to not change source ever
        public bool IsShipDataPreviewShip;

        public ShipData _ShipDef;
        public ShipData ShipDef
        {
            get
            {
                return _ShipDef;
            }
            set
            {
                if (_ShipDef != null)
                {
                    _ShipDef.VD2PropertyChanged -= ShipDef_VD2PropertyChanged;
                    _ShipDef.OnThisFileOverriden -= ShipDef_OnThisFileOverriden;
                    _ShipDef.OnThisFileLoaded -= ShipDef_OnThisFileLoaded;
                    _ShipDef.OnThisFileDeleted -= ShipDef_OnThisFileDeleted;
                }
                _ShipDef = value;
                if (_ShipDef != null)
                {
                    _ShipDef.VD2PropertyChanged += ShipDef_VD2PropertyChanged;
                    _ShipDef.OnThisFileOverriden += ShipDef_OnThisFileOverriden;
                    _ShipDef.OnThisFileLoaded += ShipDef_OnThisFileLoaded;
                    _ShipDef.OnThisFileDeleted += ShipDef_OnThisFileDeleted;
                }
            }
        }

        private void ShipDef_OnThisFileDeleted(object sender, EventArgs e)
        {
            if (InvariantSource)//we're going to get destroyed, don't bother.
            {
                return;
            }
            if (ShipDef.Source != null)
            {
                if (ShipDef.Source.ShortName != "Base")
                {
                    List<ShipData> defhits = new List<ShipData>();
                    foreach (ShipData data in EditorUI.UI.Ships.Data.Values)
                    {
                        if (data.GetObjectID() == ShipObjectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ShipData bestdef = null;
                    foreach (ShipData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    ShipDef = bestdef;
                }
                else
                {
                    ShipDef = null;
                }
            }
            UpdateShip();
        }

        private void ShipDef_OnThisFileLoaded(object sender, EventArgs e)
        {
            if (IsShipDataPreviewShip)
            {
                return;//the ogre control we are in is being disposed of, the user clicked dont save, forget about it.
            }
            UpdateShip();
        }

        private void ShipDef_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (InvariantSource)//this is the base file documents ship, don't touch it.
            {
                return;
            }
            if (e.NewFile is ShipData)
            {
                ShipData newdef = (ShipData)e.NewFile;
                if (e.OldFile is ShipData)
                {
                    ShipData testolddef = (ShipData)e.OldFile;
                    if (ShipDef != null)
                    {
                        if (testolddef == ShipDef)
                        {
                            ShipDef = newdef;
                            UpdateShip();
                        }
                    }
                }
            }
        }

        private void ShipDef_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
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
                ShipDef.rotatingElement.CollectionChanged += RotatingElement_CollectionChanged;
                UpdateRotatingElements();
            }
            if (e.PropertyName == "turret")
            {
                ShipDef.turret.CollectionChanged += Turret_CollectionChanged;
                UpdateTurrets();
            }
            if (e.PropertyName == "attachment")
            {
                ShipDef.attachment.CollectionChanged += Attachment_CollectionChanged;
                UpdateAttachments();
            }
            if (e.PropertyName == "damage")
            {
                ShipDef.damage.CollectionChanged += Damage_CollectionChanged;
                UpdateDamageStates();
            }
            if (e.PropertyName == "propulsion")
            {
                ShipDef.propulsion.CollectionChanged += Propulsion_CollectionChanged;
                UpdatePropulsion();
            }
        }

        public OgreShip(string inObjectID, EditorWorld inWorld, string inTargetSourceShortName = "")
        {
            IsShipDataPreviewShip = false;
            CurrentHealthPercent = -1;
            OgreTurrets = new List<OgreShipTurret>();
            OgreAttachments = new List<OgreShipAttachment>();
            RotateBones = new List<RotateBoneAnimationComponent>();
            DamageStateEffects = new List<OgreShipDamageStateEffect>();
            PropulsionEffects = new List<OgreShipPropulsionEffect>();
            PropulsionDirectionToggle = new Dictionary<string, bool>();
            PropulsionDirectionToggle.Add("", false);
            PropulsionDirectionToggle.Add("back", false);
            PropulsionDirectionToggle.Add("fore", false);
            PropulsionDirectionToggle.Add("right", false);
            PropulsionDirectionToggle.Add("left", false);
            PropulsionDirectionToggle.Add("up", false);
            PropulsionDirectionToggle.Add("down", false);

            ShipObjectID = inObjectID;
            World = inWorld;
            string targetsource = inTargetSourceShortName;
            if (targetsource == "")
            {                
                targetsource = "Mod";
            }

            InvariantSource = false;
            List<ShipData> defhits = new List<ShipData>();
            foreach (ShipData data in EditorUI.UI.Ships.Data.Values)
            {
                if (data.GetObjectID() == ShipObjectID)
                {
                    defhits.Add(data);
                }
            }
            ShipData bestdef = null;
            foreach (ShipData def in defhits)
            {
                if (bestdef == null)
                {
                    bestdef = def;
                }
                else if ((def.Source != null) && (bestdef.Source != null))
                {
                    if (def.Source.ShortName == targetsource)
                    {
                        if (bestdef.Source.ShortName != targetsource)
                        {
                            bestdef = def;
                        }
                    }
                }
            }
            ShipDef = bestdef;
            Spawn();
        }

        public OgreShip(ShipData inData, EditorWorld inWorld)
        {
            IsShipDataPreviewShip = false;
            if (inData != null)
            {
                CurrentHealthPercent = -1;
                OgreTurrets = new List<OgreShipTurret>();
                OgreAttachments = new List<OgreShipAttachment>();
                RotateBones = new List<RotateBoneAnimationComponent>();
                DamageStateEffects = new List<OgreShipDamageStateEffect>();
                PropulsionEffects = new List<OgreShipPropulsionEffect>();
                PropulsionDirectionToggle = new Dictionary<string, bool>();
                PropulsionDirectionToggle.Add("", false);
                PropulsionDirectionToggle.Add("back", false);
                PropulsionDirectionToggle.Add("fore", false);
                PropulsionDirectionToggle.Add("right", false);
                PropulsionDirectionToggle.Add("left", false);
                PropulsionDirectionToggle.Add("up", false);
                PropulsionDirectionToggle.Add("down", false);

                ShipObjectID = inData.objectID;
                World = inWorld;
                ShipDef = inData;
                InvariantSource = true;
                Spawn();
            }
        }

        public float GetBoundingRadius()
        {
            if (ShipActor != null)
            {
                return ShipActor.GetBoundingRadius();
            }
            return 0;
        }

        public void DestroyShip()
        {
            foreach (OgreShipTurret turret in OgreTurrets)
            {
                turret.DestroyTurret();
            }
            foreach (OgreShipAttachment attachment in OgreAttachments)
            {
                attachment.DestroyAttachment();
            }
            foreach (OgreShipDamageStateEffect damage in DamageStateEffects)
            {
                damage.DestroyDamageStateEffect();
            }
            foreach (OgreShipPropulsionEffect propulsion in PropulsionEffects)
            {
                propulsion.DestroyPropulsionEffect();
            }
            ShipActor.Destroy();
        }

        public void Spawn()
        {
            Random rnd = new Random();
            
            ShipActor = World.CreateActor("ShipActor" + ShipDef.Source.ShortName + ShipDef.objectID + rnd.Next().ToString());
            if (ShipDef.meshName != null)
            {
                string meshname = OgreControl.GetTrueFileName(ShipDef.meshName);
                if (meshname != "")
                {
                    ShipActor.SetMesh(meshname);
                    for (int i = 0; i < ShipDef.rotatingElement.Count; i++)
                    {
                        if (ShipDef.rotatingElement[i] is rotatingElementDataStructure)
                        {
                            rotatingElementDataStructure rotating = (rotatingElementDataStructure)ShipDef.rotatingElement[i];
                            RotateBoneAnimationComponent rotator = ShipActor.CreateRotateBoneAnimationComponent("RotateAnim" + i.ToString());
                            if (rotator != null)
                            {
                                rotator.StartAnimation(rotating.boneName, rotating.rollSpeed, RotateBoneAnimationAxis.Roll);
                                RotateBones.Add(rotator);
                            }
                        }
                    }
                    ShipDef.rotatingElement.CollectionChanged += RotatingElement_CollectionChanged;
                }
            }
            for (int i = 0; i < ShipDef.turret.Count; i++)
            {
                if (ShipDef.turret[i] is turretDataStructure)
                {
                    turretDataStructure turret = (turretDataStructure)ShipDef.turret[i];
                    OgreShipTurret turretent = new OgreShipTurret();
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
            ShipDef.turret.CollectionChanged += Turret_CollectionChanged;
            for (int i = 0; i < ShipDef.attachment.Count; i++)
            {
                if (ShipDef.attachment[i] is attachmentDataStructure)
                {
                    attachmentDataStructure attachment = (attachmentDataStructure)ShipDef.attachment[i];
                    OgreShipAttachment attachmentent = new OgreShipAttachment();
                    attachmentent.SelectedIndex = i;
                    attachmentent.ParentShipActor = ShipActor;
                    attachmentent.AttachmentDec = attachment;
                    List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                    foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                    {
                        if (attachmentdata.GetObjectID() == attachment.attachmentID)
                        {
                            attachmentdefhits.Add(attachmentdata);
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
            ShipDef.attachment.CollectionChanged += Attachment_CollectionChanged;
            for (int i = 0; i < ShipDef.damage.Count; i++)
            {
                if (ShipDef.damage[i] is damageDataStructure)
                {
                    damageDataStructure damage = (damageDataStructure)ShipDef.damage[i];

                    OgreShipDamageStateEffect damageeffect = new OgreShipDamageStateEffect(damage, ShipActor, i);
                    DamageStateEffects.Add(damageeffect);
                }
            }
            ShipDef.damage.CollectionChanged += Damage_CollectionChanged;

            for (int i = 0; i < ShipDef.propulsion.Count; i++)
            {
                if (ShipDef.propulsion[i] is propulsionDataStructure)
                {
                    propulsionDataStructure propulsion = (propulsionDataStructure)ShipDef.propulsion[i];
                    List<ParticleData> defhits = new List<ParticleData>();
                    foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                    {
                        if (data.GetObjectID() == propulsion.propulsionEffectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ParticleData bestdef = null;
                    foreach (ParticleData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    if (bestdef != null)
                    {
                        OgreShipPropulsionEffect propulsioneffect = new OgreShipPropulsionEffect();
                        propulsioneffect.PropulsionDec = propulsion;
                        propulsioneffect.ParticleDef = bestdef;
                        propulsioneffect.ParentShipActor = ShipActor;
                        propulsioneffect.World = World;
                        propulsioneffect.SelectedIndex = i;
                        PropulsionEffects.Add(propulsioneffect);
                        propulsioneffect.Spawn();
                    }
                }
            }
            ShipDef.propulsion.CollectionChanged += Propulsion_CollectionChanged;
        }

        private void Damage_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDamageStates();
        }

        private void Propulsion_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdatePropulsion();
        }

        public void UpdateDamageStates()
        {
            if (DamageStateEffects.Count > ShipDef.damage.Count)
            {
                for (int i = DamageStateEffects.Count - 1; i >= ShipDef.damage.Count; i--)
                {
                    DamageStateEffects[i].DestroyDamageStateEffect();
                    DamageStateEffects.RemoveAt(i);
                }
            }
            else if (DamageStateEffects.Count < ShipDef.damage.Count)
            {
                for (int i = DamageStateEffects.Count; i < ShipDef.damage.Count; i++)
                {
                    if (ShipDef.damage[i] is damageDataStructure)
                    {
                        damageDataStructure damage = (damageDataStructure)ShipDef.damage[i];
                        
                        OgreShipDamageStateEffect damageeffect = new OgreShipDamageStateEffect(damage, ShipActor, i);                        
                        DamageStateEffects.Add(damageeffect);
                    }
                }
            }
            for (int i = 0; i < DamageStateEffects.Count; i++)
            {
                // UpdateDamageState(i, DamageStateEffects[i]);
                DamageStateEffects[i].Update();
            }
        }

        public void UpdatePropulsion()
        {
            if (PropulsionEffects.Count > ShipDef.propulsion.Count)
            {
                for (int i = PropulsionEffects.Count - 1; i >= ShipDef.propulsion.Count; i--)
                {
                    PropulsionEffects[i].DestroyPropulsionEffect();
                    PropulsionEffects.RemoveAt(i);
                }
            }
            else if (PropulsionEffects.Count < ShipDef.propulsion.Count)
            {
                for (int i = PropulsionEffects.Count; i < ShipDef.propulsion.Count; i++)
                {
                    if (ShipDef.propulsion[i] is propulsionDataStructure)
                    {
                        propulsionDataStructure propulsion = (propulsionDataStructure)ShipDef.propulsion[i];
                        List<ParticleData> defhits = new List<ParticleData>();
                        foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                        {
                            if (data.GetObjectID() == propulsion.propulsionEffectID)
                            {
                                defhits.Add(data);
                            }
                        }
                        ParticleData bestdef = null;
                        foreach (ParticleData def in defhits)
                        {
                            if (bestdef == null)
                            {
                                bestdef = def;
                            }
                            else if ((def.Source != null) && (bestdef.Source != null))
                            {
                                if (def.Source.ShortName == "Mod")
                                {
                                    if (bestdef.Source.ShortName == "Base")
                                    {
                                        bestdef = def;
                                    }
                                }
                            }
                        }
                        if (bestdef != null)
                        {
                            OgreShipPropulsionEffect propulsioneffect = new OgreShipPropulsionEffect();
                            propulsioneffect.PropulsionDec = propulsion;
                            propulsioneffect.ParticleDef = bestdef;
                            propulsioneffect.ParentShipActor = ShipActor;
                            propulsioneffect.World = World;
                            propulsioneffect.SelectedIndex = i;
                            PropulsionEffects.Add(propulsioneffect);
                            propulsioneffect.Spawn();
                        }
                    }
                }
            }
            for (int i = 0; i < PropulsionEffects.Count; i++)
            {
                // UpdateDamageState(i, DamageStateEffects[i]);
                PropulsionEffects[i].Update();
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
                    if (testolddef == ShipDef)
                    {
                        ShipDef = newdef;
                        UpdateShip();
                    }
                }
            }
        }

        private void UpdateRotatingElement(int inIndex, RotateBoneAnimationComponent inComponent)
        {
            if (ShipDef.rotatingElement[inIndex] is rotatingElementDataStructure)
            {
                rotatingElementDataStructure rotating = (rotatingElementDataStructure)ShipDef.rotatingElement[inIndex];
                if (inComponent != null)
                {
                    inComponent.StartAnimation(rotating.boneName, rotating.rollSpeed, RotateBoneAnimationAxis.Roll);
                }
            }
        }

        private void UpdateRotatingElements()
        {
            if (RotateBones.Count > ShipDef.rotatingElement.Count)
            {
                for (int i = RotateBones.Count - 1; i >= ShipDef.rotatingElement.Count; i--)
                {
                    RotateBones[i].Destroy();
                    RotateBones.RemoveAt(i);
                }
            }
            else if (RotateBones.Count < ShipDef.rotatingElement.Count)
            {
                for (int i = RotateBones.Count; i < ShipDef.rotatingElement.Count; i++)
                {
                    if (ShipDef.rotatingElement[i] is rotatingElementDataStructure)
                    {
                        rotatingElementDataStructure rotating = (rotatingElementDataStructure)ShipDef.rotatingElement[i];
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

        private void UpdateTurrets()
        {
            if (OgreTurrets.Count > ShipDef.turret.Count)
            {
                for (int i = OgreTurrets.Count - 1; i >= ShipDef.turret.Count; i--)
                {
                    OgreTurrets[i].DestroyTurret();
                    OgreTurrets.RemoveAt(i);
                }
            }
            else if (OgreTurrets.Count < ShipDef.turret.Count)
            {
                for (int i = OgreTurrets.Count; i < ShipDef.turret.Count; i++)
                {
                    if (ShipDef.turret[i] is turretDataStructure)
                    {
                        turretDataStructure turret = (turretDataStructure)ShipDef.turret[i];
                        OgreShipTurret turretent = new OgreShipTurret();
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
                if (i < ShipDef.turret.Count)
                {
                    if (ShipDef.turret[i] is turretDataStructure)
                    {
                        OgreTurrets[i].TurretDec = (turretDataStructure)ShipDef.turret[i];
                    }
                    OgreTurrets[i].Update();
                }
            }
        }

        private void UpdateAttachments()
        {
            if (OgreAttachments.Count > ShipDef.attachment.Count)
            {
                for (int i = OgreAttachments.Count - 1; i >= ShipDef.attachment.Count; i--)
                {
                    OgreAttachments[i].DestroyAttachment();
                    OgreAttachments.RemoveAt(i);
                }
            }
            else if (OgreAttachments.Count < ShipDef.attachment.Count)
            {
                for (int i = OgreAttachments.Count; i < ShipDef.attachment.Count; i++)
                {
                    if (ShipDef.attachment[i] is attachmentDataStructure)
                    {
                        attachmentDataStructure attachment = (attachmentDataStructure)ShipDef.attachment[i];
                        OgreShipAttachment attachmentent = new OgreShipAttachment();
                        attachmentent.SelectedIndex = i;
                        attachmentent.ParentShipActor = ShipActor;
                        attachmentent.AttachmentDec = attachment;
                        List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                        foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                        {
                            if (attachmentdata.GetObjectID() == attachment.attachmentID)
                            {
                                attachmentdefhits.Add(attachmentdata);
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
                if (i < ShipDef.attachment.Count)
                {
                    if (ShipDef.attachment[i] is attachmentDataStructure)
                    {
                        OgreAttachments[i].AttachmentDec = (attachmentDataStructure)ShipDef.attachment[i];
                    }
                    OgreAttachments[i].Update();
                }
            }
        }

        private void UpdateShip()
        {            
            string meshname = ShipDef.meshName;
            meshname = OgreControl.GetTrueFileName(meshname);
            if (meshname != "")
            {
                if (ShipActor.GetMeshName() != meshname)
                {
                    ShipActor.SetMesh(meshname);
                    OnShipMainMeshChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        private void DataFile_OnThisFileLoaded(object sender, EventArgs e)
        {
            UpdateShip();
        }

        private void DataFile_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
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
                ShipDef.rotatingElement.CollectionChanged += RotatingElement_CollectionChanged;
                UpdateRotatingElements();
            }
            if (e.PropertyName == "turret")
            {
                ShipDef.turret.CollectionChanged += Turret_CollectionChanged;
                UpdateTurrets();
            }
            if (e.PropertyName == "attachment")
            {
                ShipDef.attachment.CollectionChanged += Attachment_CollectionChanged;
                UpdateAttachments();
            }
            if (e.PropertyName == "damage")
            {
                ShipDef.damage.CollectionChanged += Damage_CollectionChanged;
                UpdateDamageStates();
            }
            if (e.PropertyName == "propulsion")
            {
                ShipDef.propulsion.CollectionChanged += Propulsion_CollectionChanged;
                UpdatePropulsion();
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

        public void SetOnAllDamageStates()
        {
            foreach (OgreShipDamageStateEffect comp in DamageStateEffects)
            {
                comp.StartEffect();
            }
        }

        public void SetDamageState(float inHealthpoint)
        {
            CurrentHealthPercent = inHealthpoint;
            if (inHealthpoint < 0)
            {
                foreach (OgreShipDamageStateEffect comp in DamageStateEffects)
                {
                    comp.StopEffect();
                }
                return;
            }
            for (int i = 0; i < DamageStateEffects.Count; i++)
            {
                if (DamageStateEffects[i].HealthPoint >= inHealthpoint)
                {
                    DamageStateEffects[i].StartEffect();
                }
                else 
                {
                    DamageStateEffects[i].StopEffect();
                }
            }
        }

        public bool ToggleDamageState(int inIndex)
        {            
            if ((inIndex < DamageStateEffects.Count) && (inIndex >= 0))
            {
                if (DamageStateEffects[inIndex].EffectActive)
                {
                    DamageStateEffects[inIndex].StopEffect();
                }
                else
                {
                    DamageStateEffects[inIndex].StartEffect();
                }
                return DamageStateEffects[inIndex].EffectActive;
            }
            return false;
        }

        public bool TogglePropulsionEffect(int inIndex)
        {
            if ((inIndex < PropulsionEffects.Count) && (inIndex >= 0))
            {
                if (PropulsionEffects[inIndex].EffectActive)
                {
                    PropulsionEffects[inIndex].StopEffect();
                }
                else
                {
                    PropulsionEffects[inIndex].StartEffect();
                }
                return PropulsionEffects[inIndex].EffectActive;
            }
            return false;
        }

        public bool TogglePropulsionEffectDirection(string inDirection)
        {
            bool effectsareactive = false;
            foreach (OgreShipPropulsionEffect propulsion in PropulsionEffects)
            {
                if (propulsion.PropulsionDec.direction == inDirection)
                {
                    if (propulsion.EffectActive)
                    {
                        effectsareactive = true;
                    }                    
                }
            }
            foreach (OgreShipPropulsionEffect propulsion in PropulsionEffects)
            {
                if (propulsion.PropulsionDec.direction == inDirection)
                {
                    if (effectsareactive)
                    {
                        propulsion.StopEffect();
                    }
                    else
                    {
                        propulsion.StartEffect();
                    }
                }
            }
            if (!effectsareactive)
            {
                return true;
            }
            return false;
        }

        public void TurnOnAllPropulsionEffects()
        {
            foreach (OgreShipPropulsionEffect propulsion in PropulsionEffects)
            {
                propulsion.StartEffect();
            }
        }

        public void TurnOffAllPropulsionEffects()
        {
            foreach (OgreShipPropulsionEffect propulsion in PropulsionEffects)
            {
                propulsion.StopEffect();
            }
        }
    }

    /////////////////////////////////////////////////////
    //ATTACHMENT
    /////////////////////////////////////////////////////

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
                        if (attachmentdata.GetObjectID() == AttachmentDec.attachmentID)
                        {
                            attachmentdefhits.Add(attachmentdata);
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

        public EditorActor ParentShipActor;
        public EditorActor AttachmentActor;
        public int SelectedIndex;

        public void Spawn()
        {
            if ((AttachmentDef != null) && (AttachmentDec != null))
            {
                Random rnd = new Random();

                AttachmentActor = ParentShipActor.CreateChildActor(ParentShipActor.GetName() + "Attachment" + SelectedIndex.ToString() + rnd.Next().ToString());
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
                        if (attachmentdata.GetObjectID() == AttachmentDec.attachmentID)
                        {
                            attachmentdefhits.Add(attachmentdata);
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
                    if (AttachmentDef.objectID != AttachmentDec.attachmentID)
                    {
                        List<OtherObjectData> attachmentdefhits = new List<OtherObjectData>();
                        foreach (OtherObjectData attachmentdata in EditorUI.UI.OtherObjects.Data.Values)
                        {
                            if (attachmentdata.GetObjectID() == AttachmentDec.attachmentID)
                            {
                                attachmentdefhits.Add(attachmentdata);
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
        }
    }

    /////////////////////////////////////////////////////
    //TURRET
    /////////////////////////////////////////////////////

    public class OgreShipTurret
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

        public EditorActor TurretActor;
        public EditorActor ParentShipActor;
        public EditorWorld World;
        public int SelectedIndex;

        public void Spawn()
        {
            Random rnd = new Random();
            TurretActor = ParentShipActor.CreateChildActor(ParentShipActor.GetName() + "Turret" + SelectedIndex.ToString() + rnd.Next().ToString());
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
                float pitchasdegrees = TurretDec.pitch;
                switch (TurretDec.turretOrientation)
                {
                    case "bottom":
                        pitchasdegrees = TurretDec.pitch + 180.0f;
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
                else
                {
                    if (TurretDef.weaponID != TurretDec.turretID)
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
                float pitchasdegrees = TurretDec.pitch;
                switch (TurretDec.turretOrientation)
                {
                    case "bottom":
                        pitchasdegrees = TurretDec.pitch + 180.0f;
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

    /////////////////////////////////////////////////////
    //DAMAGE
    /////////////////////////////////////////////////////

    public class OgreShipDamageStateEffect
    {
        public OgreShipDamageStateEffect()
        {

        }

        public OgreShipDamageStateEffect(damageDataStructure inDamageDec, EditorActor inShipActor, int inIndex)
        {
            List<ParticleData> defhits = new List<ParticleData>();
            foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
            {
                if (inDamageDec.PropertyExists("damageEffectID"))
                {
                    if (data.GetObjectID() == inDamageDec.damageEffectID)
                    {
                        defhits.Add(data);
                    }
                }
                else
                {
                    if (data.GetObjectID() == "damage00")
                    {
                        defhits.Add(data);
                    }
                }
            }
            ParticleData bestdef = null;
            foreach (ParticleData def in defhits)
            {
                if (bestdef == null)
                {
                    bestdef = def;
                }
                else if ((def.Source != null) && (bestdef.Source != null))
                {
                    if (def.Source.ShortName == "Mod")
                    {
                        if (bestdef.Source.ShortName == "Base")
                        {
                            bestdef = def;
                        }
                    }
                }
            }
            if (bestdef != null)
            {                
                DamageDec = inDamageDec;
                ParticleDef = bestdef;
                ParentShipActor = inShipActor;
                World = inShipActor.GetWorld();
                SelectedIndex = inIndex;
                
                Spawn();
            }
        }

        public void DestroyDamageStateEffect()
        {
            DamageComponent.Destroy();
            if (_ParticleDef != null)
            {
                _ParticleDef.VD2PropertyChanged -= ParticleDef_VD2PropertyChanged;
                _ParticleDef.OnThisFileOverriden -= ParticleDef_OnThisFileOverriden;
                _ParticleDef.OnThisFileLoaded -= ParticleDef_OnThisFileLoaded;
                _ParticleDef.OnThisFileDeleted -= ParticleDef_OnThisFileDeleted;
            }
            if (_DamageDec != null)
            {
                _DamageDec.VD2PropertyChanged -= DamageDec_VD2PropertyChanged;
            }
            DamageComponent = null;
            _ParticleDef = null;
            _DamageDec = null;
        }

        public ParticleData _ParticleDef;
        public ParticleData ParticleDef
        {
            get
            {
                return _ParticleDef;
            }
            set
            {
                if (_ParticleDef != null)
                {
                    _ParticleDef.VD2PropertyChanged -= ParticleDef_VD2PropertyChanged;
                    _ParticleDef.OnThisFileOverriden -= ParticleDef_OnThisFileOverriden;
                    _ParticleDef.OnThisFileLoaded -= ParticleDef_OnThisFileLoaded;
                    _ParticleDef.OnThisFileDeleted -= ParticleDef_OnThisFileDeleted;
                }
                _ParticleDef = value;
                if (_ParticleDef != null)
                {
                    _ParticleDef.VD2PropertyChanged += ParticleDef_VD2PropertyChanged;
                    _ParticleDef.OnThisFileOverriden += ParticleDef_OnThisFileOverriden;
                    _ParticleDef.OnThisFileLoaded += ParticleDef_OnThisFileLoaded;
                    _ParticleDef.OnThisFileDeleted += ParticleDef_OnThisFileDeleted;
                }
            }
        }

        private void ParticleDef_OnThisFileDeleted(object sender, EventArgs e)
        {
            if (ParticleDef.Source != null)
            {
                if (ParticleDef.Source.ShortName != "Base")
                {
                    List<ParticleData> defhits = new List<ParticleData>();
                    foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                    {
                        if (data.GetObjectID() == DamageDec.damageEffectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ParticleData bestdef = null;
                    foreach (ParticleData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    ParticleDef = bestdef;
                }
                else
                {
                    ParticleDef = null;
                }
            }
            Update();
        }

        private void ParticleDef_OnThisFileLoaded(object sender, EventArgs e)
        {
            Update();
        }

        private void ParticleDef_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (e.NewFile is ParticleData)
            {
                ParticleData newdef = (ParticleData)e.NewFile;
                if (e.OldFile is ParticleData)
                {
                    ParticleData testolddef = (ParticleData)e.OldFile;
                    if (ParticleDef != null)
                    {
                        if (testolddef == ParticleDef)
                        {
                            ParticleDef = newdef;
                            Update();
                        }
                    }
                }
            }
        }

        private void ParticleDef_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "systemName")
            {
                Update();
            }
        }

        public damageDataStructure _DamageDec;
        public damageDataStructure DamageDec
        {
            get
            {
                return _DamageDec;
            }
            set
            {
                if (_DamageDec != null)
                {
                    _DamageDec.VD2PropertyChanged -= DamageDec_VD2PropertyChanged;
                }
                _DamageDec = value;
                if (_DamageDec != null)
                {
                    _DamageDec.VD2PropertyChanged += DamageDec_VD2PropertyChanged;
                }
            }
        }

        public float HealthPoint
        {
            get
            {
                if (_DamageDec != null)
                {
                    return _DamageDec.healthPoint;
                }
                return 0;
            }
        }

        //public PUSystemComponent DamageComponent;
        public PUSystemComponent DamageComponent;
        public EditorActor ParentShipActor;
        public EditorWorld World;
        public int SelectedIndex;

        public bool EffectActive;

        public void StartEffect()
        {
            DamageComponent.PlaySystem();
            EffectActive = true;
        }

        public void StopEffect()
        {
            DamageComponent.StopSystem();
            EffectActive = false;
        }

        public void Spawn()
        {
            if ((ParticleDef != null) && (DamageDec != null))
            {
                Random rnd = new Random();
                DamageComponent = ParentShipActor.CreatePUSystemComponent(ParentShipActor.GetName() + "DamageState" + SelectedIndex.ToString() + ParticleDef.systemName + rnd.Next().ToString(), ParticleDef.systemName, false);
                float yawasdegrees = DamageDec.yaw;
                float rollasdegrees = DamageDec.roll;
                float pitchasdegrees = DamageDec.pitch;                
                DamageComponent.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
                DamageComponent.SetRelativePosition(DamageDec.position.x, DamageDec.position.y, DamageDec.position.z);
            }
        }

        private void DamageDec_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            if (DamageDec != null)
            {
                if (ParticleDef == null)//if we have a declaration but no reference to the definition it uses, find it so we can spawn
                {
                    List<ParticleData> defhits = new List<ParticleData>();
                    foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                    {
                        if (data.GetObjectID() == DamageDec.damageEffectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ParticleData bestdef = null;
                    foreach (ParticleData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    ParticleDef = bestdef;
                }
                else
                {
                    if (ParticleDef.objectID != DamageDec.damageEffectID)
                    {
                        List<ParticleData> defhits = new List<ParticleData>();
                        foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                        {
                            if (data.GetObjectID() == DamageDec.damageEffectID)
                            {
                                defhits.Add(data);
                            }
                        }
                        ParticleData bestdef = null;
                        foreach (ParticleData def in defhits)
                        {
                            if (bestdef == null)
                            {
                                bestdef = def;
                            }
                            else if ((def.Source != null) && (bestdef.Source != null))
                            {
                                if (def.Source.ShortName == "Mod")
                                {
                                    if (bestdef.Source.ShortName == "Base")
                                    {
                                        bestdef = def;
                                    }
                                }
                            }
                        }
                        ParticleDef = bestdef;
                    }
                }
                if (DamageComponent == null)
                {
                    Spawn();
                    return;
                }
                if ((DamageComponent.GetRelativePositionX() != DamageDec.position.x) || (DamageComponent.GetRelativePositionY() != DamageDec.position.y) || (DamageComponent.GetRelativePositionZ() != DamageDec.position.z))
                {
                    DamageComponent.SetRelativePosition(DamageDec.position.x, DamageDec.position.y, DamageDec.position.z);
                }
                float yawasdegrees = DamageDec.yaw;
                float rollasdegrees = DamageDec.roll;
                float pitchasdegrees = DamageDec.pitch;
                DamageComponent.SetRelativeRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
            }
            if (ParticleDef != null)
            {                
                if (ParticleDef.systemName != "")
                {
                    if (DamageComponent.GetPUSystemName() != ParticleDef.systemName)
                    {
                        DamageComponent.SetSystemByTemplate(ParticleDef.systemName);
                        if (EffectActive)
                        {
                            DamageComponent.PlaySystem();
                        }
                    }
                }
            }
        }
    }

    /////////////////////////////////////////////////////
    //PROPULSION
    /////////////////////////////////////////////////////

    public class OgreShipPropulsionEffect
    {
        public void DestroyPropulsionEffect()
        {
            PropulsionComponent.Destroy();
            if (_ParticleDef != null)
            {
                _ParticleDef.VD2PropertyChanged -= ParticleDef_VD2PropertyChanged;
                _ParticleDef.OnThisFileOverriden -= ParticleDef_OnThisFileOverriden;
                _ParticleDef.OnThisFileLoaded -= ParticleDef_OnThisFileLoaded;
                _ParticleDef.OnThisFileDeleted -= ParticleDef_OnThisFileDeleted;
            }
            if (_PropulsionDec != null)
            {
                _PropulsionDec.VD2PropertyChanged -= PropulsionDec_VD2PropertyChanged;
            }
            PropulsionComponent = null;
            _ParticleDef = null;
            _PropulsionDec = null;
        }

        public ParticleData _ParticleDef;
        public ParticleData ParticleDef
        {
            get
            {
                return _ParticleDef;
            }
            set
            {
                if (_ParticleDef != null)
                {
                    _ParticleDef.VD2PropertyChanged -= ParticleDef_VD2PropertyChanged;
                    _ParticleDef.OnThisFileOverriden -= ParticleDef_OnThisFileOverriden;
                    _ParticleDef.OnThisFileLoaded -= ParticleDef_OnThisFileLoaded;
                    _ParticleDef.OnThisFileDeleted -= ParticleDef_OnThisFileDeleted;
                }
                _ParticleDef = value;
                if (_ParticleDef != null)
                {
                    _ParticleDef.VD2PropertyChanged += ParticleDef_VD2PropertyChanged;
                    _ParticleDef.OnThisFileOverriden += ParticleDef_OnThisFileOverriden;
                    _ParticleDef.OnThisFileLoaded += ParticleDef_OnThisFileLoaded;
                    _ParticleDef.OnThisFileDeleted += ParticleDef_OnThisFileDeleted;
                }
            }
        }

        private void ParticleDef_OnThisFileDeleted(object sender, EventArgs e)
        {
            if (ParticleDef.Source != null)
            {
                if (ParticleDef.Source.ShortName != "Base")
                {
                    List<ParticleData> defhits = new List<ParticleData>();
                    foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                    {
                        if (data.GetObjectID() == PropulsionDec.propulsionEffectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ParticleData bestdef = null;
                    foreach (ParticleData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    ParticleDef = bestdef;
                }
                else
                {
                    ParticleDef = null;
                }
            }
            Update();
        }

        private void ParticleDef_OnThisFileLoaded(object sender, EventArgs e)
        {
            Update();
        }

        private void ParticleDef_OnThisFileOverriden(object sender, VD2DataFileOverridenArgs e)
        {
            if (e.NewFile is ParticleData)
            {
                ParticleData newdef = (ParticleData)e.NewFile;
                if (e.OldFile is ParticleData)
                {
                    ParticleData testolddef = (ParticleData)e.OldFile;
                    if (ParticleDef != null)
                    {
                        if (testolddef == ParticleDef)
                        {
                            ParticleDef = newdef;
                            Update();
                        }
                    }
                }
            }
        }

        private void ParticleDef_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "systemName")
            {
                Update();
            }
        }

        public propulsionDataStructure _PropulsionDec;
        public propulsionDataStructure PropulsionDec
        {
            get
            {
                return _PropulsionDec;
            }
            set
            {
                if (_PropulsionDec != null)
                {
                    _PropulsionDec.VD2PropertyChanged -= PropulsionDec_VD2PropertyChanged;
                }
                _PropulsionDec = value;
                if (_PropulsionDec != null)
                {
                    _PropulsionDec.VD2PropertyChanged += PropulsionDec_VD2PropertyChanged;
                }
            }
        }
        
        public PUSystemComponent PropulsionComponent;
        public EditorActor ParentShipActor;
        public EditorWorld World;
        public int SelectedIndex;

        public bool EffectActive;

        public void StartEffect()
        {
            PropulsionComponent.PlaySystem();
            EffectActive = true;
        }

        public void StopEffect()
        {
            PropulsionComponent.StopSystem();
            EffectActive = false;
        }

        public void Spawn()
        {
            
            if ((ParticleDef != null) && (PropulsionDec != null))
            {
                Random rnd = new Random();
                PropulsionComponent = ParentShipActor.CreatePUSystemComponent(ParentShipActor.GetName() + "Propulsion" + SelectedIndex.ToString() + ParticleDef.systemName + rnd.Next().ToString(), ParticleDef.systemName, false);
                float yawasdegrees = PropulsionDec.yaw;
                float rollasdegrees = PropulsionDec.roll;
                float pitchasdegrees = PropulsionDec.pitch;
                switch (PropulsionDec.direction)
                {
                    case "down":
                        pitchasdegrees = PropulsionDec.pitch + 90.0f;
                        //yawasdegrees = PropulsionDec.yaw + 180.0f;
                        break;
                    case "up":
                        pitchasdegrees = PropulsionDec.pitch - 90.0f;
                        break;
                    case "port":
                        yawasdegrees = PropulsionDec.yaw + 90.0f;
                        break;
                    case "starboard":
                        yawasdegrees = PropulsionDec.yaw - 90.0f;
                        break;
                    case "fore":
                        pitchasdegrees = PropulsionDec.pitch - 180.0f;
                        break;
                }
                PropulsionComponent.SetWorldRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
                PropulsionComponent.SetRelativePosition(PropulsionDec.position.x, PropulsionDec.position.y, PropulsionDec.position.z);
            }
        }

        private void PropulsionDec_VD2PropertyChanged(object sender, VD2PropertyChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            if (PropulsionDec != null)
            {
                if (ParticleDef == null)//if we have a declaration but no reference to the definition it uses, find it so we can spawn
                {
                    List<ParticleData> defhits = new List<ParticleData>();
                    foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                    {
                        if (data.GetObjectID() == PropulsionDec.propulsionEffectID)
                        {
                            defhits.Add(data);
                        }
                    }
                    ParticleData bestdef = null;
                    foreach (ParticleData def in defhits)
                    {
                        if (bestdef == null)
                        {
                            bestdef = def;
                        }
                        else if ((def.Source != null) && (bestdef.Source != null))
                        {
                            if (def.Source.ShortName == "Mod")
                            {
                                if (bestdef.Source.ShortName == "Base")
                                {
                                    bestdef = def;
                                }
                            }
                        }
                    }
                    ParticleDef = bestdef;
                }
                else
                {
                    if (ParticleDef.objectID != PropulsionDec.propulsionEffectID)
                    {
                        List<ParticleData> defhits = new List<ParticleData>();
                        foreach (ParticleData data in EditorUI.UI.Particles.Data.Values)
                        {
                            if (data.GetObjectID() == PropulsionDec.propulsionEffectID)
                            {
                                defhits.Add(data);
                            }
                        }
                        ParticleData bestdef = null;
                        foreach (ParticleData def in defhits)
                        {
                            if (bestdef == null)
                            {
                                bestdef = def;
                            }
                            else if ((def.Source != null) && (bestdef.Source != null))
                            {
                                if (def.Source.ShortName == "Mod")
                                {
                                    if (bestdef.Source.ShortName == "Base")
                                    {
                                        bestdef = def;
                                    }
                                }
                            }
                        }
                        ParticleDef = bestdef;
                    }
                }
                if (PropulsionComponent == null)
                {
                    Spawn();
                    return;
                }
                if ((PropulsionComponent.GetRelativePositionX() != PropulsionDec.position.x) || (PropulsionComponent.GetRelativePositionY() != PropulsionDec.position.y) || (PropulsionComponent.GetRelativePositionZ() != PropulsionDec.position.z))
                {
                    PropulsionComponent.SetRelativePosition(PropulsionDec.position.x, PropulsionDec.position.y, PropulsionDec.position.z);
                }
                float yawasdegrees = PropulsionDec.yaw;
                float rollasdegrees = PropulsionDec.roll;
                float pitchasdegrees = PropulsionDec.pitch;
                switch (PropulsionDec.direction)
                {
                    case "down":
                        pitchasdegrees = PropulsionDec.pitch + 90.0f;
                        //yawasdegrees = PropulsionDec.yaw + 180.0f;
                        break;
                    case "up":
                        pitchasdegrees = PropulsionDec.pitch - 90.0f;
                        break;
                    case "port":
                        yawasdegrees = PropulsionDec.yaw + 90.0f;
                        break;
                    case "starboard":
                        yawasdegrees = PropulsionDec.yaw - 90.0f;
                        break;
                    case "fore":
                        pitchasdegrees = PropulsionDec.pitch - 180.0f;
                        break;
                }
                PropulsionComponent.SetWorldRotation(yawasdegrees, pitchasdegrees, rollasdegrees);
            }
            if (ParticleDef != null)
            {
                if (ParticleDef.systemName != "")
                {
                    if (PropulsionComponent.GetPUSystemName() != ParticleDef.systemName)
                    {
                        PropulsionComponent.SetSystemByTemplate(ParticleDef.systemName);
                        if (EffectActive)
                        {
                            PropulsionComponent.PlaySystem();
                        }
                    }
                }
            }
        }
    }
}
