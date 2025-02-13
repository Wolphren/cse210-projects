public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        this._text = text;
        this._isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;  
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string ToString()
    {
        if (_isHidden == true)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
            
    }
}