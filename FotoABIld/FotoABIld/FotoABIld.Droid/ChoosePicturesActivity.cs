using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Widget.NumberPicker;

namespace FotoABIld.Droid
{
    [Activity(Label = "ChoosePicturesActivity")]
    public class ChoosePicturesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ChoosePictures);

            
            
            

 


        }
    }
}