namespace E_Shop.Data.Models
{
	public class ProductNameAndOrdersMapper
	{
		public int OrderId { get; set; }
		public string ProductName { get; set; }
		
		public int Qty { get; set; }
		public decimal UnitPrice { get; set; }

		public decimal TotalAmountPerUnit { get; set; }
	}
}
