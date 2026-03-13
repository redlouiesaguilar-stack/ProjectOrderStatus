using System;
using System.Collections.Generic;

namespace AGUILAR
{
    public class orderappservice
    {
        orderdataservice dataService = new orderdataservice();

        public void CreateOrder(string item)
        {
            ordermodel order = new ordermodel
            {
                Item = item,
                DateOrdered = DateTime.Now
            };

            dataService.AddOrder(order);
        }

        public List<ordermodel> GetOrders()
        {
            return dataService.GetOrders();
        }
    }
}