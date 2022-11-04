using GamingLibrary.Models;
using GamingLibrary.ServiceErrors;

using ErrorOr;

namespace GamingLibrary.Services.Games;

public class GameService : IGameService
{
    private static readonly Dictionary<Guid, Game> _games = new();

    public void CreateGame(Game game)
    {
        _games.Add(game.Id, game);
    }

    public void UpsertGame(Game game)
    {
        _games[game.Id] = game;
    }

    public void DeleteGame(Guid id)
    {
        _games.Remove(id);
    }

    public ErrorOr<Game> GetGame(Guid id)
    {
        if (_games.TryGetValue(id, out var game))
        {
            return _games[id];
        }

        return Errors.Game.NotFound;
    }
}