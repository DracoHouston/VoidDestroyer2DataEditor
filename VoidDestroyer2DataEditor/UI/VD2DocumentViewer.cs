using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class VD2DocumentViewer : UserControl
    {
        private IVD2DocumentInterface _Document;
        public IVD2DocumentInterface Document
        {
            get
            {
                return _Document;
            }
            set
            {
                _Document = value;
                if (_Document != null)
                {
                    /*if (VD2DataViewer != null)
                    {
                        VD2DataViewer.SelectedObject = _Document;
                        if (_Document is VD2Data)
                        {
                            VD2Data datadoc = (VD2Data)_Document;
                            datadoc.VD2PropertyChanged += OnMyFileEdited;
                            SetTabPageTitle(datadoc);
                            SetTabPageIcon(datadoc);
                        }
                    }
                    else
                    {
                        SetupDataViewer();
                        
                        VD2DataViewer.SelectedObject = _Document;
                        
                        if (_Document is VD2Data)
                        {
                            VD2Data datadoc = (VD2Data)_Document;
                            datadoc.VD2PropertyChanged += OnMyFileEdited;
                            SetTabPageTitle(datadoc);
                            SetTabPageIcon(datadoc);
                        }
                    }*/
                    /*if (_Document is IVD2DocumentInterface)
                    {

                    }*/
                    Control doccontrol = _Document.GetDocumentControl();
                    Controls.Add(doccontrol);
                    
                    SetTabPageTitle(_Document.GetDocumentTitle());
                    SetTabPageIcon(_Document.GetDocumentIconKey());
                    if (_Document is VD2Data)
                    {
                        VD2Data datadoc = (VD2Data)_Document;
                        datadoc.VD2PropertyChanged += OnMyFileEdited;
                        datadoc.OnThisFileSaved += OnMyFileSaved;
                    }
                        //doccontrol.Dock = DockStyle.Fill;
                        /*      }
                          else
                          {
                              if (VD2DataViewer != null)
                              {
                                  Controls.Remove(VD2DataViewer);
                                  VD2DataViewer.Dispose();
                              }*/
                }
            }
        }

        private void SetupDataViewer()
        {
            VD2DataViewer = new PropertyGrid();
            Controls.Add(VD2DataViewer);
            VD2DataViewer.Dock = DockStyle.Fill;
            VD2DataViewer.BackColor = EditorUserSettings.UserSettings.CurrentTheme.FrameColor;
            VD2DataViewer.LineColor = EditorUserSettings.UserSettings.CurrentTheme.SecondaryFrameColor;
            VD2DataViewer.HelpBackColor = EditorUserSettings.UserSettings.CurrentTheme.SecondaryFrameColor;
            VD2DataViewer.ViewForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            VD2DataViewer.HelpForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            VD2DataViewer.CategoryForeColor = EditorUserSettings.UserSettings.CurrentTheme.TextColor;
            VD2DataViewer.ViewBackColor = EditorUserSettings.UserSettings.CurrentTheme.ContentColor;
        }

        private void OnMyFileEdited(object sender, VD2PropertyChangedEventArgs e)
        {
            if (_Document is VD2Data)
            {
                //VD2Data datadoc = (VD2Data)_Document;
                SetTabPageTitle(_Document.GetDocumentTitle());
            }
        }

        private void OnMyFileSaved(object sender, EventArgs e)
        {
            if (_Document is VD2Data)
            {
                //VD2Data datadoc = (VD2Data)_Document;
                SetTabPageTitle(_Document.GetDocumentTitle());
            }
        }

        private void SetTabPageTitle(string inTitle)
        {
            if (Parent is TabPage)
            {
                TabPage parentpage = (TabPage)Parent;
                parentpage.Text = inTitle;
                if (parentpage.Parent is DocumentTabControl)
                {
                    DocumentTabControl grandparenttabcontrol = (DocumentTabControl)parentpage.Parent;
                    grandparenttabcontrol.Repos();
                }
            }
        }

        /*private void SetTabPageTitle(VD2Data inDataDoc)
        {
            if (inDataDoc != null)
            {
                string savestring = "";
                if (inDataDoc.Unsaved)
                {
                    savestring = "*";
                }

                string rwstring = "";
                string sourcestring = "";

                if (inDataDoc.Source != null)
                {
                    sourcestring = inDataDoc.Source.ShortName;
                    if (inDataDoc.Source.WriteAccess)
                    {
                        rwstring = "[RW]";
                    }
                    else
                    {
                        rwstring = "[R]";
                    }
                }
                string filename = System.IO.Path.GetFileNameWithoutExtension(inDataDoc.FilePath);
                SetTabPageTitle("(" + sourcestring + rwstring + ") " + savestring + filename + "     ");
            }
        }*/

        void SetTabPageIcon(string inKey)
        {
            if (Parent is TabPage)
            {
                TabPage parentpage = (TabPage)Parent;
                parentpage.ImageKey = inKey;
                if (parentpage.Parent is DocumentTabControl)
                {
                    DocumentTabControl grandparenttabcontrol = (DocumentTabControl)parentpage.Parent;
                    grandparenttabcontrol.Repos();
                }
            }
        }
        /*
        void SetTabPageIcon(VD2Data inDataDoc)
        {
            if (inDataDoc != null)
            {
                if (inDataDoc is ShipData)
                {
                    ShipData shipdoc = (ShipData)inDataDoc;
                    switch (shipdoc.shipClass)
                    {
                        case "fighter_drone":
                            SetTabPageIcon("droneicon");
                            break;
                        case "fighter":
                            SetTabPageIcon("fightericon");
                            break;
                        case "gunship":
                            SetTabPageIcon("gunshipicon");
                            break;
                        case "corvette":
                            SetTabPageIcon("corvetteicon");
                            break;
                        case "frigate":
                            SetTabPageIcon("frigateicon");
                            break;
                        case "destroyer":
                            SetTabPageIcon("destroyericon");
                            break;
                        case "cruiser":
                            SetTabPageIcon("cruisericon");
                            break;
                        case "carrier":
                            SetTabPageIcon("carriericon");
                            break;
                        case "dreadnaught":
                            SetTabPageIcon("dreadnaughticon");
                            break;
                        case "transport":
                            SetTabPageIcon("transporticon");
                            break;
                        case "mining":
                            SetTabPageIcon("minericon");
                            break;
                        case "shuttle":
                            SetTabPageIcon("shuttleicon");
                            break;
                        case "repair":
                            SetTabPageIcon("repairicon");
                            break;
                        case "ship_capture":
                            SetTabPageIcon("shipcaptureicon");
                            break;
                        case "capture":
                            SetTabPageIcon("basecaptureicon");
                            break;
                        case "builder":
                            SetTabPageIcon("buildericon");
                            break;
                        default:
                            SetTabPageIcon("genericfileicon");
                            break;
                    }
                }
                else 
                {
                    SetTabPageIcon("genericfileicon");
                }
            }
        }*/

        PropertyGrid VD2DataViewer;

        public VD2DocumentViewer()
        {
            //VD2DataViewer = null;
            // = null;

            InitializeComponent();
        }

        public VD2DocumentViewer(VD2Data inDataFile)
        {                      
            InitializeComponent();
            //VD2DataViewer = null;

            Document = inDataFile;
        }
    }
}
