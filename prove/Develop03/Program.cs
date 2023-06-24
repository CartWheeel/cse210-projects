using System;
using System.Linq;

class ScriptureMemorization
{
    private string scripture;
    private string[] words;
    private int hiddenCount;
    private Random random;

    public ScriptureMemorization(string scripture)
    {
        this.scripture = scripture;
        words = scripture.Split(' ');
        hiddenCount = 0;
        random = new Random();
    }

    private void HideRandomWords(int wordsToHide)
    {
        for (int i = 0; i < wordsToHide; i++)
        {
            int wordIndex = random.Next(0, words.Length);
            if (!words[wordIndex].Contains("_"))
            {
                words[wordIndex] = new string('_', words[wordIndex].Length);
                hiddenCount++;
            }
        }
    }

    public void StartMemorization()
    {
        Console.WriteLine(scripture);

        Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
        string input = Console.ReadLine();

        while (hiddenCount < words.Length && input.ToLower() != "quit")
        {
            Console.Clear();
            int wordsToHide = random.Next(1, 3);
            HideRandomWords(wordsToHide);

            string modifiedScripture = string.Join(" ", words);
            Console.WriteLine(modifiedScripture);

            if (hiddenCount == words.Length)
            {
                Console.WriteLine("\nAll words have been hidden. Press enter to finish.");
            }
            else
            {
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
                input = Console.ReadLine();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string scripture = "2 Nephi 31:20 Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life.";

        ScriptureMemorization memorization = new ScriptureMemorization(scripture);
        memorization.StartMemorization();
    }
}
