using System;
using System.Collections.Generic;

namespace AGUILAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            orderappservice appService = new orderappservice();
            string username = "redlouies";
            string password = "123456";

            Console.WriteLine(" ORDER & DELIVERY TRACKING SYSTEM ");

            Console.Write("Enter username: ");
            string usernameInput = Console.ReadLine();

            Console.Write("Enter password: ");
            string passwordInput = Console.ReadLine();

            if (usernameInput == username && passwordInput == password)
            {
                Console.WriteLine("\nLogin successful!");

                bool running = true;
                while (running)
                {
                    Console.WriteLine("\n--- Main Menu ---");
                    Console.WriteLine("1. Place New Order");
                    Console.WriteLine("2. Check Delivery Status");
                    Console.WriteLine("3. Delete Order");
                    Console.WriteLine("4. Exit ");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("\nEnter item name: ");
                            string item = Console.ReadLine();
                            appService.CreateOrder(item);
                            Console.WriteLine("Success! Order Placed!");
                            break;

                        case "2":
                            var orders = appService.GetOrders();
                            if (orders.Count == 0) Console.WriteLine("\nNo orders found.");
                            else
                            {
                                Console.WriteLine("\nORDERS:");
                                foreach (var o in orders)
                                {
                                    Console.WriteLine($"{o.Name} - {o.Status}");
                                }
                            }
                            break;

                        case "3":
                            Console.Write("\nEnter item name to remove: ");
                            string toDelete = Console.ReadLine();
                            appService.RemoveOrder(toDelete);
                            Console.WriteLine("Success! Order Deleted!");
                            break;

                        case "4":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nLogin failed.");
                Console.ReadKey();
            }
        }
    }
}