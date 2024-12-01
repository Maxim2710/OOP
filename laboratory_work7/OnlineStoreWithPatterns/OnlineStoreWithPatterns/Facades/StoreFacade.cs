namespace OnlineStore.Facades
{
    using OnlineStore.Models;
    using OnlineStore.Services;
    using OnlineStore.Builders;
    using System.Collections.Generic;

    public class StoreFacade
    {
        private readonly ShoppingCart _cart;
        private readonly OrderBuilder _orderBuilder;

        public StoreFacade()
        {
            _cart = new ShoppingCart();
            _orderBuilder = new OrderBuilder();
        }

        // Добавить товар в корзину
        public void AddProductToCart(IProduct product)
        {
            _cart.AddProduct(product);
        }

        // Удалить товар из корзины
        public void RemoveProductFromCart(IProduct product)
        {
            _cart.RemoveProduct(product);
        }

        // Получить итоговую сумму в корзине
        public decimal GetCartTotal()
        {
            return _cart.Total;
        }

        // Получить список товаров в корзине
        public IEnumerable<IProduct> GetCartProducts()
        {
            return _cart.Products;
        }

        // Создать заказ на основе текущей корзины
        public Order CreateOrder()
        {
            foreach (var product in _cart.Products)
            {
                _orderBuilder.AddProduct(product);
            }

            var order = _orderBuilder.Build();
            ClearCart(); // Очистить корзину после создания заказа
            return order;
        }

        // Очистить корзину
        public void ClearCart()
        {
            foreach (var product in new List<IProduct>(_cart.Products))
            {
                _cart.RemoveProduct(product);
            }
        }
    }
}
