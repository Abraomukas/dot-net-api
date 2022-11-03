using GamingLibrary.Models;

namespace GamingLibrary.Services.Games;

public interface IGameService
{
    void CreateGame(Game game);

    void UpsertGame(Game game);

    void DeleteGame(Guid id);

    Game GetGame(Guid id);
}