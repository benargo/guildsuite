using MoonSharp.Interpreter;
using Newtonsoft.Json;
using DesktopClient.WoW;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DesktopClient
{
	public class GuildBankAddon
	{
		public ApiClient ApiClient;

		// Directories...
		public string AddonDirectory;
		public string WtfDirectory;
		public string Version = "none";

		public GuildBankAddon(ApiClient apiClient)
		{
			ApiClient = apiClient;
		}

		public void SetDirectories(string classicDir)
		{
			if (classicDir.Length > 0)
			{
				AddonDirectory = classicDir + "\\Interface\\Addons\\GuildBank";
				WtfDirectory = classicDir + "\\WTF\\Account\\474839284#1\\Pyrewood Village";

				try
				{
					Version = File.ReadAllText(AddonDirectory + "\\version");
				}
				catch (FileNotFoundException)
				{
					Version = "none";
				}
			}
		}

		public bool IsInstalled()
		{
			return File.Exists(AddonDirectory + "\\version");
		}

		public void Watch(List<Banker> bankers)
		{
			// Check that the WTF directory exists, this is where the guild bank data is stored...
			if (Directory.Exists(WtfDirectory))
			{
				// Create an array of watchers to look for file changes...
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
			if (mailbox != null)
			{
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
						itemObject.banker_name = itemTable.Table.Get("banker_name").CastToString();
						itemObject.name = itemTable.Table.Get("name").CastToString();
						itemObject.link = itemTable.Table.Get("link").CastToString();
						stock.mail.Add(itemObject);
					}
				}
			}

			// Process the bags and bank...
			Table bags = dv.Table.Get("Bags").Table;
			foreach(var bag in bags.Values)
			{
				var items = bag.Table;
				foreach (var itemTable in items.Values)
				{
					// Create a new item instance...
					Item itemObject  = new Item();

					// Get the banker's name...
					itemObject.banker_name = itemTable.Table.Get("banker_name").CastToString();

					// Get the bag number...
					itemObject.bag   = (int)itemTable.Table.Get("bag").CastToNumber();

					// Get the slot number in this bag...
					itemObject.slot = (int)itemTable.Table.Get("slot").CastToNumber();

					// Get the item's ID number, if there is one...
					if (itemTable.Table.Get("id").IsNotNil())
					{
						itemObject.id = (int)itemTable.Table.Get("id").CastToNumber();
					}

					// Get the quantity of the item in this stack, if there are any...
					if (itemTable.Table.Get("count").IsNotNil())
					{
						itemObject.count = (int)itemTable.Table.Get("count").CastToNumber();
					}
					
					// Get the item's name, if there is one...
					if (itemTable.Table.Get("name").IsNotNil())
					{
						itemObject.name = itemTable.Table.Get("name").CastToString();
					}

					// Get the in-game link to the item, if there is one...
					if (itemTable.Table.Get("link").IsNotNil())
					{
						itemObject.link = itemTable.Table.Get("link").CastToString();
					}
	
					// Add the newly created object to the array...
					stock.bags.Add(itemObject);
				}
			}

			// Organise the data and convert into JSON...
			string stockAsJson = stock.ToJson();

			// Send the API request...
			stock.Post(ApiClient, stockAsJson);
		}
	}
}
