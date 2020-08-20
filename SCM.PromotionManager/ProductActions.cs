using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SCM.PromotionManager
{
    public class ProductActions
    {
        public  List<Product> products = null;
        public  List<PromotionQuantity> promotionQuantity = null; 
        public List<PromotionCombination> promotionCombination = null;

        public List<Product> CreateAllProducts()
        {
           products = new List<Product>();
            products.Add(new Product { SkuId = 'A', Name = "A", Desc = "A Desc", AvailableCount = 100, Price = 50.00, IsQuantityDiscount = true, IsPercentageDiscount = false });
            products.Add(new Product { SkuId = 'B', Name = "B", Desc = "B Desc", AvailableCount = 100, Price = 30.00, IsQuantityDiscount = true, IsPercentageDiscount = false });
            products.Add(new Product { SkuId = 'C', Name = "C", Desc = "C Desc", AvailableCount = 100,Price = 20.00, IsQuantityDiscount = true, IsPercentageDiscount = false });
            products.Add(new Product { SkuId = 'D', Name = "D", Desc = "D Desc",AvailableCount = 100, Price = 15.00, IsQuantityDiscount = true, IsPercentageDiscount = false});
            return products;
        }
        public List<PromotionQuantity> CreateAllQuantityPromotions()
        {
            promotionQuantity = new List<PromotionQuantity>();
            promotionQuantity.Add(new PromotionQuantity { PromotionID=1, SkuId = 'A', OnNoOfProducts = 3,PromotionPrice=130 });
            promotionQuantity.Add(new PromotionQuantity { PromotionID = 2, SkuId = 'B', OnNoOfProducts = 2, PromotionPrice = 45 });
           
            return promotionQuantity;
        }

        public List<PromotionCombination> CreateAllCombinationPromotions()
        {
            promotionCombination = new List<PromotionCombination>();

            promotionCombination.Add(new PromotionCombination { PromotionID = 3, SkuIds = new List<char> { 'C', 'D' }, PromotionPrice = 30 });
            return promotionCombination;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductByID(char skuId)
        {
            return products.Find(m => m.SkuId ==skuId); 

            
        }

        public PromotionQuantity GetPromotionBySkuId(char skuId)
        {
            return promotionQuantity.Find(m => m.SkuId == skuId);
        }

        public PromotionCombination GetPromotionBySkuId(List<char> skuIds)
        {
            PromotionCombination promotion = null;
            bool pExistFlag = true;
            foreach (PromotionCombination p in promotionCombination)
            {
                pExistFlag = true;
                skuIds = skuIds.OrderBy(q => q).ToList();
                if (skuIds.Count >= p.SkuIds.Count)
                {
                    foreach (char sku in p.SkuIds.OrderBy(q => q).ToList())
                    {
                        if(!skuIds.Contains(sku))
                        {
                            pExistFlag = false;
                            break;
                        }
                        
                    }
                    
                       promotion = pExistFlag ? p : null;
                   
                }
            }
            return promotion;
        }
    }
}
