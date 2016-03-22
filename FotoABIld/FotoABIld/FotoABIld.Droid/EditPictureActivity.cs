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
        private ImageView imageView;
        private NumberPicker numberPicker;
        private Spinner spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);
           // Create your application here

            Init();
            InitNumberPicker();
            InitSpinner();
            var position = Intent.GetStringExtra("single_path");
            
            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                imageView.SetImageBitmap(bitMap);
            }
        }

        private void Init()
        {
            imageView = FindViewById<ImageView>(Resource.Id.edit_picture);
            
        }

        private void InitNumberPicker()
        {
            numberPicker = FindViewById<NumberPicker>(Resource.Id.numberPicker1);
            numberPicker.Value = 1;
            numberPicker.MinValue = 0;
            numberPicker.MaxValue = 100;
        }

        private void InitSpinner()
        {
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Sizes, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerItem);
            spinner.Adapter = adapter;
        }



    }
}