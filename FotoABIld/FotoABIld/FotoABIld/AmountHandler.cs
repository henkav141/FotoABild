using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public  class AmountHandler   
    {
        private  List<Pictures> PictureList { get; set; }
        public AmountHandler(List<Pictures> pictureList)
        {
            PictureList = pictureList;
        }
        public  int GetAmountofSize(string switchSize)
        {

            return PictureList.Where(picture => picture.Size.Equals(switchSize)).Sum(picture => picture.Amount);
     }
    }
}
