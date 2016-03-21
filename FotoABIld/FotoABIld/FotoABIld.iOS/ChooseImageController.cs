using Foundation;
using System;
using System.CodeDom.Compiler;
using CoreGraphics;
using UIKit;

namespace FotoABIld.iOS
{
    partial class ChooseImageController : UIViewController
    {
        public ChooseImageController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //UIImageView vap = new UIImageView(UIImage.FromFile("FOTOABILD Logga-knapp.png"));
            //vap.Frame = new CGRect(0, 0, 30, 30);
            //vap.ContentMode = UIViewContentMode.ScaleAspectFit;
            //baj.TitleView = vap;
        }
    }
}
