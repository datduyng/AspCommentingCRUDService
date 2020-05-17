using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AspMultiTenantCommentAPI.Models;

namespace AspMultiTenantCommentAPI
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            :base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Thread> Threads { get; set; }

        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=database.db");
        //}
    }

    public class Order
    {
        public int OrderId { get; set; }

        public DateTime? Created { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}