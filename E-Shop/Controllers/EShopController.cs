using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.Models;
using E_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Shop.Controllers
{
	public class EShopController : Controller
	{
		private readonly ILogger<EShopController> _logger;
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public EShopController(ILogger<EShopController> logger, ICategoryRepository categoryRepository,IProductRepository productRepository)
		{
			_logger = logger;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		

		public ViewResult List(int categoryId)
		{
			IEnumerable<Product> products;
			string currentCategory=string.Empty;
			if(categoryId <= 0)
			{
				products= _productRepository.Products;
				currentCategory = "All Products";
			}else
			{
                products = _productRepository.Products.Where(p => p.Category.CategoryId == categoryId).OrderBy(p =>p.ProductId);
				var category= _categoryRepository.GetCategories.FirstOrDefault(c => c.CategoryId == categoryId);
				currentCategory = category.CategoryName;

            }
			var productListViewModel = new ProductListViewModel
			{
				Products=products,	
				CurrentCategory=currentCategory,
			};
			return View(productListViewModel);


		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}