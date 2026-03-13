using System;

namespace AGUILAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            orderappservice appService = new orderappservice();

            Console.WriteLine("ACCOUNT MANAGEMENT SYSTEM");

            string username = "redlouies";
            string password = "123456";

            Console.Write("Enter username: ");
            string usernameInput = Console.ReadLine();

            Console.Write("Enter password: ");
            string passwordInput = Console.ReadLine();

            if (usernameInput == username && passwordInput == password)
            {
                Console.WriteLine("Login successful.");

                bool running = true;
                //this isasdsad
                while (running)
                {
                    Console.WriteLine("\n--- Order System ---");
                    Console.WriteLine("1. Create Order");
                    Console.WriteLine("2. View Orders");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter item name: ");
                            string item = Console.ReadLine();

                            appService.CreateOrder(item);
                            Console.WriteLine("Order created!");
                            break;

                        case "2":
                            var orders = appService.GetOrders();

                            if (orders.Count == 0)
                            {
                                Console.WriteLine("No orders yet.");
                            }
                            else
                            {
                                Console.WriteLine("\n--- Orders ---");

                                foreach (var order in orders)
                                {
                                    Console.WriteLine($"ID: {order.Id}, Item: {order.Item}, Ordered: {order.DateOrdered}, Status: {order.Status}");
                                }
                            }
                            break;

                        case "3":
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
                Console.WriteLine("Invalid login.");
            }
        }
    }
}