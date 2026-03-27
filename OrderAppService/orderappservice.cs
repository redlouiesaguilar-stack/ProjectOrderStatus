using System.Collections.Generic;

namespace AGUILAR
{
    public class orderappservice
    {
        private IOrderDataService _dataService;

        public orderappservice(IOrderDataService orderDataService)
        {
            _dataService = orderDataService;
        }

        public void CreateOrder(string item)
        {
            _dataService.SaveToSql(item);
        }

        public List<OrderInfo> GetOrders()
        {
            return _dataService.GetAllOrders();
        }

        public void RemoveOrder(string item)
        {
            _dataService.DeleteFromSql(item);
        }

        private void SyncJsonFile()
        {
            var allData = _dataService.GetAllOrders();
            _dataService.SaveToJson(allData);
        }
    }
}