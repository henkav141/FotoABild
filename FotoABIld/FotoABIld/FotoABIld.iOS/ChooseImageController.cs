using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using AssetsLibrary;
using CoreGraphics;
using ELCImagePicker;
using UIKit;

namespace FotoABIld.iOS
{
    partial class ChooseImageController : UIViewController, IUICollectionViewDataSource
    {
        private List<AssetResult> mResults = new List<AssetResult>();

        public ChooseImageController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            imageCollection.WeakDataSource = this;

        }



        partial void AddImages_TouchUpInside()
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
                            mResults.Add(aItem);
                        }

                        imageCollection.ReloadData();

                    }
                });
            });


            this.PresentViewController(picker, true, null);

        }


        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return mResults.Count;
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            
            var cell = (ImageResult)collectionView.DequeueReusableCell(ImageResult.Id, indexPath);
            var asset = mResults[indexPath.Row]; ;
            cell.TheImage.Image = asset.Image;

            return cell;

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var vc = (Grattis)segue.DestinationViewController;
            var cell = (ImageResult)sender;

            vc.TheImage = cell.TheImage.Image;
        }
    }
}

