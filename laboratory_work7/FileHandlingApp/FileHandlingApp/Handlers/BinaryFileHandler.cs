using System;
using System.IO;

namespace FileHandlingApp.Handlers
{
    public class BinaryFileHandler
    {
        // Запись бинарных данных с использованием BinaryWriter
        public string WriteBinary(string path, int number, string text)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    writer.Write(number);
                    writer.Write(text);
                }
                return "Binary data successfully written to file.";
            }
            catch (Exception ex)
            {
                return $"Error writing binary data to file: {ex.Message}";
            }
        }

        // Чтение бинарных данных с использованием BinaryReader
        public (int number, string text) ReadBinary(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
                    {
                        int number = reader.ReadInt32();
                        string text = reader.ReadString();
                        return (number, text);
                    }
                }
                else
                {
                    throw new FileNotFoundException("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading binary data from file: {ex.Message}");
            }
        }
    }
}
