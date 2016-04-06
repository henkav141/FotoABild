﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FotoABIld
{
    public class PriceHandler
    {
        private List<Pictures> PictureList;
        private AmountHandler amountHandler;
        private PriceCalculator priceCalculator;
        public PriceHandler(List<Pictures> pictureList )
        {
            PictureList = pictureList;
            amountHandler = new AmountHandler(PictureList);
            priceCalculator = new PriceCalculator(PictureList);
        }

        public int GetPriceOfSize(string switchString)
        {
            var price = 0;
            switch (switchString)
            {
                case "10x15":
                case "11x15":
                    price = priceCalculator.CalculateSmall(amountHandler.GetAmountofSize(switchString));
                    break;
                case "15x21":
                case "13x18(vit kant)":
                    break;
                case "18x24(vit kant)":
                case "20x30":
                    break;
                case "24x30(vit kant)":
                case "25x38":
                    break;
            }
            return price;
        }
    }
}
