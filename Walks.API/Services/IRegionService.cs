using System;
using Walks.API.Models.DTO;

namespace Walks.API.Services
{
    public interface IRegionService
    {
        IList<RegionDTO> GetAll();
    }
}
