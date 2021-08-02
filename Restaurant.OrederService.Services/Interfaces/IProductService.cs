using Restaurant.OrderService.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services.Interfaces
{
    public interface IProductService
    {
        Task<int> InsertProducts(IEnumerable<Product> products);
    }
}
