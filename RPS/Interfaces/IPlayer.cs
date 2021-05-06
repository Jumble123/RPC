using System;
namespace RPS.Interfaces
{
    public interface IPlayer
    {
        RPS.Enums.RoundChoices GetChoice();
    }
}
