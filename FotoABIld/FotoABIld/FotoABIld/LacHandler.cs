using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FotoABIld
{
    public  class LacHandler
    {
        private Order order;
        private string folderfilepath;
        private string lacfilepath;
        private List<FileInfo> fileInfoList;
        public LacHandler(Order order, string lacfilepath, string folderfilepath)
        {
            this.order = order;
            this.folderfilepath = folderfilepath;
            this.lacfilepath = lacfilepath;
            fileInfoList = new List<FileInfo>();
        }
        public  void CreateLacFile()
        {
            GetFileInfo();
            var lacText = new List<string> {FillUserDetails(), FillOrderDetails(), FillFilesTransmitted(), FillFileSizes() };
            
            File.WriteAllLines(lacfilepath, lacText);
        }

        private   string FillUserDetails()
        {
            return "[User Details]" + "\r\n" +
                   "FirstName=" + order.Name + "\r\n" +
                   "Email=" + order.Email + "\r\n" +
                   "LastName=" + order.Surname + "\r\n" +
                   "Phone=" + order.PhoneNumber + "\r\n";

        }

        private  string FillOrderDetails()
        {
            return "[Order Details]\r\n" +
                   "OrderReference=\r\n" +
                   "orderid=" + order.OrderId + "\r\n" +
                   "TotalPrice=" + PriceCalculator.CalculateTotalPrice(order.Pictures) + "\r\n" +
                   "OrderDate=" + DateTime.Now.ToString("dd/MM/yy hh:mm") + "\r\n" +
                   "ReturnDate=" + order.Date.ToString("dd/MM/yy hh:mm") + "\r\n";

        }

        private  string FillFilesTransmitted()
        {
            var transmittedString = "[Files Transmitted]\r\n";
            for (int index = 0; index < fileInfoList.Count; index++)
            {
                var fileInfo = fileInfoList[index];
                transmittedString += index + 1 + "=" + fileInfo.FullName + "\r\n";
            }
            return transmittedString;
        }

        private string FillFileSizes()
        {
            var sizeString = "[File Sizes]\r\n";
            for (int index = 0; index < fileInfoList.Count; index++)
            {
                var fileInfo = fileInfoList[index];
                sizeString = index + 1 + "=" + fileInfo.Length + "\r\n";
            }
            return sizeString;
        }

        private  void GetFileInfo()
        {
            var filenames = Directory.GetFiles(folderfilepath,"*.jpeg");
            foreach (var filename in filenames)
            {
                var fileinfo = new FileInfo(filename);
                fileInfoList.Add(fileinfo);
            }
        }
    }
}
