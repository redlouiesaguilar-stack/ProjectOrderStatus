using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace AGUILAR
{
    public class orderdataservice : IOrderDataService
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=OrderDeliveryDB;Integrated Security=True;TrustServerCertificate=True;";

        public void AddOrder(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Orders (ItemName, OrderStatus) VALUES (@name, 'Pending')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATABASE ERROR: " + ex.Message);
            }
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT OrderId, ItemName, OrderStatus FROM Orders";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                Name = reader["ItemName"].ToString(),
                                Status = reader["OrderStatus"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATABASE ERROR: " + ex.Message);
            }
            return orders;
        }

        public void DeleteOrder(string name)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Orders WHERE ItemName = @name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATABASE ERROR: " + ex.Message);
            }
        }
    }
}