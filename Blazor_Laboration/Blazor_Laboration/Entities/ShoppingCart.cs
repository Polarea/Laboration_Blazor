using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

    }
}
