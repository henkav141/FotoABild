using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
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

namespace FotoABIld.Droid
{
    [Activity(Label = "ChoosePicturesActivity")]
    public class ChoosePicturesActivity : Activity
    {
        List<Android.Net.Uri> uriList = new List<Android.Net.Uri>();
        private GridView gridview;
        private GalleryAdapter galleryAdapter;
        private Button chooseButton;
        private ImageLoader imageLoader;
        private ImageAdapter imageAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ChoosePictures);

            Init();
            InitImageLoader();
        }

        private void InitImageLoader()
        {
            DisplayImageOptions defaultOptions =
                new DisplayImageOptions.Builder().CacheOnDisc()
                    .ImageScaleType(ImageScaleType.ExactlyStretched)
                    .BitmapConfig(Bitmap.Config.
                        Rgb565).Build();
            ImageLoaderConfiguration.Builder builder =
                new ImageLoaderConfiguration.Builder(this).DefaultDisplayImageOptions(defaultOptions)
                    .MemoryCache(new WeakMemoryCache()
                    );

            ImageLoaderConfiguration config = builder.Build();
            imageLoader = ImageLoader.Instance;
            imageLoader.Init(config);
        }

        private void Init()
        {
           var handler = new Handler();
           gridview = gridview = FindViewById<GridView>(Resource.Id.gridview);
            galleryAdapter = new GalleryAdapter(ApplicationContext, imageLoader);
            gridview.Adapter = galleryAdapter;
            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            chooseButton = FindViewById<Button>(Resource.Id.ChoosePicturesButton);
            cancelButton.Click += Cancelbutton_Click;
            chooseButton.Click += chooseButton_Click;   

            


        }

        void chooseButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Action.ActionPickMultiple);
            StartActivityForResult(intent, 0);


        }

        void gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof (EditPictureActivity));
            i.PutExtra("id",e.Position);
            StartActivity(i);
            
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if (requestCode == 0 && resultCode == Result.Ok)
            {
                var all_path = intent.GetStringArrayExtra("all_path");
                var dataT = new List<CustomGallery>();

                foreach (string uri in all_path)
                {
                    var item = new CustomGallery();
                    item.SdCardPath = uri;
                    dataT.Add(item);
                }

                galleryAdapter.AddAll(dataT);

            }
        }

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        //{
        //    if (requestCode == 0)
        //    {
        //        if (resultCode == Result.Ok)
        //        {
        //                ClipData clipData = intent.ClipData;
        //                for (int i = 0; i < intent.ClipData.ItemCount; i++)
        //                {
        //                    var item = clipData.GetItemAt(i);
        //                    var uri = item.Uri;
        //                    uriList.Add(uri);
        //            }
        //                ImageAdapter imageAdapter = new ImageAdapter(this, uriList);
        //                gridview = FindViewById<GridView>(Resource.Id.gridview);
        //                gridview.Adapter = imageAdapter;
        //                gridview.ItemClick += gridview_ItemClick;
        //        }
        //    }
        //}
    }
}
