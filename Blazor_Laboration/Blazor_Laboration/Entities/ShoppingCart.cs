using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public int Id { get; set; }
        public string? SessionId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
