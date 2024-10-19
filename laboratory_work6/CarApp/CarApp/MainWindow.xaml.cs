using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CarSimulationApp.Controllers;

namespace CarSimulationApp
{
    public partial class MainWindow : Window
    {
        private CarController carController;

        public MainWindow()
        {
            InitializeComponent();
            carController = new CarController(CarCanvas);
        }

        private void StartSimulation_Click(object sender, RoutedEventArgs e)
        {
            carController.StartSimulation();
            UpdateCarInfo(); // Обновление информации о машинах при старте симуляции
        }

        private void StopSimulation_Click(object sender, RoutedEventArgs e)
        {
            carController.StopSimulation();
        }

        private void ResetRace_Click(object sender, RoutedEventArgs e)
        {
            carController.ResetRace(); // Вызываем сброс гонки
            UpdateCarInfo(); 

        }

        public void UpdateCarInfo()
        {
            CarInfoPanel.Children.Clear(); // Очищаем панель информации о машинах

            var cars = carController.GetCars(); // Получаем список машин

            foreach (var car in cars)
            {
                // Создаем панель для информации о машине
                StackPanel carPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

                // Создаем цветовой индикатор машины
                Rectangle carColorIndicator = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                    Fill = car.Color, // Цвет машины
                    Margin = new Thickness(0, 0, 10, 0)
                };

                // Создаем текстовое описание (позиция машины)
                TextBlock carInfoText = new TextBlock
                {
                    Text = $"Car Position: {car.X:0.00} m",
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Добавляем цветовой индикатор и текст в панель
                carPanel.Children.Add(carColorIndicator);
                carPanel.Children.Add(carInfoText);

                // Добавляем панель информации о машине в общий список
                CarInfoPanel.Children.Add(carPanel);
            }
        }

    }
}
