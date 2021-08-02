using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Context
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
