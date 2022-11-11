using GamingLibrary.Contracts.GamingLibrary;
using GamingLibrary.Models;
using GamingLibrary.Services.Games;
using GamingLibrary.ServiceErrors;

using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace GamingLibrary.Controllers;

public class GamesController : ApiController
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public IActionResult CreateGame(CreateGameRequest request)
    {
        ErrorOr<Game> requestToGameResult = Game.From(request);

        if (requestToGameResult.IsError)
        {
            return Problem(requestToGameResult.Errors);
        }

        var game = requestToGameResult.Value;
        ErrorOr<Created> createGameResult = _gameService.CreateGame(game);

        return createGameResult.Match(
            created => CreatedAtGetGame(game),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetGame(Guid id)
    {
        ErrorOr<Game> getGameResult = _gameService.GetGame(id);

        return getGameResult.Match(breakfast => Ok(MapGameResponse(breakfast)), errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertGame(Guid id, UpsertGameRequest request)
    {
        ErrorOr<Game> requestToGameResult = Game.From(id, request);

        if (requestToGameResult.IsError)
        {
            return Problem(requestToGameResult.Errors);
        }

        var game = requestToGameResult.Value;
        ErrorOr<UpsertedGame> upsertGameResult = _gameService.UpsertGame(game);

        return upsertGameResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetGame(game) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGame(Guid id)
    {
        ErrorOr<Deleted> deletedGameResult = _gameService.DeleteGame(id);

        return deletedGameResult.Match(deleted => NoContent(), errors => Problem(errors));
    }

    private static GameResponse MapGameResponse(Game game)
    {
        return new GameResponse(
            game.Id,
            game.Name,
            game.Description,
            game.ReleaseYear,
            game.Trophies,
            game.HasPlatinumTrophy,
            game.HasMultiplayerTrophies,
            game.HasOnlineTrophies,
            game.Genre,
            game.Platform);
    }

    private CreatedAtActionResult CreatedAtGetGame(Game game)
    {
        return CreatedAtAction(
            actionName: nameof(GetGame),
            routeValues: new { id = game.Id },
            value: MapGameResponse(game));
    }
}