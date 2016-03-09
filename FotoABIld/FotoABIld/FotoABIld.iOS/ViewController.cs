using System;

using UIKit;

namespace FotoABIld.iOS
{
	public partial class ViewController : UIViewController
	{
        
		public ViewController (IntPtr handle) : base (handle)
		{ 
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            //FirstPage.BackgroundColor = UIColor.FromRGB(255, 208, 66);
            topDivView.BackgroundColor = UIColor.FromRGB(31, 47, 64);
            bttnOrder.BackgroundColor = UIColor.FromRGB(255, 190, 31);
		    bttnOrder.Layer.CornerRadius = 10;
            bttnHistoryIphone.Layer.CornerRadius = 10;
            bttnHistoryIpad.Layer.CornerRadius = 10;

        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
    }
}

