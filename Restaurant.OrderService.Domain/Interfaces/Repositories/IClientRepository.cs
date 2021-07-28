using System.Threading.Tasks;

namespace Restaurant.OrderService.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task Insert(Client client);
        Task<Client> GetClientByCpf(long cpf);
    }
}
