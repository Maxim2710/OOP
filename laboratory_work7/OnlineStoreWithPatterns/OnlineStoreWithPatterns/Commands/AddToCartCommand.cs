namespace OnlineStore.Commands
{
    using OnlineStore.Services;
    using OnlineStore.Models;

    /*
     * Шаблон "Команда" инкапсулирует запрос как объект, позволяя параметризовать объекты с запросами, очередями и журналами. 
     * Это полезно для обработки пользовательских операций (например, добавление товара в корзину).
     */

    public interface IAppCommand
    {
        void Execute();
    }

    public class AddToCartCommand : IAppCommand
    {
        private readonly ShoppingCart _cart;   // Хранит ссылку на корзину
        private readonly IProduct _product;    // Хранит ссылку на продукт для добавления

        // Конструктор принимает корзину и продукт
        public AddToCartCommand(ShoppingCart cart, IProduct product)
        {
            _cart = cart;
            _product = product;
        }

        // Реализация метода Execute без параметров
        public void Execute()
        {
            _cart.AddProduct(_product); // Добавляет продукт в корзину
        }
    }
}
