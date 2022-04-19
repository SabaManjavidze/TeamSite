using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;
using TeamSite.Repositories.Abstractions;
using TeamSite.DataBase;

namespace TeamSite.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly TeamDbContext _dbContext;

        public ProductRepository(TeamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetProducts()
        {
            return _dbContext.Products;
        }
    }
}
