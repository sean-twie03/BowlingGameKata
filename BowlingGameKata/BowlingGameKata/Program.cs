using System;
using System.Collections.Generic;

namespace BowlingGameKata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Frame> frames = new List<Frame>
            {
                new Frame(10),
                new Frame(4, 3),
                new Frame(5, 2),
                new Frame(6, 4),
                new Frame(8, 2),
                new Frame(10, 0),
                new Frame(1, 4),
                new Frame(9, 0),
                new Frame(0, 8),
                new Frame(10, 10, 10),
            };

            Game game = new Game(frames);

            Console.WriteLine($"Game Score = {game.Score}");

            Console.ReadKey();
        }
    }
}
