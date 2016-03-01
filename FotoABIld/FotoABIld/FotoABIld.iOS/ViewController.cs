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
            FirstPage.BackgroundColor = UIColor.FromRGB(31, 47, 64);
		    Bttn.BackgroundColor = UIColor.FromRGB(255, 190, 31);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}



    }
}

