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
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Cache.Memory.Impl;
using Com.Nostra13.Universalimageloader.Core;
using Com.Nostra13.Universalimageloader.Core.Assist;
using Java.IO;
using Newtonsoft.Json;
using Square.Picasso;
using Console = System.Console;
using Environment = System.Environment;
using File = Java.IO.File;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid
{
    [Activity(ParentActivity = typeof(ChoosePicturesActivity),Label = "EditPictureActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class EditPictureActivity : AppCompatActivity


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
        private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)

        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);

            Init();
            InitNumberPicker();
            InitSpinner();

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
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
                pictureName = imgFile.Name;
                LoadImage();
            }
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

        }
        //Creates a copy of the image wanted to have two of the same pictures with different properties
        void copyButton_Click(object sender, EventArgs e)
        {
            var copyImageName = pictureName + "copy";
            var copyImage = new Pictures(position,0,"10x15",copyImageName,"-2");
            var bundle = new Bundle();
            var objectString = JsonConvert.SerializeObject(copyImage);
            bundle.PutString("picture", objectString);
            bundle.PutBoolean("bool",false);
            var intent = new Intent().PutExtra("bundle", bundle);
            SetResult(Result.Ok,intent);
            Finish();
        }

        private void LoadImage()
        {
            Picasso.With(this).Load(new File(position)).Fit().CenterInside().Into(imageView);
        }
        
        private void DoneButton_Click(object sender, EventArgs e)
        {
            
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
            
            
            numberPicker.ValueChanged += NumberPicker_ValueChanged; 
            
        }

        private void NumberPicker_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            picture.Amount = numberPicker.Value;
        }

        private void InitSpinner()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Sizes, Resource.Layout.SpinnerItem);
            adapter.SetDropDownViewResource(Resource.Layout.SpinnerItem);
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
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                case Resource.Id.action_help:
                    StartActivity(new Intent(this, typeof(HelpActivity)));

                    return true;

                default:

                    return OnOptionsItemSelected(item);
            }
        }
        //if the user crops the image, the newly cropped version gets loaded into the imageview.
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var sdCardPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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