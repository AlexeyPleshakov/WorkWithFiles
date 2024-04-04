using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Укажите путь к директории");
            string path = Console.ReadLine();
            Method(path);
        }
        static void Method(string path)
        {
            if(Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                var start = GetDiskSize(directory);
                Console.WriteLine($"Исходный размер папки: {start} байт");
                DeleteDir(path);
                var end = GetDiskSize(directory);
                Console.WriteLine($"Освобождено {start - end} байт");
                Console.WriteLine($"Текущий размер папки: {end} ");
            }
        }

        private static void DeleteDir(string path)
        {
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                try
                {
                    Directory.Delete(dir, true);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            var files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        private static long GetDiskSize(DirectoryInfo directory)
        {
            long size = 0;
            try
            {
                FileInfo[] arr = directory.GetFiles();
                foreach(FileInfo fi in arr)
                {
                    size += fi.Length;
                }
                DirectoryInfo[] darr = directory.GetDirectories();
                foreach(DirectoryInfo d in darr)
                {
                    size += GetDiskSize(d);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return size;
        }
    }
}
