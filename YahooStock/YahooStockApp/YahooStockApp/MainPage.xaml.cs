using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace YahooStockApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            goButton.Clicked += GetQuoteButtonClicked;
        }

        async void GetQuoteButtonClicked(object sender, EventArgs e)
        {
            string q = "?";
            string line = quoteBox.Text;

            goButton.AnchorY = 0.1;

            Task<string> getStringTask = updateStatusLabel(line); //.ConfigureAwait(false);

            await goButton.RelRotateTo(180, 1000);

            q = await getStringTask;
            statusText.Text = q;

            goButton.AnchorY = 0.1;
            await goButton.RelRotateTo(180, 1000);
        }

        async Task<string> updateStatusLabel(string Ticker)
        {
            string quote = await StockReporting.GetQuoteLatest(Ticker);
            return quote;
          
        }




    }
}
