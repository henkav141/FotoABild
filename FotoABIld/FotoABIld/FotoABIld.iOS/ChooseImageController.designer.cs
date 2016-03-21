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
		UICollectionView addImageCollectionView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationItem baj { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem bttnNextFromChooseImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (addImageCollectionView != null) {
				addImageCollectionView.Dispose ();
				addImageCollectionView = null;
			}
			if (baj != null) {
				baj.Dispose ();
				baj = null;
			}
			if (bttnNextFromChooseImage != null) {
				bttnNextFromChooseImage.Dispose ();
				bttnNextFromChooseImage = null;
			}
		}
	}
}
