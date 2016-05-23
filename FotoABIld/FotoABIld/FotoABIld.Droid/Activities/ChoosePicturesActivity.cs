using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Bluetooth;
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
using FotoABIld.Droid.Activities;
using Java.IO;
using Newtonsoft.Json;

namespace FotoABIld.Droid
{
    [Activity(ParentActivity = typeof(MainActivity),Label = "ChoosePicturesActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class ChoosePicturesActivity : AppCompatActivity
    {
        private int editIndex;
        private List<Pictures> pictureList; 
        private GridView gridGallery;
        private Handler handler;
        private GalleryAdapter adapter;
        private List<CustomGallery> dataT;
        private ImageView imgSinglePick;

        private Button chooseButton;

        private ImageLoader imageLoader;
        private ViewSwitcher viewSwitcher;
        private Android.Support.V7.Widget.Toolbar toolbar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChoosePictures);
            InitImageLoader();
            Init();

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Initializes the imageloader with certain properties.
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
            pictureList = new List<Pictures>();

            adapter = new GalleryAdapter(ApplicationContext, imageLoader);
            adapter.IsMultiplePick = false;
            gridGallery.Adapter = adapter;

            viewSwitcher = FindViewById<ViewSwitcher>(Resource.Id.viewSwitcher);
            viewSwitcher.DisplayedChild = 1;
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Button cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            chooseButton = FindViewById<Button>(Resource.Id.ChoosePicturesButton);
            cancelButton.Click += Cancelbutton_Click;
            chooseButton.Click += chooseButton_Click;
            gridGallery.ItemClick += gridGallery_ItemClick;
            Button nextButton = FindViewById<Button>(Resource.Id.NextButton);
            nextButton.Click += NextButton_Click;




        }

        void chooseButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Action.ActionPickMultiple);
            StartActivityForResult(intent, 200);


        }
        //Action for when you click on an item in the gridview
       private void gridGallery_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof (EditPictureActivity));
            
           var objectString = JsonConvert.SerializeObject(pictureList[e.Position]);

           
            i.PutExtra("picture",objectString);
            editIndex = e.Position;
            StartActivityForResult(i,300);
            
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
        //For when you continue after selecting a picture
        private void NextButton_Click(object sender, EventArgs e)
        {
            //Serializes the list of pictures to a JSON string to be deserializes in another activity
            if (pictureList.Sum(pic => pic.Amount) > 0)
            {


                var objectString = JsonConvert.SerializeObject(pictureList, Formatting.Indented);
                System.Console.WriteLine(objectString);

                var next = new Intent(this, typeof(CustomerInformationActivity));


                next.PutExtra("pictureList", objectString);
                StartActivity(next);
            }
            else
            {
                var toast = Toast.MakeText(this, "Välj en bild för framkallning för att fortsätta beställningen", ToastLength.Long);
                toast.Show();
            }
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    NavUtils.NavigateUpFromSameTask(this);
                    return true;

                case Resource.Id.action_help:
                    var intent = new Intent(this, typeof(HelpPopupActivity));
                    intent.PutExtra("help", GetString(Resource.String.choosePictureHelp));
                    StartActivity(intent);

                    return true;
                   
                    
                default:

                    return OnOptionsItemSelected(item);
            }
        }
        //A method using the result of an action above
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
            
            base.OnActivityResult(requestCode, resultCode, data);

            //When selected a single picture. Not used
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                adapter.Clear();

                viewSwitcher.DisplayedChild = 1;
                string single_path = data.GetStringExtra("single_path");

                imageLoader.DisplayImage("file://" + single_path, imgSinglePick);

            }
                //When selected multiple picture this is run to put them in the gridview through an adapter
            else if (requestCode == 200 && resultCode == Result.Ok)
            {
                String[] all_path = data.GetStringArrayExtra("all_path");


                dataT = new List<CustomGallery>();
                

                foreach (var uri in all_path)
                {
                    var item = new CustomGallery();
                    var picture = new Pictures(uri);
                    picture.Name = System.IO.Path.GetFileNameWithoutExtension(uri) + ".jpeg";
                    
                    pictureList.Add(picture);
                   
                    item.SdCardPath = uri;
                    dataT.Add(item);
                }
                viewSwitcher.DisplayedChild = 0;

                adapter.AddAll(dataT);
            }
                //After changing properties this one saves the changed properties in the picturelist or creates a new one if that was requested.
            else if (requestCode == 300 && resultCode == Result.Ok)
            {
                var bundle = data.GetBundleExtra("bundle");
                if (bundle.GetBoolean("bool"))
                {
                    
                    var picture = JsonConvert.DeserializeObject<Pictures>(bundle.GetString("picture"));
                    pictureList[editIndex] = picture;
                    dataT[editIndex].SdCardPath = picture.FilePath;
                    adapter.NotifyDataSetChanged();
                }
                else
                {
                    var pictureCopy = JsonConvert.DeserializeObject<Pictures>(bundle.GetString("pictureCopy"));
                    var picture = JsonConvert.DeserializeObject<Pictures>(bundle.GetString("picture"));
                    pictureList[editIndex] = picture;
                    pictureList.Add(pictureCopy);
                    var item = new CustomGallery {SdCardPath = pictureCopy.FilePath};
                    dataT.Add(item);
                    adapter.AddAll(dataT);
                }

            }

        }
    }
}
