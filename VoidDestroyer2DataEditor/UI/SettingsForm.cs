﻿using System;
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
        int TreeIconSize;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            switch (EditorUserSettings.UserSettings.TreeIconSize)
            {
                case 16:
                    TreeIconSize = 16;
                    break;
                case 32:
                    TreeIconSize = 32;
                    break;
            }
            textBox1.Text = EditorUserSettings.UserSettings.VD2Path;
            switch (EditorUserSettings.UserSettings.TreeIconSize)
            {
                case 16:
                    checkedListBox1.SetItemChecked(0, true);
                    break;
                case 32:
                    checkedListBox1.SetItemChecked(1, true);
                    break;
            }            
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {

            //DialogResult result = folderBrowserDialog1.ShowDialog();
            string result;
            if (EditorUI.UI.GetVD2PathUsingDialog(out result) == DialogResult.OK)
            {
                textBox1.Text = result;
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
            if (!HasUnsavedSettings())//if the user hit cancel on a restart request this should be true and we need to keep the apply button enabled.
            {
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveConfig()
        {
            bool restarteditor = false;
            if (EditorUserSettings.UserSettings.VD2Path != textBox1.Text)
            {
                EditorRestartDialog dialog = new EditorRestartDialog();
                DialogResult dresult = dialog.ShowDialog();
                if (dresult == DialogResult.Yes)
                {
                    EditorUI.UI.EditorForm.SaveAllOpenDocuments();
                    restarteditor = true;
                }
                else if (dresult == DialogResult.No)
                {
                    restarteditor = true;
                }
                else if (dresult == DialogResult.Cancel)
                {
                    restarteditor = false;
                    return;//cancel out of this and don't change apply any settings changes.
                }
                string newvd2path = textBox1.Text.Replace("/", "\\");//the different slashes looks ugly.
                EditorUserSettings.UserSettings.VD2Path = newvd2path;
            }
            if ((TreeIconSize != 16) && (TreeIconSize != 32))
            {
                TreeIconSize = 16;
            }
            if (EditorUserSettings.UserSettings.TreeIconSize != TreeIconSize)
            {
                EditorUserSettings.UserSettings.TreeIconSize = TreeIconSize;
                EditorUI.UI.EditorForm.SetTreeIconSize(TreeIconSize);
            }
            
            EditorUserSettings.UserSettings.SaveSettings();
            if (restarteditor)
            {
                Application.Restart();
            }
        }

        private bool HasUnsavedSettings()
        {
            bool result = false;
            if (EditorUserSettings.UserSettings.VD2Path != textBox1.Text)
            {
                if (File.Exists(textBox1.Text + "Void Destroyer 2.exe"))
                {
                    result = true;
                }
            }
            if (EditorUserSettings.UserSettings.TreeIconSize != TreeIconSize)
            {
                result = true;
            }
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + "Void Destroyer 2.exe"))
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

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index == 0)
                {
                    checkedListBox1.SetItemChecked(1, false);
                    TreeIconSize = 16;
                    if (HasUnsavedSettings())
                    {
                        button3.Enabled = true;
                        button1.Enabled = true;
                    }
                }
                else if (e.Index == 1)
                {
                    checkedListBox1.SetItemChecked(0, false);
                    TreeIconSize = 32;
                    if (HasUnsavedSettings())
                    {
                        button3.Enabled = true;
                        button1.Enabled = true;
                    }
                }
            }
        }
    }
}
