using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Класс хранителя состояния
    public class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Класс, состояние которого сохраняется
    public class Originator
    {
        public string State { get; set; }

        // Создание снимка состояния
        public Memento SaveStateToMemento()
        {
            return new Memento(State);
        }

        // Восстановление состояния из снимка
        public void RestoreStateFromMemento(Memento memento)
        {
            State = memento.State;
        }
    }

    // Класс, который управляет сохранением и восстановлением состояний
    public class Caretaker
    {
        private Memento _memento;

        // Сохранение состояния
        public void SaveMemento(Memento memento)
        {
            _memento = memento;
        }

        // Восстановление состояния
        public Memento GetMemento()
        {
            return _memento;
        }
    }

    // Пример использования паттерна Хранитель
    public class Client6
    {
        public static void ExecuteMementoPattern()
        {
            var originator = new Originator();
            var caretaker = new Caretaker();

            // Устанавливаем состояние объекта
            originator.State = "Состояние 1";
            Console.WriteLine("Текущее состояние: " + originator.State);

            // Сохраняем текущее состояние
            caretaker.SaveMemento(originator.SaveStateToMemento());

            // Изменяем состояние
            originator.State = "Состояние 2";
            Console.WriteLine("Текущее состояние: " + originator.State);

            // Восстанавливаем состояние из хранителя
            originator.RestoreStateFromMemento(caretaker.GetMemento());
            Console.WriteLine("Восстановленное состояние: " + originator.State);
        }
    }
}
