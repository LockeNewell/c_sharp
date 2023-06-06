using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the array of integers (comma-separated):");
        string input = Console.ReadLine();

        int[] nums = input.Split(',').Select(int.Parse).ToArray();

        var mostFrequent = nums
            .GroupBy(num => num)
            .OrderByDescending(group => group.Count())
            .FirstOrDefault();

        if (mostFrequent != null)
        {
            Console.WriteLine("The most frequently occurring element is " + mostFrequent.Key);
        }
        else
        {
            Console.WriteLine("No elements found in the array.");
        }
    }
}


/* using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the array of integers (comma-separated):");
        string input = Console.ReadLine();

        string[] numStrings = input.Split(',');
        int[] nums = new int[numStrings.Length];

        for (int i = 0; i < numStrings.Length; i++)
        {
            nums[i] = int.Parse(numStrings[i]);
        }

        int num1 = 0;
        int num2 = 0;
        int minSum = int.MaxValue;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                int sum = nums[i] + nums[j];
                int absoluteSum = Math.Abs(sum);

                if (absoluteSum < minSum)
                {
                    minSum = absoluteSum;
                    num1 = nums[i];
                    num2 = nums[j];
                }
            }
        }

        Console.WriteLine("The two numbers whose sum is closest to zero are " + num1 + " and " + num2);
    }
}

 */

/* using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');
        Array.Reverse(words);

        string reversedSentence = string.Join(" ", words);

        Console.WriteLine("Reversed sentence: " + reversedSentence);
    }
} */


/* using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the array of integers (comma-separated):");
        string input = Console.ReadLine();

        string[] numStrings = input.Split(',');
        int[] nums = new int[numStrings.Length];

        for (int i = 0; i < numStrings.Length; i++)
        {
            nums[i] = int.Parse(numStrings[i]);
        }

        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;

        foreach (int num in nums)
        {
            if (num < min)
                min = num;
            if (num > max)
                max = num;
            sum += num;
        }

        int expectedSum = (max - min + 1) * (min + max) / 2;
        int missingNumber = expectedSum - sum;

        Console.WriteLine("The missing number is: " + missingNumber);
    }
} */

/* using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else
                charCounts[c] = 1;
        }

        var sortedCharCounts = charCounts.OrderBy(x => x.Key);

        foreach (var kvp in sortedCharCounts)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
} */