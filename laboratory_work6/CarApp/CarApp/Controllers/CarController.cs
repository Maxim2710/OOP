using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using CarSimulationApp.Models;
using System.Windows;
using System.Windows.Media.Animation;

namespace CarSimulationApp.Controllers
{
    public class CarController
    {
        private List<Car> _cars;
        private List<Task> _carTasks;
        private Canvas _canvas;
        private Barrier _barrier;
        private SemaphoreSlim _semaphore; // Семафор для ограничения доступа
        private bool _isRunning = true;
        private Random _random;
        private object _lock = new object(); // Для lock
        private object _monitorLock = new object(); // Для Monitor
        private Mutex _mutex = new Mutex(); 

        public CarController(Canvas canvas)
        {
            _cars = new List<Car>();
            _canvas = canvas;
            _carTasks = new List<Task>();
            _barrier = new Barrier(5); // 5 машин
            _semaphore = new SemaphoreSlim(1, 1); // Инициализируем семафор
            _random = new Random();

            InitializeCars();
        }

        private void InitializeCars()
        {
            _mutex.WaitOne(); // Захватываем мьютекс

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    int startX = 20;
                    int startY = 70 + i * 50;

                    Brush carColor = new SolidColorBrush(Color.FromRgb(
                        (byte)_random.Next(256),
                        (byte)_random.Next(256),
                        (byte)_random.Next(256)
                    ));

                    _cars.Add(new Car(startX, startY, carColor));
                }
            }
            finally
            {
                _mutex.ReleaseMutex(); // Освобождаем мьютекс
            }
        }

        public void StartSimulation()
        {
            _isRunning = true;

            foreach (var car in _cars)
            {
                // Создаем поток для каждой машины с установкой приоритета
                Thread carThread = new Thread(() => CarMovement());
                carThread.Priority = ThreadPriority.AboveNormal; // Устанавливаем приоритет выше нормального
                carThread.Start();

                // Добавляем поток в список для последующего управления
                _carTasks.Add(Task.Run(() => carThread.Join()));
            }

            // Запускаем мониторинг потоков
            Task.Run(() => MonitorTasks());
        }

        private async Task CarMovement()
        {
            while (_isRunning)
            {
                Parallel.For(0, _cars.Count, i =>
                {
                    var car = _cars[i];
                    lock (_lock) // Используем lock для синхронизации доступа к машине
                    {
                        car.SetRandomSpeed(_random.Next(1, 7));
                        car.Move();
                    }
                });

                Application.Current.Dispatcher.Invoke(() =>
                {
                    DrawCars();
                    ((MainWindow)Application.Current.MainWindow).UpdateCarInfo();
                });

                _barrier.SignalAndWait(); // Ждем, пока все потоки закончат свою работу
                await Task.Delay(50); // Асинхронная задержка
            }
        }

        private void DrawCars()
        {
            _canvas.Children.Clear();

            // Трасса
            Rectangle track = new Rectangle
            {
                Width = 600,
                Height = 300,
                Fill = Brushes.LightGray,
                Stroke = Brushes.Black,
                StrokeThickness = 3
            };
            Canvas.SetLeft(track, 20);
            Canvas.SetTop(track, 50);
            _canvas.Children.Add(track);

            foreach (var car in _cars)
            {
                // Создаем тело машины с индивидуальным цветом
                Rectangle carBody = new Rectangle
                {
                    Width = 60, // Длина машины
                    Height = 25, // Высота машины
                    Fill = car.Color, // Цвет машины
                    RadiusX = 5, // Скругленные углы для более мягкого внешнего вида
                    RadiusY = 5
                };

                // Создаем переднее окно
                Rectangle frontWindow = new Rectangle
                {
                    Width = 15,
                    Height = 10,
                    Fill = Brushes.LightBlue // Цвет окон
                };

                // Создаем заднее окно
                Rectangle rearWindow = new Rectangle
                {
                    Width = 15,
                    Height = 10,
                    Fill = Brushes.LightBlue
                };

                // Создаем два колеса
                Ellipse frontWheel = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Black
                };

                Ellipse rearWheel = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Black
                };

                // Добавляем вращение для колес
                RotateTransform frontWheelRotation = new RotateTransform();
                frontWheel.RenderTransform = frontWheelRotation;
                frontWheel.RenderTransformOrigin = new Point(0.5, 0.5);

                RotateTransform rearWheelRotation = new RotateTransform();
                rearWheel.RenderTransform = rearWheelRotation;
                rearWheel.RenderTransformOrigin = new Point(0.5, 0.5);

                // Анимация для вращения колес
                DoubleAnimation rotateAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 360,
                    Duration = new Duration(TimeSpan.FromMilliseconds(500)),
                    RepeatBehavior = RepeatBehavior.Forever // Бесконечное вращение
                };

                // Запуск анимации для переднего колеса
                frontWheelRotation.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

                // Запуск анимации для заднего колеса
                rearWheelRotation.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

                // Устанавливаем позиции для машины и её элементов
                Canvas.SetLeft(carBody, car.X);
                Canvas.SetTop(carBody, car.Y);

                // Позиции окон
                Canvas.SetLeft(frontWindow, car.X + 10); // Переднее окно ближе к переду машины
                Canvas.SetTop(frontWindow, car.Y + 5);

                Canvas.SetLeft(rearWindow, car.X + 35); // Заднее окно ближе к задней части машины
                Canvas.SetTop(rearWindow, car.Y + 5);

                // Позиции колес
                Canvas.SetLeft(frontWheel, car.X + 5); // Переднее колесо
                Canvas.SetTop(frontWheel, car.Y + 20); // Колесо ниже корпуса

                Canvas.SetLeft(rearWheel, car.X + 45); // Заднее колесо
                Canvas.SetTop(rearWheel, car.Y + 20); // Колесо ниже корпуса

                // Добавляем элементы на холст
                _canvas.Children.Add(carBody);
                _canvas.Children.Add(frontWindow);
                _canvas.Children.Add(rearWindow);
                _canvas.Children.Add(frontWheel);
                _canvas.Children.Add(rearWheel);
            }
        }

        private void DrawCarWindows(Car car, Rectangle carBody)
        {
            Rectangle frontWindow = new Rectangle
            {
                Width = 15,
                Height = 10,
                Fill = Brushes.LightBlue
            };

            Rectangle rearWindow = new Rectangle
            {
                Width = 15,
                Height = 10,
                Fill = Brushes.LightBlue
            };

            // Устанавливаем позиции для окон
            Canvas.SetLeft(frontWindow, car.X + 10);
            Canvas.SetTop(frontWindow, car.Y + 5);
            Canvas.SetLeft(rearWindow, car.X + 35);
            Canvas.SetTop(rearWindow, car.Y + 5);

            // Добавляем окна на холст
            _canvas.Children.Add(frontWindow);
            _canvas.Children.Add(rearWindow);
        }

        private void DrawCarWheels(Car car, Rectangle carBody)
        {
            Ellipse frontWheel = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Black
            };

            Ellipse rearWheel = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Black
            };

            // Устанавливаем позиции для колес
            Canvas.SetLeft(frontWheel, car.X + 5);
            Canvas.SetTop(frontWheel, car.Y + 20);
            Canvas.SetLeft(rearWheel, car.X + 45);
            Canvas.SetTop(rearWheel, car.Y + 20);

            // Добавляем колеса на холст
            _canvas.Children.Add(frontWheel);
            _canvas.Children.Add(rearWheel);
        }

        public void StopSimulation()
        {
            _isRunning = false;
            foreach (var carTask in _carTasks)
            {
                carTask.Wait(); 
            }
        }


        public void ResetRace()
        {
            foreach (var car in _cars)
            {
                car.ResetPosition();
            }

            DrawCars();
        }

        private void MonitorTasks()
        {
        while (_isRunning)
        {
            foreach (var car in _cars)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_monitorLock, ref lockTaken); // Используем Monitor
                    if (car.X > 550)
                    {
                        car.ResetPosition();
                    }
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_monitorLock); // Освобождаем блокировку
                    }
                }
            }
            Thread.Sleep(100); // Проверяем состояние каждые 100 мс
        }
    }

        public List<Car> GetCars()
        {
            return _cars; // Возвращает текущий список машин
        }
    }
}
