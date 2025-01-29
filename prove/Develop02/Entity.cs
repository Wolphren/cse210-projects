public class Entity
{
    public string _dateTime = "";
    public string _prompt = "";
    public string _userEntry = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_dateTime} - Prompt: {_prompt}");
        Console.WriteLine(_userEntry);
    }
}