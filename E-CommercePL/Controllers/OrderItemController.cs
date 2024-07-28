using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace E_CommercePL.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult RemoveItem(int id) {  //id=orderitemid
            var Item = _unitOfWork.OrderItemRepository.GetById(id);
            _unitOfWork.OrderItemRepository.Delete(Item);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Order");

        }
    }
}
