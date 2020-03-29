using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    class VD2FileSource
    {
        public string DisplayName;
        public string ShortName;
        public string Path;
        public bool WriteAccess;
        public bool FilterIn;
    }

    class EditorUserSettings
    {
        private static EditorUserSettings Instance = null;

        public string VD2Path;
        public List<VD2FileSource> Sources;


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
            Sources = new List<VD2FileSource>();
        }

        public void SaveSettings()
        {
            List<string> configlines = new List<string>();
            configlines.Add("VD2Path|" + VD2Path);
            File.WriteAllLines("EditorUserSettings.cfg", configlines);
            EditorUI.UI.EditorForm.RepopulateAllTrees();
        }

        public void InitUserSettings()
        {
            Sources.Clear();
            VD2FileSource currentsource = new VD2FileSource();
            currentsource.DisplayName = "Base Game";
            currentsource.ShortName = "Base";
            currentsource.Path = "";
            currentsource.WriteAccess = false;
            currentsource.FilterIn = true;
            Sources.Add(currentsource);
            currentsource = new VD2FileSource();
            currentsource.DisplayName = "Mod Game";
            currentsource.ShortName = "Mod";
            currentsource.Path = "Mod\\";
            currentsource.WriteAccess = true;
            currentsource.FilterIn = true;
            Sources.Add(currentsource);

            bool configfoundandvalid = false;
            if (File.Exists("EditorUserSettings.cfg"))
            {
                List<string> configlines = File.ReadAllLines("EditorUserSettings.cfg").ToList();
                if (configlines.Count == 1)
                {

                    List<string> currentlinesplit = configlines[0].Split('|').ToList();
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
                wizard.ShowDialog();
            }
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
    }
}
