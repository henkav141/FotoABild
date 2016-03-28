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
using Java.IO;
using Lyft.Scissors;

namespace FotoABIld.Droid
{
    [Activity(Label = "CropImageActivity")]
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
            var cropView = FindViewById<CropView>(Resource.Id.crop_view);
            
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            cancelButton.Click += CancelButton_Click;
            //doneButton.Click +=;
            var sizeHeight = cropView.ViewportHeight;
            var sizeWidth = cropView.ViewportWidth;
            position = Intent.GetStringExtra("image");


            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                cropView.SetImageBitmap(bitMap);
                
            }


            
            sizeHeight = 10;
            sizeWidth = 15;





        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var edit = new Intent(this, typeof(EditPictureActivity));
            StartActivity(edit);
        }

    }
}