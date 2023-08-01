namespace GradeCalculator;

public class Subject
{
    public string SubjectName { get; set; } = null!;
    private float subjectGrade;

    public float SubjectGrade
    {
        get => subjectGrade;

        set
        {
            if (value<0 || value>100)
            {
                throw new ArgumentException("Grade must be between 0 and 100");
            }
            subjectGrade = value;

        }
    }

    public Subject(string subjectName, float subjectGrade)
    {
        SubjectName = subjectName;
        SubjectGrade = subjectGrade;
    }

}