using Blazor_Laboration.Entities;
using System.Linq.Expressions;

namespace Blazor_Laboration.Interfaces
{
	public interface IBlazorRepository
    {
        Task AddToCart(Product product, int cartId);
        Task AddToProduct(string url, int productId);
        Task<int> AddEntityAsync<T>(T entity) where T : class;
        Task<bool> DeletEntityAsync<T>(T entity) where T : class;
		Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        //Task<IEnumerable<T>> GetEntitiesAsync<T>() where T : class;
        Task<IEnumerable<T>> GetEntitiesAsync<T>(Expression<Func<T, bool>> expression) where T : class;
		Task<bool> SaveChangesAsync();
    }
}
