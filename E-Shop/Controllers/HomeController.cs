using E_Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<EShopController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<EShopController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.Products;
            ViewBag.product = product;

            return View(product);
        }
    }
}
