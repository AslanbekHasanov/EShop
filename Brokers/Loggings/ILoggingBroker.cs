//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System;

namespace EShop.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(Exception exception);
        void LogError(string message);
    }
}