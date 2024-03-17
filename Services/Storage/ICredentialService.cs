//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Auth;
using System.Collections.Generic;

namespace EShop.Services.Storage
{
    public interface ICredentialService
    {
        List<Credential> GetAllCredentials();
        Credential AddCredential(Credential credential);
    }
}