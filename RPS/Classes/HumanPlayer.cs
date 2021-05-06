using System;
using System.Collections.Generic;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class HumanPlayer : IPlayer
    {
        protected Dictionary<string, RoundChoices> _validInputs = new Dictionary<string, RoundChoices>()
        {
            { "Q", RoundChoices.Quit },
            { "1", RoundChoices.Rock },
            { "2", RoundChoices.Paper },
            { "3", RoundChoices.Scissors },
            { "R", RoundChoices.Rock },
            { "P", RoundChoices.Paper },
            { "S", RoundChoices.Scissors }
        };

        public virtual RoundChoices GetChoice()
        {
            do
            {
                var key = Console.ReadKey(true);
                if (_validInputs.TryGetValue(key.KeyChar.ToString().ToUpper(), out RoundChoices value))
                {
                    return value;
                }
            } while (true);
        }
    }
}
