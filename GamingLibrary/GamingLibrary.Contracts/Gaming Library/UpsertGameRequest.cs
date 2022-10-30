namespace GamingLibrary.Contracts.GamingLibrary;

public record UpsertGameRequest(
    string Name,
    string Description,
    string ReleaseYear,
    int Trophies,
    bool PlatinumTrophy,
    bool MultiplayerTrophies,
    bool onlineTrophies,
    List<string> genre,
    List<string> platforms
);