using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;

namespace TeamSite.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetProducts();
    }
}
