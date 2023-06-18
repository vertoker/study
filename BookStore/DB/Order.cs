using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int id { get; set; }
        public int idAddress { get; set; }
        public int idStatus { get; set; }

        public StatusEnum StatusEnum { get { return (StatusEnum)idStatus; } set { idStatus = (int)value; } }
        public AddressEnum AddressEnum { get { return (AddressEnum)idAddress; } set { idAddress = (int)value; } }

        public Address Address { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
