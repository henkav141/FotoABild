using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace FotoABildShared.Droid
{
    [Activity(Label = "PricesSizesActivity",ConfigurationChanges = ConfigChanges.Orientation,ScreenOrientation = ScreenOrientation.Portrait)]
    public class PricesSizesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PricesSizes);
            Init();

            // Create your application here
        }

        private void Init()
        {
            var text = FindViewById<TextView>(Resource.Id.pricetext);
            var htmlasstring = GetString(Resource.String.priceandsize);
            var htmlSpanned = Html.FromHtml(htmlasstring);
            text.SetText(htmlSpanned,TextView.BufferType.Editable);
            text.Enabled = false;
            var backButton = FindViewById<Button>(Resource.Id.BackButton);
            backButton.Click += BackButtonOnClick;
        }

        private void BackButtonOnClick(object sender, EventArgs eventArgs)
        {
            Finish();
        }
    }
}