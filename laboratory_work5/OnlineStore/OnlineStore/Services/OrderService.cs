using OnlineStore.Interfaces;
using OnlineStore.Models;
using System.Collections.Generic;

namespace OnlineStore.Services
{
    public class OrderService : IOrderService
    {
        private List<IOrder> _orders; // Изменяем тип списка на IOrder

        public OrderService()
        {
            _orders = new List<IOrder>();
        }

        public void CreateOrder(IOrder order)
        {
            _orders.Add(order); // Здесь order - это IOrder
            order.PlaceOrder();
        }

        public List<IOrder> GetAllOrders()
        {
            return _orders; // Возвращаем список IOrder
        }
    }
}
