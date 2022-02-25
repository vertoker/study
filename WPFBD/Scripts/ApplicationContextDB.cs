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
            optionsBuilder.UseMySQL("server=127.0.0.1; port=3307; user=root; password=root; database=teacherdb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<teacher>().HasOne(t => t.ROLEOBJECT).WithMany(r => r.TEACHERS).HasForeignKey(t => t.ROLE);
        }

        public static List<teacher> GetTeachers()
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                List<teacher> teacherList = db.teacher.ToList();
                foreach (var i in teacherList)
                    i.ROLEOBJECT = db.role.Single(r => r.ID == i.ROLE);
                return teacherList;
            }
        }
        public static List<role> GetRoles()
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                List<role> rolesList = db.role.ToList();
                return rolesList;
            }
        }
        public static void SetDatabase()
        {

        }

        public static void Add(teacher teacher)
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                db.teacher.Add(teacher);
                db.SaveChanges();
            }
        }
        public static void Modify(teacher teacher)
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                teacher t = db.teacher.Single(tch => tch.ID == teacher.ID);
                t.FULLNAME = teacher.FULLNAME;
                t.ROLE = teacher.ROLE;
                t.DEPARTMENT = teacher.DEPARTMENT;
                t.EXPERIENCE = teacher.EXPERIENCE;

                db.SaveChanges();
            }
        }
        public static void Delete(teacher teacher)
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                db.teacher.Remove(teacher);
                db.SaveChanges();
            }
        }
    }
}
