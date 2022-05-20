using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System;

using Microsoft.EntityFrameworkCore;

using WebApp.Entities;

internal class ApplicationContextDB : DbContext
{
    public DbSet<data> data { get; set; }
    public DbSet<user> user { get; set; }
    public DbSet<order> order { get; set; }
    public DbSet<product> product { get; set; }

    public ApplicationContextDB()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection = string.Join(";", "server=127.0.0.1", "port=3307", "user=root", "password=root", "database=shop_churakov");
        optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 0)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<order>().HasOne(x => x.UserObject).WithMany(x => x.Orders).HasForeignKey(e => e.UserID);
    }

    public static List<order> GetOrders(out int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        counter = db.data.ToArray()[0].CounterOrder;
        return db.order.ToList();
    }
    public static List<product> GetProducts(out int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        counter = db.data.ToArray()[0].CounterProduct;
        return db.product.ToList();
    }
    public static void UpdateOrders(List<order> orders, int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        foreach (var order in db.order)
            db.order.Remove(order);
        db.order.AddRange(orders);
        db.data.ToArray()[0].CounterOrder = counter;
        db.SaveChanges();
    }
    public static void UpdateProducts(List<product> products, int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        foreach (var product in db.product)
            db.product.Remove(product);
        db.product.AddRange(products);
        db.data.ToArray()[0].CounterProduct = counter;
        db.SaveChanges();
    }

    public static void AddUser(string login, string password, UserRole role)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        int id = db.data.ToArray()[0].CounterUser;
        user user = new user()
        {
            ID = id,
            Login = login,
            Password = password,
            UserRole = (byte)role
        };
        db.user.Add(user);
        db.data.ToArray()[0].CounterUser = id + 1;
        db.SaveChanges();
    }
    public static ClaimsIdentity GetIdentity(string username, string password)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        user user = db.user.FirstOrDefault(x => x.Login == username && x.Password == password);
        if (user != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        return null;
    }
}