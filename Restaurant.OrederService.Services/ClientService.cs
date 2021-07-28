using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Domain.Interfaces.Repositories;
using Restaurant.OrderService.Domain.Interfaces.Services;
using Restaurant.OrderService.Infrastructure.Exceptions;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateClient(Client newClient)
        {
            var client = await _clientRepository.GetClientByCpf(newClient.Cpf);

            if (client != null)
            {
                throw new ObjectAlreadyExistsException($"Not able to insert client. Cpf '{newClient.Cpf}'");
            }

            newClient.Account = new Account();

            await _clientRepository.Insert(newClient);
        }
    }
}
