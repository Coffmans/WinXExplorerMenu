namespace WinXExplorerMenu
{
    partial class Settings
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
            this.chkMinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.chkAlwaysShowIcon = new System.Windows.Forms.CheckBox();
            this.chkEnableArrowKeys = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkMinimizeOnStartup = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtAlternativeApp = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMinimizeOnClose
            // 
            this.chkMinimizeOnClose.AutoSize = true;
            this.chkMinimizeOnClose.Location = new System.Drawing.Point(6, 42);
            this.chkMinimizeOnClose.Name = "chkMinimizeOnClose";
            this.chkMinimizeOnClose.Size = new System.Drawing.Size(146, 17);
            this.chkMinimizeOnClose.TabIndex = 0;
            this.chkMinimizeOnClose.Text = "Minimize On Close Button";
            this.chkMinimizeOnClose.UseVisualStyleBackColor = true;
            // 
            // chkAlwaysShowIcon
            // 
            this.chkAlwaysShowIcon.AutoSize = true;
            this.chkAlwaysShowIcon.Location = new System.Drawing.Point(6, 65);
            this.chkAlwaysShowIcon.Name = "chkAlwaysShowIcon";
            this.chkAlwaysShowIcon.Size = new System.Drawing.Size(278, 17);
            this.chkAlwaysShowIcon.TabIndex = 1;
            this.chkAlwaysShowIcon.Text = "Always Show Taskbar Notification (System Tray) Icon";
            this.chkAlwaysShowIcon.UseVisualStyleBackColor = true;
            // 
            // chkEnableArrowKeys
            // 
            this.chkEnableArrowKeys.AutoSize = true;
            this.chkEnableArrowKeys.Location = new System.Drawing.Point(6, 88);
            this.chkEnableArrowKeys.Name = "chkEnableArrowKeys";
            this.chkEnableArrowKeys.Size = new System.Drawing.Size(250, 17);
            this.chkEnableArrowKeys.TabIndex = 2;
            this.chkEnableArrowKeys.Text = "Enable Arrow Keys (Up/Down) to Move Folders";
            this.chkEnableArrowKeys.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(171, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkMinimizeOnStartup
            // 
            this.chkMinimizeOnStartup.AutoSize = true;
            this.chkMinimizeOnStartup.Location = new System.Drawing.Point(6, 19);
            this.chkMinimizeOnStartup.Name = "chkMinimizeOnStartup";
            this.chkMinimizeOnStartup.Size = new System.Drawing.Size(125, 17);
            this.chkMinimizeOnStartup.TabIndex = 4;
            this.chkMinimizeOnStartup.Text = "Minimize On Start-Up";
            this.chkMinimizeOnStartup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtAlternativeApp);
            this.groupBox1.Controls.Add(this.chkMinimizeOnStartup);
            this.groupBox1.Controls.Add(this.chkMinimizeOnClose);
            this.groupBox1.Controls.Add(this.chkEnableArrowKeys);
            this.groupBox1.Controls.Add(this.chkAlwaysShowIcon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 163);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Windows Explorer Alternative (Optional)";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(290, 128);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 21);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtAlternativeApp
            // 
            this.txtAlternativeApp.Location = new System.Drawing.Point(6, 129);
            this.txtAlternativeApp.Name = "txtAlternativeApp";
            this.txtAlternativeApp.Size = new System.Drawing.Size(278, 20);
            this.txtAlternativeApp.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 237);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMinimizeOnClose;
        private System.Windows.Forms.CheckBox chkAlwaysShowIcon;
        private System.Windows.Forms.CheckBox chkEnableArrowKeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkMinimizeOnStartup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAlternativeApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancel;
    }
}