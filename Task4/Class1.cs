using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Student
    {
        public string Name { get; }
        public string Group { get; }
        public DateTime DateOfBirth { get; }
        public decimal AverageScore { get; }

        public Student(string name, string group, DateTime dateofbirth, decimal averageScore)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
            AverageScore = averageScore;
        }
    }
}
