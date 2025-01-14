using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        int magicNum;
        int guess;
        int guessNum;
        string userInput;

        do
        {
            Random randomGenerator = new Random();

            magicNum = randomGenerator.Next(1,101);
            guessNum = 0;
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNum == guess)
                {
                    Console.WriteLine("You guessed it!");
                    guessNum = guessNum + 1;
                    Console.WriteLine($"It took you {guessNum} guesses.");
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine("Higher");
                    guessNum = guessNum + 1;
                }
                else
                {
                    Console.WriteLine("Lower");
                    guessNum = guessNum + 1;
                }
            }
            while (guess != magicNum);
            Console.Write("Do you want to play again?(yes/no) ");
            userInput = Console.ReadLine();
        }
        while (userInput == "yes");
        
        
    }
}