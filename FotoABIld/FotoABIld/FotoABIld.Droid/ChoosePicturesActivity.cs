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
using Uri = Android.Net.Uri;

namespace FotoABIld.Droid
{
    [Activity(Label = "ChoosePicturesActivity")]
    public class ChoosePicturesActivity : Activity
    {
        List<Android.Net.Uri> uriList = new List<Android.Net.Uri>();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ChoosePictures);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button chooseButton = FindViewById<Button>(Resource.Id.ChoosePicturesButton);


            cancelButton.Click += Cancelbutton_Click;
            chooseButton.Click += chooseButton_Click;
             


        }


        void chooseButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionPick);
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            intent.PutExtra(Intent.ExtraAllowMultiple, true);
            SetResult(Result.Ok,intent);
            StartActivityForResult(intent, 0);


        }

        void gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof (EditPictureActivity));
            i.PutExtra("id",e.Position);
            StartActivity(i);
            
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            if (requestCode == 0)
            {
                if (resultCode == Result.Ok)
                {
                        ClipData clipData = intent.ClipData;
                        for (int i = 0; i < intent.ClipData.ItemCount; i++)
                        {
                            var item = clipData.GetItemAt(i);
                            var uri = item.Uri;
                            uriList.Add(uri);
                    }
                        ImageAdapter imageAdapter = new ImageAdapter(this, uriList);
                        var gridview = FindViewById<GridView>(Resource.Id.gridview);
                        gridview.Adapter = imageAdapter;
                        gridview.ItemClick += gridview_ItemClick;
                }
            }
        }
    }
}
