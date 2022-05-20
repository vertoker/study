using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WebApp.Entities;

internal class ApplicationContextDB : DbContext
{
    public DbSet<OrderEntity> Orders;
    public DbSet<ProductEntity> Products;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection = string.Join(";", "server=127.0.0.1", "port=3307", "user=root", "password=root", "database=shop_churakov");
        optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 0)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<user>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(e => e.RoleID);
    }

    public static List<OrderEntity> GetOrders()
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        return db.Orders.ToList();
    }
    public static List<ProductEntity> GetProducts()
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        return db.Products.ToList();
    }

    public static void UpdateOrders(List<OrderEntity> orders)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        foreach (var order in db.Orders)
            db.Orders.Remove(order);
        db.Orders.AddRange(orders);
        db.SaveChanges();
    }
    public static void UpdateProducts(List<ProductEntity> products)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        foreach (var product in db.Products)
            db.Products.Remove(product);
        db.Products.AddRange(products);
        db.SaveChanges();
    }
}