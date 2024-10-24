using System;

namespace ExampleAppForDesignPatterns.GeneratingPatterns
{
    // Продукт — абстрактный класс для отчетов
    public abstract class Report
    {
        public abstract void Generate();
    }

    // Конкретные продукты — отчет в формате PDF
    public class PDFReport : Report
    {
        public override void Generate() => Console.WriteLine("Generating PDF Report");
    }

    // Конкретные продукты — отчет в формате HTML
    public class HTMLReport : Report
    {
        public override void Generate() => Console.WriteLine("Generating HTML Report");
    }

    // Абстрактный класс создателя отчетов
    public abstract class ReportGenerator
    {
        // Фабричный метод
        public abstract Report CreateReport();

        public void GenerateReport()
        {
            // Получаем отчет через фабричный метод
            Report report = CreateReport();
            report.Generate();
        }
    }

    // Конкретный создатель для PDF отчетов
    public class PDFReportGenerator : ReportGenerator
    {
        public override Report CreateReport() => new PDFReport();
    }

    // Конкретный создатель для HTML отчетов
    public class HTMLReportGenerator : ReportGenerator
    {
        public override Report CreateReport() => new HTMLReport();
    }
}
