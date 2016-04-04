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
	[Register ("TableViewController")]
	partial class TableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell addACopyCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel addCopyLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell amountCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountLeftLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountRightLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell cropImageCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel cropImageLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell formatCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel formatLeftLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel formatRightLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (addACopyCell != null) {
				addACopyCell.Dispose ();
				addACopyCell = null;
			}
			if (addCopyLabel != null) {
				addCopyLabel.Dispose ();
				addCopyLabel = null;
			}
			if (amountCell != null) {
				amountCell.Dispose ();
				amountCell = null;
			}
			if (amountLeftLabel != null) {
				amountLeftLabel.Dispose ();
				amountLeftLabel = null;
			}
			if (amountRightLabel != null) {
				amountRightLabel.Dispose ();
				amountRightLabel = null;
			}
			if (cropImageCell != null) {
				cropImageCell.Dispose ();
				cropImageCell = null;
			}
			if (cropImageLabel != null) {
				cropImageLabel.Dispose ();
				cropImageLabel = null;
			}
			if (formatCell != null) {
				formatCell.Dispose ();
				formatCell = null;
			}
			if (formatLeftLabel != null) {
				formatLeftLabel.Dispose ();
				formatLeftLabel = null;
			}
			if (formatRightLabel != null) {
				formatRightLabel.Dispose ();
				formatRightLabel = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
