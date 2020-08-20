using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.PromotionManager
{
    public abstract class DiscountFactory
    {
        protected abstract IDiscount MakeDiscount();

        public IDiscount CreateDiscount() 
        {
            return this.MakeDiscount();
        }
    }
}
