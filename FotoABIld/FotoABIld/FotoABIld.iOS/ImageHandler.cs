using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FotoABIld.iOS
{
    public class ImageHandler
    {
        public UIImage Image { get; set; }

        public string ImageFormat { get; set; }

        public int ImageAmount { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }


        public ImageHandler(UIImage image, string path, string name)
        {
            Image = image;
            ImageFormat = "10x15";
            ImageAmount = 1;
            Path = path;
            Name = name;

        }

        public ImageHandler(UIImage image, string format, int amount, string path, string name)
        {
            Image = image;
            ImageFormat = format;
            ImageAmount = amount;
            Path = path;
            Name = name;

        }
    }
}
