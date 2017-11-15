using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Services;
using ShoppingList.Models;

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
        [HttpPost]
        [Route("/login")]
        public IActionResult Index(string name)
        {
            if (ItemService.CheckUser(name))
            {
                return LocalRedirect("/List/" + name);
            }
            return LocalRedirect("/AddUser/" + name);
        }

        [Route("/AddUser/{name}")]
        public IActionResult AddUser(string name)
        {
            var user = new User() { Name = name };
            return View(user);
        }

        [HttpPost]
        [Route("/AddUser/{name}")]
        public IActionResult UserAdded(string name)
        {
            ItemService.AddUser(name);
            return LocalRedirect("/List/" + name);
        }

        [Route("/List")]
        public IActionResult List(string name)
        {
            ItemService.AddItem(name);
            return Content(ItemService.GetAllItemInfo());
        }

        [Route("/List/{name}")]
        public IActionResult FilteredList(string name)
        {
            return Content(ItemService.GetUserItems(name));
        }
    }
}
