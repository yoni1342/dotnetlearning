using Xunit;
using WordFrequencyCount;
using System.Collections.Generic;

namespace WordFrequencyCount.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void WordFrequencyCount_Should_Return_Correct_Frequencies()
        {
            // Arrange
            string word = "hello";
            Dictionary<string, int> expectedFrequencies = new Dictionary<string, int>
            {
                { "h", 1 },
                { "e", 1 },
                { "l", 2 },
                { "o", 1 }
            };

            // Act
            Dictionary<string, int> actualFrequencies = new Dictionary<string, int>();
            foreach (var ch in word)
            {
                if (actualFrequencies.ContainsKey(ch.ToString()))
                {
                    actualFrequencies[ch.ToString()]++;
                }
                else
                {
                    actualFrequencies.Add(ch.ToString(), 1);
                }
            }

            // Assert
            Assert.Equal(expectedFrequencies, actualFrequencies);
        }
    }
}
