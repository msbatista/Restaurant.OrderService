using Microsoft.EntityFrameworkCore;
using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderById(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
        }
    }
}
