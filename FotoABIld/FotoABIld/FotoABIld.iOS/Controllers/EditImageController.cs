using System;
using System.Collections.Generic;
using CoreFoundation;
using Foundation;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
    
	partial class EditImageController : UIViewController
	{

        public EditImageController (IntPtr handle) : base (handle)
		{
		}

        public UIImage EditImageControllerImage
        {
            get; set;
        }

        public static int ImageIndex
        {
            get; set;
        }

        public static string EditControllerName
        {
            get; set;
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            twetImage.Image = EditImageControllerImage;
            barbtn.Clicked += BarbtnOnClicked;
            Console.WriteLine(EditControllerName);
        }

	    private void BarbtnOnClicked(object sender, EventArgs eventArgs)
	    {

	                
	    }


    }
}