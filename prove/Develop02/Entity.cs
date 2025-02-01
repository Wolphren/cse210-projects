public class Entry
{
    public string DateTime;
    public string Prompt;
    public string Response;

    public Entry(string dateTime, string prompt, string response)
    {
        DateTime = dateTime;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {DateTime}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }

    public string ToFileString()
    {
        return $"{DateTime}|{Prompt}|{Response}";
    }
}