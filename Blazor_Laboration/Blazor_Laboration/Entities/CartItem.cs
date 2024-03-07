using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
	public class CartItem : ICartItem
	{
        public int Id { get; set; }
        public Product Product { get; set; }
		public int Quantity { get; set; }
    }
}
