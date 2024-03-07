namespace Blazor_Laboration.Interfaces
{
    public interface IProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Price { get; set; }

    }
}
