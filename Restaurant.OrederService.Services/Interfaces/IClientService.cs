using Restaurant.OrderService.Domain;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services.Interfaces
{
    public interface IClientService
    {
        Task<int> CreateClient(Client client);
        Task DeleteAccount(long cpf);
    }
}
