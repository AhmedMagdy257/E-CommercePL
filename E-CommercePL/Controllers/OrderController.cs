using BusinessLayer;
using DataAccess.Model;
using E_CommercePL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommercePL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() //Cart
        {
            var userid = HttpContext.Session.GetString("userId");
            var order = _unitOfWork.OrderRepository.UserHasOrder(userid);
            var orderitem=_unitOfWork.OrderItemRepository.GetOrderItems(order.Id);

            return View(orderitem);
        }
        public IActionResult AddItem(int id) //id =Productid
        {
            var Product = _unitOfWork.ProductRepository.GetById(id);
            var userid = HttpContext.Session.GetString("userId");
            var order = _unitOfWork.OrderRepository.UserHasOrder(userid);
            if (order == null) {
                order = new Order()
                {
                    IdentityUserId = userid,
                    OrderDate = DateTime.Now,
                    TotalAmount = 0,
                };
                _unitOfWork.OrderRepository.Add(order);
                _unitOfWork.Save();
            }

            var orderitem = _unitOfWork.OrderItemRepository.CheckOrderItem(order.Id,id);
            if (orderitem == null)
            {
                orderitem = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = id,
                    Quantity = 1,
                    Price = Product.Price
                };
                _unitOfWork.OrderItemRepository.Add(orderitem);
                _unitOfWork.Save();
            }
            else {
                orderitem.Quantity += 1;
                orderitem.Price += Product.Price;   
                _unitOfWork.OrderItemRepository.Update(orderitem);
                _unitOfWork.Save();

            }
            order.TotalAmount += Product.Price;
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Save();

            Product.Stock -=1;
            _unitOfWork.ProductRepository.Update(Product);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");
        }
    }
}
