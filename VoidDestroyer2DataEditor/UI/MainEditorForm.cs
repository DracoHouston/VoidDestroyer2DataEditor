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
        public List<FilesTreeItem> FilesTreeItems;
        public List<string> ActiveFilters;

        WelcomeDocument StartupDocument;

        public MainEditorForm()
        {
            InitializeComponent();
            ActiveFilters = new List<string>();
            FilesTreeItems = new List<FilesTreeItem>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EditorUI.UI.InitUI(this);
            foreach (VD2FileSource source in EditorUserSettings.UserSettings.Sources)
            {
                source.OnWriteAccessChanged += Source_OnWriteAccessChanged;
            }
            //toolStripComboBox1.SelectedIndex = 0;
            SetTreeIconSize(EditorUserSettings.UserSettings.TreeIconSize);
            //FilesTree.ImageList = 
            if (EditorUserSettings.UserSettings.VD2Path != "")
            {
                
                InitAllTrees();
                RepopulateAllTrees();
                StartupDocument = new WelcomeDocument();
                OpenVD2Document(StartupDocument);
            }
            Disposed += MainEditorForm_Disposed;
        }

        private void Source_OnWriteAccessChanged(object sender, EventArgs e)
        {
            FilesTree.BeginUpdate();
            foreach (FilesTreeItem item in FilesTreeItems)
            {
                RefreshFilesTreeNodeText(item);
            }
            FilesTree.EndUpdate();
        }

        //!!!!!!!ALWAYS CALL BEGINUPDATE ON FILES TREE BEFORE CALLING THIS AND END UPDATE AFTER OR THIS TAKES OVER HALF A MINUTE TO EXECUTE!!!!!!!!!
        public void RefreshFilesTreeNodeText(FilesTreeItem inItem)
        {
            if (inItem.FilesTreeNode != null)
            {
                inItem.FilesTreeNode.Text = inItem.DisplayName;
            }
            foreach (FilesTreeItem item in inItem.Children)
            {
                RefreshFilesTreeNodeText(item);
            }
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
            currentitem = new FilesTreeItem();
            currentitem.Name = "Media";
            currentitem.IconKey = "foldericon";
            FilesTreeItems.Add(currentitem);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Models";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[1].Children.Add(currentitem);
            PopulateModelsTree(FilesTreeItems[1].Children[FilesTreeItems[1].Children.Count - 1]);
            currentitem = new FilesTreeItem();
            currentitem.Name = "Image Sets";
            currentitem.IconKey = "foldericon";
            FilesTreeItems[1].Children.Add(currentitem);
            PopulateImageSetTree(FilesTreeItems[1].Children[FilesTreeItems[1].Children.Count - 1]);
        }

        public void RepopulateAllTrees()
        {
            FilesTree.Nodes.Clear();
            PopulateFilesTree(FilesTree.Nodes, FilesTreeItems);
        }

        private void PopulateFilesTree(TreeNodeCollection inNodes, List<FilesTreeItem> inItems)
        {
            for (int i = 0; i < inItems.Count; i++)
            {
                if (!inItems[i].FilteredOut)
                {
                    inNodes.Add(inItems[i].Name, inItems[i].DisplayName, inItems[i].IconKey);
                    inNodes[inNodes.Count - 1].ContextMenuStrip = TreeContextMenu;
                    inItems[i].FilesTreeNode = inNodes[inNodes.Count - 1];
                    if (inItems[i].DataFile != null)
                    {
                        if (inItems[i].DataFile is VD2Data)
                        {
                            VD2Data df = (VD2Data)inItems[i].DataFile;
                            df.FilesTreeNode = inNodes[inNodes.Count - 1];
                            df.TreeItem = inItems[i];
                        }
                        
                    }
                    
                    if (inItems[i].IsCategory)
                    {
                        PopulateFilesTree(inNodes[inNodes.Count - 1].Nodes, inItems[i].Children);
                    }
                }
                else
                {
                    inItems[i].FilesTreeNode = null;
                    if (inItems[i].DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)inItems[i].DataFile;
                        df.FilesTreeNode = null;
                        df.TreeItem = null;
                    }
                }
            }
        }

        public void PopulateModelsTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem;
            List<string> folders = Directory.EnumerateDirectories(EditorUserSettings.UserSettings.VD2Path + "Media\\models").ToList();
            foreach (string folder in folders)
            {
                currentitem = new FilesTreeItem();
                currentitem.Name = Path.GetFileName(folder);
                currentitem.IconKey = "foldericon";
                inItem.Children.Add(currentitem);
                List<string> files = Directory.EnumerateFiles(folder).ToList();
                foreach (string file in files)
                {
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:Mesh");
                    currentitem.Name = Path.GetFileName(file);
                    MeshDocument meshdoc = new MeshDocument();
                    meshdoc.MeshName = Path.GetFileName(file);
                    currentitem.DataFile = meshdoc;
                    currentitem.IconKey = "genericfileicon";
                    inItem.Children[inItem.Children.Count - 1].Children.Add(currentitem);
                }
            }
            
        }

        public void PopulateImageSetTree(FilesTreeItem inItem)
        {
            FilesTreeItem currentitem;
            List<string> files = Directory.EnumerateFiles(EditorUserSettings.UserSettings.VD2Path + "Media\\gui\\imagesets").ToList();
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".imageset")
                {
                    currentitem = new FilesTreeItem();
                    currentitem.FilterTags.Add("FileType:ImageSet");
                    currentitem.Name = Path.GetFileNameWithoutExtension(file);
                    ImageSetDocument imagesetdoc = new ImageSetDocument();
                    imagesetdoc.ImageSetName = Path.GetFileNameWithoutExtension(file);
                    currentitem.DataFile = imagesetdoc;
                    currentitem.IconKey = "genericfileicon";
                    inItem.Children.Add(currentitem);
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

        private TreeNode GetFilesTreeNodeByPath(string inPath)
        {
            TreeNode result = null;
            List<string> splitpath = inPath.Split("\\".ToCharArray()).ToList();

            for (int splitidx = 0; splitidx < splitpath.Count; splitidx++)
            {
                if (result != null)
                {
                    for (int i = 0; i < result.Nodes.Count; i++)
                    {
                        if (result.Nodes[i].Text == splitpath[splitidx])
                        {
                            result = result.Nodes[i];
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < FilesTree.Nodes.Count; i++)
                    {
                        if (FilesTree.Nodes[i].Text == splitpath[splitidx])
                        {
                            result = FilesTree.Nodes[i];
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private void TreeContextMenu_Opened(object sender, EventArgs e)
        {
            for (int i = 0; i < TreeContextMenu.Items.Count; i++)
            {
                switch ((FilesTreeContextMenuItems)i)
                {
                    case FilesTreeContextMenuItems.Open:
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
                    case FilesTreeContextMenuItems.OpenNewTab:
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
                    case FilesTreeContextMenuItems.Save:
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
                    case FilesTreeContextMenuItems.Override:
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
                    case FilesTreeContextMenuItems.Duplicate:
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
                    case FilesTreeContextMenuItems.Delete:
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
                    case FilesTreeContextMenuItems.CopyObjectID://copy objectID
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
                    case FilesTreeContextMenuItems.OpenFileLocation://find refs
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
                                if (item.DataFile is VD2Data)
                                {                                    
                                    VD2Data df = (VD2Data)item.DataFile;
                                    EditorUI.ExploreFile(df.FilePath);
                                }                                
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
                                if (item.DataFile is VD2Data)
                                {
                                    VD2Data df = (VD2Data)item.DataFile;
                                    df.TrySaveData();
                                }
                                
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
            FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(FilesTree.SelectedNode.FullPath);
            if (item != null)
            {
                if (item.DataFile != null)
                {
                    OpenVD2Document(item.DataFile, true);
                }
            }
        }

        private void FilesTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (FilesTree.SelectedNode == e.Node)//if the node isnt already selected we have expanded a tree node and ended up on another item as a result
                    {
                        FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(e.Node.FullPath);
                        if (item != null)
                        {
                            if (item.DataFile != null)
                            {
                                OpenVD2Document(item.DataFile, true);
                            }
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

                    
                    if (inGoToNewTab)
                    {
                        documentTabControl1.TabPages.Insert(0, docpage);
                        documentTabControl1.SelectTab(docpage);
                    }
                    else 
                    {
                        documentTabControl1.TabPages.Add(docpage);
                    }
                    docview.Document = inDocument;
                }
                else
                {
                    if (inGoToNewTab)
                    {
                        SelectTabByDocument(inDocument);
                    }
                }
                if (StartupDocument != null)
                {
                    if (inDocument != StartupDocument)
                    {
                        if (IsDocumentAlreadyOpen(StartupDocument))
                        {
                            CloseOpenDocument(StartupDocument);
                        }
                    }
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

        public void CloseOpenDocument(IVD2DocumentInterface inDocument)
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
                                documentTabControl1.TabPages.Remove(page);
                                page.Dispose();
                            }
                        }
                    }
                }
            }
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

        private void openFileInNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(FilesTree.SelectedNode.FullPath);
            if (item != null)
            {
                if (item.DataFile != null)
                {
                    OpenVD2Document(item.DataFile, false);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OverrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(FilesTree.SelectedNode.FullPath);
            if (item != null)
            {
                if (item.DataFile != null)
                {
                    if (item.DataFile is VD2Data)
                    {
                        VD2Data dataitem = (VD2Data)item.DataFile;
                        if (dataitem.Source != null)
                        {
                            if (dataitem.Source.ShortName == "Base")//if this isn't in base files we don't even bother looking
                            {
                                List<string> splitpath = dataitem.FilePath.Split('\\').ToList();
                                for (int i = splitpath.Count - 1; i >= 0; i--)
                                {
                                    if (splitpath[i] == "Data")
                                    {
                                        splitpath.Insert(i, "Mod");
                                        break;
                                    }
                                }
                                string testpath = "";
                                //all but the last one, if theres only 1 element the next part will handle it, by adding the last one without slashes.
                                for (int i = 0; i < splitpath.Count - 1; i++)
                                {
                                    testpath += splitpath[i] + "\\";
                                }
                                if (splitpath.Count > 0)
                                {
                                    testpath += splitpath[splitpath.Count - 1];
                                }
                                if (!File.Exists(testpath))
                                {
                                    File.Copy(dataitem.FilePath, testpath);
                                    foreach (VD2FileSource source in EditorUserSettings.UserSettings.Sources)
                                    {
                                        if (source.ShortName == "Mod")
                                        {
                                            if (dataitem is ShipData)
                                            {
                                                ShipData overridefile = EditorUI.UI.Ships.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;                                                
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                currentitem.FilterTags.Add("FileType:Ship");
                                                currentitem.FilterTags.Add("Faction:" + overridefile.faction);
                                                currentitem.FilterTags.Add("Class:" + overridefile.shipClass);
                                                if (overridefile.shipClassSize != "")
                                                {
                                                    currentitem.FilterTags.Add("Size:" + overridefile.shipClassSize);
                                                }
                                                else
                                                {
                                                    currentitem.FilterTags.Add("Size:Tiny");
                                                }
                                                if (overridefile.sizeShipClass != "")
                                                {
                                                    currentitem.FilterTags.Add("Hull:" + overridefile.sizeShipClass);
                                                }
                                                else
                                                {
                                                    currentitem.FilterTags.Add("Hull:" + overridefile.shipClass);
                                                }
                                                if (overridefile.shipClass == "fighter")
                                                {
                                                    currentitem.IconKey = "fightericon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "fighter_drone")
                                                {
                                                    currentitem.IconKey = "droneicon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Drones");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Drones");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "gunship")
                                                {
                                                    currentitem.IconKey = "gunshipicon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "corvette")
                                                {
                                                    currentitem.IconKey = "corvetteicon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "frigate")
                                                {
                                                    currentitem.IconKey = "frigateicon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "destroyer")
                                                {
                                                    currentitem.IconKey = "destroyericon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "cruiser")
                                                {
                                                    currentitem.IconKey = "cruisericon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "carrier")
                                                {
                                                    currentitem.IconKey = "carriericon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "dreadnaught")
                                                {
                                                    currentitem.IconKey = "dreadnaughticon";
                                                    if (overridefile.shipClassSize == "light")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Light");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Light");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "medium")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Medium");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Medium");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                    else if (overridefile.shipClassSize == "heavy")
                                                    {
                                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Heavy");
                                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Heavy");
                                                        categoryitem.Children.Add(currentitem);
                                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                        dataitem.NotifyFileOverriden(overridefile);
                                                    }
                                                }
                                                else if (overridefile.shipClass == "transport")
                                                {
                                                    currentitem.IconKey = "transporticon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Transport");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Transport");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "mining")
                                                {
                                                    currentitem.IconKey = "minericon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Miner");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Miner");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "shuttle")
                                                {
                                                    currentitem.IconKey = "shuttleicon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Shuttle");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Shuttle");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "repair")
                                                {
                                                    currentitem.IconKey = "repairicon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Repair");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Repair");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "capture")
                                                {
                                                    currentitem.IconKey = "basecaptureicon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Base Capture");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Base Capture");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "ship_capture")
                                                {
                                                    currentitem.IconKey = "shipcaptureicon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Ship Capture");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Ship Capture");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.shipClass == "builder")
                                                {
                                                    currentitem.IconKey = "buildericon";
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Builder");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Builder");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }

                                            }
                                            else if (dataitem is PrimaryUpgradeData)
                                            {                                                
                                                PrimaryUpgradeData overridefile = EditorUI.UI.PrimaryUpgrades.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:PrimaryUpgrade");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                if (overridefile.bPersistsOnShipChange)
                                                {
                                                    currentitem.FilterTags.Add("UpgradeType:PersistentUpgrade");
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Persistent");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Persistent");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else if (overridefile.upgradeType == "other")
                                                {
                                                    currentitem.FilterTags.Add("UpgradeType:OtherUpgrade");
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Other");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Other");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                else
                                                {
                                                    currentitem.FilterTags.Add("UpgradeType:Primary");
                                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Primary");
                                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Primary");
                                                    categoryitem.Children.Add(currentitem);
                                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                    dataitem.NotifyFileOverriden(overridefile);
                                                }
                                                
                                            }
                                            else if (dataitem is ActiveUpgradeData)
                                            {
                                                ActiveUpgradeData overridefile = EditorUI.UI.ActiveUpgrades.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:ActiveUpgrade");
                                                currentitem.FilterTags.Add("UpgradeType:Active");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Active");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Active");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is WeaponData)
                                            {
                                                WeaponData overridefile = EditorUI.UI.Weapons.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Weapon");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Weapons");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Weapons");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is HangarData)
                                            {
                                                HangarData overridefile = EditorUI.UI.Hangars.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Hangar");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Hangars");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Hangars");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is LauncherData)
                                            {
                                                LauncherData overridefile = EditorUI.UI.Launchers.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Launcher");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Launchers");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Launchers");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is TurretData)
                                            {
                                                TurretData overridefile = EditorUI.UI.Turrets.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Turret");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Turrets");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Turrets");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is AmmoData)
                                            {
                                                AmmoData overridefile = EditorUI.UI.Ammo.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Ammo");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ammo");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ammo");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is MissileData)
                                            {
                                                MissileData overridefile = EditorUI.UI.Missiles.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Missile");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Missiles");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Missiles");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is MineData)
                                            {
                                                MineData overridefile = EditorUI.UI.Mines.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Mine");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Mines");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Mines");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is AreaOfEffectData)
                                            {
                                                AreaOfEffectData overridefile = EditorUI.UI.AreaOfEffect.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:AreaOfEffect");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\AreaOfEffect");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\AreaOfEffect");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is AsteroidData)
                                            {
                                                AsteroidData overridefile = EditorUI.UI.Asteroids.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Asteroid");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Asteroids");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Asteroids");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is BaseData)
                                            {
                                                BaseData overridefile = EditorUI.UI.Bases.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Base");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Bases");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Bases");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is CharacterData)
                                            {
                                                CharacterData overridefile = EditorUI.UI.Characters.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Character");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Characters");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Characters");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is CockpitData)
                                            {
                                                CockpitData overridefile = EditorUI.UI.Cockpits.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Cockpit");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Cockpits");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Cockpits");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is DebrisData)
                                            {
                                                DebrisData overridefile = EditorUI.UI.Debris.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Debris");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Debris");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Debris");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is DialogData)
                                            {
                                                DialogData overridefile = EditorUI.UI.Dialog.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Dialog");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Dialog");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Dialog");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is DockedMovingElementData)
                                            {
                                                DockedMovingElementData overridefile = EditorUI.UI.DockedMovingElements.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:DockedMovingElement");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\DockedMovingElements");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\DockedMovingElements");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is DoorData)
                                            {
                                                DoorData overridefile = EditorUI.UI.Doors.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Door");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Doors");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Doors");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is EffectData)
                                            {
                                                EffectData overridefile = EditorUI.UI.Effects.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Effect");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Effects\\Effects");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Effects\\Effects");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is ParticleData)
                                            {
                                                ParticleData overridefile = EditorUI.UI.Particles.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Particle");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Effects\\Particles");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Effects\\Particles");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is ExplosionData)
                                            {
                                                ExplosionData overridefile = EditorUI.UI.Explosions.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Explosion");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Explosions");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Explosions");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is FactionData)
                                            {
                                                FactionData overridefile = EditorUI.UI.Factions.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Faction");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Factions");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Factions");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is MusicData)
                                            {
                                                MusicData overridefile = EditorUI.UI.Music.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Music");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Music");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Music");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is OtherObjectData)
                                            {
                                                OtherObjectData overridefile = EditorUI.UI.OtherObjects.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Other");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Other");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Other");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is ShieldData)
                                            {
                                                ShieldData overridefile = EditorUI.UI.Shields.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Shield");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Shields");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Shields");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is SkyboxData)
                                            {
                                                SkyboxData overridefile = EditorUI.UI.Skyboxes.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Skybox");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Skyboxes");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Skyboxes");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is SoundData)
                                            {
                                                SoundData overridefile = EditorUI.UI.Sounds.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Sound");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Sounds");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Sounds");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is StationData)
                                            {
                                                StationData overridefile = EditorUI.UI.Stations.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Station");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Stations");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Stations");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }
                                            else if (dataitem is SunData)
                                            {
                                                SunData overridefile = EditorUI.UI.Suns.LoadSingleFileFromAbsolutePath(testpath, source);
                                                FilesTreeItem currentitem = new FilesTreeItem();
                                                currentitem.DataFile = overridefile;
                                                currentitem.FilterTags.Add("FileType:Sun");
                                                currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                                FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Suns");
                                                TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Suns");
                                                categoryitem.Children.Add(currentitem);
                                                TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                                addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                                dataitem.NotifyFileOverriden(overridefile);
                                            }                                            
                                        }
                                    }
                                }
                                else
                                {
                                    ErrorMessageDialog errormsg = new ErrorMessageDialog();
                                    errormsg.ErrorTitleText = "File already exists!";
                                    errormsg.ErrorMessageText = "The file " + testpath + "already exists, no override created.";
                                    errormsg.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void createDuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesTreeItem item = EditorUI.UI.EditorForm.GetFilesTreeItemByPath(FilesTree.SelectedNode.FullPath);
            if (item != null)
            {
                if (item.DataFile != null)
                {
                    if (item.DataFile is VD2Data)
                    {
                        VD2Data dataitem = (VD2Data)item.DataFile;
                        
                        if (dataitem.Source != null)
                        {
                            if (!dataitem.Source.WriteAccess)
                            {
                                ErrorMessageDialog errordialog = new ErrorMessageDialog();
                                errordialog.ErrorTitleText = "Trying to duplicate in read only source";
                                errordialog.ErrorMessageText = "You may not duplicate a file in a read only source, set write access on for this source (" + dataitem.Source.ShortName + ") if you wish to duplicate the file. Otherwise, try override in mod files command.";
                                errordialog.ShowDialog();
                                return;
                            }
                            DuplicateFileDialog duplicatefiledialog = new DuplicateFileDialog();
                            duplicatefiledialog.DestinationFolderPath = Path.GetDirectoryName(dataitem.FilePath);
                            duplicatefiledialog.FileName = Path.GetFileNameWithoutExtension(dataitem.FilePath);
                            if (dataitem is ShipData)
                            {
                                duplicatefiledialog.FileType = "ShipData";
                            }
                            else if (dataitem is PrimaryUpgradeData)
                            {
                                duplicatefiledialog.FileType = "PrimaryUpgradeData";
                            }
                            else if (dataitem is ActiveUpgradeData)
                            {
                                duplicatefiledialog.FileType = "ActiveUpgradeData";
                            }
                            else if (dataitem is WeaponData)
                            {
                                duplicatefiledialog.FileType = "WeaponData";
                            }
                            else if (dataitem is HangarData)
                            {
                                duplicatefiledialog.FileType = "HangarData";
                            }
                            else if (dataitem is LauncherData)
                            {
                                duplicatefiledialog.FileType = "LauncherData";
                            }
                            else if (dataitem is TurretData)
                            {
                                duplicatefiledialog.FileType = "TurretData";
                            }
                            else if (dataitem is AmmoData)
                            {
                                duplicatefiledialog.FileType = "AmmoData";
                            }
                            else if (dataitem is MissileData)
                            {
                                duplicatefiledialog.FileType = "MissileData";
                            }
                            else if (dataitem is MineData)
                            {
                                duplicatefiledialog.FileType = "MineData";
                            }
                            else if (dataitem is AreaOfEffectData)
                            {
                                duplicatefiledialog.FileType = "AreaOfEffectData";
                            }
                            else if (dataitem is AsteroidData)
                            {
                                duplicatefiledialog.FileType = "AsteroidData";
                            }
                            else if (dataitem is BaseData)
                            {
                                duplicatefiledialog.FileType = "BaseData";
                            }
                            else if (dataitem is CharacterData)
                            {
                                duplicatefiledialog.FileType = "CharacterData";
                            }
                            else if (dataitem is CockpitData)
                            {
                                duplicatefiledialog.FileType = "CockpitData";
                            }
                            else if (dataitem is DebrisData)
                            {
                                duplicatefiledialog.FileType = "DebrisData";
                            }
                            else if (dataitem is DialogData)
                            {
                                duplicatefiledialog.FileType = "DialogData";
                            }
                            else if (dataitem is DockedMovingElementData)
                            {
                                duplicatefiledialog.FileType = "DockedMovingElementData";
                            }
                            else if (dataitem is DoorData)
                            {
                                duplicatefiledialog.FileType = "DoorData";
                            }
                            else if (dataitem is EffectData)
                            {
                                duplicatefiledialog.FileType = "EffectData";
                            }
                            else if (dataitem is ParticleData)
                            {
                                duplicatefiledialog.FileType = "ParticleData";
                            }
                            else if (dataitem is ExplosionData)
                            {
                                duplicatefiledialog.FileType = "ExplosionData";
                            }
                            else if (dataitem is FactionData)
                            {
                                duplicatefiledialog.FileType = "FactionData";
                            }
                            else if (dataitem is MusicData)
                            {
                                duplicatefiledialog.FileType = "MusicData";
                            }
                            else if (dataitem is OtherObjectData)
                            {
                                duplicatefiledialog.FileType = "OtherObjectData";
                            }
                            else if (dataitem is ShieldData)
                            {
                                duplicatefiledialog.FileType = "ShieldData";
                            }
                            else if (dataitem is SkyboxData)
                            {
                                duplicatefiledialog.FileType = "SkyboxData";
                            }
                            else if (dataitem is SoundData)
                            {
                                duplicatefiledialog.FileType = "SoundData";
                            }
                            else if (dataitem is StationData)
                            {
                                duplicatefiledialog.FileType = "StationData";
                            }
                            else if (dataitem is SunData)
                            {
                                duplicatefiledialog.FileType = "SunData";
                            }
                            duplicatefiledialog.ObjectID = dataitem.GetObjectID();
                            DialogResult result = duplicatefiledialog.ShowDialog();
                            if (result == DialogResult.Cancel)
                            { 
                                return;
                            }
                            string testpath = duplicatefiledialog.DestinationFolderPath + "\\" + duplicatefiledialog.FileName + ".xml";
                            if (!File.Exists(testpath))
                            {
                                File.Copy(dataitem.FilePath, testpath);
                                if (dataitem is ShipData)
                                {
                                    ShipData overridefile = EditorUI.UI.Ships.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    currentitem.FilterTags.Add("FileType:Ship");
                                    currentitem.FilterTags.Add("Faction:" + overridefile.faction);
                                    currentitem.FilterTags.Add("Class:" + overridefile.shipClass);
                                    if (overridefile.shipClassSize != "")
                                    {
                                        currentitem.FilterTags.Add("Size:" + overridefile.shipClassSize);
                                    }
                                    else
                                    {
                                        currentitem.FilterTags.Add("Size:Tiny");
                                    }
                                    if (overridefile.sizeShipClass != "")
                                    {
                                        currentitem.FilterTags.Add("Hull:" + overridefile.sizeShipClass);
                                    }
                                    else
                                    {
                                        currentitem.FilterTags.Add("Hull:" + overridefile.shipClass);
                                    }
                                    if (overridefile.shipClass == "fighter")
                                    {
                                        currentitem.IconKey = "fightericon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Fighters\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Fighters\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "fighter_drone")
                                    {
                                        currentitem.IconKey = "droneicon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Drones");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Drones");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "gunship")
                                    {
                                        currentitem.IconKey = "gunshipicon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\GunShips\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\GunShips\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "corvette")
                                    {
                                        currentitem.IconKey = "corvetteicon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Corvettes\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Corvettes\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "frigate")
                                    {
                                        currentitem.IconKey = "frigateicon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Frigates\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Frigates\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "destroyer")
                                    {
                                        currentitem.IconKey = "destroyericon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Destroyers\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Destroyers\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "cruiser")
                                    {
                                        currentitem.IconKey = "cruisericon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Cruisers\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Cruisers\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "carrier")
                                    {
                                        currentitem.IconKey = "carriericon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Carriers\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Carriers\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "dreadnaught")
                                    {
                                        currentitem.IconKey = "dreadnaughticon";
                                        if (overridefile.shipClassSize == "light")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Light");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Light");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "medium")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Medium");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Medium");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                        else if (overridefile.shipClassSize == "heavy")
                                        {
                                            FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Combat\\Dreadnaughts\\Heavy");
                                            TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Combat\\Dreadnaughts\\Heavy");
                                            categoryitem.Children.Add(currentitem);
                                            TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                            addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                            dataitem.NotifyFileOverriden(overridefile);
                                        }
                                    }
                                    else if (overridefile.shipClass == "transport")
                                    {
                                        currentitem.IconKey = "transporticon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Transport");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Transport");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "mining")
                                    {
                                        currentitem.IconKey = "minericon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Miner");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Miner");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "shuttle")
                                    {
                                        currentitem.IconKey = "shuttleicon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Shuttle");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Shuttle");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "repair")
                                    {
                                        currentitem.IconKey = "repairicon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Repair");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Repair");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "capture")
                                    {
                                        currentitem.IconKey = "basecaptureicon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Base Capture");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Base Capture");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "ship_capture")
                                    {
                                        currentitem.IconKey = "shipcaptureicon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Ship Capture");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Ship Capture");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.shipClass == "builder")
                                    {
                                        currentitem.IconKey = "buildericon";
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ships\\Non Combat\\Builder");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ships\\Non Combat\\Builder");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }

                                }
                                else if (dataitem is PrimaryUpgradeData)
                                {
                                    PrimaryUpgradeData overridefile = EditorUI.UI.PrimaryUpgrades.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:PrimaryUpgrade");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    if (overridefile.bPersistsOnShipChange)
                                    {
                                        currentitem.FilterTags.Add("UpgradeType:PersistentUpgrade");
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Persistent");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Persistent");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else if (overridefile.upgradeType == "other")
                                    {
                                        currentitem.FilterTags.Add("UpgradeType:OtherUpgrade");
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Other");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Other");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }
                                    else
                                    {
                                        currentitem.FilterTags.Add("UpgradeType:Primary");
                                        FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Primary");
                                        TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Primary");
                                        categoryitem.Children.Add(currentitem);
                                        TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                        addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                        dataitem.NotifyFileOverriden(overridefile);
                                    }

                                }
                                else if (dataitem is ActiveUpgradeData)
                                {
                                    ActiveUpgradeData overridefile = EditorUI.UI.ActiveUpgrades.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:ActiveUpgrade");
                                    currentitem.FilterTags.Add("UpgradeType:Active");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Upgrades\\Active");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Upgrades\\Active");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is WeaponData)
                                {
                                    WeaponData overridefile = EditorUI.UI.Weapons.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.weaponID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Weapon");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Weapons");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Weapons");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is HangarData)
                                {
                                    HangarData overridefile = EditorUI.UI.Hangars.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.hangarID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Hangar");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Hangars");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Hangars");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is LauncherData)
                                {
                                    LauncherData overridefile = EditorUI.UI.Launchers.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.weaponID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Launcher");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Launchers");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Launchers");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is TurretData)
                                {
                                    TurretData overridefile = EditorUI.UI.Turrets.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.weaponID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Turret");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Turrets");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Turrets");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is AmmoData)
                                {
                                    AmmoData overridefile = EditorUI.UI.Ammo.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.projectileID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Ammo");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Ammo");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Ammo");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is MissileData)
                                {
                                    MissileData overridefile = EditorUI.UI.Missiles.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Missile");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Missiles");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Missiles");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is MineData)
                                {
                                    MineData overridefile = EditorUI.UI.Mines.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Mine");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Mines");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Mines");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is AreaOfEffectData)
                                {
                                    AreaOfEffectData overridefile = EditorUI.UI.AreaOfEffect.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:AreaOfEffect");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\AreaOfEffect");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\AreaOfEffect");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is AsteroidData)
                                {
                                    AsteroidData overridefile = EditorUI.UI.Asteroids.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Asteroid");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Asteroids");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Asteroids");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is BaseData)
                                {
                                    BaseData overridefile = EditorUI.UI.Bases.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Base");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Bases");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Bases");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is CharacterData)
                                {
                                    CharacterData overridefile = EditorUI.UI.Characters.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.characterID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Character");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Characters");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Characters");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is CockpitData)
                                {
                                    CockpitData overridefile = EditorUI.UI.Cockpits.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Cockpit");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Cockpits");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Cockpits");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is DebrisData)
                                {
                                    DebrisData overridefile = EditorUI.UI.Debris.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Debris");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Debris");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Debris");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is DialogData)
                                {
                                    DialogData overridefile = EditorUI.UI.Dialog.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.dialogID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Dialog");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Dialog");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Dialog");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is DockedMovingElementData)
                                {
                                    DockedMovingElementData overridefile = EditorUI.UI.DockedMovingElements.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:DockedMovingElement");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\DockedMovingElements");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\DockedMovingElements");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is DoorData)
                                {
                                    DoorData overridefile = EditorUI.UI.Doors.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Door");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Doors");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Doors");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is EffectData)
                                {
                                    EffectData overridefile = EditorUI.UI.Effects.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Effect");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Effects\\Effects");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Effects\\Effects");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is ParticleData)
                                {
                                    ParticleData overridefile = EditorUI.UI.Particles.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Particle");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Effects\\Particles");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Effects\\Particles");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is ExplosionData)
                                {
                                    ExplosionData overridefile = EditorUI.UI.Explosions.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Explosion");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Explosions");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Explosions");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is FactionData)
                                {
                                    FactionData overridefile = EditorUI.UI.Factions.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.factionID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Faction");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Factions");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Factions");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is MusicData)
                                {
                                    MusicData overridefile = EditorUI.UI.Music.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Music");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Music");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Music");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is OtherObjectData)
                                {
                                    OtherObjectData overridefile = EditorUI.UI.OtherObjects.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Other");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Other");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Other");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is ShieldData)
                                {
                                    ShieldData overridefile = EditorUI.UI.Shields.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.shieldID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Shield");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Shields");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Shields");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is SkyboxData)
                                {
                                    SkyboxData overridefile = EditorUI.UI.Skyboxes.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Skybox");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Skyboxes");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Skyboxes");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is SoundData)
                                {
                                    SoundData overridefile = EditorUI.UI.Sounds.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Sound");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Sounds");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Sounds");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is StationData)
                                {
                                    StationData overridefile = EditorUI.UI.Stations.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Station");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Stations");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Stations");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                                else if (dataitem is SunData)
                                {
                                    SunData overridefile = EditorUI.UI.Suns.LoadSingleFileFromAbsolutePath(testpath, dataitem.Source);
                                    overridefile.objectID = duplicatefiledialog.ObjectID;
                                    overridefile.TrySaveData();
                                    FilesTreeItem currentitem = new FilesTreeItem();
                                    currentitem.DataFile = overridefile;
                                    currentitem.FilterTags.Add("FileType:Sun");
                                    currentitem.Name = Path.GetFileNameWithoutExtension(overridefile.FilePath);
                                    FilesTreeItem categoryitem = GetFilesTreeItemByPath("Data\\Suns");
                                    TreeNode categorynode = GetFilesTreeNodeByPath("Data\\Suns");
                                    categoryitem.Children.Add(currentitem);
                                    TreeNode addednode = categorynode.Nodes.Add(currentitem.Name, currentitem.DisplayName, currentitem.IconKey);
                                    addednode.ContextMenuStrip = categorynode.ContextMenuStrip;
                                    dataitem.NotifyFileOverriden(overridefile);
                                }
                            }
                            else
                            {
                                ErrorMessageDialog errormsg = new ErrorMessageDialog();
                                errormsg.ErrorTitleText = "File already exists!";
                                errormsg.ErrorMessageText = "The file " + testpath + "already exists, no duplicate created.";
                                errormsg.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (documentTabControl1.SelectedTab != null)
            {
                foreach (Control c in documentTabControl1.SelectedTab.Controls)
                {
                    if (c is VD2DocumentViewer)
                    {
                        VD2DocumentViewer docview = (VD2DocumentViewer)c;
                        if (docview.Document != null)
                        {
                            if (docview.Document is VD2Data)
                            {
                                VD2Data datafile = (VD2Data)docview.Document;
                                datafile.TrySaveData();
                            }
                        }
                    }
                }
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
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
                            if (docview.Document is VD2Data)
                            {
                                VD2Data datafile = (VD2Data)docview.Document;
                                datafile.TrySaveData();
                            }
                        }
                    }
                }
            }
        }

        private void SaveToolstripButton_Click(object sender, EventArgs e)
        {
            if (documentTabControl1.SelectedTab != null)
            {
                foreach (Control c in documentTabControl1.SelectedTab.Controls)
                {
                    if (c is VD2DocumentViewer)
                    {
                        VD2DocumentViewer docview = (VD2DocumentViewer)c;
                        if (docview.Document != null)
                        {
                            if (docview.Document is VD2Data)
                            {
                                VD2Data datafile = (VD2Data)docview.Document;
                                datafile.TrySaveData();
                            }
                        }
                    }
                }
            }
        }

        public void SaveAllOpenDocuments()
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
                            if (docview.Document is VD2Data)
                            {
                                VD2Data datafile = (VD2Data)docview.Document;
                                datafile.TrySaveData();
                            }
                        }
                    }
                }
            }
        }

        private void SaveAllToolstripButton_Click(object sender, EventArgs e)
        {
            SaveAllOpenDocuments();
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

    enum FilesTreeContextMenuItems
    {
        New,
        Open,
        OpenNewTab,
        Save,
        Override,
        Duplicate,        
        Delete,
        SeparatorOne,
        CopyObjectID,
        OpenFileLocation
    }

    public class FilesTreeItem
    {
        public string Name;
        //public string Source;
        public string IconKey;
        public bool Saved;
        public IVD2DocumentInterface _DataFile;
        public List<string> FilterTags;
        public List<FilesTreeItem> Children;
        public TreeNode FilesTreeNode;

        public IVD2DocumentInterface DataFile
        {
            get
            {
                return _DataFile;
            }
            set
            {
                if (_DataFile != null)
                {
                    if (_DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)_DataFile;
                        df.VD2PropertyChanged -= OnMyFileEdited;
                    }
                }
                _DataFile = value;
                if (_DataFile != null)
                {
                    if (_DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)_DataFile;
                        df.VD2PropertyChanged += OnMyFileEdited;
                        /*if (df.Source != null)
                        {
                            df.Source.OnWriteAccessChanged += OnFileSourceWriteAccessChanged;
                        }*/
                    }
                    
                }
            }
        }

        private void OnFileSourceWriteAccessChanged(object sender, EventArgs e)
        {
            if (FilesTreeNode != null)
            {
                FilesTreeNode.Text = DisplayName;
            }
        }

        private void OnMyFileEdited(object sender, VD2PropertyChangedEventArgs e)
        {
            if (FilesTreeNode != null)
            {
                FilesTreeNode.Text = DisplayName;
            }
        }

        public string ObjectID
        {
            get
            {
                if (DataFile != null)
                {
                    if (DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)DataFile;
                        return df.GetObjectID();
                    }
                    
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
                    if (DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)DataFile;

                        if (df.Source != null)
                        {
                            if (!df.Source.FilterIn)
                            {
                                return true;
                            }
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
                    if (DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)DataFile;
                        if (df.Source != null)
                        {
                            sourcestring = df.Source.ShortName;
                            if (df.Source.WriteAccess)
                            {
                                rwstring = "[RW]";
                            }
                            else
                            {
                                rwstring = "[R]";
                            }
                        }
                    }
                }

                return "(" + sourcestring + rwstring + ") " + savestring + Name;
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
                    if (DataFile is VD2Data)
                    {
                        VD2Data df = (VD2Data)DataFile;
                        return df.Unsaved;
                    }
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
