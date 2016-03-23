using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public class PriceCalculator
    {
        private int Size1Amount;
        private int Size2Amount;
        private int Size3Amount;
        private int Size4Amount;
        private readonly List<SharedProperties> listProperties;


        public PriceCalculator(List<SharedProperties> listproperties)
        {
            listProperties = listproperties;
        }

        public int CalculateTotalPrice()
        {
            return Calculate1() + Calculate2() + Calculate3() + Calculate4();
        }

        public int Calculate1()
        {
            var price1 = 0;

            var list1 = listProperties.Where(item => item.Size.Equals("10x15") || item.Size.Equals("11x15")).ToList();
             Size1Amount = list1.Sum(item => item.Amount);

             if (Size1Amount < 20)
                 price1 = Size1Amount * 10;
             else if (Size1Amount > 19 && Size1Amount < 30)
                 price1 = Size1Amount * 4;
             else if (Size1Amount > 29 && Size1Amount < 60)
                 price1 = Size1Amount * 3;
             else if (Size1Amount > 59)
                 price1 = Size1Amount * 2;



            
            return price1;
        }

        public int Calculate2()
        {
            var price2 = 0;
            var list2 = listProperties.Where(item => item.Size.Equals("13x18(vit kant)") || item.Size.Equals("15x21"));
            Size2Amount = list2.Sum(item => item.Amount);
            if (Size2Amount > 9)
                price2 = Size2Amount * 15;
            else if (Size2Amount < 3)
                price2 = Size2Amount * 40;
            else if (Size2Amount % 3 == 1 && Size2Amount < 10)
            {
                var numberof3 = ((Size2Amount - 1) / 3);
                price2 = numberof3*90 + 40;
            }
            else if (Size2Amount % 3 == 2 & Size2Amount < 10)
            {
                var numberof3 = ((Size2Amount - 1) / 3);
                price2 = numberof3*90 + 80;
            }
            else if (Size2Amount % 3 == 0 && Size2Amount < 10)
            {
                var numberof3 = Size2Amount / 3;
                price2 = numberof3 * 90;
            }

            return price2;
        }

        public int Calculate3()
        {
            var price3 = 0;
            var list3 = listProperties.Where(item => item.Size.Equals("18x24(vit kant)") || item.Size.Equals("20x30"));
            Size3Amount = list3.Sum(item => item.Amount);
            if (Size3Amount > 9)
                price3 = Size3Amount * 30;
            else if (Size3Amount < 3)
                price3 = Size3Amount * 60;
            else if (Size3Amount % 3 == 1 && Size3Amount < 10)
            {
                var numberof3 = ((Size3Amount - 1) / 3);
                price3 = numberof3 * 150 + 60;
            }
            else if (Size3Amount % 3 == 2 & Size3Amount < 10)
            {
                var numberof3 = ((Size3Amount - 1) / 3);
                price3 = numberof3 * 150 + 120;
            }
            else if (Size3Amount % 3 == 0 && Size3Amount < 10)
            {
                var numberof3 = Size3Amount / 3;
                price3 = numberof3 * 150;
            }
            return price3;

        }
        public int Calculate4()
        {
            var price4 = 0;
            var list4 = listProperties.Where(item => item.Size.Equals("24x30(vit kant)") || item.Size.Equals("25x38"));
            Size4Amount = list4.Sum(item => item.Amount);
            if (Size4Amount > 9)
                price4 = Size4Amount * 40;
            else if (Size4Amount < 3)
                price4 = Size4Amount * 100;
            else if (Size4Amount % 3 == 1 && Size4Amount < 10)
            {
                var numberof3 = ((Size4Amount - 1) / 3);
                price4 = numberof3 * 210 + 100;
            }
            else if (Size4Amount % 3 == 2 & Size4Amount < 10)
            {
                var numberof3 = ((Size4Amount - 1) / 3);
                price4 = numberof3 * 210 + 80;
            }
            else if (Size4Amount%3 == 0 && Size4Amount < 10)
            {
                var numberof3 = Size4Amount / 3;
                price4 = numberof3 * 210;
            }
            return price4;
        }
        
    }
}
