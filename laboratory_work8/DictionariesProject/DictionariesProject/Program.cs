using MyCustomCollections.Models;
using MyCustomCollections.Helpers;
using System;
using System.Collections.Generic;

namespace MyCustomCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing CustomDictionary:");
            var customDictionary = new CustomDictionary<string, int>();
            customDictionary.Add("One", 1);
            customDictionary.Add("Two", 2);

            Console.WriteLine($"Value for 'One': {customDictionary.Get("One")}");
            Console.WriteLine($"Contains 'Two': {customDictionary.ContainsKey("Two")}");

            var customDictTime = TimerHelper.MeasureExecutionTime(() =>
            {
                for (int i = 0; i < 100000; i++)
                    customDictionary.Add($"Key{i}", i);
            });

            Console.WriteLine($"Time to add 100,000 items to CustomDictionary: {customDictTime} ms");

            //Console.WriteLine("\nTesting standard Dictionary:");
            //var standardDictionary = new Dictionary<string, int>();

            //var standardDictTime = TimerHelper.MeasureExecutionTime(() =>
            //{
            //    for (int i = 0; i < 100000; i++)
            //        standardDictionary.Add($"Key{i}", i);
            //});

            //Console.WriteLine($"Time to add 100,000 items to Dictionary: {standardDictTime} ms");

            Console.WriteLine("\nTesting SmartArray:");
            var smartArray = new SmartArray<int>(5);
            smartArray[0] = 10;
            smartArray[1] = 20;

            Console.WriteLine($"Element at index 1: {smartArray[1]}");

            try
            {
                smartArray[-1] = 5; // Should throw an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                smartArray[2] = -10; // Should throw an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
