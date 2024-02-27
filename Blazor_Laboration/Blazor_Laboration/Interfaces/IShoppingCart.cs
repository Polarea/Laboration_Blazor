using Blazor_Laboration.Entities;

namespace Blazor_Laboration.Interfaces
{
    public interface IShoppingCart
    {
        int Id { get; set; }
        List<Product> Products { get; set; }
    }
}
