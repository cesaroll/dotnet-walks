using System;
using Walks.API.Models.Domain;

namespace Walks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IList<Region>> GetAllAsync();
    }
}
