/*
Author: Wade Davenport

This file asks the user for their grade percentage and then tells them what their grade is and if they are passing
*/
using System;
using System.Reflection.Metadata;

class Program
{   

    
    static string Passing(int userInput)
    {
        // Determines if the user is passing their class
        //
        // Inputs:
        // userInput - the users grade percentage
        //
        // Returns: 
        // message - The pass or fail message

        string message;

        if (userInput >= 70)
        {
            message = "Congratulations!! You Passed!!!";
        }
        else
        {
            message = "I am sorry but you have failed this class.";
        }
        return message;
    }
    static string GradeCheck(int userInput)
    {
        // Determines the users letter grade
        //
        // Inputs:
        // userInput - the users grade percentage
        //
        // Returns: 
        // letter - The users letter grade

        string letter;

        if (userInput >= 90)
        {   
            letter = "A";
        }
        else if (userInput >= 80)
        {
            letter = "B";
        }
        else if (userInput >= 70)
        {
            letter = "C";
        }
        else if (userInput >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        return letter;
    }
    static string GradeSign(int userInput)
    {
        // Determines the users grade sign (+ or -)
        //
        // Inputs:
        // userInput - the users grade percentage
        //
        // Returns: 
        // sign - the users grade sign (+ or -)

        string sign;

        if (userInput % 10 >= 7)
        {
            if (userInput >= 90||userInput <60)
            {
                sign = "";
            }
            else 
            {
                sign = "+";
            }
        }
        else if (userInput % 10 <= 3)
        {
            if (userInput < 60)
            {
                sign = "";
            }
            else 
            {
                sign = "-";
            }
        }
        else 
        {
            sign = " ";
        }
        return sign;
    }
    

    static void Main(string[] args)
    {
        //Asks the user for their grade percentage and save it in a variable
         Console.Write("What is your grade percentage? ");
         string userInput = Console.ReadLine();
         int userInputInt = int.Parse(userInput);

        //runs the functions
         Console.WriteLine(GradeCheck(userInputInt) + GradeSign(userInputInt));
         Console.WriteLine(Passing(userInputInt));

        //establishes variables for the letter grade and the sign
        string letter;
        string sign;

        //calculates the letter grade
        if (userInputInt >= 90)
        {
            letter = "A";
        }
        else if (userInputInt >= 80)
        {
            letter = "B";
        }
        else if (userInputInt >= 70)
        {
            letter = "C";
        }
        else if (userInputInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //calculates the sign
        if (userInputInt % 10 >= 7)
        {
            if (letter == "A"||letter == "F")
            {
                sign = "";
            }
            else 
            {
                sign = "+";
            }
            
        }
        else if (userInputInt % 10 <= 3)
        {
            if (letter == "F")
            {
                sign = "";
            }
            else 
            {
                sign = "-";
            }
        }
        else 
        {
            sign = " ";
        }

        //Prints the letter grade with the sign
        Console.WriteLine(letter + sign);

        //calculates the passing message and prints it
        if (userInputInt >= 70)
        {
            Console.WriteLine("Congratulations!! You Passed!!!");
        }
        else
        {
            Console.WriteLine("I am sorry but you have failed this class.");
        }

        
    }
}