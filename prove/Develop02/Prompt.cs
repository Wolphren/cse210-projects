public class Prompt
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day and why?",
        "What was the most challenging part of my day and how did I handle it?",
        "What made me laugh today?",
        "What is something new I discovered about myself today?",

        "What is one thing I learned today that surprised me?",
        "What mistake did I make today and what did it teach me?",
        "What skill did I improve on today?",
        "What is something I want to learn more about after today's experiences?",
        "How did I step out of my comfort zone today?",

        "What are three things I'm grateful for today?",
        "What was an unexpected blessing today?",
        "Who am I thankful for today and why?",
        "What made me smile today?",
        "What is something beautiful I saw or experienced today?",

        "What was the strongest emotion I felt today and what triggered it?",
        "How did my actions today align with my values?",
        "What worried me today and how did I cope with it?",
        "What gave me energy today? What drained my energy?",
        "How am I feeling right now and why?",

        "How did I help someone else today?",
        "What meaningful conversation did I have today?",
        "Who do I wish I had talked to today and why?",
        "What act of kindness did I witness or perform today?",
        "How did I show love or appreciation to someone today?",

        "What progress did I make toward my goals today?",
        "What is one thing I want to do differently tomorrow?",
        "What inspired me today?",
        "What is something I'm looking forward to?",
        "If I could redo one part of today, what would it be and why?",

        "How did I take care of myself today?",
        "What brought me peace today?",
        "What was the most nourishing meal I had today?",
        "How well did I balance my responsibilities today?",
        "What did I do today that made me feel proud?"
    };
    
    public string RandomPrompt()
    {
        Random random = new Random();
        int num = random.Next(_prompts.Count);
        return _prompts[num];
    }

}