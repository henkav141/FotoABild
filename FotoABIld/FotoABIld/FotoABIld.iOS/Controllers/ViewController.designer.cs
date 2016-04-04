// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnOrderIphone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView FirstPage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (bttnOrderIphone != null) {
				bttnOrderIphone.Dispose ();
				bttnOrderIphone = null;
			}
			if (FirstPage != null) {
				FirstPage.Dispose ();
				FirstPage = null;
			}
		}
	}
}
