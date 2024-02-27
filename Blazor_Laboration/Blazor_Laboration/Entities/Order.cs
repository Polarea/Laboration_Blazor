using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }

    }
}
