using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;

class Program
{
    static void Main()
    {
        string input = "1";
        while ( !input.Equals("Q")){
          Console.WriteLine("Enter the array of integers (comma-separated):");
          input = Console.ReadLine();
          switch(input) {
            case "1":
              charCount();
              break;
            case "2":
              missingNumber();
              break;
            case "3":
              reverseOrder();
              break;
            case "4":
              closestToZero();
              break;
            case "5":
              mostFrequentlyOccurring();
              break;
            case "6":
              threading();
              break;
            default:
              // code block
              break;
          }
          
        }
    }
    static void charCount()
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

    static void missingNumber()
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

    static void reverseOrder()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');
        Array.Reverse(words);

        string reversedSentence = string.Join(" ", words);

        Console.WriteLine("Reversed sentence: " + reversedSentence);
    }

    static void closestToZero()
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
    static void mostFrequentlyOccurring()
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

    static void threading()
    {
        // MongoDB connection string and database name
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "your_database_name";

        // Create a MongoDB client
        var client = new MongoClient(connectionString);

        // Access the database
        var database = client.GetDatabase(databaseName);

        // Access the collection
        var collection = database.GetCollection<BsonDocument>("your_collection_name");

        // Create a thread to fetch the documents
        Thread thread = new Thread(() =>
        {
            // Retrieve documents from the collection
            var documents = collection.Find(new BsonDocument()).ToList();

            // Print the documents to the screen
            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
        });

        // Start the thread
        thread.Start();

        // Wait for the thread to complete
        thread.Join();

        // Prompt user to exit the program
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

}