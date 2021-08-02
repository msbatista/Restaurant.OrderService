using Restaurant.OrderService.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<int> InsertMany(IEnumerable<Product> products);
    }
}
