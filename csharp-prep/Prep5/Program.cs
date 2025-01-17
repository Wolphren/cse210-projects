using System;
using System.Xml.XPath;

class Program
{
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program");
    }
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string result = Console.ReadLine();
        return result;
    }
    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int result = int.Parse(Console.ReadLine());
        return result;
    }
    static int SquareNumber(int FavoriteNumber){
        int result = FavoriteNumber * FavoriteNumber;
        return result;
    }
    static void DisplayResult(string UserName, int SquaredNumber){
        Console.WriteLine($"{UserName}, the square of your number is {SquaredNumber}");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int FavoriteNumber = PromptUserNumber();
        int SquaredNumber = SquareNumber(FavoriteNumber);
        DisplayResult(userName, SquaredNumber);
    }
}