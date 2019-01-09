using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinXExplorerMenu
{
    public partial class TaskDialog : Form
    {
        public FolderSettings folderSettings = new FolderSettings();
        public TaskDialog(FolderSettings folder)
        {
            InitializeComponent();

            folderSettings = folder;
        }

        private void TaskDialog_Load(object sender, EventArgs e)
        {
            lblFolder.Text = Language.strFolderName;
            lblDescription.Text = Language.strFolderDescription;
            lblParameters.Text = Language.strFolderParameters;
            btnOK.Text = Language.strButtonOK;
            btnCancel.Text = Language.strButtonCancel;

            txtFolder.Text = folderSettings.FolderName;
            txtDescription.Text = folderSettings.FolderDescription;
            txtParameters.Text = folderSettings.FolderParams;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (!folderBrowser.SelectedPath.EndsWith(Convert.ToString(Path.DirectorySeparatorChar)))
                    {
                        folderBrowser.SelectedPath += Path.DirectorySeparatorChar;
                    }

                    txtFolder.Text = txtDescription.Text = folderBrowser.SelectedPath.Trim();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if( !txtFolder.Text.Any() )
            {
                MessageBox.Show(Language.strInvalidFolder, Language.strErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtDescription.Text.Any())
            {
                txtDescription.Text = txtFolder.Text;
            }

            folderSettings.FolderName = txtFolder.Text;
            folderSettings.FolderDescription = txtDescription.Text;
            folderSettings.FolderParams = txtParameters.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
