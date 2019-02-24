using System;

namespace BowlingGameKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Roll(10);
            game.Roll(0);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(1);
            game.Roll(1);

            game.Roll(10);
            game.Roll(10);
            game.Roll(1);

            Console.WriteLine(game.Score());
            Console.ReadKey();
        }
    }
}
