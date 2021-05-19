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
    public class ColisService : IColisService
    {
        public readonly IColisRepository _colisRepository;
        private readonly IMapper _mapper;

        public ColisService(IColisRepository colisRepository, IMapper mapper)
            => (_colisRepository, _mapper) = (colisRepository, mapper);

        public async Task<ColisDto> GetByIdAsync(int id)
            => _mapper.Map<ColisDto>(await _colisRepository.GetByIdAsync(id));

        public async Task<List<ColisDto>> GetAllAsync()
            => _mapper.Map<List<ColisDto>>(await _colisRepository.GetAllAsync());

        public Task<List<ColisDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ColisDto> AddAsync(ColisDto entity)
            => _mapper.Map<ColisDto>(await _colisRepository.AddAsync(_mapper.Map<Colis>(entity)));

        public async Task UpdateAsync(ColisDto entity)
            => await _colisRepository.UpdateAsync(_mapper.Map<Colis>(entity));

        public async Task DeleteAsync(ColisDto entity)
            => await _colisRepository.DeleteAsync(_mapper.Map<Colis>(entity));

        public async Task<bool> IfExists(int id)
        {
            var colis = await _colisRepository.GetAllAsync();
            return colis.Any(a => a.Id == id);
        }

        public List<ColisDto> GetAllColissIncRegions()
        {
            var colis = _mapper.Map<List<ColisDto>>(_colisRepository.GetAllAsync());
            return colis;
        }
    }
}