using System;
using System.IO;

namespace FileHandlingApp.Handlers
{
    public class TextFileHandler
    {
        // Запись текста в файл с использованием StreamWriter
        public string WriteText(string path, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(content);
                }
                return "Text successfully written to file.";
            }
            catch (Exception ex)
            {
                return $"Error writing text to file: {ex.Message}";
            }
        }

        // Чтение текста из файла с использованием StreamReader
        public string ReadText(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return "File does not exist.";
                }
            }
            catch (Exception ex)
            {
                return $"Error reading text from file: {ex.Message}";
            }
        }
    }
}
