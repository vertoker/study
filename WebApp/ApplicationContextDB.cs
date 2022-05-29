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
        /*modelBuilder.Entity<order>().HasOne(x => x.user_object).WithMany(x => x.orders).HasForeignKey(e => e.user_id);*/
    }

    public static List<order> GetOrders(ref int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        counter = db.data.ToArray()[0].counter_order;
        return db.order.ToList();
    }
    public static List<product> GetProducts()
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        return db.product.ToList();
    }
    public static List<product> GetProducts(ref int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        counter = db.data.ToArray()[0].counter_product;
        return db.product.ToList();
    }
    public static void UpdateOrders(List<order> orders, int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        /*foreach (var order in orders)
        {
            if (order.user_object == null)
            {
                user user = db.user.FirstOrDefault((user user) => user.id == order.user_id);
                order.user_object = user;
                if (user.orders == null)
                    user.orders = new List<order>();
                user.orders.Add(order);
            }
        }*/
        foreach (var order in db.order)
            db.order.Remove(order);
        db.order.AddRange(orders);
        db.data.ToArray()[0].counter_order = counter;
        db.SaveChanges();
    }
    public static void UpdateProducts(List<product> products, int counter)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        foreach (var product in db.product)
            db.product.Remove(product);
        db.product.AddRange(products);
        db.data.ToArray()[0].counter_product = counter;
        db.SaveChanges();
    }

    public static void AddUser(string login, string password, UserRole role)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        int id = db.data.ToArray()[0].counter_user;
        user user = new user()
        {
            id = id,
            login = login,
            password = password,
            user_role = (byte)role
        };
        db.user.Add(user);
        db.data.ToArray()[0].counter_user = id + 1;
        db.SaveChanges();
    }
    public static user FindUser(int userID)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        user user = db.user.FirstOrDefault((user user) => user.id == userID);
        /*if (user.Orders == null)
            user.Orders = new List<order>();
        user.Orders.Add(owner);
        db.SaveChanges();*/
        return user;
    }
    public static ClaimsIdentity GetIdentity(string login, string password)
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        user user = db.user.FirstOrDefault(x => x.login == login && x.password == password);
        if (user != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, ((UserRole)user.user_role).ToString())
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        return null;
    }
    public static user[] GetAllUsers()
    {
        using ApplicationContextDB db = new ApplicationContextDB();
        return db.user.ToArray();
    }
}