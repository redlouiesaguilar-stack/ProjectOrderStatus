using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace AGUILAR
{
    public class orderdataservice
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS; Database=OrderSystem; Integrated Security=True; TrustServerCertificate=True;";

        public void Add(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Orders (ItemName, OrderStatus) VALUES (@name, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", order.Name);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATABASE ERROR: " + ex.Message);
            }
        }

        public List<Order> GetAll()
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

        public void UpdateStatus(int id, string newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Orders SET OrderStatus = @status WHERE OrderId = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DATABASE ERROR: " + ex.Message);
            }
        }

        public void Delete(string name)
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