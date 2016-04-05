using System;
using System.Collections.Generic;
using System.Text;

namespace FotoABIld
{
    public class Order
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pictures> Pictures { get; set; }

        public Order(string name,string surname,string email,string phonenumber, List<Pictures> pictures)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phonenumber;
            Pictures = pictures;

        }

    }
}
