using System;
using ExampleAppForDesignPatterns.GeneratingPatterns;
using ExampleAppForDesignPatterns.SingletonPattern;
using ExampleAppForDesignPatterns.StructuralPatterns;

namespace ExampleAppForDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Порождающие паттерны проектирования: \n");

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

            Console.WriteLine("\n");

            Console.WriteLine("Структурные паттерны проектирования: \n");

            // Создаем адаптируемый объект
            Adaptee adaptee = new Adaptee();

            // Создаем адаптер и передаем адаптируемый объект
            ITarget adapter = new Adapter(adaptee);

            // Используем адаптер для вызова метода
            adapter.Request(); // Вывод: Called SpecificRequest from Adaptee.


            // Используем реализацию A
            IImplementation implementationA = new ConcreteImplementationA();
            Abstraction abstractionA = new RefinedAbstraction(implementationA);
            abstractionA.Operation(); // Вывод: RefinedAbstraction: Operation. ConcreteImplementationA: Operation Implementation.

            // Используем реализацию B
            IImplementation implementationB = new ConcreteImplementationB();
            Abstraction abstractionB = new RefinedAbstraction(implementationB);
            abstractionB.Operation(); // Вывод: RefinedAbstraction: Operation. ConcreteImplementationB: Operation Implementation.
        }
    }
}
