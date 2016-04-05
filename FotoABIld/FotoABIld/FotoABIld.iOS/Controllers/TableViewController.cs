using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using XamDialogs;

namespace FotoABIld.iOS.Controllers
{
    
	partial class TableViewController : UITableViewController
	{

        public TableViewController (IntPtr handle) : base (handle)
        {

        }


        public override void ViewDidAppear(bool animated)
        {
            foreach (var z in EditImageController.EditImageControllerList)
            {
                if (z.Image.Equals(EditImageController.EditImageControllerImage))
                {
                    amountRightLabel.Text = z.ImageAmount.ToString();
                    formatRightLabel.Text = z.ImageFormat;
                }
            }
        }

        //This method handles the event when a row is clicked in the UITableView
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //base.RowSelected (tableView, indexPath);

            //Checks indexpath at UITableView and creates appropriate picker
            if (tableView.CellAt(indexPath).Equals(amountCell))
            {
                var dialog = new XamSimplePickerDialog(new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" })
                {
                    Title = "Antal kopior",
                    Message = "Välj antal kopior du vill ha av bilden",
                    BlurEffectStyle = UIBlurEffectStyle.ExtraLight,
                    CancelButtonText = "Avbryt",
                    ConstantUpdates = false,
                };
                //Code to decide what to happen when an object in the picker is chosen
                dialog.OnSelectedItemChanged += (object s, string e) =>
                {
                    foreach (var x in EditImageController.EditImageControllerList)
                    {
                        if (x.Image.Equals(EditImageController.EditImageControllerImage))
                        {
                            x.ImageAmount = Int32.Parse(dialog.SelectedItem);
                            amountRightLabel.Text = dialog.SelectedItem;
                        }
                    }

                };

                dialog.SelectedItem = "1";
                dialog.Show();
            }

            //Checks indexpath at UITableView and creates appropriate picker
            else if (tableView.CellAt(indexPath).Equals(formatCell))
            {
                var dialog = new XamSimplePickerDialog(new List<string>() { "10x15", "11x15", "13x18 - Vit kant", "15x21", "18x24 - Vit kant", "20x30", "24x30 - Vit kant", "25x38"})
                {
                    Title = "Format",
                    Message = "Välj vilket format du vill ha av bilden",
                    BlurEffectStyle = UIBlurEffectStyle.ExtraLight,
                    CancelButtonText = "Avbryt",
                    ConstantUpdates = false,
                };

                dialog.OnSelectedItemChanged += (object s, string e) =>
                {
                    foreach (var x in EditImageController.EditImageControllerList)
                    {
                        if (x.Image.Equals(EditImageController.EditImageControllerImage))
                        {
                            x.ImageFormat = dialog.SelectedItem;
                            formatRightLabel.Text = dialog.SelectedItem;
                        }
                    }
                };

                dialog.SelectedItem = "10x15";
                dialog.Show();
            }

            else if (tableView.CellAt(indexPath).Equals(addACopyCell))
            {
                Console.WriteLine(addACopyCell.TextLabel);
            }

            else if (tableView.CellAt(indexPath).Equals(cropImageCell))
            {
                Console.WriteLine(cropImageCell.TextLabel);
            }

        }
    }
}
