using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
    public class ShoppingListController : Controller
    {
        ItemService ItemService;
        public ShoppingListController(ItemService itemService)
        {
            this.ItemService = itemService;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("api")]
        public IActionResult Indexs()
        {
            ItemService.Add();
            return Json(ItemService.GetAllItemInfo());
        }
    }
}
