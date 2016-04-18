using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FotoABIld
{
    public  class PriceClass
    {
        private List<Pictures> SmallPictures { get; set; }
        private List<Pictures> MediumSmallPictures { get; set; }
        private List<Pictures> MediumLargePictures { get; set; }
        private List<Pictures> LargePictures { get; set; }
        public  List<List<Pictures>> PriceClasses { get; set; }


        public PriceClass(List<Pictures> pictureList)
        {
            PriceClasses = new List<List<Pictures>>();
            SmallPictures =
                pictureList.Where(picture => picture.Size.Equals("10x15") || picture.Size.Equals("11x15")).ToList();
            MediumSmallPictures = 
                pictureList.Where(picture => picture.Size.Equals("13x18(vit kant)") || picture.Size.Equals("15x21")).ToList();
            MediumLargePictures = 
                pictureList.Where(picture => picture.Size.Equals("18x24(vit kant)") || picture.Size.Equals("20x30")).ToList();
            LargePictures = 
                pictureList.Where(picture => picture.Size.Equals("24x30(vit kant)") || picture.Size.Equals("25x38")).ToList();
            if (SmallPictures != null)
            {
                PriceClasses.Add(SmallPictures);
            }
            if (MediumSmallPictures != null)
            {
                PriceClasses.Add(MediumSmallPictures);
            }
            if (MediumLargePictures != null)
            {
                PriceClasses.Add(MediumLargePictures);
            }
            if (LargePictures != null)
            {
                PriceClasses.Add(LargePictures);
            }
        }

        public int GetPriceByClass( )
        {
            return 0;
        }
    }
}
