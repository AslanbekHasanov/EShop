//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System;

namespace EShop.Services.Order
{
    public interface IShipping
    {
        double GetCost(OrderService order);
        DateTimeOffset GetDate();
    }
}