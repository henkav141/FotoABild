﻿using System;
using System.Net.Mime;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace FotoABIld.Droid
{
    [Activity(Label = "FotoABIld.Droid", MainLauncher = true, Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : AppCompatActivity
    {
	    private FlyOutContainer menu;
        private Toolbar toolbar;
        private string[] drawerItems;
        private DrawerLayout drawerLayout;
        private ListView drawerListView;
        private ActionBarDrawerToggle drawerToggle;

        protected override void OnCreate (Bundle bundle)
		{
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            

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
      //      var menuButton = FindViewById<ImageView>(Resource.Id.FlyOutMenuButton);
		    //var homeText = FindViewById<EditText>(Resource.Id.HomeText);
		    //menuButton.Click += (sender, e) => {
		    //                                       menu.AnimatedOpened = !menu.AnimatedOpened; };

            //homeText.Click += (sender, e) =>
            //{
            //    if (!menu.AnimatedOpened) return;
            //    menu.AnimatedOpened = !menu.AnimatedOpened;
            //};
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            drawerItems = new []{"Hem","Beställ Kort", "Tidigare beställningar", "Priser och storlekar", "Hjälp" };
            drawerListView = FindViewById<ListView>(Resource.Id.left_drawer);
            
            
            drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.drawer_list_item,drawerItems);
            drawerLayout = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);
            drawerToggle = new ActionBarDrawerToggle(
                this,
                drawerLayout,
                toolbar,
                Resource.String.hello,
                Resource.String.app_name
                );




		}
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
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
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.action_help:
                    return true;

                default:

                    return OnOptionsItemSelected(item);
            }
        }

    }
}


