using StressTest;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StressTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Массив для хранения результатов тестов (4 таска)
        private TestCaseResult[] results = new TestCaseResult[10];

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранных значений
            Material selectedMaterial = (Material)materialsList.SelectedIndex;
            CrossSection selectedCrossSection = (CrossSection)crossSectionsList.SelectedIndex;
            TestResult selectedTestResult = (TestResult)testResultsList.SelectedIndex;

            // Формирование строки результата
            StringBuilder selectionStringBuilder = new StringBuilder();

            // Материал
            switch (selectedMaterial)
            {
                case Material.StainlessSteel:
                    selectionStringBuilder.Append("Material: Stainless Steel, ");
                    break;
                case Material.Aluminium:
                    selectionStringBuilder.Append("Material: Aluminium, ");
                    break;
                case Material.ReinforcedConcrete:
                    selectionStringBuilder.Append("Material: Reinforced Concrete, ");
                    break;
                case Material.Composite:
                    selectionStringBuilder.Append("Material: Composite, ");
                    break;
                case Material.Titanium:
                    selectionStringBuilder.Append("Material: Titanium, ");
                    break;
            }

            // Сечение
            switch (selectedCrossSection)
            {
                case CrossSection.IBeam:
                    selectionStringBuilder.Append("Cross-section: I-Beam, ");
                    break;
                case CrossSection.Box:
                    selectionStringBuilder.Append("Cross-section: Box, ");
                    break;
                case CrossSection.ZShaped:
                    selectionStringBuilder.Append("Cross-section: Z-Shaped, ");
                    break;
                case CrossSection.CShaped:
                    selectionStringBuilder.Append("Cross-section: C-Shaped, ");
                    break;
            }

            // Результат теста
            switch (selectedTestResult)
            {
                case TestResult.Pass:
                    selectionStringBuilder.Append("Result: Pass.");
                    break;
                case TestResult.Fail:
                    selectionStringBuilder.Append("Result: Fail.");
                    break;
            }

            // Обновление метки с результатом
            testDetails.Content = selectionStringBuilder.ToString();
        }

        //2 часть (4 таска)

        // Метод для заполнения массива данными
        private void RunTests_Click(object sender, RoutedEventArgs e)
        {
            // Очистка списка причин отказа
            reasonsList.Items.Clear();

            // Инициализация массива результатов тестов
            for (int i = 0; i < results.Length; i++)
            {
                // Генерация результата теста с использованием метода GenerateResult (будем его реализовывать позже)
                results[i] = TestManager.GenerateResult();
            }

            // Подсчет успешных и неуспешных тестов и вывод данных
            int passCount = 0;
            int failCount = 0;

            foreach (var result in results)
            {
                if (result.Result == TestResult.Pass)
                {
                    passCount++;
                }
                else
                {
                    failCount++;
                    reasonsList.Items.Add(result.ReasonForFailure); // Добавляем причину отказа в список
                }
            }

            // Вывод количества успешных и проваленных тестов
            passCountLabel.Content = $"Successes: {passCount}";
            failCountLabel.Content = $"Failures: {failCount}";
        }
    }
}
