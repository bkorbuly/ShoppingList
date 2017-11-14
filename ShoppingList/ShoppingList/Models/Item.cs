using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsUrgent { get; set; } = false;
        public User User { get; set; }
    }
}
