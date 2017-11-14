using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Entities;

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
    }
}
