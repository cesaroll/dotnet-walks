using System;

namespace Walks.API.Models.DTO
{
    public record RegionDTO
    {
        public Guid Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public double Area { get; init; }
        public double Lat { get; init; }
        public double Long { get; init; }
        public long Population { get; init; }
    }
}
