using System;
using RPS.Enums;

namespace RPS.Interfaces
{
    public interface IMessageWriter
    {
        void Menu(bool p1Human, bool p2Human);
        void Instructions();
        void GameAbandoned();
        void Choice(int player, int round);
        void RoundOutcome(RoundChoices choice1, RoundChoices choice2, RoundOutcomes outcome);
        void Score(IScore score);
        void GameOutcome(IScore score);
        void PlayAgain();
    }
}
