using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class Address
    {
        public Address()
        {
            Order = new HashSet<Order>();
        }

        public AddressEnum AddressEnum => (AddressEnum)id;

        public int id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
