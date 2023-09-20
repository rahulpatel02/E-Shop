using E_Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Components
{
    public class CategoryMenu :ViewComponent

    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetCategories.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
