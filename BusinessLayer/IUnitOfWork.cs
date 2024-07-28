using BusinessLayer.OrderItemRepo;
using BusinessLayer.OrderRepo;
using BusinessLayer.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }   
        IOrderItemRepository OrderItemRepository { get; }
        IProductRepository ProductRepository { get; }


        int Save();
    }
}
