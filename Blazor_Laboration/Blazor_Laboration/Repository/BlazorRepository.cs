using Blazor_Laboration.DbContexts;
using Blazor_Laboration.Entities;
using Blazor_Laboration.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blazor_Laboration.Repository
{
	public class BlazorRepository : IBlazorRepository
    {
        private readonly BlazorContext _context;

        public BlazorRepository(BlazorContext context)
        {
            _context = context;
        }

		public async Task AddToCart(Product product, int cartId)
        {
            var shoppingCart = await _context.Set<IShoppingCart>().FindAsync(cartId);
            if (shoppingCart != null)
            {
                shoppingCart.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public async Task AddToProduct(string url, int productId)
        {
            var product = await _context.Set<Product>().FindAsync(productId);
            if (product != null)
            {
                product.ImageUrl = url;
                _context.SaveChanges();
            }
        }

        public async Task<int> AddEntityAsync<T>(T t) where T : class
        {
            var entity = await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            var values = entity.CurrentValues;
            return values.GetValue<int>("Id");
        }

        public async Task<bool> DeletEntityAsync<T>(T t) where T : class
        {
            _context.Set<T>().Remove(t);
            return await SaveChangesAsync();
        }

        public async Task UpdateEntityAsync<T>(Expression<Func<T, bool>> expression, dynamic propertyValue) where T : class
        {
            var obj = await GetEntityAsync(expression);


        }

		public async Task<T?> GetEntityAsync<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return await _context.Set<T>().FirstOrDefaultAsync(expression);
		}

		//public async Task<IEnumerable<T>> GetEntitiesAsync<T>() where T : class
  //      {
  //          return await _context.Set<T>().ToListAsync();
  //      }

        public async Task<IEnumerable<T?>> GetEntitiesAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

		public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 1;
        }
    }
}
