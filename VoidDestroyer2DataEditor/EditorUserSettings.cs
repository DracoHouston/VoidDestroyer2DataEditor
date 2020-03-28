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
    class EditorUserSettings
    {
        private static EditorUserSettings Instance = null;

        public string VD2Path;
        public MainEditorForm EditorForm;
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
            EditorForm = null;
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
    }
}
