using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string  Name { get; set; }
        public int Age { get; set; }
        public readonly int RollNumber; 
        public int Grade { get; set; }

        public void GId(Guid id)
        {
            Id = id;
        }
        public Student(string name, int age, int rollNumber, int grade)
        {
            Name = name;
            Age = age;
            RollNumber = rollNumber;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"Id: {Id}, \nName: {Name}, \nAge: {Age}, \nRollNumber: {RollNumber}, \nGrade: {Grade}";
        }
    }
}