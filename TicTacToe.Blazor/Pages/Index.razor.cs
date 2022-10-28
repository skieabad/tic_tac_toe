using Microsoft.AspNetCore.Components;
using TicTacToe.Business.Entities;
using TicTacToe.Business;
using TicTacToe.Business.Interface;

namespace TicTacToe.Blazor.Pages
{
    public partial class Index
    {
        private const string Player1 = "Player 1";
        private const string Player2 = "Player 2";

        private static readonly List<GameBoxPosition> Positions = new()
        {
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition(),
            new GameBoxPosition()
        };

        private static bool _isPlayer1Turn = true;
        private static string _winnerPlayer = "";
        private static bool _isPopoverOpen;
        private static string CurrentPlayerName => _isPlayer1Turn ? Player1 : Player2;

        private static string MatchResult = "";

        private static string CurrentWinnerName
        {
            get
            {
                if (string.IsNullOrEmpty(_winnerPlayer))
                {
                    return "";
                }

                return _winnerPlayer == GameConstants.Player1Mark ? Player1 : Player2;
            }
        }

        private string _position0Text = "";
        private string _position1Text = "";
        private string _position2Text = "";
        private string _position3Text = "";
        private string _position4Text = "";
        private string _position5Text = "";
        private string _position6Text = "";
        private string _position7Text = "";
        private string _position8Text = "";

        [Inject] private IGame? Game { get; set; }

        private static string ChangeTextColor(string playerName)
            => playerName == Player1 ? "text-player1" : "text-player2";

        private static string ChangeTextColor(bool isChanged)
            => isChanged ? "text-player1" : "text-player2";

        private void ResetGame()
        {
            _position0Text = "";
            _position1Text = "";
            _position2Text = "";
            _position3Text = "";
            _position4Text = "";
            _position5Text = "";
            _position6Text = "";
            _position7Text = "";
            _position8Text = "";
            _winnerPlayer = "";
            _isPlayer1Turn = true;
            _isPopoverOpen = false;

            foreach (var position in Positions)
            {
                position.Player = "";
            }
        }

        private void Box0Clicked()
        {
            if (!string.IsNullOrEmpty(_position0Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position0Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(0, _position0Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box1Clicked()
        {
            if (!string.IsNullOrEmpty(_position1Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position1Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(1, _position1Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box2Clicked()
        {
            if (!string.IsNullOrEmpty(_position2Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position2Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(2, _position2Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box3Clicked()
        {
            if (!string.IsNullOrEmpty(_position3Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position3Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(3, _position3Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box4Clicked()
        {
            if (!string.IsNullOrEmpty(_position4Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position4Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(4, _position4Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box5Clicked()
        {
            if (!string.IsNullOrEmpty(_position5Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position5Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(5, _position5Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box6Clicked()
        {
            if (!string.IsNullOrEmpty(_position6Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position6Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(6, _position6Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box7Clicked()
        {
            if (!string.IsNullOrEmpty(_position7Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position7Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(7, _position7Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void Box8Clicked()
        {
            if (!string.IsNullOrEmpty(_position8Text) || !string.IsNullOrEmpty(_winnerPlayer))
            {
                return;
            }

            _position8Text = _isPlayer1Turn ? GameConstants.Player1Mark : GameConstants.Player2Mark;
            MarkThePositionsThenPlay(8, _position8Text);
            _isPlayer1Turn = !_isPlayer1Turn;
        }

        private void MarkThePositionsThenPlay(int positionSelected, string playerMark)
        {
            var count = 0;

            foreach (var position in Positions)
            {
                if (positionSelected != count)
                {
                    ++count;
                    continue;
                }

                position.Player = playerMark;
                break;
            }

            var result = Game?.Play(Positions);

            if (result == null)
            {
                return;
            }

            var playerResult = result.PlayerName;

            if (string.IsNullOrEmpty(playerResult) || !result.Winner)
            {
                if (playerResult == "draw")
                {
                    MatchResult = "Draw";
                    _isPopoverOpen = true;
                }

                return;
            }

            _winnerPlayer = playerResult;

            MatchResult = $"The Winner is {CurrentWinnerName}";
            _isPopoverOpen = true;
            StateHasChanged();
        }

        private void ToggleOpen()
        {
            _isPopoverOpen = !_isPopoverOpen;
            ResetGame();
            InvokeAsync(StateHasChanged);
        }
    }
}