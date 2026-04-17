using System;
using System.Collections.Generic;

namespace AGUILAR
{
    internal class Program
    {
        static orderdataservice dataService = new orderdataservice();
        static orderappservice appService = new orderappservice(dataService);

        static string username = "redlouies";
        static string password = "123456";

        static void Main(string[] args)
        {
            Console.WriteLine(" ORDER AND DELIVERY TRACKING SYSTEM ");
            bool isLogin = ShowLoginOption();
            while (isLogin)
            {
                Login();
                isLogin = ShowLoginOption();
            }
        }

        static bool ShowLoginOption()
        {
            Console.Write("\nDo you want to login? y/n: ");
            string input = Console.ReadLine().ToLower();
            return input == "y";
        }

        static void Login()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter username: ");
                string u = Console.ReadLine();
                Console.Write("Enter password: ");
                string p = Console.ReadLine();

                if (u == username && p == password)
                {
                    Console.WriteLine("\nLogin Successful!");
                    MainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Credentials.");
                }
            }
        }

        static void MainMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n----------\n MAIN MENU:");
                string[] options = { "Place New Order", "Check Delivery Status", "Update Order Status", "Delete Order", "Exit" };
                for (int x = 0; x < options.Length; x++) Console.WriteLine($"[{x + 1}] {options[x]}");
                Console.Write("Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Item Name: ");
                        appService.CreateOrder(Console.ReadLine());
                        Console.WriteLine("Order Saved to Database!");
                        break;
                    case "2":
                        var orders = appService.GetOrders();
                        if (orders.Count == 0) Console.WriteLine("No orders found in SQL.");
                        else foreach (var o in orders) Console.WriteLine($"{o.OrderId} | {o.Name} | {o.Status}");
                        break;
                    case "3":
                        Console.Write("Enter Order ID to update: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Status: ");
                        string newStatus = Console.ReadLine();
                        appService.UpdateOrderStatus(id, newStatus);
                        Console.WriteLine("Status Updated!");
                        break;
                    case "4":
                        Console.Write("Enter Item Name to remove: ");
                        appService.RemoveOrder(Console.ReadLine());
                        Console.WriteLine("Order Deleted from Database!");
                        break;
                    case "5":
                        running = false;
                        break;
                }
            }
        }
    }
}