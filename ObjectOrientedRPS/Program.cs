using System;

namespace ObjectOrientedRPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            while (game.roundTicker < game.bestOfCounter && !game.HasWinner())
            {
                game.PlayGame();
            }

            Console.WriteLine("Thanks for playing! \nPress Enter to exit.");
            Console.ReadLine();
        }
    }
}
