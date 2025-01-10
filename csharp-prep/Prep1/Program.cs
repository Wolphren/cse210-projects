/*
Author: Wade Davenport

This file asks the user for their first and last names and then prints it back in a James Bond Style
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        //Asks for first name
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        //Asks for last name
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        //Prints name in james Bond style
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}