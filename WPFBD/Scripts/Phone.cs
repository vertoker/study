using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBD.Scripts
{
    /// <summary>
    /// Таблица базы данных
    /// </summary>
    public class Phone
    {
        private readonly string _title;
        private readonly string _company;
        private readonly int _price;

        public string Title { get { return _title; } }
        public string Company { get { return _company; } }
        public int Price { get { return _price; } }

        public Phone(string title, string company, int price)
        {
            _title = title;
            _company = company;
            _price = price;
        }
    }
}
