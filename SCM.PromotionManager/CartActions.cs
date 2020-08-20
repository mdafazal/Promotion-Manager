using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.PromotionManager
{
    public class CartActions
    {
        Cart cart = new Cart(); 
        /// <summary>
        /// actual one 
        /// </summary>
        /// <param name="skuId"></param>
        /// <param name="quantity"></param>
        // public AddToCart(Char skuId,int quantity)
        //to test
        public void AddToCart(Char skuId, int quantity)
        {
            cart.CartId = Guid.NewGuid().ToString();
            cart.Items.Add(new Item { SkuId = skuId, Quantity = quantity, Price = 30 });
        }
    }
}
