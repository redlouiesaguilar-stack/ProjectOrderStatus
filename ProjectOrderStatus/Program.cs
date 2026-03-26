using System;
using System.Collections.Generic;

namespace AGUILAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            orderappservice appService = new orderappservice();

            Console.WriteLine("   ORDER & DELIVERY TRACKING SYSTEM  ");
            

            string username = "redlouies";
            string password = "123456";

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
                            try
                            {
                                appService.CreateOrder(item);
                                Console.WriteLine("SUCCESS: Order placed!");
                            }
                            catch (Exception ex) { Console.WriteLine($"ERROR: {ex.Message}"); }
                            break;

                        case "2":
                            try
                            {
                                var orders = appService.GetOrders();
                                if (orders.Count == 0) { Console.WriteLine("\nNo orders found."); }
                                else
                                {
                                    Console.WriteLine("\n-------------------------------------------");
                                    Console.WriteLine("{0,-20} | {1,-15}", "ITEM NAME", "STATUS");
                                    Console.WriteLine("-------------------------------------------");
                                    foreach (var o in orders) { Console.WriteLine("{0,-20} | {1,-15}", o.Name, o.Status); }
                                    Console.WriteLine("-------------------------------------------");
                                }
                            }
                            catch (Exception ex) { Console.WriteLine($"ERROR: {ex.Message}"); }
                            break;

                        case "3":
                            Console.Write("\nEnter item name to remove: ");
                            string toDelete = Console.ReadLine();
                            try
                            {
                                appService.RemoveOrder(toDelete);
                                Console.WriteLine("SUCCESS: Order deleted and JSON synced.");
                            }
                            catch (Exception ex) { Console.WriteLine($"ERROR: {ex.Message}"); }
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