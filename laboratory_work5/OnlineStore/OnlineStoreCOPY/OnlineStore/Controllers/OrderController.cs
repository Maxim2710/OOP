using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class OrderController
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void CreateOrder(IUser user, List<IProduct> products)
        {
            var order = new Order(user);
            foreach (var product in products)
            {
                order.AddProduct(product);
            }
            _orderService.CreateOrder(order);
        }

        public List<IOrder> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }
    }
}
