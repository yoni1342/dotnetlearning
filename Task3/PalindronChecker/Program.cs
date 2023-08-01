namespace Palindrom;

public class Program{

    public static bool IsPalindrome(string input)
    {
        int i = 0;
        int j = input.Length - 1;
        while (i < j)
        {
            if (input[i] != input[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string to check if it is a palindrome");
        string input = Console.ReadLine();
        if (IsPalindrome(input))
        {
            Console.WriteLine($"{input} is a palindrome");
        }
        else
        {
            Console.WriteLine($"{input} is not a palindrome");
        }
    }
}