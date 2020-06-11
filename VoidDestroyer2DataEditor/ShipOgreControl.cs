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
    public partial class ShipOgreControl : OgreControl
    {
        ShipData _DataFile;
        public ShipData DataFile
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

        OgreShip Ship;

        

        public ShipOgreControl() : base()
        {
            InitializeComponent();
        }

        protected override void SpawnEntities()
        {
            Ship = new OgreShip(_DataFile, World);
            Ship.IsShipDataPreviewShip = true;
            distance = Ship.GetBoundingRadius() * 1.25f;
            zoomdistance = distance * 0.1f;
            VP.SetCameraYawPitchDistance(yaw, pitch, distance);
            Ship.OnShipMainMeshChanged += Ship_OnShipMainMeshChanged;
        }

        private void Ship_OnShipMainMeshChanged(object sender, EventArgs e)
        {
            distance = Ship.GetBoundingRadius() * 1.25f;
            zoomdistance = distance * 0.1f;
            VP.SetCameraYawPitchDistance(yaw, pitch, distance);
        }

        protected override void ResetCamera()
        {
            if (Ship != null)
            {
                if (Ship.ShipActor != null)
                {
                    distance = Ship.ShipActor.GetBoundingRadius() * 1.25f;
                    zoomdistance = distance * 0.1f;
                    yaw = 0;
                    pitch = 0;
                    VP.SetCameraYawPitchDistance(yaw, pitch, distance);
                }
            }
        }

        protected override void PopulateContextMenu()
        {
            base.PopulateContextMenu();
            ToolStripMenuItem currentrootitem = new ToolStripMenuItem("Preview Damage");
            ToolStripMenuItem currentsubitem = new ToolStripMenuItem("All Off");
            /*if (Ship.CurrentHealthPercent < 0)
            {
                currentsubitem.Checked = true;
            }
            else
            {
                currentsubitem.Checked = false;
            }*/
            currentsubitem.Click += PreviewDamageAllOff_Click;
            currentrootitem.DropDownItems.Add(currentsubitem);
            currentsubitem = new ToolStripMenuItem("All On");
            /*if (Ship.CurrentHealthPercent < 0)
            {
                currentsubitem.Checked = true;
            }
            else
            {
                currentsubitem.Checked = false;
            }*/
            currentsubitem.Click += PreviewDamageAllOn_Click;
            currentrootitem.DropDownItems.Add(currentsubitem);
            currentsubitem = new ToolStripMenuItem("Toggle Single");
            for (int i = 0; i < DataFile.damage.Count; i++)
            {
                if (DataFile.damage[i] is damageDataStructure)
                {
                    damageDataStructure damagestate = (damageDataStructure)DataFile.damage[i];
                    ToolStripMenuItem currenttogglesingledamageitem = new ToolStripMenuItem(i.ToString() + ": " + (damagestate.healthPoint * 100).ToString() + "% Damaged");
                    //currenttogglesingledamageitem.Checked = false;
                    currenttogglesingledamageitem.Click += ToggleSingleDamageItem_Click; ;
                    currentsubitem.DropDownItems.Add(currenttogglesingledamageitem);
                }
            }
            currentrootitem.DropDownItems.Add(currentsubitem);
            currentsubitem = new ToolStripMenuItem("Preview by Health Threshold");
            Dictionary<float, List<damageDataStructure>> healthpoints = new Dictionary<float, List<damageDataStructure>>();
            for (int i = 0; i < DataFile.damage.Count; i++)
            {
                if (DataFile.damage[i] is damageDataStructure)
                {
                    damageDataStructure damagestate = (damageDataStructure)DataFile.damage[i];
                    if (healthpoints.ContainsKey(damagestate.healthPoint))
                    {
                        List<damageDataStructure> states;
                        healthpoints.TryGetValue(damagestate.healthPoint, out states);
                        states.Add(damagestate);
                    }
                    else
                    {
                        List<damageDataStructure> states = new List<damageDataStructure>();
                        states.Add(damagestate);
                        healthpoints.Add(damagestate.healthPoint, states);
                    }
                    /*currentsubitem = new ToolStripMenuItem(i.ToString() + ": " + (damagestate.healthPoint * 100).ToString() + "% Damaged");
                    currentsubitem.Checked = false;
                    currentsubitem.Click += PreviewDamageDamaged_Click;
                    currentrootitem.DropDownItems.Add(currentsubitem);*/
                }
            }
            var ordered = healthpoints.OrderByDescending(f => f.Key);
            int effectcount = 0;
            foreach(KeyValuePair<float, List<damageDataStructure>> threshold in ordered)
            {
                effectcount += threshold.Value.Count;
                ToolStripMenuItem currentthresholditem = new ToolStripMenuItem((threshold.Key * 100).ToString() + "% Damaged (" + effectcount.ToString() + " Effects)");
                /*if (Ship.CurrentHealthPercent == threshold.Key)
                {
                    currentsubitem.Checked = true;
                }
                else
                {
                    currentsubitem.Checked = false;
                }*/
                currentthresholditem.Click += PreviewDamageDamaged_Click;
                currentsubitem.DropDownItems.Add(currentthresholditem);
            }
            currentrootitem.DropDownItems.Add(currentsubitem);
            OgreContextMenu.Items.Add(currentrootitem);

            currentrootitem = new ToolStripMenuItem("Preview Propulsion");
            currentsubitem = new ToolStripMenuItem("All Off");
            /*if (Ship.CurrentHealthPercent < 0)
            {
                currentsubitem.Checked = true;
            }
            else
            {
                currentsubitem.Checked = false;
            }*/
            currentsubitem.Click += PreviewPropulsionAllOff_Click;
            currentrootitem.DropDownItems.Add(currentsubitem);

            currentsubitem = new ToolStripMenuItem("All On");
            /*if (Ship.CurrentHealthPercent < 0)
            {
                currentsubitem.Checked = true;
            }
            else
            {
                currentsubitem.Checked = false;
            }*/
            currentsubitem.Click += PreviewPropulsionAllOn_Click;
            currentrootitem.DropDownItems.Add(currentsubitem);

            currentsubitem = new ToolStripMenuItem("Toggle Single");
            for (int i = 0; i < DataFile.propulsion.Count; i++)
            {
                if (DataFile.propulsion[i] is propulsionDataStructure)
                {
                    propulsionDataStructure propulsion = (propulsionDataStructure)DataFile.propulsion[i];
                    ToolStripMenuItem currenttogglesinglepropulsionitem = new ToolStripMenuItem(i.ToString() + ": " + propulsion.direction + " " + propulsion.propulsionEffectID);
                    //currenttogglesinglepropulsionitem.Checked = false;
                    currenttogglesinglepropulsionitem.Click += ToggleSinglePropulsionItem_Click; ;
                    currentsubitem.DropDownItems.Add(currenttogglesinglepropulsionitem);
                }
            }
            currentrootitem.DropDownItems.Add(currentsubitem);

            currentsubitem = new ToolStripMenuItem("Preview by Direction");
            Dictionary<string, List<propulsionDataStructure>> directions = new Dictionary<string, List<propulsionDataStructure>>();
            for (int i = 0; i < DataFile.propulsion.Count; i++)
            {
                if (DataFile.propulsion[i] is propulsionDataStructure)
                {
                    propulsionDataStructure propulsioneffect = (propulsionDataStructure)DataFile.propulsion[i];
                    if (directions.ContainsKey(propulsioneffect.direction))
                    {
                        List<propulsionDataStructure> thrusters;
                        directions.TryGetValue(propulsioneffect.direction, out thrusters);
                        thrusters.Add(propulsioneffect);
                    }
                    else
                    {
                        List<propulsionDataStructure> thrusters = new List<propulsionDataStructure>();
                        thrusters.Add(propulsioneffect);
                        directions.Add(propulsioneffect.direction, thrusters);
                    }
                    /*currentsubitem = new ToolStripMenuItem(i.ToString() + ": " + (damagestate.healthPoint * 100).ToString() + "% Damaged");
                    currentsubitem.Checked = false;
                    currentsubitem.Click += PreviewDamageDamaged_Click;
                    currentrootitem.DropDownItems.Add(currentsubitem);*/
                }
            }
            var orderedpropulsion = directions.OrderByDescending(f => f.Key);
            int propulsioneffectcount = 0;
            foreach (KeyValuePair<string, List<propulsionDataStructure>> direction in orderedpropulsion)
            {
                propulsioneffectcount = direction.Value.Count;
                ToolStripMenuItem currentpropulsionitem = new ToolStripMenuItem(direction.Key + ": " + propulsioneffectcount.ToString() + " Effects");
                /*if (Ship.CurrentHealthPercent == threshold.Key)
                {
                    currentsubitem.Checked = true;
                }
                else
                {
                    currentsubitem.Checked = false;
                }*/
                currentpropulsionitem.Click += PreviewPropulsionDirection_Click;
                currentsubitem.DropDownItems.Add(currentpropulsionitem);
            }
            currentrootitem.DropDownItems.Add(currentsubitem);

            OgreContextMenu.Items.Add(currentrootitem);
        }

        private void PreviewPropulsionDirection_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender is ToolStripMenuItem)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    List<string> splittext = item.Text.Split(':').ToList();
                    if (splittext.Count == 2)
                    {
                        Ship.TogglePropulsionEffectDirection(splittext[0]);
                    }
                }
            }
            
        }

        private void PreviewPropulsionAllOn_Click(object sender, EventArgs e)
        {
            Ship.TurnOnAllPropulsionEffects();
        }

        private void PreviewDamageAllOn_Click(object sender, EventArgs e)
        {
            Ship.SetOnAllDamageStates();
        }

        private void ToggleSingleDamageItem_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                //throw new NotImplementedException();
                if (sender is ToolStripMenuItem)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    List<string> splittext = item.Text.Split(':').ToList();
                    if (splittext.Count == 2)
                    {
                        int result;
                        if (int.TryParse(splittext[0], out result))
                        {
                            /*item.Checked = */Ship.ToggleDamageState(result);                            
                        }
                    }
                }
            }
        }

        private void ToggleSinglePropulsionItem_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                //throw new NotImplementedException();
                if (sender is ToolStripMenuItem)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    List<string> splittext = item.Text.Split(':').ToList();
                    if (splittext.Count == 2)
                    {
                        int result;
                        if (int.TryParse(splittext[0], out result))
                        {
                            item.Checked = Ship.TogglePropulsionEffect(result);
                        }
                    }
                }
            }
        }

        private void PreviewDamageDamaged_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                //throw new NotImplementedException();
                if (sender is ToolStripMenuItem)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    List<string> splittext = item.Text.Split('%').ToList();
                    if (splittext.Count == 2)
                    {
                        float result;
                        if (float.TryParse(splittext[0], out result))
                        {
                            Ship.SetDamageState(result/100);
                            if (item.OwnerItem != null)
                            {
                                if (item.OwnerItem is ToolStripMenuItem)
                                {
                                    ToolStripMenuItem parentitem = (ToolStripMenuItem)item.OwnerItem;
                                    foreach (ToolStripMenuItem peeritem in parentitem.DropDownItems)
                                    {
                                        peeritem.Checked = false;
                                    }
                                }
                            }
                            item.Checked = true;
                        }
                    }
                }
            }
        }

        private void PreviewDamageAllOff_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Ship.SetDamageState(-1);            
        }

        private void PreviewPropulsionAllOff_Click(object sender, EventArgs e)
        {
            Ship.TurnOffAllPropulsionEffects();
        }

        protected override void OgreControlDisposed()
        {
            if (!DesignMode)
            {
                if (!SplashLoadingWindow)
                {                    
                    if (Ship != null)
                    {
                        Ship.DestroyShip();
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

        private void DataOgreControl_Load(object sender, EventArgs e)
        {
            base.OgreControl_Load(sender, e);
        }
    }    
}
