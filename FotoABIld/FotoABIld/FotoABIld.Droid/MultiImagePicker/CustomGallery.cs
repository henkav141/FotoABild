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

namespace FotoABIld.Droid
{
    public class CustomGallery
    {
        public string SdCardPath
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }
    }
}