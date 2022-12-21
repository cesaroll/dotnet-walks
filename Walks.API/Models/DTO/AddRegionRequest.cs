using System;

namespace Walks.API.Models.DTO
{
    public record AddRegionRequest
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public double Area { get; init; }
        public double Lat { get; init; }
        public double Long { get; init; }
        public long Population { get; init; }
    }
}
