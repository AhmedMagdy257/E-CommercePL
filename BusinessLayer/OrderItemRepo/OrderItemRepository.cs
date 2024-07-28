using BusinessLayer.GenericRepo;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderItemRepo
{
    public class OrderItemRepository : GenericRepository<OrderItem>,IOrderItemRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public OrderItemRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public OrderItem CheckOrderItem(int Orderid,int Productid){
            var orderitem = _dbContext.OrderItems
                  .Where(a => a.OrderId == Orderid && a.ProductId == Productid)
                  .FirstOrDefault();
            return orderitem;
        }

        public List<OrderItem> GetOrderItems(int Orderid) {
            var orderitems = _dbContext.OrderItems.Include("Product").Where(a=>a.OrderId==Orderid).ToList();
            return orderitems;
        }

    }
}
