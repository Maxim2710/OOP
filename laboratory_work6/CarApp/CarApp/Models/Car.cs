using System.Windows.Media;

namespace CarSimulationApp.Models
{
    public class Car
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Speed { get; private set; }
        public Brush Color { get; private set; } // Добавляем свойство для цвета машины

        public Car(int x, int y, Brush color)
        {
            X = x;
            Y = y;
            Speed = 0; // Изначально скорость 0
            Color = color; // Присваиваем цвет машине
        }

        public void SetRandomSpeed(int speed)
        {
            Speed = speed; // Установка случайной скорости
        }

        public void Move()
        {
            X += Speed; // Движение вправо
            if (X > 1500)
            {
                X = 0; // Сброс на начало
            }
        }

        public void ResetPosition()
        {
            X = 0; // Сбрасываем позицию на 0
        }
    }
}
