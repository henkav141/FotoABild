using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FotoABIld.Droid
{
    [Activity(Label = "HistoryActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class HistoryActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OrderHistory);

            Init();
        }

        private void Init()
        {
            var homeButton = FindViewById<Button>(Resource.Id.HomeButton);
            CreateOrderLayouts();
            
            homeButton.Click += homeButton_Click;
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            var home = new Intent(this, typeof(MainActivity));
            StartActivity(home);
        }


        private void CreateOrderLayouts()
        {
            var lPHorizontal = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent);
            var lPTextView = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);
            var orderHistoryView = FindViewById<LinearLayout>(Resource.Id.orderHistoryView);
            foreach (var order in GetOrders())
            {

                var amountHandler = new AmountHandler(order.Pictures);

                var horizontalLinearLayout = new LinearLayout(this)
                {
                    Orientation = Orientation.Horizontal,
                    LayoutParameters = lPHorizontal,
                    
                };
                horizontalLinearLayout.SetGravity(GravityFlags.CenterHorizontal);
                horizontalLinearLayout.SetPadding(0,10,0,0);
                var dateText = new TextView(this)
                {
                    LayoutParameters = lPTextView,
                    TextSize = 20,
                    Text = order.Date.ToString("yyyy-M-d")
                };
                dateText.SetPadding(0,0,10,0);
                var amountText = new TextView(this)
                {
                    LayoutParameters = lPTextView,
                    TextSize = 20,
                    Text = amountHandler.GetTotalAmount() + " bilder"
                };
                amountText.SetPadding(10,0,10,0);
                var priceText = new TextView(this)
                {
                    LayoutParameters = lPTextView,
                    TextSize = 20,
                    Text = PriceCalculator.CalculateTotalPrice(order.Pictures) + " kr"
                };
                priceText.SetPadding(10,0,0,0);

                dateText.SetTextColor(Color.ParseColor("#1F2F40"));
                amountText.SetTextColor(Color.ParseColor("#1F2F40"));
                priceText.SetTextColor(Color.ParseColor("#1F2F40"));
                priceText.SetBackgroundColor(Color.Azure);

                horizontalLinearLayout.AddView(dateText);
                horizontalLinearLayout.AddView(amountText);
                horizontalLinearLayout.AddView(priceText);
                orderHistoryView.AddView(horizontalLinearLayout);


            }
        }

        private List<Order> GetOrders()
        {
            var xmlserializer = new Serializer<Order>();
            var filepath = Android.OS.Environment.ExternalStorageDirectory + "/FotoABildKvitton/";
            var filenames = GetFileNames(filepath);
            var orders = filenames.Select(filename => xmlserializer.DeSerialize(filepath + "/" + filename)).ToList();

            foreach (var order in orders)
            {
                  Console.WriteLine(order.Pictures.Count);
            }
            return orders;
        }

        private List<string> GetFileNames(string filePath)
        {
            var directoryInfo = new DirectoryInfo(filePath);
            //var filenames = Directory.GetFiles(filePath, "*.xml");

            return directoryInfo.GetFiles().Select(item => item.Name).ToList();
        } 
    }
}