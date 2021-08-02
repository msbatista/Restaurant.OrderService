using Restaurant.OrderService.Infrastructure.DataAccess.Context;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Repository
{
    public abstract class BaseRepository
    {
        protected readonly RestaurantDbContext _context;

        protected BaseRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork { get => _context; }
    }
}
