using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class StudentList<T> : List<T> where T : Student
    {
        public void AddStudent(T student)
        {
            Add(student);
        }

        public void RemoveStudent(T student)
        {
            Remove(student);
        }

        public void UpdateStudent(T student)
        {
            var index = FindIndex(x => x.Id == student.Id);
            if (index != -1)
            {
                this[index] = student;
            }
        }

        public T GetStudentById(Guid id)
        {
            T res = this.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                throw new Exception("Student not found");
            }
            return res;
        }

        public T GetStudentByName(string name)
        {
            T res = this.FirstOrDefault(x => x.Name == name);
            if (res == null)
            {
                throw new Exception("Student not found");
            }
            return res;
        }
        public List<T> GetAllStudent()
        {
            if (this.Count == 0)
            {
                throw new Exception("Student list is empty");
            }
            return this;
        }   

    }
}