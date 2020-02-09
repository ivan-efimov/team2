using System;
using DataLayer;
using LightInject;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost]
        public IActionResult Index()
        {
            return new ObjectResult(GameToDto.Convert(_gameService.PerformCommand(Guid.Empty,
                new ResetCommand()).Item1, Guid.NewGuid()));
        }
    }
}
