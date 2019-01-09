using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinXExplorerMenu
{
    public partial class Settings : Form
    {
        public MainSettings savedSettings = new MainSettings();
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            chkAlwaysShowIcon.Checked = WinXExplorerMenuForm.Default.mainSettings.AlwaysShowIcon;
            chkEnableArrowKeys.Checked = WinXExplorerMenuForm.Default.mainSettings.EnableArrowKeys;
            chkMinimizeOnClose.Checked = WinXExplorerMenuForm.Default.mainSettings.MinimizeOnClose;
            chkMinimizeOnStartup.Checked = WinXExplorerMenuForm.Default.mainSettings.MinimizeOnStart;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            savedSettings.MinimizeOnStart = chkMinimizeOnStartup.Checked;
            savedSettings.MinimizeOnClose = chkMinimizeOnClose.Checked;
            savedSettings.EnableArrowKeys = chkEnableArrowKeys.Checked;
            savedSettings.AlwaysShowIcon = chkAlwaysShowIcon.Checked;
            savedSettings.AlternativeApp = txtAlternativeApp.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                openFileDialog.Filter = "All files(*.*) | *.* ";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    txtAlternativeApp.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(string.Format(Language.strImportFileFailedContent, fileName), Language.strImportFileFailedMainInstruction,
                    //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
