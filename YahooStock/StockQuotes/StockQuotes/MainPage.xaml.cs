using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics;

using Xamarin.Forms;

namespace StockQuotes
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent();
            goButton.Clicked += GetQuoteButtonClicked;
		}

        async void GetQuoteButtonClicked(object sender, EventArgs e)
        {
            string q = "?";
            string  line = quoteBox.Text;

            goButton.AnchorY = 0.1;

            Task<string> getStringTask = updateStatusLabel(line); //.ConfigureAwait(false);

            goButton.RelRotateTo(180, 1000);

            q = await getStringTask;
            statusText.Text = q;

        }

        async Task<string> updateStatusLabel(string Ticker)
        {
            string quote = await StockReporting.GetQuoteLatest(Ticker);
            return quote;
           // Device.BeginInvokeOnMainThread(() => statusText.Text = quote);           
        }


    }
}
