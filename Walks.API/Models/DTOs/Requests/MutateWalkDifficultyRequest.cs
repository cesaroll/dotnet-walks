namespace Walks.API.Models.DTOs.Requests;

public record MutateWalkDifficultyRequest
{
    public string Code { get; init; } = string.Empty;
}