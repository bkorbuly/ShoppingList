using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class UserItemView
    {
        public User user { get; set; }
        public List<Item> listitem { get; set; }
    }
}
