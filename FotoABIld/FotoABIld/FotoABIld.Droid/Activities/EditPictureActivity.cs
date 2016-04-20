using System;
using System.Collections.Generic;
using System.IO;
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
using Com.Nostra13.Universalimageloader.Cache.Memory.Impl;
using Com.Nostra13.Universalimageloader.Core;
using Com.Nostra13.Universalimageloader.Core.Assist;
using Java.IO;
using Newtonsoft.Json;
using Environment = System.Environment;
using File = Java.IO.File;

namespace FotoABIld.Droid
{
    [Activity(Label = "EditPictureActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class EditPictureActivity : Activity


    {
        private ImageView imageView;
        private NumberPicker numberPicker;
        private Spinner spinner;
        private Pictures picture;
        private int amount;
        private int index;
        private string position;
        private string size;
        private string pictureName;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);
           // Create your application here

            Init();
            InitNumberPicker();
            InitSpinner();

        }

        private void Init()
        {
            imageView = FindViewById<ImageView>(Resource.Id.edit_picture);
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            Button cropButton = FindViewById<Button>(Resource.Id.cropButton);
            var copyButton = FindViewById<Button>(Resource.Id.copyButton);
            copyButton.Click += copyButton_Click;
            doneButton.Click += DoneButton_Click;
            cropButton.Click += CropButton_Click;

            picture = JsonConvert.DeserializeObject<Pictures>(Intent.GetStringExtra("picture"));
            position = picture.FilePath;
            amount = picture.Amount;
            size = picture.Size;
            pictureName = picture.Name;

            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                pictureName = imgFile.Name;
                imageView.SetImageBitmap(bitMap);
            }

        }
        //Creates a copy of the image wanted to have two of the same pictures with different properties
        void copyButton_Click(object sender, EventArgs e)
        {
            var copyImage = new Pictures(position,0,"10x15","");
            var bundle = new Bundle();
            var objectString = JsonConvert.SerializeObject(copyImage);
            bundle.PutString("picture", objectString);
            bundle.PutBoolean("bool",false);
            var intent = new Intent().PutExtra("bundle", bundle);
            SetResult(Result.Ok,intent);
            Finish();
        }
        
        private void DoneButton_Click(object sender, EventArgs e)
        {
            picture.Amount = numberPicker.Value;
            var bundle = new Bundle();
            var objectString = JsonConvert.SerializeObject(picture);
            bundle.PutString("picture",objectString);
            bundle.PutBoolean("bool", true);
            var intent = new Intent().PutExtra("bundle",bundle);
            SetResult(Result.Ok,intent);
            Finish();
        }

        private void CropButton_Click(object sender, EventArgs e)
        {
            var crop = new Intent(this, typeof(CropImageActivity));
            var objectString = JsonConvert.SerializeObject(picture);
            crop.PutExtra("image", objectString);
            
            StartActivityForResult(crop, 100);

        }

        private void InitNumberPicker()
        {
            numberPicker = FindViewById<NumberPicker>(Resource.Id.numberPicker1);
            numberPicker.MinValue = 0;
            numberPicker.MaxValue = 100;
            numberPicker.Value = amount;
        }

        private void InitSpinner()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Sizes, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
            spinner.Adapter = adapter;
            spinner.ItemSelected += spinner_ItemSelected;
            if (!size.Equals(null))
            {
                var spinnerPosition = adapter.GetPosition(size);
                spinner.SetSelection(spinnerPosition);
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            picture.Size = spinner.SelectedItem.ToString();
        }
        //if the user crops the image, the newly cropped version gets loaded into the imageview.
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var sdCardPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var croppedImageName = System.IO.Path.GetFileNameWithoutExtension(pictureName);
                var filePath = System.IO.Path.Combine(sdCardPath, croppedImageName + " - cropped" + ".jpeg");
                
                if (System.IO.File.Exists(filePath))
                {
                    Bitmap bitmap = BitmapFactory.DecodeFile(filePath);
                    imageView.SetImageBitmap(bitmap);
                }
                picture.FilePath = filePath;
            }
        }



    }
}