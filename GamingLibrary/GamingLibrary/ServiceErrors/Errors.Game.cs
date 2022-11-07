using ErrorOr;

namespace GamingLibrary.ServiceErrors;

public static class Errors
{
    public static class Game
    {
        public static Error GenreListError => Error.Validation(
            code: "Game.InvalidGenreList",
            description: $"The game has to be at least part of {Models.Game.MinListLength} genre!"
        );
        public static Error PlatformListError => Error.Validation(
            code: "Game.InvalidPlatformList",
            description: $"The game has to be at least part of {Models.Game.MinListLength} platform!"
        );

        public static Error NotFound => Error.NotFound(
            code: "Game.NotFound",
            description: "Game not found!"
        );
    }

}