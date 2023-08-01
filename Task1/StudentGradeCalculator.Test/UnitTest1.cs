using Xunit;
using GradeCalculator;
using System;

namespace GradeCalculator.Tests
{
    public class SubjectTests
    {
        [Fact]
        public void Subject_Should_Set_SubjectName_And_SubjectGrade_Correctly()
        {
            // Arrange
            string subjectName = "Math";
            float subjectGrade = 85;

            // Act
            var subject = new Subject(subjectName, subjectGrade);

            // Assert
            Assert.Equal(subjectName, subject.SubjectName);
            Assert.Equal(subjectGrade, subject.SubjectGrade);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Subject_Should_Throw_Exception_If_SubjectGrade_Outside_Range(float grade)
        {
            // Arrange
            string subjectName = "Science";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Subject(subjectName, grade));
        }

        [Fact]
        public void GetAverageGrade_Should_Calculate_Correct_Average_Grade()
        {
            // Arrange
            var subjects = new List<Subject>
            {
                new Subject("Math", 85),
                new Subject("Science", 90),
                new Subject("History", 78),
                new Subject("English", 92)
            };
            var student = new Student("John", "Doe", subjects);

            // Act
            float averageGrade = student.GetAverageGrade();

            // Assert
            Assert.Equal(86.25, averageGrade);
        }
    }
}
