using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1; // Initialize with a value that won't match the magic number

        Console.WriteLine("I'm thinking of a number between 1 and 100...");

        // 2. Add a loop that keeps going until the guess matches the magic number
        while (guess != magicNumber)
        {
            // 3. Ask the user for a guess
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            guess = int.Parse(input);

            // 4. Use if statements to determine hints or success
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}