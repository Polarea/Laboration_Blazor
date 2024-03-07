using Blazor_Laboration.Entities;

namespace Blazor_Laboration.Interfaces
{
	public interface ICartItem
	{
		int Id { get; }
		Product Product { get; set; }
		int Quantity { get; set; }
	}
}
