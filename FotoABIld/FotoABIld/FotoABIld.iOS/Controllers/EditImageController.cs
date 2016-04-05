using System;
using System.Collections.Generic;
using CoreFoundation;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
    
	partial class EditImageController : UIViewController
	{

        public EditImageController (IntPtr handle) : base (handle)
		{
		}

        public static UIImage EditImageControllerImage
        {
            get; set;
        }

        public static List<ImageHandler> EditImageControllerList
        {
            get; set;
        }




	    public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            twetImage.Image = EditImageControllerImage;
            barbtn.Clicked += BarbtnOnClicked;

        }

	    private void BarbtnOnClicked(object sender, EventArgs eventArgs)
	    {
	        foreach (var g in EditImageControllerList)
	        {
	            if (g.Image.Equals(twetImage.Image))
	            {
	                Console.WriteLine(g.ImageAmount);
                    Console.WriteLine(g.ImageFormat);
	                ChooseImageController.ImageHandlerList = EditImageControllerList;
	            }
	        }
        }
	}
    }
    
