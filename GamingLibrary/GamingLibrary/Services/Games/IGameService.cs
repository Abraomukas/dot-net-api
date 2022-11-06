using GamingLibrary.Models;

using ErrorOr;

namespace GamingLibrary.Services.Games;

public interface IGameService
{
    ErrorOr<Created> CreateGame(Game game);

    ErrorOr<UpsertedGame> UpsertGame(Game game);

    ErrorOr<Deleted> DeleteGame(Guid id);

    ErrorOr<Game> GetGame(Guid id);
}