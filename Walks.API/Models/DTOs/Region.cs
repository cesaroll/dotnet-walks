using System;

namespace Walks.API.Models.DTOs
{
    public record Region
    {
        public Guid Id { get; init; }
        public string Code { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public double Area { get; init; }
        public double Lat { get; init; }
        public double Long { get; init; }
        public long Population { get; init; }
    }
}
