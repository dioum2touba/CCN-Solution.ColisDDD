using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Services
{
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        
        public RegionService(IRegionRepository regionRepository, IMapper mapper)
            => (_regionRepository, _mapper) = (regionRepository, mapper);

        public async Task<RegionDto> GetByIdAsync(int id)
            => _mapper.Map<RegionDto>(await _regionRepository.GetByIdAsync(id));

        public async Task<List<RegionDto>> GetAllAsync()
            => _mapper.Map<List<RegionDto>>(await _regionRepository.GetAllAsync());

        public async Task<List<RegionDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RegionDto> AddAsync(RegionDto entity)
            => _mapper.Map<RegionDto>(await _regionRepository.AddAsync(_mapper.Map<Region>(entity)));

        public async Task UpdateAsync(RegionDto entity)
            => await _regionRepository.UpdateAsync(_mapper.Map<Region>(entity));

        public async Task DeleteAsync(RegionDto entity)
            => await _regionRepository.DeleteAsync(_mapper.Map<Region>(entity));

        public async Task<bool> IfExists(int id)
        {
            var regions = await _regionRepository.GetAllAsync();
            return regions.Any(a => a.Id == id);
        }
    }
}