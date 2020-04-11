using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using VoidDestroyer2DataEditor.UI;

namespace VoidDestroyer2DataEditor
{
    

    public partial class MainEditorForm : Form
    {
        
        private VD2SourceDropdown sourcedropdown;
        private VD2TreeFilterDropdown treefiltersdropdown;
        public List<FilesTreeItem> FilesTreeItems;
        public List<string> ActiveFilters;
        public MainEditorForm()
        {
            InitializeComponent();
            ActiveFilters = new List<string>();
            FilesTreeItems = new List<FilesTreeItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EditorUI.UI.InitUI(this);

            //toolStripComboBox1.SelectedIndex = 0;
            SetTreeIconSize(EditorUserSettings.UserSettings.TreeIconSize);
            //FilesTree.ImageList = 
            if (EditorUserSettings.UserSettings.VD2Path != "")
            {
                
                InitAllTrees();
                RepopulateAllTrees();
                OpenVD2Document(new WelcomeDocument());
            }
            Disposed += MainEditorForm_Disposed;
        }

        private void MainEditorForm_Disposed(object sender, EventArgs e)
        {
            OgreRenderer.Renderer.ReleaseOgre();
        }

        public void SetTreeIconSize(int inSize)
        {
            switch (inSize)
            {
                case 16:
                    if (FilesTree.ImageList != TreeIcons16)
                    {
                        FilesTree.ImageList = TreeIcons16;
                        FilesTree.Indent = 16 + FilesTree.Margin.Left;
                    }
                    break;
                case 32:
                    if (FilesTree.ImageList != TreeIcons32)
                    {
                        FilesTree.ImageList = TreeIcons32;
                        FilesTree.Indent = 32 + FilesTree.Margin.Left;
                    }
                    break;
            }
        }

        public void ActivateFilter(string inTag)
        {
            for (int i = 0; i < ActiveFilters.Count; i++)
            {
                if (ActiveFilters[i] == inTag)
                {
                    return;
                }
            }
            ActiveFilters.Add(inTag);
            RepopulateAllTrees();
        }

        public bool IsFilterActive(string inTag)
        {
            for (int i = 0; i < ActiveFilters.Count; i++)
            {
                if (ActiveFilters[i] == inTag)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeactivateFilter(string inTag)
        {
            bool filterschanged = false;
            for (int i = 0; i < ActiveFilters.Count; i++)
            {
                if (ActiveFilters[i] == inTag)
                {
                    filterschanged = true;
                    ActiveFilters.RemoveAt(i);
                    i--;
                }
            }
            if (filterschanged)
            {
                RepopulateAllTrees();
            }
        }

        public void InitAllTrees()
        {
            FilesTreeItems.Clear();
            FilesTreeItem currentitem = new FilesTreeItem();
            currentitem.Name = "Data";
            currentitem.IconKey = "foldericon";
            FilesTreeItems.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Ships";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateShipsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Upgrades";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateUpgradesTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Weapons";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateWeaponsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Turrets";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateTurretsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Launchers";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateLaunchersTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Hangars";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateHangarsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Ammo";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateAmmoTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Missiles";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateMissilesTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Mines";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateMinesTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "AreaOfEffect";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateAreaOfEffectTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Asteroids";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateAsteroidsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Bases";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateBasesTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Characters";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateCharactersTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Cockpits";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateCockpitsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Debris";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateDebrisTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Dialog";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateDialogTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Docked Moving Elements";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateDockedMovingElementsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Doors";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateDoorsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Effects";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateEffectsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]); 
            currentitem = new FilesTreeItem();
            currentitem.Name = "Explosions";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateExplosionsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Factions";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateFactionsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Music";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateMusicTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Other";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateOtherTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Shields";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateShieldsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Skyboxes";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateSkyboxesTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Sounds";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateSoundsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Stations";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateStationsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Suns";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[0].Children.Add(currentitem);
            PopulateSunsTree(FilesTreeItems[0].Children[FilesTreeItems[0].Children.Count - 1]);            
        }

        public void RepopulateAllTrees()
        {
            FilesTree.Nodes.Clear();
            PopulateFilesTree(FilesTree.Nodes, FilesTreeItems);

            DataFileProperties.SelectedObject = null;
        }

