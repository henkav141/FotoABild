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
	[Register ("ImageViewController")]
	partial class ImageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ImagePickerView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ImagePickerView != null) {
				ImagePickerView.Dispose ();
				ImagePickerView = null;
			}
		}
	}
}
