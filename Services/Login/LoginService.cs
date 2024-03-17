//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Brokers.Loggings;
using EShop.Brokers.Storages;
using EShop.Models.Auth;
using System;

namespace EShop.Services.Login  
{
    public class LoginService : ILoginService
    {
        private readonly IStorageBroker<Credential> storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public LoginService()
        {
            this.loggingBroker = new LoggingBroker(); 
            this.storageBroker = new FileStorageBroker();
        }

        public bool CheckUserLogin(Credential credential)
        {
            try
            {
                return credential is null
                    ? CheckUserLoginAndLogInvalidCredential()
                    : ValidateAndCheckUserLogin(credential);
            }
            catch (Exception exception) 
            {
                this.loggingBroker.LogError(exception);
                return false;
            }
        }

        private bool ValidateAndCheckUserLogin(Credential credential)
        {
            if (String.IsNullOrWhiteSpace(credential.Username)
                || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("Credential details are missing.");
                return false;
            }
            else
            {
                foreach (Credential credentialItem in storageBroker.GetAll())
                {
                    if (credential.Username == credentialItem.Username 
                        && credential.Password == credentialItem.Password)
                    {
                        this.loggingBroker.LogInformation("successful.");
                        return true;
                    }
                }
                this.loggingBroker.LogError("Not Found");
                return false;
            }
        }

        private bool CheckUserLoginAndLogInvalidCredential()
        {
            this.loggingBroker.LogError("Credentials is invalid.");
            return false;
        }
    }
}