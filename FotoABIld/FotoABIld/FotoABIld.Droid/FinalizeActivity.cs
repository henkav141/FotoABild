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

            // Create your application here
            SetContentView(Resource.Layout.FinalizeOrder);

            Init();
            var priceClass = new PriceClass(order.Pictures);
            AddTableRow(priceClass);
        }

        private void Init()
        {
            var objectString = Intent.GetStringExtra("order");
            var cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            nameSurname = FindViewById<TextView>(Resource.Id.finalizeNameSurnameText);
            email = FindViewById<TextView>(Resource.Id.finalizeEmail);
            phoneNumber = FindViewById<TextView>(Resource.Id.finalizePhoneNumber);
            
            order = JsonConvert.DeserializeObject<Order>(objectString);
            nameSurname.Text = order.Name + " " + order.Surname;
            email.Text = order.Email;
            phoneNumber.Text = order.PhoneNumber;

            cancelButton.Click += CancelButton_Click;
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
            var lPHorizontalWeight1 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent,1);
            var lPHorizontalWeight2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 2);
            var lPPrice = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MatchParent, 1);

            var summarizeLayout = FindViewById<LinearLayout>(Resource.Id.summarizePictures);
            foreach (List<Pictures> picturelist in priceClass.PriceClasses)
            {
                var horizontalLayout = new LinearLayout(this)
                {
                    LayoutParameters = lpNoWeight,
                    Orientation = Orientation.Horizontal,
                };
                
                var sizeLayout = new LinearLayout(this)
                {
                    LayoutParameters = lPWeight1,
                    Orientation = Orientation.Vertical
                };
                sizeLayout.SetBackgroundColor(Color.YellowGreen);
                var amountLayout = new LinearLayout(this)
                {
                    LayoutParameters = lPWeight2,
                    Orientation = Orientation.Vertical
                };
                amountLayout.SetBackgroundColor(Color.IndianRed);

                var differentSizes = picturelist.Select(picture => picture.Size).Distinct().ToList();
                differentSizes = differentSizes.OrderBy(size => size).ToList();

                summarizeLayout.AddView(horizontalLayout);
                horizontalLayout.AddView(sizeLayout);
                horizontalLayout.AddView(amountLayout);
                foreach (var size in differentSizes)
                {
                    var sizeText = new TextView(this)
                    {
                        LayoutParameters = lPHorizontalWeight1,
                        Text = size,
                        Gravity = GravityFlags.Left,
                        TextSize = 20

                    };
                    sizeText.SetTextColor(Color.Black);
                    var amountText = new TextView(this)
                    {
                        LayoutParameters = lPHorizontalWeight2,
                        Text = amountHandler.GetAmountofSize(size).ToString(),
                        Gravity = GravityFlags.CenterHorizontal,
                        TextSize = 20
                    };
                    amountText.SetTextColor(Color.Black);
                    sizeLayout.AddView(sizeText);
                    amountLayout.AddView(amountText);
                }

                if (picturelist == null && picturelist.Count <= 0) continue;
                var priceText = new TextView(this)
                {
                    LayoutParameters = lPPrice,
                    Gravity = GravityFlags.Right,
                    TextSize = 20
                };
                var amount = differentSizes.Sum(size => amountHandler.GetAmountofSize(size));
                if(differentSizes.Count > 0)
                priceText.Text = PriceCalculator.CalculatePrice(differentSizes[0],amount).ToString();
                priceText.SetTextColor(Color.Black);
                horizontalLayout.AddView(priceText);
            }
        }
        //private void AddTableRow()
        //{
        //    var differentSizes = (order.Pictures.Select(picture => picture.Size).Distinct().ToList());
        //    differentSizes = differentSizes.OrderBy(size => size).ToList();
            
        //    var tableLayout = FindViewById<TableLayout>(Resource.Id.summarizePictures);
        //    var amountHandler = new AmountHandler(order.Pictures);
        //    foreach (var size in differentSizes)
        //    {
        //        var tableRow = new TableRow(this);
                
        //        var layoutParameters = new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent, TableRow.LayoutParams.MatchParent, 1);
        //        var layoutParameters2 = new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent, TableRow.LayoutParams.MatchParent, 2);


        //        var sizeText = new TextView(this)
        //        {
        //            LayoutParameters = layoutParameters,
        //            Text = size,
        //            Gravity = GravityFlags.Left,
        //            TextSize = 20

        //        };
        //        var amountText = new TextView(this)
        //        {
        //            LayoutParameters = layoutParameters2,
        //            Text = amountHandler.GetAmountofSize(size).ToString(),
        //            Gravity = GravityFlags.Right,
        //            TextSize = 20
        //        };

        //        var priceText = new TextView(this)
        //        {
        //            LayoutParameters = layoutParameters,
        //            Text = PriceHandler.GetPriceOfSize(size, order.Pictures).ToString(),
        //            Gravity = GravityFlags.Right,
        //            TextSize = 20
        //        };
        //        if (differentSizes.Contains("10x15") && differentSizes.Contains("11x15") && size.Equals("10x15"))
        //        {
        //            var amount = amountHandler.GetAmountofSize(size) + amountHandler.GetAmountofSize("11x15");

        //            priceText.Text = PriceCalculator.CalculatePrice("10x15", amount).ToString();

        //        }
        //        if (differentSizes.Contains("10x15") && differentSizes.Contains("11x15") && size.Equals("11x15"))
        //            priceText.Text = "";



        //        tableRow.AddView(sizeText);
        //        tableRow.AddView(amountText);
        //        tableRow.AddView(priceText);



        //        tableLayout.AddView(tableRow);
        //    }

        //}

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var info = new Intent(this, typeof(CustomerInformationActivity));
            StartActivity(info);
        }
    }
}