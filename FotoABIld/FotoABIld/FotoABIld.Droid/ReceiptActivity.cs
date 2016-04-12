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
using Java.IO;
using Uri = Android.Net.Uri;

namespace FotoABIld.Droid
{
    [Activity(Label = "ReceiptActivity")]
    public class ReceiptActivity : Activity
    {
        
        bool opened = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Receipt);

            //priceCalc = new PriceCalculator(CreateSampleList());
            //priceCalc.CalculateTotalPrice();
            

            //var readyText = FindViewById<TextView>(Resource.Id.finalPrice).Text = priceCalc.CalculateTotalPrice().ToString();
            SetDate();

            // Create your application here
        }

        private void SetDate()
        {
            var datetime = DateTime.Now;
            datetime = datetime.AddHours(1);
            var readyText = FindViewById<TextView>(Resource.Id.thankText);
            readyText.Text = "Din beställning kommer att vara klar " + datetime.ToString("yyyy-MM-dd hh:mm");
            var scale = Resources.DisplayMetrics.Density;
            var dpAsPixels = (int) (60*scale);
            readyText.SetPadding(0,dpAsPixels,0,0);

        }
        private List<Pictures> CreateSampleList()
        {
            var sharedpropertieslist = new List<Pictures>();
            var shared1 = new Pictures("", 25, "10x15");
            var shared2 = new Pictures("", 420, "15x21");
            var shared3 = new Pictures("", 7, "20x30");
            var shared4 = new Pictures("", 0, "25x38");
            var shared5 = new Pictures("", 1, "25x38");
            sharedpropertieslist.Add(shared1);
            sharedpropertieslist.Add(shared2);
            sharedpropertieslist.Add(shared3);
            sharedpropertieslist.Add(shared4);
            sharedpropertieslist.Add(shared5);
            return sharedpropertieslist;
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            if (!opened) return;
            opened = false;
            var pdfcreator = new PdfHandler();
            pdfcreator.CreateDocument(FindViewById(Resource.Id.receiptlayout));
            File file = new File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/hej.pdf");
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(Uri.FromFile(file), "application/pdf");
            intent.SetFlags(ActivityFlags.NoHistory);
            StartActivity(intent);
        }

        private void CreateTextViews(string switchSize)
        {
            //var amounthandler = new AmountHandler(CreateSampleList());
            //var size = "";
            //var amount = "";
            //var price = "";
            //switch (switchSize)
            //{
            //    case "10x15": case "11x15":
            //        size = "10x15 och 11x15";
            //        amount = amounthandler.GetAmountofSize(switchSize).ToString();
            //        price = priceCalc.CalculateSmall().ToString();
            //        break;
            //    case "15x21":
            //    case "13x18(vit kant)":
            //        size = "13x18 och 15x21";
            //        amount = amounthandler.GetAmountofSize(switchSize).ToString();
            //        price = priceCalc.CalculateMediumSmall().ToString();

            //        break;
            //    case "18x24(vit kant)":
            //    case "20x30":
            //        size = "13x18 och 20x30";
            //        intamount = priceCalc.Size20X30Amount + priceCalc.Size18X24Amount;
            //        amount = intamount.ToString();
            //        price = priceCalc.CalculateMediumLarge().ToString();
            //        break;
            //    case "24x30(vit kant)":
            //    case "25x38":
            //        size = "24x30 och 25x38";
            //        intamount = priceCalc.Size25X38Amount + priceCalc.Size24X30Amount;
            //        amount = intamount.ToString();
            //        price = priceCalc.CalculateLarge().ToString();
            //        break;
            //}


            //var sizeLayout = FindViewById<LinearLayout>(Resource.Id.sizeLayout);
            //var amountLayout = FindViewById<LinearLayout>(Resource.Id.amountLayout);
            //var priceLayout = FindViewById<LinearLayout>(Resource.Id.priceLayout);
            //var layoutparams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
            //    LinearLayout.LayoutParams.WrapContent);

            
            


            //var sizeText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            //sizeText.SetTextColor(Color.Black);
            //sizeText.Gravity = GravityFlags.Center;
            //sizeText.Text = size;
            //sizeLayout.AddView(sizeText);

            //var amountText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            //amountText.SetTextColor(Color.Black);
            //amountText.Gravity = GravityFlags.Center;
            //    amountText.Text = amount;
            //amountLayout.AddView(amountText);

            //var priceText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            //priceText.SetTextColor(Color.Black);
            //priceText.Gravity = GravityFlags.Center;
            //    priceText.Text = price;
            //priceLayout.AddView(priceText);
        }

    }
}