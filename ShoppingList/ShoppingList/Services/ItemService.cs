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
           var items = ItemRepository.GetInfo();
           var json = JsonConvert.SerializeObject(items);
           return json;
        }
        public void Add()
        {
            ItemRepository.Add();
        }
    }
}
