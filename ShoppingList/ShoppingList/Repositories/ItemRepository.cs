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
            return user != null;
        }

        public List<Item> GetAllInfo()
        {
            return ShoppingListContext.Items.Select(x => x).ToList();
        }

        public int GetUserId(string name)
        {
            return ShoppingListContext.Users.Where(x => x.Name == name).Select(x => x.Id).FirstOrDefault();
        }

        public List<Item> GetUserItems(string name)
        {
            return ShoppingListContext.Items.Where(x => x.UserId == GetUserId(name)).ToList();
        }
        public void AddItem(string name, Item item)
        {
            ShoppingListContext.Add
                (
                new Item { Description = item.Description, IsUrgent = item.IsUrgent, ItemName = item.ItemName, Quantity = item.Quantity, Time = DateTime.Now, UserId = GetUserId(name)}
                );
            ShoppingListContext.SaveChanges();
        }

        //public void DeleteItem(Item item, User user)
        //{
        //    ShoppingListContext.DeletedItems.Add(Description = item.Description, IsUrgent = item.IsUrgent, ItemName = item.ItemName, Quantity = item.Quantity, Time = DateTime.Now, UserId = GetUserId(name))
        //    ShoppingListContext.Items.Remove(item.Id);
        //    ShoppingListContext.SaveChanges();
        //}

        public void AddUser(string name)
        {
            ShoppingListContext.Add
                (
                new User { Name = name }
                );
            ShoppingListContext.SaveChanges();
        }
    }
}
