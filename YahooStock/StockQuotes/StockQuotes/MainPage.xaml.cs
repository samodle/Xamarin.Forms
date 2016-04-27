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

            string line = "";
            List<string> stockSymbols;
            //  Task<string> quoteTask; 
            string quote;

 
            line = quoteBox.Text;//THIS NEEDS TO BE TEXTBOX INPUT Console.ReadLine();


                stockSymbols = StringHelper.splitAtCommas(line);
                quote = await StockReporting.GetQuoteLatest(line);

            statusText.Text = quote;
            }


    }
}
