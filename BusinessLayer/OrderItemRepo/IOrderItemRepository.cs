using BusinessLayer.GenericRepo;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderItemRepo
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {

        OrderItem CheckOrderItem(int Orderid,int Productid);
        List<OrderItem> GetOrderItems(int Orderid);
    }
}
