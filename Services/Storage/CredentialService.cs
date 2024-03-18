//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Brokers.Loggings;
using EShop.Brokers.Storages;
using EShop.Models.Auth;
using EShop.Services.Login;
using System;
using System.Collections.Generic;

namespace EShop.Services.Storage
{
    public class CredentialService : ICredentialService
    {
        private readonly IStorageBroker<Credential> storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly ILoginService loginService;

        public CredentialService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
            this.loginService = new LoginService();
        }

        public Credential AddCredential(Credential credential)
        {
            try
            {
                return credential is null
                    ? CreateAndLogInvalidCredential()
                    : ValidateAndAddCredential(credential);
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError(exception);
                return new Credential();
            }
        }

        public List<Credential> GetAllCredentials()
        {
            try
            {
                if (this.storageBroker.GetAll().Count == 0)
                {
                    this.loggingBroker.LogError("No data found.");
                    return new List<Credential>();
                }
                else
                {
                    this.loggingBroker.LogInformation("=== All data ===");
                    foreach (var credentialItem in this.storageBroker.GetAll())
                    {
                        Console.WriteLine($"{credentialItem.UserName} {credentialItem.Password}");
                    }
                    return this.storageBroker.GetAll();
                }
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError(exception);
                return new List<Credential>();
            }
        }

        private Credential CreateAndLogInvalidCredential()
        {
            this.loggingBroker.LogError("Contact is invalid");

            return new Credential();
        }

        private Credential ValidateAndAddCredential(Credential credential)
        {
            if ( String.IsNullOrWhiteSpace(credential.UserName)
                || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("Credential details missing.");
                return new Credential();
            }
            else
            {
                if (this.CheckUserLogin(credential) is false)
                {
                    this.loggingBroker.LogInformation("Added successfully.");
                    return this.storageBroker.Add(credential);
                }
                else
                { 
                    this.loggingBroker.LogError("There is a credential thread");
                    return new Credential();
                }
            }
        }

        private bool CheckUserLogin(Credential credential)
        {
            foreach (var credentialItem in this.storageBroker.GetAll())
            {
                if (credentialItem.UserName.Contains(credential.UserName)
                    && credentialItem.Password.Contains(credential.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}