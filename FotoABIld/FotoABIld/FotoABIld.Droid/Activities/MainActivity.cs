using System;
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
    [Activity(Theme = "@style/AppTheme",Label = "FotoABIld.Droid", MainLauncher = true, Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        private string[] drawerItems;
        private DrawerLayout drawerLayout;
        private ListView drawerListView;
        private ActionBarDrawerToggle drawerToggle;

        protected override void OnCreate (Bundle bundle)
		{
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            

			SetContentView (Resource.Layout.Main);

		    Button orderButton = FindViewById<Button>(Resource.Id.orderButton);
		    Button historyButton = FindViewById<Button>(Resource.Id.historyButton);

		    
            orderButton.Click += OrderButton_Click;
		    historyButton.Click += HistoryButton_Click;

            

            //menu = FindViewById<FlyOutContainer>(Resource.Id.BaseContainer);
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
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            
            drawerItems = new []{"Hem","Beställ Kort", "Tidigare beställningar", "Priser och storlekar", "Hjälp" };
            drawerListView = FindViewById<ListView>(Resource.Id.left_drawer);
            
            
            drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.drawer_list_item,drawerItems);
            drawerListView.ItemClick += DrawerListView_ItemClick;
            drawerLayout = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);
            

            drawerToggle = new ActionBarDrawerToggle(
                this,
                drawerLayout,
                toolbar,
                Resource.String.hello,
                Resource.String.app_name
                );
            drawerToggle.SyncState();
            



		}

        private void DrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent;
            switch (e.Position)
            {
                case 0:
                    drawerLayout.CloseDrawers();
                    break;
                case 1:
                    intent = new Intent(this, typeof(ChoosePicturesActivity));
                    StartActivity(intent);
                    break;
                case 2:
                    intent = new Intent(this, typeof(HistoryActivity));
                    StartActivity(intent);
                    break;
                case 3:
                    intent = new Intent(this, typeof(PricesSizesActivity));
                    StartActivity(intent);
                       break;
                case 4:
                    intent = new Intent(this, typeof(HelpActivity));
                    StartActivity(intent);
                    break;
            }
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


