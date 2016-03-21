using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FotoABIld.Droid
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.OrderHistory);

            Button homeButton = FindViewById<Button>(Resource.Id.HomeButton);

            homeButton.Click += homeButton_Click;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            var home = new Intent(this, typeof(MainActivity));
            StartActivity(home);
        }
    }
}