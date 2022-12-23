namespace Walks.API.Models.DTOs;

public record WalkDifficulty
{
    public Guid Id { get; init; }
    public string Code { get; init; } = string.Empty;
}