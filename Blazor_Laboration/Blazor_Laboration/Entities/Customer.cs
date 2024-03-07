using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Address? Address { get; set; }
    }
}
