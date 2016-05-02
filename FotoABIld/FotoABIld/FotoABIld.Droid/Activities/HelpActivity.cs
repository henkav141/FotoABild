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
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid
{
    [Activity(Label = "HelpActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class HelpActivity : AppCompatActivity
    {
        private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.HelpPage);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);

            cancelButton.Click += CancelButton_Click;
            Init();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void Init()
        {
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var home = new Intent(this, typeof(MainActivity));
            StartActivity(home);
        }
    }
}