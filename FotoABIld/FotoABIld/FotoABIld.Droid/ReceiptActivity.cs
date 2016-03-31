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
        private PriceCalculator priceCalc;
        bool opened = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.receiptlayout);

            priceCalc = new PriceCalculator(CreateSampleList());
            priceCalc.CalculateTotalPrice();
            CreateTextViews(1);
            CreateTextViews(2);
            CreateTextViews(3);
            CreateTextViews(4);
            FindViewById<TextView>(Resource.Id.finalPrice).Text = priceCalc.CalculateTotalPrice().ToString();

            // Create your application here
        }

        private List<SharedProperties> CreateSampleList()
        {
            var sharedpropertieslist = new List<SharedProperties>();
            var shared1 = new SharedProperties("", 25, "10x15");
            var shared2 = new SharedProperties("", 420, "15x21");
            var shared3 = new SharedProperties("", 7, "20x30");
            var shared4 = new SharedProperties("", 2, "25x38");
            var shared5 = new SharedProperties("", 7, "25x38");
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
            var pdfcreator = new PdfCreator();
            pdfcreator.CreateDocument(FindViewById(Resource.Id.receiptlayout));
            File file = new File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/hej.pdf");
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(Uri.FromFile(file), "application/pdf");
            intent.SetFlags(ActivityFlags.NoHistory);
            StartActivity(intent);
        }

        private void CreateTextViews(int switchSize)
        {
            var sizeLayout = FindViewById<LinearLayout>(Resource.Id.sizeLayout);
            var amountLayout = FindViewById<LinearLayout>(Resource.Id.amountLayout);
            var priceLayout = FindViewById<LinearLayout>(Resource.Id.priceLayout);
            var layoutparams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                LinearLayout.LayoutParams.WrapContent);
            var size = "";
            var amount = "";
            var price = "";
            
            
            switch (switchSize)
            {
                case 1:
                    size = "10x15";
                    amount = priceCalc.Size1Amount.ToString();
                    price = priceCalc.Calculate1().ToString();
                    break;
                case 2:
                    size = "15x21";
                    amount = priceCalc.Size2Amount.ToString();
                    price = priceCalc.Calculate2().ToString();
                    
                    break;
                case 3:
                    size = "20x30";
                    amount = priceCalc.Size3Amount.ToString();
                    price = priceCalc.Calculate3().ToString();
                    break;
                case 4:
                    size = "25x38";
                    amount = priceCalc.Size4Amount.ToString();
                    price = priceCalc.Calculate4().ToString();
                    break;
            }

            var sizeText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            sizeText.SetTextColor(Color.Black);
            sizeText.Gravity = GravityFlags.Center;
            sizeText.Text = size;
            sizeLayout.AddView(sizeText);

            var amountText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            amountText.SetTextColor(Color.Black);
            amountText.Gravity = GravityFlags.Center;
            if (size.Equals("10x15"))
                amountText.Text = amount;
            if(size.Equals("15x21"))
                amountText.Text = priceCalc.Size2Amount.ToString();
            if (size.Equals("20x30"))
                amountText.Text = priceCalc.Size3Amount.ToString();
            if (size.Equals("25x38"))
                amountText.Text = priceCalc.Size4Amount.ToString();
            amountLayout.AddView(amountText);

            var priceText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            priceText.SetTextColor(Color.Black);
            priceText.Gravity = GravityFlags.Center;
            if (size.Equals("10x15"))
                priceText.Text = price;
            if (size.Equals("15x21"))
                priceText.Text = price;
            if (size.Equals("20x30"))
                priceText.Text = price;
            if (size.Equals("25x38"))
                priceText.Text = price;
            priceLayout.AddView(priceText);
        }

    }
}