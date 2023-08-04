using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ErrorOr;
using Newtonsoft.Json;
using OneOf;

namespace StudentManagement
{
    public class StudentManag
    {
        public static StudentList<Student> studentsList = new StudentList<Student>();
        public void AddStudent(Student student)
        {
            studentsList.AddStudent(student);
        }

        public void RemoveStudent(Student student)
        {
            studentsList.RemoveStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            studentsList.UpdateStudent(student);
        }

        public OneOf<List<Student>, Exception> GetAllStudent()
        {
            try
            {
                return studentsList.GetAllStudent();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public void PrintAllStudent()
        {
            foreach (var student in studentsList)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, RollNumber: {student.RollNumber}, Grade: {student.Grade}");
            }
        }

        public void PrintStudent(Student student)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, RollNumber: {student.RollNumber}, Grade: {student.Grade}");
        }

        //get student with id 
        public OneOf<Student, Exception> GetStudentById(Guid id)
        {
            try
            {
                return studentsList.GetStudentById(id);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        // Get student with name 
        public OneOf<Student, Exception> GetStudentByName(string name)
        {
            try
            {
                return studentsList.GetStudentByName(name);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public OneOf<string, Exception> SaveToJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(studentsList, Formatting.Indented);
                File.WriteAllText("student.json", json);
                return "Saved to json file";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
        public OneOf<StudentList<Student>, Exception> LoadFromJson()
        {
            try
            {
                string jsonString = File.ReadAllText("student.json");
             
                StudentList<Student>? deserializedFile = JsonConvert.DeserializeObject<StudentList<Student>>(jsonString);
                
                foreach (var student in deserializedFile)
                {
                    studentsList.AddStudent(student);
                }

                return deserializedFile;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}