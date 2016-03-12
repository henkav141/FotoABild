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
            cancelButton.Click += Cancelbutton_Click;

        }

        void gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof (EditPictureActivity));
            i.PutExtra("id",e.Position);
            StartActivity(i);
            //Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }





    }
}
