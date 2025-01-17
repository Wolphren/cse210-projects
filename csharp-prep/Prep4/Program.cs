using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        int userInput = 1;
        float sum = 0;
        int big = 0;
        float average;
        int small = int.MaxValue;
        float numCount = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (userInput != 0){
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0){
                if (userInput > big){
                    big = userInput;
                }
                else if (userInput < small && userInput > 0){
                    small = userInput;
                }
                sum = sum + userInput;
                list.Add(userInput);
                numCount++;
            }
            
        }
        list.Sort();
        average = sum / numCount;
        Console.WriteLine($"The largest number is: {big}");
        Console.WriteLine($"The smallest positive number is: {small}");
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine("The sorted list is:");
        foreach (int i in list){
            Console.WriteLine(i);
        }
        
    }
}