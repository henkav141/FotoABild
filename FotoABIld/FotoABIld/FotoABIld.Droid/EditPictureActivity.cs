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
    [Activity(Label = "EditPictureActivity")]
    public class EditPictureActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);
           // Create your application here
            
            
            var position = Intent.GetIntExtra("id",3);
            var imageAdapter = new ImageAdapter(this);

            var imageView = FindViewById<ImageView>(Resource.Id.full_image_view);
            imageView.SetImageResource(imageAdapter.thumbIds[position]);
        }
    }
}