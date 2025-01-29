public class Prompt
{
    public List<string> _prompts = new List<string>(){"What did I do today that made me feel good",
    "What did I learn today?",
    "What challenges did I face today?",
    "What am I grateful for today?",
    "What did I do today that made me feel good"
    };
    
    public string RandomPrompt()
    {
        Random random = new Random();
        int num = random.Next(_prompts.Count);
        return _prompts[num];
    }

}