        private void PopulateFilesTree(TreeNodeCollection inNodes, List<FilesTreeItem> inItems)
        {
            for (int i = 0; i < inItems.Count; i++)
            {
                if (!inItems[i].FilteredOut)
                {
                    inNodes.Add(inItems[i].Name, inItems[i].DisplayName, inItems[i].IconKey);
                    inNodes[inNodes.Count - 1].ContextMenuStrip = TreeContextMenu;
                    if (inItems[i].DataFile != null)
                    {
                        inItems[i].DataFile.FilesTreeNode = inNodes[inNodes.Count - 1];
                        inItems[i].DataFile.TreeItem = inItems[i];
                    }
                    
                    if (inItems[i].IsCategory)
                    {
                        PopulateFilesTree(inNodes[inNodes.Count - 1].Nodes, inItems[i].Children);
                    }
                }
                else
                {
                    if (inItems[i].DataFile != null)
                    {
                        inItems[i].DataFile.FilesTreeNode = null;
                        inItems[i].DataFile.TreeItem = null; 
                    }
                }
            }
        }

        public void PopulateShipsTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem = new FilesTreeItem();
            currentitem.Name = "Combat";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            
            currentitem = new FilesTreeItem();
            currentitem.Name = "Drones";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            
            currentitem = new FilesTreeItem();            
            currentitem.Name = "Fighters";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[1].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[1].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "GunShips";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[2].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[2].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[2].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Corvettes";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[3].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[3].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[3].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Frigates";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[4].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[4].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[4].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Destroyers";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[5].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[5].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[5].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Cruisers";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[6].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[6].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[6].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Carriers";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[7].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[7].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[7].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Dreadnaughts";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Light";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[8].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Medium";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[8].Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Heavy";
            currentitem.IconKey = "categoryicon";
            inItem.Children[0].Children[8].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Non Combat";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Transport";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Miner";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Shuttle";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Repair";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Ship Capture";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Base Capture";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);

            currentitem = new FilesTreeItem();
            currentitem.Name = "Builder";
            currentitem.IconKey = "categoryicon";
            inItem.Children[1].Children.Add(currentitem);            

            for (int i = 0; i < EditorUI.UI.Ships.Data.Keys.Count; i++)
            {
                ShipData currentship;
                if (EditorUI.UI.Ships.Data.TryGetValue(EditorUI.UI.Ships.Data.Keys.ElementAt(i), out currentship))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentship.FilePath);
                    //currentitem.Source = "Base";
                    currentitem.FilterTags.Add("FileType:Ship");
                    currentitem.FilterTags.Add("Faction:" + currentship.faction);
                    currentitem.FilterTags.Add("Class:" + currentship.shipClass);
                    if (currentship.shipClassSize != "")
                    {
                        currentitem.FilterTags.Add("Size:" + currentship.shipClassSize);
                    }
                    else
                    {
                        currentitem.FilterTags.Add("Size:Tiny");
                    }
                    if (currentship.sizeShipClass != "")
                    {
                        currentitem.FilterTags.Add("Hull:" + currentship.sizeShipClass);
                    }
                    else
                    {
                        currentitem.FilterTags.Add("Hull:" + currentship.shipClass);
                    }
                    currentitem.DataFile = currentship;
                    if (currentship.shipClass == "fighter")
                    {
                        currentitem.IconKey = "fightericon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[1].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[1].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[1].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "fighter_drone")
                    {
                        currentitem.IconKey = "droneicon";
                        inItem.Children[0].Children[0].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "gunship")
                    {
                        currentitem.IconKey = "gunshipicon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[2].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[2].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[2].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "corvette")
                    {
                        currentitem.IconKey = "corvetteicon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[3].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[3].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[3].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "frigate")
                    {
                        currentitem.IconKey = "frigateicon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[4].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[4].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[4].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "destroyer")
                    {
                        currentitem.IconKey = "destroyericon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[5].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[5].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[5].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "cruiser")
                    {
                        currentitem.IconKey = "cruisericon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[6].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[6].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[6].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "carrier")
                    {
                        currentitem.IconKey = "carriericon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[7].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[7].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[7].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "dreadnaught")
                    {
                        currentitem.IconKey = "dreadnaughticon";
                        if (currentship.shipClassSize == "light")
                        {
                            inItem.Children[0].Children[8].Children[0].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "medium")
                        {
                            inItem.Children[0].Children[8].Children[1].Children.Add(currentitem);
                        }
                        else if (currentship.shipClassSize == "heavy")
                        {
                            inItem.Children[0].Children[8].Children[2].Children.Add(currentitem);
                        }
                    }
                    else if (currentship.shipClass == "transport")
                    {
                        currentitem.IconKey = "transporticon";
                        inItem.Children[1].Children[0].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "mining")
                    {
                        currentitem.IconKey = "minericon";
                        inItem.Children[1].Children[1].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "shuttle")
                    {
                        currentitem.IconKey = "shuttleicon";
                        inItem.Children[1].Children[2].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "repair")
                    {
                        currentitem.IconKey = "repairicon";
                        inItem.Children[1].Children[3].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "capture")
                    {
                        currentitem.IconKey = "basecaptureicon";
                        inItem.Children[1].Children[5].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "ship_capture")
                    {
                        currentitem.IconKey = "shipcaptureicon";
                        inItem.Children[1].Children[4].Children.Add(currentitem);
                    }
                    else if (currentship.shipClass == "builder")
                    {
                        currentitem.IconKey = "buildericon";
                        inItem.Children[1].Children[6].Children.Add(currentitem);
                    }
                }
            }
        }

        public void PopulateUpgradesTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem = new FilesTreeItem();
            currentitem.Name = "Primary";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Active";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Other";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Persistent";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            for (int i = 0; i < EditorUI.UI.PrimaryUpgrades.Data.Keys.Count; i++)
            {
                PrimaryUpgradeData currentupgrade;
                if (EditorUI.UI.PrimaryUpgrades.Data.TryGetValue(EditorUI.UI.PrimaryUpgrades.Data.Keys.ElementAt(i), out currentupgrade))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentupgrade.FilePath);
                    currentitem.FilterTags.Add("FileType:PrimaryUpgrade");
                    currentitem.DataFile = currentupgrade;
                    if (currentupgrade.bPersistsOnShipChange)
                    {
                        currentitem.FilterTags.Add("UpgradeType:PersistentUpgrade");
                        inItem.Children[3].Children.Add(currentitem);
                    }
                    else if (currentupgrade.upgradeType == "other")
                    {
                        currentitem.FilterTags.Add("UpgradeType:OtherUpgrade");
                        inItem.Children[2].Children.Add(currentitem);
                    }
                    else 
                    {
                        currentitem.FilterTags.Add("UpgradeType:Primary");
                        inItem.Children[0].Children.Add(currentitem);
                    }
                }
            }
            for (int i = 0; i < EditorUI.UI.ActiveUpgrades.Data.Keys.Count; i++)
            {
                ActiveUpgradeData currentupgrade;
                if (EditorUI.UI.ActiveUpgrades.Data.TryGetValue(EditorUI.UI.ActiveUpgrades.Data.Keys.ElementAt(i), out currentupgrade))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentupgrade.FilePath);
                    currentitem.FilterTags.Add("FileType:ActiveUpgrade");
                    currentitem.DataFile = currentupgrade;
                    currentitem.FilterTags.Add("UpgradeType:Active");
                    inItem.Children[1].Children.Add(currentitem);
                }
            }
        }

