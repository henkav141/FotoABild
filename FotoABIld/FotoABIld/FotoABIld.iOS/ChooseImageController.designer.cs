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
		UIButton addImagesBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem bttnNextFromChooseImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView imageCollection { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem nextBtn { get; set; }

		[Action ("AddImagesBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AddImagesBtn_TouchUpInside (UIButton sender);

		[Action ("NextBtn_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void NextBtn_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (addImagesBtn != null) {
				addImagesBtn.Dispose ();
				addImagesBtn = null;
			}
			if (bttnNextFromChooseImage != null) {
				bttnNextFromChooseImage.Dispose ();
				bttnNextFromChooseImage = null;
			}
			if (imageCollection != null) {
				imageCollection.Dispose ();
				imageCollection = null;
			}
			if (nextBtn != null) {
				nextBtn.Dispose ();
				nextBtn = null;
			}
		}
	}
}
