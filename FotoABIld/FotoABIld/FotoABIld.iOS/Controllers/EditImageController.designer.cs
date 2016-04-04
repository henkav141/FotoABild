// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
	[Register ("EditImageController")]
	partial class EditImageController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView containerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView twetImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (containerView != null) {
				containerView.Dispose ();
				containerView = null;
			}
			if (twetImage != null) {
				twetImage.Dispose ();
				twetImage = null;
			}
		}
	}
}
