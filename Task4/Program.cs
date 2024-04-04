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
            List<Student> students = ReadStudentsFromBinFile("students.dat");
            foreach(Student student in students)
            {
                Console.WriteLine(/*...*/);
            }
        }

        static List<Student> ReadStudentsFromBinFilen(string fileName)
        {
            List<Student> students = new List<Student>();
            using FileStream fs = new FileStream(fileName,FileMode.Open);
            using StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
            fs.Position = 0;
            BinaryReader binaryReader = new BinaryReader(fs);
            while (fs.Position < fs.Length)
            {
                
            }
        }
    }
}
