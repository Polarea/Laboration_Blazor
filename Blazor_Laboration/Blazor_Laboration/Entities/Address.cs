using Blazor_Laboration.Interfaces;

namespace Blazor_Laboration.Entities
{
	public class Address : IAddress
	{
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public int ResidenceNumber { get; set; }
        public string? City { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
