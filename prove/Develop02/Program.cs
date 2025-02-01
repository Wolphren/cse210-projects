using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Prompt promptGenerator = new Prompt();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.Write("\nWhat would you like to do? ");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string prompt = promptGenerator.RandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
                journal.AddEntry(new Entry(currentDate, prompt, response));
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("\n=== Journal Entries ===");
                journal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                journal.SaveToFile();
            }
            else if (userChoice == "4")
            {
                journal.LoadFromFile();
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Thank you for using the journal program. Goodbye!");
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }
}