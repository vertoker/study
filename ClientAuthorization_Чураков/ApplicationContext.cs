using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ClientAuthorization_Чураков
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<user>? Users;
        public DbSet<role>? Roles;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = string.Join(";", "server=127.0.0.1", "port=3306", "user=root", "password=root", "database=client_db");
            optionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 0)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(e => e.RoleID);
        }
    }
}
