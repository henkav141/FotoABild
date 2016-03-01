using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FotoABIld.Droid
{
	[Activity (Label = "FotoABIld.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


		}
	}
}


