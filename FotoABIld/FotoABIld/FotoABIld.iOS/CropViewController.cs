using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Linq;
using UIKit;
using CropBindingiOS;
using FotoABIld.iOS.Controllers;


namespace FotoABIld.iOS
{
    //Class to handle Cropper.
    partial class CropViewController : UIViewController
	{
        private UIImage image;
        private TOCropViewController picker;
        private bool IsShown;

        public CropViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            foreach (var z in ChooseImageController.ImageHandlerList.Where(z => z.Name.Equals(EditImageController.EditControllerName)))
            {
                image = z.Image;
            }

            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            //Create and show the Crop View Controller.
            if (!IsShown)
            {
                IsShown = true;
                picker = new TOCropViewController(image);
                PresentViewController(picker, false, null);
            }
            
            //picker.Toolbar.DoneTextButton.TouchUpInside += DoneTextButtonOnTouchUpInside;
            picker.Toolbar.DoneIconButton.TouchUpInside += DoneTextButtonOnTouchUpInside;
        }

        private void DoneTextButtonOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            imgV.Image = picker.Image.CroppedImageWithFrame(picker.CropView.CroppedImageFrame, picker.CropView.Angle);
        }


        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }
    }
}
