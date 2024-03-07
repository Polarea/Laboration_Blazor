namespace Blazor_Laboration.Interfaces
{
	public interface IAddress
	{
		int Id { get; }
        string? StreetName { get; set; }
		int ResidenceNumber {  get; set; }
		string? City { get; set; }
		int PostalCode { get; set; }
		string? Country { get; set; }
    }
}
