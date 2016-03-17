using System;
using System.Net.Mime;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FotoABIld.Droid
{
	[Activity (Label = "FotoABIld.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.MainFrame);

		    Button orderButton = FindViewById<Button>(Resource.Id.orderButton);
		    Button historyButton = FindViewById<Button>(Resource.Id.historyButton);
            var historyText = FindViewById<EditText>(Resource.Id.HistoryText);
		    var orderText = FindViewById<EditText>(Resource.Id.OrderText);

            orderButton.Click += OrderButton_Click;
		    historyButton.Click += HistoryButton_Click;
		    historyText.Click += HistoryButton_Click;
		    orderText.Click += OrderButton_Click;

            var menu = FindViewById<FlyOutContainer>(Resource.Id.BaseContainer);
            var menuButton = FindViewById<ImageView>(Resource.Id.FlyOutMenuButton);
		    var homeText = FindViewById<EditText>(Resource.Id.HomeText);
		    menuButton.Click += (sender, e) => {
		                                           menu.AnimatedOpened = !menu.AnimatedOpened; };

            homeText.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };


        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ChoosePicturesActivity));
            StartActivity(intent);
        }

	    private void HistoryButton_Click(object sender, EventArgs e)
	    {
	        var history = new Intent(this, typeof(HistoryActivity));
            StartActivity(history);
	    }

    }
}


