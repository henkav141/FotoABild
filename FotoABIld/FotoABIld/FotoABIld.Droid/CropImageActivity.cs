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
        private CropImageView cropView;
        private bool highlightView = true;
        private Dictionary<string, int> dictionary; 

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
            cropView = FindViewById<CropImageView>(Resource.Id.cropImageView);
            var finalView = FindViewById<ImageView>(Resource.Id.croppedImageView);
            cropView.SetHandleShowMode(CropImageView.ShowMode.ShowOnTouch);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            //doneButton.Click +=;            

            //h�mtar informationen om bilden (storlek, s�kv�g till exempel)fr�n f�reg�ende sk�rm.
            picture = (PictureProperties)Intent.GetParcelableExtra("image");
            position = picture.FilePath;
            size = picture.Size;

            Button cropButton = FindViewById<Button>(Resource.Id.cropbutton1);
            cropButton.Click += delegate { finalView.SetImageBitmap(cropView.CroppedBitmap); };
            
            Button rotateButton = FindViewById<Button>(Resource.Id.rotateButton);
            rotateButton.Click += delegate { cropView.RotateImage(CropImageView.RotateDegrees.Rotate90d); };


            
            //s�tter ration f�r bilden genom att h�mta v�rden fr�n dictionarymetoden GetRatio.
            dictionary = GetRatio();
            cropView.SetCustomRatio(dictionary["height"], dictionary["width"]);

            Button rotateCropViewButton = FindViewById<Button>(Resource.Id.rotateCropView);
            rotateCropViewButton.Click += RotateCropView;

            //s�tter bildens s�kv�g i en bitmap, s� att bilden visas p� sk�rmen.
            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                cropView.SetImageBitmap(bitMap);

            }

        }

        //roterar highlightView vid knapptryck.
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
        //Metod f�r att h�mta ut v�rdena fr�n spinnern d�r man v�ljer storlek p� bilden (10x15 till exempel blir tv� intv�rden, 10 och 15).
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