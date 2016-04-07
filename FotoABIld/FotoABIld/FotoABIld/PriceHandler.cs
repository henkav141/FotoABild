using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public static class PriceHandler
    {


        public static int GetPriceOfSize(string switchString,List<Pictures> pictureList)
        {
            var amountHandler = new AmountHandler(pictureList);
            var price = 0;
            switch (switchString)
            {
                case "10x15":
                case "11x15":
                    price = PriceCalculator.CalculatePrice(switchString,amountHandler.GetAmountofSize(switchString));
                    break;
                case "15x21":
                case "13x18(vit kant)":
                    price = PriceCalculator.CalculatePrice(switchString, amountHandler.GetAmountofSize(switchString));
                    break;
                case "18x24(vit kant)":
                case "20x30":
                    price = PriceCalculator.CalculatePrice(switchString, amountHandler.GetAmountofSize(switchString));
                    break;
                case "24x30(vit kant)":
                case "25x38":
                    price = PriceCalculator.CalculatePrice(switchString, amountHandler.GetAmountofSize(switchString));
                    break;
            }
            return price;
        }
    }
}
