using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis.Models;
using Tenis.Services.Interface;
using Tenis.ViewModels.Games;

namespace Tenis.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGamesService gamesService;
        private readonly IUsersService userService;

        public GamesController(IGamesService gamesService, IUsersService userService)
        {
            this.gamesService = gamesService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllHistory()
        {
            var games = gamesService.GetAllHistoryMatches();
            return Ok(games);
        }

        [HttpGet]
        public IActionResult GetAllOpenMatches()
        {
            var games = gamesService.GetAllOpenMatches();
            return Ok(games);
        }

        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpDelete]
        public IActionResult DeleteGameNotStarted(int id)
        {
            var games = gamesService.DeleteGameNotStarted(id);
            if (games == null)
            {
                return BadRequest(new { ErrorMessage = "Error!" });
            }
            return Ok(games);
        }

        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpPost("createNew")]
        public IActionResult CreateNew([FromBody] GamesPostModel postModel)
        {
            var games = gamesService.Create(postModel, HttpContext);
            if (games == null)
            {
                return BadRequest(new { ErroMessage = "Error on create!" });
            }
            return Ok(games);
        }

    }
}