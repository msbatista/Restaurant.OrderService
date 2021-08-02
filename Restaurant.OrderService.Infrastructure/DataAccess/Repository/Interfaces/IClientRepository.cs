using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces
{
    public interface IClientRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<int> Insert(Client client);
        Task<Client> GetClientByCpf(long cpf);
        Task DeleteAccount(long cpf);
    }
}
