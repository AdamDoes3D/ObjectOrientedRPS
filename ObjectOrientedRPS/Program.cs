using System;

namespace ObjectOrientedRPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            for (game.roundTicker = 0; game.roundTicker < game.bestOfCounter; game.roundTicker++)
            {
                game.PlayGame();
            }
            Console.ReadLine();
        }
    }
}
