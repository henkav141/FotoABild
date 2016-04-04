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
        public string TelephoneNumber { get; set; }
        public List<Pictures> Pictures { get; set; }
    }
}
