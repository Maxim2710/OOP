using System.Windows;
using System.Windows.Controls;

namespace Task1Hard1
{
    public partial class MainWindow : Window
    {
        private ConversionManager _conversionManager;

        public MainWindow()
        {
            InitializeComponent();
            _conversionManager = new ConversionManager();
            UpdateTypeLists();
        }

        private void UpdateTypeLists()
        {
            if (SourceType == null || TargetType == null)
            {
                return;
            }

            SourceType.Items.Clear();
            TargetType.Items.Clear();

            // Добавляем все уникальные типы в списки источников и целей
            foreach (var type in _conversionManager.GetAllTypes())
            {
                SourceType.Items.Add(new ComboBoxItem { Content = type });
                TargetType.Items.Add(new ComboBoxItem { Content = type });
            }

            // Устанавливаем выбранный элемент по умолчанию
            if (SourceType.Items.Count > 0) SourceType.SelectedIndex = 0;
            if (TargetType.Items.Count > 0) TargetType.SelectedIndex = 0;
        }

        private void ConversionTypeChanged(object sender, RoutedEventArgs e)
        {
            UpdateTypeLists();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputValue.Text;
            string sourceType = (SourceType.SelectedItem as ComboBoxItem)?.Content.ToString();
            string targetType = (TargetType.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(input) || sourceType == null || targetType == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                dynamic value = TypeConverter.ConvertToType(input, sourceType);
                dynamic result;

                if (ImplicitRadioButton.IsChecked == true)
                {
                    if (_conversionManager.CanImplicitlyConvert(sourceType, targetType))
                    {
                        result = value;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Неявное преобразование из {sourceType} в {targetType} не поддерживается.");
                    }
                }
                else
                {
                    if (_conversionManager.CanExplicitlyConvert(sourceType, targetType))
                    {
                        result = TypeConverter.ExplicitConversion(value, targetType);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Явное преобразование из {sourceType} в {targetType} не поддерживается.");
                    }
                }

                ResultValue.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка преобразования: {ex.Message}");
            }
        }
    }
}
