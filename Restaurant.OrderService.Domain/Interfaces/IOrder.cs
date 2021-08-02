namespace Restaurant.OrderService.Domain.Interfaces
{
    public interface IOrder
    {
        void QuitOrder(bool quitOrder);
        bool IsOrderQuitted();
        void AddProduct(Product product);
    }
}
