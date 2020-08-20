using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.PromotionManager
{
    public class CombinationProductFactory : DiscountFactory
    {
        protected override IDiscount MakeDiscount() 
        {
            IDiscount discount = new CombinationProduct();
            return discount;
        }
    }
}
