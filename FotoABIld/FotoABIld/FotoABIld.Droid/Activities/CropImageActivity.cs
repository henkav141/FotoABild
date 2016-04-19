using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Lyft.Scissors;
using Com.Isseiaoki.Simplecropview;
using Newtonsoft.Json;
using Environment = System.Environment;
using File = Java.IO.File;

namespace FotoABIld.Droid
{
    [Activity(Label = "CropImageActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class CropImageActivity : Activity
    {
        private Pictures picture;
        private int amount;
        private int index;
        private string position;
        private string size;
        private CropImageView cropView;
        private bool highlightView = true;
        private Dictionary<string, int> dictionary; 
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CropImage);
            Init();
            
        }

        private void Init()
        {
            cropView = FindViewById<CropImageView>(Resource.Id.cropImageView);
            var finalView = FindViewById<ImageView>(Resource.Id.croppedImageView);
            cropView.SetHandleShowMode(CropImageView.ShowMode.ShowOnTouch);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            doneButton.Click += doneButton_Click;

            
            // Gets information about the image (size and path for example) from the previous screen.
            //
            picture = JsonConvert.DeserializeObject<Pictures>(Intent.GetStringExtra("image"));
            position = picture.FilePath;
            size = picture.Size;

            var cropButton = FindViewById<Button>(Resource.Id.cropbutton1);
            cropButton.Click += delegate { finalView.SetImageBitmap(cropView.CroppedBitmap); };
            
            var rotateButton = FindViewById<Button>(Resource.Id.rotateButton);
            rotateButton.Click += delegate { cropView.RotateImage(CropImageView.RotateDegrees.Rotate90d); };


            //Sets the aspect ration for the image by getting values from the dictionary method GetRatio.
            dictionary = GetRatio();
            cropView.SetCustomRatio(dictionary["height"], dictionary["width"]);

            Button rotateCropViewButton = FindViewById<Button>(Resource.Id.rotateCropView);
            rotateCropViewButton.Click += RotateCropView;

            //Sets the image path to a bitmap, so that the picture displays on the screen.
            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                cropView.SetImageBitmap(bitMap);

            }

        }
        //Rotates the highlightview on a click.
        private void RotateCropView(object sender, EventArgs e)
        {
            if (highlightView)
            {
                cropView.SetCustomRatio(dictionary["width"], dictionary["height"]);
                highlightView = false;
            }
            else
            {
                cropView.SetCustomRatio(dictionary["height"], dictionary["width"]);
                highlightView = true;
            }
        }

        void ExportBitmapAsJpeg(Bitmap bitmap)
        {
            var sdCardPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = System.IO.Path.Combine(sdCardPath, "cropped.jpeg");
            var stream = new FileStream(filePath, FileMode.Create);
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            stream.Close();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            ExportBitmapAsJpeg(cropView.CroppedBitmap);
            SetResult(Result.Ok);
            Finish();
        }



        //Method for getting the values from the choose size spinner (10x15 becomes two int values, 10 and 15).
        private Dictionary<string, int> GetRatio()
        {
            var dictionary = new Dictionary<string, int>();
            switch (size)
            {
                case "10x15":
                    dictionary.Add("height", 10);
                    dictionary.Add("width", 15);
                    break;
                case "11x15":
                    dictionary.Add("height", 11);
                    dictionary.Add("width", 15);
                    break;
                case "13x18(vit kant)":
                    dictionary.Add("height", 13);
                    dictionary.Add("width", 18);
                    break;
                case "15x21":
                    dictionary.Add("height", 15);
                    dictionary.Add("width", 21);
                    break;
                case "18x24(vit kant)":
                    dictionary.Add("height", 18);
                    dictionary.Add("width", 24);
                    break;
                case "20x30":
                    dictionary.Add("height", 20);
                    dictionary.Add("width", 30);
                    break;
                case "24x30(vit kant)":
                    dictionary.Add("height", 24);
                    dictionary.Add("width", 30);
                    break;
                case "25x38":
                    dictionary.Add("height", 25);
                    dictionary.Add("width", 38);
                    break;
            }
            return dictionary;
        }

    }
}