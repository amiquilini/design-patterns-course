using System;
using System.Collections.Generic;

/* Flyweight Coding Exercise
 * You are given a class called Sentence, which takes a string such as "hello world". 
 * You need to provide an interface such that the indexer returns a WordToken  which 
 * can be used to capitalize a particular word in the sentence.
 * 
 * Typical use would be something like:
 * var sentence = new Sentence("hello world");
 * sentence[1].Capitalize = true;
 * WriteLine(sentence); // writes "hello WORLD"
 */

namespace FlyweightPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
        }
    }

    public class Sentence
    {
        private string[] sentence;
        private Dictionary<int, WordToken> words = new();
        public Sentence(string plainText)
        {
            sentence = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                var wordToken = new WordToken();
                words.Add(index, wordToken);
                return wordToken;
            }
        }

        public override string ToString()
        {
            foreach (var word in words)
                if (word.Value.Capitalize) sentence[word.Key] = sentence[word.Key].ToUpper();

            return string.Join(' ', sentence);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
