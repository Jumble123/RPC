using System;
using System.Collections.Generic;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class MessageWriter : IMessageWriter
    {
        protected Dictionary<RoundOutcomes, string> _outcomes = new Dictionary<RoundOutcomes, string>
        {
            { RoundOutcomes.Invalid, "that was invalid" },
            { RoundOutcomes.Tie, "that was a tie" },
            { RoundOutcomes.Player1Win, "player 1 takes that round" },
            { RoundOutcomes.Player2Win, "player 2 takes that round" },
        };

        public MessageWriter()
        {
        }

        public void Choice(int player, int round)
        {
            WriteLine("");
            WriteLine($"Round {round}: Player {player}, enter your choice.");
        }

        public void GameAbandoned()
        {
            WriteLine("Game abandoned.");
        }

        public void GameOutcome(IScore score)
        {
            WriteLine("");

            if (score.P1Score > score.P2Score)
            {
                WriteLine("Player 1 has won the game!");
            }
            else if (score.P1Score == score.P2Score)
            {
                WriteLine("The game has ended in a draw.");
            }
            else
            {
                WriteLine("Player 2 has won the game!");
            }
        }

        public void Instructions()
        {
            WriteLine("Welcome to a new game of Rock Paper Scissors.");
            WriteLine("Press a key to register your choice:");
            WriteLine("1 or R - Rock");
            WriteLine("2 or P - Paper");
            WriteLine("3 or S - Scissors");
            WriteLine("Q - Quit.");
        }

        public void Menu(bool p1Human, bool p2Human)
        {
            WriteLine("");
            WriteLine("### Rock Paper Scissors Menu ####");
            WriteLine($"Player 1 is {GetPlayerDescription(p1Human)}");
            WriteLine($"Player 2 is {GetPlayerDescription(p2Human)}");

            WriteLine("Options:");
            WriteLine("1 - Toggle Player 1 Type");
            WriteLine("2 - Toggle Player 2 Type");
            WriteLine("G - Start Game");
            WriteLine("Q - Quit");
        }

        public void PlayAgain()
        {
            WriteLine("");
            WriteLine("Press Q to quit or any other key to play again.");            
        }

        public void RoundOutcome(RoundChoices choice1, RoundChoices choice2, RoundOutcomes outcome)
        {
            WriteLine("");
            WriteLine($"Player 1 chose {choice1} and player 2 chose {choice2}, so {_outcomes[outcome]}.");
        }

        public void Score(IScore score)
        {
            WriteLine($"The score is {score.P1Score} - {score.P2Score}.");
        }

        protected virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        protected string GetPlayerDescription(bool human)
        {
            return human ? "human" : "automated";
        }
    }
}
