using System.Collections.Generic;
using TicTacToe.Business.Entities;

namespace TicTacToe.Business.Interface
{
    public interface IGame
    {
        Player Play(List<GameBoxPosition> playerPositions);
    }
}
