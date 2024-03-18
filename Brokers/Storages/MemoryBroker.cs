//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Shop;
using System.Collections.Generic;

namespace EShop.Brokers.Storages
{
    public class MemoryBroker : IStorageBroker<Product>
    {
        static List<Product> products = new List<Product> {
            new Product { Name = "Banana",Price = 30000,Weight = 10},
            new Product { Name = "Ananas", Price = 20000, Weight = 30}
        };

        static List<Product> cartProducts = new List<Product>();

        public Product Add(Product product)
        {
            products.Add(product);

            return product;
        }

        public List<Product> GetAllCart()
        {
            return cartProducts;
        }

        public Product AddToCart(Product product)
        {
            cartProducts.Add(product);
            return product;
        }
        public List<Product> GetAll()
        {
            return products;
        }
    }
}