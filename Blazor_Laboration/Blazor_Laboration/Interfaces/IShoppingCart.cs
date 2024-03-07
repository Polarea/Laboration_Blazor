using Blazor_Laboration.Entities;

namespace Blazor_Laboration.Interfaces
{
    public interface IShoppingCart
    {
        int Id { get; set; }
        string? SessionId { get; set; }
        List<CartItem> CartItems { get; set; }
    }
}
