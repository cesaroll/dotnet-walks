using AutoMapper;
using Walks.API.Models.DTOs;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Repositories;

namespace Walks.API.Services;

public class WalkDifficultyService : IWalkDifficultyService
{
    private readonly IWalkDifficultyRepository _repo;
    private readonly IMapper _mapper;

    public WalkDifficultyService(IWalkDifficultyRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IList<WalkDifficulty>> GetAllAsync()
    {
        var walkDifficultyEntities = await _repo.GetAllAsync();
        return _mapper.Map<IList<Models.DTOs.WalkDifficulty>>(walkDifficultyEntities);
    }

    public async Task<WalkDifficulty> GetAsync(Guid id)
    {
        var walkDifficultyEntity = await _repo.GetAsync(id);
        return _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficultyEntity);
    }

    public async Task<WalkDifficulty> AddAsync(MutateWalkDifficultyRequest mutateWalkDifficultyRequest)
    {
        var walkDifficultyEntity = _mapper.Map<Models.Entities.WalkDifficultyEntity>(mutateWalkDifficultyRequest);
        walkDifficultyEntity.Id = Guid.NewGuid();
        
        walkDifficultyEntity = await _repo.AddAsync(walkDifficultyEntity);
        return _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficultyEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }

    public async Task<WalkDifficulty> UpdateAsync(Guid id, MutateWalkDifficultyRequest mutateWalkDifficultyRequest)
    {
        var walkDifficultyEntity = _mapper.Map<Models.Entities.WalkDifficultyEntity>(mutateWalkDifficultyRequest);
        walkDifficultyEntity.Id = id;
        walkDifficultyEntity = await _repo.UpdateAsync(walkDifficultyEntity);
        return _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficultyEntity);
    }
}