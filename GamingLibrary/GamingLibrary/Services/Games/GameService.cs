using GamingLibrary.Models;

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

    public Game GetGame(Guid id)
    {
        return _games[id];
    }
}