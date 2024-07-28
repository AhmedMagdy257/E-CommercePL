using BusinessLayer.GenericRepo;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderRepo
{
    public class OrderRepository :GenericRepository<Order>,IOrderRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public OrderRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }
        public Order UserHasOrder(string userid) {
            var order = _dbContext.Orders.Where(a => a.IdentityUserId == userid).FirstOrDefault();
            return order;   
        }

    }
}
