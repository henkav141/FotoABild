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
using Java.IO;

namespace FotoABIld.Droid
{
    [Activity(Label = "ChoosePicturesActivity")]
    public class ChoosePicturesActivity : Activity
    {
        private List<PictureProperties> picturesList; 
        private GridView gridGallery;
        private Handler handler;
        private GalleryAdapter adapter;

        private ImageView imgSinglePick;

        private Button chooseButton;

        private ImageLoader imageLoader;
        private ViewSwitcher viewSwitcher;
        //private ImageAdapter imageAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ChoosePictures);
            InitImageLoader();
            Init();

        }

        private void InitImageLoader()
        {
            var defaultOptions =
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
            handler = new Handler();
            gridGallery = FindViewById<GridView>(Resource.Id.gridGallery);
            gridGallery.FastScrollEnabled = true;
            
            adapter = new GalleryAdapter(ApplicationContext, imageLoader);
            adapter.IsMultiplePick = false;
            gridGallery.Adapter = adapter;

            viewSwitcher = FindViewById<ViewSwitcher>(Resource.Id.viewSwitcher);
            viewSwitcher.DisplayedChild = 1;

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            chooseButton = FindViewById<Button>(Resource.Id.ChoosePicturesButton);
            cancelButton.Click += Cancelbutton_Click;
            chooseButton.Click += chooseButton_Click;
            gridGallery.ItemClick += gridGallery_ItemClick;
            Button nextButton = FindViewById<Button>(Resource.Id.NextButton);




        }

        void chooseButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Action.ActionPickMultiple);
            StartActivityForResult(intent, 200);


        }

       private void gridGallery_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof (EditPictureActivity));
            //i.PutExtra("single_path",adapter[e.Position].SdCardPath);

            var bundle = new Bundle();
            //bundle.PutString("file_path", picturesList[e.Position].FilePath);
            //bundle.PutInt("amount", picturesList[e.Position].Amount);
            //bundle.PutString("size", picturesList[e.Position].Size);
            //bundle.PutInt("index",e.Position);
           //bundle.PutParcelable("picture", picturesList[e.Position]);
           // bundle.PutInt("index", e.Position);
           
           i.PutExtra("picture",picturesList[e.Position]);
            StartActivityForResult(i,300);
            
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var next = new Intent(this, typeof(CustomerInformationActivity));
            StartActivity(next);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
            
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 100 && resultCode == Result.Ok)
            {
                adapter.Clear();

                viewSwitcher.DisplayedChild = 1;
                string single_path = data.GetStringExtra("single_path");

                imageLoader.DisplayImage("file://" + single_path, imgSinglePick);

            }
            else if (requestCode == 200 && resultCode == Result.Ok)
            {
                String[] all_path = data.GetStringArrayExtra("all_path");


                List<CustomGallery> dataT = new List<CustomGallery>();
                picturesList = new List<PictureProperties>();

                foreach (string uri in all_path)
                {
                    CustomGallery item = new CustomGallery();
                    PictureProperties picture = new PictureProperties(uri);
                    
                    picturesList.Add(picture);
                   
                    item.SdCardPath = uri;
                    dataT.Add(item);
                }
                picturesList.Reverse();
                viewSwitcher.DisplayedChild = 0;

                adapter.AddAll(dataT);
            }
            else if (requestCode == 300 && resultCode == Result.Ok)
            {
                var text = data.GetStringExtra("size");
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
