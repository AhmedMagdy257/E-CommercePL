using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace E_CommercePL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var Product = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(Product);
        }
        public IActionResult Details(int id) {

            var product = _unitOfWork.ProductRepository.GetById(id);
            return View(product);
        }
    }
}
