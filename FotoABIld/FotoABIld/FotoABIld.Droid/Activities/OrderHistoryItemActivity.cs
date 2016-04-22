using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace FotoABIld.Droid.Resources.layout
{
    [Activity(Label = "HistoryActivity", ConfigurationChanges = ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class OrderHistoryItemActivity : Activity
    {
        private TextView orderNumber;
        private TextView expectedCollect;
        private TextView name;
        private TextView phoneNumber;
        private TextView amount;
        private TextView price;
        private TextView email;
        private Order order;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderHistoryItem);
            Init();
            FillData();
        }

        private void Init()
        {

            orderNumber = FindViewById<TextView>(Resource.Id.orderNumberText);

            expectedCollect = FindViewById<TextView>(Resource.Id.expectedCollectText);
            name = FindViewById<TextView>(Resource.Id.nameText);
            phoneNumber = FindViewById<TextView>(Resource.Id.phoneNumberText);
            amount = FindViewById<TextView>(Resource.Id.amountText);
            price = FindViewById<TextView>(Resource.Id.priceText);
            email = FindViewById<TextView>(Resource.Id.emailMessageText);

            var objectString = Intent.GetStringExtra("order");
            order = JsonConvert.DeserializeObject<Order>(objectString);
        }

        private void FillData()
        {
            var amountHandler = new AmountHandler(order.Pictures);
            orderNumber.Text += "TestOrderNumber";
            expectedCollect.Text += order.Date.ToString("hh.mm, yyyy-MM-dd");
            name.Text += order.Name + " " + order.Surname;
            phoneNumber.Text += order.PhoneNumber;
            amount.Text += amountHandler.GetTotalAmount().ToString();
            price.Text += PriceCalculator.CalculateTotalPrice(order.Pictures).ToString();
            email.Text += order.Email;

        }




    }
}