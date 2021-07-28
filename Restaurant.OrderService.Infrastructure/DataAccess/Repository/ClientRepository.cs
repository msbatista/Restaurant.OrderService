using Microsoft.EntityFrameworkCore;
using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Domain.Interfaces.Repositories;
using Restaurant.OrderService.Infrastructure.DataAccess.Context;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(RestaurantDbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientByCpf(long cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.Cpf == cpf);
        }

        public async Task Insert(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
    }
}
