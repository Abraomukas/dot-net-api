namespace GamingLibrary.Models;

public class Game
{
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

    public Game(
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
        // Enforce invariants
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
}