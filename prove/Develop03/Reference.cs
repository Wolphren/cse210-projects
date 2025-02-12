public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _scriptureText;

    public Reference(string book, int chapter, int startVerse, int endVerse, string scriptureText)
    {
        this._book = book;   
        this._chapter = chapter;
        this._startVerse = startVerse;
        this._endVerse = endVerse;
        this._scriptureText = scriptureText;
    }

    public string toString()
    {
        return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse + " " + _scriptureText;
    }
    
}