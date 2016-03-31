using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using ELCImagePicker;
using UIKit;
using XamDialogs;

namespace FotoABIld.iOS
{
	partial class EditImageController : UIViewController
	{
		public EditImageController (IntPtr handle) : base (handle)
		{
		}

        public UIImage EditImageControllerImage
        {
            get; set;
        }

        public List<ImageHandler> EditImageControllerList
        {
            get; set;
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            twetImage.Image = EditImageControllerImage;
            foreach (var x in EditImageControllerList)
            {
                if (x.Image.Equals(EditImageControllerImage))
                {
                    Console.WriteLine(x.Path + "\n" + x.Name + "\n" + x.ImageFormat);

                }
            }
            
        }

        //Method to chose amount of copies to be added to the ImageHandler>ImageAmount property.
        //partial void AddImageCopiesBtn_Click(UIBarButtonItem sender)
        //{
        //    var dialog = new XamSimplePickerDialog(new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" })
        //    {
        //        Title = "Antal kopior",
        //        Message = "Välj antal kopior du vill ha av bilden",
        //        BlurEffectStyle = UIBlurEffectStyle.ExtraLight,
        //        CancelButtonText = "Avbryt",
        //        ConstantUpdates = false,
        //    };

        //    dialog.OnSelectedItemChanged += (object s, string e) =>
        //    {
        //        //Since the XAMSImplePickerDIalog is a list of string and our ImageAmount property is of type int. We must parse the string from the list to an Int32.
        //        tImageHandler.ImageAmount = Int32.Parse(e);
        //        //Confirmation pop-up window
        //        UIAlertView alert = new UIAlertView("Antal kopior", tImageHandler.ImageAmount + " kopior", null, "OK", null);
        //        alert.Show();
                
        //    };

        //    dialog.SelectedItem = "1";
        //    dialog.Show();
        //}

        //Method used to save the changes made to the image.
	    //partial void SaveBtn_Click(UIBarButtonItem sender)
	    //{
     //       UIAlertView alert = new UIAlertView(null, tImageHandler.ImageAmount.ToString(), null, "OK", null);
     //       alert.Show();

     //   }
    }
    }
