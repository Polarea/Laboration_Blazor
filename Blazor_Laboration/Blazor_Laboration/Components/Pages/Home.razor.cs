namespace Blazor_Laboration.Components.Pages
{
	public partial class Home
    {
		protected async override Task OnInitializedAsync()
        {
           await data.GetShoppingCartAndProductsAsync();
        }
	}
}