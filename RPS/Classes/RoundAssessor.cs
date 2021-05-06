using System;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class RoundAssessor : IRoundAssessor
    {
        public virtual RoundOutcomes Assess(RoundChoices p1Choice, RoundChoices p2Choice)
        {
            RoundOutcomes result = RoundOutcomes.Invalid;

            if (p1Choice != RoundChoices.Quit && p2Choice != RoundChoices.Quit)
            {
                int diff = (int)p1Choice - (int)p2Choice;
                if (diff == 0)
                {
                    result = RoundOutcomes.Tie;
                }
                else if (diff == -1 || diff == 2)
                {
                    result = RoundOutcomes.Player2Win;
                }
                else
                {
                    result = RoundOutcomes.Player1Win;
                }
            }

            return result;
        }
    }
}
