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
    public class role
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string ROLENAME { get; set; }
        public List<teacher> TEACHERS { get; set; }
    }
}
