using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace VoidDestroyer2DataEditor
{
    public class VD2FileSource
    {
        public event EventHandler OnWriteAccessChanged;

        public string _DisplayName;
        public string _ShortName;
        public string _Path;
        public bool _WriteAccess;
        public bool _FilterIn;

        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }
        public string ShortName
        {
            get
            {
                return _ShortName;
            }
            set
            {
                _ShortName = value;
            }
        }
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }
        public bool WriteAccess
        {
            get
            {
                return _WriteAccess;
            }
            set
            {
                _WriteAccess = value;
                OnWriteAccessChanged?.Invoke(this, new EventArgs());
            }
        }
        public bool FilterIn
        {
            get
            {
                return _FilterIn;
            }
            set
            {
                _FilterIn = value;
            }
        }

        public VD2FileSource()
        {
            _DisplayName = "";
            _ShortName = "";
            _Path = "";
            _WriteAccess = true;
            _FilterIn = true;
        }

        public VD2FileSource(string inDisplayName, string inShortName, string inPath, bool inWriteAccess, bool inFilterIn)
        {
            _DisplayName = inDisplayName;
            _ShortName = inShortName;
            _Path = inPath;
            _WriteAccess = inWriteAccess;
            _FilterIn = inFilterIn;
        }
    }

    public class DataEditorTheme
    {
        public Color ContentColor;
        public Color FrameColor;
        public Color TextColor;
        public Color SecondaryFrameColor;
        public Color ButtonColor;
        public Color ButtonHoverColor;
        public Color ButtonDownColor;
        public string ThemeName;
    }

    public class EditorUserSettings
    {
        private static EditorUserSettings Instance = null;

        public string VD2Path;
        public int TreeIconSize;
        public List<VD2FileSource> Sources;
        public DataEditorTheme CurrentTheme;
        public List<DataEditorTheme> Themes;

        public static EditorUserSettings UserSettings
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new EditorUserSettings();
                }
                return Instance;
            }
        }
        private EditorUserSettings()
        {
            VD2Path = "";
            TreeIconSize = 16;
            Sources = new List<VD2FileSource>();
            Themes = new List<DataEditorTheme>();
        }

        public void SaveSettings()
        {
            List<string> configlines = new List<string>();
            configlines.Add("VD2Path|" + VD2Path);
            configlines.Add("TreeIconSize|" + TreeIconSize.ToString());
            File.WriteAllLines("EditorUserSettings.cfg", configlines);            
        }

        public bool InitUserSettings()
        {
            Sources.Clear();
            VD2FileSource currentsource = new VD2FileSource("Base Game", "Base", "", false, true);
            Sources.Add(currentsource);
            currentsource = new VD2FileSource("Mod Game", "Mod", "Mod\\", true, true);
            Sources.Add(currentsource);
            DataEditorTheme theme = new DataEditorTheme();

            theme.ThemeName = "DefaultDark";
            theme.ContentColor = Color.FromArgb(15, 15, 15);
            theme.FrameColor = Color.FromArgb(90, 90, 90);
            theme.TextColor = Color.White;
            theme.SecondaryFrameColor = Color.FromArgb(45, 45, 45);
            theme.ButtonColor = Color.FromArgb(120, 120, 120);
            theme.ButtonHoverColor = Color.FromArgb(64, 64, 64);
            theme.ButtonDownColor = Color.Silver;
            Themes.Add(theme);
            CurrentTheme = theme;
            bool configfoundandvalid = false;
            if (File.Exists("EditorUserSettings.cfg"))
            {
                List<string> configlines = File.ReadAllLines("EditorUserSettings.cfg").ToList();
                if (configlines.Count >0)
                {
                    for (int i = 0; i < configlines.Count; i++)
                    {
                        List<string> currentlinesplit = configlines[i].Split('|').ToList();
                        if (currentlinesplit.Count == 2)
                        {
                            if (currentlinesplit[0] == "VD2Path")
                            {
                                if (File.Exists(currentlinesplit[1] + "/Void Destroyer 2.exe"))
                                {
                                    VD2Path = currentlinesplit[1];
                                    configfoundandvalid = true;
                                }

                            }
                            else if (currentlinesplit[0] == "TreeIconSize")
                            {
                                int treeiconsizeresult;

                                if (int.TryParse(currentlinesplit[1], out treeiconsizeresult))
                                {
                                    if (treeiconsizeresult == 16)
                                    {
                                        TreeIconSize = 16;
                                    }
                                    else if (treeiconsizeresult == 32)
                                    {
                                        TreeIconSize = 32;
                                    }
                                    else
                                    {
                                        TreeIconSize = 16;
                                    }
                                    //unlike vd2path, we gracefully default to 16 here if the value isn't in the file. 
                                    //next time it saves the proper value will be set in the right format, no biggie.
                                }

                            }
                        }
                    }
                }

            }
            if (!configfoundandvalid)
            {
                /*string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
                if (Directory.Exists(SteamPath + "\\steamapps\\common\\Void Destroyer 2"))
                {
                    VD2Path = SteamPath + "\\steamapps\\common\\Void Destroyer 2";
                }
                else
                {
                    DialogResult folderdialogresult = EditorUI.UI.EditorForm.folderBrowserDialog1.ShowDialog();
                    if (folderdialogresult == DialogResult.OK)
                    {
                        VD2Path = EditorUI.UI.EditorForm.folderBrowserDialog1.SelectedPath;
                    }
                }

                List<string> configlines = new List<string>();
                configlines.Add("VD2Path|" + VD2Path);
                File.WriteAllLines("EditorUserSettings.cfg", configlines);*/
                FirstTimeSetupWizard wizard = new FirstTimeSetupWizard();
                if (wizard.ShowDialog() == DialogResult.Abort)
                {
                    return false;
                }
            }
            return true;
        }

        public bool SourceIsReadWrite(string inName)
        {
            for (int i = 0; i < Sources.Count; i++)
            {
                if (Sources[i].ShortName == inName)
                {
                    return Sources[i].WriteAccess;
                }
            }
            return false;
        }

        public VD2FileSource GetSourceByShortName(string inShortName)
        {
            foreach (VD2FileSource source in Sources)
            {
                if (source.ShortName == inShortName)
                {
                    return source;
                }
            }
            return null;
        }
    }
}
