public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private Random random;

    public Scripture( Reference reference, string text)
    {
        this._reference = reference;
        _words = text.Split(' ')
            .Select(word => new Word(word))
            .ToList();
            random = new Random();
    }

    public void HideWords()
{
    int visibleCount = 0;
    foreach (Word word in _words)
    {
        if (!word.isHidden())
        {
            visibleCount++;
        }
    }

    int wordsToHide;
    if (visibleCount < 3)
    {
        wordsToHide = visibleCount;
    }
    else
    {
        wordsToHide = 3;
    }

    if (wordsToHide == 0)
    {
        return;
    }

    int hiddenCount = 0;
    while (hiddenCount < wordsToHide)
    {
        int index = random.Next(_words.Count); 
        
        if (!_words[index].isHidden())
        {
            _words[index].hide();
            hiddenCount++;
        }
    }
}

    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
    public void display()
    {
        Console.Clear();
        Console.WriteLine(_reference.toString());
        Console.WriteLine(string.Join(' ', _words));
    }
}