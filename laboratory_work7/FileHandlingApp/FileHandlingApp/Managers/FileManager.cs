using System;
using System.IO;

namespace FileHandlingApp.Managers
{
    public class FileManager
    {
        // Создание файла
        public string CreateFile(string path)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    // Можно добавить логику записи начального содержимого, если нужно
                }
                return "File successfully created.";
            }
            catch (Exception ex)
            {
                return $"Error creating file: {ex.Message}";
            }
        }

        // Получение информации о файле
        public string GetFileInfo(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    return $"File Name: {fileInfo.Name}\n" +
                           $"File Size: {fileInfo.Length} bytes\n" +
                           $"Creation Time: {fileInfo.CreationTime}\n" +
                           $"Last Modified: {fileInfo.LastWriteTime}";
                }
                else
                {
                    return "File does not exist.";
                }
            }
            catch (Exception ex)
            {
                return $"Error getting file info: {ex.Message}";
            }
        }

        // Удаление файла
        public string DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return "File successfully deleted.";
                }
                else
                {
                    return "File does not exist.";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting file: {ex.Message}";
            }
        }
    }
}
