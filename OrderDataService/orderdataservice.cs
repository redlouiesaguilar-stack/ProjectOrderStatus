using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text.Json;

namespace AGUILAR
{
    public class OrderInfo
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class orderdataservice
    {
        private string connString = "Server=localhost\\SQLEXPRESS;Database=ProjectOrderSystem;Trusted_Connection=True;TrustServerCertificate=True;";
        private string jsonPath = "orders.json";

        public void SaveToSql(string itemName)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Orders (ItemName, Status) VALUES (@name, 'Pending')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", itemName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<OrderInfo> GetAllOrders()
        {
            List<OrderInfo> orders = new List<OrderInfo>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT ItemName, Status FROM Orders";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderInfo { Name = reader["ItemName"].ToString(), Status = reader["Status"].ToString() });
                        }
                    }
                }
            }
            return orders;
        }

        public void DeleteFromSql(string itemName)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM Orders WHERE ItemName = @name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", itemName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveToJson(List<OrderInfo> orders)
        {
            string json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
        }
    }
}