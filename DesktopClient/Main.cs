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
using Newtonsoft.Json.Linq;

namespace DesktopClient
{
    public partial class Main : Form
    {
        // Required for font rendering. Do not touch!
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        // Fonts and colors
        private PrivateFontCollection PrivateFonts = new PrivateFontCollection();
        private Font RalewayFont10;
        private Font RalewayFont11;
        private Font RalewayFont12;
        private Font RalewayFont16;
        private Font RalewayFont20;
        private readonly Color SuccessColor = System.Drawing.Color.FromArgb(40, 167, 69);
        private readonly Color ErrorColor = System.Drawing.Color.FromArgb(220, 53, 69);

        // Required instances...
        private readonly ApiClient ApiClient;
        private readonly OAuthClient OAuthClient;
        private readonly GuildBankAddon GuildBankAddon;

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

            // Initailise the API client...
            ApiClient = new ApiClient();

            // Initialise the Guild Bank Addon class...
            GuildBankAddon = new GuildBankAddon(ApiClient);
            GuildBankAddon.SetDirectories(Properties.Settings.Default.wowClassicDir);
        }

        private void LoadRalewayFont()
        {
            // Load the Raleway font into the application...
            byte[] FontResource = Properties.Resources.Raleway_Regular;
            System.IntPtr data = Marshal.AllocCoTaskMem((int)FontResource.Length);
            Marshal.Copy(FontResource, 0, data, (int)FontResource.Length);
            PrivateFonts.AddMemoryFont(data, (int)FontResource.Length);
            Marshal.FreeCoTaskMem(data);
            RalewayFont10 = new Font(PrivateFonts.Families[0], 10);
            RalewayFont11 = new Font(PrivateFonts.Families[0], 11);
            RalewayFont12 = new Font(PrivateFonts.Families[0], 12);
            RalewayFont16 = new Font(PrivateFonts.Families[0], 16);
            RalewayFont20 = new Font(PrivateFonts.Families[0], 20);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Instantiating objects ...
            Log.LogTextBox = textBoxLog;

            // Update text...
            textBoxClientId.Text = Properties.Settings.Default.clientId.ToString();
            textBoxClientSecret.Text = Properties.Settings.Default.clientSecret;
            textBoxRedirectUrl.Text = Properties.Settings.Default.redirectUrl;
            textBoxClassicDir.Text = Properties.Settings.Default.wowClassicDir;

            // Render fonts...
            buttonLogin.Font = RalewayFont12;
            buttonBrowseToClassicFolder.Font = RalewayFont10;
            label1.Font = RalewayFont20;
            label2.Font = RalewayFont16;
            label3.Font = RalewayFont11;
            label4.Font = RalewayFont11;
            label5.Font = RalewayFont11;
            label6.Font = RalewayFont11;
            label7.Font = RalewayFont10;
            label8.Font = RalewayFont11;
            label9.Font = RalewayFont11;
            labelAddonIsInstalled.Font = RalewayFont10;
            labelBankersList.Font = RalewayFont10;
            labelIsAuthenticated.Font = RalewayFont12;
            linkLabel1.Font = RalewayFont11;

            // Attempt to authenticate...
            AuthenticateAsync();

            // Check if the addon is installed...
            if (GuildBankAddon.IsInstalled())
            {
                labelAddonIsInstalled.Text = $"Version installed: {GuildBankAddon.Version}";
                labelAddonIsInstalled.ForeColor = SuccessColor;
            }
        }
        private async void AuthenticateAsync()
        {
            // Authenticate if required...
            string authenticationCode = await OAuthClient.AuthenticateAsync();

            if (! string.IsNullOrEmpty(authenticationCode))
            {
                // Exchange the authentication code for an access token...
                string accessToken = await OAuthClient.GetAccessTokenAsync(authenticationCode);

                // Update the API client is authentication was successful...
                if (! string.IsNullOrEmpty(accessToken))
                {
                    ApiClient.SetAccessToken(accessToken);
                }
            }

            // Bring this app back to the foreground...
            Activate();

            // Update the label to show whether or not the user has authenticated correctly...
            labelIsAuthenticated_Update(OAuthClient.IsAuthenticated());

            // Update the list of bankers...
            GetBankersAsync();
        }

        public async void GetBankersAsync()
        {
            if (OAuthClient.IsAuthenticated())
            {
                try
                {
                    // Load the bankers from the API...
                    JObject response = await ApiClient.Get(ApiClient.BankersApiUrl);
                    JArray bankersArray = (JArray)response["bankers"];
                    List<Banker> bankers = bankersArray.ToObject<List<Banker>>();

                    // Update the label containing the list of bankers...
                    labelBankersList_Update(bankers);

                    // Begin watching the saved variables...
                    GuildBankAddon.Watch(bankers);
                }
                catch (NullReferenceException)
                {
                    // TODO: Implement logging...
                }
            } 
        }

        private void labelBankersList_Update(List<Banker> bankers)
        {
            // Reset the text back to being empty...
            labelBankersList.Text = "";

            // If the array of bankers has entries then loop over them and create a visible list.
            if (bankers.Count > 1)
            {
                bankers.ForEach(banker =>
                {
                    labelBankersList.Text += $"•  {banker.name}\r\n";
                });
            }
            else
            {
                labelBankersList.Text = "(none)";
            }
        }

        private void textBoxClientId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var newClientId = int.Parse(textBoxClientId.Text);
                Properties.Settings.Default.clientId = newClientId;

                OAuthClient.ClientId = newClientId;
                Properties.Settings.Default.Save();
            }
            catch (FormatException)
            {
                textBoxClientId.Text = null;
            }
        }

        private void textBoxClientSecret_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clientSecret = textBoxClientSecret.Text;
            OAuthClient.ClientSecret = textBoxClientSecret.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxRedirectUrl_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.redirectUrl = textBoxRedirectUrl.Text;
            OAuthClient.RedirectUrl = textBoxRedirectUrl.Text;
            Properties.Settings.Default.Save();
        }

        public void labelIsAuthenticated_Update(bool isLoggedIn)
        {
            // Set the logged in label...
            if (isLoggedIn)
            {
                labelIsAuthenticated.Text = "Logged in";
                labelIsAuthenticated.ForeColor = SuccessColor;
            }
            else
            {
                labelIsAuthenticated.Text = "Not logged in";
                labelIsAuthenticated.ForeColor = ErrorColor;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            // If the form is minimized hide it from the task bar
            // and show the system tray icon (represented by the NotifyIcon control)...
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void buttonBrowseToClassicFolder_Click(object sender, EventArgs e)
        {
            // Show the dialog that allows user to select a folder...
            DialogResult result = folderBrowserDialogWoWDirectory.ShowDialog();

            // If a folder is selected...
            if (result == DialogResult.OK)
            {
                string path = folderBrowserDialogWoWDirectory.SelectedPath.TrimEnd(new[] { '/', '\\' });

                textBoxClassicDir.Text = path;
                Properties.Settings.Default.wowClassicDir = path;
                Properties.Settings.Default.Save();

                // Update the directories...
                GuildBankAddon.SetDirectories(path);

                if (GuildBankAddon.IsInstalled())
                {
                    labelAddonIsInstalled.Text = $"Version installed: {GuildBankAddon.Version}";
                    labelAddonIsInstalled.ForeColor = SuccessColor;
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Resave the settings to file...
            Properties.Settings.Default.Save();

            // Reauthenticate using the new settings...
            AuthenticateAsync();
        }
    }
}
