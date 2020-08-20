using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Model
{
    public class Product
    {
        public char SkuId { get; set; } 
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AvailableCount { get; set; }
        public double Price { get; set; }
        public bool IsPercentageDiscount { get; set; }
        public bool IsQuantityDiscount { get; set; }

        
    }
    public class PromotionQuantity
    {
        public int PromotionID { get; set; }
        public char SkuId { get; set; }
        public int OnNoOfProducts { get; set; }
        public double PromotionPrice { get; set; }
    }

    public class PromotionCombination
    {
        public int PromotionID { get; set; }
        public List<char> SkuIds { get; set; }        
        public double PromotionPrice { get; set; }
    }
}
