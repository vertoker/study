using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WPFBD.Scripts
{
    class ApplicationContextDB : DbContext
    {
        public DbSet<teacher> teacher { get; set; }
        public DbSet<role> role { get; set; }

        public ApplicationContextDB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1; port=3306; user=root; password=root; database=teacherdb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<teacher>().HasOne(t => t.ROLEOBJECT).WithMany(r => r.TEACHERS).HasForeignKey(t => t.ROLE);
        }

        public static List<teacher> GetDatabase()
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                List<teacher> teacherList = db.teacher.ToList();
                foreach (var i in teacherList)
                    i.ROLEOBJECT = db.role.Single(r => r.ID == i.ID);
                return teacherList;
            }
        }
        public static void SetDatabase()
        {

        }

        public static void Add(teacher teacher)
        {

        }
        public static teacher Get(int id)
        {
            teacher teacher = new teacher();
            teacher.ROLEOBJECT = new role();
            return teacher;
        }
        public static void Set(teacher teacher)
        {

        }
        public static void Delete(teacher teacher)
        {

        }
    }
}
