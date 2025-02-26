public class Activity 
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(5);
    }
    public void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        PauseWithSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        PauseWithSpinner(5);
        Console.Clear();
    }
    protected void PauseWithSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string spinner = animationStrings[i];
            Console.Write(spinner);
            Thread.Sleep(200);
            Console.Write("\b \b");
            
            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }
    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}