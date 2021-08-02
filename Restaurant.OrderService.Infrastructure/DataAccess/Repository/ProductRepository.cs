using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(RestaurantDbContext context) : base(context)
        {
        }

        public async Task<int> InsertMany(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                await _context.Products.AddAsync(product);
            }

            return await _context.SaveChangesAsync();
        }
    }
}
