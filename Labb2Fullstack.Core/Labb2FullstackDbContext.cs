using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2Fullstack.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2Fullstack.Core
{
    public class Labb2FullstackDbContext : DbContext
    {
        public Labb2FullstackDbContext(DbContextOptions<Labb2FullstackDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }

}
