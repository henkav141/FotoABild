using System;
using System.Collections.Generic;
using System.Drawing;
using CoreFoundation;
using CoreGraphics;
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

        public static string EditControllerName
        {
            get; set;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            this.Title = "Tillbaka";
            this.NavigationItem.TitleView = new UIView();
            twetImage.Image = EditImageControllerImage;
            Console.WriteLine(EditControllerName);
        }
    }
}