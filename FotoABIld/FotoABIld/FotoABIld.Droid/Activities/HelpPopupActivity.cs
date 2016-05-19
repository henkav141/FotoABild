using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FotoABIld.Droid.Activities
{
    [Activity(Label = "HelpPopupActivity", Theme= "@style/AppTheme.Popup")]
    public class HelpPopupActivity : Activity
    {
        private TextView text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PopUp);

            var displaymetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displaymetrics);

            var width = displaymetrics.WidthPixels;
            var height = displaymetrics.HeightPixels;

            Window.SetLayout((int) (0.8*width),(int) (0.5*height));

            text = FindViewById<TextView>(Resource.Id.popupText);
            text.Click += Text_Click;
            var htmlasstring = Intent.GetStringExtra("help");
            var htmlSpanned = Html.FromHtml(htmlasstring);
            text.SetText(htmlSpanned, TextView.BufferType.Spannable);
        }

        private void Text_Click(object sender, EventArgs e)
        {
            Finish();
        }


    }
}