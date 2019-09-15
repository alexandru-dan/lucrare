using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenis.Models;
using Tenis.Services.Interface;
using Tenis.ViewModels.Games;

namespace Tenis.Services
{
    public class GamesService: IGamesService
    {
        private TenisDbContext context;
        private readonly IUsersService userService;
        public GamesService(TenisDbContext context, IUsersService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public IEnumerable<Games> GetAllHistoryMatches()
        {
            return context.Games.Select(games => new Games
            {
                NameAndSurnameFirstPlayer = games.NameAndSurnameFirstPlayer,
                Score = games.Score,
                NameAndSurnameSecondPlayer = games.NameAndSurnameSecondPlayer,
                FieldNameAndFieldNumber = games.FieldNameAndFieldNumber,
                Status = games.Status,
                DateTime = games.DateTime
            }).Where(u => u.Score != null).OrderByDescending(i => i.DateTime);
        }

        public IEnumerable<Games> GetAllOpenMatches()
        {
            return context.Games.Select(games => new Games
            {
                NameAndSurnameFirstPlayer = games.NameAndSurnameFirstPlayer,
                Score = games.Score,
                NameAndSurnameSecondPlayer = games.NameAndSurnameSecondPlayer,
                FieldNameAndFieldNumber = games.FieldNameAndFieldNumber,
                Status = games.Status,
                DateTime = games.DateTime
            }).Where(u => u.Score == null || u.Status.Equals("Open"));
        }

        public Games DeleteGameNotStarted(int id)
        {
            Games existing = context.Games.FirstOrDefault(u => u.Id == id);

            if (existing == null)
            {
                return null;
            }

            context.Games.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public Games Create(GamesPostModel gamesModel, HttpContext httpContext)
        {
            context.Games.Add(new Games
            {
                FieldNameAndFieldNumber = gamesModel.FieldNameAndFieldNumber,
                DateTime = gamesModel.DateTime,
                NameAndSurnameFirstPlayer = userService.GetCurrentUser(httpContext)
                
            });
            context.SaveChanges();

            return context.Games.Last();
        }

        public Games AddOnExistingGame(int id, HttpContext httpContext, Games games)
        {
            var existing = context.Games.AsNoTracking().FirstOrDefault(game => game.Id == id);
            if (existing == null)
            {
                return null;
            }
            if (existing.Id == userService.GetCurrentUser(httpContext).Id)
            {
                return null;
            }
            games.Id = existing.Id;
            existing.NameAndSurnameSecondPlayer = userService.GetCurrentUser(httpContext);
            existing.Status = "Set";
            context.Games.Update(games);
            context.SaveChanges();

            return games;
        }

        public Games UpdateScore(int id, Games score)
        {
            var existing = context.Games.AsNoTracking().FirstOrDefault(game => game.Id == id);
            if (existing == null)
            {
                return null;
            }
            score.Id = existing.Id;
            existing.Score = score.Score;
            context.Games.Update(score);
            context.SaveChanges();

            return score;

        }

    }
}
