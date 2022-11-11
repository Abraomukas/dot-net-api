using ErrorOr;
using GamingLibrary.ServiceErrors;
using GamingLibrary.Contracts.GamingLibrary;

namespace GamingLibrary.Models;

public class Game
{

    public const int MinListLength = 1;
    public const int MaxDescriptionLength = 100;
    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string ReleaseYear { get; }

    public int Trophies { get; }

    public bool HasPlatinumTrophy { get; }

    public bool HasMultiplayerTrophies { get; }

    public bool HasOnlineTrophies { get; }

    public List<string> Genre { get; }

    public List<string> Platform { get; }

    private Game(
        Guid id,
        string name,
        string description,
        string releaseYear,
        int trophies,
        bool hasPlatinumTrophy,
        bool hasMultiplayerTrophies,
        bool hasOnlineTrophies,
        List<string> genre,
        List<string> platform)
    {
        Id = id;
        Name = name;
        Description = description;
        ReleaseYear = releaseYear;
        Trophies = trophies;
        HasPlatinumTrophy = hasPlatinumTrophy;
        HasMultiplayerTrophies = hasMultiplayerTrophies;
        HasOnlineTrophies = hasOnlineTrophies;
        Genre = genre;
        Platform = platform;
    }

    public static ErrorOr<Game> Create(
        string name,
        string description,
        string releaseYear,
        int trophies,
        bool hasPlatinumTrophy,
        bool hasMultiplayerTrophies,
        bool hasOnlineTrophies,
        List<string> genre,
        List<string> platform,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (genre.Count is < MinListLength)
        {
            errors.Add(Errors.Game.GenreListError);
        }

        if (platform.Count is < MinListLength)
        {
            errors.Add(Errors.Game.PlatformListError);
        }

        if (errors.Count is > 0)
        {
            return errors;
        }

        return new Game(
            id ?? Guid.NewGuid(),
            name,
            description,
            releaseYear,
            trophies,
            hasPlatinumTrophy,
            hasMultiplayerTrophies,
            hasOnlineTrophies,
            genre,
            platform);
    }

    public static ErrorOr<Game> From(CreateGameRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.ReleaseYear,
            request.Trophies,
            request.HasPlatinumTrophy,
            request.HasMultiplayerTrophies,
            request.HasOnlineTrophies,
            request.Genre,
            request.Platform);
    }

    public static ErrorOr<Game> From(Guid id, UpsertGameRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.ReleaseYear,
            request.Trophies,
            request.HasPlatinumTrophy,
            request.HasMultiplayerTrophies,
            request.HasOnlineTrophies,
            request.Genre,
            request.Platform,
            id);
    }
}