using GamingLibrary.Models;
using GamingLibrary.ServiceErrors;

using ErrorOr;

namespace GamingLibrary.Services.Games;

public class GameService : IGameService
{
    private static readonly Dictionary<Guid, Game> _games = new();

    public ErrorOr<Created> CreateGame(Game game)
    {
        _games.Add(game.Id, game);

        return Result.Created;
    }

    public ErrorOr<UpsertedGame> UpsertGame(Game game)
    {
        var IsNewlyCreated = !_games.ContainsKey(game.Id);
        _games[game.Id] = game;

        return new UpsertedGame(IsNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteGame(Guid id)
    {
        _games.Remove(id);

        return Result.Deleted;
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