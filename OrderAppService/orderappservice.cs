using System.Collections.Generic;

namespace AGUILAR
{
    public class orderappservice
    {
        private readonly IOrderDataService _dataService;

        public orderappservice(IOrderDataService dataService)
        {
            _dataService = dataService;
        }

        public void CreateOrder(string name) => _dataService.AddOrder(name);
        public List<Order> GetOrders() => _dataService.GetAllOrders();
        public void RemoveOrder(string name) => _dataService.DeleteOrder(name);
    }
}