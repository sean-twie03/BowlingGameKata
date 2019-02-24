using System;
using Xunit;
using BowlingGameKata;

namespace BowlingGameKataTests
{
    public class FrameTests
    {
        [Fact]
        public void ConstructorWithOneArgumentSucceedsIfStrike()
        {
            Frame frame = new Frame(10);
            Assert.True(frame.IsStrike);
        }

        [Fact]
        public void ConstructorWithOneArgumentThrowsExceptionIfNotStrike()
        {
            Assert.Throws<ArgumentException>(() => new Frame(1));
        }

        [Fact]
        public void ConstructorWithThreeArgumentsThrowsExceptionIfNotStrikeOrSpare()
        {
            Assert.Throws<ArgumentException>(() => new Frame(1, 1, 1));
        }

        [Fact]
        public void IsStrikeReturnsTrueIfStrikeWithTwoArgumentConstructor()
        {
            Frame frame = new Frame(10,0);
            Assert.True(frame.IsStrike);
        }

        [Fact]
        public void IsStrikeReturnsFalseIfSpare()
        {
            Frame frame = new Frame(9,1);
            Assert.False(frame.IsStrike);
        }

        [Fact]
        public void IsSpareReturnsTrueIfSpareWithTwoArgumentConstructor()
        {
            Frame frame = new Frame(5,5);
            Assert.True(frame.IsSpare);
        }

        [Fact]
        public void IsExtendedFrameReturnsTrueWhenThreeArgumentConstructorIsUsed()
        {
            Frame frame = new Frame(3, 7, 4);
            Assert.True(frame.IsExtendedTenthFrame);
        }
    }
}
