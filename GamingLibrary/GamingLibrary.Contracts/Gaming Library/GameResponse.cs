namespace GamingLibrary.Contracts.GamingLibrary;

public record GameResponse(
    Guid Id,
    string Name,
    string Description,
    string ReleaseYear,
    int Trophies,
    bool HasPlatinumTrophy,
    bool HasMultiplayerTrophies,
    bool HasOnlineTrophies,
    List<string> Genre,
    List<string> Platform
);