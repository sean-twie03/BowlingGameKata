using System;
using Xunit;
using BowlingGameKata;
using System.Collections.Generic;

namespace BowlingGameKataTests
{
    public class GameTests
    {
        private List<Frame> GenerateNormalFrames(int numberOfFrames, int numberOfPinsPerRoll)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < numberOfFrames; i++)
            {
                frames.Add(new Frame(numberOfPinsPerRoll, numberOfPinsPerRoll));
            }
            return frames;
        }

        private List<Frame> GenerateStrikeFrames(int numberOfFrames)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < numberOfFrames; i++)
            {
                frames.Add(new Frame(10));
            }
            return frames;
        }

        private List<Frame> GenerateSpareFrames(int numberOfFrames)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < numberOfFrames; i++)
            {
                frames.Add(new Frame(5,5));
            }
            return frames;
        }

        [Fact]
        public void CalculateScore10NormalFrames()
        {
            List<Frame> frames = GenerateNormalFrames(10, 1);
            Game game = new Game(frames);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void CalculateScore1StrikeFollowedBy1NormalFrame()
        {
            List<Frame> frames = GenerateStrikeFrames(1);
            frames.AddRange(GenerateNormalFrames(1, 1));
            Game game = new Game(frames);

            Assert.Equal(14, game.Score);
        }

        [Fact]
        public void CalculateScore1StrikeFollowedBy5NormalFrame()
        {
            List<Frame> frames = GenerateStrikeFrames(1);
            frames.AddRange(GenerateNormalFrames(5, 1));
            Game game = new Game(frames);

            Assert.Equal(22, game.Score);
        }


        [Fact]
        public void CalculateScore12Strikes()
        {
            List<Frame> frames = GenerateStrikeFrames(9);
            // Generate 10th Frame Manually
            frames.Add(new Frame(10, 10, 10));
            Game game = new Game(frames);

            Assert.Equal(300, game.Score);
        }

        [Fact]
        public void CalculateScore1SpareFollowedBy1NormalFrame()
        {
            List<Frame> frames = GenerateSpareFrames(1);
            frames.AddRange(GenerateNormalFrames(1, 1));
            Game game = new Game(frames);

            Assert.Equal(13, game.Score);
        }

        [Fact]
        public void CalculateScore11SparesAndAGutterBall()
        {
            List<Frame> frames = GenerateSpareFrames(9);
            // Generate 10th Frame Manually
            frames.Add(new Frame(5, 5, 0));
            Game game = new Game(frames);

            Assert.Equal(145, game.Score);
        }

    }
}
