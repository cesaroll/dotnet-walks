namespace Walks.API.Models.DTOs;

public record Walk
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public double Length { get; init; }
    public Guid RegionId { get; init; }
    public Guid WalkDifficultyId { get; init; }

    // Navigation Property
    public Region Region { get; init; } = new Region();
    public WalkDifficulty WalkDifficulty { get; init; } = new WalkDifficulty();
}