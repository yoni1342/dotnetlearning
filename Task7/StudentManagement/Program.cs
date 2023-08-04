namespace StudentManagement;
using OneOf;
// using System;
using System.Text.Json.Serialization;
public class Program
{
    public static void Main(string[] args)
    {
        StudentManag studentManag = new StudentManag();

        try
        {
            studentManag.LoadFromJson();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to Student Management System");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Remove student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Get student by id");
            Console.WriteLine("5. Get student by name");
            Console.WriteLine("6. Get all student");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {

                case 1:
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Enter student name: ");
                    string name = Console.ReadLine()!;
                    Console.WriteLine("Enter student age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter student roll number: ");
                    int rollNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter student grade: ");
                    int grade = Convert.ToInt32(Console.ReadLine());
                    Student student = new Student(name, age, rollNumber, grade);
                    studentManag.AddStudent(student);
                    Console.WriteLine("Add student successfully");
                    Console.WriteLine("+---------------------------+");
                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Enter student id: ");

                    string input = Console.ReadLine();

                    if (Guid.TryParse(input, out Guid id))
                    {
                        Console.WriteLine("Valid id");
                    }
                    else
                    {
                        Console.WriteLine("+---------------------------+");
                        Console.WriteLine("Invalid id");
                        Console.WriteLine("+---------------------------+");
                        Console.ReadLine();
                        continue;
                    }

                    var res = studentManag.GetStudentById(id);
                    if (res.IsT0)
                    {
                        studentManag.RemoveStudent(res.AsT0);
                        Console.WriteLine("Remove student successfully");
                    }
                    else
                    {
                        Console.WriteLine(res.AsT1.Message);
                    }
                    Console.WriteLine("+---------------------------+");
                    Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Enter student id: ");

                    string input1 = Console.ReadLine();

                    if (Guid.TryParse(input1, out Guid id1))
                    {
                        Console.WriteLine("Valid id");
                    }
                    else
                    {
                        Console.WriteLine("+---------------------------+");
                        Console.WriteLine("Invalid id");
                        Console.WriteLine("+---------------------------+");
                        Console.ReadLine();
                        continue;
                    }

                    var res1 = studentManag.GetStudentById(id1);
                    if (res1.IsT0)
                    {
                        Console.WriteLine("Enter student name: ");
                        string name1 = Console.ReadLine()!;
                        Console.WriteLine("Enter student age: ");
                        int age1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student roll number: ");
                        int rollNumber1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student grade: ");
                        int grade1 = Convert.ToInt32(Console.ReadLine());
                        Student student1 = new Student(name1, age1, rollNumber1, grade1);
                        student1.GId(id1);
                        studentManag.UpdateStudent(student1);
                        Console.WriteLine("Update student successfully");
                    }
                    else
                    {
                        Console.WriteLine(res1.AsT1.Message);
                    }
                    break;

                case 4:
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Enter student id: ");
                    string input2 = Console.ReadLine();

                    if (Guid.TryParse(input2, out Guid id2))
                    {
                        Console.WriteLine("Valid id");
                    }
                    else
                    {
                        Console.WriteLine("+---------------------------+");
                        Console.WriteLine("Invalid id");
                        Console.WriteLine("+---------------------------+");
                        Console.ReadLine();
                        continue;
                    }

                    var res2 = studentManag.GetStudentById(id2);
                    if (res2.IsT0)
                    {


                        Console.WriteLine(res2.AsT0.ToString());


                    }
                    else
                    {
                        Console.WriteLine(res2.AsT1.Message);
                    }
                    Console.WriteLine("+---------------------------+");
                    Console.ReadLine();
                    break;

                case 5:
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Enter student name: ");
                    string name2 = Console.ReadLine()!;
                    var res3 = studentManag.GetStudentByName(name2);
                    if (res3.IsT0)
                    {
                        Console.WriteLine(res3.AsT0.ToString());
                    }
                    else
                    {
                        Console.WriteLine(res3.AsT1.Message);
                    }
                    Console.WriteLine("+---------------------------+");
                    Console.ReadLine();
                    break;

                case 6:
                    Console.WriteLine("+---------------------------+");
                    var res4 = studentManag.GetAllStudent();
                    if (res4.IsT0)
                    {
                        Console.WriteLine("+---------------------------+");
                        foreach (var item in res4.AsT0)
                        {
                            Console.WriteLine(item.ToString());
                            Console.WriteLine("+---------------------------+");
                        }
                    }
                    else
                    {
                        Console.WriteLine(res4.AsT1.Message);
                        Console.WriteLine("+---------------------------+");
                    }
                    Console.ReadLine();
                    break;

                case 7:
                    Console.WriteLine("+---------------------------+");
                    var res5 = studentManag.SaveToJson();
                    if (res5.IsT0)
                    {
                        Console.WriteLine("Save to json successfully");
                    }
                    else
                    {
                        Console.WriteLine(res5.AsT1.Message);
                    }
                    Console.WriteLine("+---------------------------+");
                    Console.WriteLine("Thanks for using our system");

                    running = false;
                    break;
            }
        }
    }
}