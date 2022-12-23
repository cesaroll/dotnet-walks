namespace Walks.API.Models.DTOs.Requests;

public record MutateWalkRequest
{
    public string Name { get; init; } = string.Empty;
    public double Length { get; init; }
    public Guid RegionId { get; init; }
    public Guid WalkDifficultyId { get; init; }
}