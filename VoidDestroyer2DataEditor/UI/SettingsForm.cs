using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = EditorUserSettings.UserSettings.VD2Path;
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HasUnsavedSettings())
            {
                SaveConfig();
            }
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveConfig();
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveConfig()
        {
            EditorUserSettings.UserSettings.VD2Path = textBox1.Text;
            EditorUserSettings.UserSettings.SaveSettings();
        }

        private bool HasUnsavedSettings()
        {
            bool result = false;
            if (EditorUserSettings.UserSettings.VD2Path != textBox1.Text)
            {
                if (File.Exists(textBox1.Text + "/Void Destroyer 2.exe"))
                {
                    result = true;
                }
            }
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + "/Void Destroyer 2.exe"))
            {
                if (HasUnsavedSettings())
                { 
                    button3.Enabled = true;
                    button1.Enabled = true;
                }
                ValidPathIndicator.Checked = true;
                ValidPathIndicator.BackColor = Color.Green;
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
                ValidPathIndicator.Checked = false;
                ValidPathIndicator.BackColor = Color.Red;
            }
            
        }
    }
}
