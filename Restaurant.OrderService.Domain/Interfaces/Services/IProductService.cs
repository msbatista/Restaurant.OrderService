using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<int> InsertProducts(IEnumerable<Product> products);
    }
}
