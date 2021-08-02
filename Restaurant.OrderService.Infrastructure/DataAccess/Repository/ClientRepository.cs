using Microsoft.EntityFrameworkCore;
using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(RestaurantDbContext context) : base(context)
        {
        }

        public async Task DeleteAccount(long cpf)
        {
            var client = await GetClientByCpf(cpf);

            _context.Clients.Remove(client);
        }

        public async Task<Client> GetClientByCpf(long cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.Cpf == cpf);
        }

        public async Task<int> Insert(Client client)
        {
            await _context.Clients.AddAsync(client);
            return await _context.SaveChangesAsync();
        }
    }
}
