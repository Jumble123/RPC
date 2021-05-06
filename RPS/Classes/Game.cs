using System;
using System.Collections.Generic;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Classes
{
    public class Game : IScore
    {
        protected Dictionary<RoundOutcomes, int> _scores = new Dictionary<RoundOutcomes, int>()
        {
            { RoundOutcomes.Tie, 0 },
            { RoundOutcomes.Player1Win, 0 },
            { RoundOutcomes.Player2Win, 0 },
        };
        protected bool _firstGame = true;
        protected bool _player1Human = true;
        protected bool _player2Human = false;

        protected readonly IMessageWriter _messageWriter;
        protected readonly IMenuResponder _menuResponder;
        protected readonly IRoundAssessor _roundAssessor;
        protected readonly IPlayer _humanPlayer;
        protected readonly IPlayer _machinePlayer;
        protected readonly IPlayAgainResponder _playAgainResponder;

        public Game(
            IMessageWriter messageWriter,
            IMenuResponder menuResponder,
            IRoundAssessor roundAssessor,
            IPlayer humanPlayer,
            IPlayer machinePlayer,
            IPlayAgainResponder playAgainResponder
        )
        {
            _messageWriter = messageWriter;
            _menuResponder = menuResponder;
            _roundAssessor = roundAssessor;
            _humanPlayer = humanPlayer;
            _machinePlayer = machinePlayer;
            _playAgainResponder = playAgainResponder;
        }

        protected static int MaxRounds { get; } = 3;

        public virtual int RoundsPlayed => _scores[RoundOutcomes.Tie] + _scores[RoundOutcomes.Player1Win] + _scores[RoundOutcomes.Player2Win];

        public virtual int Ties => _scores[RoundOutcomes.Tie];

        public virtual int P1Score => _scores[RoundOutcomes.Player1Win];

        public virtual int P2Score => _scores[RoundOutcomes.Player2Win];

        public virtual bool GameOver => RoundsPlayed >= MaxRounds || VictorDecided();

        public virtual bool ShowMenu()
        {
            _messageWriter.Menu(_player1Human, _player2Human);
            MenuChoices menuChoice = _menuResponder.GetMenuChoice();

            switch (menuChoice)
            {
                case MenuChoices.Quit:
                    return false;

                case MenuChoices.StartGame:
                    while(StartGame()) { }
                    break;

                case MenuChoices.Toggle1:
                    _player1Human = !_player1Human;                    
                    break;

                case MenuChoices.Toggle2:
                    _player2Human = !_player2Human;                    
                    break;

                default:
                    break;
            }

            return true;
        }

        protected virtual bool StartGame()
        {
            if (_firstGame)
            {
                _firstGame = false;
                _messageWriter.Instructions();
            }
            else
            {
                ResetScore();
            }            

            do
            {
                if (_player1Human)
                {
                    _messageWriter.Choice(1, this.RoundsPlayed + 1);
                }

                RoundChoices choice1 = _player1Human ? _humanPlayer.GetChoice() : _machinePlayer.GetChoice();

                if (_player2Human)
                {
                    _messageWriter.Choice(2, this.RoundsPlayed + 1);
                }

                RoundChoices choice2 = _player2Human ? _humanPlayer.GetChoice() : _machinePlayer.GetChoice();
                RoundOutcomes outcome;

                if (choice1 == RoundChoices.Quit
                    || choice2 == RoundChoices.Quit
                    || (outcome = this._roundAssessor.Assess(choice1, choice2)) == RoundOutcomes.Invalid)
                {
                    _messageWriter.GameAbandoned();
                    return false;
                }

                _scores[outcome]++;

                _messageWriter.RoundOutcome(choice1, choice2, outcome);

                _messageWriter.Score(this);

            } while (!GameOver);

            _messageWriter.GameOutcome(this);
            _messageWriter.PlayAgain();         

            return _playAgainResponder.GetResponse();
        }

        protected virtual void ResetScore()
        {
            _scores[RoundOutcomes.Tie] = 0;
            _scores[RoundOutcomes.Player1Win] = 0;
            _scores[RoundOutcomes.Player2Win] = 0;
        }

        protected virtual bool VictorDecided()
        {
            int diff = Math.Abs(P1Score - P2Score);
            return diff > (MaxRounds - RoundsPlayed);
        }
    }
}
