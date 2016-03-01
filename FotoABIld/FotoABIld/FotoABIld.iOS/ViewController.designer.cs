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
		UIButton Bttn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Button { get; set; }

		[Action ("Bttn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Bttn_TouchUpInside (UIButton sender);

		[Action ("UIButton6_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIButton6_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (Bttn != null) {
				Bttn.Dispose ();
				Bttn = null;
			}
			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}
		}
	}
}
