using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBD.Scripts
{
    /// <summary>
    /// Таблица базы данных для работы БД
    /// </summary>
    public class TeacherDB
    {
        private string _fullName;
        private string _post;
        private int _id;
        private RoleDB _role;
        private int _experience;
        private string _department;

        public string FullName => _fullName;
        public string Post => _post;
        public int ID => _id;
        public RoleDB Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        public int Experience => _experience;
        public string Department => _department;

        public TeacherDB()
        {

        }

        public TeacherDB(int id, RoleDB role, string firstName, string lastName, string patronymic, string post, int experience, string department)
        {
            _id = id;
            _fullName = string.Join(" ", firstName, lastName, patronymic);
            _post = post;
            _role = role;
            _experience = experience;
            _department = department;
        }
    }
}
