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
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.Activities;
using FotoABIld.Droid.UITools;
using Newtonsoft.Json;
using Java.IO;
using Environment = Android.OS.Environment;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid
{
    [Activity(ParentActivity = typeof(CustomGalleryActivity),Label = "FinalizeActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FinalizeActivity : AppCompatActivity
    {
        private TextView nameSurname;
        private TextView phoneNumber;
        private TextView email;
        private Order order;
        private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FinalizeOrder);

            Init();
            var priceClass = new PriceClass(order.Pictures);
            SummarizePictures(priceClass);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void Init()
        {
            var objectString = Intent.GetStringExtra("order");
            var cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            var placeOrderButton = FindViewById<Button>(Resource.Id.PlaceOrderButton);
            nameSurname = FindViewById<TextView>(Resource.Id.finalizeNameSurnameText);
            email = FindViewById<TextView>(Resource.Id.finalizeEmail);
            phoneNumber = FindViewById<TextView>(Resource.Id.finalizePhoneNumber);
            
            order = JsonConvert.DeserializeObject<Order>(objectString);
            nameSurname.Text = order.Name + " " + order.Surname;
            email.Text = order.Email;
            phoneNumber.Text = order.PhoneNumber;

            cancelButton.Click += CancelButton_Click;
            placeOrderButton.Click += placeOrderButton_Click;
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }



        private void SummarizePictures(PriceClass priceClass)
        {
            var amountHandler = new AmountHandler(order.Pictures);
            var lPWeight1 = new LinearLayout.LayoutParams(0,
                ViewGroup.LayoutParams.WrapContent, 1);
            var lPWeight2 = new LinearLayout.LayoutParams(0,
                ViewGroup.LayoutParams.WrapContent, 2);
            var lpNoWeight = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent);
            var lPHorizontalWeight1 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 
                ViewGroup.LayoutParams.WrapContent,1);
            var lPHorizontalWeight2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 
                ViewGroup.LayoutParams.WrapContent, 2);
            var lPPrice = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MatchParent, 1);


            var summarizeLayout = FindViewById<LinearLayout>(Resource.Id.summarizePictures);
            summarizeLayout.AddView(ViewCreator.CreateDivider(this, Color.ParseColor("#1F2F40")));
            foreach (List<Pictures> picturelist in priceClass.PriceClasses)
            {
                var horizontalLayout = ViewCreator.CreateLinearLayout(this,lpNoWeight, Orientation.Horizontal);

                var sizeLayout = ViewCreator.CreateLinearLayout(this,lPWeight2, Orientation.Vertical);

                var amountLayout = ViewCreator.CreateLinearLayout(this,lPWeight1, Orientation.Vertical);


                var differentSizes = picturelist.Select(picture => picture.Size).Distinct().ToList();
                differentSizes = differentSizes.OrderBy(size => size).ToList();

                summarizeLayout.AddView(horizontalLayout);
                horizontalLayout.AddView(sizeLayout);
                horizontalLayout.AddView(amountLayout);
                foreach (var size in differentSizes)
                {
                    var sizeText = ViewCreator.CreateTextView(GravityFlags.Left, lPHorizontalWeight2, size, this, 20, Color.Black);
                    sizeText.SetBackgroundColor(Color.NavajoWhite);
                    var amountText = ViewCreator.CreateTextView(GravityFlags.CenterHorizontal,lPHorizontalWeight1,
                        amountHandler.GetAmountofSize(size).ToString(), this, 20, Color.Black);
                    amountText.SetBackgroundColor(Color.BlanchedAlmond);
                    sizeLayout.AddView(sizeText);
                    amountLayout.AddView(amountText);
                }

                if (picturelist == null && picturelist.Count <= 0) continue;
                


                var amount = differentSizes.Sum(size => amountHandler.GetAmountofSize(size));

                if (differentSizes.Count > 0)
                {
                    var price = PriceCalculator.CalculatePrice(differentSizes[0], amount) + " kr";
                    var priceText = ViewCreator.CreateTextView(GravityFlags.Right|GravityFlags.Bottom,lPPrice,
                    price,this,20,Color.Black);
                    horizontalLayout.AddView(priceText);
                }
                summarizeLayout.AddView(ViewCreator.CreateDivider(this,Color.ParseColor("#1F2F40")));
            }
        }

        void placeOrderButton_Click(object sender, EventArgs e)
        {
            order.Date = 
            order.Date.AddHours(1);
            try
            {
                
               var currentOrders =  Serializer<List<Order>>.DeSerialize(FilesDir + "/FotoABildKvitton");
               currentOrders.Add(order);
                Serializer<List<Order>>.Serialize(currentOrders,FilesDir + "/FotoABildKvitton");
                

            }
            catch
            {
                System.Console.WriteLine("Could not save orders");
            }


            //var filepath = Environment.ExternalStorageDirectory.AbsolutePath + "/" + order.OrderId + "/";
            //OrderHandler.CreateOutputFolder(filepath);
            //OrderHandler.FillOutPutFolder(order, filepath);
            //var lacHandler = new LacHandler(order, filepath + order.OrderId + ".LAC",filepath);
            //lacHandler.CreateLacFile();


            var toast = Toast.MakeText(this, "Tack för din beställning", ToastLength.Long);
            toast.Show();
            
            var intent = new Intent(this,typeof(MainActivity));
            intent.PutExtra("order", Intent.GetStringExtra("order"));
            StartActivity(intent);

        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                case Resource.Id.action_help:
                    var intent = new Intent(this, typeof(HelpPopupActivity));
                    intent.PutExtra("help", GetString(Resource.String.mainPageHelp));
                    StartActivity(intent);

                    return true;

                default:

                    return OnOptionsItemSelected(item);
            }
        }
    }
}