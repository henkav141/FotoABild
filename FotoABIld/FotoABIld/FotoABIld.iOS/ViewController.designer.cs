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
		UIView FirstPage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationItem hej { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FirstPage != null) {
				FirstPage.Dispose ();
				FirstPage = null;
			}
			if (hej != null) {
				hej.Dispose ();
				hej = null;
			}
		}
	}
}
