using E_Shop.Data.Models;

namespace E_Shop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; } 
    }
}
