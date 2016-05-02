using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FotoABIld
{
    //A model over the properties saved in an order
    public class Order
    {
        [XmlAttribute]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public List<Pictures> Pictures { get; set; }
        public string OrderId { get; set; }

        public Order(string name,string surname,string email,string phonenumber, List<Pictures> pictures)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phonenumber;
            Pictures = pictures;
            Date = DateTime.Now;
            OrderId = "TestOrderId";

        }

        public Order()
        {
            
        }


    }
}
