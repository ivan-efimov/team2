using System;
using System.Linq;
using DataLayer.Actions;
using DataLayer.GameService;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private IGameService gameService;
        public MovesController(IGameService gameService) => this.gameService = gameService;
        
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));

            try
            {
                var command = CommandConverter.GetCommand(userInput.KeyPressed);
                gameService.PerformCommand(gameId, command);

                if (userInput.ClickedPos != null)
                    game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            } catch {}

            return new ObjectResult(game);
        }
    }
}