using Restaurant.OrderService.Domain;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(long id);
    }
}
