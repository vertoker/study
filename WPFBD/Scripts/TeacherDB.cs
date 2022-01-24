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
    public class teacher
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string FULLNAME { get; set; }
        public int ROLE { get; set; }
        public role ROLEOBJECT { get; set; }
        public string DEPARTMENT { get; set; }
        public int EXPERIENCE { get; set; }
    }
}
