using MoonSharp.Interpreter;
using Newtonsoft.Json;
using DesktopClient.WoW;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesktopClient
{
	public class GuildBankAddon
	{
		private readonly ApiClient ApiClient;
		public string AddonDirectory;
		public string WtfDirectory;
		public string Version = "none";

		public GuildBankAddon(string classicDir, ApiClient apiClient)
		{
			AddonDirectory = classicDir + "\\Interface\\Addons\\GuildBank";
			WtfDirectory = classicDir + "\\WTF\\Account\\474839284#1\\Pyrewood Village";
			ApiClient = apiClient;

			if (IsInstalled())
			{
				Version = File.ReadAllText(AddonDirectory + "\\version");
			}
		}

		public bool IsInstalled()
		{
			return File.Exists(AddonDirectory + "\\version");
		}

		public async void Watch()
		{
			if (Directory.Exists(WtfDirectory))
			{
				List<Banker> bankers = await ApiClient.GetBankersAsync();
				List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();

				bankers.ForEach(banker =>
				{
					var savedVariablesDir = $"{WtfDirectory}\\{banker.name}\\SavedVariables";

					// Check that the saved variables file exists...
					if (Directory.Exists(savedVariablesDir))
					{
						FileSystemWatcher watcher = new FileSystemWatcher();

						watcher.Path = savedVariablesDir;

						// Watch for changes in LastAccess and LastWrite times, and
						// the renaming of files or directories...
						watcher.NotifyFilter = NotifyFilters.LastAccess
											 | NotifyFilters.LastWrite;

						// Only watch the specific file we want...
						watcher.Filter = "GuildBank.lua";

						// Add event handlers...
						watcher.Changed += new FileSystemEventHandler(BankerFileOnChanged);
						watcher.Created += new FileSystemEventHandler(BankerFileOnChanged);
						watcher.Deleted += new FileSystemEventHandler(BankerFileOnChanged);

						// Begin watching...
						watcher.EnableRaisingEvents = true;
						watchers.Add(watcher);
					}
				});
			}
		}

		private void BankerFileOnChanged(object source, FileSystemEventArgs e)
		{
			Stock stock = new Stock();
			Script s = new Script(CoreModules.Preset_Complete);
			DynValue dv = s.DoString(File.ReadAllText(e.FullPath) + "\nreturn Stock;");

			// Process the mailbox...
			Table mailbox = dv.Table.Get("Mail").Table;
			foreach (var envelope in mailbox.Values)
			{
				var items = envelope.Table;
				foreach (var itemTable in items.Values)
				{
					Item itemObject = new Item();
					itemObject.mail = (int)itemTable.Table.Get("mail").CastToNumber();
					itemObject.count = (int)itemTable.Table.Get("count").CastToNumber();
					itemObject.slot = (int)itemTable.Table.Get("slot").CastToNumber();
					itemObject.id = (int)itemTable.Table.Get("id").CastToNumber();
					itemObject.owner = itemTable.Table.Get("owner").CastToString();
					itemObject.name = itemTable.Table.Get("name").CastToString();
					itemObject.link = itemTable.Table.Get("link").CastToString();
					stock.Mail.Add(itemObject);
				}
			}

			// Process the bags and bank...
			Table bags = dv.Table.Get("Bags").Table;
			foreach(var bag in bags.Values)
			{
				var items = bag.Table;
				foreach (var itemTable in items.Values)
				{
					Item itemObject  = new Item();
					itemObject.bag   = (int)itemTable.Table.Get("bag").CastToNumber();
					itemObject.count = (int)itemTable.Table.Get("count").CastToNumber();
					itemObject.slot  = (int)itemTable.Table.Get("slot").CastToNumber();
					itemObject.id    = (int)itemTable.Table.Get("id").CastToNumber();
					itemObject.owner = itemTable.Table.Get("owner").CastToString();
					itemObject.name  = itemTable.Table.Get("name").CastToString();
					itemObject.link  = itemTable.Table.Get("link").CastToString();
					stock.Bags.Add(itemObject);
				}
			}

			// Organise the data and convert into JSON...
			String stockAsJson = stock.ToJson();

			// Prepare the API request...

		}
	}
}
