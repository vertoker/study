using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public StatusEnum StatusEnum => (StatusEnum)id;

        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
