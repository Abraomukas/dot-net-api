using GamingLibrary.Contracts.GamingLibrary;
using Microsoft.AspNetCore.Mvc;

namespace GamingLibrary.Controllers;

[ApiController]
public class GamingLibraryController : ControllerBase
{
    [HttpPost("/games")]
    public IActionResult CreateGame(CreateGameRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/games/{id:guid}")]
    public IActionResult GetGame(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/games/{id:guid}")]
    public IActionResult UpsertGame(Guid id, UpsertGameRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/games/{id:guid}")]
    public IActionResult DeleteGame(Guid id)
    {
        return Ok(id  );
    }
} 