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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainViewSwitcher = new System.Windows.Forms.TabControl();
            this.AuthenticationPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.MainViewSwitcher.SuspendLayout();
            this.AuthenticationPage.SuspendLayout();
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
            // MainViewSwitcher
            // 
            this.MainViewSwitcher.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.MainViewSwitcher.Controls.Add(this.AuthenticationPage);
            this.MainViewSwitcher.Controls.Add(this.tabPage2);
            this.MainViewSwitcher.Location = new System.Drawing.Point(0, 24);
            this.MainViewSwitcher.Margin = new System.Windows.Forms.Padding(0);
            this.MainViewSwitcher.Name = "MainViewSwitcher";
            this.MainViewSwitcher.Padding = new System.Drawing.Point(0, 0);
            this.MainViewSwitcher.SelectedIndex = 0;
            this.MainViewSwitcher.Size = new System.Drawing.Size(800, 425);
            this.MainViewSwitcher.TabIndex = 1;
            // 
            // AuthenticationPage
            // 
            this.AuthenticationPage.BackgroundImage = global::DesktopClient.Properties.Resources.bg_brown_texture_repeat;
            this.AuthenticationPage.Controls.Add(this.linkLabel1);
            this.AuthenticationPage.Location = new System.Drawing.Point(4, 4);
            this.AuthenticationPage.Name = "AuthenticationPage";
            this.AuthenticationPage.Padding = new System.Windows.Forms.Padding(3);
            this.AuthenticationPage.Size = new System.Drawing.Size(792, 399);
            this.AuthenticationPage.TabIndex = 0;
            this.AuthenticationPage.Text = "AuthenticationPage";
            this.AuthenticationPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(92, 68);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(696, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Welcome! To authenticate with the web server, please go to https://theorder.gg/in" +
    "ner-circle/guild-bank/clients and copy the Client ID and Secret.";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.BackgroundImage = global::DesktopClient.Properties.Resources.bg_brown_texture_repeat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainViewSwitcher);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "The Order";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainViewSwitcher.ResumeLayout(false);
            this.AuthenticationPage.ResumeLayout(false);
            this.AuthenticationPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutThisProgramToolStripMenuItem;
        private System.Windows.Forms.TabControl MainViewSwitcher;
        private System.Windows.Forms.TabPage AuthenticationPage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

