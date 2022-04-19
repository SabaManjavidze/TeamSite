using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;

namespace TeamSite.Repositories.Abstractions
{
    public interface ICartRepository
    {
        public void AddItem(Product product,int quantity);

        public void RemoveItem(int productId);

        public decimal TotalPrice();

        public void Clear();


    }
}
