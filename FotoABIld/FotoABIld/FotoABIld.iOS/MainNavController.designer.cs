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
	[Register ("MainNavController")]
	partial class MainNavController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIToolbar bottomToolbar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationBar mainNavBar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (bottomToolbar != null) {
				bottomToolbar.Dispose ();
				bottomToolbar = null;
			}
			if (mainNavBar != null) {
				mainNavBar.Dispose ();
				mainNavBar = null;
			}
		}
	}
}
