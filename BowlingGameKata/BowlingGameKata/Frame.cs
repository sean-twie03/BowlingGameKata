using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameKata
{
    public class Frame
    {
        public Guid Id;
        public int FirstRoll;
        public int SecondRoll;
        public int ThirdRoll;
        public bool IsSpare { get { return DetermineIsSpare(); } }
        public bool IsStrike { get { return DetermineIsStrike(); } }
        public bool IsExtendedTenthFrame { get { return DetermineIsExtendedTenthFrame(); } }
        private bool _threeArgumentConstructor = false;

        public Frame(int firstRoll)
        {
            Id = Guid.NewGuid();
            FirstRoll = firstRoll;

            if (!IsStrike)
            {
                throw new ArgumentException("Frame Constructor with one argument is only valid for a Strike.");
            }

        }

        public Frame(int firstRoll, int secondRoll)
        {
            Id = Guid.NewGuid();
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
        }

        // Extended 10th Frame
        public Frame(int firstRoll, int secondRoll, int thirdRoll)
        {
            Id = Guid.NewGuid();
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            ThirdRoll = thirdRoll;
            _threeArgumentConstructor = true;
            if (!IsExtendedTenthFrame)
            {
                throw new ArgumentException("Frame constructor with three arguments is only valid for Extended 10th Frame.");
            }
        }

        private bool DetermineIsSpare()
        {
            return FirstRoll + SecondRoll == 10;
        }

        private bool DetermineIsStrike()
        {
            return FirstRoll == 10;
        }

        private bool DetermineIsExtendedTenthFrame()
        {
            if (_threeArgumentConstructor && FirstRoll == 10 || FirstRoll + SecondRoll == 10)
            {
                return true;
            }

            return false;
        }
    }
}
