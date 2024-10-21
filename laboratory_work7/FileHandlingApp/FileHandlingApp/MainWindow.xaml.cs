using FileHandlingApp.Managers;
using FileHandlingApp.Handlers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FileHandlingApp
{
    public partial class MainWindow : Window
    {
        private FileManager fileManager;
        private TextFileHandler textFileHandler;
        private BinaryFileHandler binaryFileHandler;

        public MainWindow()
        {
            InitializeComponent();
            fileManager = new FileManager();
            textFileHandler = new TextFileHandler();
            binaryFileHandler = new BinaryFileHandler();
        }

        private void CreateFile_Click(object sender, RoutedEventArgs e)
        {
            string result = fileManager.CreateFile(FilePath.Text);
            Result.Text = result;
        }

        private void FilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            // FilePathPlaceholder.Visibility = string.IsNullOrEmpty(FilePath.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void FileContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            // FileContentPlaceholder.Visibility = string.IsNullOrEmpty(FileContent.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void GetFileInfo_Click(object sender, RoutedEventArgs e)
        {
            string result = fileManager.GetFileInfo(FilePath.Text);
            Result.Text = result;
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            string result = fileManager.DeleteFile(FilePath.Text);
            Result.Text = result;
        }

        private void WriteText_Click(object sender, RoutedEventArgs e)
        {
            string content = FileContent.Text;
            string result = textFileHandler.WriteText(FilePath.Text, content);
            Result.Text = result;
        }

        private void ReadText_Click(object sender, RoutedEventArgs e)
        {
            string result = textFileHandler.ReadText(FilePath.Text);
            Result.Text = result;
        }

        private void WriteBinary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка на то, пусто ли поле для числа
                int number = 0; // Значение по умолчанию для числа
                bool isNumberEntered = !string.IsNullOrEmpty(BinaryNumber.Text);

                if (isNumberEntered)
                {
                    number = int.Parse(BinaryNumber.Text); // Парсим число, если оно введено
                }

                string text = string.IsNullOrEmpty(BinaryText.Text) ? string.Empty : BinaryText.Text; // Если текст не введен, оставляем пустую строку

                // Передаем введенные данные в обработчик
                string result = binaryFileHandler.WriteBinary(FilePath.Text, number, text);
                Result.Text = result;
            }
            catch (FormatException)
            {
                Result.Text = "Invalid number format. Please enter a valid integer.";
            }
        }


        private void ReadBinary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (int number, string text) = binaryFileHandler.ReadBinary(FilePath.Text);
                Result.Text = $"Number: {number}, Text: {text}";
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }
    }
}
