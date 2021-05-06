using System;

namespace RPS.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(
                new MessageWriter(),
                new MenuResponder(),
                new RoundAssessor(),
                new HumanPlayer(),
                new MachinePlayer(),
                new PlayAgainResponder()
            );

            bool keepGoing;
            do
            {
                keepGoing = game.ShowMenu();
            } while (keepGoing);            
        }
    }
}
