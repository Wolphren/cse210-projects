public class Reference
{
    private string _book;
    private int _chapter;
    private string _startVerse;
    private string _endVerse;

public Reference(string book, int chapter)
{
    this._book = book;
    this._chapter = chapter;
}
public Reference(string book, int chapter, string startVerse)
{
    this._book = book;
    this._chapter = chapter;
    this._startVerse = startVerse;
}
    public Reference(string book, int chapter, string startVerse, string endVerse)
    {
        this._book = book;   
        this._chapter = chapter;
        this._startVerse = startVerse;
        this._endVerse = endVerse;
    }

    public string toString()
    {
        if(_startVerse == null)
        {
            return _book + ' ' + _chapter;
        }
        else if(_endVerse == null)
        {
            return _book + ' ' + _chapter + ":" + _startVerse;
        }
        else
        {
        return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
        }
    }
    
}