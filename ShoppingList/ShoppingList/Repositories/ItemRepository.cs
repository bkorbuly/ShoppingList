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

        public List<Item> GetAllInfo()
        {
            return ShoppingListContext.Items.Select(x => x).ToList();
        }

        public void Add()
        {
            ShoppingListContext.Add
                (
                new Item { ItemName = "Leves", UserId = 2 }
                );
            ShoppingListContext.SaveChanges();
        }
    }
}
