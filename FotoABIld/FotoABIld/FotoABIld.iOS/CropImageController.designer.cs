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
	[Register ("CropImageController")]
	partial class CropImageController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView cropImageView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (cropImageView != null) {
				cropImageView.Dispose ();
				cropImageView = null;
			}
		}
	}
}
