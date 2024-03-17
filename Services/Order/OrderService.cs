//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Services.Order
{
    public class OrderService
    {        
        private IList<Product> lineItems;
        private IShipping shipping;

        public OrderService(IList<Product> products) =>
            lineItems = products;

        public int GetTotal() => lineItems.Count;
        public double GetTotalWeight() => lineItems.Sum(x => x.Weight);
        
        public void SetShippingType(IShipping shippingType) => 
            shipping = shippingType;

        public double GetShippingCost()=> shipping.GetCost(this);
        public DateTimeOffset GetShippingDate() => DateTimeOffset.Now;
    }
}