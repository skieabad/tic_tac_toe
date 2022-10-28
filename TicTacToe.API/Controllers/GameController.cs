using System.Collections.Generic;
using System.Web.Http;
using TicTacToe.Business.Entities;
using TicTacToe.Business.Interface;

namespace TicTacToe.API.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGame _iGame;
        public GameController(IGame iGame)
        {
            _iGame = iGame;
        }

        // POST api/values
        public Player Post([FromBody] List<GameBoxPosition> positions)
        {
            return _iGame.Play(positions);
        }
    }
}
