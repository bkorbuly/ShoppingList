using Newtonsoft.Json;
using ShoppingList.Models;
using ShoppingList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class ItemService
    {
        ItemRepository ItemRepository;
        public ItemService(ItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public string GetAllItemInfo()
        {
            var items = ItemRepository.GetAllInfo();
            return JsonConvert.SerializeObject(items);
        }
        public void AddItem(string name, Item item)
        {
            ItemRepository.AddItem(name, item);
        }

        public void AddUser(string name)
        {
            ItemRepository.AddUser(name);
        }

        public bool CheckUser(string name)
        {
            return ItemRepository.CheckUserExist(name);
        }

        public string GetUserItems(string name)
        {
            return JsonConvert.SerializeObject(ItemRepository.GetUserItems(name));
        }
    }
}
