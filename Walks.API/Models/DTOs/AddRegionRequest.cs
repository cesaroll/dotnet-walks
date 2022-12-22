using System;

namespace Walks.API.Models.DTOs
{
    public record AddRegionRequest
    {
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public double Area { get; init; }
        public double Lat { get; init; }
        public double Long { get; init; }
        public long Population { get; init; }
    }
}
