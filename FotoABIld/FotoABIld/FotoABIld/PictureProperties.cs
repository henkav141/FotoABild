using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace FotoABIld
{   
    
    public sealed class PictureProperties
    {
        public string FilePath { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }

        public PictureProperties(string filePath)
        {
            FilePath = filePath;
            Amount = 1;
            Size = "10x15";
        }

         public PictureProperties(string filePath, int amount, string size)
         {
             FilePath = filePath;
             Amount = amount;
             Size = size;
         }

 
    }
}
