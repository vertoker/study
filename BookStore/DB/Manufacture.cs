using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class Manufacture
    {
        public Manufacture()
        {
            Product = new HashSet<Product>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
