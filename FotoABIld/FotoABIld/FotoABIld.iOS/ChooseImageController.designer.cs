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
	[Register ("ChooseImageController")]
	partial class ChooseImageController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton addImages { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem bttnNextFromChooseImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ChooseImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView imageCollection { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem nextButton { get; set; }

		[Action ("AddImages_TouchUpInside")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AddImages_TouchUpInside ();

		void ReleaseDesignerOutlets ()
		{
			if (addImages != null) {
				addImages.Dispose ();
				addImages = null;
			}
			if (bttnNextFromChooseImage != null) {
				bttnNextFromChooseImage.Dispose ();
				bttnNextFromChooseImage = null;
			}
			if (ChooseImageView != null) {
				ChooseImageView.Dispose ();
				ChooseImageView = null;
			}
			if (imageCollection != null) {
				imageCollection.Dispose ();
				imageCollection = null;
			}
			if (nextButton != null) {
				nextButton.Dispose ();
				nextButton = null;
			}
		}
	}
}
