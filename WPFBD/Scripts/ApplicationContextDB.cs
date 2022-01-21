using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WPFBD.Scripts
{
    class ApplicationContextDB : DbContext
    {
        private DbSet<TeacherDB> _teachers;
        private DbSet<RoleDB> _roles;

        public DbSet<TeacherDB> Teachers => _teachers;
        public DbSet<RoleDB> Roles => _roles;

        public ApplicationContextDB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1; port=3306; user=root; password=root; database=TeachersDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherDB>().HasOne(t => t.Role).WithMany(r => r.Teachers).HasForeignKey(t => t.ID);
        }


        public static List<TeacherDB> GetTeachers()
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                List<TeacherDB> teacherList = db.Teachers.ToList();
                foreach (var i in teacherList)
                    i.Role = db.Roles.Single(r => r.ID == i.ID);
                return teacherList;
            }
        }
    }
}
