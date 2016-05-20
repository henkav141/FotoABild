using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using UIKit;
using CropBindingiOS;



namespace FotoABIld.iOS
{
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
            
            image = UIImage.FromFile("elcapitan.jpg");
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (!IsShown)
            {

                IsShown = true;
                picker = new TOCropViewController(image);
                PresentViewController(picker, false, null);
            }

            picker.Toolbar.DoneTextButton.TouchUpInside += DoneTextButtonOnTouchUpInside;
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
