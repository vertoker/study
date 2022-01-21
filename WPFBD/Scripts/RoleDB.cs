using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBD.Scripts
{
    /// <summary>
    /// Таблица базы данных для работы БД (роли)
    /// </summary>
    public class RoleDB
    {
        private int _id;
        private string _roleName;
        private List<TeacherDB> _teachers;

        public int ID => _id;
        public string RoleName => _roleName;
        public List<TeacherDB> Teachers => _teachers;

        public RoleDB()
        {

        }

        public RoleDB(int id, string roleName, List<TeacherDB> teachers)
        {
            _id = id;
            _roleName = roleName;
            _teachers = teachers;
        }
    }
}
