using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TeamSite.Repositories.Implementations.CartRepository;

namespace TeamSite.Models
{
    public class Order
    {
        public int Id { get; set; }

        public List<CartLine> Lines { get; set; }

        public decimal TotalPrice { get; set; }

        public string FullName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
