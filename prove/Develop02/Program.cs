using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Journal> entries = new List<Journal>();

        bool quit = false;
        while (!quit)
        {
            DisplayMenu();
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                string randomPrompt = GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                string journalEntry = Console.ReadLine();
                entries.Add(new Journal {_Date = DateTime.Now.ToShortDateString(), _Response = journalEntry });
            }
            else if (selection == "2")
            {
                DisplayEntries(entries);
            }
            else if (selection == "3")
            {
                Console.Write("Enter the file name to load: ");
                string fileName = Console.ReadLine();
                entries = ReadFromFile(fileName);
            }
            else if (selection == "4")
            {
                Console.Write("Enter the file name to save: ");
                string saveFileName = Console.ReadLine();
                SaveToFile(entries, saveFileName);
            }
            else if (selection == "5")
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

    }

    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What are things that I'm grateful for today?",
            "What did I eat today?",
            "What success did I see today?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    static void DisplayEntries(List<Journal> entries)
    {
        Console.WriteLine("Previous Entries:");
        foreach (Journal entry in entries)
        {
            Console.WriteLine($"{entry._Date}: {entry._Response}");
        }
    }

    static List<Journal> ReadFromFile(string fileName)
    {
        List<Journal> entries = new List<Journal>();

        try // I found online how to use try and catch so that there aren't any errors that get through.
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~~");
                entries.Add(new Journal { _Date = parts[0], _Response = parts[1] });
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return entries;
    }

    static void SaveToFile(List<Journal> entries, string fileName)
    {
        try // I found online how to use try and catch so that there aren't any errors that get through.
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Journal entry in entries)
                {
                    outputFile.WriteLine($"{entry._Date}~~{entry._Response}");
                }
            }

            Console.WriteLine("Entries saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class Journal
{
    public string _Date { get; set; }
    public string _Response { get; set; }
}