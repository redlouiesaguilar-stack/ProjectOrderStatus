using System.Collections.Generic;

namespace AGUILAR
{
    public class orderdataservice
    {
        private static List<ordermodel> orders = new List<ordermodel>();
        private static int nextId = 1;

        public void AddOrder(ordermodel order)
        {
            order.Id = nextId++;
            orders.Add(order);
        }

        public List<ordermodel> GetOrders()
        {
            return orders;
        }
    }
}