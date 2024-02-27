using Blazor_Laboration.Entities;

namespace Blazor_Laboration.Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        List<Product> Products { get; set; }

    }
}
