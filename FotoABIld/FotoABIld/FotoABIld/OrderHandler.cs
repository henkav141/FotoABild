using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public static class OrderHandler    
    {
        public static string CreateOrderId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        
        }
        public static  void CreateOutputFolder(string filepath)
        {
            Directory.CreateDirectory(filepath);
        }

        public static void FillOutPutFolder(Order order, string targetPath)
        {

            for (var index = 0; index < order.Pictures.Count; index++)
            {

                var picture = order.Pictures[index];
                if(!File.Exists(targetPath + picture.Name))
                File.Copy(picture.FilePath, targetPath + picture.Name );


            }
        }
    }

}
