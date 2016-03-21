using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Cache.Memory.Impl;
using Com.Nostra13.Universalimageloader.Core;
using Com.Nostra13.Universalimageloader.Core.Assist;
using Java.IO;

namespace FotoABIld.Droid
{
    [Activity(Label = "EditPictureActivity")]
    public class EditPictureActivity : Activity


    {
        private ImageLoader imageLoader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);
           // Create your application here

            var position = Intent.GetStringExtra("single_path");
            var imageView = FindViewById<ImageView>(Resource.Id.edit_picture);
            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                imageView.SetImageBitmap(bitMap);
            }
            




        }

    }
}