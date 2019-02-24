using System;
using Xunit;
using BowlingGameKata;

namespace BowlingGameKataTests
{
    public class GameTests
    {
        [Fact]
        public void ScoreTwoRolls()
        {
            Game game = new Game();

            game.Roll(1);
            game.Roll(1);

            Assert.True(game.Score() == 2);
        }

        [Fact]
        public void ScoreStikeOnFirstRoll()
        {
            Game game = new Game();

            game.Roll(10);
            game.Roll(1);
            game.Roll(1);

            Assert.Equal(14, game.Score());
        }

        [Fact]
        public void ScoreSpareOnFirstRoll()
        {
            Game game = new Game();

            game.Roll(3);
            game.Roll(7);
            game.Roll(1);

            Assert.Equal(12, game.Score());
        }

        Random rand = new Random();

        [Fact]
        public void RandomNoStrikesOrSpares()
        {
            Game game = new Game();

            int score = 0;
            for (int i = 0; i < 20; i++)
            {
                int roll = rand.Next(0, 4);
                score += roll;
                game.Roll(roll);
            }

            Assert.Equal(score, game.Score());
        }

        [Fact]
        public void AllStrikes()
        {
            Game game = new Game();

            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.Equal(300, game.Score());
        }

    }
}
