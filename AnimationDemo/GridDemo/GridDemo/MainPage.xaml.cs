using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GridDemo
{
  /*  public static class Constants
    {
        public const double numRows = 7;
        public const double numCols = 7;
    }  */
    public partial class MainPage : ContentPage
    {
        public int LabelGridRow = 1;

        public int LabelRow
        {
            get
            {
                return LabelGridRow;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            GoButton.Clicked += StartAnimation;
            StopButton.Clicked += EndAnimation;
        }

        public void StartAnimation(object a, EventArgs e)
        {
            LabelGridRow = 3;

            //  MainGrid.Children.Clear(); //this clears everything

         //   Label1.AnchorX = 1;
         //   Label1.AnchorY = 1;
        }

        public void EndAnimation(object a, EventArgs e)
        {

        }



    }
}
