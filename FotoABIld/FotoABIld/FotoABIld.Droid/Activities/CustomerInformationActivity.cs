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

namespace FotoABIld.Droid
{
    [Activity(Label = "CustomerInformationActivity", ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class CustomerInformationActivity : Activity
    {
        private Button cancelButton;
        private Button nextButton;
        private TextView nameText;
        private TextView surnameText;
        private TextView phoneNumber;
        private TextView emailText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomerInformation);


            Init();
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
        }

        //Method used to get a list of Pictures instead of PictureProperties. 
        //Will be changed when PictureProperties is changed to Pictures
        //Deserializes a JSON string when sent from another intent
        private List<Pictures> CreatePictureList()
        {
            var objectString = Intent.GetStringExtra("pictureList");
            List<PictureProperties> picturePropertyList = null;
            if (!string.IsNullOrEmpty(objectString))
            {
               picturePropertyList = JsonConvert.DeserializeObject<List<PictureProperties>>(objectString);
            }
            if (picturePropertyList == null) return null;
            var pictureList = picturePropertyList.Select(pictureProperty => 
                new Pictures(pictureProperty.FilePath, pictureProperty.Amount, pictureProperty.Size)).ToList();


            return pictureList;
        } 

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();

        }

        //Continuing to finalizeactivity with the JSON string of the order details.
        private void NextButton_Click(object sender, EventArgs e)
        {
            var order = new Order(nameText.Text,surnameText.Text,emailText.Text,phoneNumber.Text,CreatePictureList()
                );
            var objectString = JsonConvert.SerializeObject(order);
            var next = new Intent(this, typeof(FinalizeActivity));
            next.PutExtra("order", objectString);
            StartActivity(next);
        }
    }
}