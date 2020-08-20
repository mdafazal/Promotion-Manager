using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.PromotionManager
{
    public interface IDiscount
    {
        void ApplyDiscount(List<Item> skuid); 
    }
}
