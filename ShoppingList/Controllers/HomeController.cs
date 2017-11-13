using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;


namespace ShoppingList.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            var item = new Item() { Id = 1, ItemName = "soupcube", IsUrgent = true, Description = "for the soup", Quantity = 1 };
            return View(item);
        }
    }
}
