using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Assignment A1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(A1.GetSummary());
        MathAssignment M1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(M1.GetSummary());
        Console.WriteLine(M1.GetHomework());
        WritingAssignment W1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(W1.GetSummary());
        Console.WriteLine(W1.GetWrittenInformation());
    }
}