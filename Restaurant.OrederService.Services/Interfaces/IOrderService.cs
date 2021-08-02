using Restaurant.OrderService.Domain;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services.Interfaces
{
    public interface IOrderService
    {
        Task<long> CreateOrder(long cpf, Order order);
    }
}
