using System;

// EXCEEDING REQUIREMENTS:
// This program exceeds the core requirements by:
// 1. Ensuring that only words that are not already hidden are selected when hiding words.
// 2. Improving user experience by preventing unnecessary re-hiding of already hidden words.
// 3. Structuring the program cleanly using multiple classes with strong encapsulation.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, " +
                      "that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden! Memorization complete.");
    }
}