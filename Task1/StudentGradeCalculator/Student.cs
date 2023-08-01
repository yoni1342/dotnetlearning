using System.Globalization;

namespace GradeCalculator;

public class Student
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public List<Subject> Subjects { get; set; }

    public Student(string firstName, string lastName, List<Subject> subjects)
    {
        FirstName = firstName;
        LastName = lastName;
        Subjects = subjects;
    }

    public float GetAverageGrade()
    {
        float sum = 0;
        foreach (var subject in Subjects)
        {
            sum += subject.SubjectGrade;
        }

        return sum / Subjects.Count;
    }

    public override string ToString()
    {
        var subjectsString = "";
        foreach (var subject in Subjects)
        {
            subjectsString += subject.SubjectName + "\t\t||" + subject.SubjectGrade.ToString(CultureInfo.InvariantCulture) + "\n";
        }

        return $"{nameof(FirstName)}: {FirstName} \n {nameof(LastName)}: {LastName} \n" +
        "-----------------------------------------\n" +
              $"Total Subjects: {Subjects.Count} \n"
                + subjectsString + "\n" +
                $"Average Grade: {GetAverageGrade():F2}";
    }
}