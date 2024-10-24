using System;

namespace ExampleAppForDesignPatterns.GeneratingPatterns;


// Продукт — интерфейс для документов
public interface IDocument
{
    IDocument Clone(); // Метод для клонирования
    void Print();
}

// Конкретный продукт — документ типа Word
public class WordDocument : IDocument
{
    public string Content { get; set; }

    public WordDocument(string content)
    {
        Content = content;
    }

    public IDocument Clone()
    {
        return new WordDocument(Content); // Клонирование через конструктор
    }

    public void Print() => Console.WriteLine($"Printing Word Document: {Content}");
}

// Конкретный продукт — документ типа Excel
public class ExcelDocument : IDocument
{
    public string Content { get; set; }

    public ExcelDocument(string content)
    {
        Content = content;
    }

    public IDocument Clone()
    {
        return new ExcelDocument(Content); // Клонирование через конструктор
    }

    public void Print() => Console.WriteLine($"Printing Excel Document: {Content}");
}