public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private Random _random;

    public Scripture( Reference reference, string text)
    {
        this._reference = reference;
        _words = text.Split(' ')
            .Select(word => new Word(word))
            .ToList();
            _random = new Random();
    }

    public void HideWords()
{
    int visibleCount = 0;
    foreach (Word word in _words)
    {
        if (!word.IsHidden())
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
        int _index = _random.Next(_words.Count); 
        
        if (!_words[_index].IsHidden())
        {
            _words[_index].Hide();
            hiddenCount++;
        }
    }
}

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        
        List<string> wordStrings = new List<string>();

        foreach (Word word in _words)
        {
            wordStrings.Add(word.ToString());
        }

        Console.WriteLine(string.Join(' ', wordStrings));
    }
}