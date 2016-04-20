using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.UITools;

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
            PopulateListView();
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

        private void PopulateListView()
        {
            var listItems = CreateOrderStrings();

            var adapter = new LayoutAdapter(this, listItems);

            var listView = FindViewById<ListView>(Resource.Id.orderListView);
            
            listView.Adapter = adapter;
        }

        private List<TextView> CreateOrderStrings()
        {
            var lPText = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
            ViewGroup.LayoutParams.MatchParent);
            var list = new List<TextView>();
            foreach (var order in GetOrders())
            {
                var amountHandler = new AmountHandler(order.Pictures);
                var text = (order.Date.ToString("yyyy-M-d") + "   " 
                    + amountHandler.GetTotalAmount() + " bilder" + "   " 
                    + PriceCalculator.CalculateTotalPrice(order.Pictures) + " kr");
                list.Add(ViewCreator.CreateTextView(GravityFlags.NoGravity, lPText, text, this, 20, Color.ParseColor("#1F2F40")));
            }
            return list;
        }

        private void CreateOrderLayouts()
        {
            var lPHorizontal = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent);
            var lPTextView = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);
            //var orderHistoryView = FindViewById<LinearLayout>(Resource.Id.);
            foreach (var order in GetOrders())
            {

                var amountHandler = new AmountHandler(order.Pictures);

                var horizontalLinearLayout = ViewCreator.CreateLinearLayout(this, lPHorizontal,Orientation.Horizontal);
                horizontalLinearLayout.SetGravity(GravityFlags.CenterHorizontal);
                horizontalLinearLayout.SetPadding(0,10,0,0);
                

                var dateText = ViewCreator.CreateTextView(GravityFlags.NoGravity, lPTextView,
                    order.Date.ToString("yyyy-M-d"), this,20, (Color.ParseColor("#1F2F40")));
                
                dateText.PaintFlags = PaintFlags.UnderlineText;


                var amountText = ViewCreator.CreateTextView(GravityFlags.NoGravity, lPTextView,
                    "   " + amountHandler.GetTotalAmount() + " bilder", this, 20, (Color.ParseColor("#1F2F40")));
                
                amountText.PaintFlags = PaintFlags.UnderlineText;

                var priceText = ViewCreator.CreateTextView(GravityFlags.NoGravity, lPTextView,
                    "   " + PriceCalculator.CalculateTotalPrice(order.Pictures) + " kr", this,20, (Color.ParseColor("#1F2F40")));

                
                priceText.PaintFlags = PaintFlags.UnderlineText;
                

                horizontalLinearLayout.AddView(dateText);
                horizontalLinearLayout.AddView(amountText);
                horizontalLinearLayout.AddView(priceText);
                //orderHistoryView.AddView(horizontalLinearLayout);



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