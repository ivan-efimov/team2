using System;
using System.Linq;
using DataLayer;
using DataLayer.Game;
using Microsoft.AspNetCore.Mvc;
using thegame.InputConverter;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IInputToCommandConverter _inputToCommandConverter;

        public MovesController(IGameService gameService, IInputToCommandConverter inputToCommandConverter)
        {
            _gameService = gameService;
            _inputToCommandConverter = inputToCommandConverter;
        }
        
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            // var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));
            // if (userInput.ClickedPos != null)
            //     game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            // return new ObjectResult(game);
            var result = _gameService.PerformCommand(gameId,
                _inputToCommandConverter.Convert(userInput));
            var gameDto = GameToDto.Convert(result.Item1, gameId);
            if (result.Item2 == TurnResult.GameSolved)
            {
                _gameService.PerformCommand(gameId, new ResetCommand());
            }
            return new ObjectResult(gameDto); // TODO
        }
    }
}