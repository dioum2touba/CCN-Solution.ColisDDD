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
    public class PrixVoyageRegionsService : IPrixVoyageRegionService
    {
        public readonly IPrixVoyageRegionRepository _prixVoyageRegionsRepository;
        private readonly IMapper _mapper;

        public PrixVoyageRegionsService(IPrixVoyageRegionRepository PrixVoyageRegionsRepository, IMapper mapper)
            => (_prixVoyageRegionsRepository, _mapper) = (PrixVoyageRegionsRepository, mapper);

        public async Task<PrixVoyageRegionDto> GetByIdAsync(int id)
            => _mapper.Map<PrixVoyageRegionDto>(await _prixVoyageRegionsRepository.GetByIdAsyncWithInc(id));

        public async Task<PrixVoyageRegionDto> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PrixVoyageRegionDto>> GetAllAsync()
            => _mapper.Map<List<PrixVoyageRegionDto>>(await _prixVoyageRegionsRepository.GetPrixVoyageRegionAllAsyncWithInc());

        public Task<List<PrixVoyageRegionDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PrixVoyageRegionDto> AddAsync(PrixVoyageRegionDto entity)
            => _mapper.Map<PrixVoyageRegionDto>(await _prixVoyageRegionsRepository.AddAsync(_mapper.Map<PrixVoyageRegion>(entity)));

        public async Task UpdateAsync(PrixVoyageRegionDto entity)
            => await _prixVoyageRegionsRepository.UpdateAsync(_mapper.Map<PrixVoyageRegion>(entity));

        public async Task DeleteAsync(PrixVoyageRegionDto entity)
            => await _prixVoyageRegionsRepository.DeleteAsync(_mapper.Map<PrixVoyageRegion>(entity));

        public async Task<bool> IfExists(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IfExists(int id)
        {
            var PrixVoyageRegionss = await _prixVoyageRegionsRepository.GetAllAsync();
            return PrixVoyageRegionss.Any(a => a.Id == id);
        }
    }
}