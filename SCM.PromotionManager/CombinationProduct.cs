using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SCM.PromotionManager
{
    public class CombinationProduct : IDiscount
    {
        public List<Product> products = null; 
        public List<PromotionCombination> cromotionCombination = null;
        public void ApplyDiscount(List<Item> items)
        {
            
            //Start temp code as data is not getting from DB
            ProductActions productActions = new ProductActions();
            productActions.CreateAllProducts();
            productActions.CreateAllCombinationPromotions();
            var allProducts = productActions.GetAllProducts();
            //End temp code as data is not getting from DB

            var allSkus = items.Select(m => m.SkuId).ToList();


            
                var promotion = productActions.GetPromotionBySkuId(allSkus);

            if (promotion != null)
            {
                
                for (int iteration= 0; iteration < promotion.SkuIds.Count; iteration++)               
                {
                    Item item = items.Find(m => m.SkuId == promotion.SkuIds[iteration]);
                    item.Price = 0;
                    if (iteration == promotion.SkuIds.Count - 1)
                        item.Price = promotion.PromotionPrice;

                }
                              
            
            }
            
        }
    }
}
