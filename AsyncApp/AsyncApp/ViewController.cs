using System;
using UIKit;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using AVFoundation;

namespace AsyncApp
{
	public class ViewController : UITableViewController
	{

		static int refreshbuttoncount;

		Thread uiThread;
		public ViewController ()
		{
			uiThread = Thread.CurrentThread;
			WhatThreadAmI ();
			this.NavigationItem.RightBarButtonItem =
					new UIBarButtonItem (UIBarButtonSystemItem.Refresh, async (s, e) => {
						refreshbuttoncount++;

						Console.WriteLine ("**************");
						Console.WriteLine ("**************888");
						Console.WriteLine ("**************");
						Console.WriteLine ($"Refrehs button clicked {refreshbuttoncount}");

						Console.WriteLine ("**************");
						Console.WriteLine ("**************888");
						Console.WriteLine ("**************");
						await Refresh ();
						Console.WriteLine ("Finished Refresh");
						refreshbuttoncount--;
					});

			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Done,async (s, e) => {
				await Speak ("Hello Everyone!!!");
			});
		}

		async Task Speak (string text)
		{
			var tcs = new TaskCompletionSource<bool> ();
			var synth = new AVSpeechSynthesizer ();
			synth.SpeakUtterance (new AVSpeechUtterance(text) {

			});
			EventHandler<AVSpeechSynthesizerUteranceEventArgs> del = null;
			del  = (object sender, AVSpeechSynthesizerUteranceEventArgs e) => {
				tcs.TrySetResult (true);
				synth.DidFinishSpeechUtterance -= del;
			};
			synth.DidFinishSpeechUtterance += del;
			await tcs.Task;
			Console.WriteLine ("We finished");
		}

		public override async void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			await Refresh ();
		}

		HttpClient client = new HttpClient ();
		List<Song> Songs = new List<Song> ();
		static int refreshCount = 0;
		Task refreshTask;
		public Task Refresh ()
		{
			if (refreshTask?.IsCompleted ?? true) {
				refreshTask = refresh ();
			}
			return refreshTask;
		}


		async Task refresh ()
		{
			refreshCount++;
			WhatThreadAmI ();
			Songs = await DownloadSongs ();
			WhatThreadAmI ();
			this.TableView.ReloadData ();
			refreshCount--;
		}


		async Task<List<Song>> DownloadSongs ()
		{
			var json = await client.GetStringAsync ("https://dl.dropboxusercontent.com/s/cv75h76pv9su7l4/songs-small.json").ConfigureAwait (false);
			WhatThreadAmI ();
			return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>> (json);


		}

		async Task<List<Song>> ParseJson (string json)
		{
			WhatThreadAmI ();
			return await Task.Run (() => {
				WhatThreadAmI ();
				return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>> (json);
			});
		}


		void WhatThreadAmI ([CallerMemberName] string method = "",[CallerLineNumber] int line = 0)
		{
			//Console.WriteLine ("**************");
			//Console.WriteLine ("**************888");
			//Console.WriteLine ("**************");
			Console.WriteLine ($"{method} - RefreshCount!!! {refreshCount} {IsMainThread}");
			//Console.WriteLine ("**************");
			//Console.WriteLine ("**************888");
			//Console.WriteLine ("******************");

		}

		public bool IsMainThread => uiThread == Thread.CurrentThread;


		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return Songs?.Count ?? 0;
		}
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("Cell") ??
								new UITableViewCell (UITableViewCellStyle.Subtitle, "Cell");
			var song = Songs [indexPath.Row];
			cell.TextLabel.Text = song.Title;
			cell.DetailTextLabel.Text = song.Artist;
			return cell;
		}
	}

	public class Song
	{

		[JsonProperty ("Artist")]
		public string Artist { get; set; }

		[JsonProperty ("Timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonProperty ("TrackId")]
		public string TrackId { get; set; }

		[JsonProperty ("Title")]
		public string Title { get; set; }
	}

}

