using GamingLibrary.Contracts.GamingLibrary;
using GamingLibrary.Models;
using GamingLibrary.Services.Games;

using Microsoft.AspNetCore.Mvc;

namespace GamingLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public IActionResult CreateGame(CreateGameRequest request)
    {
        var game = new Game(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.ReleaseYear,
            request.Trophies,
            request.HasPlatinumTrophy,
            request.HasMultiplayerTrophies,
            request.HasOnlineTrophies,
            request.Genre,
            request.Platform
        );

        _gameService.CreateGame(game);

        var response = new GameResponse(
            game.Id,
            game.Name,
            game.Description,
            game.ReleaseYear,
            game.Trophies,
            game.HasPlatinumTrophy,
            game.HasMultiplayerTrophies,
            game.HasOnlineTrophies,
            game.Genre,
            game.Platform
        );

        return CreatedAtAction(
            actionName: nameof(GetGame),
            routeValues: new { id = game.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetGame(Guid id)
    {
        Game game = _gameService.GetGame(id);

        var response = new GameResponse(
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

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertGame(Guid id, UpsertGameRequest request)
    {
        var game = new Game(
            id,
            request.Name,
            request.Description,
            request.ReleaseYear,
            request.Trophies,
            request.HasPlatinumTrophy,
            request.HasMultiplayerTrophies,
            request.HasOnlineTrophies,
            request.Genre,
            request.Platform
        );

        _gameService.UpsertGame(game);

        //TODO Return 201 if a new game was created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGame(Guid id)
    {
        _gameService.DeleteGame(id);

        return NoContent();
    }
}