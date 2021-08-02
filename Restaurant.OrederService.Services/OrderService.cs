using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using Restaurant.OrderService.Infrastructure.Exceptions;
using Restaurant.OrederService.Services.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IClientRepository _clientRepository;

        public OrderService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<long> CreateOrder(long cpf, Order order)
        {

            var client = await _clientRepository.GetClientByCpf(cpf);

            if (client != null)
            {
                client.Account.AddOrder(order);

                await _clientRepository.UnitOfWork.SaveChangesAsync();

                return order.Id;
            }

            throw new AccountNotFoundException($"Not able to find account associated with cpf '{cpf}'");
        }
    }
}
