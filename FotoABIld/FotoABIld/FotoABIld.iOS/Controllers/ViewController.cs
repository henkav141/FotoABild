﻿using System;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
	public partial class ViewController : UIViewController
	{
        // No code here since the segue is being initialized in the design mode
        public ViewController (IntPtr handle) : base (handle)
		{ 

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		    this.Title = "Tillbaka";
            this.NavigationItem.TitleView = new UIView();
		    // Perform any additional setup after loading the view, typically from a nib.

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            // Release any cached data, images, etc that aren't in use.
        }

    }
}

