using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinXExplorerMenu
{
    public partial class WinXExplorerMenuForm/* : Form*/
    {
        private bool bSystemShutdown;

        public MainSettings mainSettings;

        public static WinXExplorerMenuForm Default { get; } = new WinXExplorerMenuForm();

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        private BindingList<FolderSettings> listFolders = new BindingList<FolderSettings>();

        public WinXExplorerMenuForm()
        {
            InitializeComponent();
        }

        private void WinXExplorerMenu_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Globals.ConfigPath))
                {
                    Directory.CreateDirectory(Globals.ConfigPath);
                }

                if (!File.Exists(Globals.ConfigFile))
                {

                    XDocument doc = new XDocument(new XElement("Folders"));
                    doc.Save(Globals.ConfigFile);
                }

                mainSettings = new MainSettings();
                mainSettings.AlwaysShowIcon = Globals.GetConfigData(Globals.SettingsAlwaysShowIcon) == "True" ? true : false ;
                mainSettings.EnableArrowKeys = Globals.GetConfigData(Globals.SettingsEnableArrowKeys) == "True" ? true : false;
                mainSettings.MinimizeOnClose = Globals.GetConfigData(Globals.SettingsMinimizeOnClose) == "True" ? true : false;
                mainSettings.MinimizeOnStart = Globals.GetConfigData(Globals.SettingsStartMinimized) == "True" ? true : false;
                mainSettings.AlternativeApp = Globals.GetConfigData(Globals.SettingsAlternativeApp);

                var savedFolders = FolderSettings.Deserialize(Globals.ConfigFile);

                // Execute the query
                foreach (var folder in savedFolders)
                {
                    listFolders.Add(new FolderSettings()
                    {
                        FolderName = folder.FolderName,
                        FolderDescription = folder.FolderDescription,
                        FolderParams = folder.FolderParams,
                        FolderID = folder.FolderID
                    });
                }

                PopulateListViewWithSavedFolders();

                CreateNotifcationIconAreaContextMenus();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void WinXExplorerMenu_Closing(object sender, CancelEventArgs e)
        {
            if (bSystemShutdown)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                WindowFormMinimized();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == base.WindowState)
            {
                WindowFormMinimized();
            }
            else
            {
                WindowFormNormal();
            }
        }

        private void WindowFormNormal()
        {
            base.WindowState = FormWindowState.Normal;
            base.ShowInTaskbar = true;
            base.Show();
            base.Focus();
            notifyIcon1.Visible = false;
            base.CenterToScreen();
        }

        private void WindowFormMinimized()
        {
            Hide();
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            Visible = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (0x11 == m.Msg)
            {
                bSystemShutdown = true;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void PopulateListViewWithSavedFolders()
        {
            try
            {
                ColumnHeader Name = new ColumnHeader
                {
                    Text = "Folder Name",
                    Width = lvMenuItems.Width - 5
                };
                lvMenuItems.Columns.Add(Name);
                lvMenuItems.HeaderStyle = ColumnHeaderStyle.None;

                if (listFolders.Any())
                {
                    foreach (var folder in listFolders)
                    {
                        ListViewItem item = new ListViewItem
                        {
                            Text = folder.FolderDescription,
                            Tag = folder.FolderID
                        };
                        lvMenuItems.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Folders!n\n\n " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Notfication Icon Area Items
        private void NotifcationIconAreaPopupMenu(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem miClicked = (ToolStripMenuItem)sender;
                string item = miClicked.Text;

                for (int nItems = 0; nItems < listFolders.Count; nItems++)
                {
                    if (0 == String.Compare(listFolders[nItems].FolderDescription, item, true))
                    {
                        try
                        {
                            string sFolderDirectory = listFolders[nItems].FolderName + ",/e " + listFolders[nItems].FolderParams;

                            System.Diagnostics.Process.Start("explorer.exe", sFolderDirectory);
                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show(Exc.ToString());
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void CreateNotifcationIconAreaContextMenus()
        {
            try
            {
                contextNotifyIconMenu.Items.Add("Config", null, new EventHandler(ConfigToolStripMenuItem_Click));

                ToolStripSeparator separator1 = new ToolStripSeparator();
                contextNotifyIconMenu.Items.Add(separator1);

                contextNotifyIconMenu.Items.Add("Exit", null, new EventHandler(ExitToolStripMenuItem_Click));

                ToolStripSeparator separator2 = new ToolStripSeparator();
                contextNotifyIconMenu.Items.Add(separator2);

                try
                {
                    if (listFolders.Any())
                    {
                        for (int nItems = 0; nItems < listFolders.Count; nItems++)
                        {
                            string _sDescription = listFolders[nItems].FolderDescription;

                            if (_sDescription.IndexOf("------------ <separator>") == 0)
                            {
                                ToolStripSeparator separator = new ToolStripSeparator();
                                contextNotifyIconMenu.Items.Add(separator);
                            }
                            else
                            {
                                contextNotifyIconMenu.Items.Add(listFolders[nItems].FolderDescription, null, new EventHandler(NotifcationIconAreaPopupMenu));
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_Resize(this, new EventArgs());
            Settings settingsForm = new Settings();
            if( DialogResult.OK == settingsForm.ShowDialog())
            {
                mainSettings.AlternativeApp = settingsForm.savedSettings.AlternativeApp;
                mainSettings.AlwaysShowIcon = settingsForm.savedSettings.AlwaysShowIcon;
                mainSettings.EnableArrowKeys = settingsForm.savedSettings.EnableArrowKeys;
                mainSettings.MinimizeOnClose = settingsForm.savedSettings.MinimizeOnClose;
                mainSettings.MinimizeOnStart = settingsForm.savedSettings.MinimizeOnStart;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bSystemShutdown = true;
            base.Close();
        }

        #endregion

        #region ListView Menu Items
        private void AddFolderMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void ModifyFolderMenuItem_Click(object sender, EventArgs e)
        {
            ModifyFolder();
        }

        private void DeleteFolderMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMenuItems.Items.Count > 0)
            {
                DeleteFolder();
            }
        }

        private void AddSeparatorMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripSeparator separator = new ToolStripSeparator();
            contextNotifyIconMenu.Items.Add(separator);

            FolderSettings newFolder = new FolderSettings
            {
                FolderName = "------------ <separator>",
                FolderDescription = "------------ <separator>"
            };

            listFolders.Add(newFolder);
            FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);

            lvMenuItems.Items.Add(new ListViewItem
            {
                Text = newFolder.FolderDescription,
                Tag = newFolder.FolderID
            });
        }

        #endregion

        #region Folder Changes
        private FolderSettings ShowFolderWindow(FolderSettings folder)
        {
            TaskDialog folderWindow = new TaskDialog(folder);
            if (DialogResult.OK == folderWindow.ShowDialog())
            {
                return folderWindow.folderSettings;
            }

            return null;
        }

        private void AddFolder()
        {
            FolderSettings newFolder = new FolderSettings();
            if ((newFolder = ShowFolderWindow(new FolderSettings())) != null)
            {
                listFolders.Add(newFolder);
                FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);
                lvMenuItems.Items.Add(new ListViewItem
                {
                    Text = newFolder.FolderDescription,
                    Tag = newFolder.FolderID
                });
            }
        }

        private void ModifyFolder()
        {
            if (lvMenuItems.Items.Count > 0)
            {
                ListViewItem lvFolder = lvMenuItems.SelectedItems[0];
                if (lvFolder != null)
                {
                    int index = lvMenuItems.SelectedIndices[0];
                    var modFolder = (FolderSettings)listFolders.Where(t => t.FolderID == (Guid)lvFolder.Tag).FirstOrDefault();
                    if (modFolder != null)
                    {
                        if ((modFolder = ShowFolderWindow(modFolder)) != null)
                        {
                            listFolders[index] = modFolder;
                            XElement xEle = XElement.Load(Globals.ConfigFile);
                            xEle.Save(Globals.ConfigFile);
                            lvMenuItems.Items[index].Text = modFolder.FolderName;
                        }
                    }
                }
            }
        }

        private bool DeleteFolder()
        {
            try
            {
                if (lvMenuItems.Items.Count > 0)
                {
                    ListViewItem lvFolder = lvMenuItems.SelectedItems[0];
                    if (lvFolder != null)
                    {
                        int index = lvMenuItems.SelectedIndices[0];
                        var delFolder = (FolderSettings)listFolders.Where(t => t.FolderID == (Guid)lvFolder.Tag).FirstOrDefault();
                        if (delFolder != null)
                        {
                            listFolders.RemoveAt(index); ;
                            lvMenuItems.Items.RemoveAt(index);
                            FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }

        #endregion

        #region ListView Functionality
        private void LvMenuItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LvMenuItems_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = ((ListView)sender).PointToClient(new Point(e.X, e.Y));
            ListViewItem item = ((ListView)sender).GetItemAt(pt.X, pt.Y);
            if (item != null)
            {
                var dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                if (dragItem != null)
                {
                    ListViewItem clone = (ListViewItem)dragItem.Clone();
                    var movedFolder = (FolderSettings)listFolders.Where(t => t.FolderID == (Guid)dragItem.Tag).FirstOrDefault();
                    if (movedFolder != null)
                    {
                        listFolders.RemoveAt(dragItem.Index);
                        lvMenuItems.Items.RemoveAt(dragItem.Index);
                        lvMenuItems.Items.Insert(item.Index+1, clone);
                        listFolders.Insert(item.Index+1, movedFolder);
                        FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);
                    }
                    item.Selected = true;
                }
            }

        }

        private void LvMenuItems_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void LvMenuItems_DoubleClick(object sender, EventArgs e)
        {
            ModifyFolder();
        }

        private void LvMenuItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                AddFolder();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                ModifyFolder();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteFolder();
            }
            else if (e.KeyCode == Keys.Enter)
            {
            }
            else if( e.KeyCode == Keys.Down)
            {
                try
                {
                    if (lvMenuItems.Items.Count > 1)
                    {
                        ListViewItem lvFolder = lvMenuItems.SelectedItems[0];
                        if (lvFolder != null)
                        {
                            int nIndex = lvFolder.Index;

                            if (nIndex >= 0 && nIndex < lvMenuItems.Items.Count)
                            {
                                ListViewItem clone = (ListViewItem)lvFolder.Clone();
                                ListViewItem nextItemClone = (ListViewItem)lvMenuItems.Items[nIndex + 1].Clone();

                                FolderSettings movedFolder = listFolders[nIndex];
                                FolderSettings nextFolder = listFolders[nIndex + 1];
                                listFolders[nIndex + 1] = movedFolder;
                                listFolders[nIndex] = nextFolder;
                                FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);

                                lvMenuItems.Items[nIndex] = nextItemClone;
                                lvMenuItems.Items[nIndex + 1] = clone;
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                try
                {
                    if (lvMenuItems.Items.Count > 1)
                    {
                        ListViewItem lvFolder = lvMenuItems.SelectedItems[0];
                        if (lvFolder != null)
                        {
                            int nIndex = lvFolder.Index;

                            if (nIndex >= 1 && nIndex < lvMenuItems.Items.Count)
                            {
                                ListViewItem clone = (ListViewItem)lvFolder.Clone();
                                ListViewItem prevItemClone = (ListViewItem)lvMenuItems.Items[nIndex-1].Clone();

                                FolderSettings movedFolder = listFolders[nIndex];
                                FolderSettings previousFolder = listFolders[nIndex-1];
                                listFolders[nIndex-1] = movedFolder;
                                listFolders[nIndex] = previousFolder;
                                FolderSettings.Serialize(listFolders.ToList(), Globals.ConfigFile);

                                lvMenuItems.Items[nIndex] = prevItemClone;
                                lvMenuItems.Items[nIndex - 1] = clone;
                                
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

            }
        }

        #endregion

    }
}