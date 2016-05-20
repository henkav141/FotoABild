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
	[Register ("CropViewController")]
	partial class CropViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView imgV { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (imgV != null) {
				imgV.Dispose ();
				imgV = null;
			}
		}
	}
}
