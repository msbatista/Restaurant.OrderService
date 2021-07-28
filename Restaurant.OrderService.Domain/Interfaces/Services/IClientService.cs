using System.Threading.Tasks;

namespace Restaurant.OrderService.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task CreateClient(Client client);
    }
}
