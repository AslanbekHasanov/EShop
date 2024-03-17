//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Auth;
using System.Collections.Generic;

namespace EShop.Brokers.Storages
{
    public interface IStorageBroker<T>
    {
        List<T> GetAll();
        T Add(T credential);
    }
}