public class BreathingActivity : Activity
{
    public BreathingActivity() : base ("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {}
    public void Breath()
    {
        Console.WriteLine("Breathe in...");
        DisplayExpandingCircle();
        Console.WriteLine();

        Console.WriteLine("Now breathe out...");
        DisplayContractingCircle();
        Console.WriteLine();
        Console.WriteLine();

    }
    public void RunBreath()
    {
        DisplayStartMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Breath();
        }

        DisplayEndMessage();
    }

    private void DisplayExpandingCircle()
    {
        string[] expandingCircles = {
            "   ( )   ",
            "  (   )  ",
            " (     ) ",
            "(       )"
        };
        foreach (string circle in expandingCircles)
        {
            Console.WriteLine(circle);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', circle.Length));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
    private void DisplayContractingCircle()
    {
        string[] contractingCircles = {
            "(       )",
            " (     ) ",
            "  (   )  ",
            "   ( )   "
        };
        
        foreach (string circle in contractingCircles)
        {
            Console.WriteLine(circle);
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', circle.Length));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}