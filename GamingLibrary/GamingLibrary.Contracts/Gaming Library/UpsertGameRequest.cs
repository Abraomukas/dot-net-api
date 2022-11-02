namespace GamingLibrary.Contracts.GamingLibrary;

public record UpsertGameRequest(
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