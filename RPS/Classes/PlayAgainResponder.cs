using System;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class PlayAgainResponder : IPlayAgainResponder
    {
        public PlayAgainResponder()
        {
        }

        public bool GetResponse()
        {
            var key = Console.ReadKey(true);
            return key.Key != ConsoleKey.Q;
        }
    }
}
