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
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Java.IO;

namespace FotoABIld.Droid
{
    [Activity(Label = "FinalizeActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FinalizeActivity : Activity
    {
        private TextView nameSurname;
        private TextView phoneNumber;
        private TextView email;
        private Order order; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FinalizeOrder);

            Init();
            var priceClass = new PriceClass(order.Pictures);
            AddTableRow(priceClass);
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
        }



        private void AddTableRow(PriceClass priceClass)
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
            summarizeLayout.AddView(CreateDivider());
            foreach (List<Pictures> picturelist in priceClass.PriceClasses)
            {
                var horizontalLayout = CreateLinearLayout(lpNoWeight, Orientation.Horizontal);

                var sizeLayout = CreateLinearLayout(lPWeight2, Orientation.Vertical);

                var amountLayout = CreateLinearLayout(lPWeight1, Orientation.Vertical);



                var differentSizes = picturelist.Select(picture => picture.Size).Distinct().ToList();
                differentSizes = differentSizes.OrderBy(size => size).ToList();

                summarizeLayout.AddView(horizontalLayout);
                horizontalLayout.AddView(sizeLayout);
                horizontalLayout.AddView(amountLayout);
                foreach (var size in differentSizes)
                {
                    var sizeText = CreateSizeTextView(lPHorizontalWeight2,size);
                    sizeText.SetBackgroundColor(Color.NavajoWhite);
                    var amountText = CreateAmountTextView(lPHorizontalWeight1,
                        amountHandler.GetAmountofSize(size).ToString());
                    amountText.SetBackgroundColor(Color.BlanchedAlmond);
                    sizeLayout.AddView(sizeText);
                    amountLayout.AddView(amountText);
                }

                if (picturelist == null && picturelist.Count <= 0) continue;
                


                var amount = differentSizes.Sum(size => amountHandler.GetAmountofSize(size));

                if (differentSizes.Count > 0)
                {
                    var price = PriceCalculator.CalculatePrice(differentSizes[0], amount) + " kr";
                    var priceText = CreatePriceTextView(lPPrice,
                    price);
                    horizontalLayout.AddView(priceText);
                }
                summarizeLayout.AddView(CreateDivider());
            }
        }

        private View CreateSizeTextView(ViewGroup.LayoutParams lP, string size)
        {
            var sizeText = new TextView(this)
            {
                LayoutParameters = lP,
                Text = size,
                Gravity = GravityFlags.Left,
                TextSize = 20

            };
            sizeText.SetTextColor(Color.Black);
            return sizeText;
        } 

        private View CreateAmountTextView(ViewGroup.LayoutParams lP, string amount)
        {
            var amountText = new TextView(this)
            {
                LayoutParameters = lP,
                Text = amount,
                Gravity = GravityFlags.CenterHorizontal,
                TextSize = 20
            };
            amountText.SetTextColor(Color.Black);
            return amountText;
        }

        private View CreatePriceTextView(ViewGroup.LayoutParams lP, string price)
        {
            var priceText = new TextView(this)
            {
                LayoutParameters = lP,
                Gravity = GravityFlags.Bottom | GravityFlags.Right,

                TextSize = 20
            };
            priceText.Text = price;
            priceText.SetTextColor(Color.Black);
            return priceText;
        }
        private View CreateDivider()
        {
            var view = new View(this);
            view.SetBackgroundColor(Color.ParseColor("#1F2F40"));
            view.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,1);

            return view;
        }

        private LinearLayout CreateLinearLayout(ViewGroup.LayoutParams lP,Orientation orientation)
        {
            var layout = new LinearLayout(this)
            {
                LayoutParameters = lP,
                Orientation = orientation
            };
            return layout;
        }

        void placeOrderButton_Click(object sender, EventArgs e)
        {
            var folderName = "FotoABildKvitton";
            
            var file = new File(Android.OS.Environment.ExternalStorageDirectory, folderName);
            if (!file.Exists())
            {
                file.Mkdirs();
            }
            var filePath = Android.OS.Environment.ExternalStorageDirectory + "/FotoABildKvitton/" + order.Email + order.Surname + order.Pictures.Count;
            var xmlWriter = new Serializer<Order>();
            xmlWriter.Serialize(order, filePath);

        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}