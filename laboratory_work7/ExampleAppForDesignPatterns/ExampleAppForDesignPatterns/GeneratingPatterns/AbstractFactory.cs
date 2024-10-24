using System;

namespace ExampleAppForDesignPatterns.GeneratingPatterns
{
    // Абстрактные продукты
    public interface IButton
    {
        void Click();
    }

    public interface IWindow
    {
        void Open();
    }

    // Конкретные продукты для Windows
    public class WindowsButton : IButton
    {
        public void Click() => Console.WriteLine("Windows Button clicked");
    }

    public class WindowsWindow : IWindow
    {
        public void Open() => Console.WriteLine("Windows Window opened");
    }

    // Конкретные продукты для MacOS
    public class MacButton : IButton
    {
        public void Click() => Console.WriteLine("Mac Button clicked");
    }

    public class MacWindow : IWindow
    {
        public void Open() => Console.WriteLine("Mac Window opened");
    }

    // Абстрактная фабрика
    public interface IGUIFactory
    {
        IButton CreateButton();
        IWindow CreateWindow();
    }

    // Конкретные фабрики
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public IWindow CreateWindow() => new WindowsWindow();
    }

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public IWindow CreateWindow() => new MacWindow();
    }

    // Клиентский код
    public class Client
    {
        private readonly IButton _button;
        private readonly IWindow _window;

        public Client(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _window = factory.CreateWindow();
        }

        public void Interact()
        {
            _button.Click();
            _window.Open();
        }
    }
}
