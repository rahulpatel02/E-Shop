using E_Shop.Data.Models;

namespace E_Shop.ViewModels
{
	public class OrderDetailsViewModel
	{

		//public string FirstName { get; set; }	
		//public string LastName { get; set; }

		//public string Address { get; set; }
		//public string State { get; set; }
		//public string Country { get; set; }
		//public string PostalCode { get; set; }

		//public string Phone { get; set; }
		//public string Email { get; set; }

		//public int OrderId { get; set; }
		//public  decimal OrderTotal { get; set; }

		//public DateTime OrderPlace { get; set; }

		public Order userOrderInfo { get; set; }
		//public IQueryable <OrderDetail> orderDetail { get; set; }
         public IEnumerable<Product> products { get; set; }
		public IEnumerable< ProductNameAndOrdersMapper> ProductNameAndOrdersMapper { get; set; }
	


	}
}
