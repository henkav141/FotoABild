using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using ELCImagePicker;
using UIKit;
using XamDialogs;

namespace FotoABIld.iOS
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

        public List<ImageHandler> EditImageControllerList
        {
            get; set;
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            twetImage.Image = EditImageControllerImage;
            foreach (var x in EditImageControllerList)
            {
                if (x.Image.Equals(EditImageControllerImage))
                {
                    Console.WriteLine(x.Path + "\n" + x.Name + "\n" + x.ImageFormat);

                }
            }
             
        }
    }
    }
