using System;

namespace AGUILAR
{
    public class ordermodel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime DateOrdered { get; set; }

        public string Status
        {
            get
            {
                int days = (DateTime.Now - DateOrdered).Days;

                if (days == 0) return "Pending";
                else if (days == 1) return "Processing";
                else if (days == 2) return "Shipped";
                else return "Delivered";
            }
        }
    }
}