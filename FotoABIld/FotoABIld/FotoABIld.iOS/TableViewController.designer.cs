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
		UITableViewCell amountCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountLeftLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountRightLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel formatLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
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
			if (formatLabel != null) {
				formatLabel.Dispose ();
				formatLabel = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
