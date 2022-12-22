using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class WalkRepository : IWalkRepository
{
    public Task<IList<WalkEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WalkEntity> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<WalkEntity> AddAsync(WalkEntity walk)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<WalkEntity> UpdateAsync(WalkEntity walk)
    {
        throw new NotImplementedException();
    }
}