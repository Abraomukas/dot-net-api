using Microsoft.AspNetCore.Mvc;

namespace GamingLibrary.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}