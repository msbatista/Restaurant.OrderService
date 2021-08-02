namespace Restaurant.OrderService.Domain.Interfaces
{
    public interface IAccount
    {
        bool HasDebits();
        void AddOrder(Order order);
    }
}
