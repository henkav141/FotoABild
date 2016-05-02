using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FotoABIld.Droid
{
    [Activity(Label = "CustomerInformationActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class CustomerInformationActivity : AppCompatActivity
    {
        private Button cancelButton;
        private Button nextButton;
        private TextView nameText;
        private TextView surnameText;
        private TextView phoneNumber;
        private TextView emailText;
        private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomerInformation);


            Init();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarItems, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void Init()
        {
            cancelButton = FindViewById<Button>(Resource.Id.CancelButton);
            nextButton = FindViewById<Button>(Resource.Id.NextButton);
            nameText = FindViewById<EditText>(Resource.Id.CustomerInfoNameText);
            surnameText = FindViewById<EditText>(Resource.Id.CustomerInfoSurnameText);
            phoneNumber = FindViewById<EditText>(Resource.Id.CustomerInfoPhoneNumber);
            emailText = FindViewById<EditText>(Resource.Id.CustomerInfoEmailText);

            cancelButton.Click += CancelButton_Click;
            nextButton.Click += NextButton_Click;
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
        }




        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();

        }

        //Continuing to finalizeactivity with the JSON string of the order details.
        private void NextButton_Click(object sender, EventArgs e)
        {
            var pictureList = JsonConvert.DeserializeObject<List<Pictures>>(Intent.GetStringExtra("pictureList"));
            var order = new Order(nameText.Text,surnameText.Text,emailText.Text,phoneNumber.Text,pictureList);
            var objectString = JsonConvert.SerializeObject(order);
            var next = new Intent(this, typeof(FinalizeActivity));
            next.PutExtra("order", objectString);
            StartActivity(next);
        }
    }
}