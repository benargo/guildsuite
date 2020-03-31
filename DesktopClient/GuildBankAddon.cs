using System;
using System.IO;

namespace DesktopClient
{
	public class GuildBankAddon
	{
		public string AddonDirectory;
		public string WtfDirectory;
		public string Version = "none";

		public GuildBankAddon(string classicDir)
		{
			AddonDirectory = classicDir + "\\Interface\\Addons\\GuildBank";
			WtfDirectory = classicDir + "\\WTF\\Account\\474839284#1\\Pyrewood Village";

			if (IsInstalled())
			{
				Version = File.ReadAllText(AddonDirectory + "\\version");
			}
		}

		public bool IsInstalled()
		{
			return File.Exists(AddonDirectory + "\\version");
		}

		public void Watch()
		{
			if (Directory.Exists(WtfDirectory))
			{

			}
		}
	}
}
