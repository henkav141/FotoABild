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
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            cancelButton.Click += CancelButton_Click;
            //doneButton.Click +=;            

            //hämtar informationen om bilden (storlek, sökväg till exempel)från föregående skärm.
            picture = (PictureProperties)Intent.GetParcelableExtra("image");
            position = picture.FilePath;
            size = picture.Size;

            Button cropButton = FindViewById<Button>(Resource.Id.cropbutton1);
            cropButton.Click += delegate { finalView.SetImageBitmap(cropView.CroppedBitmap); };
            
            Button rotateButton = FindViewById<Button>(Resource.Id.rotateButton);
            rotateButton.Click += delegate { cropView.RotateImage(CropImageView.RotateDegrees.Rotate90d); };


            
            //sätter ration för bilden genom att hämta värden från dictionarymetoden GetRatio.
            dictionary = GetRatio();
            cropView.SetCustomRatio(dictionary["height"], dictionary["width"]);

            Button rotateCropViewButton = FindViewById<Button>(Resource.Id.rotateCropView);
            rotateCropViewButton.Click += RotateCropView;

            //sätter bildens sökväg i en bitmap, så att bilden visas på skärmen.
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
        //Metod för att hämta ut värdena från spinnern där man väljer storlek på bilden (10x15 till exempel blir två intvärden, 10 och 15).
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