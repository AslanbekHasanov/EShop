//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Brokers.Loggings;
using EShop.Brokers.Storages;
using EShop.Models.Shop;
using System;
using System.Collections.Generic;

namespace EShop.Services.Storage
{
    public class ProductService : IProductService
    {
        private readonly MemoryBroker memoryStorageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ProductService()
        {
            memoryStorageBroker = new MemoryBroker();
            loggingBroker = new LoggingBroker();
        }
        public List<Product> GetProducts()
        {
            try
            {
                if (this.memoryStorageBroker.GetAll().Count is 0)
                {
                    this.loggingBroker.LogError("No data found.");
                    return new List<Product>();
                }
                else
                {
                    this.loggingBroker.LogInformation("=== All Products Data ===");

                    foreach (var product in this.memoryStorageBroker.GetAll())
                    {
                        Console.WriteLine($"{product.Name} {product.Weight}");
                    }
                }

                return memoryStorageBroker.GetAll();
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError(exception);
                return new List<Product>();
            }
        }

        public Product Add(Product product)
        {
            try
            {
                return product is null
                    ? AddAndLogInvalidProduct()
                    : ValidateAndAddProduct(product);
            }
            catch (Exception exceprion)
            {
                this.loggingBroker.LogError(exceprion);
                return new Product();
            }
        }

        public List<Product> GetAllCart()
        {
            return memoryStorageBroker.GetAllCart();
        }

        public void AddToCart(Product product)
        {
            memoryStorageBroker.AddToCart(product);
        }

        private Product ValidateAndAddProduct(Product product)
        {
            if (String.IsNullOrWhiteSpace(product.Name)
                || product.Price is 0
                || product.Weight is 0)
            {
                this.loggingBroker.LogError("Product details missing.");
                return new Product();
            }
            else
            {
                this.loggingBroker.LogInformation("Added successfully.");
                return this.memoryStorageBroker.Add(product);
            }
        }

        private Product AddAndLogInvalidProduct()
        {
            this.loggingBroker.LogError("Product is invalid.");
            return new Product();
        }
    }
}