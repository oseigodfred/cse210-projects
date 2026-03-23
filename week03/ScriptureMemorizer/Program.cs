using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // ------------------ Reference Class ------------------
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        // Constructor for single verse
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        // Constructor for verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (EndVerse.HasValue)
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            else
                return $"{Book} {Chapter}:{StartVerse}";
        }
    }

    // ------------------ Word Class ------------------
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public string GetDisplayText()
        {
            if (IsHidden)
                return new string('_', Text.Length);
            else
                return Text;
        }
    }

    // ------------------ Scripture Class ------------------
    public class Scripture
    {
        public Reference ScriptureReference { get; private set; }
        public List<Word> Words { get; private set; }
        private Random random;

        public Scripture(Reference reference, string text)
        {
            ScriptureReference = reference;
            Words = new List<Word>();
            random = new Random();

            // Split text into words
            string[] wordArray = text.Split(' ');
            foreach (string w in wordArray)
            {
                Words.Add(new Word(w));
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = ScriptureReference.GetDisplayText() + " ";
            foreach (var word in Words)
            {
                scriptureText += word.GetDisplayText() + " ";
            }
            return scriptureText.Trim();
        }

        public void HideRandomWords(int count)
        {
            int hiddenCount = 0;
            int attempts = 0;

            // Hide 'count' words that are not already hidden (stretch improvement)
            while (hiddenCount < count && attempts < 100)
            {
                int index = random.Next(Words.Count);
                if (!Words[index].IsHidden)
                {
                    Words[index].Hide();
                    hiddenCount++;
                }
                attempts++;
            }
        }

        public bool AllWordsHidden()
        {
            foreach (var word in Words)
            {
                if (!word.IsHidden)
                    return false;
            }
            return true;
        }
    }

    // ------------------ Program Class ------------------
    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture
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
                if (input.ToLower() == "quit") break;

                scripture.HideRandomWords(3); // hide 3 words at a time
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden! Memorization complete.");
        }
    }
}