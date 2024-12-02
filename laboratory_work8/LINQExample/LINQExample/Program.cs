using LINQExample.Interfaces;
using LINQExample.Models;
using LINQExample.Services;
using System;

namespace LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ Example:");

            IDataProvider dataProvider = new DataProvider();
            IProcessor dataProcessor = new DataProcessor();

            // Получение данных
            var people = dataProvider.GetPeople();
            var products = dataProvider.GetProducts();

            // Использование LINQ методов
            Console.WriteLine("\nAdults:");
            var adults = dataProcessor.GetAdults(people);
            foreach (var adult in adults)
            {
                Console.WriteLine(adult);
            }

            Console.WriteLine("\nExpensive Products (>= $500):");
            var expensiveProducts = dataProcessor.GetExpensiveProducts(products, 500);
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nProduct Names (Sorted):");
            var productNames = dataProcessor.GetProductNamesSorted(products);
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }

            // Использование операторов LINQ
            Console.WriteLine("\nLINQ Query Syntax - Products Above $200:");
            var query = from p in products
                        where p.Price > 200
                        orderby p.Price descending
                        select p;

            foreach (var product in query)
            {
                Console.WriteLine(product);
            }
        }
    }
}
