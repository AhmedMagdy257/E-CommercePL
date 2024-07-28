using BusinessLayer.OrderItemRepo;
using BusinessLayer.OrderRepo;
using BusinessLayer.ProductRepo;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ECommerceDbContext _dbContext;
        public IOrderRepository OrderRepository { get; set; }  
        public IOrderItemRepository OrderItemRepository { get; set; }  
        public IProductRepository ProductRepository { get; set; }  
        public UnitOfWork(ECommerceDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IProductRepository productRepository) {
            _dbContext=dbContext;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
            ProductRepository = productRepository;
        }
        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();
        }
    }
}
