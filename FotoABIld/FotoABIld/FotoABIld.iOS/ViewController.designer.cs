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
		UIView botDivView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnHistoryIpad { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnHistoryIphone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnOrder { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton bttnOrderIpad { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView FirstPage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView logoBackgroundViewLeft { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView logoBackgroundViewRight { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView logoType { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (botDivView != null) {
				botDivView.Dispose ();
				botDivView = null;
			}
			if (bttnHistoryIpad != null) {
				bttnHistoryIpad.Dispose ();
				bttnHistoryIpad = null;
			}
			if (bttnHistoryIphone != null) {
				bttnHistoryIphone.Dispose ();
				bttnHistoryIphone = null;
			}
			if (bttnOrder != null) {
				bttnOrder.Dispose ();
				bttnOrder = null;
			}
			if (bttnOrderIpad != null) {
				bttnOrderIpad.Dispose ();
				bttnOrderIpad = null;
			}
			if (FirstPage != null) {
				FirstPage.Dispose ();
				FirstPage = null;
			}
			if (logoBackgroundViewLeft != null) {
				logoBackgroundViewLeft.Dispose ();
				logoBackgroundViewLeft = null;
			}
			if (logoBackgroundViewRight != null) {
				logoBackgroundViewRight.Dispose ();
				logoBackgroundViewRight = null;
			}
			if (logoType != null) {
				logoType.Dispose ();
				logoType = null;
			}
		}
	}
}
