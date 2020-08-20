using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.PromotionManager
{
    public class NoOfProduct : IDiscount
    {
        public List<Product> products = null;
        public List<PromotionQuantity> promotionQuantity = null; 
       
        public void ApplyDiscount(List<Item> items)
        {
            double price = 0;
            //Start temp code as data is not getting from DB
            ProductActions productActions = new ProductActions();
            productActions.CreateAllProducts();
            productActions.CreateAllQuantityPromotions();
            
            var allProducts = productActions.GetAllProducts();
            //End temp code as data is not getting from DB
            

            foreach (Item item in items)
            {
                var promotion = productActions.GetPromotionBySkuId(item.SkuId);               

                if (promotion != null)
                {
                    if (promotion.OnNoOfProducts == item.Quantity)
                    {
                        price = promotion.PromotionPrice;
                    }
                    else if (promotion.OnNoOfProducts < item.Quantity)
                    {
                        int quantity = item.Quantity / promotion.OnNoOfProducts;
                        price = promotion.PromotionPrice * quantity;
                        quantity = item.Quantity % promotion.OnNoOfProducts;
                        price = price + (quantity * item.Price);
                    }
                    else
                    {
                        price = item.Quantity * item.Price;
                    }
                }
                else
                {
                    price = item.Quantity * item.Price;
                }
                item.Price = price;
            }
           
        }
    }
}
