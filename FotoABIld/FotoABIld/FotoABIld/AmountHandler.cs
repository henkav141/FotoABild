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
        //Method to calculate the amount of a certain size.
        public  int GetAmountofSize(string size)
        {

            return PictureList.Where(picture => picture.Size.Equals(size)).Sum(picture => picture.Amount);
     }

        public int GetTotalAmount()
        {
            return PictureList.Sum(picture => picture.Amount);
        }
    }
}
