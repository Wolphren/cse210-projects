public class Journal
{
    public string _fileName = "";
    public void SaveFile()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            
        }
    }

    public void LoadFile()
    {

    }
}