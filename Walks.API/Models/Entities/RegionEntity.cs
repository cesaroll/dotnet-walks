using Microsoft.VisualBasic.CompilerServices;

namespace Walks.API.Models.Entities;

public class RegionEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Area { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public long Population { get; set; }

    // Navigation Property
    public List<WalkEntity>? Walks { get; set; }
}
