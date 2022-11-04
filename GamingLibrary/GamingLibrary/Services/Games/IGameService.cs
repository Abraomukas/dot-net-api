using GamingLibrary.Models;

using ErrorOr;

namespace GamingLibrary.Services.Games;

public interface IGameService
{
    void CreateGame(Game game);

    void UpsertGame(Game game);

    void DeleteGame(Guid id);

    ErrorOr<Game> GetGame(Guid id);
}