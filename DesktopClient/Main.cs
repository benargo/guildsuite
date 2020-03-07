using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DesktopClient
{
    public partial class Main : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection PrivateFonts = new PrivateFontCollection();

        private Font RalewayFont;

        private readonly OAuthClient OAuthClient;

        public Main()
        {
            InitializeComponent();
            LoadRalewayFont();

            // Initialise the OAuth client...
            OAuthClient = new OAuthClient(
                Properties.Settings.Default.clientId,
                Properties.Settings.Default.clientSecret,
                Properties.Settings.Default.redirectUrl
            );

            // Obtain an Authorization Token...
            _ = OAuthClient.GetOAuthTokenAsync(this);
        }

        private void LoadRalewayFont()
        {
            // Load the Raleway font into the application...
            byte[] FontResource = Properties.Resources.Raleway_Regular;
            System.IntPtr data = Marshal.AllocCoTaskMem((int)FontResource.Length);
            Marshal.Copy(FontResource, 0, data, (int)FontResource.Length);
            PrivateFonts.AddMemoryFont(data, (int)FontResource.Length);
            Marshal.FreeCoTaskMem(data);
            RalewayFont = new Font(PrivateFonts.Families[0], 22);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Update text...
            textBoxClientId.Text = Properties.Settings.Default.clientId.ToString();
            textBoxClientSecret.Text = Properties.Settings.Default.clientSecret;
            textBoxRedirectUrl.Text = Properties.Settings.Default.redirectUrl;

            // Render fonts...
            buttonAuthenticationSettingsSave.Font = RalewayFont;
            label1.Font = RalewayFont;
            label2.Font = RalewayFont;
            label3.Font = RalewayFont;
            label4.Font = RalewayFont;
            linkLabel1.Font = RalewayFont;
        }

        private void textBoxClientId_TextChanged(object sender, EventArgs e)
        {
            var newClientId = int.Parse(textBoxClientId.Text);

            try {
                Properties.Settings.Default.clientId = newClientId;
            }
            catch (FormatException exception)
            {
                textBoxClientId.Text = null;
            }

            OAuthClient.clientId = newClientId;
            Properties.Settings.Default.Save();
        }

        private void textBoxClientSecret_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clientSecret = textBoxClientSecret.Text;
            OAuthClient.clientSecret = textBoxClientSecret.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxRedirectUrl_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.redirectUrl = textBoxRedirectUrl.Text;
            OAuthClient.redirectUrl = textBoxRedirectUrl.Text;
            Properties.Settings.Default.Save();
        }

        private void buttonAuthenticationSettingsSave_Click(object sender, EventArgs e)
        {
            // Resave the settings to file...
            Properties.Settings.Default.Save();

            // Reauthenticate using the new settings...
            _ = OAuthClient.GetOAuthTokenAsync(this);
        }
    }
}
