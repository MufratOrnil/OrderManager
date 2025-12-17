using MasterDetailApp.Models;
using System.Collections.Generic;

namespace MasterDetailApp.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
