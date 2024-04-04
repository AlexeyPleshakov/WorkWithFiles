using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFiles
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Укажите путь к папке");
            string pathFolder = Console.ReadLine();
            ClearFolder(pathFolder);
            Console.WriteLine("Cleaning finished");
            Console.ReadLine();
        }
        static void ClearFolder(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    var dirTime = dir.LastWriteTime;
                    TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                    DateTime dateTime = DateTime.Now - timeSpan;
                    foreach (var files in dir.GetFiles())
                    {
                        if (dateTime > dirTime)
                        {
                            files.Delete();
                            Console.WriteLine($"Deleted file: {files.FullName}");
                        }
                    }
                    foreach (var subdirectory in dir.GetDirectories())
                    {
                        ClearFolder(subdirectory.FullName);
                        if (subdirectory.GetFiles().Length == 0)
                        {
                            if (dateTime > dirTime)
                            {
                                subdirectory.Delete(true);
                                Console.WriteLine($"Delete folder: {subdirectory.FullName}");
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Директория не найдена.Ошибка: " + ex.Message);
                }
            }
        }
    }
}
