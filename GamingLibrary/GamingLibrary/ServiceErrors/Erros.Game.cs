using ErrorOr;

namespace GamingLibrary.ServiceErrors;

public static class Errors
{
    public static class Game
    {
        public static Error NotFound => Error.NotFound(
            code: "Game.NotFound",
            description: "Game not found"
        );
    }

}