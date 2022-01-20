using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBD.Scripts
{
    /// <summary>
    /// Таблица базы данных для лабораторной 5.1
    /// </summary>
    public class Teacher
    {
        private readonly string _fullName;
        private readonly string _post;
        private readonly int _experience;
        private readonly string _department;

        public string FullName => _fullName;
        public string Post => _post;
        public int Experience => _experience;
        public string Department => _department;

        public Teacher()
        {

        }

        public Teacher(string firstName, string lastName, string patronymic, string post, int experience, string department)
        {
            _fullName = string.Join(" ", firstName, lastName, patronymic);
            _post = post;
            _experience = experience;
            _department = department;
        }
    }
}
