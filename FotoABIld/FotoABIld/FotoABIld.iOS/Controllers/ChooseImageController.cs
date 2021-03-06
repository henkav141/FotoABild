using System;
using System.Collections.Generic;
using System.Linq;
using AVFoundation;
using ELCImagePicker;
using Foundation;
using UIKit;

namespace FotoABIld.iOS.Controllers
{
    partial class ChooseImageController : UIViewController, IUICollectionViewDataSource
    {
        public static List<ImageHandler> ImageHandlerList = new List<ImageHandler>();

        public ChooseImageController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Tillbaka";
            this.NavigationItem.TitleView = new UIView();
            imageCollection.WeakDataSource = this;

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            imageCollection.ReloadData();

        }


        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return ImageHandlerList.Count;
        }



        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            
            var cell = (ImageResult)collectionView.DequeueReusableCell(ImageResult.Id, indexPath);
            var asset = ImageHandlerList[indexPath.Row];
            cell.TheImage.Image = asset.Image;
            cell.TheName = asset.Name;
            return cell;

        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var destination = (EditImageController)segue.DestinationViewController;
            var imageToPass = (ImageResult)sender;

            //Give the properties in DestinationViewController value of the locale variables e.g. the name of the image and the selected image.
            destination.EditImageControllerImage = imageToPass.TheImage.Image;
            EditImageController.EditControllerName = imageToPass.TheName;
        }


        partial void AddImagesBtn_TouchUpInside(UIButton sender)
        {
            //create a new instance of the picker view controller
            var picker = ELCImagePickerViewController.Instance;

            //set the maximum number of images that can be selected
            picker.MaximumImagesCount = 200;

            //setup the handling of completion once the items have been picked or the picker has been cancelled
            picker.Completion.ContinueWith(t =>
            {
                //execute any UI code on the UI thread
                this.BeginInvokeOnMainThread(() =>
                {
                    //dismiss the picker
                    picker.DismissViewController(true, null);

                    if (t.IsCanceled || t.Exception != null)
                    {
                        //cancelled or error
                    }
                    else
                    {
                        //get the selected items
                        var items = t.Result as List<AssetResult>;

                        foreach (AssetResult aItem in items)
                        {
                            
                            var x = new ImageHandler(aItem.Image, aItem.Path, aItem.Name);
                            ImageHandlerList.Add(x);
                        }

                        imageCollection.ReloadData();

                    }
                });
            });


            this.PresentViewController(picker, true, null);
        }

        // Test code for button
        partial void NextBtn_Activated(UIBarButtonItem sender)
        {
            foreach (var t in ImageHandlerList)
            {
                Console.WriteLine("Namn: "+ t.Name + "\n" + "Path: " + t.Path + "\n" + "Hur m�nga: " + t.ImageAmount + "\n" + "Storlek: " + t.ImageFormat);
            }
        }
    }
}

