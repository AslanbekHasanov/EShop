//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Auth;
using System.Collections.Generic;
using System.IO;

namespace EShop.Brokers.Storages
{
    public class FileStorageBroker : IStorageBroker<Credential>
    {
        private const string FilePath = "../../../Assets/Credentials.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }

        public List<Credential> GetAll()
        {
            List<Credential> credentials = new List<Credential>(); 
            string[] credentialLines = File.ReadAllLines(FilePath);
            
            foreach (string credentialLine in credentialLines)
            {
                string[] credentialProperties = credentialLine.Split('*');

                credentials.Add(new Credential()
                    {UserName = credentialProperties[0], 
                     Password = credentialProperties[1]});
            }

            return credentials;
        } 
        
        public Credential Add(Credential credential)
        {
            string credentialLine = $"{credential.UserName}*{credential.Password}\n";
            File.AppendAllText(FilePath,credentialLine);

            return credential;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
            }
        }
    }
}