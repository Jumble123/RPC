using System;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class MachinePlayer : IPlayer
    {
        protected Random _random = new Random();

        public MachinePlayer()
        {
        }

        public RoundChoices GetChoice()
        {
            return Enum.Parse<RoundChoices>(_random.Next(1, 4).ToString());
        }
    }
}
