using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Entities
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
