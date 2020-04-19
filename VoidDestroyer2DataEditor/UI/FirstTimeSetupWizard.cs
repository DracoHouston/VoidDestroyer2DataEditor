using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    enum FirstTimeSetupWizardPages
    {
        welcome,
        path
    }
    public partial class FirstTimeSetupWizard : Form
    {
        FirstTimeSetupWizardPages currentpage = FirstTimeSetupWizardPages.welcome;
        
        public FirstTimeSetupWizard()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            switch (currentpage)
            {
                case FirstTimeSetupWizardPages.welcome:
                    panel1.Visible = false;
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                    panel2.Visible = true;
                    BackButton.Enabled = true;
                    NextButton.Text = "Done";
                    NextButton.Enabled = false;
                    currentpage = FirstTimeSetupWizardPages.path;
                    SetupPathPage();
                    break;
                case FirstTimeSetupWizardPages.path:
                    EditorUserSettings.UserSettings.VD2Path = textBox1.Text;
                    EditorUserSettings.UserSettings.SaveSettings();
                    Close();
                    break;
            }
        }

        public void SetupPathPage()
        {
            string SteamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "C:\\Program Files (x86)\\Steam");
            SteamPath = SteamPath.Replace("/", "\\");//the different slashes looks ugly.
            if (File.Exists(SteamPath + "\\steamapps\\common\\Void Destroyer 2\\Void Destroyer 2.exe"))
            {
                textBox1.Text = SteamPath + "\\steamapps\\common\\Void Destroyer 2\\";
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            EditorUI.UI.EditorForm.Close();
            Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (currentpage)
            {
                case FirstTimeSetupWizardPages.welcome:
                    //uhh
                    break;
                case FirstTimeSetupWizardPages.path:
                    panel2.Visible = false;
                    panel2.Enabled = false;
                    panel1.Enabled = true;
                    panel1.Visible = true;
                    BackButton.Enabled = false;
                    NextButton.Enabled = true;
                    NextButton.Text = "Next";
                    currentpage = FirstTimeSetupWizardPages.welcome;
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + "Void Destroyer 2.exe"))
            {
                /*if (HasUnsavedSettings())
                {
                    button3.Enabled = true;
                    button1.Enabled = true;
                }*/
                if (currentpage == FirstTimeSetupWizardPages.path)
                {
                    NextButton.Enabled = true;
                }
                ValidPathIndicator.Checked = true;
                ValidPathIndicator.BackColor = Color.Green;
            }
            else
            {
                //button1.Enabled = false;
                //button3.Enabled = false;
                ValidPathIndicator.Checked = false;
                ValidPathIndicator.BackColor = Color.Red;
            }
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {
            string result;
            if (EditorUI.UI.GetVD2PathUsingDialog(out result) == DialogResult.OK)
            {
                textBox1.Text = result;
            }
        }
    }
}
