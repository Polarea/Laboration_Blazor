using Blazor_Laboration.Components.Pages;
using Blazor_Laboration.DbContexts;
using Blazor_Laboration.Entities;
using Blazor_Laboration.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Blazor_Laboration.Repository
{
    public class BlazorRepository : IBlazorRepository
    {
        private readonly BlazorContext _context;

        public BlazorRepository(BlazorContext context)
        {
            _context = context;
        }

		public async Task AddToCartAsync(int productId, int cartId, int quantity)
        {
            var shoppingCart = await _context.ShoppingCarts
                .Include(cart => cart.CartItems)
                .FirstOrDefaultAsync(cart => cart.Id == cartId);
            if (shoppingCart != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product != null)
                {
                    var cartItem = shoppingCart.CartItems.FirstOrDefault(c => c.Product.Id == product.Id);
                    if (cartItem == null)
                    {
						cartItem = new CartItem() { Product = product, Quantity = quantity };
						shoppingCart.CartItems.Add(cartItem);
					}
                    else
                    {
                        cartItem.Quantity += quantity;
                    }
                    
                    _context.SaveChanges();
                }
            }
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
			var order = await _context.Orders
			.Include(cart => cart.CartItems) 
            .ThenInclude(items => items.Product)
			.FirstOrDefaultAsync(order => order.Id == orderId);
            return order;
		}

        public Customer? GetCustomer(int customerId)
        {
            var customer = _context.Customers
                .Where(c => c.Address != null)
                .Include(c => c.Address)
				.FirstOrDefault(c => c.Id == customerId);
            return customer;
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
            var subEntities = typeof(T).GetProperties();
            var subEntityList = subEntities?.FirstOrDefault(s => s.PropertyType.IsGenericType)?.Name;
            if (subEntityList != null)
            {
				return await _context.Set<T>()
				.Include(subEntityList)
				.FirstOrDefaultAsync(expression);
			}
            else
            {
				return await _context.Set<T>().FirstOrDefaultAsync(expression);
			}
		}

        public async Task<IEnumerable<T>> GetEntitiesAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T?>> GetEntitiesByPropertyAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

		public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 1;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
