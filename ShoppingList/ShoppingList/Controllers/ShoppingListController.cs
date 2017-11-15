using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Services;
using ShoppingList.Models;
using Newtonsoft.Json;

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
                return LocalRedirect("/List");
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
            return Content(JsonConvert.SerializeObject(ItemService.GetAllItemInfo()));
        }

        [Route("/List/{name}")]
        public IActionResult FilteredList(string name)
        {
            return Content(ItemService.GetUserItems(name));
        }

        [Route("/AddItem/{name}")]
        public IActionResult AddItem(string name)
        {
            var user = new User() { Name = name };
            return View(user);
        }

        [HttpPost]
        [Route("/AddItem/{name}")]
        public IActionResult AddItem(string name, Item item)
        {
            ItemService.AddItem(name, item);
            return RedirectToAction("/List");
        }

        [Route("/DeleteItem/{name}")]
        public IActionResult DeleteItem(string name)
        {
            var list = ItemService.GetAllItemInfo();
            var user = new User() { Name = name };
            var mix = new UserItemView() { user = user, listitem = list };
            return View(mix);
        }

        //[HttpDelete]
        //[Route("/DeleteItem/{name}")]
        //public IActionResult DeleteItem(Item item, User user)
        //{
        //    ItemService.DeleteItem(item, user);
        //    return RedirectToAction("/List");
        //}
    }
}
