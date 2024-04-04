using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            bool b = true;
            while(b)
            {
                Console.WriteLine("Укажите путь");
                string path = Console.ReadLine();
                if (new DirectoryInfo(path).Exists)
                {
                    Console.WriteLine($"Размер диска {GetDiskSize(path)} байт");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно указан путь");
                    b = false;
                }
            }
            Console.ReadLine();
        }

        private static long GetDiskSize(string path)
        {
            long size = 0;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] fiArr = dir.GetFiles();
                foreach(FileInfo fi in fiArr)
                {
                    size += fi.Length;
                }
                DirectoryInfo[] drs = dir.GetDirectories();
                foreach(DirectoryInfo d in drs)
                {
                    string pathdir = d.FullName;
                    size += GetDiskSize(pathdir);
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
