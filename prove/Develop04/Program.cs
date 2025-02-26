using System;
using System.Net.Quic;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start breathing activity");
            Console.WriteLine("\t2. Start reflection activity");
            Console.WriteLine("\t3. Start listening activity");
            Console.WriteLine("\t4. Quit");
            Console.WriteLine("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.RunBreath();
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.RunReflection();
                    break;
                case "3":
                    ListeningActivity listening = new ListeningActivity();
                    listening.RunListening();
                    break;
                case "4":
                    quit = true;
                    Console.WriteLine("Thank you for using the Mindfulness Program");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        
        }
    }
}