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
    [Activity(Label = "ChoosePicturesActivity")]
    public class ChoosePicturesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ChoosePictures);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            var gridview = FindViewById<GridView>(Resource.Id.gridview);

            gridview.Adapter = new ImageAdapter(this);

            gridview.ItemClick += gridview_ItemClick;

            //NumberPicker nr1 = FindViewById<NumberPicker>(Resource.Id.numberPicker1);
            //NumberPicker nr2 = FindViewById<NumberPicker>(Resource.Id.numberPicker2);

            //nr2.MaxValue = 20;
            //nr2.MinValue = 0;
            //nr2.Value = 0;
            //nr2.Selected = true;
            //nr1.MaxValue = 20;
            //nr1.MinValue = 0;
            //nr1.Value = 0;
            //nr1.Selected = false;
            cancelButton.Click += Cancelbutton_Click;

        }

        void gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            //Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }





    }
}
