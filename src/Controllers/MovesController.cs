using System;
using System.Linq;
using DataLayer.Actions;
using DataLayer.GameService;
using Microsoft.AspNetCore.Mvc;
using thegame.Converters;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private IGameService gameService;
        private IGameStorage gameStorage;
        public MovesController(IGameService gameService, IGameStorage gameStorage)
        {
            this.gameStorage = gameStorage;
            this.gameService = gameService;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = gameStorage.GetGameById(gameId);
            try
            {
                var command = CommandConverter.GetCommand(userInput.KeyPressed);
                return new ObjectResult(MapConverter.GameToGameDto(gameService.PerformCommand(gameId, command)));
            }
            catch
            {
                return new ObjectResult(game);
            }
        }
    }
}