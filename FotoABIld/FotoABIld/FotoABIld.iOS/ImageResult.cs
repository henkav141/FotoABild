using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FotoABIld.iOS
{
	public partial class ImageResult : UICollectionViewCell
	{
        public static readonly NSString Id = new NSString("cellImage");


        public ImageResult (IntPtr handle) : base (handle)
        {


        }
        public UIImageView TheImage
        {
            get { return this.bild; }
        }

    }
}
