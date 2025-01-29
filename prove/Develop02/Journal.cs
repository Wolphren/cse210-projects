public class Journal
{
    public string _fileName = "";
    public void SaveFile(string _entry)
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            Console.WriteLine(_entry);
        }
    }

    public void LoadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string firstName = parts[0];
            string lastName = parts[1];
        }
    }
}