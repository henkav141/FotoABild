using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid
{
    [Activity(Label = "PricesSizesActivity",ConfigurationChanges = ConfigChanges.Orientation,ScreenOrientation = ScreenOrientation.Portrait)]
    public class PricesSizesActivity : AppCompatActivity
    {
        private Toolbar toolbar ;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PricesSizes);
            Init();

            // Create your application here
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        //Loads views and the StringHTML from the Resources/String folder to load HTML.
        private void Init()
        {
            var text = FindViewById<TextView>(Resource.Id.pricetext);
            var htmlasstring = GetString(Resource.String.priceandsize);
            var htmlSpanned = Html.FromHtml(htmlasstring);
            text.SetText(htmlSpanned,TextView.BufferType.Editable);
            text.Enabled = false;
            var backButton = FindViewById<Button>(Resource.Id.BackButton);
            backButton.Click += BackButtonOnClick;
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        private void BackButtonOnClick(object sender, EventArgs eventArgs)
        {
            Finish();
        }
    }
}