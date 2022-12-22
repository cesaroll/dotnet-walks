namespace Walks.API.Models.Entities;

public class WalkEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Length { get; set; }
    public Guid RegionId { get; set; }
    public Guid WalkDifficultyId { get; set; }

    // Navigation Property
    public RegionEntity Region { get; set; } = new RegionEntity();
    public WalkDifficultyEntity WalkDifficulty { get; set; } = new WalkDifficultyEntity();
}
