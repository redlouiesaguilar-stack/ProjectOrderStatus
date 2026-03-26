using System.Collections.Generic;

namespace AGUILAR
{
    public class orderappservice
    {
        private orderdataservice _dataService = new orderdataservice();

        public void CreateOrder(string item)
        {
            _dataService.SaveToSql(item);
            SyncJsonFile();
        }

        public List<OrderInfo> GetOrders()
        {
            return _dataService.GetAllOrders();
        }

        public void RemoveOrder(string item)
        {
            _dataService.DeleteFromSql(item);
            SyncJsonFile();
        }

        private void SyncJsonFile()
        {
            var allData = _dataService.GetAllOrders();
            _dataService.SaveToJson(allData);
        }
    }
}