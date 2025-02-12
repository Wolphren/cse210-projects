using System;

class Program
{
    static void Main(string[] args)
    {
        Word f1 = new Word("Faith");
        Console.WriteLine(f1.isHidden());
        Console.WriteLine(f1.toString());
        f1.hide();
        Console.WriteLine(f1.isHidden());
        Console.WriteLine(f1.toString());

        Reference r1 = new Reference("Proverbs", 3, 5, 6, "Trust in the Lord with all thine heart and trust not unto thine own understanding; in all thy ways acknowledge him");
        Console.WriteLine(r1.toString());
    }
}