using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Text RPG Adventure!");

        Game game = new Game();
        game.Start();
    }
}