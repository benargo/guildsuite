namespace DesktopClient
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.groupBoxAuthenticationSettings = new System.Windows.Forms.GroupBox();
            this.buttonAuthenticationSettingsSave = new System.Windows.Forms.Button();
            this.textBoxRedirectUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBoxAuthenticationStatus = new System.Windows.Forms.GroupBox();
            this.labelIsAuthenticated = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxWoWConfiguration = new System.Windows.Forms.GroupBox();
            this.labelAddonIsInstalled = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonBrowseToClassicFolder = new System.Windows.Forms.Button();
            this.textBoxClassicDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.folderBrowserDialogWoWDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.labelBankersList = new System.Windows.Forms.Label();
            this.groupBoxGuildBank = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxAuthenticationSettings.SuspendLayout();
            this.groupBoxAuthenticationStatus.SuspendLayout();
            this.groupBoxWoWConfiguration.SuspendLayout();
            this.groupBoxGuildBank.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisProgramToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutThisProgramToolStripMenuItem
            // 
            this.aboutThisProgramToolStripMenuItem.Name = "aboutThisProgramToolStripMenuItem";
            this.aboutThisProgramToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.aboutThisProgramToolStripMenuItem.Text = "About this program";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(114, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "The Order";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DesktopClient.Properties.Resources.app_icon_192;
            this.pictureBox1.Location = new System.Drawing.Point(13, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(115, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Desktop Client";
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.textBoxClientId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClientId.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientId.ForeColor = System.Drawing.Color.White;
            this.textBoxClientId.Location = new System.Drawing.Point(6, 102);
            this.textBoxClientId.MaxLength = 6;
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(244, 25);
            this.textBoxClientId.TabIndex = 3;
            this.textBoxClientId.TextChanged += new System.EventHandler(this.textBoxClientId_TextChanged);
            // 
            // groupBoxAuthenticationSettings
            // 
            this.groupBoxAuthenticationSettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAuthenticationSettings.Controls.Add(this.buttonAuthenticationSettingsSave);
            this.groupBoxAuthenticationSettings.Controls.Add(this.textBoxRedirectUrl);
            this.groupBoxAuthenticationSettings.Controls.Add(this.label5);
            this.groupBoxAuthenticationSettings.Controls.Add(this.textBoxClientSecret);
            this.groupBoxAuthenticationSettings.Controls.Add(this.label4);
            this.groupBoxAuthenticationSettings.Controls.Add(this.label3);
            this.groupBoxAuthenticationSettings.Controls.Add(this.linkLabel1);
            this.groupBoxAuthenticationSettings.Controls.Add(this.textBoxClientId);
            this.groupBoxAuthenticationSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAuthenticationSettings.ForeColor = System.Drawing.Color.White;
            this.groupBoxAuthenticationSettings.Location = new System.Drawing.Point(13, 191);
            this.groupBoxAuthenticationSettings.Name = "groupBoxAuthenticationSettings";
            this.groupBoxAuthenticationSettings.Size = new System.Drawing.Size(256, 331);
            this.groupBoxAuthenticationSettings.TabIndex = 6;
            this.groupBoxAuthenticationSettings.TabStop = false;
            this.groupBoxAuthenticationSettings.Text = "Authentication Settings";
            // 
            // buttonAuthenticationSettingsSave
            // 
            this.buttonAuthenticationSettingsSave.AutoSize = true;
            this.buttonAuthenticationSettingsSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.buttonAuthenticationSettingsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAuthenticationSettingsSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.buttonAuthenticationSettingsSave.Location = new System.Drawing.Point(6, 287);
            this.buttonAuthenticationSettingsSave.Name = "buttonAuthenticationSettingsSave";
            this.buttonAuthenticationSettingsSave.Padding = new System.Windows.Forms.Padding(5);
            this.buttonAuthenticationSettingsSave.Size = new System.Drawing.Size(244, 38);
            this.buttonAuthenticationSettingsSave.TabIndex = 6;
            this.buttonAuthenticationSettingsSave.Text = "Save Changes";
            this.buttonAuthenticationSettingsSave.UseVisualStyleBackColor = false;
            this.buttonAuthenticationSettingsSave.Click += new System.EventHandler(this.buttonAuthenticationSettingsSave_Click);
            // 
            // textBoxRedirectUrl
            // 
            this.textBoxRedirectUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.textBoxRedirectUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRedirectUrl.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRedirectUrl.ForeColor = System.Drawing.Color.White;
            this.textBoxRedirectUrl.Location = new System.Drawing.Point(6, 234);
            this.textBoxRedirectUrl.Name = "textBoxRedirectUrl";
            this.textBoxRedirectUrl.Size = new System.Drawing.Size(244, 25);
            this.textBoxRedirectUrl.TabIndex = 5;
            this.textBoxRedirectUrl.TextChanged += new System.EventHandler(this.textBoxRedirectUrl_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Redirect URL";
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.textBoxClientSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClientSecret.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientSecret.ForeColor = System.Drawing.Color.White;
            this.textBoxClientSecret.Location = new System.Drawing.Point(6, 168);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.Size = new System.Drawing.Size(244, 25);
            this.textBoxClientSecret.TabIndex = 4;
            this.textBoxClientSecret.TextChanged += new System.EventHandler(this.textBoxClientSecret_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Client Secret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Client ID";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(3, 22);
            this.linkLabel1.MaximumSize = new System.Drawing.Size(256, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(230, 36);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "You can obtain your Client ID and Secret from The Order\'s website.";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            // 
            // groupBoxAuthenticationStatus
            // 
            this.groupBoxAuthenticationStatus.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAuthenticationStatus.Controls.Add(this.labelIsAuthenticated);
            this.groupBoxAuthenticationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxAuthenticationStatus.ForeColor = System.Drawing.Color.White;
            this.groupBoxAuthenticationStatus.Location = new System.Drawing.Point(13, 130);
            this.groupBoxAuthenticationStatus.Name = "groupBoxAuthenticationStatus";
            this.groupBoxAuthenticationStatus.Size = new System.Drawing.Size(256, 55);
            this.groupBoxAuthenticationStatus.TabIndex = 7;
            this.groupBoxAuthenticationStatus.TabStop = false;
            this.groupBoxAuthenticationStatus.Text = "Authentication Status";
            // 
            // labelIsAuthenticated
            // 
            this.labelIsAuthenticated.AutoSize = true;
            this.labelIsAuthenticated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelIsAuthenticated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelIsAuthenticated.Location = new System.Drawing.Point(6, 26);
            this.labelIsAuthenticated.Name = "labelIsAuthenticated";
            this.labelIsAuthenticated.Size = new System.Drawing.Size(95, 18);
            this.labelIsAuthenticated.TabIndex = 0;
            this.labelIsAuthenticated.Text = "Not logged in";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Guild Suite";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // groupBoxWoWConfiguration
            // 
            this.groupBoxWoWConfiguration.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxWoWConfiguration.Controls.Add(this.buttonBrowseToClassicFolder);
            this.groupBoxWoWConfiguration.Controls.Add(this.textBoxClassicDir);
            this.groupBoxWoWConfiguration.Controls.Add(this.label7);
            this.groupBoxWoWConfiguration.Controls.Add(this.label6);
            this.groupBoxWoWConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxWoWConfiguration.ForeColor = System.Drawing.Color.White;
            this.groupBoxWoWConfiguration.Location = new System.Drawing.Point(276, 130);
            this.groupBoxWoWConfiguration.Name = "groupBoxWoWConfiguration";
            this.groupBoxWoWConfiguration.Size = new System.Drawing.Size(256, 105);
            this.groupBoxWoWConfiguration.TabIndex = 8;
            this.groupBoxWoWConfiguration.TabStop = false;
            this.groupBoxWoWConfiguration.Text = "WoW Settings";
            // 
            // labelAddonIsInstalled
            // 
            this.labelAddonIsInstalled.AutoSize = true;
            this.labelAddonIsInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddonIsInstalled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelAddonIsInstalled.Location = new System.Drawing.Point(6, 44);
            this.labelAddonIsInstalled.Name = "labelAddonIsInstalled";
            this.labelAddonIsInstalled.Size = new System.Drawing.Size(143, 16);
            this.labelAddonIsInstalled.TabIndex = 10;
            this.labelAddonIsInstalled.Text = "Version installed: none";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Addon Status";
            // 
            // buttonBrowseToClassicFolder
            // 
            this.buttonBrowseToClassicFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.buttonBrowseToClassicFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBrowseToClassicFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.buttonBrowseToClassicFolder.Location = new System.Drawing.Point(175, 63);
            this.buttonBrowseToClassicFolder.Name = "buttonBrowseToClassicFolder";
            this.buttonBrowseToClassicFolder.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseToClassicFolder.TabIndex = 8;
            this.buttonBrowseToClassicFolder.Text = "Browse...";
            this.buttonBrowseToClassicFolder.UseVisualStyleBackColor = false;
            this.buttonBrowseToClassicFolder.Click += new System.EventHandler(this.buttonBrowseToClassicFolder_Click);
            // 
            // textBoxClassicDir
            // 
            this.textBoxClassicDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.textBoxClassicDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClassicDir.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClassicDir.ForeColor = System.Drawing.Color.White;
            this.textBoxClassicDir.Location = new System.Drawing.Point(7, 64);
            this.textBoxClassicDir.Name = "textBoxClassicDir";
            this.textBoxClassicDir.ReadOnly = true;
            this.textBoxClassicDir.Size = new System.Drawing.Size(162, 25);
            this.textBoxClassicDir.TabIndex = 7;
            this.textBoxClassicDir.Click += new System.EventHandler(this.buttonBrowseToClassicFolder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "This should end in `_classic_`";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(7, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "WoW Classic Directory";
            // 
            // folderBrowserDialogWoWDirectory
            // 
            this.folderBrowserDialogWoWDirectory.Description = "Select your WoW Classic directory. This should end in `_classic_`.";
            this.folderBrowserDialogWoWDirectory.RootFolder = System.Environment.SpecialFolder.ProgramFilesX86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Accredited Bank Characters";
            // 
            // labelBankersList
            // 
            this.labelBankersList.AutoSize = true;
            this.labelBankersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBankersList.Location = new System.Drawing.Point(6, 89);
            this.labelBankersList.Name = "labelBankersList";
            this.labelBankersList.Size = new System.Drawing.Size(46, 16);
            this.labelBankersList.TabIndex = 12;
            this.labelBankersList.Text = "(none)";
            // 
            // groupBoxGuildBank
            // 
            this.groupBoxGuildBank.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxGuildBank.Controls.Add(this.labelBankersList);
            this.groupBoxGuildBank.Controls.Add(this.label8);
            this.groupBoxGuildBank.Controls.Add(this.label9);
            this.groupBoxGuildBank.Controls.Add(this.labelAddonIsInstalled);
            this.groupBoxGuildBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxGuildBank.ForeColor = System.Drawing.Color.White;
            this.groupBoxGuildBank.Location = new System.Drawing.Point(276, 242);
            this.groupBoxGuildBank.Name = "groupBoxGuildBank";
            this.groupBoxGuildBank.Size = new System.Drawing.Size(256, 280);
            this.groupBoxGuildBank.TabIndex = 9;
            this.groupBoxGuildBank.TabStop = false;
            this.groupBoxGuildBank.Text = "Guild Bank Settings";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.BackgroundImage = global::DesktopClient.Properties.Resources.bg_brown_texture_repeat;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.groupBoxGuildBank);
            this.Controls.Add(this.groupBoxWoWConfiguration);
            this.Controls.Add(this.groupBoxAuthenticationStatus);
            this.Controls.Add(this.groupBoxAuthenticationSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Guild Suite";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxAuthenticationSettings.ResumeLayout(false);
            this.groupBoxAuthenticationSettings.PerformLayout();
            this.groupBoxAuthenticationStatus.ResumeLayout(false);
            this.groupBoxAuthenticationStatus.PerformLayout();
            this.groupBoxWoWConfiguration.ResumeLayout(false);
            this.groupBoxWoWConfiguration.PerformLayout();
            this.groupBoxGuildBank.ResumeLayout(false);
            this.groupBoxGuildBank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutThisProgramToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.GroupBox groupBoxAuthenticationSettings;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRedirectUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAuthenticationSettingsSave;
        private System.Windows.Forms.GroupBox groupBoxAuthenticationStatus;
        private System.Windows.Forms.Label labelIsAuthenticated;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBoxWoWConfiguration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWoWDirectory;
        private System.Windows.Forms.Button buttonBrowseToClassicFolder;
        private System.Windows.Forms.TextBox textBoxClassicDir;
        private System.Windows.Forms.Label labelAddonIsInstalled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelBankersList;
        private System.Windows.Forms.GroupBox groupBoxGuildBank;
    }
}

