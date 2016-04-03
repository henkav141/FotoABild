using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public class PriceCalculator
    {
        public int Size10X15Amount { get; set; }
        public int Size11X15Amount { get; set; }
        public int Size13X18Amount { get; set; }
        public int Size15X21Amount { get; set; }
        public int Size18X24Amount { get; set; }
        public int Size20X30Amount { get; set; }
        public int Size24X30Amount { get; set; }
        public int Size25X38Amount { get; set; }

        private readonly List<SharedProperties> listProperties;


        public PriceCalculator(List<SharedProperties> listproperties)
        {
            listProperties = listproperties;
        }

        public int CalculateTotalPrice()
        {
            return CalculateSmall() + CalculateMediumSmall() + CalculateMediumLarge() + CalculateLarge();
        }

        public int CalculateSmall()
        {
            var priceSmall = 0;

            var list10X15 = listProperties.Where(item => item.Size.Equals("10x15")).ToList();
            var list11X15 = listProperties.Where(item => item.Size.Equals("11x15")).ToList();
            Size10X15Amount = list10X15.Sum(item => item.Amount);
            Size11X15Amount = list11X15.Sum(item => item.Amount);
            var smallPhotos = Size10X15Amount + Size11X15Amount;

            if (smallPhotos < 20)
                priceSmall = smallPhotos * 10;
            else if (smallPhotos > 19 && smallPhotos < 30)
                priceSmall = smallPhotos * 4;
            else if (smallPhotos > 29 && smallPhotos < 60)
                priceSmall = smallPhotos * 3;
             else if (Size10X15Amount > 59)
                priceSmall = smallPhotos * 2;
            return priceSmall;
        }

        public int CalculateMediumSmall()
        {
            var priceMediumSmall = 0;
            var list13X18 = listProperties.Where(item => item.Size.Equals("13x18(vit kant)"));
            var list15X21 = listProperties.Where(item => item.Size.Equals("15x21"));
            Size13X18Amount = list13X18.Sum(item => item.Amount);
            Size15X21Amount = list15X21.Sum(item => item.Amount);
            var mediumSmallPhotos = Size13X18Amount + Size15X21Amount;


            if (mediumSmallPhotos > 9)
                priceMediumSmall = mediumSmallPhotos * 15;
            else if (Size13X18Amount < 3)
                priceMediumSmall = mediumSmallPhotos * 40;
            else if (mediumSmallPhotos % 3 == 1 && mediumSmallPhotos < 10)
            {
                var numberof3 = ((mediumSmallPhotos - 1) / 3);
                priceMediumSmall = numberof3*90 + 40;
            }
            else if (mediumSmallPhotos % 3 == 2 & mediumSmallPhotos < 10)
            {
                var numberof3 = ((mediumSmallPhotos - 1) / 3);
                priceMediumSmall = numberof3*90 + 80;
            }
            else if (mediumSmallPhotos % 3 == 0 && mediumSmallPhotos < 10)
            {
                var numberof3 = mediumSmallPhotos / 3;
                priceMediumSmall = numberof3 * 90;
            }

            return priceMediumSmall;
        }

        public int CalculateMediumLarge()
        {
            var priceMediumLarge = 0;
            var list18X24 = listProperties.Where(item => item.Size.Equals("18x24(vit kant)"));
            var list20X30 = listProperties.Where(item => item.Size.Equals("20x30"));
            Size18X24Amount = list18X24.Sum(item => item.Amount);
            Size20X30Amount = list20X30.Sum(item => item.Amount);
            var mediumLargePhotos = Size18X24Amount + Size20X30Amount;

            if (mediumLargePhotos > 9)
                priceMediumLarge = mediumLargePhotos * 30;
            else if (mediumLargePhotos < 3)
                priceMediumLarge = mediumLargePhotos * 60;
            else if (mediumLargePhotos % 3 == 1 && mediumLargePhotos < 10)
            {
                var numberof3 = ((mediumLargePhotos - 1) / 3);
                priceMediumLarge = numberof3 * 150 + 60;
            }
            else if (mediumLargePhotos % 3 == 2 & mediumLargePhotos < 10)
            {
                var numberof3 = ((mediumLargePhotos - 1) / 3);
                priceMediumLarge = numberof3 * 150 + 120;
            }
            else if (mediumLargePhotos % 3 == 0 && mediumLargePhotos < 10)
            {
                var numberof3 = mediumLargePhotos / 3;
                priceMediumLarge = numberof3 * 150;
            }
            return priceMediumLarge;

        }
        public int CalculateLarge()
        {
            var priceLarge = 0;
            var list24X30 = listProperties.Where(item => item.Size.Equals("24x30(vit kant)"));
            var list25X38 = listProperties.Where(item => item.Size.Equals("25x38"));
            Size24X30Amount = list24X30.Sum(item => item.Amount);
            Size25X38Amount = list25X38.Sum(item => item.Amount);
            var largePhotos = Size24X30Amount + Size25X38Amount;

            if (largePhotos > 9)
                priceLarge = largePhotos * 40;
            else if (largePhotos < 3)
                priceLarge = largePhotos * 100;
            else if (largePhotos % 3 == 1 && largePhotos < 10)
            {
                var numberof3 = ((largePhotos - 1) / 3);
                priceLarge = numberof3 * 210 + 100;
            }
            else if (largePhotos % 3 == 2 & largePhotos < 10)
            {
                var numberof3 = ((largePhotos - 1) / 3);
                priceLarge = numberof3 * 210 + 80;
            }
            else if (largePhotos % 3 == 0 && largePhotos < 10)
            {
                var numberof3 = largePhotos / 3;
                priceLarge = numberof3 * 210;
            }
            return priceLarge;
        }
        
    }
}
