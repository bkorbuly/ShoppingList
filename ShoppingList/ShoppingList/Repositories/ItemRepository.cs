using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Entities;
using ShoppingList.Models;

namespace ShoppingList.Repositories
{
    public class ItemRepository
    {
        ShoppingListContext ShoppingListContext;

        public ItemRepository(ShoppingListContext shoppingListContext)
        {
            this.ShoppingListContext = shoppingListContext;
        }

        public bool CheckUserExist(string name)
        {
            var user = ShoppingListContext.Users.FirstOrDefault(u => u.Name.Equals(name));
            return user != null ? true : false;
        }

        public List<Item> GetInfo()
        {
            return ShoppingListContext.Items.Select(x => x).ToList();
        }

        public void Add()
        {
            ShoppingListContext.Add
                (
                new Item { Id = 2, ItemName = "Leves", UserId = 1 }
                );
            ShoppingListContext.SaveChanges();
        }
    }
}
