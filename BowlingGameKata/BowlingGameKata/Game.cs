using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameKata
{
    public class Game
    {
        public List<Frame> Frames = new List<Frame>();
        public int Score { get { return CalculateScore(); } }
        public Game(IEnumerable<Frame> frames)
        {
            Frames.AddRange(frames);
        }

        private int CalculateScore()
        {
            int score = 0;
            for (int frameIndex = 0; frameIndex < Frames.Count; frameIndex++)
            {
                score += Frames[frameIndex].FirstRoll + Frames[frameIndex].SecondRoll;
                if (Frames[frameIndex].IsStrike)
                {
                    // If there are atleast 2 frames left in the game - Add Strike Bonus
                    if (frameIndex + 2 < Frames.Count)
                    {
                        score += StrikeBonus(frameIndex);
                    }
                    // Else only add the 1 remaining frame as StrikeBonus
                    else if (frameIndex + 1 < Frames.Count)
                    {
                        score += Frames[frameIndex + 1].FirstRoll + Frames[frameIndex + 1].SecondRoll;
                    }
                }
                else if (Frames[frameIndex].IsSpare)
                {
                    // Add Spare Bonus if there is atleast 1 frame left in the game
                    if (frameIndex + 1 < Frames.Count)
                    {
                        score += SpareBonus(frameIndex);
                    }
                }

                if (Frames[frameIndex].IsExtendedTenthFrame)
                {
                    score += Frames[frameIndex].ThirdRoll;
                }
            }
            return score;
        }

        private int StrikeBonus(int frameIndex)
        {
            if (Frames[frameIndex + 1].IsStrike)
            {
                return Frames[frameIndex + 1].FirstRoll + Frames[frameIndex + 2].FirstRoll;
            }
            else
            {
                return Frames[frameIndex + 1].FirstRoll + Frames[frameIndex + 1].SecondRoll;
            }
        }

        private int SpareBonus(int frameIndex)
        {
            return Frames[frameIndex + 1].FirstRoll;
        }

    }
}
