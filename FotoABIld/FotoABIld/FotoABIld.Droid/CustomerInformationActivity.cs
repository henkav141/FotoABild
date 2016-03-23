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
    [Activity(Label = "CustomerInformationActivity")]
    public class CustomerInformationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerInformation);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button nextButton = FindViewById<Button>(Resource.Id.NextButton);

            cancelButton.Click += CancelButton_Click;
            nextButton.Click += NextButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var home = new Intent(this, typeof(MainActivity));
            StartActivity(home);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var next = new Intent(this, typeof(FinalizeActivity));
            StartActivity(next);
        }
    }
}