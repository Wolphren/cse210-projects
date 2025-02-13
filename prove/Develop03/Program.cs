using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("3 Nephi", 11, "8", "11");

        string text = "And it came to pass, as they understood they cast their eyes up again towards heaven; and behold, they saw a Man descending out of heaven; and he was clothed in a white robe; and he came down and stood in the midst of them; and the eyes of the whole multitude were turned upon him, and they durst not open their mouths, even one to another, and wist not what it meant, for they thought it was an angel that had appeared unto them. And it came to pass that he stretched forth his hand and spake unto the people, saying: Behold, I am Jesus Christ, whom the prophets testified shall come into the world. And behold, I am the light and the life of the world; and I have drunk out of that bitter cup which the Father hath given me, and have glorified the Father in taking upon me the sins of the world, in the which I have suffered the will of the Father in all things from the beginning.";

        Scripture scripture= new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nPress Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideWords();
        }
    }
}