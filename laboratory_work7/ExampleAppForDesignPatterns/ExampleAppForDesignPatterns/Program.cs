using System;
using ExampleAppForDesignPatterns.GeneratingPatterns;
using ExampleAppForDesignPatterns.SingletonPattern;

namespace ExampleAppForDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Использование Windows фабрики
            IGUIFactory windowsFactory = new WindowsFactory();
            Client windowsClient = new Client(windowsFactory);
            windowsClient.Interact();

            // Использование Mac фабрики
            IGUIFactory macFactory = new MacFactory();
            Client macClient = new Client(macFactory);
            macClient.Interact();


            // Строим офисный компьютер
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            Director officeDirector = new Director(officeBuilder);
            officeDirector.ConstructComputer();
            Computer officeComputer = officeDirector.GetComputer();
            Console.WriteLine(officeComputer);

            // Строим игровой компьютер
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            Director gamingDirector = new Director(gamingBuilder);
            gamingDirector.ConstructComputer();
            Computer gamingComputer = gamingDirector.GetComputer();
            Console.WriteLine(gamingComputer);


            // Создаем генератор отчетов для PDF
            ReportGenerator pdfReportGenerator = new PDFReportGenerator();
            pdfReportGenerator.GenerateReport(); // Выводит: Generating PDF Report

            // Создаем генератор отчетов для HTML
            ReportGenerator htmlReportGenerator = new HTMLReportGenerator();
            htmlReportGenerator.GenerateReport(); // Выводит: Generating HTML Report


            // Создаем оригинальный документ Word
            IDocument originalWordDocument = new WordDocument("Quarterly Financial Report");
            originalWordDocument.Print(); // Вывод: Printing Word Document: Quarterly Financial Report

            // Клонируем оригинальный документ
            IDocument clonedWordDocument = originalWordDocument.Clone();
            clonedWordDocument.Print(); // Вывод: Printing Word Document: Quarterly Financial Report

            // Создаем оригинальный документ Excel
            IDocument originalExcelDocument = new ExcelDocument("Sales Data Q1 2024");
            originalExcelDocument.Print(); // Вывод: Printing Excel Document: Sales Data Q1 2024

            // Клонируем оригинальный Excel документ
            IDocument clonedExcelDocument = originalExcelDocument.Clone();
            clonedExcelDocument.Print(); // Вывод: Printing Excel Document: Sales Data Q1 2024


            // Получаем экземпляр одиночки
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething(); // Вывод: Singleton is doing something!

            // Проверяем, что оба обращения к экземпляру возвращают один и тот же объект
            Singleton anotherSingleton = Singleton.Instance;
            Console.WriteLine(Object.ReferenceEquals(singleton, anotherSingleton)); // Вывод: True
        }
    }
}
