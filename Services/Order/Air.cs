//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System;

namespace EShop.Services.Order
{
    public class Air : IShipping
    {
        public double GetCost(OrderService order)
        {
            if (order.GetTotal() < 100)
            {
                return 0;
            }

            return Math.Max(20, order.GetTotalWeight()*3);
        }

        public DateTimeOffset GetDate()=>
                DateTime.Now.AddDays(7);
    }
}