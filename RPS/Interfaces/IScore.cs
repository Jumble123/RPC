using System;
namespace RPS.Interfaces
{
    public interface IScore
    {
        int Ties { get; }
        int P1Score { get; }
        int P2Score { get; }
        bool GameOver { get; }
    }
}
