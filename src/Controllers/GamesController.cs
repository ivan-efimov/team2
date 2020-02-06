using System;
using DataLayer.GameService;
using Microsoft.AspNetCore.Mvc;
using thegame.Converters;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGameStorage _gameStorage;

        public GamesController(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return new ObjectResult(MapConverter.GameToGameDto(_gameStorage.GetGameById(Guid.Empty)));
        }
    }
}
