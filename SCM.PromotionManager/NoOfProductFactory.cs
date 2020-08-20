using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.PromotionManager
{
    public class NoOfProductFactory : DiscountFactory
    {
        protected override IDiscount MakeDiscount() 
        {
            IDiscount discount = new NoOfProduct();
            return discount;
        }
    }
}
