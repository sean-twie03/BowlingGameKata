using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameKata
{
    public class Game
    {
        private List<int> _pinsPerRoll = new List<int>();
        public void Roll(int pins)
        {
            _pinsPerRoll.Add(pins);
        }

        public int Score()
        {
            int sum = 0;

            for (int i = 0; i < _pinsPerRoll.Count; i++)
            {
                if (i >= 8)
                {
                   if (_pinsPerRoll[i] == 10)
                    {
                        sum += _pinsPerRoll[i];
                        if (_pinsPerRoll.Count > i + 2)
                        {
                            sum += _pinsPerRoll[i + 1] + _pinsPerRoll[i + 2];
                        }
                        else if (_pinsPerRoll.Count > i + 1)
                        {
                            sum += _pinsPerRoll[i + 1];
                        }
                    }
                    
                }
                else if (_pinsPerRoll[i] == 10 && i < 9)
                {
                    sum += _pinsPerRoll[i] + _pinsPerRoll[i + 1] + _pinsPerRoll[i + 2];
                }
                else if (i != 0 && _pinsPerRoll[i] + _pinsPerRoll[i-1] == 10)
                {
                    sum += _pinsPerRoll[i] + _pinsPerRoll[i + 1];
                }
                else
                {
                    sum += _pinsPerRoll[i];
                }

            }

            return sum;
        }
    }
}
