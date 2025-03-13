using System;

class Program
{
    static GoalTracker tracker = new GoalTracker();
    
    static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Display Score");
        Console.WriteLine("7. Quit");
        Console.Write("Select a choice from the menu: ");
    }
    
    static Goal CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        
        if (choice == 1)
        {
            return new SimpleGoal(name, description, points);
        }
        else if (choice == 2)
        {
            return new OngoingGoal(name, description, points);
        }
        else if (choice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetCount = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());
            
            return new ChecklistGoal(name, description, points, targetCount, 0, bonusPoints);
        }
        
        return null;
    }
    
    static void Main(string[] args)
    {
        bool quit = false;
        
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        
        while (!quit)
        {
            Console.WriteLine($"\nYou have {tracker.GetTotalScore()} points.");
            
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Goal newGoal = CreateGoal();
                    if (newGoal != null)
                    {
                        tracker.AddGoal(newGoal);
                        Console.WriteLine("Goal created successfully!");
                    }
                    break;
                case "2":
                    tracker.DisplayGoals();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFilename = Console.ReadLine();
                    tracker.SaveGoals(saveFilename);
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string loadFilename = Console.ReadLine();
                    tracker.LoadGoals(loadFilename);
                    Console.WriteLine("Goals loaded successfully!");
                    break;
                case "5":
                    tracker.DisplayGoals();
                    Console.Write("Which goal did you accomplish? ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    tracker.RecordGoalEvent(goalIndex);
                    break;
                case "6":
                    Console.WriteLine($"You currently have {tracker.GetTotalScore()} points.");
                    break;
                case "7":
                    quit = true;
                    Console.WriteLine("Thank you for using the Eternal Quest Program!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}