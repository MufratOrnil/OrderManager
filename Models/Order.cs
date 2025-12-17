using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterDetailApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        public bool IsPaid { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
