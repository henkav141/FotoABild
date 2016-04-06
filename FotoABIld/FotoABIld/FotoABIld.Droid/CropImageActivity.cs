using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Lyft.Scissors;
using Com.Isseiaoki.Simplecropview;

namespace FotoABIld.Droid
{
    [Activity(Label = "CropImageActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class CropImageActivity : Activity
    {
        private PictureProperties picture;
        private int amount;
        private int index;
        private string position;
        private string size;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CropImage);
            Init();
            
        }

        private void Init()
        {
            var cropView = FindViewById<CropImageView>(Resource.Id.cropImageView);
            var finalView = FindViewById<ImageView>(Resource.Id.croppedImageView);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            cancelButton.Click += CancelButton_Click;
            //doneButton.Click +=;            
            position = Intent.GetStringExtra("image");

            Button cropButton = FindViewById<Button>(Resource.Id.cropbutton1);
            cropButton.Click += delegate { finalView.SetImageBitmap(cropView.CroppedBitmap); };


            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                cropView.SetImageBitmap(bitMap);

            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var edit = new Intent(this, typeof(EditPictureActivity));
            StartActivity(edit);
        }

    }
}