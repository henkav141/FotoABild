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
            SetContentView(Resource.Layout.Receipt);

            priceCalc = new PriceCalculator(CreateSampleList());
            priceCalc.CalculateTotalPrice();
            CreateTextViews(1);
            CreateTextViews(2);
            CreateTextViews(3);
            CreateTextViews(4);
            var readyText = FindViewById<TextView>(Resource.Id.finalPrice).Text = priceCalc.CalculateTotalPrice().ToString();
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
        private List<SharedProperties> CreateSampleList()
        {
            var sharedpropertieslist = new List<SharedProperties>();
            var shared1 = new SharedProperties("", 25, "10x15");
            var shared2 = new SharedProperties("", 420, "15x21");
            var shared3 = new SharedProperties("", 7, "20x30");
            var shared4 = new SharedProperties("", 0, "25x38");
            var shared5 = new SharedProperties("", 0, "25x38");
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

            var size = "";
            var amount = "";
            var price = "";
            var intamount = 0;
            switch (switchSize)
            {
                case 1:
                    size = "10x15";

                    intamount = priceCalc.Size11X15Amount + priceCalc.Size10X15Amount;
                    amount = intamount.ToString();
                    price = priceCalc.CalculateSmall().ToString();
                    break;
                case 2:
                    size = "15x21";
                    intamount = priceCalc.Size13X18Amount + priceCalc.Size15X21Amount;
                    amount = intamount.ToString();
                    price = priceCalc.CalculateMediumSmall().ToString();

                    break;
                case 3:
                    size = "20x30";
                    intamount = priceCalc.Size20X30Amount + priceCalc.Size18X24Amount;
                    amount = intamount.ToString();
                    price = priceCalc.CalculateMediumLarge().ToString();
                    break;
                case 4:
                    size = "25x38";
                    intamount = priceCalc.Size25X38Amount + priceCalc.Size24X30Amount;
                    amount = intamount.ToString();
                    price = priceCalc.CalculateLarge().ToString();
                    break;
            }
            if (intamount == 0) return;

            var sizeLayout = FindViewById<LinearLayout>(Resource.Id.sizeLayout);
            var amountLayout = FindViewById<LinearLayout>(Resource.Id.amountLayout);
            var priceLayout = FindViewById<LinearLayout>(Resource.Id.priceLayout);
            var layoutparams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                LinearLayout.LayoutParams.WrapContent);

            
            


            var sizeText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            sizeText.SetTextColor(Color.Black);
            sizeText.Gravity = GravityFlags.Center;
            sizeText.Text = size;
            sizeLayout.AddView(sizeText);

            var amountText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            amountText.SetTextColor(Color.Black);
            amountText.Gravity = GravityFlags.Center;
                amountText.Text = amount;
            amountLayout.AddView(amountText);

            var priceText = new TextView(this) { LayoutParameters = layoutparams, TextSize = 20 };
            priceText.SetTextColor(Color.Black);
            priceText.Gravity = GravityFlags.Center;
                priceText.Text = price;
            priceLayout.AddView(priceText);
        }

    }
}