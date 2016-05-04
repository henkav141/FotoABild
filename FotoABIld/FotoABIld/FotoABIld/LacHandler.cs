using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FotoABIld
{
    public static class LacHandler
    {
        public static void CreateLacFile(Order order,string filepath)
        {
            var lacText = new List<string> {FillUserDetails(order), FillOrderDetails(order)};

            File.WriteAllLines(filepath, lacText);
        }

        private  static string FillUserDetails(Order order)
        {
            return "[User Details]" + "\r\n" +
                   "FirstName=" + order.Name + "\r\n" +
                   "Email=" + order.Email + "\r\n" +
                   "LastName=" + order.Surname + "\r\n" +
                   "Phone=" + order.PhoneNumber + "\r\n";

        }

        private static string FillOrderDetails(Order order)
        {
            return "[OrderDetails]" + "\r\n" +
                   "OrderReference=" + "" + "\r\n" +
                   "orderid=" + order.OrderId + "\r\n" +
                   "TotalPrice=" + PriceCalculator.CalculateTotalPrice(order.Pictures) + "\r\n" +
                   "OrderDate=" + DateTime.Now.ToString("dd/MM/yy hh:mm") + "\r\n" +
                   "ReturnDate=" + order.Date.ToString("dd/MM/yy hh:mm") + "\r\n";

        }
    }
}
