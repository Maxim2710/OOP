using OnlineStore.Controllers;
using OnlineStore.Interfaces;
using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var categoryService = new CategoryService();
            var userService = new UserService();
            var orderService = new OrderService();

            var productController = new ProductController(productService);
            var categoryController = new CategoryController(categoryService);
            var userController = new UserController(userService);
            var orderController = new OrderController(orderService);

            // Добавление категорий
            categoryController.AddCategory("Working");
            categoryController.AddCategory("Gaming");

            // Добавление продуктов
            productController.AddProduct("MacBook 14 M1 Pro", 3000.99m, "Comfortable and prestigious laptop", "M1 Pro", 16);
            productController.AddProduct("Dell XPS 13", 1500.50m, "Compact and powerful laptop", "Intel i7", 16);
            productController.AddProduct("HP Spectre x360", 1400.00m, "Versatile 2-in-1 laptop", "Intel i7", 16);
            productController.AddProduct("Lenovo ThinkPad X1 Carbon", 2500.00m, "Business laptop with excellent battery life", "Intel i7", 16);
            productController.AddProduct("Asus ROG Zephyrus G14", 1800.75m, "Gaming laptop with high performance", "AMD Ryzen 9", 32);
            productController.AddProduct("Acer Swift 3", 800.00m, "Affordable ultrabook for everyday use", "AMD Ryzen 5", 8);
            productController.AddProduct("Microsoft Surface Laptop 4", 1300.99m, "Stylish laptop with great performance", "Intel i5", 8);
            productController.AddProduct("Razer Blade 15", 2500.00m, "High-end gaming laptop", "Intel i7", 16);

            // Регистрация пользователей
            userController.RegisterUser("maxim_primak", "max@mail.ru");
            userController.RegisterUser("vanya_vorov", "vano@gmail.com", true); // admin

            // Получение пользователей
            var user = userController.GetUserByUsername("maxim_primak");
            Console.WriteLine($"Registered User: {user.Username}, Email: {user.Email}, Admin: {user.IsAdmin}");

            // Создание заказа
            var products = productController.GetAllProducts();
            var productsToOrder = products.Take(3).ToList(); // Выберем первые 3 продукта для заказа
            orderController.CreateOrder(user, productsToOrder);

            // Получение всех продуктов
            var allProducts = productController.GetAllProducts();
            foreach (var product in allProducts)
            {
                Console.WriteLine(product.GetProductDetails());
            }

            // Получение всех категорий
            var allCategories = categoryController.GetAllCategories();
            Console.WriteLine("Categories:");
            foreach (var category in allCategories)
            {
                Console.WriteLine($"- {category.CategoryName}");
            }
        }
    }
}
