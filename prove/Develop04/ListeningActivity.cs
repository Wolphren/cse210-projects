public class ListeningActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    public ListeningActivity() : base ("Listening", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

    }
    private string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }
    public void RunListening()
    {
        DisplayStartMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");

        Console.Write("You may begin in: ");
        PauseWithCountdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
        
        Console.WriteLine($"You listed {items.Count} items!");

        DisplayEndMessage();
    }
}