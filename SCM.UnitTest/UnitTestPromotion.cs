using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCM.Model;
using SCM.PromotionManager;
using System.Linq;

namespace SCM.UnitTest
{
    [TestClass]
    public class UnitTestPromotion
    {
        [TestMethod]
        public void TestCaseScenarioA()
        {
            double TotalPrice = 0.0;
            List<Item> items = new List<Item>();
            items.Add(new Item { SkuId = 'A', Quantity = 1, Price = 50 });
            items.Add(new Item { SkuId = 'B', Quantity = 1, Price = 30 });
            items.Add(new Item { SkuId = 'C', Quantity = 1, Price = 20 });

            IDiscount discount = new NoOfProductFactory().CreateDiscount();
            discount.ApplyDiscount(items);
            TotalPrice = items.Sum(m => m.Price);           

            Assert.AreEqual(50, items[0].Price);
            Assert.AreEqual(30, items[1].Price);
            Assert.AreEqual(20, items[2].Price);
            Assert.AreEqual(100, TotalPrice); 
        }
        [TestMethod]
        public void TestCaseScenarioB()
        {
            double TotalPrice = 0.0;
            List<Item> items = new List<Item>();
            items.Add(new Item { SkuId = 'A', Quantity = 5, Price = 50 });
            items.Add(new Item { SkuId = 'B', Quantity = 5, Price = 30 });
            items.Add(new Item { SkuId = 'C', Quantity = 1, Price = 20 });

            IDiscount discount = new NoOfProductFactory().CreateDiscount();
            discount.ApplyDiscount(items);
            TotalPrice = items.Sum(m => m.Price);          

            Assert.AreEqual((130+2*50), items[0].Price);
            Assert.AreEqual((45+45+30), items[1].Price);
            Assert.AreEqual(20, items[2].Price);
            Assert.AreEqual(370, TotalPrice);
        }

        [TestMethod]
        public void TestCaseScenarioC()
        {
            double TotalPrice = 0.0;
            List<Item> items = new List<Item>();
            items.Add(new Item { SkuId = 'A', Quantity = 3, Price = 50 });
            items.Add(new Item { SkuId = 'B', Quantity = 5, Price = 30 });
            items.Add(new Item { SkuId = 'C', Quantity = 1, Price = 20 });
            items.Add(new Item { SkuId = 'D', Quantity = 1, Price = 15 });

            IDiscount discount = new NoOfProductFactory().CreateDiscount();
            discount.ApplyDiscount(items);
            discount = new CombinationProductFactory().CreateDiscount();
            discount.ApplyDiscount(items);
            TotalPrice = items.Sum(m => m.Price);           

            Assert.AreEqual(130, items[0].Price);
            Assert.AreEqual((45 + 45 + 30), items[1].Price);
            Assert.AreEqual(0, items[2].Price);
            Assert.AreEqual(30, items[3].Price);
            Assert.AreEqual(280, TotalPrice);
        }
    }
}
