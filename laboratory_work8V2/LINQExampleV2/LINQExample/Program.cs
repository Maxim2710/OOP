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


            // Пример 1: GroupBy
            Console.WriteLine("\nGroup People by Age Group:");
            var groupedByAge = people.GroupBy(p => p.Age >= 18 ? "Adults" : "Minors");
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var person in group)
                {
                    Console.WriteLine($"  {person}");
                }
            }

            // Пример 2: Join
            Console.WriteLine("\nJoin People and Products by Name:");
            var peopleWithMatchingProducts = people.Join(products,
                person => person.Name,
                product => product.Name,
                (person, product) => new { Person = person, Product = product });
            foreach (var match in peopleWithMatchingProducts)
            {
                Console.WriteLine($"{match.Person.Name} bought a {match.Product.Name}.");
            }

            // Пример 3: SelectMany
            Console.WriteLine("\nFlatten a List of Collections:");
            var nestedList = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };
            var flattenedList = nestedList.SelectMany(list => list);
            Console.WriteLine(string.Join(", ", flattenedList));

            // Пример 4: Aggregate
            Console.WriteLine("\nAggregate Example - Total Product Price:");
            var totalPrice = products.Aggregate(0m, (sum, product) => sum + product.Price);
            Console.WriteLine($"Total Price: {totalPrice:C}");

            // Пример 5: Distinct
            Console.WriteLine("\nDistinct Example:");
            var duplicateNumbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            var distinctNumbers = duplicateNumbers.Distinct();
            Console.WriteLine(string.Join(", ", distinctNumbers));

            // Пример 6: Any, All, Contains
            Console.WriteLine("\nAny, All, Contains Examples:");
            Console.WriteLine($"Any product costs more than $1000: {products.Any(p => p.Price > 1000)}");
            Console.WriteLine($"All products cost less than $2000: {products.All(p => p.Price < 2000)}");
            Console.WriteLine($"Contains a product named 'Phone': {products.Select(p => p.Name).Contains("Phone")}");

            // Пример 7: Skip, Take
            Console.WriteLine("\nSkip and Take Examples:");
            var firstTwoProducts = products.Take(2);
            var skipFirstTwoProducts = products.Skip(2);
            Console.WriteLine("First 2 Products:");
            foreach (var product in firstTwoProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("\nProducts after skipping first 2:");
            foreach (var product in skipFirstTwoProducts)
            {
                Console.WriteLine(product);
            }

            // Пример 8: Union, Intersect, Except
            Console.WriteLine("\nUnion, Intersect, Except Examples:");
            var list1 = new List<int> { 1, 2, 3, 4 };
            var list2 = new List<int> { 3, 4, 5, 6 };

            var union = list1.Union(list2);
            var intersect = list1.Intersect(list2);
            var except = list1.Except(list2);

            Console.WriteLine($"Union: {string.Join(", ", union)}");
            Console.WriteLine($"Intersect: {string.Join(", ", intersect)}");
            Console.WriteLine($"Except: {string.Join(", ", except)}");

            
        }
    }
    
}
