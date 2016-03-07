// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FotoABIld.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnOrder { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView FirstPage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView topDiv { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (bttnOrder != null) {
				bttnOrder.Dispose ();
				bttnOrder = null;
			}
			if (FirstPage != null) {
				FirstPage.Dispose ();
				FirstPage = null;
			}
			if (topDiv != null) {
				topDiv.Dispose ();
				topDiv = null;
			}
		}
	}
}
