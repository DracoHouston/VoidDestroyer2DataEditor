using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class DuplicateFileDialog : Form
    {
        public string DestinationFolderPath;
        public string FileName;
        public string ObjectID;
        public string FileType;

        public DuplicateFileDialog()
        {
            FileName = "";
            ObjectID = "";
            InitializeComponent();
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FileName = FileNameTextBox.Text;
            if (Directory.Exists(DestinationFolderPath))//is this even correct?
            {
                if (File.Exists(DestinationFolderPath + "\\" + FileName + ".xml"))//file exists?
                {
                    FileNameIndicator.Checked = false;
                    FileNameIndicator.BackColor = Color.Red;
                    OKButton.Enabled = false;
                }
                else
                {
                    FileNameIndicator.Checked = true;
                    FileNameIndicator.BackColor = Color.Green;
                    if (ObjectIDIndicator.Checked)
                    {
                        OKButton.Enabled = true;
                    }
                }
            }
            else
            {
                FileNameIndicator.Checked = false;
                FileNameIndicator.BackColor = Color.Red;
                OKButton.Enabled = false;
            }
        }

        private void ObjectIDTextBox_TextChanged(object sender, EventArgs e)
        {
            ObjectID = ObjectIDTextBox.Text;
            if (ObjectID == "")
            {
                ObjectIDIndicator.Checked = false;
                ObjectIDIndicator.BackColor = Color.Red;
                OKButton.Enabled = false;
                return;
            }
            bool foundobjectid = false;
            switch (FileType)
            {
                case "ShipData":
                    foreach (VD2Data datafile in EditorUI.UI.Ships.Data.Values)
                    {
                        if (datafile.GetObjectID() == ObjectID)
                        {
                            foundobjectid = true;
                        }
                    }
                    break;
                case "PrimaryUpgradeData":
                    foreach (VD2Data datafile in EditorUI.UI.PrimaryUpgrades.Data.Values)
                    {
                        if (datafile.GetObjectID() == ObjectID)
                        {
                            foundobjectid = true;
                        }
                    }
                    break;
            }
            if (foundobjectid)
            {
                ObjectIDIndicator.Checked = false;
                ObjectIDIndicator.BackColor = Color.Red;
                OKButton.Enabled = false;
            }
            else
            {
                ObjectIDIndicator.Checked = true;
                ObjectIDIndicator.BackColor = Color.Green;
                if (FileNameIndicator.Checked)
                {
                    OKButton.Enabled = true;
                }
            }
            
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if ((FileNameIndicator.Checked) && (ObjectIDIndicator.Checked))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DuplicateFileDialog_Load(object sender, EventArgs e)
        {
            FileNameTextBox.Text = FileName;
            ObjectIDTextBox.Text = ObjectID;
        }
    }
}
