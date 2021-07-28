using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<int> InsertProducts(IEnumerable<Product> products);
    }
}
