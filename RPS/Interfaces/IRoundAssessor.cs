using System;
using RPS.Enums;

namespace RPS.Interfaces
{
    public interface IRoundAssessor
    {
        public RoundOutcomes Assess(RoundChoices p1Choice, RoundChoices p2Choice);
    }
}
