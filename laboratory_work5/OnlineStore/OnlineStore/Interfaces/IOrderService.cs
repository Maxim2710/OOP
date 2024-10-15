namespace OnlineStore.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(IOrder order);
        List<IOrder> GetAllOrders();
    }
}
