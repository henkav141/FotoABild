using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public class LacHandler
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
        public void CreateLacFile()
        {
            GetFileInfo();
            var lacText = new List<string> { FillUserDetails(), FillOrderDetails(), FillFilesTransmitted(), FillFileSizes(), FillFitOrFill(), Fill10X15() };

            File.WriteAllLines(lacfilepath, lacText);
        }

        private string FillUserDetails()
        {
            return "[User Details]" + "\r\n" +
                   "FirstName=" + order.Name + "\r\n" +
                   "Email=" + order.Email + "\r\n" +
                   "LastName=" + order.Surname + "\r\n" +
                   "Phone=" + order.PhoneNumber + "\r\n";

        }

        private string FillOrderDetails()
        {
            return "[Order Details]\r\n" +
                   "OrderReference=\r\n" +
                   "orderid=" + order.OrderId + "\r\n" +
                   "TotalPrice=" + PriceCalculator.CalculateTotalPrice(order.Pictures) + "\r\n" +
                   "OrderDate=" + DateTime.Now.ToString("dd/MM/yy hh:mm") + "\r\n" +
                   "ReturnDate=" + order.Date.ToString("dd/MM/yy hh:mm") + "\r\n";

        }

        private string FillFilesTransmitted()
        {
            var transmittedString = "[Files Transmitted]\r\n";
            //for (int index = 0; index < fileInfoList.Count; index++)
            //{
            //    var fileInfo = fileInfoList[index];
            //    transmittedString += index + 1 + "=" + fileInfo.FullName + "\r\n";
            //}
            var index = 1;

            foreach (var picture in order.Pictures)
            {
                transmittedString += index + "=" + picture.FilePath + "\r\n";
                index++;
            }

            return transmittedString;
        }

        private string FillFileSizes()
        {
            var sizeString = "[File Sizes]\r\n";
            //for (int index = 0; index < fileInfoList.Count; index++)
            //{
            //    var fileInfo = fileInfoList[index];
            //    sizeString += index + 1 + "=" + fileInfo.Length + "\r\n";
            //}
            var index = 1;
            foreach (var picture in order.Pictures)
            {
                var fileInfo = fileInfoList[index - 1];
                sizeString += index + "=" + fileInfo.Length + "\r\n";
                index++;
            }
            return sizeString;
        }

        private string FillFitOrFill()
        {
            var fitOrFillString = "[FitOrFill]\r\n";
            var index = 1;
            foreach (var picture in order.Pictures)
            {
                fitOrFillString += index + "=" + picture.FitOrFill + "\r\n";
                index++;
            }
            return fitOrFillString;
        }

        private string Fill10X15()
        {
            var _10X15string = "[10x15]\r\n";
            for (var index = 0; index < order.Pictures.Count; index++)
            {
                if (order.Pictures[index].Size == "10x15")
                {
                    _10X15string += index + 1 + "=" + order.Pictures[index].Amount + "\r\n";

                }

            }
            return _10X15string;
        }

        private void GetFileInfo()
        {
            foreach (var picture in order.Pictures)
            {
                var fileinfo = new FileInfo(picture.FilePath);
                fileInfoList.Add(fileinfo);
            }
        }
    }
}