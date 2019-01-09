namespace WinXExplorerMenu
{
    partial class WinXExplorerMenuForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinXExplorerMenuForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvMenuItems = new System.Windows.Forms.ListView();
            this.contextLVMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSeparatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextNotifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.contextLVMenuItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvMenuItems);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 532);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // lvMenuItems
            // 
            this.lvMenuItems.AllowDrop = true;
            this.lvMenuItems.ContextMenuStrip = this.contextLVMenuItems;
            this.lvMenuItems.Location = new System.Drawing.Point(6, 19);
            this.lvMenuItems.MultiSelect = false;
            this.lvMenuItems.Name = "lvMenuItems";
            this.lvMenuItems.Size = new System.Drawing.Size(308, 507);
            this.lvMenuItems.TabIndex = 15;
            this.lvMenuItems.UseCompatibleStateImageBehavior = false;
            this.lvMenuItems.View = System.Windows.Forms.View.Details;
            this.lvMenuItems.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LvMenuItems_ItemDrag);
            this.lvMenuItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.LvMenuItems_DragDrop);
            this.lvMenuItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.LvMenuItems_DragEnter);
            this.lvMenuItems.DoubleClick += new System.EventHandler(this.LvMenuItems_DoubleClick);
            this.lvMenuItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvMenuItems_KeyDown);
            // 
            // contextLVMenuItems
            // 
            this.contextLVMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderMenuItem,
            this.modifyFolderMenuItem,
            this.deleteFolderMenuItem,
            this.toolStripSeparator1,
            this.addSeparatorMenuItem});
            this.contextLVMenuItems.Name = "contextMenuStripMenuItems";
            this.contextLVMenuItems.Size = new System.Drawing.Size(150, 98);
            // 
            // addFolderMenuItem
            // 
            this.addFolderMenuItem.Name = "addFolderMenuItem";
            this.addFolderMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addFolderMenuItem.Text = "Add Folder";
            this.addFolderMenuItem.Click += new System.EventHandler(this.AddFolderMenuItem_Click);
            // 
            // modifyFolderMenuItem
            // 
            this.modifyFolderMenuItem.Name = "modifyFolderMenuItem";
            this.modifyFolderMenuItem.Size = new System.Drawing.Size(149, 22);
            this.modifyFolderMenuItem.Text = "Modify Folder";
            this.modifyFolderMenuItem.Click += new System.EventHandler(this.ModifyFolderMenuItem_Click);
            // 
            // deleteFolderMenuItem
            // 
            this.deleteFolderMenuItem.Name = "deleteFolderMenuItem";
            this.deleteFolderMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteFolderMenuItem.Text = "Delete Folder";
            this.deleteFolderMenuItem.Click += new System.EventHandler(this.DeleteFolderMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // addSeparatorMenuItem
            // 
            this.addSeparatorMenuItem.Name = "addSeparatorMenuItem";
            this.addSeparatorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addSeparatorMenuItem.Text = "Add Separator";
            this.addSeparatorMenuItem.Click += new System.EventHandler(this.AddSeparatorMenuItem_Click);
            // 
            // contextNotifyIconMenu
            // 
            this.contextNotifyIconMenu.Name = "contextMenuStrip1";
            this.contextNotifyIconMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextNotifyIconMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WinXExplorerMenu";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.Form1_Resize);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // WinXExplorerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 556);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinXExplorerMenu";
            this.Text = "WinX Explorer Menu";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WinXExplorerMenu_Closing);
            this.Load += new System.EventHandler(this.WinXExplorerMenu_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.contextLVMenuItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextNotifyIconMenu;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView lvMenuItems;
        private System.Windows.Forms.ContextMenuStrip contextLVMenuItems;
        private System.Windows.Forms.ToolStripMenuItem addFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addSeparatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyFolderMenuItem;
    }
}

