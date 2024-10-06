using System;

namespace ExceptionHandlingExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int x = 5;
                    int i = int.Parse(Console.ReadLine()); // Ввод значения i
                    int y = x / i;
                    Console.WriteLine("x={0}, y={1}", x, y);
                }
                catch (System.DivideByZeroException e)
                {
                    Console.WriteLine("Попытка деления на ноль", e.ToString());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Введено не целое число! Исключение: {0}", e.ToString());
                }
                catch
                {
                    Console.WriteLine("Неизвестная ошибка. Перезапустите программу");
                    throw;
                }
                finally
                {
                    Console.WriteLine("Выполнили блок finally");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.HelpLink);
            }
        }
    }
}
