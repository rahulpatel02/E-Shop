using E_Shop.Data.Models;

namespace E_Shop.ViewModels
{
	public class OrderDetailsViewModel
	{
		public Order userOrderInfo { get; set; }
		public decimal subTotal { get; set; }
		public decimal taxAmount { get; set; }

		public decimal total { get; set; }
         public IEnumerable<Product> products { get; set; }
		public IEnumerable< ProductNameAndOrdersMapper> ProductNameAndOrdersMapper { get; set; }
	


	}
}
