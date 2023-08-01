using Palindrom;
using Xunit;

namespace Palindrom.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void IsPalindrome_Should_Return_True_For_Palindrome_Input()
        {
            // Arrange
            string input = "level";

            // Act
            bool result = Program.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_Should_Return_True_For_Empty_Input()
        {
            // Arrange
            string input = "";

            // Act
            bool result = Program.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_Should_Return_True_For_Single_Character_Input()
        {
            // Arrange
            string input = "a";

            // Act
            bool result = Program.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_Should_Return_False_For_Non_Palindrome_Input()
        {
            // Arrange
            string input = "hello";

            // Act
            bool result = Program.IsPalindrome(input);

            // Assert
            Assert.False(result);
        }
    }
}
