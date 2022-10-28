using System.Collections.Generic;
using System.Linq;
using TicTacToe.Business.Entities;
using TicTacToe.Business.Interface;

namespace TicTacToe.Business
{
    public class Game : IGame
    {
        private readonly int[,] _winningCombinations =
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };

        private Player _player = new Player();

        public Player Play(List<GameBoxPosition> playerPositions)
        {
            return CheckWinner(playerPositions);
        }

        private Player CheckWinner(IReadOnlyList<GameBoxPosition> playerPositions)
        {
            if (IsDrawGame(playerPositions))
            {
                var playerResult = PlayM(playerPositions);

                if (playerResult != null)
                {
                    return playerResult;
                }

                return new Player
                {
                    Winner = false,
                    PlayerName = "draw"
                };
            }

            var resultPlayer = PlayM(playerPositions);

            if (resultPlayer != null)
            {
                return resultPlayer;
            }

            return new Player
            {
                Winner = false,
                PlayerName = ""
            };
        }

        private Player PlayM(IReadOnlyList<GameBoxPosition> playerPositions)
        {
            for (var i = 0; i < 8; i++)
            {
                int a = _winningCombinations[i, 0], b = _winningCombinations[i, 1], c = _winningCombinations[i, 2];

                if (playerPositions[a].Player == "" || playerPositions[b].Player == "" ||
                    playerPositions[c].Player == "")
                    continue;

                if (playerPositions[a].Player != playerPositions[b].Player ||
                    playerPositions[b].Player != playerPositions[c].Player)
                {
                    continue;
                }

                _player = new Player
                {
                    Winner = true,
                    PlayerName = playerPositions[a].Player
                };

                return _player;
            }

            return null;
        }

        private static bool IsDrawGame(IEnumerable<GameBoxPosition> playerPositions)
        {
            return playerPositions.All(boxPosition =>
                boxPosition.Player == GameConstants.Player1Mark || boxPosition.Player == GameConstants.Player2Mark);
        }
    }
}