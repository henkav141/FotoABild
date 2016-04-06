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
            return PictureList.Count(pictures => pictures.Size.Equals(switchSize));
        }
    }
}
