using System;

class Program
{
    static void Main(string[] args)
    {
        // What is your first name? Scott
        // What is your last name? Burton
        // Your name is Burton, Scott Burton.
        //
        //get user first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        //get user last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();
        //output user name in sentence
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
