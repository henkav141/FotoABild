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
        private PictureProperties picture;
        private int amount;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditPicture);
           // Create your application here

            Init();
            InitNumberPicker();
            InitSpinner();
            var position = Intent.GetStringExtra("file_path");
            
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
            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);
            doneButton.Click += DoneButton_Click;
            var bundle = Intent.Extras;
            var position = bundle.GetString("file_path");
             amount = bundle.GetInt("amount",1);
            var size = bundle.GetString("size");
            File imgFile = new File(position);
            if (imgFile.Exists())
            {
                Bitmap bitMap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);
                imageView.SetImageBitmap(bitMap);
            }
            picture = new PictureProperties(position,amount,size);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            picture.Amount = numberPicker.Value;
            picture.Size = spinner.SelectedItem.ToString();
            var bundle = new Bundle();

            FinishActivity(300);
        }

        private void InitNumberPicker()
        {
            numberPicker = FindViewById<NumberPicker>(Resource.Id.numberPicker1);
            numberPicker.Value = amount;
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