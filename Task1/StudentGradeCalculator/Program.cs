namespace GradeCalculator;

public class Program
{
    static void Main(string[] args)
    {
        try
        {

            Console.WriteLine("Welcome to the Grade Calculator!");
            Console.WriteLine("Please enter your first name:");
            var firstName = Console.ReadLine()!;
            Console.WriteLine("Please enter your last name:");
            var lastName = Console.ReadLine()!;
            var subjects = new List<Subject>();

            Console.WriteLine("Please enter how many subjects you take:");
            var numberOfSubjects = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < numberOfSubjects; i++)
            {
                Console.WriteLine("Please enter the name of the subject:");
                var subjectName = Console.ReadLine()!;
                Console.WriteLine("Please enter the grade that you get in " + subjectName + " subject:");
                var subjectGrade = float.Parse(Console.ReadLine()!);
                subjects.Add(new Subject(subjectName, subjectGrade));
            }

            var student = new Student(firstName, lastName, subjects);
            Console.WriteLine(student.ToString());
        }catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        { 
            Console.WriteLine("Thank you for using the Grade Calculator!");
        }
    }
}