public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    private string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = _random.Next(0, _questions.Count);
        return _questions[index];
    }
    public void RunReflection()
    {
        DisplayStartMessage();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.Write("You may begin in... ");
        PauseWithCountdown(3);
        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"> {question}");
            PauseWithSpinner(10);
            Console.WriteLine();
        }
        
        DisplayEndMessage();
    }
    
}