using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FotoABildShared.iOS
{
    public class ImageHandler
    {
        public UIImage Image { get; set; }

        public string ImageFormat { get; set; }

        public int ImageAmount { get; set; }


        public ImageHandler(UIImage image)
        {
            Image = image;
            ImageFormat = "10x15";
            ImageAmount = 1;
        }

        public ImageHandler(UIImage image, string format, int amount)
        {
            Image = image;
            ImageFormat = format;
            ImageAmount = amount;

        }
    }
}
