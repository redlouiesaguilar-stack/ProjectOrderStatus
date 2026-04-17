using System.Collections.Generic;

namespace AGUILAR
{
    public class orderappservice
    {
        private readonly orderdataservice _dataService;

        public orderappservice(orderdataservice dataService)
        {
            _dataService = dataService;
        }

        public void CreateOrder(string name)
        {
            var newOrder = new Order { Name = name, Status = "Pending" };
            _dataService.Add(newOrder);
        }

        public List<Order> GetOrders() => _dataService.GetAll();

        public void UpdateOrderStatus(int id, string status) => _dataService.UpdateStatus(id, status);

        public void RemoveOrder(string name) => _dataService.Delete(name);
    }
}