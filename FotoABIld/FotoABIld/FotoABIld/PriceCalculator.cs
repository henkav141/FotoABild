using System.Collections.Generic;
using System.Linq;

namespace FotoABIld
{
    public static class PriceCalculator
    {

        public static int CalculateTotalPrice(List<Pictures> pictureList)
        {
            var amountHandler = new AmountHandler(pictureList);

            var smallPhotos = amountHandler.GetAmountofSize("10x15") + amountHandler.GetAmountofSize("11x15");
            var mediumSmallPhotos = amountHandler.GetAmountofSize("13x18(vit kant)") +
                                    amountHandler.GetAmountofSize("15x21");
            var mediumLargePhotos = amountHandler.GetAmountofSize("18x24") + amountHandler.GetAmountofSize("20x30");

            var largePhotos = amountHandler.GetAmountofSize("24x30(vit kant)") + amountHandler.GetAmountofSize("25x38");
            return CalculateSmall(smallPhotos) + CalculateMediumSmall(mediumSmallPhotos) +
                CalculateMediumLarge(mediumLargePhotos) + CalculateLarge(largePhotos);
        }

        public static int CalculatePrice(string size, int photos)
        {
            var price = 0;
            if (size.Equals("10x15") || size.Equals("11x15"))
            {
                price = CalculateSmall(photos);
            }
            else if (size.Equals("13x18(vit kant)") || size.Equals("15x21"))
            {
                price = CalculateMediumSmall(photos);
            }
            else if (size.Equals("18x24(vit kant)") || size.Equals("20x30"))
            {
                price = CalculateMediumLarge(photos);
            }
            else if (size.Equals("24x30(vit kant)") || size.Equals("25x38"))
            {
                price = CalculateLarge(photos);
            }

            return price;
        }
        private static int CalculateSmall(int smallPhotos)
        {
            var priceSmall = 0;

            //var list10X15 = listProperties.Where(item => item.Size.Equals("10x15")).ToList();
            //var list11X15 = listProperties.Where(item => item.Size.Equals("11x15")).ToList();
            //Size10X15Amount = list10X15.Sum(item => item.Amount);
            //Size11X15Amount = list11X15.Sum(item => item.Amount);
            //var smallPhotos = Size10X15Amount + Size11X15Amount;

            if (smallPhotos < 20)
                priceSmall = smallPhotos * 10;
            else if (smallPhotos > 19 && smallPhotos < 30)
                priceSmall = smallPhotos * 4;
            else if (smallPhotos > 29 && smallPhotos < 60)
                priceSmall = smallPhotos * 3;
             else if (smallPhotos > 59)
                priceSmall = smallPhotos * 2;
            return priceSmall;
        }

        private static int CalculateMediumSmall(int mediumSmallPhotos)
        {
            var priceMediumSmall = 0;
            //var list13X18 = listProperties.Where(item => item.Size.Equals("13x18(vit kant)"));
            //var list15X21 = listProperties.Where(item => item.Size.Equals("15x21"));
            //Size13X18Amount = list13X18.Sum(item => item.Amount);
            //Size15X21Amount = list15X21.Sum(item => item.Amount);
            //var mediumSmallPhotos = Size13X18Amount + Size15X21Amount;


            if (mediumSmallPhotos > 9)
                priceMediumSmall = mediumSmallPhotos * 15;
            else if (mediumSmallPhotos < 3)
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

        private static int CalculateMediumLarge(int mediumLargePhotos)
        {
            var priceMediumLarge = 0;
            //var list18X24 = listProperties.Where(item => item.Size.Equals("18x24(vit kant)"));
            //var list20X30 = listProperties.Where(item => item.Size.Equals("20x30"));
            //Size18X24Amount = list18X24.Sum(item => item.Amount);
            //Size20X30Amount = list20X30.Sum(item => item.Amount);
            //var mediumLargePhotos = Size18X24Amount + Size20X30Amount;

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
        private static int CalculateLarge(int largePhotos)
        {
            var priceLarge = 0;
            //var list24X30 = listProperties.Where(item => item.Size.Equals("24x30(vit kant)"));
            //var list25X38 = listProperties.Where(item => item.Size.Equals("25x38"));
            //Size24X30Amount = list24X30.Sum(item => item.Amount);
            //Size25X38Amount = list25X38.Sum(item => item.Amount);
            //var largePhotos = Size24X30Amount + Size25X38Amount;

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
