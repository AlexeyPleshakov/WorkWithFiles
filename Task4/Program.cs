using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Укажите путь к бинарному файлу");
            string filePath = Console.ReadLine();
            List<Student> students = ReadStudentsFromBinFile(filePath);
            Directory.CreateDirectory("C:/Users/plesh/OneDrive/Студенты");
            
        }

        static List<Student> ReadStudentsFromBinFile(string filePath)
        {
            List<Student> students = new List<Student>();
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while(reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var student = new Student()
                    {
                        Name = reader.ReadString(),
                        Group = reader.ReadString(),
                        DateOfBirth = DateTime.FromBinary(reader.ReadInt64()),
                        AverageScore = reader.ReadDecimal()
                    };
                    students.Add(student);
                }
            }
            return students;
        }
    }
}
