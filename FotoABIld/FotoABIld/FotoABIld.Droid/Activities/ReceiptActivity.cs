using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FotoABIld.Droid.UITools;
using Java.IO;
using Newtonsoft.Json;
using Uri = Android.Net.Uri;

namespace FotoABIld.Droid
{
    [Activity(Label = "ReceiptActivity")]
    public class ReceiptActivity : Activity
    {
        
        bool opened = true;
        private Order order;
        //Class that creates the receipt. Commented because of errors after changing the PriceCalculator.
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Receipt);

            order = JsonConvert.DeserializeObject<Order>(Intent.GetStringExtra("order"));
            var priceClass = new PriceClass(order.Pictures);

            SummarizePictures(priceClass);
            FindViewById<TextView>(Resource.Id.finalPrice).Text = PriceCalculator.CalculateTotalPrice(order.Pictures).ToString();
            FindViewById<TextView>(Resource.Id.orderNumberText).Text = order.OrderId;
            SetDate();

            
        }

        private void SetDate()
        {

            var readyText = FindViewById<TextView>(Resource.Id.thankText);
            readyText.Text = "Din beställning kommer att vara klar " + order.Date.ToString("yyyy-MM-dd hh:mm");
            var scale = Resources.DisplayMetrics.Density;
            var dpAsPixels = (int) (60*scale);
            readyText.SetPadding(0,dpAsPixels,0,0);

        }


        public override void OnWindowFocusChanged(bool hasFocus)
        {
            //if (!opened) return;
            //opened = false;
            //var pdfcreator = new PdfHandler();
            //pdfcreator.CreateDocument(FindViewById(Resource.Id.receiptlayout));
            //File file = new File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/¨test.pdf");
            //Intent intent = new Intent(Intent.ActionView);
            //intent.SetDataAndType(Uri.FromFile(file), "application/pdf");
            //intent.SetFlags(ActivityFlags.NoHistory);
            //StartActivity(intent);
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
                ViewGroup.LayoutParams.WrapContent, 1);
            var lPHorizontalWeight2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.WrapContent, 2);
            var lPPrice = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MatchParent, 1);


            var summarizeLayout = FindViewById<LinearLayout>(Resource.Id.summarizeOrder);
            summarizeLayout.AddView(ViewCreator.CreateDivider(this, Color.ParseColor("#1F2F40")));
            foreach (List<Pictures> picturelist in priceClass.PriceClasses)
            {
                var horizontalLayout = ViewCreator.CreateLinearLayout(this, lpNoWeight, Orientation.Horizontal);

                var sizeLayout = ViewCreator.CreateLinearLayout(this, lPWeight2, Orientation.Vertical);

                var amountLayout = ViewCreator.CreateLinearLayout(this, lPWeight1, Orientation.Vertical);


                var differentSizes = picturelist.Select(picture => picture.Size).Distinct().ToList();
                differentSizes = differentSizes.OrderBy(size => size).ToList();

                summarizeLayout.AddView(horizontalLayout);
                horizontalLayout.AddView(sizeLayout);
                horizontalLayout.AddView(amountLayout);
                foreach (var size in differentSizes)
                {
                    var sizeText = ViewCreator.CreateTextView(GravityFlags.Left, lPHorizontalWeight2, size, this, 20, Color.Black);
                    sizeText.SetBackgroundColor(Color.NavajoWhite);
                    var amountText = ViewCreator.CreateTextView(GravityFlags.CenterHorizontal, lPHorizontalWeight1,
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
                    var priceText = ViewCreator.CreateTextView(GravityFlags.Right, lPPrice,
                    price, this, 20, Color.Black);
                    horizontalLayout.AddView(priceText);
                }
                summarizeLayout.AddView(ViewCreator.CreateDivider(this, Color.ParseColor("#1F2F40")));
            }
        }

    }
}