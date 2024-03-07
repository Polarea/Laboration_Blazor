using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Price { get; set; }
    }
}