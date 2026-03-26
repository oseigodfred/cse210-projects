using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }

    public void HideRandomWords(int count)
    {
        int hidden = 0;

        while (hidden < count)
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden)
            {
                _words[index].Hide();
                hidden++;
            }

            // Prevent infinite loop if all words are hidden
            if (AllWordsHidden())
                break;
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }
}