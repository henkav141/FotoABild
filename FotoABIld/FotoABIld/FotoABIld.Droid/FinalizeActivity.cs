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
            AddTableRow();
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

        //Skapar TableRows för varje unik storlek som finns i ordern och lägger till antal och pris för varje.
        //Fungerar ej till 100% beroende på prisrabatter ännu
        private void AddTableRow()
        {
            var differentSizes = (order.Pictures.Select(picture => picture.Size).Distinct().ToList());
            differentSizes = differentSizes.OrderBy(size => size).ToList();
            
            var tableLayout = FindViewById<TableLayout>(Resource.Id.amountTable);
            var tablerowList = new List<TableRow>();
            var amountHandler = new AmountHandler(order.Pictures);
            foreach (var size in differentSizes)
            {
                var tableRow = new TableRow(this);
                
                var layoutParameters = new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent, TableRow.LayoutParams.MatchParent, 1);
                var layoutParameters2 = new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent, TableRow.LayoutParams.MatchParent, 2);


                var sizeText = new TextView(this)
                {
                    LayoutParameters = layoutParameters,
                    Text = size,
                    Gravity = GravityFlags.Left,
                    TextSize = 20

                };
                var amountText = new TextView(this)
                {
                    LayoutParameters = layoutParameters2,
                    Text = amountHandler.GetAmountofSize(size).ToString(),
                    Gravity = GravityFlags.Right,
                    TextSize = 20
                };

                var priceText = new TextView(this)
                {
                    LayoutParameters = layoutParameters,
                    Text = PriceHandler.GetPriceOfSize(size, order.Pictures).ToString(),
                    Gravity = GravityFlags.Right,
                    TextSize = 20
                };
                if (differentSizes.Contains("10x15") && differentSizes.Contains("11x15") && size.Equals("10x15"))
                {
                    var amount = amountHandler.GetAmountofSize(size) + amountHandler.GetAmountofSize("11x15");

                    priceText.Text = PriceCalculator.CalculatePrice("10x15", amount).ToString();

                }
                if (differentSizes.Contains("10x15") && differentSizes.Contains("11x15") && size.Equals("11x15"))
                    priceText.Text = "";


                sizeText.SetTextColor(Color.Black);
                amountText.SetTextColor(Color.Black);
                priceText.SetTextColor(Color.Black);
                tableRow.AddView(sizeText);
                tableRow.AddView(amountText);
                tableRow.AddView(priceText);



                tableLayout.AddView(tableRow);
            }
            var layoutParameters3 = new TableRow.LayoutParams(TableRow.LayoutParams.MatchParent, TableRow.LayoutParams.MatchParent, 1);


            foreach (var tableRow in tablerowList)
            {
                tableLayout.AddView(tableRow);
            }


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var info = new Intent(this, typeof(CustomerInformationActivity));
            StartActivity(info);
        }
    }
}