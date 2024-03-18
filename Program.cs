//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using EShop.Models.Auth;
using EShop.Models.Shop;
using EShop.Services.Login;
using EShop.Services.Order;
using EShop.Services.Storage;
using System;
using System.Collections.Generic;

namespace EShop
{
    public class Program
    {

        static IList<IShipping> shippings = new List<IShipping> { new Sea(), new Air(), new Ground() };
        static ILoginService loginService = new LoginService();
        static ICredentialService credentialService = new CredentialService();
        static IProductService productService = new ProductService();  

        public static void Main(string[] args)
        {
            bool isContinue = false;
            bool isLogIn = true;


            do
            {
                Console.WriteLine("Welcome to, my project");
                Console.WriteLine("1.Auth");
                Console.WriteLine("2.Show products");
                Console.WriteLine("3.Show shipping method");
                Console.WriteLine("4.Show shipping method");
                Console.Write("Enter your command: ");
                string commandMenu = Console.ReadLine();

                if (commandMenu.Contains("1"))
                {
                    do
                    {
                        Credential credential = new Credential();
                        Console.WriteLine("=== Auth ===");
                        Console.WriteLine("1 Log In");
                        Console.WriteLine("2 Sign Up");

                        Console.Write("Enter your command: ");
                        string commandLogInAndSignUp = Console.ReadLine();

                        Console.Write("Enter your user name: ");
                        credential.UserName = Console.ReadLine();
                        Console.Write("Enter your user password: ");
                        credential.Password = Console.ReadLine();

                        if (commandLogInAndSignUp.Contains("1") is true)
                        {
                            if (loginService.CheckUserLogin(credential) is true)
                            {
                                isLogIn = false;
                            }
                        }
                        else if (commandLogInAndSignUp.Contains("2") is true)
                        {
                            credentialService.AddCredential(credential);
                        }
                    } while (isLogIn is true);
                }

                if (commandMenu.Contains("2"))
                {
                    Console.Clear();
                    Console.WriteLine("=== Show products ===");
                    Console.WriteLine("1.Products");
                    Console.WriteLine("2.Add to cart");

                    Console.Write("Enter your command:(1 or 2) ");
                    string commandProduct = Console.ReadLine();

                    if (commandProduct.Contains("1") is true)
                    {
                        productService.GetProducts();
                    }
                    else if(commandProduct.Contains("2") is true)
                    {
                        Product product = new Product();
                        Console.Write("Enter product name: ");
                        product.Name = Console.ReadLine();
                        Console.Write("Enter product price: ");
                        product.Price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter products weight: ");
                        product.Weight = Convert.ToDouble(Console.ReadLine());
                        
                        productService.AddToCart(product);
                    }
                }

                //Show shipping method not implement in Program class
                //Show total price not imlement in Program class

                Console.Write("Is continue(no or yes): ");
                string isContinueCommand = Console.ReadLine();

                if (isContinueCommand.ToLower().Contains("no"))
                {
                    isContinue = false;
                }
            } while (isContinue is true);
        }
    }
}