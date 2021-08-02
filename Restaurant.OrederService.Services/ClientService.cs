using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using Restaurant.OrderService.Infrastructure.Exceptions;
using Restaurant.OrederService.Services.Interfaces;
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

        public async Task<int> CreateClient(Client newClient)
        {
            var client = await _clientRepository.GetClientByCpf(newClient.Cpf);

            if (client != null)
            {
                throw new ObjectAlreadyExistsException($"Not able to insert client. Cpf '{newClient.Cpf}' already exists!");
            }

            newClient.Account = new Account();

            return await _clientRepository.Insert(newClient);
        }

        public async Task DeleteAccount(long cpf)
        {
            var client = await _clientRepository.GetClientByCpf(cpf);

            if (client.Account.HasDebits())
            {
                throw new DeleteAccountWithDebitsException("Not able to remove account as oppened debits.");
            }

            await _clientRepository.DeleteAccount(cpf);

            await _clientRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
