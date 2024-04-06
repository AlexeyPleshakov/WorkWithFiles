using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Укажите путь к бинарному файлу");
            string path = Console.ReadLine();
            if(File.Exists(path))
            {
                List<Student> students = ReadStudentsFromBinFile(path);
                foreach(Student student in students)
                {
                    Console.WriteLine(/*...*/);
                }
            }
        }

        static List<Student> ReadStudentsFromBinFile(string fileName)
        {
            List<Student> students = new List<Student>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using ( var fs = new FileStream(fileName, FileMode.Open))
            {
                // Как вытащить список объектов из файла и добавить в students??
                var obj = binaryFormatter.Deserialize(fs);
                
            }
            return students;
        }
    }
}
