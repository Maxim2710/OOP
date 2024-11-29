using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс команды
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }

    // Конкретная команда
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Unexecute()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Unexecute()
        {
            _light.TurnOn();
        }
    }

    // Получатель
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is OFF.");
        }
    }

    // Отправитель
    public class RemoteControl
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void PressButton(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void PressUndo()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                command.Unexecute();
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }
    }

    // Клиент
    public class Client2
    {
        public static void ExecuteCommandPattern()
        {
            Light livingRoomLight = new Light();
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            RemoteControl remoteControl = new RemoteControl();

            // Включаем свет
            remoteControl.PressButton(lightOn);

            // Выключаем свет
            remoteControl.PressButton(lightOff);

            // Отменяем последнюю операцию (включаем свет обратно)
            remoteControl.PressUndo();

            // Отменяем ещё одну операцию (выключаем свет снова)
            remoteControl.PressUndo();
        }
    }
}
