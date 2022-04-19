using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;
using TeamSite.Repositories.Abstractions;
using TeamSite.DataBase;
using Microsoft.EntityFrameworkCore;

namespace TeamSite.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TeamDbContext _dbContext;

        public OrderRepository(TeamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.AttachRange(order.Lines.Select(l => l.product));
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public IQueryable<Order> GetOrders()
        {
            return _dbContext.Orders.Include(o => o.Lines).ThenInclude(l => l.product);
        }
    }
}
