using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.Activities;
using Newtonsoft.Json;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid.Resources.layout
{
    [Activity(ParentActivity = typeof(HistoryActivity),Label = "HistoryActivity", ConfigurationChanges = ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class OrderHistoryItemActivity : AppCompatActivity
    {
        private TextView orderNumber;
        private TextView expectedCollect;
        private TextView name;
        private TextView phoneNumber;
        private TextView amount;
        private TextView price;
        private TextView email;
        private Order order;
        private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderHistoryItem);
            Init();
            FillData();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
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
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        private void FillData()
        {
            var amountHandler = new AmountHandler(order.Pictures);
            orderNumber.Text += "TestOrderNumber";
            expectedCollect.Text += order.Date.ToString("HH.mm, yyyy-MM-dd");
            name.Text += order.Name + " " + order.Surname;
            phoneNumber.Text += order.PhoneNumber;
            amount.Text += amountHandler.GetTotalAmount().ToString();
            price.Text += PriceCalculator.CalculateTotalPrice(order.Pictures).ToString();
            email.Text += order.Email;

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