        public void PopulateWeaponsTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem = new FilesTreeItem();
            currentitem.Name = "Projectile";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Instant";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Beam";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Collision";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Shield";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Tractor Beam";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Speed";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "ECM";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Ship Shooter";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Release Attached Ship";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            int i = 0;
            for (i = 0; i < EditorUI.UI.Weapons.Data.Keys.Count; i++)
            {
                WeaponData currentdata;
                if (EditorUI.UI.Weapons.Data.TryGetValue(EditorUI.UI.Weapons.Data.Keys.ElementAt(i), out currentdata))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Weapon");
                    currentitem.FilterTags.Add("WeaponType:" + currentdata.weaponType);
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    if (currentdata.weaponType == "projectile")
                    {
                        inItem.Children[(int)WeaponTypeIndex.projectile].Children.Add(currentitem);                        
                    }
                    else if (currentdata.weaponType == "instant")
                    {
                        inItem.Children[(int)WeaponTypeIndex.instant].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "beam")
                    {
                        inItem.Children[(int)WeaponTypeIndex.beam].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "collision")
                    {
                        inItem.Children[(int)WeaponTypeIndex.collision].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "shield")
                    {
                        inItem.Children[(int)WeaponTypeIndex.shield].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "tractor_beam")
                    {
                        inItem.Children[(int)WeaponTypeIndex.tractor_beam].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "speed")
                    {
                        inItem.Children[(int)WeaponTypeIndex.speed].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "ecm")
                    {
                        inItem.Children[(int)WeaponTypeIndex.ecm].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "ship_shooter")
                    {
                        inItem.Children[(int)WeaponTypeIndex.ship_shooter].Children.Add(currentitem);
                    }
                    else if (currentdata.weaponType == "release_attached_ship")
                    {
                        inItem.Children[(int)WeaponTypeIndex.release_attached_ship].Children.Add(currentitem);
                    }
                }
            }
        }
        public void PopulateTurretsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Turrets.Data.Keys.Count; i++)
            {                
                TurretData currentdata;
                if (EditorUI.UI.Turrets.Data.TryGetValue(EditorUI.UI.Turrets.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Turret");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }
        public void PopulateLaunchersTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Launchers.Data.Keys.Count; i++)
            {
                LauncherData currentdata;
                if (EditorUI.UI.Launchers.Data.TryGetValue(EditorUI.UI.Launchers.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Launcher");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }
        public void PopulateHangarsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Hangars.Data.Keys.Count; i++)
            {
                HangarData currentdata;
                if (EditorUI.UI.Hangars.Data.TryGetValue(EditorUI.UI.Hangars.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Hangar");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }
        public void PopulateAmmoTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Ammo.Data.Keys.Count; i++)
            {
                AmmoData currentdata;
                if (EditorUI.UI.Ammo.Data.TryGetValue(EditorUI.UI.Ammo.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Ammo");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }
        public void PopulateMissilesTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Missiles.Data.Keys.Count; i++)
            {
                MissileData currentdata;
                if (EditorUI.UI.Missiles.Data.TryGetValue(EditorUI.UI.Missiles.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Missile");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }
        public void PopulateMinesTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Mines.Data.Keys.Count; i++)
            {
                MineData currentdata;
                if (EditorUI.UI.Mines.Data.TryGetValue(EditorUI.UI.Mines.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Mine");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }        

        public void PopulateAreaOfEffectTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.AreaOfEffect.Data.Keys.Count; i++)
            {
                AreaOfEffectData currentdata;
                if (EditorUI.UI.AreaOfEffect.Data.TryGetValue(EditorUI.UI.AreaOfEffect.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:AreaOfEffect");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateAsteroidsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Asteroids.Data.Keys.Count; i++)
            {
                AsteroidData currentdata;
                if (EditorUI.UI.Asteroids.Data.TryGetValue(EditorUI.UI.Asteroids.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Asteroid");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateBasesTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Bases.Data.Keys.Count; i++)
            {
                BaseData currentdata;
                if (EditorUI.UI.Bases.Data.TryGetValue(EditorUI.UI.Bases.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Base");
                    currentitem.FilterTags.Add("Faction:" + currentdata.faction);
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateCharactersTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Characters.Data.Keys.Count; i++)
            {
                CharacterData currentdata;
                if (EditorUI.UI.Characters.Data.TryGetValue(EditorUI.UI.Characters.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Character");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateCockpitsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Cockpits.Data.Keys.Count; i++)
            {
                CockpitData currentdata;
                if (EditorUI.UI.Cockpits.Data.TryGetValue(EditorUI.UI.Cockpits.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Cockpit");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateDebrisTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Debris.Data.Keys.Count; i++)
            {
                DebrisData currentdata;
                if (EditorUI.UI.Debris.Data.TryGetValue(EditorUI.UI.Debris.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Debris");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateDialogTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Dialog.Data.Keys.Count; i++)
            {
                DialogData currentdata;
                if (EditorUI.UI.Dialog.Data.TryGetValue(EditorUI.UI.Dialog.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Dialog");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateDockedMovingElementsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.DockedMovingElements.Data.Keys.Count; i++)
            {
                DockedMovingElementData currentdata;
                if (EditorUI.UI.DockedMovingElements.Data.TryGetValue(EditorUI.UI.DockedMovingElements.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:DockedMovingElement");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateDoorsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Doors.Data.Keys.Count; i++)
            {
                DoorData currentdata;
                if (EditorUI.UI.Doors.Data.TryGetValue(EditorUI.UI.Doors.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Door");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateEffectsTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem = new FilesTreeItem();
            currentitem.Name = "Effects";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Particles";
            currentitem.IconKey = "categoryicon";
            inItem.Children.Add(currentitem);
            for (int i = 0; i < EditorUI.UI.Effects.Data.Keys.Count; i++)
            {
                EffectData currentdata;
                if (EditorUI.UI.Effects.Data.TryGetValue(EditorUI.UI.Effects.Data.Keys.ElementAt(i), out currentdata))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Effect");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children[0].Children.Add(currentitem);
                }
            }
            for (int i = 0; i < EditorUI.UI.Particles.Data.Keys.Count; i++)
            {
                ParticleData currentdata;
                if (EditorUI.UI.Particles.Data.TryGetValue(EditorUI.UI.Particles.Data.Keys.ElementAt(i), out currentdata))
                {
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Particle");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children[1].Children.Add(currentitem);
                }
            }
        }

        public void PopulateExplosionsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Explosions.Data.Keys.Count; i++)
            {
                ExplosionData currentdata;
                if (EditorUI.UI.Explosions.Data.TryGetValue(EditorUI.UI.Explosions.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Explosion");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateFactionsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Factions.Data.Keys.Count; i++)
            {
                FactionData currentdata;
                if (EditorUI.UI.Factions.Data.TryGetValue(EditorUI.UI.Factions.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Faction");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateMusicTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Music.Data.Keys.Count; i++)
            {
                MusicData currentdata;
                if (EditorUI.UI.Music.Data.TryGetValue(EditorUI.UI.Music.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Music");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateOtherTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.OtherObjects.Data.Keys.Count; i++)
            {
                OtherObjectData currentdata;
                if (EditorUI.UI.OtherObjects.Data.TryGetValue(EditorUI.UI.OtherObjects.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Other");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateShieldsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Shields.Data.Keys.Count; i++)
            {
                ShieldData currentdata;
                if (EditorUI.UI.Shields.Data.TryGetValue(EditorUI.UI.Shields.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Shield");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateSkyboxesTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Skyboxes.Data.Keys.Count; i++)
            {
                SkyboxData currentdata;
                if (EditorUI.UI.Skyboxes.Data.TryGetValue(EditorUI.UI.Skyboxes.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Skybox");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateSoundsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Sounds.Data.Keys.Count; i++)
            {
                SoundData currentdata;
                if (EditorUI.UI.Sounds.Data.TryGetValue(EditorUI.UI.Sounds.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Sound");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateStationsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Stations.Data.Keys.Count; i++)
            {
                StationData currentdata;
                if (EditorUI.UI.Stations.Data.TryGetValue(EditorUI.UI.Stations.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Station");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }

        public void PopulateSunsTree(FilesTreeItem inItem)
        {
            for (int i = 0; i < EditorUI.UI.Suns.Data.Keys.Count; i++)
            {
                SunData currentdata;
                if (EditorUI.UI.Suns.Data.TryGetValue(EditorUI.UI.Suns.Data.Keys.ElementAt(i), out currentdata))
                {
                    FilesTreeItem currentitem = new FilesTreeItem();
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Sun");
                    currentitem.DataFile = currentdata;
                    currentitem.Name = Path.GetFileNameWithoutExtension(currentdata.FilePath);

                    inItem.Children.Add(currentitem);
                }
            }
        }       

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorAboutBox about = new EditorAboutBox();
            about.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*switch (toolStripComboBox1.SelectedIndex)
            {
                case (int)EditorModes.BaseReadOnly:
                    break;
                case (int)EditorModes.ModReadOnly:
                    EditorUI.UI.CurrentEditorMode = EditorModes.ModReadOnly;
                    RepopulateAllTrees();
                    break;
            }*/
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            if (sourcedropdown == null)
            {
                VD2SourceDropdown test = new VD2SourceDropdown();
                Controls.Add(test);
                sourcedropdown = test;
                Point newloc = EditorUI.GetEditorFormLocationFromNestedLocation(button1);//new Point(button1.Parent.Parent.Parent.Parent.Location.X + button1.Parent.Parent.Parent.Location.X + button1.Parent.Parent.Location.X + button1.Parent.Location.X + button1.Location.X, button1.Parent.Parent.Parent.Parent.Location.Y + button1.Parent.Parent.Parent.Location.Y + button1.Parent.Parent.Location.Y + button1.Parent.Location.Y + button1.Location.Y + button1.Size.Height);
                newloc.Y += button1.Size.Height;
                test.Location = newloc;
                test.BringToFront();
                test.Focus();
                test.Leave += new EventHandler(this.SourceDropdown_LostFocus);
            }
            else
            {
                sourcedropdown.Dispose();
                sourcedropdown = null;
            }
        }

        public void SourceDropdown_LostFocus(object sender, EventArgs e)
        {
            sourcedropdown.Dispose();
            sourcedropdown = null;
        }*/

        private FilesTreeItem GetFilesTreeItemByPath(string inPath)
        {
            FilesTreeItem result = null;
            List<string> splitpath = inPath.Split("\\".ToCharArray()).ToList();

            for (int splitidx = 0; splitidx < splitpath.Count; splitidx++)
            {
                if (result != null)
                {
                    for (int i = 0; i < result.Children.Count; i++)
                    {
                        if (result.Children[i].DisplayName == splitpath[splitidx])
                        {
                            result = result.Children[i];
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < FilesTreeItems.Count; i++)
                    {
                        if (FilesTreeItems[i].DisplayName == splitpath[splitidx])
                        {
                            result = FilesTreeItems[i];
                            break;
                        }
                    }
                }
            }
            
            return result;
        }

        private void FilesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<int> indexes = new List<int>();
            indexes.Add(e.Node.Index);
            TreeNode currentnode = e.Node;
            FilesTreeItem item = GetFilesTreeItemByPath(e.Node.FullPath);
            DataFileProperties.SelectedObject = item.DataFile;
            /*while (currentnode.Parent != null)
            {
                indexes.Add(currentnode.Parent.Index);
                currentnode = currentnode.Parent;
            }
            FilesTreeItem currentitem = null;
            if (FilesTreeItems.Count > 0)
            {
                currentitem = FilesTreeItems[indexes[indexes.Count - 1]];
            }
            
            for (int i = indexes.Count - 2; i > -1; i--)
            {
                currentitem = currentitem.Children[indexes[i]];
            }
            if (currentitem.DisplayName == e.Node.Name)
            {
                DataFileProperties.SelectedObject = currentitem.DataFile;
            }*/
        }

        

        /*private void button2_Click(object sender, EventArgs e)
        {
            if (treefiltersdropdown == null)
            {
                VD2TreeFilterDropdown test = new VD2TreeFilterDropdown();
                Controls.Add(test);
                treefiltersdropdown = test;
                Point newloc = EditorUI.GetEditorFormLocationFromNestedLocation(button2);//new Point(button1.Parent.Parent.Parent.Parent.Location.X + button1.Parent.Parent.Parent.Location.X + button1.Parent.Parent.Location.X + button1.Parent.Location.X + button1.Location.X, button1.Parent.Parent.Parent.Parent.Location.Y + button1.Parent.Parent.Parent.Location.Y + button1.Parent.Parent.Location.Y + button1.Parent.Location.Y + button1.Location.Y + button1.Size.Height);
                newloc.Y += button2.Size.Height;
                test.Location = newloc;
                test.BringToFront();
                test.Focus();
                test.Leave += new EventHandler(this.TreeFiltersDropdown_LostFocus);
            }
            else
            {
                treefiltersdropdown.Dispose();
                treefiltersdropdown = null;
            }
        }

        public void TreeFiltersDropdown_LostFocus(object sender, EventArgs e)
        {
            treefiltersdropdown.Dispose();
            treefiltersdropdown = null;
        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }*/

        private void TreeContextMenu_Opened(object sender, EventArgs e)
        {
            for (int i = 0; i < TreeContextMenu.Items.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        TreeContextMenu.Items[i].Enabled = false;
                        if (TreeContextMenu.SourceControl != null)
                        {
                            if (TreeContextMenu.SourceControl is TreeView)
                            {
                                TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                                if (tree != null)
                                {
                                    FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                                    if (item != null)
                                    {
                                        if (item.DataFile != null)
                                        {
                                            TreeContextMenu.Items[i].Enabled = true;
                                        }
                                    }
                                }
                            }

                        }

                        break;
                    case 1://save
                        TreeContextMenu.Items[i].Enabled = false;
                        if (TreeContextMenu.SourceControl != null)
                        {
                            if (TreeContextMenu.SourceControl is TreeView)
                            {
                                TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                                if (tree != null)
                                {
                                    FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                                    if (item != null)
                                    {
                                        if (item.DataFile != null)
                                        {
                                            TreeContextMenu.Items[i].Enabled = true;
                                        }
                                    }
                                }
                            }

                        }
                        
                        break;
                    case 2://save as
                        TreeContextMenu.Items[i].Enabled = false;
                        break;
                    case 3://delete
                        TreeContextMenu.Items[i].Enabled = false;
                        break;
                    case 4://duplicate to mod files
                        TreeContextMenu.Items[i].Enabled = false;
                        break;
                    case 6://copy objectID
                        TreeContextMenu.Items[i].Enabled = true;
                        /*if (TreeContextMenu.SourceControl != null)
                        {
                            if (TreeContextMenu.SourceControl is TreeView)
                            {
                                TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                                if (tree != null)
                                {
                                    FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                                    if (item != null)
                                    {
                                        if (item.DataFile != null)
                                        {
                                            TreeContextMenu.Items[i].Enabled = true;
                                        }
                                    }
                                }
                            }
                            
                        }*/
                        break;
                    case 7://find refs
                        TreeContextMenu.Items[i].Enabled = false;
                        break;
                }
            }
        }

        private void CopyObjectIDItem_Click(object sender, EventArgs e)
        {
            if (TreeContextMenu.SourceControl != null)
            {
                if (TreeContextMenu.SourceControl is TreeView)
                {
                    TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                    if (tree != null)
                    {
                        FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                        if (item != null)
                        {
                            /*
                            if (item.DataFile != null)
                            {
                                //TreeContextMenu.Items[i].Enabled = true;
                                Clipboard.SetText(item.DataFile.GetObjectID());
                            }*/
                            Clipboard.SetText(item.ObjectID);
                        }
                    }
                }

            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TreeContextMenu.SourceControl != null)
            {
                if (TreeContextMenu.SourceControl is TreeView)
                {
                    TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                    if (tree != null)
                    {
                        FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                        if (item != null)
                        {
                            if (item.DataFile != null)
                            {
                                EditorUI.ExploreFile(item.DataFile.FilePath);
                            }
                        }
                    }
                }

            }
            
        }

        public List<string> GetStandardFilterTags()
        {
            List<String> result = new List<string>();
            for (int i = 0; i < FilesTreeItems.Count; i++)
            {
                result.AddRange(GetStandardFilterTagsFromFilesTreeItem(FilesTreeItems[i]));
            }
            Dictionary<string, byte> dupeblocker = new Dictionary<string, byte>();
            for (int i = 0; i < result.Count; i++)
            {
                if (!dupeblocker.ContainsKey(result[i]))
                {
                    dupeblocker.Add(result[i], 0);
                }
            }
            result = dupeblocker.Keys.ToList();
            return result;
        }

        public List<string> GetStandardFilterTagsFromFilesTreeItem(FilesTreeItem inItem)
        {
            List<String> result = new List<string>();
            result.AddRange(inItem.FilterTags);
            for (int i = 0; i < inItem.Children.Count; i++)
            {
                result.AddRange(GetStandardFilterTagsFromFilesTreeItem(inItem.Children[i]));
            }
            return result;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (TreeContextMenu.SourceControl != null)
            {
                if (TreeContextMenu.SourceControl is TreeView)
                {
                    TreeView tree = (TreeView)TreeContextMenu.SourceControl;
                    if (tree != null)
                    {
                        FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(tree.SelectedNode.FullPath);
                        if (item != null)
                        {
                            if (item.DataFile != null)
                            {
                                //EditorUI.ExploreFile(item.DataFile.FilePath);
                                item.DataFile.SaveData();
                            }
                        }
                    }
                }
            }
        }

        private void FilesTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    FilesTree.SelectedNode = e.Node;
                    break;
                case MouseButtons.Middle:
                    FilesTree.SelectedNode = e.Node;
                    documentTabControl1.TabPages.Add(GetFilesTreeItemByPath(e.Node.FullPath).DisplayName);
                    break;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentTabControl1.TabPages.Add(GetFilesTreeItemByPath(FilesTree.SelectedNode.FullPath).DisplayName);
        }

        private void FilesTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    FilesTree.SelectedNode = e.Node;
                    FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(e.Node.FullPath);
                    if (item != null)
                    {
                        if (item.DataFile != null)
                        {
                            OpenVD2Document(item.DataFile, true);

                        }
                    }
                    break;
            }
        }
        public void OpenVD2Document(IVD2DocumentInterface inDocument, bool inGoToNewTab = false)
        {
            if (inDocument != null)
            {
                if (!IsDocumentAlreadyOpen(inDocument))
                {
                    TabPage docpage = new TabPage();

                    VD2DocumentViewer docview = new VD2DocumentViewer();
                    docpage.Controls.Add(docview);
                    docview.Dock = DockStyle.Fill;

                    documentTabControl1.TabPages.Add(docpage);
                    if (!inGoToNewTab)
                    {
                        documentTabControl1.SelectTab(docpage);
                    }
                    docview.Document = inDocument;
                }
                else
                {
                    SelectTabByDocument(inDocument);
                }
            }            
        }

        public bool IsDocumentAlreadyOpen(IVD2DocumentInterface inDocument)
        {
            foreach (TabPage page in documentTabControl1.TabPages)
            {
                foreach (Control c in page.Controls)
                {
                    if (c is VD2DocumentViewer)
                    {
                        VD2DocumentViewer docview = (VD2DocumentViewer)c;
                        if (docview.Document != null)
                        {
                            if (docview.Document == inDocument)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void SelectTabByDocument(IVD2DocumentInterface inDocument)
        {
            foreach (TabPage page in documentTabControl1.TabPages)
            {
                foreach (Control c in page.Controls)
                {
                    if (c is VD2DocumentViewer)
                    {
                        VD2DocumentViewer docview = (VD2DocumentViewer)c;
                        if (docview.Document != null)
                        {
                            if (docview.Document == inDocument)
                            {
                                documentTabControl1.SelectTab(page);
                            }
                        }
                    }
                }
            }
        }
    }

    

    //the order of this enum and the base nodes hard coded below must match!
    enum ShipClassIndex
    {
        fighter,
        gunship,
        corvette,
        frigate,
        destroyer,
        cruiser,
        carrier,
        dreadnaught,
        fighter_drone
    };
    enum ShipClassSizeIndex
    {
        light,
        medium,
        heavy
    };

    enum WeaponTypeIndex
    {
        projectile,
        instant,
        beam,
        collision,
        shield,
        tractor_beam,
        speed,
        ecm,
        ship_shooter,
        release_attached_ship
    };

    enum EditorModes
    {
        BaseReadOnly,
        ModReadOnly,
        BaseReadWrite,
        ModReadWrite
    }

    public class FilesTreeItem
    {
        public string Name;
        //public string Source;
        public string IconKey;
        public bool Saved;
        public VD2Data _DataFile;
        public List<string> FilterTags;
        public List<FilesTreeItem> Children;

        public VD2Data DataFile
        {
            get
            {
                return _DataFile;
            }
            set
            {
                if (_DataFile != null)
                {
                    _DataFile.VD2PropertyChanged -= OnMyFileEdited;
                }
                _DataFile = value;
                if (_DataFile != null)
                {
                    _DataFile.VD2PropertyChanged += OnMyFileEdited;
                }
            }
        }

        private void OnMyFileEdited(object sender, VD2PropertyChangedEventArgs e)
        {
            
        }

        public string ObjectID
        {
            get
            {
                if (DataFile != null)
                {
                    return DataFile.GetObjectID();
                }
                string result = "";
                for (int i = 0; i < Children.Count; i++)
                {
                    string test = Children[i].ObjectID;
                    if (test != "")
                    {
                        result += Children[i].ObjectID + ",";
                    }
                }
                if (result.Length != 0)
                {
                    return result.Substring(0, result.Length - 1);
                }
                return "";
            }
        }

        public bool IsCategory
        {
            get
            {
                if (Children.Count > 0)
                {
                    return true;
                }
                if (DataFile == null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool FilteredOut
        {
            get
            {
                if (IsCategory)
                {
                    if (Children.Count == 0)
                    {
                        return true;
                    }
                    bool allfiltered = true;
                    for (int idx = 0; idx < Children.Count; idx++)
                    {
                        if (!Children[idx].FilteredOut)
                        {
                            allfiltered = false;
                        }
                    }
                    if (allfiltered)
                    {
                        return true;
                    }
                }
                for (int i = 0; i < EditorUI.UI.EditorForm.ActiveFilters.Count; i++)
                {
                    for (int j = 0; j < FilterTags.Count; j++)
                    {
                        if (EditorUI.UI.EditorForm.ActiveFilters[i] == FilterTags[j])
                        {
                            return true;
                        }
                    }
                }
                if (DataFile != null)
                {
                    if (DataFile.Source != null)
                    {
                        if (!DataFile.Source.FilterIn)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public string DisplayName
        {
            get
            {
                if (IsCategory)
                {
                    return Name;
                }

                string savestring = "";
                if (Unsaved)
                {
                    savestring = "*";
                }

                string rwstring = "";
                string sourcestring = "";
                if (DataFile != null)
                {
                    if (DataFile.Source != null)
                    {
                        sourcestring = DataFile.Source.ShortName;
                        if (DataFile.Source.WriteAccess)
                        {
                            rwstring = "[RW]";
                        }
                        else
                        {
                            rwstring = "[R]";
                        }
                    }
                }

                return "(" + sourcestring + rwstring + ") " /*+ savestring*/ + Name;
            }
        }

        public bool Unsaved
        {
            get
            {
                if (IsCategory)
                {
                    for (int i = 0; i < Children.Count; i++)
                    {
                        if (Children[i].Unsaved)
                        {
                            return true;
                        }
                    }
                }

                if (DataFile != null)
                {
                    return DataFile.Unsaved;
                }

                return false;
            }
        }

        public FilesTreeItem()
        {
            Name = "";
            //Source = "";
            Saved = true;
            DataFile = null;
            Children = new List<FilesTreeItem>();
            FilterTags = new List<string>();
            IconKey = "genericfileicon";
        }
    }
}
