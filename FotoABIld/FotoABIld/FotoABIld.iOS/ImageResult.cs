using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using UIKit;

namespace FotoABIld.iOS
{     // This class handles the imageview in the cell that is located inside the collectionview
      // It has 3 properties; Id, TheName and TheImage. id is contains a string that has the same value as the reusable cell in the collectionview.
      // TheName has a get and set property. Its function is to handle the name of the image that is being sent through the UICollectionView.
      // TheImage is of UIImageView data type and conatins a "get" property that gets access to the imageview thas is located inside reusablecell. This imageview has the id: imageInCell
	public partial class ImageResult : UICollectionViewCell
	{
        public static readonly NSString Id = new NSString("cellImage");
	    public string TheName { get; set; }

        public ImageResult (IntPtr handle) : base (handle)
        {


        }

        public UIImageView TheImage
        {
            get { return this.imageInCell; }
        }

    }
}
