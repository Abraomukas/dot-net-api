using GamingLibrary.Models;

namespace GamingLibrary.Services.Games;

public interface IGameService
{
    void CreateGame(Game game);

    Game GetGame(Guid id);
}