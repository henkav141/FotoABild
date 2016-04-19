﻿using System;
using System.Net.Mime;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace FotoABIld.Droid
{
    [Activity(Label = "FotoABIld.Droid", MainLauncher = true, Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
	    private FlyOutContainer menu;

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
		    var helpText = FindViewById<EditText>(Resource.Id.HelpText);
		    var priceText = FindViewById<EditText>(Resource.Id.PriceText);
		    
            orderButton.Click += OrderButton_Click;
		    historyButton.Click += HistoryButton_Click;
		    historyText.Click += HistoryButton_Click;
		    orderText.Click += OrderButton_Click;
		    helpText.Click += HelpButton_Click;
		    priceText.Click += priceText_Click;
            

            menu = FindViewById<FlyOutContainer>(Resource.Id.BaseContainer);
            var menuButton = FindViewById<ImageView>(Resource.Id.FlyOutMenuButton);
		    var homeText = FindViewById<EditText>(Resource.Id.HomeText);
		    menuButton.Click += (sender, e) => {
		                                           menu.AnimatedOpened = !menu.AnimatedOpened; };

            homeText.Click += (sender, e) =>
            {
                if (!menu.AnimatedOpened) return;
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

	    private void HelpButton_Click(object sender, EventArgs e)
	    {
            if (!menu.AnimatedOpened) return;
	        var help = new Intent(this, typeof(HelpActivity));
            StartActivity(help);
	    }

	    private void priceText_Click(object sender, EventArgs e)
	    {
	        if (!menu.AnimatedOpened) return;
	        var price = new Intent(this, typeof (PricesSizesActivity));
	        StartActivity(price);
	    }

    }
}

