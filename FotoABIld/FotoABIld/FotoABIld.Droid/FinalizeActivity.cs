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
            phoneNumber = FindViewById<TextView>(Resource.Id.finalizeEmail);
            
            order = JsonConvert.DeserializeObject<Order>(objectString);
            nameSurname.Text = order.Name + " " + order.Surname;
            email.Text = order.Email;
            phoneNumber.Text = order.PhoneNumber;

            cancelButton.Click += CancelButton_Click;
        }

        private void AddTableRow()
        {
            List<String> differentSizes = (order.Pictures.Select(picture => picture.Size).Distinct().ToList());
            var tableLayout = FindViewById<TableLayout>(Resource.Id.amountTable);
            foreach (var size in differentSizes)
            {
                var tableRow = new TableRow(this);

                
                var layoutParameters = new TableRow.LayoutParams(TableRow.LayoutParams.WrapContent, TableRow.LayoutParams.WrapContent, 1f);
                var params2 = new TableRow.LayoutParams(TableRow.LayoutParams.FillParent, TableRow.LayoutParams.WrapContent);
                var textView = new TextView(this);
                textView.LayoutParameters = layoutParameters;
                textView.Text = size;
                textView.Gravity = GravityFlags.Left;
                textView.SetTextColor(Color.ParseColor("#1F2F40"));
                textView.SetTextSize(ComplexUnitType.Dip,20);
                tableRow.LayoutParameters = params2;
                tableRow.AddView(textView);
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