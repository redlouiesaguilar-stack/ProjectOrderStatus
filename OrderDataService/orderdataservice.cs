using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace AGUILAR
{
    
    public interface IOrderDataService
    {
        void SaveToSql(string item);
        List<OrderInfo> GetAllOrders();
        void DeleteFromSql(string item);
        void SaveToJson(List<OrderInfo> orders);
    }

    
    public class OrderSqlDataService : IOrderDataService
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=OrderDeliveryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void SaveToSql(string item)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Orders (OrderId, ItemName, OrderStatus) VALUES (@id, @name, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@name", item);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDATABASE ERROR: " + ex.Message);
            }
        }

        public List<OrderInfo> GetAllOrders()
        {
            List<OrderInfo> orders = new List<OrderInfo>();
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
                            orders.Add(new OrderInfo
                            {
                                OrderId = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Status = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDATABASE ERROR: " + ex.Message);
            }
            return orders;
        }

        public void DeleteFromSql(string item)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Orders WHERE ItemName = @name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", item);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDATABASE ERROR: " + ex.Message);
            }
        }

        public void SaveToJson(List<OrderInfo> orders) { }
    }

    
    public class orderdataservice
    {
        IOrderDataService _dataService;

        public orderdataservice(IOrderDataService orderDataService)
        {
            _dataService = orderDataService;
        }

        public void SaveToSql(string item)
        {
            _dataService.SaveToSql(item);
        }

        public List<OrderInfo> GetAllOrders()
        {
            return _dataService.GetAllOrders();
        }

        public void DeleteFromSql(string item)
        {
            _dataService.DeleteFromSql(item);
        }

        public void SaveToJson(List<OrderInfo> orders)
        {
            _dataService.SaveToJson(orders);
        }
    }
}