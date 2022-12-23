using System;
using AutoMapper;
using Walks.API.Models.DTOs;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Repositories;

namespace Walks.API.Services
{
    public class WalkService : IWalkService
    {
        private readonly IWalkRepository _repo;
        private readonly IMapper _mapper;

        public WalkService(IWalkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IList<Walk>> GetAllAsync()
        {
            var walkEntities = await _repo.GetAllAsync();
            return _mapper.Map<IList<Models.DTOs.Walk>>(walkEntities);
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            var walkEntity = await _repo.GetAsync(id);
            return _mapper.Map<Models.DTOs.Walk>(walkEntity);
        }

        public async Task<Walk> AddAsync(MutateWalkRequest mutateWalkRequest)
        {
            var walkEntity = _mapper.Map<Models.Entities.WalkEntity>(mutateWalkRequest);
            walkEntity.Id = Guid.NewGuid();

            walkEntity = await _repo.AddAsync(walkEntity);
            return _mapper.Map<Models.DTOs.Walk>(walkEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<Walk> UpdateAsync(Guid id, MutateWalkRequest mutateWalkRequest)
        {
            var walkEntity = _mapper.Map<Models.Entities.WalkEntity>(mutateWalkRequest);
            walkEntity.Id = id;

            walkEntity = await _repo.UpdateAsync(walkEntity);
            return _mapper.Map<Models.DTOs.Walk>(walkEntity);
        }
    }
}
