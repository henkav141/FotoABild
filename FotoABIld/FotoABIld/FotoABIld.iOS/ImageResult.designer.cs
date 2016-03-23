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
	[Register ("ImageResult")]
	partial class ImageResult
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView bild { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (bild != null) {
				bild.Dispose ();
				bild = null;
			}
		}
	}
}
