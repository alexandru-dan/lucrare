using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;
using Tenis.ViewModels.Games;

namespace Tenis.Services.Interface
{
    public interface IGamesService
    {
        IEnumerable<Games> GetAllHistoryMatches();
        IEnumerable<Games> GetAllOpenMatches();
        Games DeleteGameNotStarted(int id);
        Games Create(GamesPostModel gamesModel, HttpContext httpContext);
        Games AddOnExistingGame(int id, HttpContext httpContext, Games games);
        Games UpdateScore(int id, Games score);

    }
}
