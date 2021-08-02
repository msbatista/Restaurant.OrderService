using Restaurant.OrderService.Domain;
using Restaurant.OrderService.Infrastructure.DataAccess.Repository.Interfaces;
using Restaurant.OrederService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrederService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> InsertProducts(IEnumerable<Product> products)
        {
            return await _productRepository.InsertMany(products);
        }
    }
}
